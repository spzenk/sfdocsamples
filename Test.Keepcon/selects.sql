
--USE BB_MovistarSM_Logs

--SELECT *  FROM dbo.KeepconPost ORDER BY postid desc
--SELECT * FROM dbo.KeepconPost WHERE dbo.KeepconPost.MESSAGE LIKE '%free%'
DECLARE  @Total INT

DECLARE  @Enviados INT
DECLARE  @Enviar INT

SELECT @Total = COUNT(*) FROM dbo.KeepconPost 

SELECT  @Total AS 'Total'

--Enviados
SELECT @Enviados  = COUNT(*)  FROM dbo.KeepconPost WHERE  keepcon_send_setId IS NOT NULL

SELECT @Enviados AS 'Enviados' 

SET @Enviar = @Total  - @Enviados
SELECT @Enviar AS 'Falta enviar'


DECLARE  @Enviados_Con_Resultados INT
--Enviados con resultado
SELECT  @Enviados_Con_Resultados = COUNT(*)  FROM dbo.KeepconPost WHERE  keepcon_result_resived_date IS NOT NULL
SELECT @Enviados_Con_Resultados AS 'Enviados con resultado'



SELECT  AVG(DATEDIFF(second,[keepcon_send_date] ,[keepcon_result_resived_date])) AS '[Media de respuesta (seg)]'
  FROM [dbo].[KeepconPost]
WHERE keepcon_moderator_decision IS NOT NULL AND postid  NOT IN(1342162,1342164,1342165 )

SELECT  max(DATEDIFF(second,[keepcon_send_date] ,[keepcon_result_resived_date])) AS '[Maximo tiempo (seg)]'
  FROM [dbo].[KeepconPost]
WHERE keepcon_moderator_decision IS NOT NULL  AND postid  NOT IN(1342162,1342164,1342165 )

SELECT  min(DATEDIFF(second,[keepcon_send_date] ,[keepcon_result_resived_date])) AS '[Minimo tiempo (seg)]'
  FROM [dbo].[KeepconPost]
WHERE keepcon_moderator_decision IS NOT NULL


--deteccion de tiempos altos
--SELECT  postid,DATEDIFF(second,[keepcon_send_date] ,[keepcon_result_resived_date]) 
--  FROM [dbo].[KeepconPost]
--WHERE DATEDIFF(second,[keepcon_send_date] ,[keepcon_result_resived_date]) > 2000

/*
SELECT  count(*) AS Post_Count FROM [dbo].[KeepconPost] WHERE keepcon_moderator_decision IS NOT NULL

SELECT  [keepcon_send_date], DATEDIFF(second,[keepcon_send_date] ,[keepcon_result_resived_date]) AS '[send_date - result_resived_date]'
  FROM [dbo].[KeepconPost]
WHERE keepcon_moderator_decision IS NOT NULL

SELECT [keepcon_send_date] ,[keepcon_moderator_date], DATEDIFF(second,[keepcon_send_date] ,[keepcon_moderator_date]) AS 'send_date - moderator_date'
  FROM [dbo].[KeepconPost]
WHERE keepcon_moderator_decision IS NOT NULL
*/



