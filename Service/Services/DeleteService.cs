using System;
using Model.ItemModels;

namespace Service.Services
{
    public abstract class DeleteService
    {
        public static event Action<AbstractItem> DeleteItemEvent;
        public static void DeleteItem(AbstractItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            StorageService.HashTable.Delete(item.ItemID, out _);
            StorageService.Tree.DeleteItem(item.ItemName);
            DeleteItemEvent?.Invoke(item);
        }
    }
}
