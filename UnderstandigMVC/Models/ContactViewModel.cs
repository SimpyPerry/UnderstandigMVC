using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandigMVC.Models
{
    public class ContactViewModel
    {

        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage ="For lang besked")]
        public string Message { get; set; }
    }
}
