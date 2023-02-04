using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Phramacy_New.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Controllers
{
    public class BeautiesController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly PharmacyContext _context;

        public BeautiesController(IWebHostEnvironment hostEnvironment, PharmacyContext context)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Beauty> beauties = _context.Beauties.ToList();

            return CheckAdmin(View(beauties.OrderByDescending(x => x.Name)));
        }

        public IActionResult Create()
        {
            return CheckAdmin(View());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Beauty beauty)
        {
            if (beauty.ImageFile != null)
            {
                // Get Path to wwwRoot
                string wwwRootPath = Path.Combine(_hostEnvironment.WebRootPath);
                //Create Random Name for image
                string fileName = Guid.NewGuid().ToString() + "_" + beauty.ImageFile.FileName;

                // Get Extension of image
                string extension = Path.GetExtension(beauty.ImageFile.FileName);

                //Get path to image
                string path = Path.Combine(wwwRootPath + "/BeautyImages/" + fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    // Store Image in wwwroot/MedicineImage
                    // Copy your image to wwwroot/MedicineImage
                    await beauty.ImageFile.CopyToAsync(fileStream);

                    //Store Image name in medicine.ImageName
                    beauty.ImageName = fileName;
                }

            }
            _context.Beauties.Add(beauty);
            _context.SaveChanges();
            return CheckAdmin(RedirectToAction("Index"));

        }

        public IActionResult Delete(int id)
        {

            Beauty beauty = _context.Beauties.Where(x => x.Id == id).SingleOrDefault();
            if (beauty == null)
            {
                ViewBag.Error = "No Beauty With This Id";
            }
            else
            {
                ViewBag.Error = String.Empty;
            }
            return CheckAdmin(View(beauty));
        }


        [HttpPost]
        public IActionResult Delete(Beauty beauty)
        {
            _context.Remove(beauty);
            _context.SaveChanges();
            return CheckAdmin(RedirectToAction("Index"));     
        }


        public IActionResult Edit(int id)
        {
            Beauty beauty = _context.Beauties.Where(x => x.Id == id).SingleOrDefault();
            if (beauty == null)
            {
                ViewBag.Error = "No Beauty With This Id";
            }
            else
            {
                ViewBag.Error = String.Empty;
            }
            return CheckAdmin(View(beauty));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Beauty beauty)
        {
            if (beauty.ImageFile != null)
            {
                string wwwRootPath = Path.Combine(_hostEnvironment.WebRootPath);
                string fileName = Guid.NewGuid().ToString() + "_" + beauty.ImageFile.FileName;
                string extension = Path.GetExtension(beauty.ImageFile.FileName);
                string path = Path.Combine(wwwRootPath + "/BeautyImages/" + fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await beauty.ImageFile.CopyToAsync(fileStream);
                    beauty.ImageName = fileName;
                }

            }
            _context.Beauties.Update(beauty);
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
