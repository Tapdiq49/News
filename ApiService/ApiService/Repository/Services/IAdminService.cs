using Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IAdminService
    {
        Admin Login(string email, string password);
        bool UserExsist(string email);
        Admin CheckByToken(string token);
        void UpdateToken(int id, string token);
        void Logout(int id);
        Task ForgetPassword(string email);
        Task ChangePassword(string forgetToken, string password);
        Task<bool> CheckForgetToken(string token);
    }
}
