--create table
CREATE TABLE tblEmployees
(EmployeeId int identity primary key,
Name nvarchar(50),
Gender nvarchar(10),
Salary int)

INSERT INTO tblEmployees values('Mason','Male',5000)
INSERT INTO tblEmployees values('Priyanka','Female',3500)
INSERT INTO tblEmployees values('John','Male',2350)
INSERT INTO tblEmployees values('Louna','Female',5700)
INSERT INTO tblEmployees values('Jackson','Male',4890)
INSERT INTO tblEmployees values('Aulia','Female',4500)

--Insert sp
create or alter procedure spEMPLOYEE_i
(@NAME nvarchar(50),
@GENDER nvarchar(10),
@SALARY int)
as
begin
	insert into tblEmployees values(@NAME,@GENDER,@SALARY);
end;

--Get sp
create or alter procedure spEMPLOYEE_get
(@NAME nvarchar(50),
@GENDER nvarchar(10),
@SALARY int)
as
begin
	select EmployeeId, Name, Gender, Salary
	from tblEmployees
	where (@NAME ='' or LOWER(Name) like '%'+LOWER(@NAME)+'%') and (@GENDER='' or Gender=@GENDER) and (@SALARY ='' or Salary=@SALARY);
end;