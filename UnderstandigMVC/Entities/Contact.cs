using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandigMVC.Entities
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }
        public string Name { get; set; }
      
        public string Mail { get; set; }
      
        public string Subject { get; set; }
    
        public string Message { get; set; }
    }
}
