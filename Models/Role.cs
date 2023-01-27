﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string Name { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
