﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class AppointmentStatus
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Appointment Status")]

        public string Name { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
