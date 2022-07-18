using Service.API;
using Model.General;
using Model.ItemModels;
using Service.Services;
using GalaSoft.MvvmLight;
using LibraryApp2.General;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace LibraryApp2.ViewModel.CustomerViewModels
{
    public class CartViewModel : ViewModelBase
    {
        #region ID
        private string id = null;
        public string ID
        {
            get => id;
            set => Set(ref id, value);
        }
        #endregion

        #region Total
        private double total;
        public double Total
        {
            get => total;
            set => Set(ref total, value);
        }

        private double CalcTotal()
        {
            double total = 0;
            foreach (var item in Items)
            {
                total += item.Item.DiscountPrice * item.Amount;
            }
            return total;
        }
        #endregion

        public RelayCommand PurchaseCommand { get; }
        public ObservableCollection<AbstractItemAmount> Items { get; }

        public CartViewModel(ICartaddEvent cartService)
        {
            Items = new ObservableCollection<AbstractItemAmount>();
            PurchaseCommand = new RelayCommand(Purchase);
            cartService.CartAddEvent += AddItem;
        }

        private void Purchase()
        {
            if (!int.TryParse(ID, out int id) || !IDValidator.IsIdValid(id))
            {
                IDValidator.InvalidIdMessage();
                return;
            }
            GetSaleDetails();
            ResetView();
        }
        private void GetSaleDetails() => SaleDetailsService.SendSaleDetails(new SaleDetails(Items, int.Parse(ID), Total));
        private void AddItem(AbstractItem item, int amount)
        {
            if (!IsExist(item, out int index)) Items.Add(new AbstractItemAmount(item, amount));
            else UpdateAmount(amount, index);
            Total = CalcTotal();
        }
        private bool IsExist(AbstractItem item, out int index)
        {
            index = -1;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Item.IsEqual(item))
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
        private void UpdateAmount(int amount, int index)
        {
            var listItem = Items[index];
            listItem.Amount += amount;
            Items[index] = listItem;
        }
        private void ResetView()
        {
            Items.Clear();
            ID = null;
            Total = 0;
        }
    }
}
