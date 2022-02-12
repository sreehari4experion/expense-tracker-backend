using ExpenseTrackerNew.Models;
using ExpenseTrackerNew.Repository.UsersRepo;
using ExpenseTrackerNew.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepository;
        public UserController(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]

        public async Task<List<UserView>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserView>> GetUserByID(int? id)
        {
            try
            {
                var user = await _userRepository.GetUserByID( id);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Users>> AddUser(Users user)
        {
            return await _userRepository.AddUser(user);
        }

        //update a user
        #region update a user
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] Users user)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _userRepository.UpdateUser(user);
                    return Ok(user);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        //delete user
        #region delete user by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserByID(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _userRepository.DeleteUserByID(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok("delete successfull");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
