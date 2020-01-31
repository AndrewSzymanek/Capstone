using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [DisplayName("Job name")]
        public string JobName { get; set; }

        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        public string Lat { get; set; }
        public string Long { get; set; }
        private double? materialsCost { get; set; }

        [DisplayName("Total Materials Cost")]
        public double? MaterialsCost { get { return materialsCost; } set { materialsCost = value; } }

        [DisplayName("Total Labor Cost")]
        public double? LaborCost { get; set; }

        [DisplayName("Total Liabilities (labor + materials)")]
        public double? TotalLiabilities { get; set; }

        [DisplayName("Payment Received")]
        public double? PaymentReceived { get; set; }

        [DisplayName("Days To Complete")]
        public int? DaysToComplete { get; set; }

        [DisplayName("Complete?")]
        public bool? IsComplete { get; set; }

        [DisplayName("Date completed")]
        public DateTime? DateCompleted { get; set; }

        [DisplayName("Profitability Ratio")]
        public double? ProfitabilityRatio { get; set; }
     

        [NotMapped]
        public Weather Weather { get; set; }
    }

    public class Weather
    {
        public int Temperature { get; set; }
        public string Condition { get; set; }
    }
}