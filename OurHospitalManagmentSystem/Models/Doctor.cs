using OurHospitalManagmentSystem.BreakTables;
using OurHospitalManagmentSystem.Class_Attriputes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OurHospitalManagmentSystem.Models
{
    public class Doctor
    {
        [Key]  // (111111,1)
        public int Doctor_Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First Name Must Be Between 2 and 30 characters ..")]
        [Display(Name = "First Name")]
        public string Doctor_First_Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First Name Must Be Between 2 and 30 characters ..")]
        [Display(Name = "Middle Name")]
        public string Doctor_Middle_Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First Name Must Be Between 2 and 30 characters ..")]
        [Display(Name = "Last Name")]
        public string Doctor_Last_Name { get; set; }
        [Display(Name = "Full Name")]
        public string Doctor_Full_Name { get { return Doctor_First_Name + " " + Doctor_Middle_Name + " " + Doctor_Last_Name; } }
        [Required] // [unique]
        [StringLength(25)]
        public string Doctor_National_Number { get; set; }// Unique   // Remeber that he is a doctor !!!!!!!!!
        [Required]
        [StringLength(6)]
        [Display(Name = "Gender")]
        public string Doctor_Gender { get; set; }
        [StringLength(50)]
        [Display(Name = "Area")]
        public string Doctor_Area { get; set; }
        [StringLength(50)]
        [Display(Name = "Street")]
        public string Doctor_Street { get; set; }
        [StringLength(50)]
        [Display(Name = "City")]
        public string Doctor_City { get; set; }
        [Display(Name = "Location")]
        public string Doctor_Location { get { return Doctor_Area + " " + Doctor_City + " " + Doctor_Street; } }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Email")]
        public string Doctor_Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Must Be Between 8 and 25 Characters ")]
        public string Doctor_Password { get; set; }

        [Range(0,25, ErrorMessage = "Must be between 0 and 25")]
        public int Doctor_Family_Members { get; set; } = 0 ;
        [Required]
        [StringLength(60)]
        [Display(Name = "Specialization")]
        public string Doctor_Specialization { get; set; }
        [Display(Name = "Career")]
        [StringLength(255)]
        public string Doctor_Career { get; set; }
        [Display(Name = "Qualifications")]
        // max
        public string Doctor_Qualifications { get; set; }
        [StringLength(10)]
        [Display(Name = "Social Status")]
        public string Doctor_Social_Status { get; set; }
 
        [Display(Name = "Birth Date")]
        public DateTime Doctor_Birth_Date { get; set; }
        [Display(Name = "Age")]
        public int Doctor_Age { get { return DateTime.Now.Year - Doctor_Birth_Date.Year; } }
        [Display(Name = "Birth Place")]
        [StringLength(100)]
        public string Doctor_Birth_Place { get; set; }
        [Required]
        [Display(Name = "Hire Date")]
        public DateTime Doctor_Hire_Date { get; set; }
        [Required]
        public int Department_Id { get; set; } // Foreign Key

        [ForeignKey("Doctor_Id")]
        public virtual List<Doctor_Phone_Numbers> Doctor_Phone_Numbers { get; set; } = new List<Doctor_Phone_Numbers>();
        [ForeignKey("Doctor_Id")]
        public virtual List<Preview> Doctor_Previews { get; set; } = new List<Preview>();
        [ForeignKey("Doctor_Id")]
        public virtual List<Surgery> Doctor_Surgeries { get; set; } = new List<Surgery>();

        [ForeignKey("Doctor_Id")]
        public virtual List<Caring> CareGiver { get; set; } = new List<Caring>();
    }
}