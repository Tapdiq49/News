using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Controllers
{
    [Route("v{ver:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMapper _mapper => HttpContext.RequestServices.GetService<IMapper>();
    }
}
