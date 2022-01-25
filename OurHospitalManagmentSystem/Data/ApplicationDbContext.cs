using Microsoft.EntityFrameworkCore;
using OurHospitalManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OurHospitalManagmentSystem.Class_Attriputes;

namespace OurHospitalManagmentSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Patient> Patients{ get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals{ get; set; }
        public DbSet<Medical_Detail> Medical_Details { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient_Phone_Numbers>().HasKey(o => new { o.Patient_Id, o.Patient_Phone_Number });
            modelBuilder.Entity<Doctor_Phone_Numbers>().HasKey(o => new { o.Doctor_Id, o.Doctor_Phone_Number });
            modelBuilder.Entity<Hospital_Phone_Numbers>().HasKey(o => new { o.Serial_Number, o.Hospital_Phone_Number });
            modelBuilder.Entity<Employee_Phone_Numbers>().HasKey(o => new { o.Employee_Id, o.Employee_Phone_Number });
        }
    }
}
