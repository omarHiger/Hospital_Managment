using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings.Models
{
    public class Death_Cases
    {
        [Required]
        [StringLength(200)]
        public string Death_Cause { get; set; }
        [Required]
        [Display(Name = "Death Date")]
        public DateTime Death_Date { get; set; }
    }
}
