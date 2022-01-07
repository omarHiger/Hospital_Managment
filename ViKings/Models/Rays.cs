using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings.Models
{
    public class Rays
    {
        [Key]
        public int Rays_Id { get; set; }
        [Required]
        [Display(Name = "Rays Result")]
        public string Rays_Result { get; set; }
        [Required]
        [Display(Name = "Rays Type")]
        public string Rays_Type { get; set; }
        public int Patient_Id { get; set; } // Foreign Key
    }
}
