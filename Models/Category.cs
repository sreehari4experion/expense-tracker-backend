using System;
using System.Collections.Generic;

namespace ExpenseTrackerNew.Models
{
    public partial class Category
    {
        public Category()
        {
            Expenses = new HashSet<Expenses>();
            Item = new HashSet<Item>();
        }

        public int CategoryId { get; set; }
        public string Category1 { get; set; }

        public virtual ICollection<Expenses> Expenses { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
