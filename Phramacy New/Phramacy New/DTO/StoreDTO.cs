using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.DTO
{
    public class StoreDTO
    {
        public int? MedicineId { get; set; }
        public string? MedicineName { get; set; }
        public string? BeautyName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StoreID { get; set; }
        public string Username { get; set; }
        public int UserID { get; set; }
        public float Price { get; set; }

        public string ImageName { get; set; }
    }
}
