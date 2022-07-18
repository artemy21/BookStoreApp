using Service.API;
using Model.General;
using Model.ItemModels;
using Service.Services;
using GalaSoft.MvvmLight;
using LibraryApp2.General;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LibraryApp2.ViewModel.ManagerViewModels
{
    public class DiscountViewModel : ViewModelBase
    {
        public ObservableCollection<AbstractItem> Items { get; }

        #region Discount Type
        private string discountType;
        public string DiscountType
        {
            get => discountType;
            set
            {
                Set(ref discountType, value);
                ListAll();
            }
        }
        #endregion

        #region ItemType
        private string selectedItemType;
        public string SelectedItemType
        {
            get => selectedItemType;
            set
            {
                Set(ref selectedItemType, value);
                SetItemGenres();
                ListType();
            }
        }
        public List<string> ItemTypeValues => ItemTypes.GetAllTypes();
        private void SetItemGenres() => ItemGenreValues = ItemGenres.GetItemGenres(SelectedItemType);
        #endregion

        #region Name
        private string itemName;
        public string ItemName
        {
            get => itemName;
            set => Set(ref itemName, value);
        }

        public RelayCommand SearchNameCommand { get; }
        #endregion

        #region Author
        private string author;
        public string Author
        {
            get => author;
            set => Set(ref author, value);
        }

        public RelayCommand SearchAuthorCommand { get; }
        #endregion

        #region Genre
        private string selectedItemGenre;
        public string SelectedItemGenre
        {
            get => selectedItemGenre;
            set
            {
                Set(ref selectedItemGenre, value);
                ListGenre();
            }
        }

        private string[] itemGenreValues;
        public string[] ItemGenreValues
        {
            get => itemGenreValues;
            set => Set(ref itemGenreValues, value);
        }
        #endregion

        #region Discount
        private int discount;
        public int Discount
        {
            get => discount;
            set => Set(ref discount, value);
        }
        #endregion

        public RelayCommand StartDiscountCommand { get; }
        public RelayCommand ResetDiscountCommand { get; }

        public DiscountViewModel(IAddEvent addableService)
        {
            Items = new ObservableCollection<AbstractItem>(GetAllService.GetAllItems());
            addableService.AddItemEvent += AddItem;
            DeleteService.DeleteItemEvent += DeleteItem;
            SearchNameCommand = new RelayCommand(SearchName);
            SearchAuthorCommand = new RelayCommand(SearchAuthor);
            StartDiscountCommand = new RelayCommand(StartDiscount);
            ResetDiscountCommand = new RelayCommand(ResetDiscount);
        }

        private void StartDiscount()
        {
            foreach (var item in Items)
            {
                if (Discount > item.Discount) item.Discount = Discount;
            }
            Discount = 0;
            RefreshList();
        }
        private void ResetDiscount()
        {
            foreach (var item in Items) item.Discount = 0;
            RefreshList();
        }
        private void RefreshList() => ListUpdater.RefreshList(Items);
        private void AddItem(AbstractItem item) => Items.Add(item);
        private void DeleteItem(AbstractItem item) => Items.Remove(item);

        #region Filtering
        private void ListAll()
        {
            SelectedItemType = default;
            ItemGenreValues = default;
            FilterService.ListAll(Items);
        }

        private void ListType() => FilterService.ListType(Items, selectedItemType);
        private void ListGenre() => FilterService.ListGenre(Items, SelectedItemGenre, selectedItemType);
        private void SearchName() => FilterService.SearchName(Items, ItemName);
        private void SearchAuthor() => FilterService.SearchAuthor(Items, Author);
        #endregion
    }
}
