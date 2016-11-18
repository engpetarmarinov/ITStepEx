 -- ALL Footballers by team
 SELECT p.FirstName, p.LastName, c.Name
 FROM Club.Players p
 LEFT JOIN Division.Clubs c ON (p.ClubId = c.Id)
 ORDER BY p.ClubId, p.FirstName

 -- Number of 1,X,2
 SELECT c.Id, c.Name,
 -- WINS
 SUM(CASE WHEN 		
		(m.HomeGoals > m.GuestGoals AND c.Id = m.HomeClubId) -- HOME WIN!
		OR 		
		(m.GuestGoals > m.HomeGoals AND c.Id = m.GuestClubId) -- GUEST WIN!
	THEN 1 ELSE 0 
	END) as 'Wins',
 -- Draws
 SUM(
	CASE WHEN 
		m.HomeGoals = m.GuestGoals
	THEN 1 ELSE 0 
	END) as 'Draws',
-- LOSES
 SUM(
	CASE WHEN 
		(m.HomeGoals > m.GuestGoals AND c.Id = m.GuestClubId)
		OR 
		(m.GuestGoals > m.HomeGoals AND c.Id = m.HomeClubId)
	THEN 1 ELSE 0 
	END) as 'Loses',
 COUNT(*) as 'All',
 -- Points
 SUM(
	CASE WHEN 
		(m.HomeGoals > m.GuestGoals AND c.Id = m.HomeClubId) -- HOME WIN!
		OR 
		(m.GuestGoals > m.HomeGoals AND c.Id = m.GuestClubId) -- GUEST WIN!
	THEN 3 ELSE 0 
	END)
 +
 SUM(
	CASE WHEN 
		m.HomeGoals = m.GuestGoals
	THEN 1 ELSE 0 
	END) as 'Points'

 FROM Division.Matches AS m
 JOIN Division.Clubs AS c ON (c.Id = m.HomeClubId OR c.Id = m.GuestClubId)
 GROUP BY c.Name, c.Id
 ORDER BY Wins DESC, Draws DESC, Name


 -- Last matches
SELECT
	(homeClub.Name + N' - ' + guestClub.Name) as teams,
	(CAST(m.HomeGoals as varchar) + N' : ' + CAST(m.GuestGoals as varchar)) as result,
	CONVERT(VARCHAR(11),m.StartDate,113) as 'time'
FROM Division.Matches m
JOIN Division.Clubs homeClub ON (homeClub.Id = m.HomeClubId)
JOIN Division.Clubs guestClub ON (guestClub.Id = m.GuestClubId)
WHERE m.StartDate > '2016-10-11'
ORDER BY m.StartDate DESC



-- All teams that have more wins than half of all mathes played
 SELECT c.Id, c.Name,
 -- WINS
 SUM(
	CASE WHEN 
		(m.HomeGoals > m.GuestGoals AND c.Id = m.HomeClubId) -- HOME WIN!
		OR 
		(m.GuestGoals > m.HomeGoals AND c.Id = m.GuestClubId) -- GUEST WIN!
	THEN 1 ELSE 0 
	END) as 'Wins',
 COUNT(*) as 'All'	

 FROM Division.Matches AS m
 JOIN Division.Clubs AS c ON (c.Id = m.HomeClubId OR c.Id = m.GuestClubId)
 GROUP BY c.Name, c.Id
 HAVING SUM(CASE WHEN 
		(m.HomeGoals > m.GuestGoals AND c.Id = m.HomeClubId) -- HOME WIN!
		OR 		
		(m.GuestGoals > m.HomeGoals AND c.Id = m.GuestClubId) -- GUEST WIN!
	THEN 1 ELSE 0 
	END) > ( COUNT(*)/ 2 )
 ORDER BY Wins DESC, Name

GO;

-- Table by date
CREATE PROCEDURE Club.GetPoints(@date smalldatetime)
AS
BEGIN

	SELECT c.Id, c.Name,
	 -- WINS
	 SUM(CASE WHEN 		
			(m.HomeGoals > m.GuestGoals AND c.Id = m.HomeClubId) -- HOME WIN!
			OR 		
			(m.GuestGoals > m.HomeGoals AND c.Id = m.GuestClubId) -- GUEST WIN!
		THEN 1 ELSE 0 
		END) as 'Wins',
	 -- Draws
	 SUM(
		CASE WHEN 
			m.HomeGoals = m.GuestGoals
		THEN 1 ELSE 0 
		END) as 'Draws',
	-- LOSES
	 SUM(
		CASE WHEN 
			(m.HomeGoals > m.GuestGoals AND c.Id = m.GuestClubId)
			OR 
			(m.GuestGoals > m.HomeGoals AND c.Id = m.HomeClubId)
		THEN 1 ELSE 0 
		END) as 'Loses',
	 COUNT(*) as 'All',
	 -- Points
	 SUM(
		CASE WHEN 
			(m.HomeGoals > m.GuestGoals AND c.Id = m.HomeClubId) -- HOME WIN!
			OR 
			(m.GuestGoals > m.HomeGoals AND c.Id = m.GuestClubId) -- GUEST WIN!
		THEN 3 ELSE 0 
		END)
	 +
	 SUM(
		CASE WHEN 
			m.HomeGoals = m.GuestGoals
		THEN 1 ELSE 0 
		END) as 'Points'

	 FROM Division.Matches AS m
	 JOIN Division.Clubs AS c ON (c.Id = m.HomeClubId OR c.Id = m.GuestClubId)
	 WHERE StartDate < @date
	 GROUP BY c.Name, c.Id
	 ORDER BY Wins DESC, Draws DESC, Name

END
GO;

-- Execute procedure
EXEC Club.GetPoints '2016-12-12'