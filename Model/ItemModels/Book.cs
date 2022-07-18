using System;
using System.Windows.Media.Imaging;

namespace Model.ItemModels
{
    public class Book : AbstractItem
    {
        protected readonly int itemID;
        public override int ItemID => itemID;

        public override string[] Genres => Enum.GetNames(typeof(BookType));
        internal enum BookType
        {
            Any,
            Adventure,
            Comic,
            Detective,
            Fantasy,
            Fiction,
            Horror
        }

        public Book(string itemName, string author, string genre, int amount, double price, BitmapImage image = default)
             : base(itemName, author, genre, amount, price, image)
        {
            itemID = _itemID;
            SetGenre(genre);
        }

        private void SetGenre(string bookGenre)
        {
            Enum.TryParse(bookGenre, out BookType itemEnum);
            Genre = itemEnum.ToString();
        }
    }
}