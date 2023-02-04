using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
  public class Feedback : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        
        


    }
}
