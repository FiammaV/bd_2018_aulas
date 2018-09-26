SELECT Players.Name AS "Player Name",
       Arenas.Name AS "Map Name",
       SUM(Matches.TimePlayed) AS "Total Time"
FROM Players, Arenas, Matches
WHERE (Players.PlayerID = Matches.PlayerID) AND
      (Arenas.ArenaID = Matches.ArenaID) AND
      (Matches.ArenaID = 2)
GROUP BY Players.Name
ORDER BY "Total Time" DESC LIMIT 5
