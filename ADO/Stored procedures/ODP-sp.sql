--create table
create table tblEmployees(
EmployeeId int primary key,
Name nvarchar2(50),
Gender nvarchar2(10),
Salary int);

create sequence emp_seq
start with 1
increment by 1;

INSERT INTO tblEmployees values(emp_seq.NEXTVAL,'Mason','Male',5000);
INSERT INTO tblEmployees values(emp_seq.NEXTVAL,'Priyanka','Female',3500);
INSERT INTO tblEmployees values(emp_seq.NEXTVAL,'John','Male',2350);
INSERT INTO tblEmployees values(emp_seq.NEXTVAL,'Louna','Female',5700);
INSERT INTO tblEmployees values(emp_seq.NEXTVAL,'Jackson','Male',4890);
INSERT INTO tblEmployees values(emp_seq.NEXTVAL,'Aulia','Female',4500);

--Get sp
create or replace procedure spEMPLOYEE_GET
(pEMP_NAME in tblemployees.name%type,
pEMP_GENDER in tblemployees.gender%type,
pEMP_SALARY in tblemployees.salary%type,
rs out sys_refcursor)
as
begin
    open rs for select EmployeeId EmployeeID, Name, Gender, Salary
                from tblemployees
                where (pEMP_NAME is null or Name like '%' || pEMP_NAME || '%') and (pEMP_GENDER is null or Gender=pEMP_GENDER) and (pEMP_SALARY is null or Salary=pEMP_SALARY)
                order by EmployeeId;
end;


--Insert sp
create or replace procedure spEMPLOYEE_i
(pEMP_NAME in tblemployees.name%type,
pEMP_GENDER in tblemployees.gender%type,
pEMP_SALARY in tblemployees.salary%type,
preturncode out number,
preturnmess out varchar2)
as
begin
    insert into tblemployees(EmployeeId,Name,Gender,Salary) values(emp_seq.NEXTVAL,pEMP_NAME,pEMP_GENDER,pEMP_SALARY);
    preturncode:=1;
    preturnmess:='Succeeded';
    
    exception when others then
    rollback;
    preturncode:=0;
    preturnmess:= sqlcode || ' : ' || sqlerrm;
end;
select * from tblemployees;

--Delete sp
create or replace procedure spEMPLOYEE_d
(pEMP_ID in tblemployees.employeeid%type,
preturncode out number,
preturnmess out varchar2)
as
begin
    delete tblemployees where EmployeeID = pEMP_ID;
    preturncode := sql%rowcount;
    preturnmess := 'Succeeded';
    
    exception when others then
    rollback;
    preturncode :=-1;
    preturnmess:= sqlcode || ' : ' || sqlerrm;
end;

--Update sp
create or replace procedure spEMPLOYEE_u
(pEMP_ID in tblemployees.employeeid%type,
pEMP_NAME in tblemployees.name%type,
pEMP_GENDER in tblemployees.gender%type,
pEMP_SALARY in tblemployees.salary%type,
preturncode out number,
preturnmess out varchar2)
as
begin
    update tblemployees set name = pEMP_NAME, gender = pEMP_GENDER, salary = pEMP_SALARY where employeeid = pEMP_ID;
    commit;
    preturncode := sql%rowcount;
    preturnmess := 'Update succeeded';
    
    exception
    when others then
    rollback;
    preturncode := -1;
    preturnmess := sqlcode || ' : ' || sqlerrm;
end;