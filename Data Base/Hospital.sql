create table hospital(

SerialNumber int,
Name_HO nvarchar(50),
City nvarchar(50),
Street nvarchar(50),
Area nvarchar(50),
Mgr_Id int,
constraint HO_SerialNumber_PK primary key (SerialNumber),
)

create table HO_Phone(
  HO_Phone nvarchar(10),
  Ho_SerialNumber int ,
  constraint Ho_Phone_SerialNumber_FK foreign key (Ho_SerialNumber) references  hospital(SerialNumber)
)
create table Doctor
(
Do_ID int,
First_Name nvarchar(50),
Middle_Name nvarchar(50),
Last_Name  nvarchar(50),
Email nvarchar(50),
Password nvarchar(50),
Gender nvarchar(50),
Date_of_hiring date ,
Birth_Date date,
National_number int unique,
City nvarchar(50),
Street nvarchar(50),
Area nvarchar(50),
social_status nvarchar(50),
Family_mamber  int ,
Specialization nvarchar(50),
Qualificationsþ nvarchar(50),  
constraint DO_ID_PK primary key (Do_ID),
)
ALTER TABLE hospital
ADD constraint hospital_Mgr_Id_FK FOREIGN KEY (Mgr_Id) REFERENCES Doctor(Do_Id);


create table Doctor_Phone_number
(
	Do_Phone nvarchar(10),
	Do_Id int,
	constraint Doctor_Phone_number_PK primary key (Do_Phone,Do_Id),
	constraint Doctor_Phone_number_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID)
)

create table Patient
(
Pa_ID int,
First_Name nvarchar(50),
Middle_Name nvarchar(50),
Last_Name  nvarchar(50),
City nvarchar(50),
Street nvarchar(50),
Area nvarchar(50),
X_Y geography,
Gender nvarchar(50),
Birth_Date date,
Birth_Place nvarchar(max),
social_status nvarchar(50),
Career nvarchar(50),
Email nvarchar(50),
Password nvarchar(50),
National_number int unique ,
Ho_SerialNumber int,
constraint Pa_ID_PK primary key (Pa_ID),
constraint Patient_HO_SerialNumber_FK foreign key (Ho_SerialNumber) references  hospital(SerialNumber)
)

create table Caregiver
(
	Do_Id int,
	Pa_Id int,
	constraint Caregiver_PK primary key (Pa_Id,Do_Id),
	constraint Caregiver_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID),
	constraint Caregiver_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)


create table Patient_Phone_number
(
	Pa_Phone nvarchar(10),
	Pa_Id int,
	constraint Patient_Phone_number_PK primary key (Pa_Phone,Pa_Id),
	constraint Patient_Phone_number_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID) 
)

create table Previews
(
	Pre_Id int identity(1,1),
	Previews_Date smalldatetime,
	DO_Id int ,
	Pa_ID int ,
	constraint Previews_PK primary key (Pre_Id),
	constraint Previews_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID),
	constraint Previews_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),

	
)

create table Bills
(
	Bill_Id int,
	Examinations money,
	Surgeries money,
	Room_Service money,
	Medical_tests money,
	Rays money,
	constraint Bills_PK primary key (Bill_Id),
)

create table Payments
(
	Pa_Id int,
	Bill_Id int,
	constraint Payments_PK primary key (Pa_Id,Bill_Id),
	constraint Payments_Bill_ID_FK foreign key (Bill_Id) references  Bills(Bill_Id),
	constraint Payments_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)



create table Medical_Details
(
Pa_Id int,
Pa_Name nvarchar(50),
Examenation_Records nvarchar(max),
Blood_type nvarchar(5),
Treatment_plans_Daily_supplements nvarchar(max),
Allergies nvarchar(max),
Family_Health_History nvarchar(max),
Special_Needs nvarchar(max),
Chronic_diseases nvarchar(max),
External_Records nvarchar(max),
constraint Medical_Details_PK primary key (Pa_Id,Pa_Name),
constraint Medical_Details_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)

create table Medical_tests
(
	Test_Id int,
	Pa_Id int,
	Test_Type nvarchar(50),
	Test_Result nvarchar(50),
	constraint Medical_tests_PK primary key (Test_Id),
	constraint Medical_tests_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)

create table Rays
(
	Rays_Id int,
	Pa_Id int,
	Rays_Type nvarchar(50),
	Rays_Result nvarchar(50),
	constraint Rays_PK primary key (Rays_Id),
	constraint Rays_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)


create table Department
(
Dept_ID int,
Dept_name nvarchar(50),
Ho_SerialNumber int ,
Mgr_Id int,
constraint Department_PK primary key (Dept_ID),
constraint Department_HO_SerialNumber_FK foreign key (Ho_SerialNumber) references  hospital(SerialNumber),
constraint Department_Mgr_Id_FK FOREIGN KEY (Mgr_Id) REFERENCES Doctor(Do_Id)
)

create table Employee
(
Emp_Id int,
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
Qualificationsþ nvarchar(max),
social_status nvarchar(50),
Family_member  int,
Dept_Id int,
constraint Employee_PK primary key (Emp_Id),
constraint Employee_Dept_ID_FK foreign key (Dept_Id) references  Department(Dept_ID),
)

create table Emp_Phone_number
(
	Emp_Phone nvarchar(10),
	Emp_Id int,
	constraint Emp_Phone_number_PK primary key (Emp_Phone,Emp_Id),
	constraint Emp_Phone_number_Emp_ID_FK foreign key (Emp_Id) references  Employee(Emp_Id) 
)

create table Room
(
Room_ID int,
Room_type nvarchar(20),
Empity_or_not bit ,
constraint Room_Room_Id_PK primary key (Room_Id),
)

create table Room_Reservation
(
--الكيان الضعيف هل يأخذ مفتاح أساسي؟؟
	Pa_Id int ,
	Room_Id int,
	Reservation_Date smalldatetime,
	Reservation_EndDate smalldatetime,

	constraint Room_Reservation_PK primary key (Room_Id,Pa_Id),
	constraint Room_Reservation_Pa_Id_FK foreign key (Pa_Id) references  Patient(Pa_ID),
	constraint Room_Reservation_Room_Id_FK foreign key (Room_Id) references  Room(Room_ID),

)
create table Surgery_Room
(

Surgery_Room_ID int, 
Ready_or_not bit,
HO_Serial_number int,
constraint Surgery_Room_PK primary key (Surgery_Room_ID),
constraint Surgery_Room_HO_SerialNumber_FK foreign key (HO_Serial_number) references  hospital(SerialNumber)
)

create table Surgery
(
	Surgery_number int,
	Surgery_name nvarchar(50),
	Surgery_date smalldatetime,
	Surgery_Room_ID int,
	Pa_ID int,
	Do_ID int,
	constraint Surgery_PK primary key (Surgery_number),
	constraint Surgery_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID),
	constraint Surgery_Dept_Id_FK foreign key (Pa_Id) references  Patient(Pa_ID),
	constraint Surgery_Surgery_Room_ID_FK foreign key (Surgery_Room_ID) references  Surgery_Room(Surgery_Room_ID),
)

create table Death_Cases
(
Pa_Id int unique,
Death_date date,
Cause_death nvarchar(1000),
constraint Death_Cases_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)

create table [Admin]
(
	Email nvarchar(50),
	Password nvarchar(50)
)
