using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Models
{
    public class Ray
    {
        [Key]
        public int Ray_Id { get; set; }
        [Required]
        public DateTime Ray_Date { get; set; }
        [Required]
        [Display(Name = "Ray Type")]
        [StringLength(60)]
        public string Ray_Type { get; set; }
        [Required]
        [Display(Name = "Ray Result")]
        public string Ray_Result { get; set; } // needs to be an img
        [Required]
        public int Patient_Id { get; set; } // Foreign Key
    }
}
