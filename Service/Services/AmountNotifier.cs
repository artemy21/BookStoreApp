using System;
using Model.ItemModels;

namespace Service.Services
{
    public abstract class AmountNotifier
    {
        public static event Action<string> ItemAmountEvent;

        internal static void AmountNotify(AbstractItem item)
        {
            if (item.Amount < 10)
            {
                string itemDetails = GetItemDetails(item);
                ItemAmountEvent?.Invoke(itemDetails);
            }
        }
        private static string GetItemDetails(AbstractItem item)
        {
            string details = $"The {item.GetType().Name} '{item.ItemName}' (ID {item.ItemID}) ";
            string ending = "is going to run out (amount < 10)";
            string gone = "is out of stock";
            return item.Amount != 0 ? details + ending : details + gone;
        }
    }
}
