
#include <stdio.h>
#include <stdlib.h>

int main()
{
	FILE* file = NULL;
	fopen_s(&file, "Matches.sql", "wt");
	if (file == NULL) return -1;

	fprintf(file, "CREATE TABLE Players(\n");
	fprintf(file, "		PlayerID INTEGER UNIQUE NOT NULL PRIMARY KEY AUTOINCREMENT,\n");
	fprintf(file, "		Name VARCHAR(255), Country VARCHAR(255)\n");
	fprintf(file, "	);\n");
	fprintf(file, "\n");
	fprintf(file, "CREATE TABLE Arenas(\n");
	fprintf(file, "	ArenaID INTEGER UNIQUE NOT NULL PRIMARY KEY AUTOINCREMENT,\n");
	fprintf(file, "	Name VARCHAR(255)\n");
	fprintf(file, ");\n");
	fprintf(file, "\n");
	fprintf(file, "CREATE TABLE Matches(\n");
	fprintf(file, "	MatchID INTEGER UNIQUE NOT NULL PRIMARY KEY AUTOINCREMENT,\n");
	fprintf(file, "	ArenaID int,\n");
	fprintf(file, "	PlayerID INT,\n");
	fprintf(file, "	TimePlayed INT,\n");
	fprintf(file, "	Score INT\n");
	fprintf(file, ");\n");
	fprintf(file, "\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(1, 'unificationpuscle', 'Russia');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(2, 'cranniesbitcoin', 'United States');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(3, 'eyetrolleybus', 'Russia');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(4, 'benthicsweep', 'Germany');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(5, 'tavernercoda', 'Spain');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(6, 'padelephant', 'France');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(7, 'slurpdartboard', 'Germany');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(8, 'markupgeas', 'Portugal');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(9, 'plandarwin', 'Germany');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(10, 'wryfork', 'Russia');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(11, 'wantedways', 'Portugal');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(12, 'vaccineseyeballs', 'Germany');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(13, 'peanutbamb', 'Russia');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(14, 'toastedmiserly', 'Russia');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(15, 'deercrampon', 'Portugal');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(16, 'swoophumor', 'United States');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(17, 'minimizexebec', 'Russia');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(18, 'doughgrasp', 'Portugal');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(19, 'reinforcejacket', 'United Kingdom');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(20, 'groomingswoosh', 'United Kingdom');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(21, 'cartridgestegative', 'France');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(22, 'anguishedzeolite', 'France');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(23, 'pagingsathing', 'Spain');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(24, 'buckeffects', 'Russia');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(25, 'commonsoast', 'Germany');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(26, 'marboom', 'Russia');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(27, 'whackblision', 'Germany');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(28, 'wildcatmelodic', 'Germany');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(29, 'cloningrafter', 'Russia');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(30, 'veneratedegyptian', 'United States');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(31, 'genoalanguage', 'United States');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(32, 'chalkyunselfish', 'Germany');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(33, 'meamcax', 'United States');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(34, 'shieldgrateful', 'France');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(35, 'rhangcolumba', 'Portugal');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(36, 'instancekneepads', 'United Kingdom');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(37, 'gumpssniveling', 'Germany');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(38, 'fleshfont', 'Portugal');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(39, 'strunchfea', 'United Kingdom');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(40, 'ninkslemongrass', 'Spain');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(41, 'buttocksadorable', 'Spain');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(42, 'glaucomasodding', 'United Kingdom');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(43, 'crottedhelicopter', 'United Kingdom');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(44, 'linkagequirt', 'France');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(45, 'creakycuddly', 'Germany');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(46, 'dimwittedask', 'France');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(47, 'potablechorse', 'Portugal');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(48, 'bloomingbike', 'United Kingdom');\n");
	fprintf(file, "INSERT INTO Players(PlayerID, Name, Country) VALUES(49, 'scienceunicyclist', 'United States');\n");
	fprintf(file, "INSERT INTO Arenas(ArenaID, Name) VALUES(1, 'Sacred Tree');\n");
	fprintf(file, "INSERT INTO Arenas(ArenaID, Name) VALUES(2, 'Forsaken Ships');\n");
	fprintf(file, "INSERT INTO Arenas(ArenaID, Name) VALUES(3, 'Kingdom Border');\n");
	fprintf(file, "INSERT INTO Arenas(ArenaID, Name) VALUES(4, 'Dread Grove');\n");
	fprintf(file, "INSERT INTO Arenas(ArenaID, Name) VALUES(5, 'Dark Swamp');\n");
	fprintf(file, "INSERT INTO Arenas(ArenaID, Name) VALUES(6, 'Evil Lava Lair');\n");

	for (int i = 0; i < 500; i++)
	{
		fprintf(file, "INSERT INTO Matches(ArenaID, PlayerID, TimePlayed, Score) VALUES(%i, %i, %i, %i);\n",
					  (rand() % 5) + 1,
					  (rand() % 48) + 1,
					  (rand() % 60) + 10,
					  (rand() % 100000) + 2365);
	}

	fclose(file);

	return 0;
}