using System;
using Model.General;
using Model.ItemModels;
using GalaSoft.MvvmLight;
using LibraryApp2.General;
using GalaSoft.MvvmLight.Command;
using System.Windows.Media.Imaging;

namespace LibraryApp2.ViewModel.ManagerViewModels
{
    public class EditItemViewModel : ViewModelBase
    {
        #region Item
        private AbstractItem item;
        public AbstractItem Item
        {
            get => item;
            set
            {
                Set(ref item, value);
                InitializeProps();
            }
        }
        #endregion

        #region ItemName
        private string itemName;
        public string ItemName
        {
            get => itemName;
            set => Set(ref itemName, value);
        }
        #endregion

        #region Genre
        private string itemGenre;
        public string ItemGenre
        {
            get => itemGenre;
            set => Set(ref itemGenre, value);
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

        #region Amount
        private int amount;
        public int Amount
        {
            get => amount;
            set => Set(ref amount, value);
        }
        #endregion

        #region Image
        private BitmapImage image;
        public BitmapImage Image
        {
            get => image;
            set => Set(ref image, value);
        }
        public RelayCommand ChangeImageCommand { get; }
        #endregion

        public RelayCommand SaveChangesCommand { get; }

        public event Action CloseWindowEvent;

        public EditItemViewModel()
        {
            ChangeImageCommand = new RelayCommand(ChangeImage);
            SaveChangesCommand = new RelayCommand(SaveChanges);
        }

        private void InitializeProps()
        {
            ItemName = Item.ItemName;
            ItemGenreValues = ItemGenres.GetItemGenres(Item.GetType().Name);
            ItemGenre = Item.Genre;
            Author = Item.Author;
            Amount = Item.Amount;
            Price = Item.Price;
            Image = Item.ItemImage;
        }
        private void SaveChanges()
        {
            if (!IsPropsValid()) return;
            Item.ItemName = ItemName;
            Item.Genre = ItemGenre;
            Item.Author = Author;
            Item.Amount = Amount;
            Item.Price = Price;
            Item.ItemImage = Image;
            CloseWindowEvent?.Invoke();
        }
        private bool IsPropsValid() => ItemName != null && Author != null && Price > 0;
        private void ChangeImage() => Image = ItemImage.ImageDialog();
    }
}
