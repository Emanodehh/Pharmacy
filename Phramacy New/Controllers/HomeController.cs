using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Phramacy_New.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Controllers
{
    public class HomeController : Controller
    {
        private readonly PharmacyContext _context;
        public HomeController( PharmacyContext context)
        {
          
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                ViewBag.meds = _context.Medicines.ToList();
                ViewBag.beauties = _context.Beauties.ToList();
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
