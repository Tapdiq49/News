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

        public void AboutToUpdate(About aboutToUpdate, About about)
        {
            aboutToUpdate.ModifiedAt = DateTime.Now;
            aboutToUpdate.Text = about.Text;
            aboutToUpdate.Title = about.Title;

            _context.SaveChanges();
        }

        public async Task<About> GetAbout()
        {
            return await _context.Abouts.FirstOrDefaultAsync();
        }

        public About GetAboutById(int id)
        {
            return _context.Abouts.Find(id);
        }
    }
}
