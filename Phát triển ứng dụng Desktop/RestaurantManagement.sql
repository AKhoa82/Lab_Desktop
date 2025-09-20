create database RestaurantManagement
USE [RestaurantManagement]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[FullName] [nvarchar](1000) NOT NULL,
	[Email] [nvarchar](1000) NULL,
	[Tell] [nvarchar](200) NULL,
	[DateCreated] [smalldatetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDetails]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_BillDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[TableID] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Discount] [float] NULL,
	[Tax] [float] NULL,
	[Status] [bit] NOT NULL,
	[CheckoutDate] [smalldatetime] NULL,
	[Account] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Unit] [nvarchar](100) NOT NULL,
	[FoodCategoryID] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Notes] [nvarchar](3000) NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](1000) NOT NULL,
	[Path] [nvarchar](3000) NULL,
	[Notes] [nvarchar](3000) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAccount]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAccount](
	[RoleID] [int] NOT NULL,
	[AccountName] [nvarchar](100) NOT NULL,
	[Actived] [bit] NOT NULL,
	[Notes] [nvarchar](3000) NULL,
 CONSTRAINT [PK_RoleAccount] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NULL,
	[Status] [int] NOT NULL,
	[Capacity] [int] NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated]) VALUES (N'Anh Khoa', N'leko', N'Lê Anh Khoa', N'khoa@gmail.com', N'0545245521', CAST(N'2025-08-11T00:00:00' AS SmallDateTime))
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated]) VALUES (N'Diệu Linh', N'dlyn', N'Đỗ Đặng Diệu Linh', N'linh@gmail.com', N'0599865563', CAST(N'2025-08-11T00:00:00' AS SmallDateTime))
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated]) VALUES (N'Phương Trang', N'chuchoa', N'Trần Thị Phương Trang', N'trang@gmail.com', N'0424638538', CAST(N'2025-08-11T00:00:00' AS SmallDateTime))
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated]) VALUES (N'Thanh Hiền', N'octymus', N'Nguyễn Ngọc Thanh Hiền', N'hien@gmail.com', N'0521507312', CAST(N'2025-08-11T00:00:00' AS SmallDateTime))
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated]) VALUES (N'Trà My', N'moemo', N'Nguyễn Thị Trà My', N'my@gmail.com', N'0886553599', CAST(N'2025-08-11T00:00:00' AS SmallDateTime))
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated]) VALUES (N'Xuân Hiếu', N'chidung', N'Trần Xuân Hiếu', N'hieu@gmail.com', N'0848853589', CAST(N'2025-08-11T00:00:00' AS SmallDateTime))
GO
SET IDENTITY_INSERT [dbo].[BillDetails] ON 

INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (1, 1, 1, 2)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (2, 1, 4, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (3, 3, 2, 3)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (4, 3, 3, 2)
SET IDENTITY_INSERT [dbo].[BillDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Bills] ON 

INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (1, N'Hóa đơn 1', 1, 95000, 0, 5000, 1, CAST(N'2025-08-10T00:00:00' AS SmallDateTime), N'admin')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (3, N'Hóa đơn 2', 2, 20000, 0, 1000, 0, NULL, N'admin')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (4, N'Hóa đơn 3', 3, 60000, 5, 3000, 1, CAST(N'2025-08-09T00:00:00' AS SmallDateTime), N'nhanvien')
SET IDENTITY_INSERT [dbo].[Bills] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (1, N'Món chính', 1)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (2, N'Khai vị', 2)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (3, N'Tráng miệng', 3)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (4, N'Nước uống', 4)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (5, N'Ăn tối', 5)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (1, N'Phở bò', N'Tô', 1, 45000, N'Món truyền thống')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (2, N'Gỏi cuốn', N'Phần', 2, 30000, N'Món ăn nhẹ, ăn kèm nước chấm')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (3, N'Bánh flan', N'Cái', 3, 15000, N'Món tráng miệng')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (4, N'Cà phê sữa đá', N'Ly', 4, 20000, N'Pha phin truyền thống')
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (1, N'Quản trị viên', N'admin', N'Toàn quyền hệ thống')
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (2, N'Nhân viên phục vụ', N'staff', N'Quản lý order')
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (3, N'Nhân viên thu ngân', N'cashier', N'Quản lý thanh toán')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (1, N'Anh Khoa', 1, N'Tài khoản quản trị')
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (2, N'Trà My', 1, N'Tài khoản nhân viên phục vụ')
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (3, N'Phương Trang', 1, N'Tài khoản nhân viên thu ngân')
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (1, N'Bàn 1', 0, 4)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (2, N'Bàn 2', 1, 2)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (3, N'Bàn 3', 0, 6)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (4, N'Bàn 4', 1, 4)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (5, N'Bàn 5', 0, 5)
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
ALTER TABLE [dbo].[BillDetails]  WITH CHECK ADD  CONSTRAINT [FK_BillDetails_Bills] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Bills] ([ID])
GO
ALTER TABLE [dbo].[BillDetails] CHECK CONSTRAINT [FK_BillDetails_Bills]
GO
ALTER TABLE [dbo].[BillDetails]  WITH CHECK ADD  CONSTRAINT [FK_BillDetails_Food] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Food] ([ID])
GO
ALTER TABLE [dbo].[BillDetails] CHECK CONSTRAINT [FK_BillDetails_Food]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Table] FOREIGN KEY([ID])
REFERENCES [dbo].[Table] ([ID])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Table]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_Food_Category] FOREIGN KEY([FoodCategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_Food_Category]
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD  CONSTRAINT [FK_RoleAccount_Account] FOREIGN KEY([AccountName])
REFERENCES [dbo].[Account] ([AccountName])
GO
ALTER TABLE [dbo].[RoleAccount] CHECK CONSTRAINT [FK_RoleAccount_Account]
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD  CONSTRAINT [FK_RoleAccount_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[RoleAccount] CHECK CONSTRAINT [FK_RoleAccount_Role]
GO
/****** Object:  StoredProcedure [dbo].[Category_GetAll]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Thủ tục
--Category
create proc [dbo].[Category_GetAll]
as
begin
	select * from Category
end
GO
/****** Object:  StoredProcedure [dbo].[Category_GetByID]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Category_GetByID]
@id int
as
begin
	select * from Category where ID = @ID
end
GO
/****** Object:  StoredProcedure [dbo].[Category_Insert]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Category_Insert]
@name nvarchar(1000), @type int
as
begin
	if (not exists (select Name from Category where Name = @name))
		insert into Category (Name, Type) values (@name, @type)
end
GO
/****** Object:  StoredProcedure [dbo].[Category_Update]    Script Date: 15/08/2025 3:38:48 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Category_Update]
@id int, @name nvarchar(1000), @type int
as
begin
	update Category
	set [Name] = @name, [Type] = @type 
	where ID = @id
end
GO

create proc Category_Delete
@id int
as
begin
	delete from Category
	where id = @id
end
go

exec Category_Delete 5

--Account
create proc Account_GetAll
as
begin
	select * from Account
end
go

exec Account_GetAll

create proc Account_GetByID
@accountName nvarchar(100)
as
begin
	select *
	from Account
	where AccountName = @accountName
end
go

exec Account_GetByID N'Anh Khoa'

create proc Account_Insert
@accountName nvarchar(100), @passWord nvarchar(200), @fullName nvarchar(1000), 
@email nvarchar(1000) = Null, @tell nvarchar(200) = null, @dateCreated smalldatetime = null
as
begin
	insert into Account values (@accountName, @passWord, @fullName, @email, @tell, @dateCreated)
end
go

exec Account_Insert N'Thùy Trâm', N'xiu', N'Quan Thị Thùy Trâm', N'tram@gmail.com', N'0324832524', '2025-08-15'

create proc Account_Update
@accountName nvarchar(100), @passWord nvarchar(200), @fullName nvarchar(1000), 
@email nvarchar(1000) = Null, @tell nvarchar(200) = null, @dateCreated smalldatetime = null
as
begin
	update Account
	set Password = @passWord, FullName = @fullName, Email = @email, Tell = @tell, DateCreated = @dateCreated
	where AccountName = @accountName
end
go

exec Account_Update N'Thùy Trâm', N'xiu', N'Quan Thị Thúy Tràm', N'tram@gmail.com', N'0324832524', '2025-08-16'

create proc Account_Delete
@accountName nvarchar(100)
as
begin
	delete from Account where AccountName = @accountName
end
go

exec Account_Delete N'Thùy Trâm'

--Food
create proc Food_GetAll
as
begin
    select * from Food
end
go

exec Food_GetAll

create proc Food_GetByID
@id int
as
begin
    select * from Food where ID = @id
end
go

exec Food_GetByID 1

create proc Food_Insert
@name nvarchar(1000), @unit nvarchar(100), @foodCategoryID int,
@price int, @notes nvarchar(3000) = null
as
begin
    insert into Food values(@name, @unit, @foodCategoryID, @price, @notes)
end
go

exec Food_Insert N'Phở gà', N'Tô', 1, 40000, N'Thêm rau sống'

create proc Food_Update
@id int, @name nvarchar(1000), @unit nvarchar(100), @foodCategoryID int,
@price int, @notes nvarchar(3000) = null
as
begin
    update Food
    set Name = @name, Unit = @unit, FoodCategoryID = @foodCategoryID, Price = @price, Notes = @notes
    where ID = @id
end
go

exec Food_Update 6, N'Phở gà', N'Tô', 1, 35000, N'Ít hành'

create proc Food_Delete
@id int
as
begin
    delete from Food
    where ID = @id
end
go

exec Food_Delete 7

--Table
create proc Table_GetAll
as
begin
    select * from [Table]
end
go

exec Table_GetAll

create proc Table_GetByID
@id int
as
begin
    select * from [Table] where ID = @id
end
go

exec Table_GetByID 1

create proc Table_Insert
@name nvarchar(1000), @status int, @capacity int = null
as
begin
    insert into [Table] values(@name, @status, @capacity)
end
go

exec Table_Insert N'Bàn 6', 0, 7

create proc Table_Update
@id int, @name nvarchar(1000), @status int, @capacity int = null
as
begin
    update [Table]
    set Name = @name, Status = @status, Capacity = @capacity
    where ID=@id
end
go

exec Table_Update 6, N'Bàn 6', 0, 2

create proc Table_Delete
@id int
as
begin
    delete from [Table] where ID = @id
end
go

exec Table_Delete 6

--Bills
create proc Bills_GetAll
as
begin
    select * from Bills
end
go

exec Bills_GetAll

create proc Bills_GetByID
@id int
as
begin
    select * from Bills where ID = @id
end
go

exec Bills_GetByID 1

create proc Bills_Insert
@name nvarchar(1000), @tableID int, @amount int, @discount float = null,
@tax float = null, @status bit, @checkoutDate smalldatetime = null, @account nvarchar(100)
as
begin
    insert into Bills values(@name, @tableID, @amount, @discount, @tax, @status, @checkoutDate, @account)
end
go

exec Bills_Insert N'Hóa đơn 4', 4, 100000, Null, 1000, 1, Null, N'nhanvien'

create proc Bills_Update
@id int, @name nvarchar(1000), @tableID int, @amount int, @discount float = null,
@tax float = null, @status bit, @checkoutDate smalldatetime = null, @account nvarchar(100)
as
begin
    update Bills
    set Name = @name, TableID = @tableID, Amount = @amount, Discount = @discount,
        Tax = @tax, Status = @status, CheckoutDate = @checkoutDate, Account = @account
    where ID = @id
end
go

exec Bills_Update 5, N'Hóa đơn 4', 4, 50000, Null, 100, 0, Null, N'admin'

create proc Bills_Delete
@id int
as
begin
    delete from Bills where ID = @id
end
go

exec Bills_Delete 5

--BillDetails
create proc BillDetails_GetAll
as
begin
    select * from BillDetails
end
go

exec BillDetails_GetAll

create proc BillDetails_GetByID
@id int
as
begin
    select * from BillDetails where ID = @id
end
go

exec BillDetails_GetByID 3

alter proc BillDetails_Insert
@invoiceID int, @foodID int, @quantity int
as
begin
    insert into BillDetails values(@invoiceID, @foodID, @quantity)
end
go

exec BillDetails_Insert 3, 2, 5

create proc BillDetails_Update
@id int, @invoiceID int, @foodID int, @quantity int
as
begin
    update BillDetails
    set InvoiceID = @invoiceID, FoodID = @foodID, Quantity = @quantity
    where ID = @id
end
go

exec BillDetails_Update 5, 3, 1, 4

create proc BillDetails_Delete
@id int
as
begin
    delete from BillDetails where ID = @id
end
go

exec BillDetails_Delete 5