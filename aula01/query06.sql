SELECT Players.Name AS Player,
       Matches.Score AS Score,
       Arenas.Name AS Map
FROM Players, Matches, Arenas
WHERE (Players.PlayerID = Matches.PlayerID) AND
	  (Players.Name = 'wryfork') AND
      (Matches.ArenaID = 1) AND
      (Arenas.ArenaID = 1)
ORDER BY Score DESC