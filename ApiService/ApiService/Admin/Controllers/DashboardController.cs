using Admin.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
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
