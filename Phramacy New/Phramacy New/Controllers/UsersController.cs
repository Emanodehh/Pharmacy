using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Phramacy_New.Constants;
using Phramacy_New.Repositories;
using System;
using System.Linq;

namespace Phramacy_New.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepositores;
        protected readonly PharmacyContext _context;

        public UsersController(IUserRepository userRepositores, PharmacyContext context)
        {
            this.userRepositores = userRepositores;
            _context = context;
        }

        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }   

        [HttpPost]
        public IActionResult Login(User user)
        {
            var rec = userRepositores.Login(user);
            if (rec != null)
            {
                HttpContext.Session.SetString(SesstionTitle.UserId,rec.Id.ToString());
                HttpContext.Session.SetString(SesstionTitle.UserEmail, rec.Email.ToString());
                HttpContext.Session.SetString(SesstionTitle.UserName,rec.Name.ToString());
                HttpContext.Session.SetString(SesstionTitle.UserRole,rec.Role);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.error = "invalid email or password";
                return View(user);
            }

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                user.Role = SesstionTitle.client;
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
            
        }





    }





}
