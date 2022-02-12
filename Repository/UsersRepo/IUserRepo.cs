using ExpenseTrackerNew.Models;
using ExpenseTrackerNew.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Repository.UsersRepo
{
    public interface IUserRepo
    {
        Task<List<UserView>> GetUsers();
        Task<ActionResult<UserView>> GetUserByID(int? id);
        Task<ActionResult<Users>> AddUser(Users user);
        Task UpdateUser(Users user);
        Task<int> DeleteUserByID(int? id);
        Task<UserModel> GetUserbyNameandPassword(string user, string pass);
    }
}
