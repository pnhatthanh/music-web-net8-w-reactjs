using music_api.DTOs;
using music_api.Models;

namespace music_api.Services.IRepositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<List<Category>> GetCategoryById(long id);
        Task<Category> AddCategory(CategoryDTO categoryDTO);
        Task<Category> DeleteCategory(long id);
    }
}
