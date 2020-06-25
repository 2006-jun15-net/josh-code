-- basic exercises (Chinook database)
-- 1. list all customers (full names, customer ID, and country) who are not in the US
-- 2. list all customers from brazil
-- 3. list all sales agents
-- 4. show a list of all countries in billing addresses on invoices.
-- 5. how many invoices were there in 2009, and what was the sales total for that year?
--    (extra challenge: find the invoice count sales total for every year, using one query)
-- 6. how many line items were there for invoice #37?
-- 7. how many invoices per country?
-- 8. show total sales per country, ordered by highest sales first.
-- SELECT * FROM Track;

SELECT FirstName, LastName, CustomerId, Country FROM Customer WHERE NOT Country = 'USA' ;

Select * FROM Customer WHERE Country = 'Brazil';

SELECT * FROM Employee WHERE Title = 'Sales Support Agent';

SELECT DISTINCT BillingCountry FROM Invoice;

SELECT COUNT(InvoiceDate) AS InvoiceCount, Sum(Total) AS Total FROM Invoice WHERE InvoiceDate LIKE '%2009%';

SELECT COUNT(*) FROM InvoiceLine WHERE InvoiceId = '37';

SELECT BillingCountry, COUNT(*) FROM Invoice GROUP BY BillingCountry;

SELECT BillingCountry, SUM(Total) AS TotalSales FROM Invoice GROUP BY BillingCountry ORDER BY TotalSales DESC;


-- join exercises (Chinook database)
-- 1. show all invoices of customers from brazil (mailing address not billing)
-- 2. show all invoices together with the name of the sales agent of each one
-- 3. show all playlists ordered by the total number of tracks they have
-- 4. which sales agent made the most in sales in 2009?
-- 5. how many customers are assigned to each sales agent?
-- 6. which track was purchased the most since 2010?
-- 7. show the top three best-selling artists.
-- 8. which customers have the same initials as at least one other customer?

SELECT * FROM Invoice LEFT JOIN Customer ON Invoice.CustomerId = Customer.CustomerId WHERE Customer.Country='Brazil';

SELECT * FROM Invoice LEFT JOIN Customer;
