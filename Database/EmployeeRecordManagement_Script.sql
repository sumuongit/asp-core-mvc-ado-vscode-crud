CREATE DATABASE EmployeeRecordManagement

USE [EmployeeRecordManagement]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[City] [varchar](20) NOT NULL,
	[Department] [varchar](20) NOT NULL,
	[Gender] [varchar](6) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spAddEmployee]         
(        
    @Name VARCHAR(20),         
    @City VARCHAR(20),        
    @Department VARCHAR(20),        
    @Gender VARCHAR(6)        
)        
as         
Begin         
    Insert into tblEmployee (Name,City,Department, Gender)         
    Values (@Name,@City,@Department, @Gender)         
End
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spDeleteEmployee]         
(          
   @EmpId int          
)          
as           
begin          
   Delete from tblEmployee where EmployeeId=@EmpId          
End
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spGetAllEmployees]      
as      
Begin      
    select *      
    from tblEmployee   
    order by EmployeeId 
End
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spUpdateEmployee]          
(          
   @EmpId INTEGER,        
   @Name VARCHAR(20),         
   @City VARCHAR(20),        
   @Department VARCHAR(20),        
   @Gender VARCHAR(6)        
)          
as          
begin          
   Update tblEmployee           
   set Name=@Name,          
   City=@City,          
   Department=@Department,        
   Gender=@Gender          
   where EmployeeId=@EmpId          
End
GO

