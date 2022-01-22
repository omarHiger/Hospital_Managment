using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ViKings.Class_Attriputes;

namespace ViKings.Models
{
    public class Hospital
    {
        [Key]
        public int Serial_Number { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name ="Hospital Name ")]
        public string Hospital_Name { get; set; }
        [Required]
        [Display(Name = "Subscribtion Date")]
        public DateTime Hospital_Subscribtion_Date { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Area")]
        [DisplayName]
        public string Hospital_Area { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Street")]
        public string Hospital_Street { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "City")]
        public string Hospital_City { get; set; }
        [Display(Name = "Location")]
        public string Hospital_Location { get { return Hospital_Area + " " + Hospital_City + " " + Hospital_Street; } }
        [ForeignKey("Serial_Number")]
        public virtual ICollection<Hospital_Phone_Numbers> Hospital_Phone_Numbers { get; set; }
        [ForeignKey("Serial_Number")]
        public virtual ICollection<Room> Hospital_Rooms { get; set; }   
        [ForeignKey("Serial_Number")]
        public virtual ICollection<Surgery_Room> Hospital_Surgery_Rooms { get; set; }   
        [ForeignKey("Serial_Number")]
        public virtual ICollection<Department> Hospital_Departments { get; set; }   




        // relation between Doctor and Hospital   1-1 unique manager


    }
}
