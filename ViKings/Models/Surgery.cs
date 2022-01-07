using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings.Models
{
    public class Surgery
    {
        [Key]
        public int Surgery_Id { get; set; }
        [Required]
        [Display(Name ="Name")]
        [StringLength(30,MinimumLength =2)]
        public string Surgery_Name { get; set; }
        [Required]
        public DateTime Surgery_Date { get; set; }
        [Required]
        public int Surgery_Time { get; set; } // in minutes  // No boundries to the time because the doctor is the one whose entering it 
        public int Surgery_Room_Id { get; set; } // Foreign Key
        public int Doctor_Id { get; set; } // Foreign Key
    }
}
