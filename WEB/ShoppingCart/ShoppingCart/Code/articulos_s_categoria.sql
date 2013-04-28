
--created BY Pelsoft SF 
-- www.pelsfoft.net
alter PROCEDURE Articulos_s_categoria

@idcate INT =NULL
AS


SELECT 
	dbo.articulo.idart, 
	dbo.articulo.idcate, 
	dbo.codbarra.prevta AS 'precio', 
	dbo.articulo.denom, 
	dbo.codbarra.idpais, 
	dbo.codbarra.margen
FROM  dbo.articulo 
INNER JOIN dbo.codbarra ON dbo.articulo.idart = dbo.codbarra.idart
WHERE  (@idcate IS NOT NULL ) or (dbo.articulo.idcate = @idcate)