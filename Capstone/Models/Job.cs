using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        private double? materialsCost { get; set; }
        public double? MaterialsCost { get { return materialsCost; } set { materialsCost = value; } }
        public double? LaborCost { get; set; }
        public double? TotalLiabilities { get; set; }
        public double? PaymentReceived { get; set; }
        public int? DaysToComplete { get; set; }
        public bool? IsComplete { get; set; }
        public double? ProfitabilityRatio { get; set; }

    }
}