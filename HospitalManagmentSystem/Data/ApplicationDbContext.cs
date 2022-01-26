using HospitalManagmentSystem.BreakTables;
using HospitalManagmentSystem.Class_Attriputes;
using HospitalManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; } // دولة
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Preview> Previews { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Medical_Detail> Medical_Details { get; set; }
        public DbSet<Medical_Test> Medical_Tests { get; set; }
        public DbSet<Ray> Rays { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Surgery_Room> Surgery_Rooms { get; set; }
        public DbSet<Surgery> Surgeries { get; set; }
        public DbSet<Death_Case> Death_Cases{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient_Phone_Numbers>().HasKey(o => new { o.Patient_Id, o.Patient_Phone_Number });
            modelBuilder.Entity<Doctor_Phone_Numbers>().HasKey(o => new { o.Doctor_Id, o.Doctor_Phone_Number });
            modelBuilder.Entity<Hospital_Phone_Numbers>().HasKey(o => new { o.Ho_Id, o.Hospital_Phone_Number });
            modelBuilder.Entity<Employee_Phone_Numbers>().HasKey(o => new { o.Employee_Id, o.Employee_Phone_Number });
            modelBuilder.Entity<Caring>().HasKey(o => new { o.Doctor_Id, o.Patient_Id });
        }
    }
}
