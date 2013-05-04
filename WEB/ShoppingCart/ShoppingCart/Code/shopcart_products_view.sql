SELECT  
          dbo.articulo.idart,
		   dbo.articulo.idcate, 
		  dbo.codbarra.prevta, 
		  dbo.articulo.denom,
		   dbo.codbarra.idpais

FROM  dbo.articulo INNER JOIN
               dbo.codbarra ON dbo.articulo.idart = dbo.codbarra.idart
WHERE (dbo.codbarra.habilitado = 3) AND (dbo.articulo.habilitado = 3)
ORDER BY dbo.articulo.idart