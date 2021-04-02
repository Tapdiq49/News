using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.Entities;
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
        public async Task<About> GetAbout()
        {
            return await _context.Abouts.FirstOrDefaultAsync();
        }
    }
}
