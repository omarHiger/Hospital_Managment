using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastHMS1.Models
{
    public class Reservation
    {
        [Key]
        public int Reservation_Id { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Room Number")]
        public string Room_Number { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; } // Room.Count --
        [Required]
        public int Patient_Id { get; set; } // Foreign Key // cascade
        public int Room_Id { get; set; } // Foreign Key // No Action 
    }
}
