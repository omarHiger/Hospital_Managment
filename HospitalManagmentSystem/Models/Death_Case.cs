using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Models
{
    public class Death_Case
    {
        [Key]
        public int Death_Case_Number { get; set; }
        [Required]
        public string Death_Cause { get; set; }
        [Required]
        [Display(Name = "Death Date")]
        public DateTime Death_Date { get; set; }
        [Required]
        [ForeignKey("Patient_Id")] // unique
        public virtual Patient Dead_Patient { get; set; }
    }
}
