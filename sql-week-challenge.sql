CREATE TABLE Customers 
(
    Id int PRIMARY KEY,
    FirstName nvarchar(20) NOT NULL,
    LastName nvarchar(30) NOT NULL
    CardNumber nvarchar(10) NULL CHECK(LEN(CardNumber) == 10)
);

CREATE TABLE Products
(
    Id int PRIMARY KEY,
    Name nvarchar(30) NOT NULL,
    Price decimal(5, 2) NOT NULL
);

CREATE TABLE Orders
(
    Id int PRIMARY KEY,
    ProductID int FOREIGN KEY,
    CustomerID int FOREIGN KEY
);

INSERT INTO Customers (Id, FirstName, LastName, CardNumber) VALUES 
(
    (1, "Josh", "Bertrand", "1234567890"),
    (2, "John", "Doe", "5452689542"),
    (3, "Jane", "Doeh", "7832564854")
);

INSERT INTO Products (Id, Name, Price) VALUES 
(
    (1, "Laptop", 750.99),
    (2, "Batteries", 2.99),
    (3, "Keyboard", 25.99)
);

INSERT INTO Orders (Id, ProductID, CustomerID) VALUES 
(
    (1, 1, 1),
    (2, 2, 3),
    (3, 3, 1)
);

INSERT INTO Products (Id, Name, Price) VALUES 
(
    (4, "iPhone", 200.00)
);

INSERT INTO Customers (Id, FirstName, LastName, CardNumber) VALUES 
(
    (4, "Tina", "Smith", "1234567890")
);

INSERT INTO Orders (Id, ProductID, CustomerID) VALUES 
(
    (4, 
    SELECT Id FROM Products Where Name = "iPhone",
    SELECT Id FROM Customers Where FirstName = "Tina" AND LastName = "Smith"
    )
);

SELECT * FROM Orders Where FirstName = "Tina" AND LastName = "Smith";

SELECT SUM(Price) FROM Products WHERE (SELECT COUNT(*) FROM Orders WHERE ProductID = (SELECT ProductID FROM Products WHERE Name = "iPhone"));

ALTER TABLE Products 
(
    SET Price = 250.00
); 