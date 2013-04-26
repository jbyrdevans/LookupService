create table [Version]
(
	[Type] varchar(32) not null,
	[LastUpdateSuccess] datetime not null,
	[LastUpdateAttempt] datetime not null,
	[LastUpdateItemsAdded] INT NOT NULL, 
    [LastUpdateItemsModified] INT NOT NULL, 
    constraint PK_Version primary key ([Type]),
	constraint UK_Version_Type unique ([Type])
)