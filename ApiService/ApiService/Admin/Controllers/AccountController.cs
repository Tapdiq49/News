using Admin.Filters;
using Admin.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Exceptions;

namespace Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminService _adminService;
        private Repository.Data.Entities.Admin _admin => RouteData.Values["Admin"] as Repository.Data.Entities.Admin;

        public AccountController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = _adminService.Login(model.Email, model.Password);

                if (admin != null)
                {
                    admin.Token = Guid.NewGuid().ToString();

                    _adminService.UpdateToken(admin.Id, admin.Token);

                    Response.Cookies.Append("admin-token", admin.Token, new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        HttpOnly = true,
                        Expires = model.RememberMe ? DateTime.Now.AddYears(1) : DateTime.Now.AddDays(1)
                    });

                    return RedirectToAction("index", "dashboard");
                }

                ModelState.AddModelError("Password", "E-poçt və ya şifrə yalnışdır");
            }

            return View(model);
        }

        [TypeFilter(typeof(Auth))]
        public IActionResult Logout()
        {
            _adminService.Logout(_admin.Id);

            return RedirectToAction("login", "account");
        }

        public  IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            try
            {
                 await _adminService.ForgetPassword(model.Email);
            }
            catch (NotFoundException e)
            {
                ModelState.AddModelError("Email", "Belə bir e-poçt addresi mövcud deyil");
            }

            return View(model);
        }

        public IActionResult ChangePassword(string token)
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel
            {
                ForgetToken = token,
                Password = ""

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid) {

                try
                {
                    await _adminService.ChangePassword(model.ForgetToken, model.Password);
                }
                catch (NotFoundException e)
                {
                    ModelState.AddModelError("Password", "fsdfds");
                }
               
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("index", "dashboard");
            }
            return View(model);

            
        }

        public async Task<IActionResult> CheckForgetToken(string token)
        {
            try
            {
                await _adminService.CheckForgetToken(token);
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, new { e.Message });
            }
            return Ok();
        }

    }
}
