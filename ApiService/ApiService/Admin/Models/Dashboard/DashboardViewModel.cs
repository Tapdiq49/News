using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Dashboard
{
    public class DashboardViewModel
    {
        public int newsCount { get; set; }
        public int categoryCount { get; set; }
        public int likedNewsCount { get; set; }
        public int dislikedNewsCount { get; set; }
    }
}
