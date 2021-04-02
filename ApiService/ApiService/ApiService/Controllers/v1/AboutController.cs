using ApiService.Resources.About;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Entities;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAbout()
        {
            var about = await _aboutService.GetAbout();
            var aboutResource = _mapper.Map<About, AboutResource>(about);
            return Ok(aboutResource);
        }
    }
}
