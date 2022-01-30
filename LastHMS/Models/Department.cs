using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LastHMS.Models
{
    public class Department
    {
        [Key]
        public int Department_Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Department_Name { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Type")]
        public string Department_Type { get; set; }
        public int Ho_Id { get; set; } // Foreign Key // cascade
        [ForeignKey("Dept_Mgr_Id")] // Foreign Key // set null unique
        public virtual Doctor Dept_Manager { get; set; }

        [ForeignKey("Department_Id")]
        public virtual List<Doctor> Department_Doctors { get; set; } = new List<Doctor>();

    }
}
