create table hospital(

SerialNumber int primary key not null,
Name_HO nvarchar(50),
City nvarchar(50),
Street nvarchar(50),
Area nvarchar(50)
)
create table Doctor
(
Doc_ID int primary key not null,
First_Name nvarchar(50),
Middle_Name nvarchar(50),
Last_Name  nvarchar(50),
Acount nvarchar(50),
Gender nvarchar(50),
Date_of_hiring date ,
Birth_Date date,
National_number int unique ,
City nvarchar(50),
Street nvarchar(50),
Area nvarchar(50),
social_status nvarchar(50),
Family_mamber  int ,
Specialization nvarchar(50),
Qualifications� nvarchar(50),
)

create table Patient
(
ID_Pa int primary key not null,
First_Name nvarchar(50),
Middle_Name nvarchar(50),
Last_Name  nvarchar(50),
City nvarchar(50),
Street nvarchar(50),
Area nvarchar(50),
Gender nvarchar(50),
Birth_Date date,
Acount nvarchar(50),
National_number int unique ,
social_status nvarchar(50),
Career nvarchar(50),
Birth_Place nvarchar(max),
)

create table Patient_Phone_numPa
(
Phone_numPa int primary key
ID_Pa int 
)


create table Medical_Details
(
ID_Pa int ,
Examenation_Records nvarchar(max),
Blood_type nvarchar(5),
Treatment plans&Daily supplements nvarchar(max)
Allergies nvarchar(50),
Examenation_Records nvarchar(50),
Family_Health_History nvarchar(50),
Special_Needs nvarchar(50),
Chronic_diseases nvarchar
)

create table Employee
(
ID_emp int primary key not null,
First_Name nvarchar(50),
Middle_Name nvarchar(50),
Last_Name  nvarchar(50),
City nvarchar(50),
Street nvarchar(50),
Area nvarchar(50),
Gender nvarchar(50),
Date_of_hiring date ,
Birth_Date date,
National_number int unique ,
Acount nvarchar(50),
Emp_Type nvarchar(50),
Qualifications� nvarchar(max),
social_status nvarchar(50),
Family_mamber  int 
)


create table Department
(
Dept_ID int primary key not null,
Dept_name nvarchar(50),
Dept_type nvarchar(50)
)

create table Room
(
Room_ID int primary key not null,
Room_type nvarchar(20),
Empity_or_not bit 
)

create table Surgery_Room
(
Room_ID_SU int primary key not null, 
Ready_or_not bit
Serial_number_HO int 
)

create table Surgery
(
Surgery_number int primary key not null,
Surgery_name nvarchar(50),
Surgery_date date,
Pa_ID int,
Doc_ID int 
)

create table Death_Cases
(
ID_Pa int ,
Death_date date,
Cause_death nvarchar(50)
)

