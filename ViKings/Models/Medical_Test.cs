using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings.Models
{
    public class Medical_Test
    {
        [Key]
        public int Test_Id { get; set; }
        [Required]
        [Display(Name = "Test Result")]
        public string Test_Result { get; set; }
        [Required]
        [Display(Name = "Test Type")]
        public string Test_Type { get; set; } // Drop Down List
        public int Patient_Id { get; set; } // Foreign Key
    }
}
