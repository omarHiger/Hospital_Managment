using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Models
{
    public class Preview
    {
        [Key]
        public int Preview_Id { get; set; }
        [Required]
        [Display(Name = "Preview Date")]
        public DateTime Preview_Date { get; set; }
        [Required]
        public int Patient_Id { get; set; } // Foreign Key
        [Required]
        public int Doctor_Id { get; set; } // Foreign Key
    }
}
