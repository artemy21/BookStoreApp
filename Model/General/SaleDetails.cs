using System;
using Model.ItemModels;
using System.Collections.Generic;

namespace Model.General
{
    public class SaleDetails
    {
        public List<AbstractItem> Items { get; }
        public int Amount { get; }
        public int ID { get; }
        public DateTime PurchaseDate { get; }
        public double Total { get; }

        public SaleDetails(ICollection<AbstractItemAmount> list, int id, double total)
        {
            Items = new List<AbstractItem>();
            foreach (var item in list)
            {
                Items.Add(item.Item);
                Amount += item.Amount;
            }
            ID = id;
            PurchaseDate = DateTime.Now;
            Total = total;
        }
    }

    public class AbstractItemAmount
    {
        public AbstractItem Item { get; }
        public int Amount { get; set; }

        public AbstractItemAmount(AbstractItem item, int amount)
        {
            Item = item;
            Amount = amount;
        }
    }
}