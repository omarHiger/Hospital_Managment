--email= fullName		password= nationalNumber
create table hospital(
	Ho_Id int identity(111111,1),
	Serial_Number nvarchar(100) not null,  -- added not null" -Huda
	Ho_Name nvarchar(50) not null,
	City nvarchar(50) not null,
	Street nvarchar(50) not null,
	Area nvarchar(50) not null,
	Mgr_Id int not null unique,
	Subscibtion_Date date not null,

	constraint HO_Serial_Number_PK primary key (Ho_Id),
	constraint hospital_Mgr_Id_FK FOREIGN KEY (Mgr_Id) REFERENCES Doctor(Do_Id)
)
create table HO_Phone(
	HO_Phone nvarchar(10),
	Ho_Id int ,

	constraint HO_Phone_PK primary key (Ho_Id,HO_Phone),
	constraint Ho_Phone_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id)
)
create table Doctor(
	Do_ID int identity(111111,1), --Added "identity" -Huda
	First_Name nvarchar(30) not null,
	Middle_Name nvarchar(30) not null,
	Last_Name  nvarchar(30) not null,
	Email nvarchar(100) not null,
	[Password] nvarchar(25) not null constraint check_Doctor_Password check([Password]>7),
	Gender nvarchar(6) , --removed "default('single')" and added it in "social_status" instead -Huda
	Date_of_hiring date not null,
	Birth_Date date not null,
	National_number nvarchar(25) not null, --removed "unique" -Huda
	City nvarchar(50),
	Street nvarchar(50),
	Area nvarchar(50),
	social_status nvarchar(10) default('single'), --added "default('single')" -Huda
	Family_mamber  int ,
	Specialization nvarchar(50) not null,
	Qualifications nvarchar(max),  
	--Career nvarchar(255),
	Birth_Place nvarchar(100),
	Dept_Id int not null,


	constraint DO_ID_PK primary key (Do_ID),
	constraint Doctor_Dept_Id_FK FOREIGN KEY (Dept_Id) REFERENCES Department(Dept_ID)
)

create table Doctor_Phone_number(
	Do_Phone nvarchar(10),
	Do_Id int,

	constraint Doctor_Phone_number_PK primary key (Do_Phone,Do_Id),
	constraint Doctor_Phone_number_DO_ID_FK foreign key (DO_Id) references  Doctor(Do_ID)
)

create table Patient(
	Pa_ID int identity(111111,1), --Added "identity" -Huda
	First_Name nvarchar(30) not null, 
	Middle_Name nvarchar(30)not null,
	Last_Name  nvarchar(30)not null,
	City nvarchar(50) not null,
	Street nvarchar(50) not null,
	Area nvarchar(50) not null,
	X_Y decimal(38,20), --"decimal(40,20)" ---->> "decimal(38,20)" -Huda
	Gender nvarchar(6),
	Birth_Date date not null,
	Birth_Place nvarchar(100),
	social_status nvarchar(10) default('single'),
	Career nvarchar(50),
	Email nvarchar(100) not null,
	[Password] nvarchar(25) constraint check_Patient_Password check([Password]>7) not null ,
	National_number nvarchar(25) not null unique ,
	Ho_Id int,

	constraint Pa_ID_PK primary key (Pa_ID),
	constraint Patient_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id)
)

create table Caring(
	Do_Id int,
	Pa_Id int,

	constraint Caring_PK primary key (Pa_Id,Do_Id),
	constraint Caring_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID),
	constraint Caring_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)


create table Patient_Phone_number(
	Pa_Phone nvarchar(10),
	Pa_Id int,

	constraint Patient_Phone_number_PK primary key (Pa_Phone,Pa_Id),
	constraint Patient_Phone_number_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID) 
)

create table Preview(
	Pre_Id int identity(1,1), --Added "identity" -Huda
	Previews_Date smalldatetime,
	DO_Id int,
	Pa_ID int,

	constraint Previews_PK primary key (Pre_Id),
	constraint Previews_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID),
	constraint Previews_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)

create table Bill(
	Bill_Id int identity(1,1), --Added "identity" -Huda
	Pa_Id int,
	Examinations decimal,
	Surgeries decimal,
	Room_Service decimal,
	Medical_tests decimal,
	Rays decimal,

	constraint Bill_PK primary key (Bill_Id),
	constraint Bill_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_Id),
)

create table Medical_Detail(
	Pa_Id int,
	Pa_Name nvarchar(50),
	Examenation_Records nvarchar(max),
	Blood_type nvarchar(3),
	Treatment_plans_Daily_supplements nvarchar(max),
	Allergies nvarchar(max),
	Family_Health_History nvarchar(max),
	Special_Needs nvarchar(max),
	Chronic_diseases nvarchar(max),
	External_Records nvarchar(max),

	constraint Medical_Detail_PK primary key (Pa_Id,Pa_Name),
	constraint Medical_Detail_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)

