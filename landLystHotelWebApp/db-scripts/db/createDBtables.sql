-- create hotel table
if not exists (select * from sys.objects where type ='U' and name ='hotel')

begin
	create table hotel
	(
		hotelNumber integer not null identity(1,1) primary key,
		hotelName varchar (50) not null,
		rating tinyint,
		totalRooms int,
		phoneNumber varchar(50), 
		email varchar(50)	 	
	);
end;

-- create hotelAudit table
if not exists (select * from sys.objects where type ='U' and name ='hotelAudit')
begin
	create table hotelAudit
	(
		hotelNumber 	integer,
		hotelName 		varchar(50),
		rating 			tinyint,
		totalRooms 		integer,
		phoneNumber 	varchar(50),
		email 			varchar(50),
		userName        varchar(50),
		audit_action    varchar(100),
		audit_timestamp datetime
	);
end;

-- create zipcodes table
if not exists (select * from sys.objects where type ='U' and name ='zipcodes')

begin
	create table zipcodes
	(
	zipcode integer not null,
	cityname varchar (50) not null,
    Constraint PK_zipcode PRIMARY KEY(zipcode)
	);
end;

-- create zipcodesAudit table
if not exists (select * from sys.objects where type ='U' and name ='zipcodesAudit')
begin
	create table zipcodesAudit(

	  zipcode integer,
	  cityName varchar (50),
	  userName        varchar(50),
	  audit_action    varchar(100),
	  audit_timestamp datetime
	);
end;


--create customer table	
if not exists (select * from sys.objects where type ='U' and name ='customer')

begin
	create table customer
	(
		fname  varchar (50) not null,
		lname varchar (50) not null,
		zipcode integer not null,
		address varchar (50) not null,
		phoneNumber varchar (50) not null primary key,
		email varchar (50) not null,
		
		constraint FK_zipcodes foreign key (zipcode)	
		references zipcodes (zipcode)		
	);
end;

-- create customerAudit table
if not exists (select * from sys.objects where type ='U' and name ='customerAudit')
begin
	create table customerAudit
	(
		fname           varchar(50),
		lname           varchar(50),
		zipcode         int,
		address         varchar(50),
		phoneNumber     varchar(50),
		email           varchar(50),
		userName        varchar(50),
		audit_action    varchar(100),
		audit_timestamp datetime

	);
end;


-- create room table
if not exists (select * from sys.objects where type ='U' and name ='room')

begin
	create table room
	(
		roomNumber integer not null primary key,
		hotelNumber integer not null,
		floorLevel tinyint not null,
		price decimal(19,4) not null,
		condition varchar(5) not null, 
		
		constraint FK_hotel foreign key (hotelNumber)	
		references hotel (hotelNumber)		
	);
end;

-- create roomAudit table
if not exists (select * from sys.objects where type ='U' and name ='roomAudit')
begin
	create table roomAudit(
	  roomNumber integer,
	  hotelNumber integer,
	  floorLevel tinyint,
	  price decimal(19,4),
	  condition varchar(5),
	  userName        varchar(50),
	  audit_action    varchar(100),
	  audit_timestamp datetime
	);
end;

-- create features table
if not exists (select * from sys.objects where type ='U' and name ='features')

begin
	create table features
	(
		featureNumber integer not null identity(1,1) primary key,
		description  varchar (100) not null,
		price decimal(19,4) not null	 	 
	);
end;

-- create featureAudit table
if not exists (select * from sys.objects where type ='U' and name ='featuresAudit')
begin
	create table featuresAudit
	(
		featureNumber   int,
		description     varchar(100),
		price           decimal(19, 4),
		userName        varchar(50),
		audit_action    varchar(100),
		audit_timestamp datetime
	);
end;


-- create roomFeatures  table
if not exists (select * from sys.objects where type ='U' and name ='roomFeatures')

begin	
	create table roomFeatures
	(

		roomNumber integer not null,
		featureNumber integer not null,
		
		constraint FK_roomNumber foreign key (roomNumber)
		references room (roomNumber),
		constraint FK_features foreign key (featureNumber)
		references features (featureNumber)
	);
end;

-- create roomFeatureAudit table
if not exists (select * from sys.objects where type ='U' and name ='roomFeaturesAudit')
begin
	create table roomFeaturesAudit
	(
	  roomNumber 	  integer,
	  featureNumber   integer,
	  userName        varchar(50),
	  audit_action    varchar(100),
	  audit_timestamp datetime
	);
end;

-- create reservation table
if not exists (select * from sys.objects where type ='U' and name ='reservation')

begin	
	create table reservation 
	(
		resNumber integer not null identity(1,1) primary key,
		custPhoneNumber varchar(50) not null,
		roomNumber integer not null,
		checkInDate date not null,
		checkOutDate date not null,
		daysToStay integer not null,
		totalprice decimal(19,4) not null,
		
		constraint FK_customer foreign key (custPhoneNumber)
		references customer (phoneNumber),
		constraint FK_room foreign key (roomNumber)
		references room (roomNumber)

	);
end;

-- create reservationAudit table
if not exists (select * from sys.objects where type ='U' and name ='reservationAudit')
begin
	create table reservationAudit
	(
		resNumber 		integer ,
		custPhoneNumber varchar(50),
		roomNumber 		integer,
		checkInDate 	date,
		checkOutDate 	date,
		daysToStay 		integer,
		totalprice 		decimal(19,4),
		userName        varchar(50),
		audit_action    varchar(100),
		audit_timestamp datetime
	);
end;
if not exists (select * from sys.objects where type ='U' and name ='archiveReservation')
begin
	create table archiveReservation 
	(
		 resNumber integer,
		 custPhoneNumber varchar(50),
		 roomNumber integer,
		 checkInDate date,
		 checkOutDate date,
		 daysToStay integer,
		 totalprice decimal(19,4),

	);
end;