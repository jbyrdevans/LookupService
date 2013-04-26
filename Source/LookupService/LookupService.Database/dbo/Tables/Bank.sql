create table Bank
(
	[RoutingNumber] varchar(9) not null,
	[Name] varchar(36) null,
	[Address] varchar(36) null,
	[City] varchar(20) null,
	[State] varchar(2) null,
	[Zip] varchar(5) null,
	[ZipPlus4] varchar(4) null,
	[Phone] varchar(10) null,
	[ServicingFrbRoutingNumber] varchar(9) null,
	[DateLastChange] datetime null,
	[NewRoutingNumber] varchar(9) null,
	[RecordTypeId] varchar(1) not null,
	[OfficeTypeId] varchar(1) not null,
	[StateCodeId] varchar(1) not null,
	[DataViewCodeId] varchar(1) not null,
	constraint PK_Address primary key ([RoutingNumber])
)