SELECT Arenas.Name As Map,
       COUNT(*) AS "Games Played",
       SUM(Matches.TimePlayed) AS "Total Time Played"
FROM Matches, Arenas
WHERE Matches.ArenaID = Arenas.ArenaID
GROUP BY Arenas.Name
ORDER BY "Games Played" DESC
