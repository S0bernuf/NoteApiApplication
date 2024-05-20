using DataAccess.Models;
using NoteApplication.BusinessLogic.Dtos;
using WepApi.Dtos;

namespace NoteApplication.BusinessLogic.Services
{
    public interface ICategoryService
    {
        Task<ServiceResponse<Category>> CreateCategoryAsync(CategoryCreate dto, string userName);
        Task<ServiceResponse<Category>> UpdateCategoryAsync(CategoryUpdate dto, string userName);
        Task<ServiceResponse<bool>> DeleteCategoryAsync(int id, string userName);
    }
}
