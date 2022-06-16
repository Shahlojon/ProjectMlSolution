using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectML.Core.Enum;
using ProjectML.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProjectML.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationContext _context;

        public DashboardController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var user = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefaultAsync();
            ViewBag.User = user;
            return View();
        }
    }
}
