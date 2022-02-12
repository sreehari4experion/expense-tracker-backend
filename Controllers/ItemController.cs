using ExpenseTrackerNew.Models;
using ExpenseTrackerNew.Repository.ItemRepo;
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
    public class ItemController : ControllerBase
    {
        private readonly IItemRepo _itemRepo;
        public ItemController(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }
        [HttpGet]
        public async Task<List<ItemView>> GetItems()
        {
            return await _itemRepo.GetItems();
        }
        //add an item
        [HttpPost]
        public async Task<ActionResult<Item>> AddItem(Item item)
        {
            return await _itemRepo.AddItem(item);
        }
        #region delete item by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemById(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _itemRepo.DeleteItemById(id);
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
