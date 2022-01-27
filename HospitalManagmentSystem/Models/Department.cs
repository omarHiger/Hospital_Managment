using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Models
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
        public int Ho_Id { get; set; } // Foreign Key
        [ForeignKey("Dept_Mgr_Id")]
        public virtual Doctor Dept_Manager { get; set; }

        //[ForeignKey("Department_Id")]
        //public virtual ICollection<Employee> Department_Employees { get; set; } // Deleted <3
        [ForeignKey("Department_Id")]
        public virtual List<Doctor> Department_Doctors { get; set; } = new List<Doctor>();

    }
}
