﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings_1.Class_Attriputes
{

    public class Patient_Phone_Numbers
    {
        public int Id { get; set; }
        public int Patient_Id { get; set; }
        [Required]
        public string Patient_Phone_Number { get; set; }
    }
}





//[Key][Column(Order = 0)]

//[Key] [Column(Order = 1)] 