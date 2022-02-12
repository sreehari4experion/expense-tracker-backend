using ExpenseTrackerNew.Models;
using ExpenseTrackerNew.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : Controller
    {
        private readonly IEntityRepo _entityRepo;
        public EntityController(IEntityRepo entityRepo)
        {
            _entityRepo = entityRepo;
        }
        [HttpGet("categories")]
        public async Task<List<Category>> GetCategories()
        {
            return await _entityRepo.GetCategories();
        }
        [HttpGet("items")]
        public async Task<List<Item>> GetItems()
        {
            return await _entityRepo.GetItems();
        }



    }
}
