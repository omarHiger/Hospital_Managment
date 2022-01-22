using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings.Models
{
    public class Reservation
    {
        [Key]
        public int Reservation_Id { get; set; }
        public int Patient_Id { get; set; } // Foreign Key
        public int Room_Id { get; set; } // Foreign Key
    }
}
