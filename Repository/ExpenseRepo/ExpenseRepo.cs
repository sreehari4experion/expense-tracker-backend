using ExpenseTrackerNew.Models;
using ExpenseTrackerNew.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Repository.ExpenseRepo
{
    public class ExpenseRepo:IExpenseRepo
    {
        private readonly expenseContext _contextone;
        public ExpenseRepo(expenseContext contextone)
        {
            _contextone = contextone;
        }

        //get all expenses
        #region
        public async Task<List<ExpenseView>> GetExpenses()
        {
            if (_contextone != null)
            {
                return await (from u in _contextone.Expenses
                              from c in _contextone.Category
                              select new ExpenseView
                              {
                                  ExpenseId = u.ExpenseId,
                                  ExpenseDate = u.ExpenseDate,
                                  UserId = u.UserId,
                                  ExpenseAmount = u.ExpenseAmount,
                                  CategoryId = u.CategoryId,
                                  Category=c.Category1,
                                  Items = (from p in _contextone.Expenses
                                           join i in _contextone.ItemList
                                           on p.ExpenseId equals i.ExpenseId
                                           join it in _contextone.Item
                                           on i.ItemId equals it.ItemId
                                           where p.ExpenseId == i.ExpenseId
                                           select new ItemView
                                           {
                                               ItemId = it.ItemId,
                                               ItemName = it.ItemName,
                                               ItemPrice = it.ItemPrice
                                           }
                                         ).ToList()
                              }

                    ).ToListAsync();
            }
            return null;
        }
        #endregion

        //get user by id
        #region
        //get user by id
        public async Task<ActionResult<ExpenseView>> GetExpensesByUserId(int? id)
        {
            if (_contextone != null)
            {
                return await (from u in _contextone.Expenses
                              from c in _contextone.Category

                              where u.UserId == id
                              select new ExpenseView
                              {
                                  ExpenseId = u.ExpenseId,
                                  ExpenseDate = u.ExpenseDate,
                                  UserId = u.UserId,
                                  ExpenseAmount = u.ExpenseAmount,
                                  CategoryId = u.CategoryId,
                                  Category=c.Category1,

                                  Items = (from p in _contextone.Expenses
                                           join i in _contextone.ItemList
                                           on p.ExpenseId equals i.ExpenseId
                                           join it in _contextone.Item
                                           on i.ItemId equals it.ItemId
                                           select new ItemView
                                           {
                                               ItemId = it.ItemId,
                                               ItemName = it.ItemName,
                                               ItemPrice = it.ItemPrice
                                           }
                                         ).ToList()
                              }

                    ).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        //add a user
        #region
        public async Task<ActionResult<Expenses>> AddExpense(Expenses exp)
        {
            if (_contextone != null)
            {

                await _contextone.Expenses.AddAsync(exp);
                await _contextone.SaveChangesAsync();
                return exp;
            }
            return null;
        }
        #endregion

        //update user
        #region update user
        public async Task UpdateExpense(Expenses exp)
        {
            if (_contextone != null)
            {
                _contextone.Entry(exp).State = EntityState.Modified;
                _contextone.Expenses.Update(exp);
                await _contextone.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }



        #endregion

        //delete a user
        #region delete User
        public async Task<int> DeleteExpenseById(int? id)
        {
            // declare result
            int result = 0;
            if (_contextone != null)
            {
                var user = await _contextone.Expenses.FirstOrDefaultAsync(u => u.ExpenseId == id);
                if (user != null)
                {
                    // perform delete
                    _contextone.Expenses.Remove(user);
                    result = await _contextone.SaveChangesAsync(); // commit 
                    //return succcess;
                    result = 1;

                }
                return result;
            }
            return result;

            //throw new NotImplementedException();
        }
        #endregion

        public async Task<ExpenseView> GetExpenseByUsername(string name)
        {
            if (_contextone != null)
            {
                return await (from e in _contextone.Expenses
                              join u in _contextone.Users
                              on e.UserId equals u.UserId
                              join c in _contextone.Category
                              on e.CategoryId equals c.CategoryId
                              where u.UserName == name
                              select new ExpenseView
                              {

                                  ExpenseId = e.ExpenseId,
                                  ExpenseDate = e.ExpenseDate,
                                  UserId = e.UserId,
                                  ExpenseAmount = e.ExpenseAmount,
                                  CategoryId = c.CategoryId,
                                  Category = c.Category1,

                                  Items = (from p in _contextone.Expenses
                                           join i in _contextone.ItemList
                                           on p.ExpenseId equals i.ExpenseId
                                           join it in _contextone.Item
                                           on i.ItemId equals it.ItemId
                                           select new ItemView
                                           {
                                               ItemId = it.ItemId,
                                               ItemName = it.ItemName,
                                               ItemPrice = it.ItemPrice
                                           }
                                         ).ToList()
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        //get expense by date
        public async Task<ExpenseView> GetExpenseByDateAndUser(DateTime date,String user)
        {
            if (_contextone != null)
            {
                return await (from e in _contextone.Expenses
                              join u in _contextone.Users
                              on e.UserId equals u.UserId
                              join c in _contextone.Category
                              on e.CategoryId equals c.CategoryId
                              where e.ExpenseDate == date && u.UserName==user
                              select new ExpenseView
                              {

                                  ExpenseId = e.ExpenseId,
                                  ExpenseDate = e.ExpenseDate,
                                  UserId = e.UserId,
                                  ExpenseAmount = e.ExpenseAmount,
                                  CategoryId = c.CategoryId,
                                  Category = c.Category1,

                                  Items = (from p in _contextone.Expenses
                                           join i in _contextone.ItemList
                                           on p.ExpenseId equals i.ExpenseId
                                           join it in _contextone.Item
                                           on i.ItemId equals it.ItemId
                                           select new ItemView
                                           {
                                               ItemId = it.ItemId,
                                               ItemName = it.ItemName,
                                               ItemPrice = it.ItemPrice
                                           }
                                         ).ToList()
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        //max amount is pend
        public async Task<CategoryView> getMaxCategory(DateTime date,string name)
        {
            if (_contextone != null)
            {
                return await (from e in _contextone.Expenses
                              join u in _contextone.Users
                              on e.UserId equals u.UserId
                              join c in _contextone.Category
                              on e.CategoryId equals c.CategoryId
                              where e.ExpenseDate == date && u.UserName == name

                              select new CategoryView
                              {
                                  Category=c.Category1,
                                  amount=(int)e.ExpenseAmount
                              }
                              
                              ).FirstOrDefaultAsync();
            }
            return null;
        }

    }
}
