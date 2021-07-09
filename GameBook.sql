CREATE SCHEMA GameBook;

CREATE DATABASE GameBook;

CREATE TABLE users(
	user_id				INT				NOT NULL	PRIMARY KEY  IDENTITY(1,1),
	username			NVARCHAR(20)	NOT NULL,
	password			NVARCHAR(20)	NOT NULL,
	first_name			NVARCHAR(30)	NOT NULL,
	last_name			NVARCHAR(30)	NOT NULL,
	email				NVARCHAR(60)	NOT NULL
);

CREATE TABLE friend(
	user1_id			INT				NOT NULL	FOREIGN KEY REFERENCES users(user_id),
	user2_id			INT				NOT NULL	FOREIGN KEY REFERENCES users(user_id)
);

CREATE TABLE post(
	post_id				INT				NOT NULL	PRIMARY KEY  IDENTITY(1,1),
	user_id				INT				NOT NULL	FOREIGN KEY REFERENCES users(user_id),
	comment_parent_id	INT				NULL		FOREIGN KEY REFERENCES post(post_id),
	content				NVARCHAR(1000)	NOT NULL,
	rating				INT,
	post_date			DATETIME		NOT NULL	DEFAULT Getdate()
);

CREATE TABLE game(
	game_id				INT				NOT NULL	PRIMARY KEY,
	name				NVARCHAR(40)	NOT NULL
);

CREATE TABLE play_history(
	user_id				INT				NOT NULL	FOREIGN KEY REFERENCES users(user_id),
	game_id				INT				NOT NULL	FOREIGN KEY REFERENCES game(game_id)
);

CREATE TABLE genre(
	genre_id			INT				NOT NULL	PRIMARY KEY,
	name				NVARCHAR(40)	NOT NULL
);

CREATE TABLE genre_junction(
	genre_id			INT				NOT NULL	FOREIGN KEY REFERENCES genre(genre_id),
	game_id				INT				NOT NULL	FOREIGN KEY REFERENCES game(game_id)
);

CREATE TABLE collection(
	collection_id		INT				NOT NULL	PRIMARY KEY,
	name				NVARCHAR(40)	NOT NULL
);

CREATE TABLE collection_junction(
	collection_id		INT				NOT NULL	FOREIGN KEY REFERENCES collection(collection_id),
	game_id				INT				NOT NULL	FOREIGN KEY REFERENCES game(game_id)
);

CREATE TABLE keyword(
	keyword_id			INT				NOT NULL	PRIMARY KEY,
	name				NVARCHAR(40)	NOT NULL
);

CREATE TABLE keyword_junction(
	keyword_id			INT				NOT NULL	FOREIGN KEY REFERENCES keyword(keyword_id),
	game_id				INT				NOT NULL	FOREIGN KEY REFERENCES game(game_id)
);