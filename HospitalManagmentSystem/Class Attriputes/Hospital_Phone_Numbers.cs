using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Class_Attriputes
{
    public class Hospital_Phone_Numbers
    {
        //public int Id { get; set; }
        [Key] [Column(Order =1)]
        public int Ho_Id { get; set; } // Foreign Key 
        [Required]
        [Key] [Column(Order = 2)]
        public string Hospital_Phone_Number { get; set; }
    }
}
