CREATE TABLE [dbo].[Supplier](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[DDD] [Nvarchar](3) NOT NULL,
	[PhoneNumber] [nvarchar] (11) NOT NULL,
	[CreatedDate] [Datetime] NOT NULL,
	[LastUpdatedDate] [Datetime] NULL,
	[CanceledDate] [Datetime] NULL,
	[Status] [Int] NOT NULL, -- 0 - Canceled | 1 - Active
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Materials](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[DueDate] [DateTime] NOT NULL,
	[CreatedDate] [nvarchar](255) NOT NULL,
	[LastUpdatedDate] [Datetime] NULL,
	[CanceledDate] [Datetime] NULL,
	[Status] [Int] NOT NULL, -- 0 - Canceled | 1 - Active
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Stock](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MaterialId] [bigint] NOT NULL,
	[SupplierId] [bigint] NOT NULL,
	[Qtty] [int] NOT NULL,
	[CreatedDate] [nvarchar](255) NOT NULL,
	[LastUpdatedDate] [Datetime] NULL,
	[Status] [Int] NOT NULL, -- 0 - Canceled | 1 - Active
)