DROP SCHEMA IF EXISTS NotesPP;
CREATE SCHEMA IF NOT EXISTS NotesPP;
USE NotesPP;

CREATE TABLE IF NOT EXISTS Notes(
Id INT(10) AUTO_INCREMENT NOT NULL,
Name VARCHAR(20) NOT NULL,
Content VARCHAR(500) NOT NULL,
Acc_Username VARCHAR(20) NOT NULL,
IsArchived BOOLEAN,
PRIMARY KEY(Id)
);

CREATE TABLE IF NOT EXISTS Accounts(
Id INT(10) NOT NULL AUTO_INCREMENT,
Username VARCHAR(20) NOT NULL,
Password VARCHAR(20) NOT NULL,
PRIMARY KEY(Id)
);