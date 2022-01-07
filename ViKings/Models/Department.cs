using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings.Models
{
    public class Department
    {
        [Key]
        public int Department_Id { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name ="Name")]
        public string Department_Name { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Type")]
        public string Department_Type { get; set; }
        public int Serial_Number { get; set; } // Foreign Key

        [ForeignKey("Department_Id")]
        public virtual ICollection<Employee> Department_Employees { get; set; }    
        [ForeignKey("Department_Id")]
        public virtual ICollection<Doctor> Department_Doctors { get; set; }
    }
}
