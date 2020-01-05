using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        [DisplayName("Time In")]
        public string TimeIn { get; set; }

        [DisplayName("Time Out")]
        public string TimeOut { get; set; }

        [DisplayName("Checked In")]
        public bool CheckedIn { get; set; }

        public string TodaysDate { get; set; }

        [DisplayName("Time Worked")]
        public double? MinutesWorked { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}