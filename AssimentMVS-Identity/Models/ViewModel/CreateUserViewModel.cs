using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVS_Identity.Models.ViewModel
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(Name ="UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength = 8, ErrorMessage ="Password must be 8 long and maximum 20 long.")]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
