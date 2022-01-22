using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings_1.Class_Attriputes
{
    public class Employee_Phone_Numbers
    {
        public int Employee_Id { get; set; }
        [Required]
        public string Employee_Phone_Number { get; set; }
    }
}
