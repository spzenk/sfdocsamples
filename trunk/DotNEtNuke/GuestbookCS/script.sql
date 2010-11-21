

CREATE TABLE [dbo].[YourCompany_GuestBook](
[ID] [int] IDENTITY(1,1) NOT NULL,
[ModuleID] [int] NULL,
[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Message] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateEntered] [datetime] NULL,
CONSTRAINT [PK_YourCompany_GuestBook] PRIMARY KEY CLUSTERED 
(
[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE PROCEDURE {databaseOwner}
   [{objectQualifier}YourCompany_GuestBook_Delete] 
(
@ID int
)
AS
DELETE FROM {objectQualifier}YourCompany_GuestBook
WHERE (ID = @ID)
RETURN
GO
CREATE PROCEDURE {databaseOwner}
   [{objectQualifier}YourCompany_GuestBook_GetAll] 
(
@ModuleID int 
)
AS
SELECT ID, ModuleID, Name, Email, Message, DateEntered
FROM {objectQualifier}YourCompany_GuestBook
WHERE (ModuleID = @ModuleID)
order by DateEntered DESC
RETURN
GO
CREATE PROCEDURE {databaseOwner}
   [{objectQualifier}YourCompany_GuestBook_Insert] 
(
@ModuleID int,
@Name nvarchar(50),
@Email nvarchar(50),
@Message nvarchar(250)
)
AS
INSERT INTO {objectQualifier}YourCompany_GuestBook
(ModuleID, Name, Email, Message, DateEntered)
VALUES (@ModuleID,@Name,@Email,@Message,getdate())
RETURN
GO
CREATE PROCEDURE {databaseOwner}
   [{objectQualifier}YourCompany_GuestBook_Update] 
(
@ID int,
@Name nvarchar(50),
@Email nvarchar(50), 
@Message nvarchar(250),
@DateEntered datetime
)
AS
UPDATE {objectQualifier}YourCompany_GuestBook
SET Name = @Name, Email = @Email, 
    Message = @Message, DateEntered = @DateEntered
WHERE (ID = @ID)
RETURN
GO