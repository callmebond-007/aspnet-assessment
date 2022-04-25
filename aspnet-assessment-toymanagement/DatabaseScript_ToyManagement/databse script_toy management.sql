Create database ToyDB
go

use ToyDB
go

Create table Toy(
ToyId int not null primary key identity(100,1),
ToyName varchar(50),
ToyCategory varchar(50),
ToyDescription varchar(50),
ToyAmount int);
go

insert into Toy values
('Ducatti','Cars','Remote Control',5100)
go

 create procedure sp_AddToy
 @name varchar(50),
 @category varchar(50),
 @description varchar(50),
 @amount int
 As
 Begin
 insert into Toy values(@name,@category,@description,@amount)
 End
 go

 Create table ToyCategory(
 Id int not null primary key Identity(1,1),
 ToyCategory varchar(50)
 )
go

 insert into ToyCategory values
 ('Cars'),
 ('Boards'),
 ('Bicycle'),
 ('Archery'),
 ('Soft Toys')
 go

 create procedure sp_AllToyCategory
 As
 Begin
 Select Id,ToyCategory from ToyCategory
 End
 go

 exec sp_AllToyCategory
 go

 Create procedure sp_ViewAllToy
 As
 Begin
 select ToyId,ToyName,ToyCategory,ToyDescription,ToyAmount from Toy
 End
 go

 exec sp_ViewAllToy
 go

 create procedure spIsToyExist
 @name varchar(50)
 As
 Begin
 select Count(1) from Toy where ToyName=@name
 End
 go

 exec spIsToyExist 'Ducatti'
 go

 create procedure sp_DeleteToy
 @id int
 as
 begin
 delete from Toy where ToyId=@id
 end