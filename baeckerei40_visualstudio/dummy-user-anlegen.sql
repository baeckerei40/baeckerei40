USE [baeckerei40]
GO

INSERT INTO [dbo].[Kunden]
           ([Vorname]
           ,[Nachname]
           ,[Telefonnummer]
           ,[EMail]
           ,[Adresse]
           ,[Ort])
     VALUES
           ('Max',
		   'Muster',
		   '123455',
		   'max@muster.de',
		   'teststr.1',
		   'Testort')
GO