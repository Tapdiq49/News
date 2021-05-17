using Admin.Filters;
using Admin.Models.Dashboard;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System.Linq;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            DashboardViewModel dashboard = new DashboardViewModel();

            dashboard.categoryCount = _context.Categories.Count();
            dashboard.newsCount = _context.News.Count();

            dashboard.likedNewsCount = _context.News.Where(e => e.Like > 0).Count();
            dashboard.dislikedNewsCount = _context.News.Where(e => e.Dislike > 0).Count();

           
           
            return View(dashboard);
        }

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
