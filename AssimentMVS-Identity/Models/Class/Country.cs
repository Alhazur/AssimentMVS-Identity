using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVS_Identity.Models.Class
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<City> Cities { get; set; }
    }
}
