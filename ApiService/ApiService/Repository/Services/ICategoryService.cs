using Repository.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> CreateCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task UpdateCategory(Category categoryToUpdate, Category category);
        void DeleteCategory(Category category);
    }
}
