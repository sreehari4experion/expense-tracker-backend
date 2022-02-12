using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Views
{
    public class ExpenseView
    {
        public int ExpenseId { get; set; }
        public int? UserId { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public int? ExpenseAmount { get; set; }
        public int? CategoryId { get; set; }
        public string Category { get; set; }

        public List<ItemView> Items { get; set; }
    }
}
