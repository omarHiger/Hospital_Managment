--email= fullName		password= nationalNumber

create table hospital(
	Ho_Id int identity(111111,1),
	Serial_Number nvarchar(100) not null,
	Ho_Name nvarchar(50) not null,
	City nvarchar(50) not null,
	Street nvarchar(50) not null,
	Area nvarchar(50) not null,
	Mgr_Id int unique not null,
	Subscibtion_Date date not null,

	constraint HO_Serial_Number_PK primary key (Ho_Id),
	constraint hospital_Mgr_Id_FK FOREIGN KEY (Mgr_Id) REFERENCES Doctor(Do_Id) --get error when try delete it 
)

create table HO_Phone(
	HO_Phone nvarchar(10),
	Ho_Id int,

	constraint HO_Phone_PK primary key (Ho_Id,HO_Phone),
<<<<<<< HEAD
	constraint Ho_Phone_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id) on delete cascade --set on delete action
=======
	constraint Ho_Phone_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id) on delete cascade
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)
create table Doctor(
	Do_ID int identity(111111,1), 
	First_Name nvarchar(30) not null,
	Middle_Name nvarchar(30) not null,
	Last_Name  nvarchar(30) not null,
	Email nvarchar(100) not null,
	[Password] nvarchar(25) not null constraint check_Doctor_Password check([Password]>7),
	Gender nvarchar(6) default('Male'),
	National_number nvarchar(25) not null, --removed "unique" -Huda
	City nvarchar(50),
	Street nvarchar(50),
	Area nvarchar(50),
	social_status nvarchar(10) default('single'),
	Family_member  int default(0) constraint Doctor_Family_Check check(Family_member between 0 and 25)  ,
	Specialization nvarchar(60) not null,
	Qualifications nvarchar(max), 
	Birth_Place nvarchar(100),
<<<<<<< HEAD
	Birth_Date date,
	Dept_Id int,
=======
	Dept_Id int  null,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65


	constraint DO_ID_PK primary key (Do_ID),
	constraint Doctor_Dept_Id_FK FOREIGN KEY (Dept_Id) REFERENCES Department(Dept_ID) on delete set null
<<<<<<< HEAD
)

create table Work_Days(
	Do_ID int,
	[Day] date,
	start_Hour time not null,
	End_Hour time not null,

	constraint Work_Days_PK primary key (Do_ID,[Day]),
	constraint Work_Days_Do_ID_FK FOREIGN KEY (Do_ID) REFERENCES Doctor(Do_ID) on delete cascade,
=======
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table Doctor_Phone_number(
	Do_Phone nvarchar(10),
	Do_Id int,

	constraint Doctor_Phone_number_PK primary key (Do_Phone,Do_Id),
	constraint Doctor_Phone_number_DO_ID_FK foreign key (DO_Id) references  Doctor(Do_ID)on delete cascade
)

create table Patient(
	Pa_ID int identity(111111,1), --Added "identity" -Huda
	First_Name nvarchar(30) not null, 
	Middle_Name nvarchar(30)not null,
	Last_Name  nvarchar(30)not null,
	City nvarchar(50) not null,
	Street nvarchar(50) not null,
	Area nvarchar(50) not null,
	X_Y nvarchar(61) not null,
	Gender nvarchar(6) default('Male'),
	Birth_Date date not null,
	Birth_Place nvarchar(100) not null,
	social_status nvarchar(10) default('single'),
	Email nvarchar(100) not null,
	[Password] nvarchar(25) constraint check_Patient_Password check([Password]>7) not null ,
	National_number nvarchar(25),
	Ho_Id int not null,

	constraint Pa_ID_PK primary key (Pa_ID),
<<<<<<< HEAD
	constraint Patient_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id) on delete cascade,
=======
	constraint Patient_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id) on delete cascade
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table Patient_Phone_number(
	Pa_Phone nvarchar(10),
	Pa_Id int,

	constraint Patient_Phone_number_PK primary key (Pa_Phone,Pa_Id),
<<<<<<< HEAD
	constraint Patient_Phone_number_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID) on delete cascade,
=======
	constraint Patient_Phone_number_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID) on delete cascade
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table Caring(
	Do_Id int,
	Pa_Id int,

	constraint Caring_PK primary key (Pa_Id,Do_Id),
<<<<<<< HEAD
	constraint Caring_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID) on delete cascade,
