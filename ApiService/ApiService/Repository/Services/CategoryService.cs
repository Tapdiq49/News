using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.Where(e => !e.SoftDeleted && e.ParentId==null).Include(e=>e.SubCategories).ToListAsync();
        }
    }
}
