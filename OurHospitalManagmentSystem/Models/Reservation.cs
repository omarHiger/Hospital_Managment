using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OurHospitalManagmentSystem.Models
{
    public class Reservation
    {
        [Key]
        public int Reservation_Id { get; set; }
        [Required]
        public int Patient_Id { get; set; } // Foreign Key
        [Required]
        public int Room_Id { get; set; } // Foreign Key
        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; } // Room.Count --


    }
}
