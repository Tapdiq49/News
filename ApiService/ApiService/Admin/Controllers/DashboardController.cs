using Control.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control.Controllers
{
    public class DashboardController : Controller
    {
        [TypeFilter(typeof(Auth))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
