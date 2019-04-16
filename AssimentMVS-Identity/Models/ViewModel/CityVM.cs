using AssimentMVS_Identity.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVS_Identity.Models.ViewModel
{
    public class CityVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }//001

        public Country Country { get; set; }

        public List<Person> People = new List<Person>();
    }
}
