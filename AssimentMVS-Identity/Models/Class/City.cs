﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVS_Identity.Models.Class
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Country Country { get; set; }

        public List<Person> People { get; set; }
    }
}
