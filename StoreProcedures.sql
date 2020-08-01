--CREATE PROCEDURE [dbo].[CreateUser]
--	@userName nvarchar(60), 
--	@userEmail nvarchar(60), 
--	@userPassword nvarchar(MAX), 
--	@userFullName nvarchar(80), 
--	@userPhone nvarchar(20), 
--	@userBirthDay date,
--	@UserStatus bit,
--	@RoleId nvarchar(MAX)
--	AS
--	BEGIN
--		INSERT INTO [dbo].[AspNetUsers] (UserName, Email, PasswordHash, userFullName, PhoneNumber, UserBirthDay, UserStatus, RoleId)
--			VALUES(@userName, @userEmail, @userPassword, @userFullName, @userPhone, @userBirthDay, @UserStatus, @RoleId)
--	END



--CREATE PROCEDURE [dbo].[CreateCategory]
--	@categoryId nvarchar(MAX),
--	@categoryName nvarchar(60), 
--	@categoryDescription nvarchar(MAX), 
--	@categoryStatus bit

--	AS
--	BEGIN
--		INSERT INTO [dbo].Categories(CategoryId,CategoryName, CategoryDescription, CategoryStatus)
--			VALUES(@categoryId, @categoryName, @categoryDescription, @categoryStatus)
--	END

--CREATE PROCEDURE [dbo].[CreateProduct]
--	@productId nvarchar(MAX),
--	@productName nvarchar(60), 
--	@productPrice float, 
--	@productStatus bit,
--	@productDescription nvarchar(MAX),
--	@productImage nvarchar(MAX),
--	@categoryId nvarchar(MAX)
--	AS
--	BEGIN
--		INSERT INTO [dbo].Products(ProductId, ProductName, ProductPrice, ProductStatus, ProductDescription,ProductImage, CategoryId)
--			VALUES(@productId, @productName, @productPrice, @productStatus, @productDescription,@productImage ,@categoryId)
--	END


--CREATE PROCEDURE [dbo].[CreateOrder]
--	@orderId nvarchar(MAX),
--	@orderTotal float,
--	@orderDate datetime,
--	@orderStatus int,
--	@customerId nvarchar(MAX)
--	AS
--	BEGIN
--		INSERT INTO [dbo].Orders(OrderId, OrderTotal,OrderDate, OrderStatus, CustomerId)
--			VALUES(@orderId, @orderTotal, @orderDate,@orderStatus,@customerId)
--	END

--CREATE PROCEDURE [dbo].[CreateOrderDetail]
--	@orderDetailId nvarchar(MAX),
--	@orderDetailProductAmount int,
--	@orderDetailSubTotal float,
--	@productId nvarchar(MAX),
--	@orderId nvarchar(MAX)
--	AS
--	BEGIN
--		INSERT INTO [dbo].OrderDetails(OrderDetailId, OrderDetailProductAmount, OrderDetailSubTotal, ProductId, OrderId)
--		VALUES(@orderDetailId, @orderDetailProductAmount,@orderDetailSubTotal, @productId, @orderId)
--	END

--CREATE PROCEDURE [dbo].[CreateCustomer]
--	@customerId nvarchar(MAX),
--	@customerFullName nvarchar(80),
--	@customerEmail nvarchar(80),
--	@customerPhoneNumber nvarchar(25),
--	@customerBirthDay datetime
--	AS
--	BEGIN
--		INSERT INTO [dbo].Customers(CustomerId, CustomerFullName, CustomerEmail, CustomerPhoneNumber, CustomerBirthDate)
--			VALUES(@customerId, @customerFullName, @customerEmail,@customerPhoneNumber,@customerBirthDay)
--	END


--Listar---

	--CREATE PROCEDURE [dbo].[GetAllCategories]
	--AS
	--BEGIN
	--	SET NOCOUNT ON;
	--	select * 
	--		from [dbo].[Categories] 
	--END