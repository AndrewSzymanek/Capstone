using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Day
    {
        [Key]
        public int DayId { get; set; }
        
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }

        public double HoursWorked { get; set; }

        public double DaysPay { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}