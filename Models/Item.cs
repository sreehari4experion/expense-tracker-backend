using System;
using System.Collections.Generic;

namespace ExpenseTrackerNew.Models
{
    public partial class Item
    {
        public Item()
        {
            ItemList = new HashSet<ItemList>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? ItemPrice { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ItemList> ItemList { get; set; }
    }
}
