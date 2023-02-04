using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Store
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int? MedicineId { get; set; }
        public int? BeautyId { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Medicine Medicine { get; set; }
        public User User{ get; set; }
        public Beauty Beauty{ get; set; }
    }
}
