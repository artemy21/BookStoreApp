using Service.API;
using Model.General;
using GalaSoft.MvvmLight;
using LibraryApp2.General;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace LibraryApp2.ViewModel.ManagerViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private readonly IAddable addService;

        #region ItemName
        private string itemName;
        public string ItemName
        {
            get => itemName;
            set => Set(ref itemName, value);
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
            }
        }
        public List<string> ItemTypeValues => ItemTypes.GetAllTypes();
        private void SetItemGenres() => ItemGenreValues = ItemGenres.GetItemGenres(SelectedItemType);
        #endregion

        #region ItemGenre
        private string selectedItemGenre;
        public string SelectedItemGenre
        {
            get => selectedItemGenre;
            set => Set(ref selectedItemGenre, value);
        }

        private string[] itemGenreValues;
        public string[] ItemGenreValues
        {
            get => itemGenreValues;
            set => Set(ref itemGenreValues, value);
        }
        #endregion

        #region Author
        private string author;
        public string Author
        {
            get => author;
            set => Set(ref author, value);
        }
        #endregion

        #region Amount
        private int amount = 10;
        public int Amount
        {
            get => amount;
            set => Set(ref amount, value);
        }
        #endregion

        #region Price
        private double price;
        public double Price
        {
            get => price;
            set
            {
                if (price < 0) price = 0;
                Set(ref price, value);
            }
        }
        #endregion

        #region Image
        private BitmapImage image;
        public BitmapImage Image
        {
            get => image;
            set => Set(ref image, value);
        }
        public RelayCommand AddImageCommand { get; }
        #endregion

        public RelayCommand OrderCommand { get; }

        public OrderViewModel(IAddable addService)
        {
            this.addService = addService;
            OrderCommand = new RelayCommand(AddItem);
            AddImageCommand = new RelayCommand(ImageDialog);
            Image = ItemImage.defaultImage;
            InitializeItems.AddItems(addService);
        }

        private void AddItem()
        {
            if (!IsPropsValid()) return;
            addService.Add(ItemName, SelectedItemType, SelectedItemGenre, Author, Amount, Price, Image);
            ResetView();
        }
        private bool IsPropsValid()
        {
            return ItemName != null && SelectedItemType != null && SelectedItemGenre != null && Author != null && Price > 0;
        }
        private void ResetView()
        {
            ItemName = default;
            SelectedItemType = default;
            SelectedItemGenre = default;
            ItemGenreValues = default;
            Author = default;
            Amount = 10;
            Price = 0;
            Image = ItemImage.defaultImage;
        }
        private void ImageDialog() => Image = ItemImage.ImageDialog();
    }
}
