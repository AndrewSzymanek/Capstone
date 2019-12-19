using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class PaymentInfo
    {
        [Key]
        public int PaymentInfoId { get; set; }
        public string NameOnCard { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardExpirationDate { get; set; }
        public int CreditCardSecurityCode { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}