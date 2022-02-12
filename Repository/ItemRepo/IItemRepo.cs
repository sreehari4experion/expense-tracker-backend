using ExpenseTrackerNew.Models;
using ExpenseTrackerNew.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Repository.ItemRepo
{
    public interface IItemRepo
    {
        Task<List<ItemView>> GetItems();
        Task<ActionResult<Item>> AddItem(Item item);
        Task<int> DeleteItemById(int? id);
    }
}
