SELECT DISTINCT  dbo.articulo.idart, dbo.articulo.idcate, dbo.codbarra.prevta, dbo.articulo.denom, dbo.codbarra.idpais, dbo.codbarra.margen
FROM  dbo.articulo INNER JOIN
               dbo.codbarra ON dbo.articulo.idart = dbo.codbarra.idart
ORDER BY dbo.articulo.idart