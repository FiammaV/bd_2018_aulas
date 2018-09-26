SELECT Players.name, SUM(Matches.TimePlayed) AS Total
FROM Players, Matches
WHERE (Players.PlayerID = Matches.PlayerID) AND (Matches.ArenaID = 1)
GROUP BY Players.Name
ORDER BY Total DESC;