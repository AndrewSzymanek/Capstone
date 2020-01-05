using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [DisplayName("Task Name")]
        public string TaskName { get; set; }

        [DisplayName("Complete?")]
        public bool IsComplete { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}