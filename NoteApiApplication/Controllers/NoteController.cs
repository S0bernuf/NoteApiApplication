using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApplication.Database;
using WepApi.Dtos;

namespace NoteApiApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly NoteDbContext _context;

        public NoteController(NoteDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteCreate noteCreate)
        {
            var note = new Note
            {
                Title = noteCreate.Title,
                Text = noteCreate.Text,
                PhotoPath = noteCreate.PhotoPath,
                CategoryId = noteCreate.CategoryId,
                UserId = 1 // Get the actual user ID from the token or context
            };
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return Ok(note);
        }

        // Add methods for Update, Delete, Get etc.
    }
}
