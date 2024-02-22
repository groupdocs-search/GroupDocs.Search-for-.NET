using System;
using System.Collections.Specialized;
using System.Windows.Controls;

namespace GroupDocs.Search.IndexBrowser.Controls
{
    public class CustomListView : ListView
    {
        public event EventHandler ItemsChanged;

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            ItemsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
