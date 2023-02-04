using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace Phramacy_New.Controllers
{
    public class FeedbackController : Controller
    {
        PharmacyContext _pharmacyContext;
        public FeedbackController(PharmacyContext pharmacyContext)
        {

            _pharmacyContext = pharmacyContext;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            try
            {

                if (String.IsNullOrEmpty(feedback.Email))
                {
                    ViewBag.Error = "Please, Fill out email";

                }
                else if (String.IsNullOrEmpty(feedback.Message))
                {
                    ViewBag.Error = "Please, Fill out Message";


                }
                else if (String.IsNullOrEmpty(feedback.Name))
                {
                    ViewBag.Error = "Please, Fill out Name";
                }
                else
                {
                    _pharmacyContext.Feedbacks.Add(feedback);
                    _pharmacyContext.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }

                return View();
            }
            
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();

    }
    }
}

