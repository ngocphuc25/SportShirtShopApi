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
    note NVARCHAR(100) null,
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



CREATE TABLE TournamentClub (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_Tournament INT,
    id_Club INT,
    createDate DATETIME,
    createAccount INT,
    FOREIGN KEY (id_Tournament) REFERENCES Tournament(id),
    FOREIGN KEY (id_Club) REFERENCES Club(id)
);


CREATE TABLE ShirtEdition (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_TournamentClub INT,
    nameseason NVARCHAR(MAX),
	color NVARCHAR(MAX),
	Material NVARCHAR(MAX),
	versionForMatch NVARCHAR(MAX),
    status NVARCHAR(MAX),
    note NVARCHAR(MAX) null,
    code NVARCHAR(MAX),
    createDate DATETIME,
    createAccount INT,
    FOREIGN KEY (id_TournamentClub) REFERENCES TournamentClub(id)
);
CREATE TABLE PlayerInTournamentClub (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_TournamentClub INT,
    id_Player INT,
    Number INT,
    PlayerName NVARCHAR(MAX),
    SeasonName NVARCHAR(MAX),
    ClubName NVARCHAR(MAX),
    Description NVARCHAR(MAX) null,
    FOREIGN KEY (id_TournamentClub) REFERENCES TournamentClub(id),
    FOREIGN KEY (id_Player) REFERENCES Player(id)
);

