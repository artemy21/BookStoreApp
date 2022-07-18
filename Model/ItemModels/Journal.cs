using System;
using System.Windows.Media.Imaging;

namespace Model.ItemModels
{
    public class Journal : AbstractItem
    {
        protected readonly int itemID;
        public override int ItemID => itemID;

        public override string[] Genres => Enum.GetNames(typeof(JournalType));
        internal enum JournalType
        {
            Any,
            Academic,
            Business,
            Gossip,
            News,
            Sports
        }

        public Journal(string itemName, string author, string genre, int amount, double price, BitmapImage image = default)
             : base(itemName, author, genre, amount, price, image)
        {
            itemID = _itemID;
            SetGenre(genre);
        }

        private void SetGenre(string journalGenre)
        {
            Enum.TryParse(journalGenre, out JournalType itemEnum);
            Genre = itemEnum.ToString();
        }
    }
}