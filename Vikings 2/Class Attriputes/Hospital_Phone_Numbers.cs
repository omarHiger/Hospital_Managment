using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vikings_2.Class_Attriputes
{
    public class Hospital_Phone_Numbers
    {
        public int Serial_Number { get; set; } // Foreign Key 
        [Required]
        public string Hospital_Phone_Number { get; set; }
    }
}
