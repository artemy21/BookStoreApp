using System;
using System.Collections;
using System.Windows.Data;

namespace LibraryApp2.General
{
    internal abstract class ListUpdater
    {
        internal static event Action UpdateCatalogEvent;
        internal static void RefreshList(ICollection list)
        {
            if (list == null) throw new ArgumentNullException("list");
            CollectionViewSource.GetDefaultView(list).Refresh();
            UpdateCatalogEvent?.Invoke();
        }
    }
}
