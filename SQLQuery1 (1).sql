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
    Logo NVARCHAR(200),
    Status NVARCHAR(50),
    note NVARCHAR(50) null,
    code NVARCHAR(50),
    createDate DATETIME,
    createAccount INT
);
CREATE TABLE Player (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_Club INT  null,
    name NVARCHAR(50),
    dob DATETIME,
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
    startDate DATETIME,
    endDate DATETIME,
    name NVARCHAR(MAX) ,
    status NVARCHAR(MAX),
    description NVARCHAR(MAX),
    note NVARCHAR(MAX) null,
    code NVARCHAR(MAX),
    createDate DATETIME,
    createAccount INT
);

CREATE TABLE ShirtEdition (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_Tournament INT,
    nameseason NVARCHAR(MAX),
    status NVARCHAR(MAX),
    note NVARCHAR(MAX) null,
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

INSERT INTO Club (Name, Logo, Status, Note, Code, CreateDate, CreateAccount)
VALUES 
    ('Manchester United', 'https://upload.wikimedia.org/wikipedia/vi/thumb/a/a1/Man_Utd_FC_.svg/800px-Man_Utd_FC_.svg.png', 'Active', '-', 'MU', GETDATE(), null),
    ('Real Madrid', 'https://upload.wikimedia.org/wikipedia/vi/thumb/a/a1/Man_Utd_FC_.svg/363px-Man_Utd_FC_.svg.png', 'Active', '-', 'REAL', GETDATE(), null),
    ('Manchester City', 'https://upload.wikimedia.org/wikipedia/en/thumb/e/eb/Manchester_City_FC_badge.svg/285px-Manchester_City_FC_badge.svg.png', 'Active', '-', 'MC', GETDATE(), 3),
    ('Chelsea', 'https://upload.wikimedia.org/wikipedia/en/thumb/c/cc/Chelsea_FC.svg/285px-Chelsea_FC.svg.png', 'Active', '-', 'CHEL', GETDATE(), NULL)

INSERT INTO Tournament (StartDate, EndDate, Name, Status, Description, Note, Code, CreateDate, CreateAccount)
VALUES
    ('2024-08-11', '2024-05-19', '2023-24 Premier League', 'Completed', N'Giải ngoại hạng Anh 23-24', 'Manchester City is a champion', 'P2324', GETDATE(), null),
    ('2022-8-5', '2023-5-28', '2022–23 Premier League', 'Completed', N'Giải ngoại hạng Anh 22-23', 'Manchester City is a champion', 'P2223', GETDATE(), null),
    ('2024-08-28', '2023-5-31', '2024–25 UEFA Champions League', 'Active', N'Champions League 24-25', '-', 'CL2425', GETDATE(), null)

INSERT INTO Player (id_Club, Name, Dob, Note, Code, CreateDate, CreateAccount)
VALUES
    (1, 'Marcus Rashford', '1997-10-31', '-', 'MU001', GETDATE(), null),
    (1, 'Bruno Fernandes', '1994-09-08', '-', 'MU002', GETDATE(), null),
    (1, 'Harry Maguire', '1993-03-05', '-', 'MU003', GETDATE(), null),
	(1, 'Harry Maguire', '1993-03-05', '-', 'MU003', GETDATE(), null),	
	(null, 'Cristiano Ronaldo', '1985-02-05', 'Forward, Captain', 'CR7', GETDATE(), NULL),
	(null, 'Lionel Messi', '1987-06-24', 'Forward, Playmaker', 'M10', GETDATE(), NULL);

	INSERT INTO Account (username, email, password, Role, Status, Name, Dob, gender, phone)
VALUES 
('admin_user', 'admin@example.com', 'hashed_admin_password', 'ADMIN', 'Active', 'Admin Name', '1985-01-01', 'Male', '1234567890'),
('staff_user1', 'staff1@example.com', 'hashed_staff_password1', 'STAFF', 'Active', 'Staff One', '1990-05-10', 'Female', '0987654321'),
('staff_user1', 'staff2@example.com', 'hashed_staff_password2', 'STAFF', 'Active', 'Staff Two', '1992-08-15', 'Male', '1122334455');

INSERT INTO TournamentClub (id_Tournament, id_Club, createDate, createAccount)
VALUES 
(1, 1, GETDATE(), 1), -- Linking Tournament ID 1 with Club ID 1
(1, 2, GETDATE(), 1), -- Linking Tournament ID 1 with Club ID 2
(2, 1, GETDATE(), 1)
