namespace Model.General
{
    public abstract class ItemGenres
    {
        public static string[] GetItemGenres(string itemType)
        {
            if (!IsTypeValid(itemType)) return null;
            var item = ItemTypes.GetItem(default, itemType, default, default, default, default);
            return item.Genres;
        }
        public static bool IsGenreValid(string itemType, string itemGenre)
        {
            if (string.IsNullOrEmpty(itemType) || string.IsNullOrEmpty(itemGenre)) return false;
            var genres = GetItemGenres(itemType);
            foreach (var genre in genres)
            {
                if (genre == itemGenre) return true;
            }
            return false;
        }
        private static bool IsTypeValid(string itemType) => !string.IsNullOrEmpty(itemType) && ItemTypes.IsTypeValid(itemType);
    }
}