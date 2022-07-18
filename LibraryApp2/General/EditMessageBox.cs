using System;
using Model.ItemModels;
using LibraryApp2.Views.ManagerViews;

namespace LibraryApp2.General
{
    internal abstract class EditMessageBox
    {
        internal static void EditMessage(AbstractItem item, Action act)
        {
            ValidateParams(item, act);
            var editWindow = new EditItemView(item, act);
            editWindow.Show();
        }
        private static void ValidateParams(AbstractItem item, Action act)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (act == null) throw new ArgumentNullException(nameof(act));
        }
    }
}
