using Entities;
using Phramacy_New.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Interfaces
{
   public interface IStoreRepositories
   {
        void CreateStore(Store store);
        void Edit(Store store);
        void Edit(List<Store> stores);
        List<StoreDTO> GetStoreMedicineDTOByUserId(int userId, string userName);
        List<StoreDTO> GetStoreBeautyDTOByUserId(int userId, string userName);
        Store GetById(int id);
        List<Store> GetStoresByMedicineId(int medicineId);
        List<Store> GetStorseByBeautyId(int beautyId);

    }
}
