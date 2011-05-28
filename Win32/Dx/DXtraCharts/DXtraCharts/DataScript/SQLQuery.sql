----------------------------------Monto de ventas anuales
SELECT    year( Sales.SalesOrderHeader.OrderDate) as [Year],
sum(Sales.SalesOrderDetail.UnitPrice) as  TotalAmount
FROM         Sales.SalesOrderDetail INNER JOIN
                      Sales.SalesOrderHeader ON Sales.SalesOrderDetail.SalesOrderID = Sales.SalesOrderHeader.SalesOrderID
group by year( Sales.SalesOrderHeader.OrderDate)
order by [Year]

-----------------------Monto de ventas por año y por producto
SELECT    
		Production.Product.Name, 
		Production.Product.ProductID,
		year( Sales.SalesOrderHeader.OrderDate) as [Year],
		Sum(Sales.SalesOrderDetail.UnitPrice) as TotalAmount
FROM         Sales.SalesOrderDetail 
INNER JOIN            Sales.SalesOrderHeader ON Sales.SalesOrderDetail.SalesOrderID = Sales.SalesOrderHeader.SalesOrderID 
INNER JOIN            Production.Product ON Sales.SalesOrderDetail.ProductID = Production.Product.ProductID

group by 
year( Sales.SalesOrderHeader.OrderDate)
,Production.Product.Name
,Production.Product.ProductID

order By Production.Product.Name,[Year]