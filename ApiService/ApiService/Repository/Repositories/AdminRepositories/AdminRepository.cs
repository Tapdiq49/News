using Repository.Data;
using Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.AdminRepositories
{
    public interface IAdminRepository
    {
        Admin Login(string email, string password);
        bool UserExsist(string email);
        Admin CheckByToken(string token);
        void UpdateToken(int id, string token);

        void Logout(int id);
    }
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }
        public Admin CheckByToken(string token)
        {
            return _context.Admins.FirstOrDefault(e => e.Token == token);
        }

        public Admin Login(string email, string password)
        {
            Admin admin = _context.Admins.FirstOrDefault(a => a.Email == email);

            if (admin != null && CryptoHelper.Crypto.VerifyHashedPassword(admin.Password, password))
            {
                return admin;
            }

            return null;
        }

        public void Logout(int id)
        {
            var admin = _context.Admins.Find(id);

            admin.Token = null;

            _context.SaveChanges();

        }

        public void UpdateToken(int id, string token)
        {
            Admin admin = _context.Admins.Find(id);

            admin.Token = token;

            _context.SaveChanges();
        }

        public bool UserExsist(string email)
        {
            return _context.Admins.Any(a => a.Email == email);
        }
    }
}
