using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteApplication.BusinessLogic.Dtos;
using NoteApplication.BusinessLogic.Services;
using WepApi.Dtos;

namespace NoteApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteCreate dto)
        {
            var result = await _noteService.CreateNoteAsync(dto, User.Identity.Name);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(NoteUpdate dto)
        {
            var result = await _noteService.UpdateNoteAsync(dto, User.Identity.Name);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _noteService.DeleteNoteAsync(id, User.Identity.Name);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string title)
        {
            var result = await _noteService.SearchNotesAsync(title, User.Identity.Name);
            return Ok(result);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] int categoryId)
        {
            var result = await _noteService.FilterNotesByCategoryAsync(categoryId, User.Identity.Name);
            return Ok(result);
        }
    }
}
