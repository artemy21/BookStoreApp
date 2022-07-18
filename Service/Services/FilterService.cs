using System;
using System.Linq;
using Model.ItemModels;
using System.Collections.Generic;

namespace Service.Services
{
    public abstract class FilterService
    {
        public static void ListAll(ICollection<AbstractItem> items)
        {
            items.Clear();
            var list = GetAllService.GetAllItems();
            foreach (var item in list) items.Add(item);
        }
        public static void ListType(ICollection<AbstractItem> items, string selectedType)
        {
            Validate(items);
            items.Clear();
            var allList = GetAllService.GetAllItems();
            foreach (var item in allList.Where(item => item.GetType().Name == selectedType))
            {
                items.Add(item);
            }
        }
        public static void ListGenre(ICollection<AbstractItem> items, string genre, string type)
        {
            Validate(items);
            if (genre == "Any")
            {
                ListType(items, type);
                return;
            }

            items.Clear();
            var allList = GetAllService.GetAllItems();
            foreach (var item in allList.Where(item => item.Genre == genre))
            {
                items.Add(item);
            }
        }
        public static void SearchName(ICollection<AbstractItem> items, string itemName)
        {
            Validate(items);
            items.Clear();
            var allList = GetAllService.GetAllItems();
            foreach (var item in allList)
            {
                var upItem = item.ItemName.ToUpper();
                var upName = itemName.ToUpper();
                if (upItem.Contains(upName)) items.Add(item);
            }
        }
        public static void SearchAuthor(ICollection<AbstractItem> items, string author)
        {
            Validate(items);
            items.Clear();
            var allList = GetAllService.GetAllItems();
            foreach (var item in allList)
            {
                var upItem = item.Author.ToUpper();
                var upAuthor = author.ToUpper();
                if (upItem.Contains(upAuthor)) items.Add(item);
            }
        }
        public static void SearchID(ICollection<AbstractItem> items, int id)
        {
            Validate(items);
            items.Clear();
            if (SearchService.IsItemExist(id, out var item)) items.Add(item);
        }
        private static void Validate(ICollection<AbstractItem> items)
        {
            if (items == null) throw new ArgumentNullException("items");
        }
    }
}
