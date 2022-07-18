using System;
using Service.API;
using Model.ItemModels;

namespace Service.Services
{
    public class CartAddService : ICartaddable, ICartaddEvent
    {
        public event Action<AbstractItem, int> CartAddEvent;
        public void CartAdd(AbstractItem item, int amount)
        {
            ValidateInput(item, amount);
            item.Amount -= amount;
            AmountNotifier.AmountNotify(item);
            CartAddEvent?.Invoke(item, amount);
            if (item.Amount == 0) DeleteService.DeleteItem(item);
        }
        private void ValidateInput(AbstractItem item, int amount)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (amount < 1) throw new ArgumentOutOfRangeException(nameof(amount), "amount < 0");
            if (amount > item.Amount) throw new ArgumentOutOfRangeException(nameof(amount), "amount > item amount");
        }
    }
}
