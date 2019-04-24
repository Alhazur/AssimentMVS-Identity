using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssimentMVS_Identity.Models.ViewModel
{
    public class CityVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }
        
        //public Country Country { get; set; }

        //public List<Person> People = new List<Person>();
    }
}
