using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApplication.Database;
using WepApi.Dtos;

namespace NoteApiApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly NoteDbContext _context;

        public CategoryController(NoteDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreate categoryCreate)
        {
            var category = new Category
            {
                Name = categoryCreate.Name,
                UserId = 1 // Get the actual user ID from the token or context
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }

        // Add methods for Update, Delete, Get etc.
    }
}
