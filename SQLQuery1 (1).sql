-- Create the database
CREATE DATABASE SportShirtShopDB;
GO

-- Use the newly created database
USE SportShirtShopDB;
GO

CREATE TABLE Account (
    id INT PRIMARY KEY,
    username NVARCHAR(200),
    email NVARCHAR(200),
    password NVARCHAR(200),
    Name NVARCHAR(200),
    
    gender NVARCHAR(200),
    address NVARCHAR(200),
    phone NVARCHAR(15),
    Dob DATETIME,
    Role NVARCHAR(MAX),
    Status NVARCHAR(MAX)
);

CREATE TABLE Orders (
    id INT PRIMARY KEY,
    id_Account INT,
    note NVARCHAR(MAX),
    Status NVARCHAR(MAX),
    PaymentStatus NVARCHAR(10),
	ship_address NVARCHAR(200),
    code NVARCHAR(MAX),
    createDate DATETIME,
    createAccount INT,
    FOREIGN KEY (id_Account) REFERENCES Account(id)
);
CREATE TABLE Club (
    id INT PRIMARY KEY,
    Name NVARCHAR(MAX),
    Logo NVARCHAR(MAX),
    Status NVARCHAR(MAX),
    note NVARCHAR(MAX),
    code NVARCHAR(MAX),
    createDate DATETIME,
    createAccount INT
);
CREATE TABLE Player (
    id INT PRIMARY KEY,
    id_Club INT  null,
    name NVARCHAR(MAX),
    dob DATE,
    note NVARCHAR(MAX),
    code NVARCHAR(MAX),
    createDate DATETIME,
    createAccount INT,
    FOREIGN KEY (id_Club) REFERENCES Club(id)
);

CREATE TABLE Payment (
    id INT PRIMARY KEY,
    id_Orders INT,
    method NVARCHAR(MAX),
    status NVARCHAR(MAX),
    note NVARCHAR(MAX),
    code NVARCHAR(MAX),
    createDate DATETIME,
    createAccount INT,
    FOREIGN KEY (id_Orders) REFERENCES Orders(id)
);

CREATE TABLE Tournament (
    id INT PRIMARY KEY,
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
    id INT PRIMARY KEY,
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
    id INT PRIMARY KEY,
    id_Tournament INT,
    id_Club INT,
    createDate DATETIME,
    createAccount INT,
    FOREIGN KEY (id_Tournament) REFERENCES Tournament(id),
    FOREIGN KEY (id_Club) REFERENCES Club(id)
);

CREATE TABLE PlayerInTournamentClub (
    id INT PRIMARY KEY,
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
    id INT PRIMARY KEY,
    id_shirtEdition INT null ,
    id_PlayerinTournamentClub INT Null,
    name NVARCHAR(MAX),
    price DECIMAL(18, 2),
    description NVARCHAR(MAX),
    quantity_stock INT,
    code NVARCHAR(MAX),
    createDate DATETIME,
    createAccount INT,
    updatedDate DATETIME,
    FOREIGN KEY (id_shirtEdition) REFERENCES ShirtEdition(id),
    FOREIGN KEY (id_PlayerinTournamentClub) REFERENCES PlayerInTournamentClub(id)
);




CREATE TABLE OrderDetail (
    id INT PRIMARY KEY,
    id_Orders INT,
    id_Shirt INT,
    quantity INT,
    price DECIMAL(18, 2),
    subtotal DECIMAL(18, 2),
    FOREIGN KEY (id_Orders) REFERENCES Orders(id),
    FOREIGN KEY (id_Shirt) REFERENCES Shirt(id)
);

CREATE TABLE Image (
    id INT PRIMARY KEY,
    link NVARCHAR(MAX),
    id_Shirt INT,
    FOREIGN KEY (id_Shirt) REFERENCES Shirt(id)
);

INSERT INTO Account VALUES
(1, 'johndoe', 'johndoe@example.com', 'hashedPassword1', 'John', 'Doe', 'Male', '123 Street, City', '1234567890', '1985-01-01', 'Admin', 'Active'),
(2, 'janedoe', 'janedoe@example.com', 'hashedPassword2', 'Jane', 'Doe', 'Female', '456 Avenue, City', '0987654321', '1990-02-02', 'User', 'Active'),
(3, 'player1', 'player1@example.com', 'hashedPassword3', 'Player', 'One', 'Male', '789 Boulevard, City', '1112223333', '1992-03-03', 'Player', 'Inactive'),
(4, 'manager1', 'manager1@example.com', 'hashedPassword4', 'Manager', 'One', 'Male', '321 Lane, City', '4445556666', '1988-04-04', 'Manager', 'Active'),
(5, 'coach1', 'coach1@example.com', 'hashedPassword5', 'Coach', 'One', 'Female', '654 Park, City', '7778889999', '1980-05-05', 'Coach', 'Active');
