/****** Objeto:  Table [dbo].[SystemEvent]    Fecha de la secuencia de comandos: 06/18/2010 09:45:01 ******/
DROP TABLE [dbo].[SystemEvent]
GO
/****** Objeto:  StoredProcedure [dbo].[Logs_s]    Fecha de la secuencia de comandos: 06/18/2010 09:45:01 ******/
DROP PROCEDURE [dbo].[Logs_s]
GO
/****** Objeto:  StoredProcedure [dbo].[Logs_i]    Fecha de la secuencia de comandos: 06/18/2010 09:45:01 ******/
DROP PROCEDURE [dbo].[Logs_i]
GO
/****** Objeto:  StoredProcedure [dbo].[Logs_d]    Fecha de la secuencia de comandos: 06/18/2010 09:45:01 ******/
DROP PROCEDURE [dbo].[Logs_d]
GO
/****** Objeto:  Table [dbo].[Logs]    Fecha de la secuencia de comandos: 06/18/2010 09:45:00 ******/
DROP TABLE [dbo].[Logs]
GO
/****** Objeto:  Table [dbo].[SystemEvent]    Fecha de la secuencia de comandos: 06/18/2010 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemEvent](
	[UserName] [nvarchar](20) NULL,
	[MachineName] [nvarchar](20) NULL,
	[GeneratedTime] [datetime] NULL,
	[EventType] [nvarchar](20) NULL,
	[Message] [nvarchar](2000) NULL
) ON [PRIMARY]
GO
/****** Objeto:  StoredProcedure [dbo].[Logs_s]    Fecha de la secuencia de comandos: 06/18/2010 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------------------
	-- Autor:		moviedo
	-- Creacion:		26/02/2010 10:05:27
	-- Descripcion: 	Realiza una busqueda por parametros de la tabla Logs
	--------------------------------------------------------------------------------------------
	-- Operadores posibles de usar:
	--
	-- <> | > | >= | < | <= | = | %_ | _% | %% | []
	--
	--------------------------------------------------------------------------------------------
	CREATE PROCEDURE [dbo].[Logs_s]
	-- Lista de Parámetros
	
	
	@Source NVarChar(20) = null,
	@LogType NVarChar(20) = null,
	@Machine NVarChar(50) = null,
	@LogDateDesde DateTime = null,
	@LogDateHasta DateTime = null,
	@UserLoginName NVarChar(100) = null
--	@AppId NVarChar(100)

	AS
	BEGIN
	SET NOCOUNT ON
	SET DATEFORMAT DMY

	----------------------------------------
	-- Definimos Variables
	----------------------------------------
	DECLARE @sql        nvarchar(4000)
	DECLARE @parametros nvarchar(4000)

	SET @sql = N' SELECT * FROM Logs  WHERE 1 = 1 '

	-- Source = TYPE NVarChar
	IF (@Source IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND Source  LIKE  @Source '
	END
	
	-- LogType = TYPE NVarChar
	IF (@LogType IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND LogType  =  @LogType '
	END
	
	-- Machine = TYPE NVarChar
	IF (@Machine IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND Machine  LIKE  @Machine '
	END
	
 --------------  Fechas ---------------------------------------
	 IF (@LogDateDesde IS NOT NULL AND @LogDateHasta IS NULL)
		BEGIN
			SET @sql = @sql + ' AND (LogDate >= @LogDateDesde)'
		END
	
	 IF (@LogDateDesde IS NOT NULL  AND  @LogDateHasta IS NOT NULL )
	BEGIN
	  SET @sql = @sql + ' AND (LogDate >= @LogDateDesde AND LogDate <= @LogDateHasta)'
	END
--------------  Fechas ---------------------------------------


	
	-- UserLoginName = TYPE NVarChar
	IF (@UserLoginName IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND UserLoginName  LIKE  @UserLoginName '
	END

	


	SELECT @parametros = '	
	@Source NVarChar(20) ,
	@LogType NVarChar(20) ,
	@Machine NVarChar(50) ,
	@LogDateDesde DateTime ,
	@LogDateHasta DateTime ,
	@UserLoginName NVarChar(100)'

	EXEC sp_executesql @sql, @parametros, 
					   @Source, @LogType, @Machine,@LogDateDesde,@LogDateHasta, @UserLoginName
	END
GO
/****** Objeto:  Table [dbo].[Logs]    Fecha de la secuencia de comandos: 06/18/2010 09:45:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [uniqueidentifier] NOT NULL,
	[Message] [varchar](2000) NOT NULL,
	[Source] [nvarchar](20) NOT NULL,
	[LogType] [nvarchar](20) NOT NULL,
	[Machine] [nvarchar](50) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[UserLoginName] [nvarchar](100) NOT NULL,
	[AppId] [nvarchar](100) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  StoredProcedure [dbo].[Logs_i]    Fecha de la secuencia de comandos: 06/18/2010 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Logs_i]
(
	@Id  uniqueidentifier ,
	@LogDate datetime ,
	@Message nvarchar(2000) ,
	@Source nvarchar(20) ,
	@LogType nvarchar(20) ,
	@Machine nvarchar(100) ,
	@UserLoginName nvarchar(100) ,
	@AppId nvarchar(100) = null

)
AS
				
-- Description : Procedimiento de creación de Logs.
-- Author      : moviedo
-- Date        : 2006-11-16T11:59:20
				

INSERT INTO Logs
(
	Id,
	LogDate,
	Message,
	Source,
	LogType,
	Machine,
	UserLoginName,
	AppId

)
VALUES
(
	@Id,
	@LogDate,
	@Message,
	@Source,
	@LogType,
	@Machine,
	@UserLoginName,
	@AppId

)
GO
/****** Objeto:  StoredProcedure [dbo].[Logs_d]    Fecha de la secuencia de comandos: 06/18/2010 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Logs_d]
(
	@Id    uniqueidentifier

)
AS
				
-- Description : Procedimiento de eliminación de Logs.
-- Author      : moviedo
-- Date        : 2006-11-16T11:59:20
				

DELETE FROM Logs
WHERE Id = @Id
GO
