using System;
using System.Windows;
using Service.Services;
using Model.ItemModels;

namespace LibraryApp2.General
{
    internal abstract class DeleteMessageBox
    {
        internal static void DeleteMessage(AbstractItem item, Action act)
        {
            ValidateParams(item, act);
            var res = MessageBox.Show("Are you sure?", "Delete Item", MessageBoxButton.OKCancel);
            if (res != MessageBoxResult.Cancel) DeleteService.DeleteItem(item);
            act();
        }
        private static void ValidateParams(AbstractItem item, Action act)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (act == null) throw new ArgumentNullException(nameof(act));
        }
    }
}
