using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OurHospitalManagmentSystem.Class_Attriputes
{
    public class Hospital_Phone_Numbers
    {
        //public int Id { get; set; }
        [Key] [Column(Order =1)]
        public int Serial_Number { get; set; } // Foreign Key 
        [Required]
        [Key] [Column(Order = 2)]
        public string Hospital_Phone_Number { get; set; }
    }
}
