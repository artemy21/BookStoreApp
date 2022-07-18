using System.Windows.Media.Imaging;

namespace Model.ItemModels
{
    public abstract class AbstractItem : IGenreable
    {
        public string ItemName { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public abstract string[] Genres { get; }
        public BitmapImage ItemImage { get; set; }

        protected static int _itemID;
        public abstract int ItemID { get; }

        public int Amount { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double DiscountPrice { get => Price * (1 - (Discount / 100)); }

        public AbstractItem(string itemName, string author, string genre, int amount, double price, BitmapImage image = default)
        {
            ItemName = itemName;
            Author = author;
            Genre = genre;
            Amount = amount;
            Price = price;
            _itemID++;
            ItemImage = image;
        }

        public bool IsEqual(AbstractItem item) => IsEqual(item.ItemName, item.Genre, item.Author);
        public bool IsEqual(string name, string genre, string author) => ItemName == name && Genre == genre && Author == author;
    }
}