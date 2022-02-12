using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Views
{
    public class ItemView
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? ItemPrice { get; set; }
        public string category { get; set; }
    }
}
