using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vikings_2.Class_Attriputes
{
    public class Doctor_Phone_Numbers
    {
        public int Doctor_Id { get; set; }
        [Required]
        public string Doctor_Phone_Number { get; set; }
    }
}
