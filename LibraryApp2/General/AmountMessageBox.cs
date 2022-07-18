using System;
using Model.ItemModels;
using Service.Services;
using LibraryApp2.Views.CustomerViews;

namespace LibraryApp2.General
{
    internal abstract class AmountMessageBox
    {
        internal static void AmountMessage(AbstractItem item, Action act)
        {
            ValidateParams(item, act);
            var amountWindow = new OrderAmountView(item);
            amountWindow.Show();
            act();
        }
        private static void ValidateParams(AbstractItem item, Action act)
        {
            ValidatorService.ArgumentNotNull(item, nameof(item));
            ValidatorService.ArgumentNotNull(act, nameof(act));
        }
    }
}
