﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LastHMS1.Class_Attriputes
{
    public class Employee_Phone_Numbers
    {
        [Key] [Column(Order = 1)]
        public int Employee_Id { get; set; }
        [Required]
        [Key] [Column(Order = 2)]
        [StringLength(25)]
        public string Employee_Phone_Number { get; set; }
    }
}
