using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Phramacy_New.DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Phramacy_New.Constants;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace Phramacy_New.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly PharmacyContext _context;
        public MedicinesController(PharmacyContext context,IWebHostEnvironment hostEnvironmentl)
        {
            _hostEnvironment = hostEnvironmentl;
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

            return CheckAdmin(View(medicines.OrderByDescending(x => x.CategoryId)));

        }
        public IActionResult Delete(int id)
        {
            
            Medicine med = _context.Medicines.Where(x => x.Id == id).SingleOrDefault(); 
            if (med == null)
            {
                ViewBag.Error = "No Medicine With This Id";
            }
            else
            {
                ViewBag.Error = String.Empty;
            }
            return CheckAdmin(View(med));
        }


        [HttpPost]
        public IActionResult Delete(Medicine medicine)
        {
            _context.Remove(medicine);
            _context.SaveChanges();
            return CheckAdmin(RedirectToAction("Index"));
        }


        public IActionResult Edit(int id)
        {
            Medicine med = _context.Medicines.Where(x => x.Id == id).SingleOrDefault(); 
            if (med == null)
            {
                ViewBag.Error = "No Medicine With This Id";
            }
            else
            {
                ViewBag.Error = String.Empty;//A string is null if it has not been assigned a value.
            }
            return CheckAdmin(View(med));
        }

        
        


        [HttpPost]
        public async Task<IActionResult> Edit(Medicine medicine)
        {
            if (medicine.ImageFile != null)
            {
                string wwwRootPath = Path.Combine(_hostEnvironment.WebRootPath);
                string fileName = Guid.NewGuid().ToString() + "_" + medicine.ImageFile.FileName;
                string extension = Path.GetExtension(medicine.ImageFile.FileName);
                string path = Path.Combine(wwwRootPath + "/MedicineImages/" + fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await medicine.ImageFile.CopyToAsync(fileStream);
                    medicine.ImageName = fileName;
                }
                    
            }
            _context.Medicines.Update(medicine);
            _context.SaveChanges();
            return CheckAdmin(RedirectToAction("Index") 
                
                );

        }

        public IActionResult Create()
        {
            Medicine medicine = new Medicine();
            ViewBag.categories = _context.Categories.ToList();
            return CheckAdmin(View(medicine));
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(Medicine medicine)
        {
            if (medicine.ImageFile != null)
            {
                // Get Path to wwwRoot
                string wwwRootPath = Path.Combine(_hostEnvironment.WebRootPath);
                //Create Random Name for image
                string fileName = Guid.NewGuid().ToString() + "_" + medicine.ImageFile.FileName;

                // Get Extension of image
                string extension = Path.GetExtension(medicine.ImageFile.FileName);

                //Get path to image
                string path = Path.Combine(wwwRootPath + "/MedicineImages/" + fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    // Store Image in wwwroot/MedicineImage
                    // Copy your image to wwwroot/MedicineImage
                    await medicine.ImageFile.CopyToAsync(fileStream);

                    //Store Image name in medicine.ImageName
                    medicine.ImageName = fileName;
                }

            }          
            _context.Medicines.Add(medicine); 
            _context.SaveChanges();
            return CheckAdmin(RedirectToAction("Index"));

        }

           

        public IActionResult CheckAdmin(IActionResult view)
        {
            if (HttpContext.Session.GetString(SesstionTitle.UserRole) != SesstionTitle.admin)
            {
                return RedirectToAction("Index", "Home");       
            }
            else
            {
                return view;
            }
        }

        
    }
}

