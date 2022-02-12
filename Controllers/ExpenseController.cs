using ExpenseTrackerNew.Models;
using ExpenseTrackerNew.Repository.ExpenseRepo;
using ExpenseTrackerNew.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepo _userRepository;
        private readonly expenseContext _context;
        public ExpenseController(IExpenseRepo userRepository, expenseContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }
        [HttpGet]

        public async Task<List<ExpenseView>> GetExpenses()
        {
            return await _userRepository.GetExpenses();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseView>> GetExpensesByUserId(int? id)
        {
            try
            {
                var user = await _userRepository.GetExpensesByUserId(id);
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
        public async Task<ActionResult<Expenses>> AddExpense(Expenses exp)
        {
            return await _userRepository.AddExpense(exp);
        }

        //update a user
        #region update a expense
        [HttpPut]
        public async Task<IActionResult> UpdateExpense([FromBody] Expenses exp)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _userRepository.UpdateExpense(exp);
                    return Ok(exp);
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
        #region delete expense by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseById(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _userRepository.DeleteExpenseById(id);
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

        [HttpGet("nameis{name}")]
        public async Task<ActionResult<ExpenseView>> GetExpenseByUsername(string name)
        {
            try
            {
                var user = await _userRepository.GetExpenseByUsername(name);
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

        //get expenses by date
        [HttpGet("date&user{date}&{user}")]
        public async Task<ActionResult<ExpenseView>> GetExpenseByDateAndUser(DateTime date, String user)
        {
            try
            {
                var user1 = await _userRepository.GetExpenseByDateAndUser(date,user);
                if (user1 == null)
                {
                    return NotFound();
                }
                return user1;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //get category where max max money is spent
        [HttpGet("maxCategory{date}&{user}")]
        public async Task<ActionResult<CategoryView>> getMaxCategory(DateTime date, String user)
        {
            try
            {
                var user1 = await _userRepository.getMaxCategory(date, user);
                if (user1 == null)
                {
                    return NotFound();
                }
                return user1;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
