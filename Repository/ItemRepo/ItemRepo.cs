using ExpenseTrackerNew.Models;
using ExpenseTrackerNew.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Repository.ItemRepo
{
    public class ItemRepo:IItemRepo
    {
        private readonly expenseContext _context;

        //constructor based dependency injection
        public ItemRepo(expenseContext context)
        {
            _context = context;
        }

        //get all Items 
        public async Task<List<ItemView>> GetItems()
        {
            if (_context != null)
            {
                return await (from c in _context.Category
                              join it in _context.Item on c.CategoryId equals it.CategoryId

                              select new ItemView
                              {
                                  ItemId = it.ItemId,
                                  ItemName = it.ItemName,
                                  ItemPrice = it.ItemPrice,
                                  category = c.Category1
                              }

                    ).ToListAsync();

            }
            return null;
        }
        //add an item
        public async Task<ActionResult<Item>> AddItem(Item item)
        {
            if (_context != null)
            {

                await _context.Item.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }
        //delete a user
        #region delete User
        public async Task<int> DeleteItemById(int? id)
        {
            // declare result
            int result = 0;
            if (_context != null)
            {
                var user = await _context.Item.FirstOrDefaultAsync(u => u.ItemId == id);
                if (user != null)
                {
                    // perform delete
                    _context.Item.Remove(user);
                    result = await _context.SaveChangesAsync(); // commit 
                    //return succcess;
                    result = 1;

                }
                return result;
            }
            return result;

            //throw new NotImplementedException();
        }
        #endregion

    }
}
