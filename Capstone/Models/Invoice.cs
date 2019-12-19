using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public double InvoiceAmount { get; set; }
        public string DueDate { get; set; }
        public bool IsPaid { get; set; }
    }
}