=======
	constraint Caring_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID) on delete cascade, 
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
	constraint Caring_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID) on delete cascade,
)

create table Preview(
	Pre_Id int, 
	Previews_Date smalldatetime not null,
	DO_Id int,
<<<<<<< HEAD
	Do_Name nvarchar(90) not null,
=======
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
	Pa_ID int not null,
	Do_name nvarchar(90),

	constraint Previews_PK primary key (Pre_Id),
	constraint Previews_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID) on delete set null,
	constraint Previews_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID) on delete cascade,
)

create table Bill(
	Bill_Id int,
	Examinations decimal,
	Surgeries decimal,
	Room_Service decimal,
	Medical_tests decimal,
	Rays decimal,
	Pa_Id int not null,

	constraint Bill_PK primary key (Bill_Id),
<<<<<<< HEAD
	constraint Bill_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_Id) on delete cascade,
=======
	constraint Bill_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_Id)on delete cascade,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table Medical_Detail(
	Pa_Id int,
	Pa_Name nvarchar(90),
	Examenation_Records nvarchar(max),
	Blood_type nvarchar(3),
	Treatment_plans_Daily_supplements nvarchar(max),
	Allergies nvarchar(max),
	Family_Health_History nvarchar(max),
	Special_Needs nvarchar(max),
	Chronic_diseases nvarchar(max),
	External_Records nvarchar(max),

	constraint Medical_Detail_PK primary key (Pa_Id,Pa_Name),
<<<<<<< HEAD
	constraint Medical_Detail_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID) on delete cascade,
=======
	constraint Medical_Detail_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID)on delete cascade,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table Medical_tests(
	Test_Id int,
	Pa_Id int not null,
	Test_Type nvarchar(60) not null,
	Test_Result image not null,
	Test_Date date not null,

	constraint Medical_tests_PK primary key (Test_Id),
	constraint Medical_tests_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID) on delete cascade,
)

create table Ray(
	Ray_Id int,
	Pa_Id int not null,
	Ray_Type nvarchar(60)not null,
	Ray_Result image not null,
	Ray_Date date not null
	constraint Ray_PK primary key (Ray_Id),
<<<<<<< HEAD
	constraint Ray_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID) on delete cascade,
=======
	constraint Ray_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID)on delete cascade,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table Department(
	Dept_ID int identity(111111,1),
	Dept_name nvarchar(50) not null,
	Dept_Type nvarchar(50)not null,
	Ho_Id int not null,
	Dept_Mgr_Id int,

	constraint Department_PK primary key (Dept_ID),
<<<<<<< HEAD
	constraint Department_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id) on delete cascade,
	constraint Department_Mgr_Id_FK FOREIGN KEY (Dept_Mgr_Id) REFERENCES Doctor(Do_Id)on delete set null,
=======
	constraint Department_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id)on delete cascade,
	constraint Department_Mgr_Id_FK FOREIGN KEY (Dept_Mgr_Id) REFERENCES Doctor(Do_Id) on delete set null,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table Employee(
	Emp_Id int identity(111111,1),
	First_Name nvarchar(30) not null,
	Middle_Name nvarchar(30) not null,
	Last_Name  nvarchar(30)not null,
	City nvarchar(50)not null,
	Street nvarchar(50) not null,
	Area nvarchar(50) not null,
	X_Y nvarchar(61) not null,
	Gender nvarchar(6) default('Male'),
	Date_of_hiring date not null, --default sysdate
	Birth_Date date ,
	Birth_Place nvarchar(100),
	National_number nvarchar(25) not null,
	Email nvarchar(100) not null,
	[Password] nvarchar(25)constraint check_Employee_Password check([Password]>7) not null,
	job nvarchar(30) not null,
	Qualifications nvarchar(max),
	social_status nvarchar(20) default('Single'),
	Family_member int default(0),
	Ho_Id int not null,

	constraint Employee_PK primary key (Emp_Id),
	constraint Employee_Dept_ID_FK foreign key (Ho_Id) references  Hospital(Ho_Id) on delete cascade,
)

