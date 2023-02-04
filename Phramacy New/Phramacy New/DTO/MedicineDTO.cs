using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.DTO
{
    public class MedicineDTO
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } 
        public float Price{ get; set; } 
        public string ImageName{ get; set; }
    }
}
