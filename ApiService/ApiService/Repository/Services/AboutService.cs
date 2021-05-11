using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        public AboutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AboutToUpdate(About aboutToUpdate, About about)
        {
            aboutToUpdate.ModifiedAt = DateTime.Now;
            aboutToUpdate.Text = about.Text;
            aboutToUpdate.Title = about.Title;

            await _context.SaveChangesAsync();
        }

        public async Task<About> GetAbout()
        {
            return await _context.Abouts.FirstOrDefaultAsync();
        }

        public async Task<About> GetAboutById(int id)
        {
            return await _context.Abouts.FindAsync(id);
        }
    }
}
