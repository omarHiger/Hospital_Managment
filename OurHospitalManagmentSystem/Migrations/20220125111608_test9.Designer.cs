﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OurHospitalManagmentSystem.Data;

namespace OurHospitalManagmentSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220125111608_test9")]
    partial class test9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OurHospitalManagmentSystem.Class_Attriputes.Doctor_Phone_Numbers", b =>
                {
                    b.Property<int>("Doctor_Id")
                        .HasColumnType("int");

                    b.Property<string>("Doctor_Phone_Number")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Doctor_Id", "Doctor_Phone_Number");

                    b.ToTable("Doctor_Phone_Numbers");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Class_Attriputes.Hospital_Phone_Numbers", b =>
                {
                    b.Property<int>("Serial_Number")
                        .HasColumnType("int");

                    b.Property<string>("Hospital_Phone_Number")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Serial_Number", "Hospital_Phone_Number");

                    b.ToTable("Hospital_Phone_Numbers");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Class_Attriputes.Patient_Phone_Numbers", b =>
                {
                    b.Property<int>("Patient_Id")
                        .HasColumnType("int");

                    b.Property<string>("Patient_Phone_Number")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Patient_Id", "Patient_Phone_Number");

                    b.ToTable("Patient_Phone_Numbers");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Models.Doctor", b =>
                {
                    b.Property<int>("Doctor_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department_Id")
                        .HasColumnType("int");

                    b.Property<string>("Doctor_Area")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Doctor_Birth_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Doctor_Birth_Place")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Doctor_Career")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Doctor_City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Doctor_Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Doctor_Family_Members")
                        .HasColumnType("int");

                    b.Property<string>("Doctor_First_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Doctor_Gender")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTime>("Doctor_Hire_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Doctor_Last_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Doctor_Middle_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Doctor_National_Number")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Doctor_Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Doctor_Qualifications")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doctor_Social_Status")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Doctor_Specialization")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Doctor_Street")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Doctor_Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Models.Hospital", b =>
                {
                    b.Property<int>("Serial_Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ho_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Ho_Subscribtion_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hospital_Area")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Hospital_City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Hospital_Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Mgr_Id")
                        .HasColumnType("int");

                    b.HasKey("Serial_Number");

                    b.HasIndex("Mgr_Id");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Models.Medical_Detail", b =>
                {
                    b.Property<string>("MD_Patient_Allergies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MD_Patient_Blood_Type")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("MD_Patient_Chronic_diseases")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MD_Patient_Eternal_Records")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MD_Patient_Examination_Records")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MD_Patient_Family_Health_History")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MD_Patient_Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("MD_Patient_Special_Needs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MD_Patient_Treatment_Plans_And_Daily_Supplements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasIndex("PatientId");

                    b.ToTable("Medical_Details");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Models.Patient", b =>
                {
                    b.Property<int>("Patient_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Patient_Area")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Patient_Birth_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Patient_Birth_Place")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Patient_City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Patient_Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Patient_First_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Patient_Gender")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Patient_Last_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Patient_Middle_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Patient_National_Number")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Patient_Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Patient_Social_Status")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Patient_Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Serial_Number")
                        .HasColumnType("int");

                    b.HasKey("Patient_Id");

                    b.HasIndex("Serial_Number");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Class_Attriputes.Doctor_Phone_Numbers", b =>
                {
                    b.HasOne("OurHospitalManagmentSystem.Models.Doctor", null)
                        .WithMany("Doctor_Phone_Numbers")
                        .HasForeignKey("Doctor_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Class_Attriputes.Hospital_Phone_Numbers", b =>
                {
                    b.HasOne("OurHospitalManagmentSystem.Models.Hospital", null)
                        .WithMany("Hospital_Phone_Numbers")
                        .HasForeignKey("Serial_Number")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Class_Attriputes.Patient_Phone_Numbers", b =>
                {
                    b.HasOne("OurHospitalManagmentSystem.Models.Patient", null)
                        .WithMany("Patient_Phone_Numbers")
                        .HasForeignKey("Patient_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Models.Hospital", b =>
                {
                    b.HasOne("OurHospitalManagmentSystem.Models.Doctor", "Manager")
                        .WithMany()
                        .HasForeignKey("Mgr_Id");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Models.Medical_Detail", b =>
                {
                    b.HasOne("OurHospitalManagmentSystem.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Models.Patient", b =>
                {
                    b.HasOne("OurHospitalManagmentSystem.Models.Hospital", null)
                        .WithMany("Ho_Patients")
                        .HasForeignKey("Serial_Number")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Models.Doctor", b =>
                {
                    b.Navigation("Doctor_Phone_Numbers");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Models.Hospital", b =>
                {
                    b.Navigation("Ho_Patients");

                    b.Navigation("Hospital_Phone_Numbers");
                });

            modelBuilder.Entity("OurHospitalManagmentSystem.Models.Patient", b =>
                {
                    b.Navigation("Patient_Phone_Numbers");
                });
#pragma warning restore 612, 618
        }
    }
}
