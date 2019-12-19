using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("Contractor")]
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

    }
}