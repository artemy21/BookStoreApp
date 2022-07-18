using System;
using Service.API;
using System.Windows;
using Model.ItemModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace LibraryApp2.ViewModel.CustomerViewModels
{
    public class OrderAmountViewModel : ViewModelBase
    {
        private readonly ICartaddable cartService;

        #region Item
        private AbstractItem item;
        public AbstractItem Item
        {
            get => item;
            set
            {
                Set(ref item, value);
                if (Item != null) Price = item.DiscountPrice * Amount;
            }
        }
        private double price;
        public double Price
        {
            get => Item != null ? Item.DiscountPrice * Amount : 0;
            set => Set(ref price, value);
        }
        #endregion

        #region Amount
        private int amount = 1;
        public int Amount
        {
            get => amount;
            set
            {
                if (value > 0 && value <= Item.Amount)
                {
                    Set(ref amount, value);
                    MaxAmountVisibility = Visibility.Collapsed;
                }
                if (value >= Item.Amount) MaxAmountVisibility = Visibility.Visible;
                Price = Item.DiscountPrice * Amount;
            }
        }
        public RelayCommand IncrementCommand { get; }
        public RelayCommand DecrementCommand { get; }

        private Visibility maxAmountVisibility = Visibility.Collapsed;
        public Visibility MaxAmountVisibility
        {
            get => maxAmountVisibility;
            set => Set(ref maxAmountVisibility, value);
        }
        #endregion

        public event Action CloseWindowEvent;
        public RelayCommand CartAddCommand { get; }

        public OrderAmountViewModel(ICartaddable cartService)
        {
            this.cartService = cartService;
            IncrementCommand = new RelayCommand(Increment);
            DecrementCommand = new RelayCommand(Decrement);
            CartAddCommand = new RelayCommand(CartAdd);
        }

        private void Increment() => ++Amount;
        private void Decrement() => --Amount;

        private void CartAdd()
        {
            cartService.CartAdd(Item, Amount);
            CloseWindowEvent?.Invoke();
            ResetView();
        }
        internal void ResetView() => Amount = 1;
    }
}
