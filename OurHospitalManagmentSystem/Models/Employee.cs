using OurHospitalManagmentSystem.Class_Attriputes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OurHospitalManagmentSystem.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First Name Must Be Between 2 and 30 characters ..")]
        [Display(Name = "First Name")]
        public string Employee_First_Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Middle Name Must Be Between 2 and 30 characters ..")]
        [Display(Name = "Middle Name")]
        public string Employee_Middle_Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last Name Must Be Between 2 and 30 characters ..")]
        [Display(Name = "Last Name")]
        public string Employee_Last_Name { get; set; }
        [Display(Name = "Full Name")]
        public string Employee_Full_Name { get { return Employee_First_Name + " " + Employee_Middle_Name + " " + Employee_Last_Name; } }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Email")]
        public string Employee_Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Must Be Between 8 and 25 Characters ")]
        public string Employee_Password { get; set; }
        [Required]
        [Display(Name = "National Number")]
        [StringLength(25)]
        public string Employee_National_Number { get; set; }
        [Required]
        [StringLength(6)]
        [Display(Name = "Gender")]
        public string Employee_Gender { get; set; }
        [StringLength(50)]
        [Display(Name = "Area")]
        [Required]
        public string Employee_Area { get; set; }
        [StringLength(50)]
        [Display(Name = "Street")]
        [Required]
        public string Employee_Street { get; set; }
        [StringLength(50)]
        [Display(Name = "City")]
        [Required]
        public string Employee_City { get; set; }
        // public string Employee_X_Y { get; set; }
        [Display(Name = "Location")]
        public string Employee_Location { get { return Employee_Area + " " + Employee_City + " " + Employee_Street; } }
        [Display(Name = "Number of Family Members")]
        [Range(0, 25,ErrorMessage ="Must be between 0 and 25")]
        public int Employee_Family_Members { get; set; } = 0;
        [Required]
        [StringLength(30)]
        [Display(Name = "Type")]

        public string Employee_Type { get; set; }
        [Display(Name = "Career")]
        [StringLength(255)]
        public string Employee_Career { get; set; }
        [Display(Name = "Qualifications")]
        
        public string Employee_Qualifications { get; set; }
        [Required]
        [Display(Name = "Social Status")]
        [StringLength(20)]
        public string Employee_Social_Status { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime Employee_Birth_Date { get; set; }
        [Display(Name = "Age")]
        public int Employee_Age { get { return DateTime.Now.Year - Employee_Birth_Date.Year; } }
        [Display(Name = "Birth Place")]
        [StringLength(100)]
        public string Employee_Birth_Place { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime Employee_Hire_Date { get; set; } = DateTime.Now;
        public int Serial_Number { get; set; } // Foreign Key

        [ForeignKey("Employee_Id")]
        public virtual List<Employee_Phone_Numbers> Employee_Phone_Numbers { get; set; } = new List<Employee_Phone_Numbers>();
    }
}
