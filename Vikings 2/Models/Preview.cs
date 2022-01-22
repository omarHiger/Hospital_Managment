﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vikings_2.Models
{
    public class Preview
    {
        [Key]
        public int Preview_Id { get; set; }
        [Required]
        public DateTime Preview_Date { get; set; }
        public int Patient_Id { get; set; } // Foreign Key
        //public int Doctor_Id { get; set; } // Foreign Key
    }
}
