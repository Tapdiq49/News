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

        public void ContactToUpdate(Contact contactToUpdate, Contact contact)
        {
            contactToUpdate.ModifiedAt = DateTime.Now;
            contactToUpdate.Phone = contact.Phone;
            contactToUpdate.Address = contact.Address;
            contactToUpdate.Email = contact.Email;

            _context.SaveChanges();

        }

        public async Task<Contact> GetContact()
        {
            return await _context.Contacts.FirstOrDefaultAsync();
        }

        public Contact GetContactById(int id)
        {
            return _context.Contacts.Find(id);
        }
    }
}
