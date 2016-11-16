/*============================================================================
	File:		1.1 - Advanced Grouping.sql

	Summary:	The script demonstrates how to use GROUPING SETS,
				GROUPING ROLLUP and GROUPING CUBE.

				THIS SCRIPT IS PART OF THE COURSE: 
				"Developing with SQL Server"



	SQL Server Version: 2008 / 2012 / 2014 / 2016
------------------------------------------------------------------------------


	This script is intended only as a supplement to demos and lectures

  
	THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF 
	ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED 
	TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
	PARTICULAR PURPOSE.
============================================================================*/

USE TSQL2012
GO

--Create table and populate with example data

CREATE TABLE Sales (EmpId INT, Yr INT, Sales MONEY)
INSERT Sales VALUES(1, 2005, 12000)
INSERT Sales VALUES(1, 2006, 18000)
INSERT Sales VALUES(1, 2007, 25000)
INSERT Sales VALUES(2, 2005, 15000)
INSERT Sales VALUES(2, 2006, 6000)
INSERT Sales VALUES(3, 2006, 20000)
INSERT Sales VALUES(3, 2007, 24000)


SELECT * FROM Sales

--Show me the sales + the totals for each group(DEPRECATED!)
SELECT EmpId, Yr, SUM(Sales) AS Sales
FROM Sales
GROUP BY EmpId, Yr WITH ROLLUP

--Show me summary based on every permutation (DEPRECATED!)
SELECT EmpId, Yr, SUM(Sales) AS Sales
FROM Sales
GROUP BY EmpId, Yr WITH CUBE

--Remind the students about the DEPRECATED features / code

--How to fix this?
--New Functions GROUP BY ROLLUP () and GROUP BY CUBE ()

--ROLLUP () new syntax
SELECT EmpId, Yr, SUM(Sales) AS Sales
FROM Sales
GROUP BY ROLLUP(EmpId, Yr)

--CUBE () new syntax
SELECT EmpId, Yr, SUM(Sales) AS Sales
FROM Sales
GROUP BY CUBE(EmpId, Yr)

--What's next?

--GROUPING SETS
--GROUPING SETS allow us to choose which grouping aggregations we want

/*
The equivilant to

SELECT EmpId, Yr, SUM(Sales) AS Sales
FROM Sales
GROUP BY EmpId, Yr WITH ROLLUP

*/

SELECT EmpId, Yr, SUM(Sales) AS Sales
FROM Sales
GROUP BY GROUPING SETS((EmpId, Yr), (EmpId), ()) 
-- group by empid and year first, 
-- group by empid total second
-- group and summarise the total at the end 

SELECT EmpId, Yr, SUM(Sales) AS Sales
FROM Sales
GROUP BY GROUPING SETS((EmpId, Yr), (EmpId), (Yr), ()) -- give me all combinations

-- same as first one without the total for all employees
SELECT EmpId, Yr, SUM(Sales) AS Sales
FROM Sales
GROUP BY GROUPING SETS((EmpId, Yr), (EmpId)) 

-- summarized by employee and year, but no intermediate results (totals for employee), but total for all of them
SELECT EmpId, Yr, SUM(Sales) AS Sales
FROM Sales
GROUP BY GROUPING SETS((EmpId, Yr), ())

-- summarized by employees and then summarized by years (totally unrelated)
SELECT EmpId, Yr, SUM(Sales) AS Sales
FROM Sales
GROUP BY GROUPING SETS((EmpId), (Yr))
