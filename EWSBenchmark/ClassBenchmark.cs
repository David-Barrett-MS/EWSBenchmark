using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using System.Net;

namespace EWSBenchmark
{
    class ClassBenchmark
    {
        private ClassLogger _logger = null;
        private ClassStats _stats = null;
        private ExchangeService _service = null;
        private int _maxItems = 50;
        private int _testRuns = 1;

        public ClassBenchmark(string Mailbox, ClassStats Stats, ClassLogger Logger)
        {
            _service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            _service.UseDefaultCredentials = true;
            _stats = Stats;
            _logger = Logger;
            _logger.Log(String.Format("Performing autodiscover for {0}", Mailbox));
            long startTicks = DateTime.Now.Ticks;
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

        public ClassBenchmark(string Mailbox, ExchangeCredentials Credentials, ClassStats Stats, ClassLogger Logger, string EWSUrl = "")
        {
            _service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            _service.Credentials = Credentials;
            _stats = Stats;
            _logger = Logger;
            _logger.Log(String.Format("Performing autodiscover for {0}", Mailbox));
            long startTicks = DateTime.Now.Ticks;
            if (!String.IsNullOrEmpty(EWSUrl))
            {
                _service.Url = new Uri(EWSUrl);
            }
            else
            {
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

        static bool AutodiscoverCallback(string redirectionUrl)
        {
            return true;
        }
        public ClassBenchmark(Uri EWSUrl, ExchangeCredentials Credentials, ClassStats Stats, ClassLogger Logger)
        {
            _service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            _service.Credentials = Credentials;
            _stats = Stats;
            _logger = Logger;
            _service.Url = EWSUrl;
        }

        public void Impersonate(string ImpersonateId)
        {
            _service.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, ImpersonateId);
            _service.HttpHeaders.Add("X-AnchorMailbox", ImpersonateId); // Required for Exchange 2013+
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

        public void StartBenchmark()
        {
            // The benchmark involves going through each folder of the mailbox
            if (_service.Url == null)
            {
                _logger.Log("Cannot benchmark, EWS failed to initialise");
                return;
            }
            for (int i = 0; i < _testRuns; i++)
            {
                _logger.Log(String.Format("Starting test run {0}", i+1));
                Folder rootFolder = TimedFolderBind(WellKnownFolderName.MsgFolderRoot);
                RecurseFolders(rootFolder);
            }

            // Benchmark has completed, so write the stats to the logger
            _logger.Log("--------------------------------------------------------------------------");
            _logger.Log("Statistics");
            _logger.Log("--------------------------------------------------------------------------");
            _stats.LogStats(_logger);
            _logger.Log("--------------------------------------------------------------------------");
        }

        private void RecurseFolders(Folder rootFolder)
        {
            foreach (Folder folder in TimedFindFolders(rootFolder, new FolderView(500)))
            {
                _logger.Log(String.Format("Processing folder {0}", folder.DisplayName));
                ProcessFolder(folder);
                RecurseFolders(folder);
            }
        }

        private void ProcessFolder(Folder folder)
        {
            folder = TimedFolderBind(folder.Id);

            int iPageSize = 500;
            if (_maxItems < iPageSize)
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
                }

                iItemsRetrieved += results.Items.Count;
                bMoreItems = results.MoreAvailable;
                if (iItemsRetrieved > _maxItems)
                    bMoreItems = false;
            }
        }

        private Folder TimedFolderBind(FolderId folderId)
        {
            Folder folder = null;
            long startTicks = DateTime.Now.Ticks;
            try
            {
                folder = Folder.Bind(_service, folderId, BasePropertySet.FirstClassProperties);
            }
            finally
            {
                long endTicks = DateTime.Now.Ticks;
                _stats.AddStat("GetFolder", endTicks - startTicks);
            }
            return folder;
        }

        private Item TimedItemBind(ItemId itemId)
        {
            Item item = null;
            long startTicks = DateTime.Now.Ticks;
            try
            {
                item = Item.Bind(_service, itemId, BasePropertySet.FirstClassProperties);
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
            FindFoldersResults results = null;
            long startTicks = DateTime.Now.Ticks;
            try
            {
                results = folder.FindFolders(folderView);
            }
            finally
            {
                long endTicks = DateTime.Now.Ticks;
                _stats.AddStat("FindFolders", endTicks - startTicks);
            }
            return results;
        }

        private FindItemsResults<Item> TimedFindItems(FolderId folderId, ItemView view)
        {
            FindItemsResults<Item> results = null;
            long startTicks = DateTime.Now.Ticks;
            try
            {
                results = _service.FindItems(folderId, view);
            }
            finally
            {
                long endTicks = DateTime.Now.Ticks;
                _stats.AddStat("FindItems", endTicks - startTicks);
            }
            return results;
        }
    }
}
