using Admin.Filters;
using Admin.Models.Manager;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Enums;
using Repository.Exceptions;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class ManagerController : Controller
    {
        private Repository.Data.Entities.Admin _admin => RouteData.Values["Admin"] as Repository.Data.Entities.Admin;
        private readonly IMapper _mapper;
        private readonly IAdminService _adminService;

        public ManagerController(IMapper mapper, IAdminService adminService)
        {
            _mapper = mapper;
            _adminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var manager = await _adminService.GetManagers();
            var model = _mapper.Map<IEnumerable<Repository.Data.Entities.Admin>, IEnumerable<AdminViewModel>>(manager);
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            if (_admin.Type != ManagerType.SuperAdmin)
            {
                return NotFound();
            }
            ViewBag.Admins = await _adminService.GetManagers();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userInput = _mapper.Map<AdminViewModel, Repository.Data.Entities.Admin>(model);
                    await _adminService.Register(userInput);
                }catch(InvalidInputException e)
                {
                    ModelState.AddModelError("Email", e.Message);
                }
                
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (_admin.Type != ManagerType.SuperAdmin)
            {
                return NotFound();
            }
            Repository.Data.Entities.Admin admin = await _adminService.GetAdminById(id);

            if (admin == null) return NotFound();

            await _adminService.DeleteAdmin(admin);

            return RedirectToAction("index");
        }
    }
}
