﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "City")]

        public string Name { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