CREATE TABLE Shirt (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_shirtEdition INT  ,
    id_PlayerinTournamentClub INT null,
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

INSERT INTO Account (username, email, password, Role, Status, Name, Dob, gender, phone)
VALUES 
('admin_user', 'admin@example.com', 'hashed_admin_password', 'ADMIN', 'ACTIVE', 'Admin Name', '1985-01-01', 'Male', '1234567890'),
('staff_user1', 'staff1@example.com', 'hashed_staff_password1', 'STAFF', 'ACTIVE', 'Staff One', '1990-05-10', 'Female', '0987654321'),
('staff_user1', 'staff2@example.com', 'hashed_staff_password2', 'STAFF', 'ACTIVE', 'Staff Two', '1992-08-15', 'Male', '1122334455'),
('admin1', 'admin@gmail.com', 'admin', 'ADMIN', 'ACTIVE', 'Admin Name', '1985-01-01', 'Male', '1234567890'),
('staff1', 'saaa@example.com', '123', 'STAFF', 'ACTIVE', 'Staff Two', '1992-08-15', 'Male', '1122334455');


INSERT INTO Club (Name, Logo, Status, Note, Code, CreateDate, CreateAccount)
VALUES 
    ('Manchester United', 'https://upload.wikimedia.org/wikipedia/vi/thumb/a/a1/Man_Utd_FC_.svg/800px-Man_Utd_FC_.svg.png', 'Active', '-', 'MU', GETDATE(), null), ---1
    ('Real Madrid', 'https://upload.wikimedia.org/wikipedia/vi/thumb/a/a1/Man_Utd_FC_.svg/363px-Man_Utd_FC_.svg.png', 'Active', '-', 'REAL', GETDATE(), null), ----2
    ('Manchester City', 'https://upload.wikimedia.org/wikipedia/en/thumb/e/eb/Manchester_City_FC_badge.svg/285px-Manchester_City_FC_badge.svg.png', 'Active', '-', 'MC', GETDATE(), 1),----3
    ('Chelsea', 'https://upload.wikimedia.org/wikipedia/en/thumb/c/cc/Chelsea_FC.svg/285px-Chelsea_FC.svg.png', 'Active', '-', 'CHEL', GETDATE(), NULL),------4
	('Al Nassr FC','https://upload.wikimedia.org/wikipedia/vi/9/9d/Logo_Al-Nassr.png','Active','-',N'đội bóng có cr7',Getdate(),Null),---------5
	('Inter Miami CF','https://upload.wikimedia.org/wikipedia/vi/thumb/5/5c/Inter_Miami_CF_logo.svg/285px-Inter_Miami_CF_logo.svg.png','Active','-',N'đội có M10',GETDATE(),1), ---------6
	('Arsenal','https://upload.wikimedia.org/wikipedia/vi/thumb/5/53/Arsenal_FC.svg/270px-Arsenal_FC.svg.png','Active','-',N'Pháo thủ',GETDATE(),1);------------------7
INSERT INTO Tournament (StartDate, EndDate, Name, Status, Description, Note, Code, CreateDate, CreateAccount)
VALUES
    ('2024-08-11', '2024-05-19', '2023-24 Premier League', 'Completed', N'Giải ngoại hạng Anh 23-24', 'Manchester City is a champion', 'P2324', GETDATE(), null), ----1
    ('2022-8-5', '2023-5-28', '2022–23 Premier League', 'Completed', N'Giải ngoại hạng Anh 22-23', 'Manchester City is a champion', 'P2223', GETDATE(), null), ----2
    ('2024-08-28', '2023-5-31', '2024–25 UEFA Champions League', 'Active', N'Champions League 24-25', '-', 'CL2425', GETDATE(), null), ----3
	('2023-1-1','2024-1-1','2023-24 Saudi Professional League','Completed',N'Giải bóng đá chuyên nghiệp Ả Rập Xê Út','-','a',GETDATE(),1), ---4
	('2023-1-1','2024-1-1','2023-24 Major League Soccer','Completed',N'Giải bóng đá nhà nghề Mỹ','-','NFL',GETDATE(),1), ----5
	('2024-8-16','2025-5-25','2024-25 Premier League','Active',N'Ngoại hạng anh 24-25','-','P2425',GETDATE(),1);-----6
INSERT INTO Player (id_Club, Name, Dob, Note, Code, CreateDate, CreateAccount)
VALUES
    (1, 'Marcus Rashford', '1997-10-31', '-', 'MU001', GETDATE(), 1), --1
    (1, 'Bruno Fernandes', '1994-09-08', '-', 'MU002', GETDATE(), 1), --2
    (1, 'Harry Maguire', '1993-03-05', '-', 'MU003', GETDATE(), 1), --3
	(5, 'Cristiano Ronaldo', '1985-02-05', 'Forward, Captain', 'CR7', GETDATE(), 1), --4
	(6, 'Lionel Messi', '1987-06-24', 'Forward, Playmaker', 'M10', GETDATE(), 1), ---5
	 (4, 'Thiago Silva', '1984-09-22', 'Defender, Experienced Leader', 'SILV', GETDATE(), 1), ----6
    (4, N'Golo Kante', '1991-03-29', 'Midfielder, Playmaker' , 'KANT', GETDATE(), 1), -----7
	(1, 'Mason Mount', '1999-01-10',  'English midfielder','MM', GETDATE(), 1), ---8
	(7, 'Martin Odegaard', '1998-12-17', '-----', 'ODE', GETDATE()-1, 1),--------9
	(7, 'Raheem Sterling', '1994-12-8', 'Captain of Arsenal', 'STERL', GETDATE()-1, 1);--------10
	
	
INSERT INTO TournamentClub (id_Tournament, id_Club, createDate, createAccount)
VALUES 
(1, 1, GETDATE(), 1), -- Linking Tournament ID 1 with Club ID 1 ---1
(1, 3, GETDATE(), 1), ---2
(1, 4, GETDATE(), 1),     --------3
(2, 1, GETDATE(), 1), -- Linking Tournament ID 1 with Club ID 1     ----------4
 (2, 3, GETDATE(), 1),        -------------5
(2, 4, GETDATE(), 1),
(2,5,GETDATE(),1),-------------7
(5,6,Getdate(),1),
(6,1,Getdate(),1),---------------9
(6,4,Getdate(),1),
(6,7,Getdate(),1);--------------------11

INSERT INTO PlayerInTournamentClub (id_TournamentClub, id_Player, Number, PlayerName, SeasonName, ClubName, Description)
VALUES
	(1, 1, 10, 'Marcus Rashford', '2023-24 Premier League', 'Manchester United', 'Forward, Star Player'),--------1
	(9, 1, 10, 'Marcus Rashford', '2024-25 Premier League', 'Manchester United', 'Forward, Star Player'),-----------2
    (9, 2, 8, 'Bruno Fernandes', '2024-25 Premier League', 'Manchester United', 'Midfielder, Playmaker'),----------3
    (2, 4, 7, 'Cristiano Ronaldo', '2023-24 Saudi Professional League', 'Al-Nassr', 'Forward, Captain'),-----------4
    (3, 5, 10, 'Lionel Messi', '2023-24 Major League Soccer', 'Paris Saint-Germain', 'Forward, Playmaker'),-----------5
    (5, 8, 19, 'Mason Mount', '2022–23 Premier League', 'Chelsea', 'Midfielder'),--------------6
    (4, 6, 6, 'Thiago Silva', '2023/2024', 'Chelsea', 'Defender, Experienced Leader'),----------7
	(9,8, 7,	'Mason Mount', '2024–25 Premier League', 'Manchester United', 'Midfielder'),------------8
	 (11, 9, 8, 'Martin Odegaard', '2024–25 Premier League', 'Arsenal', 'Midfielder, Experienced Leader'),------------9
	 (11, 10, 30, 'Raheem Sterling', '2024–25 Premier League', 'Arsenal', 'Winger, Experienced Leader');--------------10

 INSERT INTO ShirtEdition ( id_TournamentClub, nameseason,  color, Material,  versionForMatch,   status, note,  code,  createDate,  createAccount)
VALUES 
(    3, '2023-24 Premier League','Blue','Away edition',  'Cotton','Active', 'Limited edition for the 2023/24 season', 'R001',    GETDATE(), 1 ),----1
(    1, '2023-24 Premier League','Red', 'Home edition' ,'Cotton','Active', 'Limited edition for the 2023/24 season', 'R002',    GETDATE(), 1 ),-----2
(    1, '2023-24 Premier League','Blue', 'Away edition' ,'Cotton','Active', 'Limited edition for the 2023/24 season', 'R003',    GETDATE(), 1 ),---------3
(    1, '2023-24 Premier League','White', 'Third edition' ,'Cotton','Active', 'Limited edition for the 2023/24 season', 'R002',    GETDATE(), 1 ),--------4
(   11 , '2024-25 Premier League','Red', 'Home edition' ,'Cotton','Active', 'Limited edition for the 2024/25 season', 'ARS01',    GETDATE(), 1 ),---------5
(   11, '2024-25 Premier League','Black', 'Away edition' ,'Cotton','Active', 'Limited edition for the 2024/25 season', 'ARS02',    GETDATE(), 1 ),--------6
(    11, '2024-25 Premier League','Blue', 'Third edition' ,'Cotton','Active','Limited edition for the 2024/25 season', 'ARS03',    GETDATE(), 1 ),------------7
(   9 , '2024-25 Premier League','Red', 'Home edition' ,'Cotton','Active', 'Limited edition for the 2023/24 season', 'R002',    GETDATE(), 1 );--------8


INSERT INTO Shirt (id_shirtEdition, id_PlayerinTournamentClub, name,price, salePrice, totalSold,description, quantity_stock, status,code,createDate,createAccount, updatedDate)
VALUES 

(   1,  6,'Mason Mount 2024 Jersey',10000, 5000, 0,'Limited edition shirt for the 2024 season featuring Mason Mount',100, 'Active','CHELSEA00019',GETDATE(), 1  ,GETDATE() ),-------1
(   2,  null,'Manchester United 23/24 Home Jersey',10000, 5000, 0,'Manchester United 23/24 Home Jersey',100, 'Active','MU0001',GETDATE(), 1  ,GETDATE() ),----------2
(   3,  null,'Manchester United 23/24 Away Jersey',10000, 5000, 0,N'Siêu đẹp luôn',100, 'Active','MU0002',GETDATE(), 1  ,GETDATE() ),-----------3
(   4,  null,'Manchester United 23/24 Third Jersey',10000, 5000, 0,'Manchester United 23/24 Third Jersey',100, 'Active','MU0003',GETDATE(), 1  ,GETDATE() ),---------4
(   5,  null,'ARSENAL 24/25 Home Jersey',10000, 5000, 0,'ARSENAL 24/25 Home Jersey',100, 'Active','ARS01',GETDATE(), 1  ,GETDATE() ),-----------------5
(   6,  null,'ARSENAL 24/25 Away Jersey',10000, 5000, 0,'ARSENAL 24/25 Away Jersey',100, 'Active','ARS02',GETDATE(), 1  ,GETDATE() ),------------------6
(   7,  null,'ARSENAL 24/25 Third Jersey',10000, 5000, 0,'ARSENAL 24/25 Third Jersey',100, 'Active','ARS03',GETDATE(), 1  ,GETDATE() ),-------------7
(   7,  9,'ARSENAL 24/25 Third Jersey',10000, 5000, 0,'ARSENAL 24/25 Third Jersey',100, 'Active','ARS03',GETDATE(), 1  ,GETDATE() ),------------8
(   7,  10,'ARSENAL 24/25 Third Jersey',10000, 5000, 0,'ARSENAL 24/25 Third Jersey',100, 'Active','ARS03',GETDATE(), 1  ,GETDATE() ),-----------------9
( 8,  8,' Mason Mount Manchester United 24/25 Third Jersey',10000, 5000, 0,N'Limited',100, 'Active','MU0004',GETDATE(), 1  ,GETDATE() ),--------------------10
( 8,  2,' Marcus Rashford Manchester United 24/25 Third Jersey',10000, 5000, 0,N'Limited',100, 'Active','MU0004',GETDATE(), 1  ,GETDATE() ),----------11
( 8,  3,' Bruno Fernandes Manchester United 24/25 Third Jersey',10000, 5000, 0,N'Limited',100, 'Active','MU0004',GETDATE(), 1  ,GETDATE() );-------------12
INSERT INTO Image( link,id_Shirt)
values
('https://mufc-live.cdn.scayle.cloud/images/8ed8c14d2c334556c14da1116ba32a50.jpg?brightness=1&width=576&height=768&quality=75&bg=ffffff',2),
('https://metro.co.uk/wp-content/uploads/2023/07/Mount-853c_1688711331.png',10),
('https://mufc-live.cdn.scayle.cloud/images/9d8b1e35abd676645560a4bce2b86dca.jpg?brightness=1&width=1536&height=2048&quality=75&bg=ffffff',4),
('https://mufc-live.cdn.scayle.cloud/images/e8a92d15e1b75bb7994cb4c7ec3fd30c.jpg?brightness=1&width=576&height=768&quality=75&bg=ffffff',3),
('https://images.footballfanatics.com/chelsea/mens-nike-mason-mount-blue-chelsea-2021/22-home-vapor-match-authentic-player-jersey_pi4309000_altimages_ff_4309686-3d6a40133a4042442260alt1_full.jpg?_hv=2&w=900',1),
('https://product.hstatic.net/200000477321/product/tai_xuong_-_2024-11-29t102140.217_70d8f617fe9841978a1e666ee2eb7e13_grande.png',5),
('https://i1.adis.ws/i/ArsenalDirect/miz0114_f1',7),
('https://i1.adis.ws/i/ArsenalDirect/mit6148_f1',6),
('https://i1.adis.ws/i/ArsenalDirect/mit6148_f1',8),
('https://i1.adis.ws/i/ArsenalDirect/mit6148_f1',9),
('https://i1.adis.ws/i/ArsenalDirect/mit6148_f1',10),
('https://mufc-live.cdn.scayle.cloud/images/9d8b1e35abd676645560a4bce2b86dca.jpg?brightness=1&width=1536&height=2048&quality=75&bg=ffffff',12),
('https://mufc-live.cdn.scayle.cloud/images/9d8b1e35abd676645560a4bce2b86dca.jpg?brightness=1&width=1536&height=2048&quality=75&bg=ffffff',11);






