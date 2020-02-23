CREATE DATABASE QLCF
GO
USE QLCF
GO

-- Nước uống
-- Bàn 
-- Tài khoản 
-- Bill
-- Thông tin Bill	
-- Tạo món
-- Trạng thái bàn
-- KH vip

--Table Tai Khoan
CREATE TABLE Account
(
	UserName NVARCHAR(100) NOT NULL PRIMARY KEY,
	DisplayName NVARChAR(100) NOT NULL,
	PassWord NVARCHAR(100) NOT NULL DEFAULT 0,
	Type INT  NOT NULL DEFAULT 0 -- Loai tai khoan: 1 la admin , 0 là staff
)
GO
--Danh sach nuoc uong

CREATE TABLE DrinkCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa Đặt Tên'
)
GO

--Ban uong 
CREATE TABLE TableDrink
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Bạn chưa đặt tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống' 
)
GO

--Danh sach Bill
CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0, -- 1 thanh toan xong, 0 chua thanh toan
	
	FOREIGN KEY (idTable) REFERENCES dbo.TableDrink(id)
)
GO

--Bill Info
CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idDrink INT NOT NULL,
	count INT NOT NULL DEFAULT 0,
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idDrink) REFERENCES dbo.Drink(id)
)
GO

--Drink

CREATE TABLE Drink
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL,
	idCategory INT NOT NULL,
	price FLOAT NOT NULL,
	
	FOREIGN KEY (idCategory)  REFERENCES dbo.DrinkCategory(id)
	)
GO
-----------------------------------------------
INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'Admin' , -- UserName - nvarchar(100)
          N'Admin' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(100)
			1	  -- Type - int
        )

------------------------------------------------------------------------------------------------------------------Xong phần tạo bảng 

DECLARE @i INT = 1
WHILE(@i <= 10)
BEGIN
	INSERT INTO dbo.TableDrink
	        ( name)
	VALUES  ( N'Bàn' + CAST(@i AS NVARCHAR(100)))
	SET @i +=1
END
GO


SELECT * FROM dbo.TableDrink

CREATE PROC USP_GetTableList AS SELECT * FROM dbo.TableDrink

EXEC  USP_GetTableList

INSERT INTO dbo.TableDrink
        ( name, status )
VALUES  ( N'Bàn 11', -- name - nvarchar(100)
          N'Có Người'  -- status - nvarchar(100)
          )


SELECT* FROM dbo.Bill
SELECT * FROM dbo.BillInfo
SELECT * FROM dbo.Drink
SELECT * FROM dbo.DrinkCategory

---



---Thêm Category
INSERT dbo.DrinkCategory
        ( name )
VALUES  ( N'Nước ép trái cây')

INSERT dbo.DrinkCategory
        ( name )
VALUES  ( N'Sinh tố')
INSERT dbo.DrinkCategory
        ( name )
VALUES  ( N'Trà các loại')
INSERT dbo.DrinkCategory
        ( name )
VALUES  ( N'Nước uống có gas')

--Thêm món ăn
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép chanh tươi',1,50000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép dưa hấu',1,60000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép bưởi',1,65000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép cam tươi',1,65000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép chanh leo',1,65000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép dừa',1,60000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép ổi',1,60000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép cà rốt',1,50000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép táo',1,60000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép nha đam vải',1,55000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Ép nha đam nho',1,50000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố chanh leo',2,60000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố dưa hấu',2,70000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố chanh tuyết',2,60000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố táo',2,70000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố dâu',2,90000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố mãn cầu',2,70000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố bơ',2,90000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố đu đủ',2,40000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố sầu riêng',2,100000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố mít',2,80000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố kiwi',2,120000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Sinh tố cherry',2,150000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Trà đá',3,10000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Trà đá bình',3,30000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Trà chanh',3,30000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Trà lài',3,40000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Trà hoa cúc',3,40000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Trà lipton',3,50000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Trà lipton sữa',3,55000)
INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'7 UP',4,30000)

INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Pepsi',4,40000)

INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Coca Cola',4,45000)

INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Mountain Dew',4,50000)

INSERT dbo.Drink
        ( name, idCategory, price )
VALUES  ( N'Nước cam có gas',4,30000)

--Thêm Bill
INSERT dbo.Bill
        ( DateCheckIn ,DateCheckOut ,idTable ,status)
VALUES  ( GETDATE() ,NULL ,1 ,0)
INSERT dbo.Bill
        ( DateCheckIn ,DateCheckOut ,idTable ,status)
