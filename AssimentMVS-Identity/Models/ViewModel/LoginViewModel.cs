using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVS_Identity.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(80, MinimumLength = 8, ErrorMessage = "Password must be 8 long and maximum 20 long.")]
        public string Password { get; set; }
    }
}
