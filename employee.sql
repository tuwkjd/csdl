create database HR
go
use HR
create  table  Employee(
IdEmployee nvarchar(25),
Name nvarchar(30),
DateBirth datetime,
Gender bit,
PlaceBirth nvarchar(35),
IdDepartment nvarchar(30)
)
create  table  Department(
IdDepartment nvarchar(30),
Name nvarchar(30)
)

insert into  Employee values('C53418','Tran Tien', '11/10/2000', 1, 'Ha Noi', 'KT')
insert into  Employee values('X53416','Nguyen Cuong', '11/11/2001', 1, 'Dak Lak', 'KD')
insert into  Employee values('M53417','Nguyen Hao', '11/12/2002', 1, 'TP.HCM', 'NS')
insert into  Employee values('M53419','Nguyen Son', '11/12/2003', 0,'TP.HCM', 'NS')
insert into  Employee values('M53419','Nguyen Son', '11/12/2003', 0,'TP.HCM', 'NS')
select*from Employee
insert into  Department values('NS', 'Nhan su')
insert into  Department values('KT', 'Ke toan')
insert into  Department values('KD', 'Kinh doanh')
select*from Department
