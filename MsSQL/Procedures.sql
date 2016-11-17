-- CREATE PROCEDURE <schema_name.proc_name> (@params type) AS ...
-- ALTER PROCEDURE

-- CREATE
CREATE PROCEDURE Production.ProdByCategory(@numrows AS int, @catid AS int)
AS
SELECT TOP (@numrows) productid, productname, unitprice
FROM Production.Products
WHERE categoryid = @catid;
GO

-- ALTER
ALTER PROCEDURE [Production].[ProdByCategory](@numrows AS int, @catid AS int)
AS
SELECT TOP (@numrows) categoryid, productid, productname, unitprice
FROM Production.Products
WHERE categoryid = @catid;
GO

-- EXECUTE and use as a var of set of results
Declare @tmp Table (categoryid int, productid int, productname nvarchar(MAX), unitprice float)
INSERT @tmp EXEC Production.ProdByCategory 2, 3;
SELECT * FROM @tmp WHERE unitprice < 20;
GO

-- A bit more complex procedure with 2 selects
CREATE PROC Production.ProductList (@ProdName nvarchar(50))
AS
BEGIN 
	-- First result set
	SELECT ProductID, productName, unitprice
		FROM Production.Products
		WHERE productName LIKE @ProdName;
	-- Second result set 
	SELECT productName, COUNT(S.ProductID) AS NumberOfOrders
		FROM Production.Products AS P
		JOIN Sales.OrderDetails AS S
			ON P.ProductID  = S.ProductID 
		WHERE productName LIKE @ProdName
		GROUP BY productName;
END
GO

-- Execute the procedure 
EXEC Production.ProductList @prodname = '%product%'
WITH RESULT SETS 
(
    (ProductID int,   -- first result set definition starts here
    Namewqewqe NVARCHAR(50),
    ListPrice money)
    ,                 -- comma separates result set definitions
    (Name NVARCHAR(50),       -- second result set definition starts here
    NumberOfOrders int)
)

-- DROP the procedure
DROP PROCEDURE Production.productList;


DECLARE @filter varchar(MAX) = 'a) OR 1=1; -- ';
SELECT * 
FROM HR.Employees
WHERE firstname IN (@filter);
SELECT @filter;
