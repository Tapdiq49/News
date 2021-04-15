using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.Entities;
using Repository.Exceptions;
using Repository.Services.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public AdminService(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task ChangePassword(string forgetToken, string password)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(u => u.ForgetToken == forgetToken);

            if (admin == null) throw new NotFoundException("Token tapılmadı");

            admin.Password = CryptoHelper.Crypto.HashPassword(password);
            admin.ForgetToken = null;
            admin.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public Admin CheckByToken(string token)
        {
            return _context.Admins.FirstOrDefault(e => e.Token == token);
        }

        public async Task<bool> CheckForgetToken(string token)
        {
            bool check = await _context.Admins.AnyAsync(u => u.ForgetToken == token);

            if (!check) throw new NotFoundException("Token tapılmadı");

            return true;
        }

        public async Task ForgetPassword(string email)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(e => e.Email == email);

            if (admin == null) throw new NotFoundException("E-poçt tapılmadı");

            admin.ForgetToken = Guid.NewGuid().ToString();

            await _context.SaveChangesAsync();

            await _emailService.SendAsync(admin.Email, admin.Fullname, "d-e7ec5a458b974f1084e93e9641438c54", new
            {
                subject = "Forget Password",
                fullname = admin.Fullname,
                text = $"We’ve received a request to reset the password for the Stripe account associated with {admin.Email}. No changes have been made to your account yet.",
                btnText = "Reset your password",
                btnUrl = $"https://localhost:44397/account/ChangePassword?token={admin.ForgetToken}"
            });
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
