using System;
using System.Collections.Generic;

namespace ExpenseTrackerNew.Models
{
    public partial class ItemList
    {
        public int ItemListId { get; set; }
        public int? ExpenseId { get; set; }
        public int? ItemId { get; set; }

        public virtual Expenses Expense { get; set; }
        public virtual Item Item { get; set; }
    }
}
