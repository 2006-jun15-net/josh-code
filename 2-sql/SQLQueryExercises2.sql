-- exercises
-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?
-- 2. which artists did not record any tracks of the Latin genre?
-- join version
-- 3. which video track has the longest length? (use media type table)
-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)
-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?
-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.

SELECT ar.*
FROM Artist AS ar
	LEFT JOIN Album AS al ON ar.ArtistId = al.ArtistId
WHERE al.AlbumId IS NULL;

SELECT *
FROM Artist
WHERE ArtistId not IN (
	SELECT ArtistId 
	FROM Album 
	WHERE AlbumId IS not NULL
);

----------------------------------------------------------
SELECT * FROM Artist
EXCEPT
SELECT ar.*
FROM Artist AS ar
	INNER JOIN Album AS al ON ar.ArtistId = al.ArtistId
	LEFT JOIN Track AS t ON al.AlbumId = t.AlbumId
	LEFT JOIN Genre AS g ON t.GenreId = g.GenreId
WHERE g.Name = 'Latin';

-- 1. insert two new records into the employee table.
-- 2. insert two new records into the tracks table.
-- 3. update customer Aaron Mitchell's name to Robert Walter
-- 4. delete one of the employees you inserted.
-- 5. delete customer Robert Walter.

INSERT INTO Employee (EmployeeId, LastName, FirstName) 
	VALUES 
		(2000, 'Bertrand', 'Josh'),
		(2001, 'Musk', 'Elon');

INSERT INTO Track (TrackId, Name, MediaTypeId, Milliseconds, UnitPrice) 
	VALUES
		(10001, 'Track Name', 1, 500, 150.00),
		(10002, 'Untitled', 1, 500, 151.00);

UPDATE Customer
	SET FirstName = 'Robert', LastName = 'Walter'
	WHERE FirstName = 'Aaron' AND LastName = 'Mitchell';

DELETE Employee
	WHERE EmployeeId = 2001;

DELETE Customer
	WHERE FirstName = 'Robert' AND LastName = 'Walter';
