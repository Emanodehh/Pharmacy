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
    public class StoreRepository : BaseRepository<Store>, IStoreRepositories
    {

        public StoreRepository(PharmacyContext context) : base(context)
        {

        }

        public void CreateStore(Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
        }

        public void Edit(Store store)
        {
            _context.Stores.Update(store);
            _context.SaveChanges();

        }
        public void Edit(List<Store> stores)
        {
            foreach(var store in stores)
            {
                _context.Stores.Update(store);
            }
            _context.SaveChanges();

        }

        public List<StoreDTO> GetStoreBeautyDTOByUserId(int userId, string userName)
        {
            return (from s in _context.Stores
                    join b in _context.Beauties
                    on s.BeautyId equals b.Id
                    where s.UserId == userId
                    select new StoreDTO()
                    {
                        BeautyName = b.Name,
                        StoreID = s.Id,
                        CreatedDate = s.CreatedDate,
                        UserID = s.Id,
                        Price = b.Price,
                        Username = userName,
                        ImageName = b.ImageName
                    }
                          ).ToList();

        }

        public List<StoreDTO> GetStoreMedicineDTOByUserId(int userId,string userName)
        {
            return (from s in _context.Stores
                    join m in _context.Medicines
                    on s.MedicineId equals m.Id
                    where s.UserId == userId
                    select new StoreDTO()
                    {
                        MedicineId = m.Id,
                        MedicineName = m.Name,
                        StoreID = s.Id,
                        CreatedDate = s.CreatedDate,
                        UserID = s.Id,
                        Price = m.Price,
                        Username = userName,
                        ImageName = m.ImageName
                    }
                          ).ToList();
        }

        public List<Store> GetStoresByMedicineId(int medicineId)
        {
            return _context.Stores.Where(x => x.MedicineId == medicineId).ToList();
        }

        public List<Store> GetStorseByBeautyId(int beautyId)
        {
            return _context.Stores.Where(x => x.BeautyId == beautyId).ToList();
        }


    }
}