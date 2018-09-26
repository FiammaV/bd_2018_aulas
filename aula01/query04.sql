SELECT Players.PlayerID AS ID,
	   Players.Name AS "Player Name",
	  SUM(Matches.TimePlayed) AS "Time Played"
FROM Matches, Players
WHERE (Players.PlayerID = Matches.PlayerID) AND
	  (Players.Name = 'wryfork')