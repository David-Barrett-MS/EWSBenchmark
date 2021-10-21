/*
 * By David Barrett, Microsoft Ltd. 2013-2021. Use at your own risk.  No warranties are given.
 * 
 * DISCLAIMER:
 * THIS CODE IS SAMPLE CODE. THESE SAMPLES ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND.
 * MICROSOFT FURTHER DISCLAIMS ALL IMPLIED WARRANTIES INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OF MERCHANTABILITY OR OF FITNESS FOR
 * A PARTICULAR PURPOSE. THE ENTIRE RISK ARISING OUT OF THE USE OR PERFORMANCE OF THE SAMPLES REMAINS WITH YOU. IN NO EVENT SHALL
 * MICROSOFT OR ITS SUPPLIERS BE LIABLE FOR ANY DAMAGES WHATSOEVER (INCLUDING, WITHOUT LIMITATION, DAMAGES FOR LOSS OF BUSINESS PROFITS,
 * BUSINESS INTERRUPTION, LOSS OF BUSINESS INFORMATION, OR OTHER PECUNIARY LOSS) ARISING OUT OF THE USE OF OR INABILITY TO USE THE
 * SAMPLES, EVEN IF MICROSOFT HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. BECAUSE SOME STATES DO NOT ALLOW THE EXCLUSION OR LIMITATION
 * OF LIABILITY FOR CONSEQUENTIAL OR INCIDENTAL DAMAGES, THE ABOVE LIMITATION MAY NOT APPLY TO YOU.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace EWSBenchmark
{
    struct FolderProcessInfo
    {
        public ExchangeService exchangeService;
        public string folderId;
    }

    public class ClassBenchmark
    {
        private ClassLogger _logger = null;
        private ClassStats _stats = null;
        private ExchangeService _service = null;
        private ClassTraceListener _traceListener = null;
        private string _mailbox = "";
        private int _maxItems = 50;
        private int _testRuns = 1;
        private int _folderProcessingThreads = 1;
        private bool _testRunning = false;
        private bool _stopRequested = false;
        private int _foldersBeingProcessed = 0;
        private FolderId _allItemsFolderId = null;
        private DateTime _backOffEndTime = DateTime.MinValue;
        private Queue<string> _conversationIdsToSearch = null;
        public static bool IgnoreSSLErrors { get; set; } = false;


        public ClassBenchmark(string Mailbox, ExchangeCredentials Credentials, ClassStats Stats, ClassLogger Logger, string EWSUrl = "")
        {
            _service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
            ServicePointManager.ServerCertificateValidationCallback = ValidateCertificate;
            _service.Credentials = Credentials;
            _mailbox = Mailbox;
            _stats = Stats;
            _logger = Logger;
            long startTicks = DateTime.Now.Ticks;
            if (!String.IsNullOrEmpty(EWSUrl))
            {
                _logger.Log($"Using EWS URL: {EWSUrl}");
                _service.Url = new Uri(EWSUrl);
            }
            else
            {
                _logger.Log(String.Format("Performing autodiscover for {0}", Mailbox));
                try
                {
                    _service.AutodiscoverUrl(Mailbox, AutodiscoverCallback);
                }
                catch (Exception ex)
                {
                    _logger.Log(String.Format("Autodiscover failed: {0}", ex.Message));
                }
                finally
                {
                    long endTicks = DateTime.Now.Ticks;
                    Stats.AddStat("Autodiscover", endTicks - startTicks);
                }
            }
        }

        public void Stop()
        {
            _stopRequested = true;
        }

        static bool AutodiscoverCallback(string redirectionUrl)
        {
            return true;
        }

        static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if ( IgnoreSSLErrors || (errors == SslPolicyErrors.None))
                return true;

            return false;
        }

        public void Impersonate(string ImpersonateId)
        {
            _service.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, ImpersonateId);
            _service.HttpHeaders.Add("X-AnchorMailbox", ImpersonateId); // Required for Exchange 2013+
            _mailbox = ImpersonateId;
        }

        public ClassLogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        public int MaxItems
        {
            get { return _maxItems; }
            set { _maxItems = value; }
        }

        public int TestRuns
        {
            get { return _testRuns; }
            set { _testRuns = value; }
        }

        public int MaxThreads
        {
            get { return _folderProcessingThreads; }
            set
            {
                _folderProcessingThreads = value;
                ThreadPool.SetMaxThreads(_folderProcessingThreads, _folderProcessingThreads);
            }
        }

        public void RunBenchmark()
        {
            if (_testRunning)
                return;

            // The benchmark involves going through each folder of the mailbox
            if (_service.Url == null)
            {
                _logger.Log("Cannot benchmark, EWS failed to initialise");
                return;
            }

            _conversationIdsToSearch = new Queue<string>();
            _stopRequested = false;
            _testRunning = true;
            for (int i = 0; i < _testRuns; i++)
            {
                _logger.Log(String.Format("Starting test run {0}", i+1));
                Folder rootFolder = TimedFolderBind(WellKnownFolderName.MsgFolderRoot);
                RecurseFolders(rootFolder);
                if (_stopRequested)
                    break;
            }

            if (_folderProcessingThreads>1)
            {
                while (_foldersBeingProcessed > 0)
                    Thread.Yield();
            }

            _testRunning = false;

            // Benchmark has completed, so write the stats to the logger
            _logger.Log("--------------------------------------------------------------------------");
            _logger.Log($"Statistics {_mailbox}");
            _logger.Log("--------------------------------------------------------------------------");
            _stats.LogStats(_logger);
            _logger.Log("--------------------------------------------------------------------------");
        }

        public void SetTraceFile(string TraceFile)
        {
            _traceListener = new ClassTraceListener(TraceFile);
            _service.TraceListener = _traceListener;
            _service.TraceFlags = TraceFlags.All;
            _service.TraceEnabled = true;
        }

        private bool Throttled(Exception ex)
        {
            // Check if we were throttled, and if so, back off for the specified time
            if (ex is ServerBusyException)
            {
                // Need to read BackoffMilliseconds and work out when we can next send data
                _backOffEndTime = DateTime.Now.AddMilliseconds(((ServerBusyException)ex).BackOffMilliseconds);
                _stats.AddStat("Throttled", 1);
                return true;
            }
            Logger?.Log($"Unexpected error: {ex.Message}");
            return false;
        }

        private void SleepIfThrottled()
        {
            if (_backOffEndTime <= DateTime.Now)
                return;

            int millisecondsUntilResume = (int)_backOffEndTime.Subtract(DateTime.Now).TotalMilliseconds;
            if (millisecondsUntilResume>0)
                Thread.Sleep(millisecondsUntilResume);
        }

        private void RecurseFolders(Folder rootFolder)
        {
            FindFoldersResults results = TimedFindFolders(rootFolder, new FolderView(500));
            if (results != null)
            {
                foreach (Folder folder in results)
                {
                    ProcessFolder(folder);
                    if (_stopRequested)
                        break;
                    RecurseFolders(folder);
                    if (_stopRequested)
                        break;
                }
            }
        }

        private ExchangeService CopyExchangeServiceObject(ExchangeService exchangeService)
        {
            // For thread safety, we must use a unique ExchangeService object per thread
            ExchangeService copiedExchangeService = new ExchangeService(exchangeService.RequestedServerVersion);
            copiedExchangeService.Url = exchangeService.Url;
            copiedExchangeService.Credentials = exchangeService.Credentials;
            if (exchangeService.ImpersonatedUserId != null)
            {
                if (!String.IsNullOrEmpty(exchangeService.ImpersonatedUserId.Id))
                {
                    _service.ImpersonatedUserId = new ImpersonatedUserId(exchangeService.ImpersonatedUserId.IdType, exchangeService.ImpersonatedUserId.Id);
                    _service.HttpHeaders.Add("X-AnchorMailbox", exchangeService.ImpersonatedUserId.Id); // Required for Exchange 2013+            }
                }
            }

            if (exchangeService.TraceListener != null)
            {
                copiedExchangeService.TraceListener = exchangeService.TraceListener;
                copiedExchangeService.TraceFlags = exchangeService.TraceFlags;
                copiedExchangeService.TraceEnabled = exchangeService.TraceEnabled;
            }
            return copiedExchangeService;
        }

        void ProcessFolderAsync(object e)
        {
            ExchangeService service = ((FolderProcessInfo)e).exchangeService;
            Folder folder = TimedFolderBind(((FolderProcessInfo)e).folderId, service);
            if ( (folder==null) || _maxItems == 0)
                return;

            _logger.Log($"Starting to process folder {folder.DisplayName}");
            _foldersBeingProcessed++;
            int iPageSize = 500;
            if ((_maxItems > 0) && (_maxItems < iPageSize))
                iPageSize = _maxItems;
            int iItemsRetrieved = 0;
            int iOffset = 0;
            bool bMoreItems = true;

            while (bMoreItems)
            {
                ItemView view = new ItemView(iPageSize, iOffset, OffsetBasePoint.Beginning);
                view.PropertySet = new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.ConversationId);
                view.Traversal = ItemTraversal.Shallow;
                FindItemsResults<Item> results = TimedFindItems(folder.Id, view, service);

                if (results != null)
                {
                    foreach (Item item in results)
                    {
                        if (!String.IsNullOrEmpty(item.ConversationId.UniqueId))
                            new Thread(() => { TimedFindItemsAllItemsSearch(item.ConversationId.UniqueId, CopyExchangeServiceObject(service)); }).Start();

                        TimedItemBind(item.Id);
                        if (_stopRequested)
                            break;
                    }

                    iItemsRetrieved += results.Items.Count;
                    bMoreItems = results.MoreAvailable;
                    if (((_maxItems > 0) && (iItemsRetrieved >= _maxItems)) || _stopRequested)
                        bMoreItems = false;
                }
                else
                    bMoreItems = false;
            }
            _foldersBeingProcessed--;
            _logger.Log($"Finished processing folder {folder.DisplayName}");
        }

        private void ProcessFolder(Folder folder)
        {
            if (_folderProcessingThreads > 1)
            {
                // Queue the folder processing on a new thread and then return
                FolderProcessInfo folderProcessInfo;
                folderProcessInfo.exchangeService = CopyExchangeServiceObject(_service);
                folderProcessInfo.folderId = folder.Id.UniqueId;
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessFolderAsync), folderProcessInfo);
                return;
            }

            _logger.Log(String.Format("Processing folder {0}", folder.DisplayName));
            folder = TimedFolderBind(folder.Id);
            if (_maxItems == 0)
                return;

            int iPageSize = 500;
            if ((_maxItems > 0) && (_maxItems < iPageSize))
                iPageSize = _maxItems;
            int iItemsRetrieved = 0;
            int iOffset = 0;
            bool bMoreItems = true;

            while (bMoreItems)
            {
                ItemView view = new ItemView(iPageSize, iOffset,OffsetBasePoint.Beginning);
                view.PropertySet = BasePropertySet.IdOnly;
                view.Traversal = ItemTraversal.Shallow;
                FindItemsResults<Item> results = TimedFindItems(folder.Id, view);

                foreach (Item item in results)
                {
                    TimedItemBind(item.Id);
                    if (_stopRequested)
                        break;
                }

                iItemsRetrieved += results.Items.Count;
                bMoreItems = results.MoreAvailable;
                if ( ((_maxItems > 0) && (iItemsRetrieved >= _maxItems)) || _stopRequested )
                    bMoreItems = false;
            }
        }

        private Folder TimedFolderBind(FolderId folderId, ExchangeService exchangeService = null)
        {
            if (exchangeService == null)
                exchangeService = CopyExchangeServiceObject(_service);

            SleepIfThrottled();

            Folder folder = null;
            long startTicks = DateTime.Now.Ticks;
            try
            {
                folder = Folder.Bind(exchangeService, folderId, BasePropertySet.FirstClassProperties);
            }
            catch (Exception ex)
            {
                Throttled(ex);
            }
            finally
            {
                long endTicks = DateTime.Now.Ticks;
                _stats.AddStat("GetFolder", endTicks - startTicks);
            }
            return folder;
        }

        private Item TimedItemBind(ItemId itemId, ExchangeService exchangeService = null)
        {
            if (exchangeService == null)
                exchangeService = CopyExchangeServiceObject(_service);

            SleepIfThrottled();

            Item item = null;
            long startTicks = DateTime.Now.Ticks;
            try
            {
                item = Item.Bind(exchangeService, itemId, BasePropertySet.FirstClassProperties);
            }
            catch (Exception ex)
            {
                Throttled(ex);
            }
            finally
            {
                long endTicks = DateTime.Now.Ticks;
                _stats.AddStat("GetItem", endTicks - startTicks);
            }
            return item;
        }


        private FindFoldersResults TimedFindFolders(Folder folder, FolderView folderView)
        {
            if (folder == null)
                return null;

            SleepIfThrottled();

            FindFoldersResults results = null;
            long startTicks = DateTime.Now.Ticks;
            try
            {
                results = folder.FindFolders(folderView);
            }
            catch (Exception ex)
            {
                Throttled(ex);
            }
            finally
            {
                long endTicks = DateTime.Now.Ticks;
                _stats.AddStat("FindFolders", endTicks - startTicks);
            }
            return results;
        }

        private FindItemsResults<Item> TimedFindItems(FolderId folderId, ItemView view, ExchangeService exchangeService = null)
        {
            if (exchangeService == null)
                exchangeService = _service;

            SleepIfThrottled();

            FindItemsResults<Item> results = null;
            long startTicks = DateTime.Now.Ticks;
            try
            {
                results = exchangeService.FindItems(folderId, view);
            }
            catch (Exception ex)
            {
                Throttled(ex);
            }
            finally
            {
                long endTicks = DateTime.Now.Ticks;
                _stats.AddStat("FindItems", endTicks - startTicks);
            }
            return results;
        }

        private FolderId AllItemsFolderId(ExchangeService exchangeService)
        {
            SleepIfThrottled();

            if (_allItemsFolderId == null)
            {
                // Need to find the Id for All Items folder. Should be MsgFolderRoot/AllItems
                FolderView view = new FolderView(2, 0, OffsetBasePoint.Beginning);
                view.PropertySet = BasePropertySet.IdOnly;
                view.Traversal = FolderTraversal.Shallow;

                SearchFilter searchFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "AllItems");

                FindFoldersResults results = exchangeService.FindFolders(new FolderId(WellKnownFolderName.Root), searchFilter, view);
                if (results.TotalCount == 1)
                    _allItemsFolderId = results.Folders[0].Id;
            }
            return _allItemsFolderId;
        }

        private FindItemsResults<Item> TimedFindItemsAllItemsSearch(string conversationId, ExchangeService exchangeService = null)
        {
            if (exchangeService == null)
                exchangeService = _service;

            ItemView view = new ItemView(100, 0, OffsetBasePoint.Beginning);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.ConversationId);
            view.Traversal = ItemTraversal.Shallow;

            SearchFilter searchFilter = new SearchFilter.IsEqualTo(EmailMessageSchema.ConversationId, conversationId);

            SleepIfThrottled();

            FindItemsResults<Item> results = null;
            long startTicks = DateTime.Now.Ticks;
            try
            {
                results = exchangeService.FindItems(AllItemsFolderId(exchangeService), searchFilter, view);
            }
            catch (Exception ex)
            {
                Throttled(ex);
            }
            finally
            {
                long endTicks = DateTime.Now.Ticks;
                _stats.AddStat("FindItemsAllItemsSearch", endTicks - startTicks);
            }
            return results;
        }
    }
}
