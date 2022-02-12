using ExpenseTrackerNew.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Repository
{
    public class EntityRepo:IEntityRepo
    {
        private readonly expenseContext _context;

        //constructor based dependency injection
        public EntityRepo(expenseContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategories()
        {
            if (_context != null)
            {
                return await _context.Category.ToListAsync();

            }
            return null;
        }
        public async Task<List<Item>> GetItems()
        {
            if (_context != null)
            {
                return await _context.Item.ToListAsync();

            }
            return null;
        }

    }
}
