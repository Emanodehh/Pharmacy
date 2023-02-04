using Entities;
using Model;
using Phramacy_New.DTO;
using Phramacy_New.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Repositories
{
    public class MediciensRepositores : BaseRepository<Medicine>, IMedicineRepository //genric
    {


        public MediciensRepositores(PharmacyContext context) : base(context)
        {

        }
        public List<MedicineDTO> GetMedicineDtos()
        {
          return  (from m in _context.Medicines
             join
             c in _context.Categories
             on m.CategoryId equals c.Id
             select new MedicineDTO()
             {
                 CategoryId = c.Id,
                 CategoryName = c.Name,
                 MedicineId = m.Id,
                 MedicineName = m.Name,
                Price=m.Price,
                 ImageName = m.ImageName
             }).ToList();
        
        

           
        }
        public Medicine Delete(int id)
        {
            var med = _context.Medicines.SingleOrDefault(x => x.Id == id);
            return (med);

        }
        public void Delete(Medicine medicine)
        {
            var med = _context.Medicines.SingleOrDefault(x => x.Id == medicine.Id);
            _context.Medicines.Remove(med);
            _context.SaveChanges();
        }

        public Medicine Edit(int id)
        {
            return _context.Medicines.Where(x => x.Id == id).SingleOrDefault();
            
        }

        public void Edit(Medicine medicine)
        {
            _context.Medicines.Update(medicine);
            _context.SaveChanges();
        }

        public void CreateMedicine(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
            _context.SaveChanges();

        }


    }
}



