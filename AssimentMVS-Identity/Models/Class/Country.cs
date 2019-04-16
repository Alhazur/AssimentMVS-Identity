using AssimentMVS_Identity.Models.Class;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssimentMVS_Identity.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<City> Cities { get; set; }
    }
}
