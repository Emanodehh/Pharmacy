using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Phramacy_New.Constants;
using Phramacy_New.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Controllers
{
    public class StoreController : Controller
    {
        private readonly PharmacyContext _context;
        public StoreController(PharmacyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<MedicineDTO> medicines = (from m in _context.Medicines
                                           join
                                           c in _context.Categories
                                           on m.CategoryId equals c.Id
                                           select new MedicineDTO()
                                           {
                                               CategoryId = c.Id,
                                               CategoryName = c.Name,
                                               MedicineId = m.Id,
                                               MedicineName = m.Name,
                                               Price = m.Price,
                                               ImageName = m.ImageName
                                           }
                             ).ToList();

            ViewBag.meds = medicines;
            ViewBag.Beauties = _context.Beauties.ToList();
            return CheckClient(View());
        }

        public IActionResult Medicine(int id)
        {
            var medicine = _context.Medicines.Where(m => m.Id == id).SingleOrDefault();

            if (medicine == null)
            {
                ViewBag.error = "No Medicine With This Id";
            }
            else
            {
                ViewBag.error = "";
            }

            return CheckClient(View(medicine));
        }

        [HttpPost]
        public  IActionResult Medicine(Medicine medicine)
        {
            try
            {
                
                Store store = new Store()
                {
                    MedicineId = medicine.Id,
                    UserId = Convert.ToInt32(HttpContext.Session.GetString(SesstionTitle.UserId))
                };
                _context.Stores.Add(store);
                _context.SaveChanges();
                return RedirectToAction("CartMedicine");
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }


        }




        public IActionResult Beauty(int id)
        {
            var beauty= _context.Beauties.Where(m => m.Id == id).SingleOrDefault();

            if (beauty == null)
            {
                ViewBag.error = "No Beauty With This Id";
            }
            else
            {
                ViewBag.error = "";
            }

            return CheckClient(View(beauty));
        }

        [HttpPost]
        public IActionResult Beauty(Beauty beauty)
        {
            try
            {

                Store store = new Store()
                {
                    BeautyId = beauty.Id,
                    UserId = Convert.ToInt32(HttpContext.Session.GetString(SesstionTitle.UserId)),
                    CreatedDate = DateTime.Now
                };
                _context.Stores.Add(store);
                _context.SaveChanges();
                return RedirectToAction("CartBeauty");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }


        }

        public IActionResult CheckClient(IActionResult view)
        {
            if (HttpContext.Session.GetString(SesstionTitle.UserRole) == SesstionTitle.client)
            {
                return view;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult CartMedicine()
        {


            var stores = (from s in _context.Stores
                          join m in _context.Medicines
                          on s.MedicineId equals m.Id
                          where s.UserId == Convert.ToInt32(HttpContext.Session.GetString(SesstionTitle.UserId))
                          select new StoreDTO()
                          {
                              MedicineId = m.Id,
                              MedicineName = m.Name,
                              StoreID = s.Id,
                              CreatedDate = s.CreatedDate,
                              UserID = s.Id,
                              Price = m.Price,
                              Username = HttpContext.Session.GetString(SesstionTitle.UserName),
                              ImageName = m.ImageName
                          }
                          ).ToList();


            return View(stores.OrderByDescending(x=>x.MedicineId));
        }


        public IActionResult CartBeauty()
        {


            var stores = (from s in _context.Stores
                          join b in _context.Beauties
                          on s.BeautyId equals b.Id
                          where s.UserId == Convert.ToInt32(HttpContext.Session.GetString(SesstionTitle.UserId))
                          select new StoreDTO()
                          {
                              BeautyName = b.Name,
                              StoreID = s.Id,
                              CreatedDate = s.CreatedDate,
                              UserID = s.Id,
                              Price = b.Price,
                              Username = HttpContext.Session.GetString(SesstionTitle.UserName),
                              ImageName = b.ImageName
                          }
                          ).ToList();


            return View(stores.OrderByDescending(x => x.CreatedDate));
        }


    }
}
