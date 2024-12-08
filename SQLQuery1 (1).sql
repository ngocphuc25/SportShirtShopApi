-- Create the database
CREATE DATABASE SportShirtShopDB;
GO

-- Use the newly created database
USE SportShirtShopDB;
GO

CREATE TABLE Account (
    id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(200),
    email NVARCHAR(200),
    password NVARCHAR(200),
	  Role NVARCHAR(20) ,
    Status NVARCHAR(20),
    Name NVARCHAR(200) null,
     Dob DATETIME null,
    gender NVARCHAR(10) null,
    phone NVARCHAR(15)
  
);

CREATE TABLE Orders (
    id INT IDENTITY(1,1) PRIMARY KEY,
    note NVARCHAR(MAX) null,
    status NVARCHAR(MAX),
	id_Account INT null,
	payment_method NVARCHAR(20),
    payment_status NVARCHAR(30),
	name NVARCHAR(150),
	phone NVARCHAR(30),
	email NVARCHAR(100),
	ship_address NVARCHAR(200),
	totalAmmount decimal(18,2),
    code NVARCHAR(MAX),
    createDate DATETIME,
    

    FOREIGN KEY (id_Account) REFERENCES Account(id)
);
CREATE TABLE Club (
    id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50),
    Logo NVARCHAR(50),
    Status NVARCHAR(50),
    note NVARCHAR(50),
    code NVARCHAR(50),
    createDate DATETIME,
    createAccount INT
);
CREATE TABLE Player (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_Club INT  null,
    name NVARCHAR(50),
    dob DATE,
    note NVARCHAR(50) null,
    code NVARCHAR(50),
    createDate DATETIME,
    createAccount INT,
    FOREIGN KEY (id_Club) REFERENCES Club(id)
);

CREATE TABLE Payment (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_Orders INT,
    method NVARCHAR(MAX),
    status NVARCHAR(MAX),
	price decimal(18,2),
    createDate DATETIME,
    updateDate Datetime,
    FOREIGN KEY (id_Orders) REFERENCES Orders(id)
);

CREATE TABLE Tournament (
    id INT IDENTITY(1,1) PRIMARY KEY,
    startDate DATE,
    endDate DATE,
    name NVARCHAR(MAX),
    status NVARCHAR(MAX),
    description NVARCHAR(MAX),
    note NVARCHAR(MAX),
    code NVARCHAR(MAX),
    createDate DATETIME,
    createAccount INT
);

CREATE TABLE ShirtEdition (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_Tournament INT,
    nameseason NVARCHAR(MAX),
    status NVARCHAR(MAX),
    note NVARCHAR(MAX),
    code NVARCHAR(MAX),
    createDate DATETIME,
    createAccount INT,
    FOREIGN KEY (id_Tournament) REFERENCES Tournament(id)
);

CREATE TABLE TournamentClub (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_Tournament INT,
    id_Club INT,
    createDate DATETIME,
    createAccount INT,
    FOREIGN KEY (id_Tournament) REFERENCES Tournament(id),
    FOREIGN KEY (id_Club) REFERENCES Club(id)
);

CREATE TABLE PlayerInTournamentClub (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_TournamentClub INT,
    id_Player INT,
    Number INT,
    PlayerName NVARCHAR(MAX),
    SeasonName NVARCHAR(MAX),
    ClubName NVARCHAR(MAX),
    Description NVARCHAR(MAX),
    FOREIGN KEY (id_TournamentClub) REFERENCES TournamentClub(id),
    FOREIGN KEY (id_Player) REFERENCES Player(id)
);

CREATE TABLE Shirt (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_shirtEdition INT null ,
    id_PlayerinTournamentClub INT Null,
    name NVARCHAR(MAX),
    price DECIMAL(18, 2),
	salePrice Decimal(18,2) null,
	totalSold int null,
    description NVARCHAR(MAX),
    quantity_stock INT,
	status nvarchar(30),
    code NVARCHAR(20),
    createDate DATETIME,
    createAccount INT,
    updatedDate DATETIME,
    FOREIGN KEY (id_shirtEdition) REFERENCES ShirtEdition(id),
    FOREIGN KEY (id_PlayerinTournamentClub) REFERENCES PlayerInTournamentClub(id)
);




CREATE TABLE OrderDetail (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_Orders INT,
    id_Shirt INT,
	name NVARCHAr(500),
    quantity INT,
    price DECIMAL(18, 2),
    subtotal DECIMAL(18, 2),
	createDate DATETIME,
	updateDate Datetime,
	salePrice decimal(18,2),

    FOREIGN KEY (id_Orders) REFERENCES Orders(id),
    FOREIGN KEY (id_Shirt) REFERENCES Shirt(id)
);

CREATE TABLE Image (
    id INT IDENTITY(1,1) PRIMARY KEY,
    link NVARCHAR(MAX),
    id_Shirt INT,
    FOREIGN KEY (id_Shirt) REFERENCES Shirt(id)
);


