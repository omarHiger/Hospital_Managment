﻿using OurHospitalManagmentSystem.BreakTables;
using OurHospitalManagmentSystem.Class_Attriputes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OurHospitalManagmentSystem.Models
{
    public class Patient
    {
        [Key]
        public int Patient_Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First Name Must Be Between 2 and 30 characters ..")]
        [Display(Name = "First Name")]
        public string Patient_First_Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Middle Name Must Be Between 2 and 30 characters ..")]
        [Display(Name = "Middle Name")]
        public string Patient_Middle_Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last Name Must Be Between 2 and 30 characters ..")]
        [Display(Name = "Last Name")]
        public string Patient_Last_Name { get; set; }
        [Display(Name = "Full Name")]
        public string Patient_Full_Name { get { return Patient_First_Name + " " + Patient_Middle_Name + " " + Patient_Last_Name; } }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Email")]
        public string Patient_Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Must Be Between 8 and 25 Characters ")]
        public string Patient_Password { get; set; }
        [StringLength(50)]
        [Display(Name = "Area")]
        [Required]
        public string Patient_Area { get; set; }
        [StringLength(50)]
        [Display(Name = "Street")]
        [Required]
        public string Patient_Street { get; set; }
        [StringLength(50)]
        [Display(Name = "City")]
        [Required]
        public string Patient_City { get; set; }
     // public double Patient_X_Y { get; set; }

        [Display(Name = "Location")]
        public string Patient_Location { get { return Patient_Area + " " + Patient_City + " " + Patient_Street; } }
        [Required]
        [Display(Name = "National Number")]
        [StringLength(25)]
        public string Patient_National_Number { get; set; }
        [Required]
        [StringLength(6)]
        [Display(Name = "Gender")]
        public string Patient_Gender { get; set; } // Male or Female
        [StringLength(10)]
        [Display(Name = "Social Status")]
        public string Patient_Social_Status { get; set; }  // Married or Single
        [Display(Name = "Birth Date")]
        public DateTime Patient_Birth_Date { get; set; }
        [Required]
        [Display(Name = "Birth Place")]
        [StringLength(100)]
        public string Patient_Birth_Place { get; set; }
        [Display(Name = "Age")]

        public int Serial_Number { get; set; } // Foreign key 
        public int Patient_Age { get { return DateTime.Now.Year - Patient_Birth_Date.Year; } }
        [ForeignKey("Patient_Id")]
        public virtual List<Patient_Phone_Numbers> Patient_Phone_Numbers { get; set; } = new List<Patient_Phone_Numbers>();

        [ForeignKey("Patient_Id")]
        public virtual List<Preview> Patient_Previews { get; set; } = new List<Preview>();
        [ForeignKey("Patient_Id")]
        public virtual List<Ray> Patient_Rays { get; set; } = new List<Ray>();
        [ForeignKey("Patient_Id")]
        public virtual List<Medical_Test> Medical_Tests { get; set; } = new List<Medical_Test>();
        [ForeignKey("Patient_Id")]
        public virtual List<Reservation> Patient_Reservations { get; set; } = new List<Reservation>();
        [ForeignKey("Patient_Id")]
        public virtual List<Bill> Patient_Bills { get; set; } = new List<Bill>();
        [ForeignKey("Patient_Id")]
        public virtual List<Caring> CareTaker { get; set; } = new List<Caring>();
        [ForeignKey("Patient_Id")]
        public virtual List<Surgery> Patient_Surgeries { get; set; } = new List<Surgery>();
    }
}
