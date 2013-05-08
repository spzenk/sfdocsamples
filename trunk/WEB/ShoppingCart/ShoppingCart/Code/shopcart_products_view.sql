SELECT DISTINCT 
 dbo.articulo.idart, 
 dbo.articulo.idcate, 
 dbo.codbarra.prevta, 
 dbo.articulo.denom, 
 dbo.marcas.denom AS Marca
FROM  dbo.articulo 
INNER JOIN  dbo.codbarra ON dbo.articulo.idart = dbo.codbarra.idart 
INNER JOIN  dbo.marcas ON dbo.articulo.idmarca = dbo.marcas.idmarca
WHERE (dbo.codbarra.habilitado = 3) AND (dbo.articulo.habilitado = 1)
ORDER BY dbo.articulo.denom