CREATE TABLE [dbo].[ZIP]
(
	[ZIPCode] char(5) not null,
	[City] varchar(max) not null,
	[State] char(2) not null,
	[Country] varchar(max),
	[Latitude] numeric(18,4),
	[Longitude] numeric(18,4),
	[DateLastChange] datetime not null,
	constraint PK_ZIP primary key ([ZIPCode])
)
