CREATE TABLE Games (
	gameID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	name VARCHAR(128) NOT NULL
);

CREATE TABLE ReviewerTypes (
	reviewerTypeID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	description VARCHAR(128) NOT NULL,
	isPlayer INT DEFAULT 1
);

CREATE TABLE Reviewer (
	reviewerID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	reviewerTypeID INT NOT NULL REFERENCES ReviewerTypes(reviewerTypeID),
	name VARCHAR(128) NOT NULL
);

CREATE TABLE GamesOwner (
	gameID INT NOT NULL REFERENCES Games(gameID),
	reviewerID INT NOT NULL REFERENCES Reviewer(reviewerID),
	PRIMARY KEY (gameID, reviewerID)
);

CREATE TABLE Review (
	gameID INT NOT NULL REFERENCES Games(gameID),
	reviewerID INT NOT NULL REFERENCES Reviewer(reviewerID),
	score INT NOT NULL,
	reviewText TEXT NOT NULL,
	link VARCHAR(512),
	PRIMARY KEY (gameID, reviewerID)
);
