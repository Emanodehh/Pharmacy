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
using Phramacy_New.Interfaces;

namespace Phramacy_New.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly IMedicineRepository medicineRepository;
        private readonly ICategoryRepositories categoryRepositories;
        private readonly IStoreRepositories storeRepositories;
        public MedicinesController(IMedicineRepository medicineRepository,IStoreRepositories storeRepositories, ICategoryRepositories categoryRepositories,IWebHostEnvironment hostEnvironmentl)
        {
            _hostEnvironment = hostEnvironmentl;
            this.medicineRepository = medicineRepository;
            this.categoryRepositories = categoryRepositories;
            this.storeRepositories= storeRepositories;

        }
        public IActionResult Index() 
        {
            try
            {
                List<MedicineDTO> medicines = medicineRepository.GetMedicineDtos();

                return CheckAdmin(View(medicines.OrderByDescending(x => x.CategoryId)));
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

                Medicine med = medicineRepository.Delete(id);
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
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }


        [HttpPost]
        public IActionResult Delete(Medicine medicine)
        {

            try
            {
                var med = medicineRepository.GetById(medicine.Id);
                var stores = storeRepositories.GetStoresByMedicineId(med.Id);
                foreach(var store in stores)
                {
                    store.MedicineId = null;
                }
                storeRepositories.Edit(stores);

                medicineRepository.Delete(med);
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
            Medicine med = medicineRepository.Edit(id);
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
            try
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
                medicineRepository.Edit(medicine);
                return CheckAdmin(RedirectToAction("Index")

                    );

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();

        }

        public IActionResult Create()
        {
            try
            {
                ViewBag.categories = categoryRepositories.getallcategory();

                return CheckAdmin(View());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Medicine medicine)
        {
            try
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
                medicineRepository.CreateMedicine(medicine);

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