create table Emp_Phone_number(
	Emp_Phone nvarchar(10),
	Emp_Id int,

	constraint Emp_Phone_number_PK primary key (Emp_Phone,Emp_Id),
<<<<<<< HEAD
	constraint Emp_Phone_number_Emp_ID_FK foreign key (Emp_Id) references  Employee(Emp_Id) on delete cascade
=======
	constraint Emp_Phone_number_Emp_ID_FK foreign key (Emp_Id) references  Employee(Emp_Id) on delete cascade,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table Room(
	Room_ID int,
<<<<<<< HEAD
	Room_Number nvarchar(20) not null,
	[Floor] int not null,
	Beds_Count int not null constraint Room_Type_check check(Beds_Count between 0 and 10),
	Empity bit default(1),
	Ho_Id int not null,

	constraint Room_Room_Id_PK primary key (Room_Id),
	constraint Room_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id) on delete cascade,
=======
	Room_Number nvarchar(20) not null	,
	Room_type int not null constraint Room_Type_check check(Room_Type between 0 and 10),
	[floor] int not null,
	Empity bit default(1) ,
	Ho_Id int,

	constraint Room_Room_Id_PK primary key (Room_Id),
	constraint Room_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id)on delete cascade,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)
create table Room_Reservation(
	Res_id int,
	Pa_Id int not null,
<<<<<<< HEAD
	Room_Id int,
	Room_Number nvarchar(20) not null,
=======
	Room_Id int not null,
	Room_Number nvarchar(20),
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
	Reservation_SDate smalldatetime not null,
	Reservation_EDate smalldatetime,

	constraint Room_Reservation_PK primary key (Res_id),
	constraint Room_Reservation_Pa_Id_FK foreign key (Pa_Id) references  Patient(Pa_ID) on delete cascade,
<<<<<<< HEAD
	constraint Room_Reservation_Room_Id_FK foreign key (Room_Id) references  Room(Room_ID) on delete no action,
=======
	constraint Room_Reservation_Room_Id_FK foreign key (Room_Id) references  Room(Room_ID) on delete set null,

>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)
create table Surgery_Room(
	Surgery_Room_ID int,
	Surgery_Room_Number nvarchar(20) not null,
	Surgery_Room_Floor int not null,
	Ready bit,
	Surgery_Room_Number nvarchar(20) not null,
	Surgery_Room_Floor int not null,
	Ho_Id int not null,

	constraint Surgery_Room_PK primary key (Surgery_Room_ID),
<<<<<<< HEAD
	constraint Surgery_Room_HO_Serial_Number_FK foreign key (Ho_Id) references hospital(Ho_Id) on delete cascade, 
=======
	constraint Surgery_Room_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id) on delete cascade,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table Surgery(
	Surgery_number int,
	Surgery_name nvarchar(50) not null,
	Surgery_date smalldatetime not null,
<<<<<<< HEAD
=======
	Do_name nvarchar(90),
	Surgery_Room_ID int ,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
	Surgery_Time int not null,
	Surgery_Room_Number nvarchar(20) not null,
	Do_Name nvarchar(90) not null,
	Pa_ID int not null,
	Do_ID int,
	Surgery_Room_ID int,

	constraint Surgery_PK primary key (Surgery_number),
	constraint Surgery_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID) on delete set null,
	constraint Surgery_Pa_Id_FK foreign key (Pa_Id) references  Patient(Pa_ID) on delete cascade,
<<<<<<< HEAD
	constraint Surgery_Surgery_Room_ID_FK foreign key (Surgery_Room_ID) references  Surgery_Room(Surgery_Room_ID) on delete no action,
=======
	constraint Surgery_Surgery_Room_ID_FK foreign key (Surgery_Room_ID) references  Surgery_Room(Surgery_Room_ID) on delete set null,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table Death_Cases(
	Death_Num int,
	Death_date date not null ,
	Cause_death nvarchar(max) not null,
	Pa_Id int unique not null,

	constraint Deat_Cases_DeathNum_PK primary key(Death_Num), 
<<<<<<< HEAD
	constraint Death_Cases_Pa_ID_FK foreign key (Pa_Id) references Patient(Pa_ID) on delete cascade,
=======
	constraint Death_Cases_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID) on delete cascade,
>>>>>>> 3b7278984cece1884b613ca7a19fcbc2897fca65
)

create table [Admin](
	Email nvarchar(50) not null,
	[Password] nvarchar(50) not null,
)