create table Medical_tests(
	Test_Id int identity(1,1), --Added "identity" -Huda
	Pa_Id int,
	Test_Type nvarchar(60) not null,
	Test_Result nvarchar(50) not null,
	Test_Date date not null,

	constraint Medical_tests_PK primary key (Test_Id),
	constraint Medical_tests_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)

create table Ray(
	Ray_Id int identity(1,1), --Added "identity" -Huda
	Pa_Id int,
	Ray_Type nvarchar(60)not null,
	Ray_Result nvarchar(50)not null,
	Ray_Date date not null
	constraint Ray_PK primary key (Ray_Id),
	constraint Ray_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)

create table Department(
	Dept_ID int identity(111111,1), --Added "identity" -Huda
	Dept_name nvarchar(50) not null,
	Dept_Type nvarchar(50)not null,
	Ho_Id int ,
	Dept_Mgr_Id int,

	constraint Department_PK primary key (Dept_ID),
	constraint Department_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id),
	constraint Department_Mgr_Id_FK FOREIGN KEY (Dept_Mgr_Id) REFERENCES Doctor(Do_Id)
)

create table Employee(
	Emp_Id int identity(111111,1), --Added "identity" -Huda
	First_Name nvarchar(30) not null,
	Middle_Name nvarchar(30) not null,
	Last_Name  nvarchar(30)not null,
	City nvarchar(50)not null,
	Street nvarchar(50)not null,
	Area nvarchar(50)not null,
	Gender nvarchar(6),
	Date_of_hiring date,
	Birth_Date date ,
	Birth_Place nvarchar(100),
	National_number nvarchar(25) unique not null,
	Email nvarchar(100) not null,
	[Password] nvarchar(25)constraint check_Employee_Password check([Password]>7) not null,
	Emp_Type nvarchar(30),
	Qualificationsþ nvarchar(max),
	social_status nvarchar(20),
	Family_member  int default(0),
	--Career nvarchar(255),
	Ho_Id int,

	constraint Employee_PK primary key (Emp_Id),
	constraint Employee_Dept_ID_FK foreign key (Ho_Id) references  Hospital(Ho_Id),
)

create table Emp_Phone_number(
	Emp_Phone nvarchar(10),
	Emp_Id int,

	constraint Emp_Phone_number_PK primary key (Emp_Phone,Emp_Id),
	constraint Emp_Phone_number_Emp_ID_FK foreign key (Emp_Id) references  Employee(Emp_Id) 
)

create table Room(
	Room_ID int identity(1,1), --Added "identity" -Huda
	Room_type int not null,
	Empity bit default(1) ,
	Ho_Id int ,
	constraint Room_Room_Id_PK primary key (Room_Id),
	constraint Room_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id)
)
create table Room_Reservation(
	Res_id int identity(1,1), --Added "identity" -Huda
	Pa_Id int not null,
	Room_Id int not null,
	Reservation_SDate smalldatetime not null,
	Reservation_EDate smalldatetime,

	constraint Room_Reservation_PK primary key (Res_id),
	constraint Room_Reservation_Pa_Id_FK foreign key (Pa_Id) references  Patient(Pa_ID),
	constraint Room_Reservation_Room_Id_FK foreign key (Room_Id) references  Room(Room_ID),

)
create table Surgery_Room(
	Surgery_Room_ID int identity(1,1), --Added "identity" -Huda
	Ready bit,
	Ho_Id int,

	constraint Surgery_Room_PK primary key (Surgery_Room_ID),
	constraint Surgery_Room_HO_Serial_Number_FK foreign key (Ho_Id) references  hospital(Ho_Id)
)

create table Surgery(
	Surgery_number int identity(1,1), --Added "identity" -Huda
	Surgery_name nvarchar(50) not null,
	Surgery_date smalldatetime not null,
	Surgery_Room_ID int not null,
	Surgery_Time int not null,
	Pa_ID int not null,
	Do_ID int,

	constraint Surgery_PK primary key (Surgery_number),
	constraint Surgery_DO_ID_FK foreign key (DO_Id) references  doctor(Do_ID),
	constraint Surgery_Pa_Id_FK foreign key (Pa_Id) references  Patient(Pa_ID),
	constraint Surgery_Surgery_Room_ID_FK foreign key (Surgery_Room_ID) references  Surgery_Room(Surgery_Room_ID),
)

create table Death_Cases(
	Death_Num int identity(1,1),  --Added "identity" -Huda
	Pa_Id int unique not null,
	Death_date date not null ,
	Cause_death nvarchar(max) not null,
	constraint Deat_Cases_DeathNum_PK primary key(Death_Num), 
	constraint Death_Cases_Pa_ID_FK foreign key (Pa_Id) references  Patient(Pa_ID),
)

create table [Admin](
	Email nvarchar(50),
	[Password] nvarchar(50)
)
