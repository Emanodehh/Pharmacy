using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User : BaseEntity
    {
        
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
       
    }
}
