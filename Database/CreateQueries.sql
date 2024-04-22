create database BidingSystem


USE BidingSystem

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(255) NOT NULL,
    Nickname NVARCHAR(255),
    UserType NVARCHAR(50) NOT NULL,
);

CREATE TABLE Bid(
	BidID INT PRIMARY KEY IDENTITY,
	BidSum FLOAT,
	TimeOfBid DateTime,
	UserID INT,
	FOREIGN KEY (UserID) REFERENCES Users(UserID)

);
CREATE TABLE Auction(
	AuctionID INT PRIMARY KEY IDENTITY,
	AuctionDescription NVARCHAR(255),
	AuctionName NVARCHAR(50),
	CurrentMaxSum FLOAT,
	UserID INT,
	FOREIGN KEY (UserID) REFERENCES Users(UserID),
	BidID INT,
	FOREIGN KEY (BidID) REFERENCES Bid(BidID),
	DateOfStart DATETIME,
);

SELECT * FROM Users
SELECT * FROM Bid
SELECT * FROM Auction


