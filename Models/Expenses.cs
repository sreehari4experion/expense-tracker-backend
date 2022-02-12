using System;
using System.Collections.Generic;

namespace ExpenseTrackerNew.Models
{
    public partial class Expenses
    {
        public Expenses()
        {
            ItemList = new HashSet<ItemList>();
        }

        public int ExpenseId { get; set; }
        public int? UserId { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public int? ExpenseAmount { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<ItemList> ItemList { get; set; }
    }
}
