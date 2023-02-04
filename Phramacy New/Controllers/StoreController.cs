using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Phramacy_New.Constants;
using Phramacy_New.DTO;
using Phramacy_New.Interfaces;
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
        private readonly IMedicineRepository _mediciensRepository;
        private readonly IBeautiesRepositories _beautiesRepository;
        private readonly IStoreRepositories _storeRepository;
        public StoreController(PharmacyContext context,IMedicineRepository medicineRepository,IBeautiesRepositories beautiesRepositories,IStoreRepositories storeRepositories)
        {
            _context = context;
            _mediciensRepository = medicineRepository;
            _beautiesRepository = beautiesRepositories;
            _storeRepository = storeRepositories;

        }

        public IActionResult Index()
        {
            List<MedicineDTO> medicines = _mediciensRepository.GetMedicineDtos();
            ViewBag.meds = medicines;
            ViewBag.Beauties = _beautiesRepository.getBeauties();
            return CheckClient(View());
        }

        public IActionResult Medicine(int id)
         {
            var medicine = _mediciensRepository.GetById(id);

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
                _storeRepository.CreateStore(store);
                return RedirectToAction("CartMedicine");
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }


        }




        public IActionResult Beauty(int id)
        {
            var beauty = _beautiesRepository.GetById(id);

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
                _storeRepository.CreateStore(store);
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


            var stores = _storeRepository.GetStoreMedicineDTOByUserId(Convert.ToInt32(HttpContext.Session.GetString(SesstionTitle.UserId)), HttpContext.Session.GetString(SesstionTitle.UserName));
            
            return View(stores.OrderByDescending(x=>x.MedicineId));
        }


        public IActionResult CartBeauty()
        {

            var stores = _storeRepository.GetStoreBeautyDTOByUserId(Convert.ToInt32(HttpContext.Session.GetString(SesstionTitle.UserId)), HttpContext.Session.GetString(SesstionTitle.UserName));
            
            return View(stores.OrderByDescending(x => x.CreatedDate));
        }


    }
}
