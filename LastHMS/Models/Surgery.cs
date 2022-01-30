using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastHMS.Models
{
    public class Surgery
    {
        [Key]
        public int Surgery_Number { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Surgery_Name { get; set; }
        [Required]
        public DateTime Surgery_Date { get; set; }
        [Required]
        public int Surgery_Time { get; set; } // in minutes  // No boundries to the time because the doctor is the one whose entering it 
        public int Surgery_Room_Id { get; set; } // Foreign Key // No Action
        public int Doctor_Id { get; set; } // Foreign Key // he is the one that is entering it //set null
        [Required]
        [StringLength(90)]
        [Display(Name = "Doctor Name")]
        public string Doctor_Name { get; set; }
        [Required]
        public int Patient_Id { get; set; } // Foreign Key  // cascade
    }
}
