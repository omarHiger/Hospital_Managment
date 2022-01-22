using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ViKings_1.Class_Attriputes;

namespace ViKings_1.Models
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
       // [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Email")]
        public string Patient_Email { get; set; }
        //public string Patient_Email { get { return Patient_Email; } set { Patient_Email = value + "PAT.com"; } }
        [Required]
        [Display(Name = "Password")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Must Be Between 8 and 25 Characters ")]
        public string Patient_Password { get; set; }
       // public string Patient_Password { get { return PasswordSecurity.Decrypt(Patient_Password); } set { Patient_Password = PasswordSecurity.Encrypt(value); }}
        public string Patient_Account { get { return Patient_Email + " " + Patient_Password; } }
        [StringLength(50)]
        [Display(Name = "Area")]
        public string Patient_Area { get; set; }
        [StringLength(50)]
        [Display(Name = "Street")]
        public string Patient_Street { get; set; }
        [StringLength(50)]
        [Display(Name = "City")]
        public string Patient_City { get; set; }
        // public string Patient_X_Y { get; set; }
        [Display(Name = "Location")]
        public string Patient_Location { get { return Patient_Area + " " + Patient_City + " " + Patient_Street; } }
        [Required]
        public string Patient_National_Number { get; set; }
        [Required]
        [StringLength(6)]
        [Display(Name = "Gender")]
        public string Patient_Gender { get; set; } // Male or Female
        [Required]
        [StringLength(10)]
        [Display(Name = "Social Status")]
        public string Patient_Social_Status { get; set; } = "Single"; // Married or Single
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime Patient_Birth_Date { get; set; }
        [Display(Name = "Age")]
        public int Patient_Age { get { return DateTime.Now.Year - Patient_Birth_Date.Year; } }

        [ForeignKey("Patient_Id")]
        public virtual List<Patient_Phone_Numbers> Patient_Phone_Numbers { get; set; } = new List<Patient_Phone_Numbers>();

    }
}
