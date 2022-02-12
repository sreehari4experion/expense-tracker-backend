using ExpenseTrackerNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Repository
{
    public interface IEntityRepo
    {
        Task<List<Category>> GetCategories();
        Task<List<Item>> GetItems();

    }
}
