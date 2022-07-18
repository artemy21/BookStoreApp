using Model.ItemModels;
using System.Collections.Generic;

namespace Service.Services
{
    public abstract class GetAllService
    {
        public static List<AbstractItem> GetAllItems()
        {
            var items = new List<AbstractItem>();
            if (StorageService.Tree.GetEnumerator() != null)
            {
                foreach (var item in StorageService.Tree) items.Add(item);
            }
            return items;
        }
    }
}
