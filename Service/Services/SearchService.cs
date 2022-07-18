using Model.ItemModels;

namespace Service.Services
{
    internal abstract class SearchService
    {
        internal static bool IsItemExist(int itemID, out AbstractItem item)
        {
            item = default;
            if (itemID < 0) return false;
            item = StorageService.HashTable[itemID];
            return item != null;
        }
    }
}
