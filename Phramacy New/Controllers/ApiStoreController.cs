using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Phramacy_New.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiStoreController : ControllerBase
    {
        PharmacyContext pharmacyContext;
        public ApiStoreController(PharmacyContext pharmacyContext)
        {
            this.pharmacyContext = pharmacyContext; 



        }

        [HttpGet]// http verbs , methods
        public async Task<ActionResult<List<Medicine>>> Getmedicines()
        {
            return Ok(await pharmacyContext.Medicines.ToListAsync()); //200 .
        } 
        

       


        [HttpPost]// add
        public async Task createmedicines(MedicineDTO medicine) //From body
        {
            await pharmacyContext.Medicines.AddAsync(new Medicine 
            {
                Name = medicine.MedicineName, 
                Price = medicine.Price,
                CategoryId = medicine.CategoryId



            }); 
            await this.pharmacyContext.SaveChangesAsync();
        }
      
        


        [HttpDelete("{id}")]
        public async Task Delete(int id)

        {
            var med = await pharmacyContext.Medicines.FindAsync(id);
            this.pharmacyContext.Medicines.Remove(med);
            await this.pharmacyContext.SaveChangesAsync();

        } 

        //Beauties 
      
 
        


   }
}
