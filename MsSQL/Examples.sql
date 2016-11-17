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
WHERE YEAR(o.orderdate) = 2006 -- Functions in WHERE clause will be applied to ALL rows
ORDER BY 3

-- SELECT the server version
SELECT @@VERSION as 'Microsoft SQL Server Version' -- Alias with spaces in single quotes;

-- Return a result set after insert with OUTPUT
INSERT INTO Stats.Tests (testid)
OUTPUT Inserted.testid
VALUES('banana1');

-- DELETE with TOP only limited number of rows
DELETE TOP (1) 
FROM Stats.Tests
WHERE testid LIKE 'banana%';

-- IF STATEMENT
DECLARE @MyProduct int;  
SET @MyProduct = 3;  
IF (@MyProduct = 0)
	SELECT *
	FROM Production.Products
	WHERE productid = @MyProduct; 
ELSE IF (@MyProduct > 0)
   SELECT *
   FROM Production.Products
   WHERE productid BETWEEN 0 AND @MyProduct

-- CROSS JOIN -- cartesian product 3 x 3 = 9
SELECT e1.firstname, e2.lastname
FROM HR.Employees AS e1
CROSS JOIN HR.Employees AS e2

-- Join 2 tables (INNER JOIN)
-- Select and execute the following query
-- to illustrate ANSI SQL-89 syntax
-- to join 2 tables
-- Point out that 830 rows are returned.
SELECT c.companyname, o.orderdate
FROM Sales.Customers AS c, Sales.Orders AS o
WHERE c.custid = o.custid;

GO

-- Used when you want to return two or more rows that tie for last place in the limited results set.
SELECT TOP 10 WITH TIES 
shipcity,shipregion
FROM Sales.Orders
ORDER BY shipcity

-- OFFSET/FETCH since SQL Server 2012
SELECT shipcity,shipregion
FROM Sales.Orders
ORDER BY shipcity
OFFSET 20 ROWS FETCH NEXT 10 ROWS ONLY


-- Create tables with many to many references and cascade update and delete
CREATE SCHEMA Custom
	CREATE TABLE Users (
		Id integer primary key not null identity(1,2), -- autoincrement by 2
		Email varchar(100) unique not null
	)
	CREATE TABLE Roles (
		Id integer primary key identity(1,1), -- autoincrement by 1
		Name varchar(100)
	)
	CREATE TABLE UserRoles (
		UserId integer not null references Users(Id) ON DELETE CASCADE ON UPDATE CASCADE,
		RoleId integer not null references Roles(Id) ON DELETE CASCADE ON UPDATE CASCADE
	);
GO

INSERT INTO Custom.Users (Email) VALUES ('test@abv.bg'), ('baba@sadsad.com');
INSERT INTO Custom.Roles ("Name") VALUES ('admin'), ('user');
INSERT INTO Custom.UserRoles (UserId,RoleId) VALUES (1,1), (1,2), (3,2);
UPDATE Custom.Users SET Id = 2 WHERE Id = 1; -- Can NOT update identity column
DELETE FROM Custom.Users -- DELETE all users will cascade deleting of UserRoles
DELETE FROM Custom.Roles
SELECT * FROM Custom.UserRoles
DROP TABLE Custom.UserRoles;
DROP TABLE Custom.Users;
DROP TABLE Custom.Roles;
DROP SCHEMA Custom;

-- NULL is handled differently in different components
-- FOR ORDER BY NULL IS EQUAL TO NULL
SELECT  CASE WHEN NULL IS NULL then 1 else 0 end as 'check' -- 1
SELECT  CASE WHEN NULL <> NULL then 1 else 0 end as 'check' -- 0
SELECT  CASE WHEN NULL = NULL then 1 else 0 end as 'check' -- 0
SELECT 'Ddsadsad' + NULL; -- NULL

-- the difference between function and search in the predicate
-- show execution plan + IO
DBCC FREEPROCCACHE
SET STATISTICS IO ON

SELECT orderid, custid, orderdate
FROM Sales.Orders
WHERE orderdate >= '20070101' AND orderdate < '20080101';

SELECT orderid, custid, orderdate
FROM Sales.Orders
WHERE YEAR(orderdate) >=2007 AND YEAR(orderdate) < 2008

-- index seek
SELECT city
FROM Sales.Customers
WHERE city LIKE 'Par%';

-- index scan
SELECT city
FROM Sales.Customers
WHERE city LIKE '%Par%';


SELECT COUNT(*) -- NULLS are skipped!
FROM Sales.Customers

SELECT region
FROM Sales.Customers
ORDER BY (CASE WHEN region IS NULL THEN 1 ELSE 0 END), region DESC-- Same as NULLS LAST

-- Just some GROUP BY and JOIN
SELECT o.empid, 
	(e.firstname + ' ' + e.lastname) as fullname, 
	COUNT(*) AS cnt
FROM Sales.Orders o
INNER JOIN HR.Employees e ON (e.empid = o.empid)
GROUP BY o.empid, firstname, lastname
HAVING COUNT(*) < 50
ORDER BY cnt, fullname

-- Case sensitive COLLATE
SELECT REPLACE('imalo edno vreme EDNO malko prasence i edno momiche' COLLATE SQL_Latin1_General_CP1_CS_AS,'edno','1')

-- DATEs
DECLARE @datetime DATETIME2 = '17990101';
SELECT @datetime; -- 1799-01-01 00:00:00.0000000

SELECT * FROM Sales.Orders
WHERE orderdate > '20010203' -- implicit conversion

SELECT CURRENT_TIMESTAMP
SELECT SYSUTCDATETIME()
SELECT SYSDATETIMEOFFSET()
SELECT DATEDIFF(year, CURRENT_TIMESTAMP,'20000101'); -- '-16'

-- DB NAME
SELECT DB_NAME() AS [CurrentDatabase]

-- Window function works with set of rows
SELECT TOP 5 *, RANK() OVER (ORDER BY unitprice DESC) AS rankbyprice
FROM Production.Products
ORDER BY productid
