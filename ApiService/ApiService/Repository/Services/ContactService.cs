using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.Entities;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;
        public ContactService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Contact> GetContact()
        {
            return await _context.Contacts.FirstOrDefaultAsync();
        }
    }
}
