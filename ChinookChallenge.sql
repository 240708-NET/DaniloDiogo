-- List all customers (full name, customer id, and country) who are not in the USA
SELECT * FROM Customer c 
	WHERE c.Country <> 'USA'
	
-- List all customers from Brazil
SELECT * FROM Customer c 
	WHERE c.Country = 'Brazil'
	
-- List all sales agents
SELECT * FROM Employee e
	WHERE e.Title = 'Sales Support Agent'
	
-- Retrieve a list of all countries in billing addresses on invoices
SELECT i.BillingCountry FROM Invoice i 

-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
    -- (challenge: find the invoice count sales total for every year using one query)
SELECT COUNT(*) as count, SUM(i.Total) as total FROM Invoice i 
	WHERE i.InvoiceDate BETWEEN '2009-01-01' and '2009-12-31'

-- how many line items were there for invoice #37
SELECT COUNT(*) FROM InvoiceLine il
	WHERE il.InvoiceId = 37

-- how many invoices per country? BillingCountry  # of invoices -
SELECT CONCAT(i.BillingCountry, ' #',COUNT(*), ' of invoices') FROM Invoice i 
	GROUP BY i.BillingCountry 

-- Retrieve the total sales per country, ordered by the highest total sales first.
SELECT i.BillingCountry, SUM(i.Total) as total FROM Invoice i 
	GROUP BY i.BillingCountry
	ORDER BY total DESC
