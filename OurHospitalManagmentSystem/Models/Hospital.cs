﻿
using OurHospitalManagmentSystem.Class_Attriputes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OurHospitalManagmentSystem.Models
{
    public class Hospital
    {
        [Key]
        public int Serial_Number { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Hospital Name ")]
        public string Ho_Name { get; set; }
        [Required]
        [Display(Name = "Subscribtion Date")]
        public DateTime Ho_Subscribtion_Date { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Area")]
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
        [ForeignKey("Mgr_Id")]
        public virtual Doctor Manager { get; set; }

        [ForeignKey("Serial_Number")]
        public virtual List<Hospital_Phone_Numbers> Hospital_Phone_Numbers { get; set; } = new List<Hospital_Phone_Numbers>();

        [ForeignKey("Serial_Number")]
        public virtual List<Patient> Ho_Patients { get; set; } = new List<Patient>();
        [ForeignKey("Serial_Number")]
        public virtual List<Employee> Ho_Employees{ get; set; } = new List<Employee>();
        [ForeignKey("Serial_Number")]
        public virtual List<Room> Hospital_Rooms { get; set; } = new List<Room>();
        [ForeignKey("Serial_Number")]
        public virtual List<Surgery_Room> Hospital_Surgery_Rooms { get; set; } = new List<Surgery_Room>();
        [ForeignKey("Serial_Number")]
        public virtual List<Department> Hospital_Departments { get; set; } = new List<Department>();


    }
}
