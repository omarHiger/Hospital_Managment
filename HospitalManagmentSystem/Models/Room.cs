﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Models
{
    public class Room
    {
        [NotMapped]
        public int Count { get; set; } = 0; // increment & Decrement On Reservation ...
        [Key]
        public int Room_Id { get; set; }
        [Display(Name = "Available")]
        public bool Room_Empty { get; set; } = true; // Empty == true ,,, not empty == false ;
        [Display(Name = "Number of Beds")]
        [Required]
        [Range(0, 10,ErrorMessage ="Must Be Between 0 and 10")]
        public int Room_Type { get; set; } // Number of Beds
        public int Ho_Id { get; set; } // ForeignKey  // Not Required, we Take its value from a hidden Input

        [ForeignKey("Room_Id")]
        public virtual List<Reservation> Room_Reservations { get; set; }
    }
}
