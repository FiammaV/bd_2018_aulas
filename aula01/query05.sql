SELECT Players.Name AS Player,
       Matches.Score AS Score,
       Arenas.Name AS Map
FROM Players, Matches, Arenas
WHERE (Players.PlayerID = Matches.PlayerID) AND
	  (Matches.ArenaID = 3) AND
      (Arenas.ArenaID = 3)
ORDER BY Score DESC
LIMIT 10