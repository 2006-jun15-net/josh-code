CREATE TABLE EXDepartment
	(
		ID int NOT NULL,
		Name nvarchar (255) NOT NULL,
		Location varchar (255),
		PRIMARY KEY(ID)
	);

CREATE TABLE EXEmployee
	(
		ID int NOT NULL,
		FirstName nvarchar (255) NOT NULL,
		LastName nvarchar (255) NOT NULL,
		SSN varchar (9) NOT NULL UNIQUE,
		DeptID int NOT NULL,
		PRIMARY KEY(ID),
		FOREIGN KEY (DeptID) REFERENCES EXDepartment (ID) 
	);

CREATE TABLE EXEmpDetails
	(
		ID int NOT NULL,
		EmployeeID int NOT NULL,
		Salary money NOT NULL,
		Address_1 nvarchar (255),
		Address_2 nvarchar (255),
		City varchar (255),
		State varchar (255),
		Country varchar (255)
		PRIMARY KEY (ID)
		FOREIGN KEY (EmployeeID) REFERENCES EXEmployee (ID) 
	);

--DROP TABLE EXEmpDetails, EXEmployee, EXDepartment;


INSERT INTO EXDepartment (ID, Name, Location) 
	VALUES 
		(1, 'Software Development', '3rd Floor'),
		(2, 'Network Infrastructure', '2nd Floor'),
		(3, 'Sales', '1st Floor');

INSERT INTO EXEmployee (ID, FirstName, LastName, SSN, DeptID)
	VALUES 
		(1, 'Josh', 'Bertrand', 123456 ,1),
		(2, 'Elon', 'Musk', 654321, 3),
		(3, 'Gergen', 'Frampt',999999999 ,1);

INSERT INTO EXEmpDetails (ID, EmployeeID, Salary, Address_1, Address_2, City, State, Country)
	VALUES
		(1, 1, 100000, '123 ONMYWAY Road', '', 'Eureka', 'Nevada', 'USA'),
		(2, 2, 30000000, '135 Space Way', '', 'San Fran', 'California', 'USA'),
		(3, 3, 500000, '534 Hadron Ring', '', 'Geneva', '', 'Switzerland');