--Select product with product name that begins with ‘C’.
SELECT * FROM Products WHERE ProductName like 'C%';

--Select product with the smallest price.
SELECT *  FROM Products WHERE Price=(SELECT MIN(Price) FROM Products);

--Select cost of all products from the USA.
SELECT SUM(Price) FROM Products 
JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID 
WHERE Suppliers.Country = 'USA';

--Select suppliers that supply Condiments.
SELECT DISTINCT SupplierName FROM Suppliers 
JOIN Products ON Suppliers.SupplierID = Products.SupplierID
JOIN Categories ON Products.CategoryID = Categories.CategoryID 
WHERE Categories.CategoryName = 'Condiments';

--Insert
BEGIN;
INSERT INTO Suppliers (SupplierName, City,Country)
  VALUES('Norske Meierier', 'Lviv','Ukraine');
INSERT INTO Products (ProductName, SupplierID, CategoryID, Price) 
  VALUES('Green tea', SCOPE_IDENTITY (),(SELECT CategoryID FROM Categories WHERE CategoryName = 'Beverages'), 10.);
END;
