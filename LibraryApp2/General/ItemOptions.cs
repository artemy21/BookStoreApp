using System;
using System.Windows;
using Model.ItemModels;
using System.Windows.Forms;

namespace LibraryApp2.General
{
    internal abstract class ItemOptions
    {
        internal static MessageBoxResult ShowItemOptions(AbstractItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            RegisterMessageBox();
            var res = MessageBox.Show(ShowItemInfo(item), item.GetType().Name, MessageBoxButton.YesNoCancel);
            MessageBoxManager.Unregister();
            return res;
        }
        private static void RegisterMessageBox()
        {
            MessageBoxManager.Yes = "Edit";
            MessageBoxManager.No = "Delete";
            MessageBoxManager.Register();
        }
        private static string ShowItemInfo(AbstractItem item)
        {
            return "Name: " + $"{item.ItemName}\n" +
                   "ID: " + $"{item.ItemID}\n" +
                   "Genre: " + $"{item.Genre}\n" +
                   "Author: " + $"{item.Author}\n" +
                   "Unit Price: " + $"{item.Price}\n" +
                   "Amount in storage: " + $"{item.Amount}";
        }
    }
}
