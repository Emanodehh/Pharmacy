using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Phramacy_New.Constants;
using Phramacy_New.Interfaces;
using Phramacy_New.Repositories;
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
        private readonly IBeautiesRepositories beautiesRepositories;
        private readonly IStoreRepositories storeRepositories;



        public BeautiesController(IWebHostEnvironment hostEnvironment, IStoreRepositories storeRepositories, IBeautiesRepositories beautiesRepositories)
        {
            _hostEnvironment = hostEnvironment;
            this.beautiesRepositories = beautiesRepositories;
            this.storeRepositories = storeRepositories;
        }

        public IActionResult Index()
        {
            try
            {
                var beauties = beautiesRepositories.getBeauties();

                return CheckAdmin(View(beauties.OrderByDescending(x => x.Name)));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        public IActionResult Create()
        {
            return CheckAdmin(View());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Beauty beauty)
        {
            try
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
                beautiesRepositories.Create(beauty);
                return CheckAdmin(RedirectToAction("Index"));
            }

            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();

        }

        public IActionResult Delete(int id)
        {

            try
            {
                Beauty beauty = beautiesRepositories.Delete(id);
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
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }


        [HttpPost]
        public IActionResult Delete(Beauty beauty)
        {
            try
            {
                var stores = storeRepositories.GetStorseByBeautyId(beauty.Id);
                foreach (var store in stores)
                {
                    store.BeautyId = null;
                }
                storeRepositories.Edit(stores);
                beautiesRepositories.Delete(beauty);
                return CheckAdmin(RedirectToAction("Index"));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }


        public IActionResult Edit(int id)
        {
            Beauty beauty = beautiesRepositories.Edit(id);
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
            try
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
                beautiesRepositories.Edit(beauty);
                return CheckAdmin(RedirectToAction("Index"));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        public IActionResult CheckAdmin(IActionResult view)
        {
            try
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
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

    }
}
