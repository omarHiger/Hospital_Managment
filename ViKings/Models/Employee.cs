using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ViKings.Class_Attriputes;

namespace ViKings.Models
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
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Email")]
        public string Employee_Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Must Be Between 8 and 25 Characters ")]
        public string Employee_Password { get; set; }
        public string Employee_Account { get { return Employee_Email + " " + Employee_Password; } }
        [Required]
        public string Employee_National_Number { get; set; }
        [Required]
        [StringLength(6)]
        [Display(Name ="Gender")]
        public string Employee_Gender { get; set; }
        [StringLength(50)]
        [Display(Name = "Area")]
        public string Employee_Area { get; set; }
        [StringLength(50)]
        [Display(Name = "Street")]
        public string Employee_Street { get; set; }
        [StringLength(50)]
        [Display(Name = "City")]
        public string Employee_City { get; set; }
        // public string Employee_X_Y { get; set; }
        [Display(Name = "Location")]
        public string Employee_Location { get { return Employee_Area + " " + Employee_City + " " + Employee_Street; } }
        [Display(Name = "Number of Family Members")]
        public int Employee_Family_Members { get; set; } = 0;
        [Required]
        [StringLength(30,MinimumLength =2)]
        [Display(Name = "Type")]

        public string Employee_Type { get; set; }
        [Display(Name = "Career")]

        public string Employee_Career { get; set; }
        [Display(Name = "Qualifications")]

        public string Employee_Qualifications { get; set; }
        [Required]
        [Display(Name = "Social Status")]
        public string Employee_Social_Status { get; set; } = "Single";
        [Display(Name = "Birth Date")]
        public DateTime Employee_Birth_Date { get; set; }
        [Display(Name = "Age")]
        public int Employee_Age { get { return DateTime.Now.Year - Employee_Birth_Date.Year; } }
        [Display(Name = "Birth Place")]
        public string Employee_Birth_Place { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime Employee_Hire_Date { get; set; } = DateTime.Now;
        public int Department_Id { get; set; } // Foreign Key

        [ForeignKey("Employee_Id")]
        public virtual ICollection<Employee_Phone_Numbers> Employee_Phone_Numbers { get; set; }

    }
}
