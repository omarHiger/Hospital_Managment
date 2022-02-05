--CONVERT(nvarchar,'12/10/2018',103)

--insert into hospitals (Serial_Number,Ho_Name,City,Street,Area,Mgr_Id,Subscibtion_Date)
--values ('omarIsKing','Alshami','damas','mas','wer',11111111,GETDATE())


--insert into Doctors(Doctor_First_Name,Doctor_Middle_Name,Doctor_Last_Name,
--Doctor_Email,Doctor_Password,Doctor_Gender,
--Doctor_National_number,Doctor_City,Doctor_Street,Doctor_Area,Doctor_social_status,
--Doctor_Family_member,Doctor_Specialization,Doctor_Hire_Date
--Qualifications,Birth_Place,Birth_Date,Dept_Id) values
--('mahmood','bahaa','arksusy','albi@gmail.com','werwer','male','123124',
--'daheea','dsf','sdfs','single',0,'sfsdf',GETDATE(),'dsfwqerq','syria',GETDATE(),11111111)




--insert into Patients(Patient_First_Name,Patient_Middle_Name ,Patient_Last_Name,
--Patient_Email,Patient_Password,Patient_Area,Patient_Street,Patient_City,
--Patient_X_Y,Patient_National_Number,Patient_Gender,Patient_Social_Status,
--Patient_Birth_Date,Patient_Birth_Place,Ho_Id) 
--values('sewr','wer','qwe','pateint','pa1234','dams','qwe','weq','124,43',
--'12412','female','married',GETDATE(),'wert',11213)




--insert into Employees(Employee_First_Name,Employee_Middle_Name,Employee_Last_Name,
--Employee_Email,Employee_Password,Employee_National_Number,Employee_Gender,
--Employee_Area,Employee_Street,Employee_City,Employee_X_Y,
--Employee_Family_Members,Employee_Job,Employee_Qualifications,Employee_Social_Status,
--Employee_Birth_Date,Employee_Birth_Place,Employee_Hire_Date)
--values('amjad','jalal','aldeen','amjadjalal','amjad1234','2198404','male',
-- 'da','wqe','asq','123,23',0,'it','ajdab','married',GETDATE(),'syria',GETDATE())


--insert into Rooms(Room_Number,Room_floor,Room_Empty,Room_Type)
--values('w3','2',1,4)


--insert into Reservations(Patient_Id,Room_Id,[Start_Date],Room_Number)
--values(11111111,11111111,GETDATE(),'w3')


--insert into Medical_Details(Patient_Id,MD_Patient_Name,MD_Patient_Blood_Type,
--MD_Patient_Treatment_Plans_And_Daily_Supplements,MD_Patient_Chronic_diseases,
--MD_Patient_Examination_Records,MD_Patient_Special_Needs,
--MD_Patient_Family_Health_History,MD_Patient_Allergies,MD_Patient_External_Records)
--values(11111111,'wsr','a+','qew','qwe','asfx','qweas','cxzcxz','hkh','ikpoj')


--insert into Departments(Department_Name,Department_Type,Dept_Mgr_Id,Ho_Id)
--values('ds','wer',11111111,11111111)


--insert into Surgery_Rooms(Surgery_Room_Number,Surgery_Room_Floor,Surgery_Room_Ready,Ho_Id)
--values('w2',3,1,11111111)




--insert into Surgeries(Surgery_Name,Surgery_Date,Surgery_Time,Surgery_Room_Id,
--Doctor_Id,Patient_Id)
--values('dfsf',GETDATE(),4,11111111,11111111,11111111)




--insert into Previews(Preview_Date,Patient_Id,Doctor_Id)
--values(GETDATE(),11111111,11111111)


-- √ﬂœ „‰ «”„ Â«œ «·ÃœÊ·
--insert into Caring(Do_Id,Pa_Id) values(11111111,11111111)