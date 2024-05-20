using DataAccess.Models;
using NoteApplication.Database.Repositories;
using NoteApplication.BusinessLogic.Dtos;
using WepApi.Dtos;

namespace NoteApplication.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<Category>> CreateCategoryAsync(CategoryCreate dto, string userName)
        {
            var user = await _userRepository.GetUserByNameAsync(userName);
            var category = new Category
            {
                Name = dto.Name,
                UserId = user.Id
            };
            await _categoryRepository.AddCategoryAsync(category);

            return new ServiceResponse<Category> { Success = true, Data = category };
        }

        public async Task<ServiceResponse<Category>> UpdateCategoryAsync(CategoryUpdate dto, string userName)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(dto.Id);
            if (category == null || category.User.UserName != userName)
                return new ServiceResponse<Category> { Success = false, Message = "Category not found or access denied" };

            category.Name = dto.Name;
            await _categoryRepository.UpdateCategoryAsync(category);

            return new ServiceResponse<Category> { Success = true, Data = category };
        }

        public async Task<ServiceResponse<bool>> DeleteCategoryAsync(int id, string userName)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null || category.User.UserName != userName)
                return new ServiceResponse<bool> { Success = false, Message = "Category not found or access denied" };

            await _categoryRepository.DeleteCategoryAsync(category);

            return new ServiceResponse<bool> { Success = true, Data = true };
        }
    }
}
