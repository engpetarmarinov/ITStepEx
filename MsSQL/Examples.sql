-- Declare a var
DECLARE @a int;
SET @a = 2;
SELECT @a;

-- Get all  column names from a table
SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('TSQL2012.Sales.Customers') 

-- Simple INNER JOIN, casting and order by, TOP 
SELECT TOP 2 
o.orderdate, CAST(GETDATE() AS char(20)) AS "date", c.*
FROM Sales.Customers c
JOIN Sales.Orders o ON o.custid = c.custid
WHERE YEAR(o.orderdate) = 2006
ORDER BY 3

-- SELECT the server version
SELECT @@VERSION;
