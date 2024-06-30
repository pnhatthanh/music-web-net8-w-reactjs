
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;

namespace MusicApi.Service.Services.CategoryService
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<List<Category>> GetCategoryById(long id);
        Task<Category> AddCategory(CategoryDTO categoryDTO);
        Task<Category> DeleteCategory(long id);
    }
}
