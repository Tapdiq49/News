using ApiService.Resources.Contact;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Entities;
using Repository.Services;
using System.Threading.Tasks;

namespace ApiService.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetContact()
        {
            var contact = await _contactService.GetContact();
            var contactResource = _mapper.Map<Contact, ContactResource>(contact);
            return Ok(contactResource);
        }
    }
}
