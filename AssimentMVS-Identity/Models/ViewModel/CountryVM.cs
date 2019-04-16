using AssimentMVS_Identity.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVS_Identity.Models.ViewModel
{
    public class CountryVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Country Country { get; set; }

        public City City { get; set; }

        public List<City> Cities = new List<City>();

        public List<Person> People = new List<Person>();
    }
}
