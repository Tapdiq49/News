using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.Entities;
using Repository.Exceptions;
using System;
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

        public async Task<Category> CreateCategory(Category category)
        {
            category.ModifiedAt = DateTime.Now;

            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public void DeleteCategory(Category category)
        {
             _context.Categories.Remove(category);

            _context.SaveChanges();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.Where(e => !e.SoftDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(e => !e.SoftDeleted && e.Id == id);
            if (category == null) throw new NotFoundException("Kategoriya tapilmadi");
            return category;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateCategory(Category categoryToUpdate, Category category)
        {
            categoryToUpdate.SoftDeleted = category.SoftDeleted;
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.ModifiedBy = category.ModifiedBy;
            categoryToUpdate.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }
}
