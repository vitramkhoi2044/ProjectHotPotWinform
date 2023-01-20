Create Database HotpotDB
Go

Use HotpotDB
Go

--Create table
CREATE TABLE Dishes (
    DishID int Primary Key NOT NULL Identity, 
	DishName nvarchar(255), 
	DishPrice int,
	Image image,
	CategoryID int NOT NULL,
);
Go

CREATE TABLE DishCategories(
    CategoryID int Primary Key NOT NULL Identity, 
	CategoryName nvarchar(255), 
);
Go

CREATE TABLE Tables(
    TableID int Primary Key NOT NULL Identity, 
	TableName nvarchar(255),
	TableStatus bit,
);
Go

CREATE TABLE Employees(
    EmployeeID int Primary Key NOT NULL Identity, 
	EmployeeName nvarchar(255),
	Shift nvarchar(255),
	EmployeeStatus nvarchar(255),
	Position nvarchar(255),
	Username nvarchar(255) NOT NULL UNIQUE,
	Password nvarchar(255) NOT NULL,
);
Go

CREATE TABLE Orders(
    OrderID int Primary Key NOT NULL Identity , 
	CustomerID int NOT NULL,
	TotalPrice int,
	TotalQuantity int,
	CreateDate date,
	EmployeeID int NOT NULL,
	TableID int NOT NULL, 
	OrderStatus bit,
);
Go

CREATE TABLE OrderDishes(
    ID int Primary Key NOT NULL Identity , 
	OrderID int NOT NULL,
	DishID int NOT NULL,
	DishQuantity int,
);
Go

CREATE TABLE Customers(
    CustomerID int Primary Key NOT NULL Identity , 
	CustomerName nvarchar(255),
	Score int,
);
Go

CREATE TABLE Ingredients(
    IngredientID int Primary Key NOT NULL Identity , 
	IngredientName nvarchar(255),
	IngredientPrice int,
	ImportDate date,
	ExpireDate date,
	IngredientQuantity int,
);
Go

--Foreign Key
ALTER TABLE Dishes ADD CONSTRAINT fk_Dishes_CategoryID FOREIGN KEY (CategoryID) REFERENCES DishCategories(CategoryID);
Go

ALTER TABLE Orders ADD CONSTRAINT fk_Orders_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID);
Go

ALTER TABLE Orders ADD CONSTRAINT fk_Orders_EmployeeID FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID);
Go

ALTER TABLE Orders ADD CONSTRAINT fk_Orders_TableID FOREIGN KEY (TableID) REFERENCES Tables(TableID);
Go

ALTER TABLE OrderDishes ADD CONSTRAINT fk_OrderDishes_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID);
Go

ALTER TABLE OrderDishes ADD CONSTRAINT fk_OrderDishes_DishID FOREIGN KEY (DishID) REFERENCES Dishes(DishID);
Go

----Drop Foreign Key
--ALTER TABLE Dishes DROP CONSTRAINT fk_Dishes_CategoryID;
--Go

--ALTER TABLE Orders DROP CONSTRAINT fk_Orders_CustomerID;
--Go

--ALTER TABLE Orders DROP CONSTRAINT fk_Orders_EmployeeID;
--Go

--ALTER TABLE Orders DROP CONSTRAINT fk_Orders_TableID;
--Go

--ALTER TABLE OrderDishes DROP CONSTRAINT fk_OrderDishes_OrderID;
--Go

--ALTER TABLE OrderDishes DROP CONSTRAINT fk_OrderDishes_DishID;
--Go


----Drop Table
--Drop table Customers
--Go

--Drop table DishCategories
--Go

--Drop table Dishes
--Go

--Drop table Employees
--Go

--Drop table Ingredients
--Go

--Drop table OrderDishes
--Go

--Drop table Orders
--Go

--Drop table Tables
--Go

----Drop Database
--Use master
--Go
--Drop Database HotpotDB
--Go

--Insert Data Employees
Insert Into Employees(EmployeeName,EmployeeStatus,Position,Shift,Username,Password) Values(N'Cao Trương Trí Luận', 'Active', 'CEO', 'Fulltime', 'luancao', 'pFwYo/QhAvc=');
Go
Insert Into Employees(EmployeeName,EmployeeStatus,Position,Shift,Username,Password) Values(N'Trầm Khôi Vĩ', 'Active', 'Manager', 'Fulltime', 'khoivi', 'pFwYo/QhAvc=');
Go
Insert Into Employees(EmployeeName,EmployeeStatus,Position,Shift,Username,Password) Values(N'Lê Minh Hiển', 'Active', 'Staff', '14:20 - 23h00', 'minhhien', 'pFwYo/QhAvc=');
Go

--Insert Data Customers
Insert Into Customers(CustomerName,Score) Values(N'Trí Luận',10);
Go
Insert Into Customers(CustomerName,Score) Values(N'Khôi Vĩ',10);
Go
Insert Into Customers(CustomerName,Score) Values(N'Nhật Quang',20);
Go

--Insert Data Ingredients
Insert Into Ingredients(IngredientName,IngredientPrice,ImportDate,ExpireDate,IngredientQuantity) Values(N'Tôm',250000,'2022-12-05','2022-12-10',5)
Go
Insert Into Ingredients(IngredientName,IngredientPrice,ImportDate,ExpireDate,IngredientQuantity) Values(N'Thit bò',150000,'2022-12-06','2022-12-22',20)
Go
Insert Into Ingredients(IngredientName,IngredientPrice,ImportDate,ExpireDate,IngredientQuantity) Values(N'Tiger',15000,'2022-02-09','2022-11-16',5)
Go

--Insert Data Tables
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 1',1)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 2',1)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 3',1)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 4',1)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 5',1)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 6',0)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 7',1)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 8',1)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 9',0)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 10',0)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 11',0)
Go
Insert Into Tables(TableName,TableStatus) Values(N'Bàn 12',0)
Go


--Insert Data DishCategories
INSERT INTO DishCategories(CategoryName) VALUES (N'Loại thịt')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Hải sản')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Loại viên')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Các loại rau, củ và nấm')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Loại lẩu')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Món ăn vặt')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Món ăn đặc sắc')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Món ăn kinh điển')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Món ăn loại đậu')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Đồ uống có cồn')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Đồ uống')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Cơm')
Go
INSERT INTO DishCategories(CategoryName) VALUES (N'Món ăn tinh bột')
Go

----Insert Data Dishes
--INSERT INTO Dishes(DishName,DishPrice,CategoryID) VALUES(N'Ba Chỉ Bò',160000,1)
--Go
--INSERT INTO Dishes(DishName,DishPrice,CategoryID) VALUES(N'Tôm',200000,2)
--Go
--INSERT INTO Dishes(DishName,DishPrice,CategoryID) VALUES(N'Combo rau',50000,4)
--Go
--INSERT INTO Dishes(DishName,DishPrice,CategoryID) VALUES(N'Chả cá thác lác',100000,2)
--Go
--INSERT INTO Dishes(DishName,DishPrice,CategoryID) VALUES(N'Tiger',15000,10)
--Go
--INSERT INTO Dishes(DishName,DishPrice,CategoryID) VALUES(N'Nước Lavie',10000,11)
--Go