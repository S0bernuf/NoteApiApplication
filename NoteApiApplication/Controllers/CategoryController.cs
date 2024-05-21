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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreate dto)
        {
            var result = await _categoryService.CreateCategoryAsync(dto, User.Identity.Name);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdate dto)
        {
            var result = await _categoryService.UpdateCategoryAsync(dto, User.Identity.Name);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id, User.Identity.Name);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
