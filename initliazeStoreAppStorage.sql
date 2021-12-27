
--SELECT * from Addresses;
--SELECT * from Customers;
--SELECT * from Orders;

--drop in this order because of FK References
--DROP TABLE Orders;
--DROP TABLE Customers;
--DROP TABLE Addresses;

--TRUNCATE TABLE Orders;
--TRUNCATE TABLE Customers;
--TRUNCATE TABLE Addresses;

CREATE DATABASE p0_StoreApp;

CREATE TABLE Products(
ProductID INT PRIMARY KEY IDENTITY,
ProductName nvarchar(50) NOT NULL,
ProductPrice MONEY NOT NULL,
ProductDesc nvarchar(400) NOT NULL);

CREATE TABLE Stores(
StoreID INT PRIMARY KEY IDENTITY,
StoreName nvarchar(50) NOT NULL,
StoreLoc nvarchar(50) NOT NULL);

CREATE TABLE Inventory(--Should have storeID as FK because you can have same items at different quantities at different stores; each store only has one inventory made up of many items
InventoryID INT PRIMARY KEY IDENTITY,
ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
Quantity INT NOT NULL,
StoreID INT NOT NULL FOREIGN KEY REFERENCES Stores(StoreID) ON DELETE CASCADE);

--CREATE TABLE Cart(--unique to Customer; actually this probably isn't even needed to be stored, just do it in C# as temp then store after purchase
--CartID INT PRIMARY KEY IDENTITY,
--ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
--Quantity INT NOT NULL);

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY IDENTITY,
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(15) NOT NULL);
--CartID INT Not NULL FOREIGN KEY REFERENCES Cart(CartID) ON DELETE CASCADE);

CREATE TABLE PastSales(--should have no rows on first initalization
PastSalesID INT PRIMARY KEY IDENTITY,
ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
Quantity INT NOT NULL,
OrderDate date NOT NULL,
totalAmount MONEY NOT NULL,
CustomerID INT NULL FOREIGN KEY REFERENCES Customers(CustomerID) ON DELETE CASCADE, --will get list of PastSales for specific Customer using this FK
StoreID INT NULL FOREIGN KEY REFERENCES Stores(StoreID) ON DELETE CASCADE); --will get list of PastSales for specific Store using this FK

CREATE TABLE Orders(--this probably also doesn't need to be stored in sql
OrderId INT PRIMARY KEY IDENTITY NOT NULL,
CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerId) ON DELETE CASCADE,
OrderDate date NOT NULL, --will be generated to add to PastSales once purchase goes through
totalAmount MONEY NOT NULL); --totalAmount comes from Cart

--insert to tables in this order because of FK References
--bikes
INSERT INTO Products (ProductName, ProductPrice, ProductDesc) 
VALUES ('Old Bike', 39.99, 'A trusty refurbished bike which is in dire need of a paint job.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Miracle Cycle', 499.99, 'A bike so overpriced, you''d think it was meant to deter 10 year olds from speeding through routes.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Miracle Cycle V', 00.01, 'An upgraded model that is meant to be exchanged for a Voucher.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Rydel''s Cycle', 19.99, 'A grossly underpriced bike that serves as advertisement.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES('Mach Bike', 125.00, 'Warp Speed!');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Acro Bike', 125.00, 'It jumps ledges so you don''t have to!');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES('Radical Rickshaw', 160.88, 'If you ignore the fact it''s a rickshaw, this bike will serve you very well.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES('Harlequin''s Bike', 269.99, 'Was this bike stolen?');

--clothing
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('THE Jacket', 499.99, 'More drip than the River Thames.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('THE T-shirt', 169.99, 'There''s not even a logo?');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('THE Hoodie', 219.99, 'The power of BRANDING.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('THE Sweatpants', 97.79, 'They''re like socks for your legs.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Golden Wind', 199.99, 'Why do I hear music, where are the speakers? 10/10');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Silver Moon Headband', 17.49, 'As seen on the Chris Rock Impersonators Show');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Just a Suit', 74.99, 'Not a custom-fit but worth every penny');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Sewing Kit', 69.99, 'Who sews nowadays anyways');

--shoes
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Boots of Mobility', 8.50, 'The classic. Lets you run straight into the enemy.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Swifties', 9.00, 'Not even your teammates can slow you down now!');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Merc Treads', 11.00, 'Go where you please(s).');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Ninja Tabi''s', 11.00, 'Ninja''s don''t wear steel capped shoes.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Boots of Lucidity', 9.50, 'Am I dreaming or did you just do that again?');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Sorceror''s Shoes', 10.99, 'True magic lies in the heart.');
INSERT INTO Products (ProductName, ProductPrice, ProductDesc)  
VALUES ('Berserker''s Greaves', 11.49, 'Why do they cost more? Why not.');

--store init
INSERT INTO Stores (StoreName, StoreLoc)
VALUES ('WePokeBikes', 'Northern Ward');
INSERT INTO Stores (StoreName, StoreLoc)
VALUES ('Golden Threads', 'Southern Ward');
INSERT INTO Stores (StoreName, StoreLoc)
VALUES ('sh0EZsh0p', 'Eastern Ward');


--base inventory
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (1, 15, 1);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (2, 15, 1);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (3, 15, 1);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (4, 15, 1);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (5, 15, 1);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (6, 15, 1);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (7, 15, 1);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (8, 15, 1);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (9, 15, 2);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (10, 15, 2);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (11, 15, 2);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (12, 15, 2);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (13, 15, 2);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (14, 15, 2);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (15, 15, 2);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (16, 15, 2);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (17, 47, 3);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (18, 83, 3);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (19, 61, 3);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (20, 79, 3);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (21, 99, 3);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (22, 95, 3);
INSERT INTO Inventory (ProductID, Quantity, StoreID)
VALUES (23, 105, 3);
