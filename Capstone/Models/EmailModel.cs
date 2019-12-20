using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Capstone.Models;
namespace Capstone.Models
{
    public class EmailModel
    {
        [Required, Display(Name = "Your name")]
        public string ToName { get; set; }
        [Required, Display(Name = "Your email"/*, EmailAddress*/)]
        public string ToEmail { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string message { get; set; }
    }
}