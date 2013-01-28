--USE BB_MovistarSM_Logs
SELECT COUNT(*) FROM dbo.KeepconPost 
SELECT *  FROM dbo.KeepconPost ORDER BY postid desc
SELECT * FROM dbo.KeepconPost WHERE dbo.KeepconPost.MESSAGE LIKE '%free%'
--No enviados
SELECT COUNT(*) FROM dbo.KeepconPost WHERE keepcon_send_setId IS  NULL
--Enviados
SELECT COUNT(*) FROM dbo.KeepconPost WHERE  keepcon_send_setId IS NOT NULL
--Enviados con resultado
SELECT COUNT(*) FROM dbo.KeepconPost WHERE  keepcon_result_resived_date IS NOT NULL

SELECT  count(*) AS Post_Count FROM [dbo].[KeepconPost] WHERE keepcon_moderator_decision IS NOT NULL

SELECT  [keepcon_send_date], DATEDIFF(second,[keepcon_send_date] ,[keepcon_result_resived_date]) AS '[send_date - result_resived_date]'
  FROM [dbo].[KeepconPost]
WHERE keepcon_moderator_decision IS NOT NULL

SELECT [keepcon_send_date] ,[keepcon_moderator_date], DATEDIFF(second,[keepcon_send_date] ,[keepcon_moderator_date]) AS 'send_date - moderator_date'
  FROM [dbo].[KeepconPost]
WHERE keepcon_moderator_decision IS NOT NULL