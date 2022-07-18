using Service.API;
using Model.General;
using Model.ItemModels;
using Service.Services;
using GalaSoft.MvvmLight;
using System.Windows.Data;
using LibraryApp2.General;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LibraryApp2.ViewModel.CustomerViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        public ObservableCollection<AbstractItem> Items { get; }

        #region Filter Type
        private string filterType;
        public string FilterType
        {
            get => filterType;
            set
            {
                Set(ref filterType, value);
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

        #region Selected Item
        private AbstractItem selectedItem;
        public AbstractItem SelectedItem
        {
            get => selectedItem;
            set
            {
                Set(ref selectedItem, value);
                if (selectedItem != null) GetItemOptions();
            }
        }
        private void GetItemOptions() => AmountMessageBox.AmountMessage(SelectedItem, ResetItem);
        private void ResetItem() => SelectedItem = null;
        #endregion

        public RelayCommand FilterWindowCommand { get; }

        public CatalogViewModel(IAddEvent addableService)
        {
            Items = new ObservableCollection<AbstractItem>(GetAllService.GetAllItems());
            addableService.AddItemEvent += AddItem;
            DeleteService.DeleteItemEvent += DeleteItem;
            SearchNameCommand = new RelayCommand(SearchName);
            SearchAuthorCommand = new RelayCommand(SearchAuthor);
            ListUpdater.UpdateCatalogEvent += RefreshList;
        }

        private void AddItem(AbstractItem item) => Items.Add(item);
        private void DeleteItem(AbstractItem item) => Items.Remove(item);
        private void RefreshList() => CollectionViewSource.GetDefaultView(Items).Refresh();

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
