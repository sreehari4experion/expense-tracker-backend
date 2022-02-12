using ExpenseTrackerNew.Models;
using ExpenseTrackerNew.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Repository.UsersRepo
{
    public class UserRepository:IUserRepo
    {
        private readonly expenseContext _contextone;
        public UserRepository(expenseContext contextone)
        {
            _contextone = contextone;
        }
        //get all users
        #region
        public async Task<List<UserView>> GetUsers()
        {
            if (_contextone != null)
            {
                return await (from u in _contextone.Users
                              select new UserView
                              {
                                  UserId=u.UserId,
                                  Name = u.Name,
                                  UserName =u.UserName,
                                  Password=u.Password,
                                  DateOfBirth=u.DateOfBirth,
                                  Email=u.Email,
                                  Phone=u.Phone
                              }
                    
                    ).ToListAsync();
            }
            return null;
        }
        #endregion

        //get user by id
        #region
        //get user by id
        public async Task<ActionResult<UserView>> GetUserByID(int? id)
        {
            if (_contextone != null)
            {
                var user = await _contextone.Users.FindAsync(id);    //primary key

                return await (from u in _contextone.Users
                              where u.UserId == id
                              select new UserView
                              {
                                  UserId = u.UserId,
                                  Name = u.Name,
                                  UserName = u.UserName,
                                  Password = u.Password,
                                  DateOfBirth = u.DateOfBirth,
                                  Email = u.Email,
                                  Phone = u.Phone

                              }
                              ).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        //add a user
        #region
        public async Task<ActionResult<Users>> AddUser(Users user)
        {
            if (_contextone != null)
            {

                await _contextone.Users.AddAsync(user);
                await _contextone.SaveChangesAsync();
                return user;
            }
            return null;
        }
        #endregion

        //update user
        #region update user
        public async Task UpdateUser(Users user)
        {
            if (_contextone != null)
            {
                _contextone.Entry(user).State = EntityState.Modified;
                _contextone.Users.Update(user);
                await _contextone.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }



        #endregion

        //delete a user
        #region delete User
        public async Task<int> DeleteUserByID(int? id)
        {
            // declare result
            int result = 0;
            if (_contextone != null)
            {
                var user = await _contextone.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (user != null)
                {
                    // perform delete
                    _contextone.Users.Remove(user);
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

        //get token by username and password
        #region
        //get user by userid and password
        public async Task<UserModel> GetUserbyNameandPassword(string user, string pass)
        {
            if (_contextone != null)
            {
                return await (from p in _contextone.Users

                              where p.UserName == user && p.Password == pass
                              select new UserModel
                              {
                                  UserName = p.UserName,
                                  Password = p.Password



                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
    }
}
