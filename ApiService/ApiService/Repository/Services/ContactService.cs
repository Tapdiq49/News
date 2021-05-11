using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.Entities;
using System;
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

        public async Task ContactToUpdate(Contact contactToUpdate, Contact contact)
        {
            contactToUpdate.ModifiedAt = DateTime.Now;
            contactToUpdate.Phone = contact.Phone;
            contactToUpdate.Address = contact.Address;
            contactToUpdate.Email = contact.Email;

           await _context.SaveChangesAsync();

        }

        public async Task<Contact> GetContact()
        {
            return await _context.Contacts.FirstOrDefaultAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }
    }
}
