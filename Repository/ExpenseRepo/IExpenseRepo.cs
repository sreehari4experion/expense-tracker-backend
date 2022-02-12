using ExpenseTrackerNew.Models;
using ExpenseTrackerNew.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Repository.ExpenseRepo
{
    public interface IExpenseRepo
    {
        Task<List<ExpenseView>> GetExpenses();
        Task<ActionResult<ExpenseView>> GetExpensesByUserId(int? id);
        Task<ActionResult<Expenses>> AddExpense(Expenses exp);
        Task UpdateExpense(Expenses exp);
        Task<int> DeleteExpenseById(int? id);
        Task<ExpenseView> GetExpenseByUsername(string name);
        Task<ExpenseView> GetExpenseByDateAndUser(DateTime date, String user);
        Task<CategoryView> getMaxCategory(DateTime date, string name);


    }
}
