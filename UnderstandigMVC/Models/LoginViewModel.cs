﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandigMVC.Models
{
    public class LoginViewModel : IdentityUser
    {
        [Required]
        [Display(Name ="User name")]
        [MinLength(5)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
