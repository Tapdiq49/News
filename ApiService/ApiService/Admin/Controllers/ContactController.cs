using Admin.Models.Contact;
using AutoMapper;
using Admin.Filters;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Entities;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private Repository.Data.Entities.Admin _admin => RouteData.Values["Admin"] as Repository.Data.Entities.Admin;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }
        public async Task<IActionResult> Index()
        {
            var contact = await _contactService.GetContact();
            var model = _mapper.Map<Contact, ContactViewModel>(contact);
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            Contact contact = _contactService.GetContactById(id);

            if (contact == null) return NotFound();

            var model = _mapper.Map<Contact, ContactViewModel>(contact);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = _mapper.Map<ContactViewModel, Contact>(model);

                Contact contactToUpdate = _contactService.GetContactById(model.Id);

                contactToUpdate.ModifiedBy = _admin.Fullname;

                if (contactToUpdate == null) return NotFound();

                _contactService.contactToUpdate(contactToUpdate, contact);

                return RedirectToAction("index");
            }

            return View(model);
        }

    }
}
