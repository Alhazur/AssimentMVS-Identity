using System.ComponentModel.DataAnnotations;

namespace AssimentMVS_Identity.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }

        public City City { get; set; }
    }
}