VALUES  ( GETDATE() ,NULL ,2 ,0)
INSERT dbo.Bill
        ( DateCheckIn ,DateCheckOut ,idTable ,status)
VALUES  ( GETDATE() ,NULL ,3 ,1)
--Thêm bill info
INSERT dbo.BillInfo
        ( idBill, idDrink, count )
VALUES  ( 1,1,1)

INSERT dbo.BillInfo
        ( idBill, idDrink, count )
VALUES  ( 2,2,1)
INSERT dbo.BillInfo
        ( idBill, idDrink, count )
VALUES  ( 3,3,1)




------------------------------------------------------------------------Xong phần insert dữ liệu

SELECT * FROM dbo.BillInfo
SELECT * FROM dbo.Bill 
SELECT * FROM dbo.Drink 
SELECT * FROM dbo.DrinkCategory


  ---------
 
 DELETE FROM dbo.DrinkCategory
WHERE id=8
SELECT * FROM dbo.DrinkCategory WHERE name = N'Sinh tố' 


----------------

--Sử dụng store Proc để tạo ra thêm 1 bill khác giữ nguyên thời gian checkin, check out là Null do bill chưa thanh toán.

ALTER PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT INTO dbo.Bill
	        ( DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status,
			  discount
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0,  -- status - int
			  0
	        )
END
GO



ALTER PROC USP_InsertBillInfo
@idBill int, @idDrink INT, @count INT
AS 
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1

	SELECT @isExitsBillInfo = id,@foodCount = b.count
	FROM dbo.BillInfo AS b WHERE idBill = @idBill AND idDrink = @idDrink

	IF(@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF(@newCount > 0)
			UPDATE dbo.BillInfo SET count = @foodCount + @count WHERE idDrink = @idDrink
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idDrink = @idDrink
    END
    ELSE
	INSERT INTO dbo.BillInfo
	        ( idBill, idDrink, count )
	VALUES  ( @idBill, -- idBill - int
	          @idDrink, -- idDrink - int
	          @count  -- count - int
	          )
END
GO

-----------------------Tao Trigger

ALTER TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = idBill FROM Inserted
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0


	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idBill
	IF(@count >0)
	BEGIN
		PRINT @idTable
		PRINT @idBill
		PRINT @count

		UPDATE dbo.TableDrink SET status = N'Có người' WHERE id = @idTable

		
	END
    
	ELSE
	BEGIN
		PRINT @idTable
		PRINT @idBill
		PRINT @count
	
	UPDATE dbo.TableDrink SET status = N'Trống' WHERE id = @idTable
	end
END

GO



CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableDrink SET status = N'Trống' WHERE id = @idTable
END
GO

ALTER TABLE dbo.Bill ADD discount INT

UPDATE dbo.Bill SET discount = 0


--------------------Tao Proc Swap table

Alter PROC USP_SwitchTable
@idTable1 int, @idTable2 int
AS
BEGIN
		DECLARE @idFirstBill INT
		DECLARE @idSecondBill INT

		DECLARE @isFirstTableEmty INT = 1
		
		DECLARE @isSecondTableEmty INT = 1

		SELECT @idSecondBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0

		PRINT @idFirstBill
		PRINT @idSecondBill
		PRINT '--------------'

		IF(@idFirstBill IS null)
		BEGIN
		INSERT INTO dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )

		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE  idTable = @idTable1 AND status = 0


		END

		SELECT @isFirstTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill

		PRINT @idFirstBill
		PRINT @idSecondBill
		PRINT '-----------'        

		IF(@idSecondBill IS null)
		BEGIN
		PRINT '000000002'
		INSERT INTO dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )

		SELECT @idSecondBill = MAX(id) FROM dbo.Bill WHERE  idTable = @idTable2 AND status = 0

		
		END

		SELECT @isSecondTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSecondBill 

		PRINT @idFirstBill
		PRINT @idSecondBill
		PRINT '----------------'

		SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill

		UPDATE dbo.BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
		UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)

		DROP TABLE IDBillInfoTable

		IF(@isFirstTableEmty = 0)
			UPDATE dbo.TableDrink SET status = N'Trống' WHERE id = @idTable2

			
		IF(@isSecondTableEmty = 0)
			UPDATE dbo.TableDrink SET status = N'Trống' WHERE id = @idTable2
        
END

EXEC dbo.USP_SwitchTable  @idTable1 = 0, -- int
    @idTable2 = 0 -- int


	UPDATE dbo.TableDrink SET status = N'Trống'
