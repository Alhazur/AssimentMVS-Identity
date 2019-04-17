using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssimentMVS_Identity.Models.ViewModel
{
    public class PersonVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }

        public int CityId { get; set; }//001

        public int PersonId { get; set; }//001

        public List<City> Cities = new List<City>();

        public List<Country> Countries = new List<Country>();
    }
}
