using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastHMS.Models
{
    public class Bill
    {
        [Key]
        public int Bill_Id { get; set; }
        [Display(Name = "Examination")]
        public double Bill_Examination { get; set; } // Currency
        [Display(Name = "Surgeries")]
        public double Bill_Surgeries { get; set; }
        [Display(Name = "Rays")]
        public double Bill_Rays { get; set; }
        [Display(Name = "Medical Test")]
        public double Bill_Medical_Test { get; set; }
        [Display(Name = "Room Service")]
        public double Bill_Room_Service { get; set; }
        [Required]
        public int Patient_Id { get; set; } // Foreign Key //cascade
    }
}
