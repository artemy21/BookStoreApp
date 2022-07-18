using System;
using Service.API;
using System.Windows.Media.Imaging;

namespace LibraryApp2.General
{
    public abstract class InitializeItems
    {
        #region Images
        private static readonly BitmapImage harryPotterIMG
            = new BitmapImage(new Uri(@"\Assets\Items\HarryPotter.jpg", UriKind.Relative));
        private static readonly BitmapImage _1984IMG
            = new BitmapImage(new Uri(@"\Assets\Items\1984.jpg", UriKind.Relative));
        private static readonly BitmapImage treasureIslandIMG
            = new BitmapImage(new Uri(@"\Assets\Items\TreasureIsland.jpg", UriKind.Relative));
        private static readonly BitmapImage gameOfThronesIMG
            = new BitmapImage(new Uri(@"\Assets\Items\GOT.jpg", UriKind.Relative));
        private static readonly BitmapImage lordoftheRingsIMG
            = new BitmapImage(new Uri(@"\Assets\Items\LOTR.jpg", UriKind.Relative));
        private static readonly BitmapImage businessInsiderIMG
            = new BitmapImage(new Uri(@"\Assets\Items\JournalCover.jpg", UriKind.Relative));
        #endregion

        public static void AddItems(IAddable addService)
        {
            ValidateService(addService);
            addService.Add("Harry potter", "Book", "Fantasy", "JK Rowling", 25, 80, harryPotterIMG);
            addService.Add("1984", "Book", "Fiction", "George Orwell", 18, 65, _1984IMG);
            addService.Add("Treasure Island", "Book", "Adventure", "Robert Louis Stevenson", 15, 40, treasureIslandIMG);
            addService.Add("Game Of Thrones", "Book", "Fantasy", "George R. R. Martin", 32, 85, gameOfThronesIMG);
            addService.Add("Lord of the Rings", "Book", "Fantasy", "J. R. R. Tolkien", 26, 80, lordoftheRingsIMG);
            addService.Add("Business Insider", "Journal", "Business", "John Watson", 40, 30, businessInsiderIMG);
        }
        private static void ValidateService(IAddable addService)
        {
            if (addService is null) throw new ArgumentNullException(nameof(addService));
        }
    }
}
