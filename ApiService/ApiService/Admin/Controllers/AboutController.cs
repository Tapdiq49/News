using Admin.Filters;
using Admin.Models.About;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Entities;
using Repository.Enums;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private Repository.Data.Entities.Admin _admin => RouteData.Values["Admin"] as Repository.Data.Entities.Admin;

        public AboutController(IMapper mapper, IAboutService aboutService)
        {
            _mapper = mapper;
            _aboutService = aboutService;
        }
        public async Task<IActionResult> Index()
        {
            var about = await _aboutService.GetAbout();
            var model = _mapper.Map<About, AboutViewModel>(about);
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (_admin.Type != ManagerType.SuperAdmin)
            {
                return NotFound();
            }
            About about =  await _aboutService.GetAboutById(id);

            if (about == null) return NotFound();

            var model = _mapper.Map<About, AboutViewModel>(about);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AboutViewModel model)
        {
            if (ModelState.IsValid)
            {
                About about = _mapper.Map<AboutViewModel, About>(model);

                About aboutToUpdate = await _aboutService.GetAboutById(model.Id);

                aboutToUpdate.ModifiedBy = _admin.Fullname;

                if (aboutToUpdate == null) return NotFound();

                await _aboutService.AboutToUpdate(aboutToUpdate, about);

                return RedirectToAction("index");
            }

            return View(model);
        }
    }
}
