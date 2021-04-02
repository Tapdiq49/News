using Repository.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
