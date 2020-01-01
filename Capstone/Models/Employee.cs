﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Hourly rate")]
        public double HourlyRate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public Geolocation Geolocation { get; set; }

    }
    
    public class Geolocation
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}