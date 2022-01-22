using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings.Models
{
    public class Medical_Details
    {
        [Required]
        [StringLength(90)]
        [Display(Name ="Patient Name")]
        public string MD_Patient_Name { get; set; }
        [Required]
        [StringLength(3)]
        [Display(Name = "Blood Type")]
        public string MD_Patient_Blood_Type { get; set; }
        [Display(Name = "Treatment Plans and Daily Supplements")]
        public string MD_Patient_Treatment_Plans_And_Daily_Supplements { get; set; }
        [Display(Name = "Chronic Diseases")]
        public string MD_Patient_Chronic_diseases { get; set; }
        [Display(Name = "Examination Records")]
        public string MD_Patient_Examination_Records { get; set; }
        [Display(Name = "Special Needs")]
        public string MD_Patient_Special_Needs { get; set; }
        [Display(Name = "Family Health History")]
        public string MD_Patient_Family_Health_History { get; set; }
        [Display(Name = "Allergies")]
        public string MD_Patient_Allergies { get; set; }
        [Display(Name = "Eternal Records")]
        public string MD_Patient_Eternal_Records { get; set; }

    }
}
