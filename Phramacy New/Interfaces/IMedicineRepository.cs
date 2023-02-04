using Entities;
using Phramacy_New.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Interfaces
{
    public interface IMedicineRepository
    {
        Medicine GetById(int id);
        List<MedicineDTO> GetMedicineDtos();
        Medicine Delete(int id);
        void Delete(Medicine medicine);
        Medicine Edit(int id);
        void Edit(Medicine medicine);
        void CreateMedicine(Medicine medicine);
    }
}
