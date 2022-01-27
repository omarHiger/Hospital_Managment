using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Models
{
    public class Medical_Test
    {
        [Key]
        public int Test_Id { get; set; }
        [Display(Name = "Test Date")]
        [Required]
        public DateTime Test_Date { get; set; }
        [Required]
        [Display(Name = "Test Type")]
        [StringLength(60)]
        public string Test_Type { get; set; } // Drop Down List
        [Required]
        [Display(Name = "Test Result")]
        public string Test_Result { get; set; } // needs to be an img 
        [Required]
        public int Patient_Id { get; set; } // Foreign Key
    }
}
