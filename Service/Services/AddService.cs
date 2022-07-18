using System;
using Service.API;
using Model.General;
using Model.ItemModels;
using System.Windows.Media.Imaging;

namespace Service.Services
{
    public class AddService : IAddable, IAddEvent
    {
        public event Action<AbstractItem> AddItemEvent;
        public void Add
            (string name, string type, string genre, string author, int amount, double price, BitmapImage image = default)
        {
            ValidateInput(name, type, genre, author, amount, price);
            var item = ItemTypes.GetItem(name, type, genre, author, amount, price, image);
            StorageService.HashTable.Add(item.ItemID, item);
            StorageService.Tree.Add(item.ItemName, item);
            AddItemEvent?.Invoke(item);
            return;
        }
        private void ValidateInput(string name, string type, string genre, string author, int amount, double price)
        {
            ValidatorService.StringNotNullOrEmpty(name, "name");
            ValidatorService.StringNotNullOrEmpty(type, "type");
            ValidatorService.StringNotNullOrEmpty(genre, "genre");
            ValidatorService.StringNotNullOrEmpty(author, "author");

            if (!ItemTypes.IsTypeValid(type)) throw new ArgumentException("type not exist");
            if (!ItemGenres.IsGenreValid(type, genre)) throw new ArgumentException("genre not exist");

            if (amount < 0) throw new ArgumentOutOfRangeException("amount less than 0");
            if (price < 0) throw new ArgumentOutOfRangeException("price less than 0");
        }
    }
}
