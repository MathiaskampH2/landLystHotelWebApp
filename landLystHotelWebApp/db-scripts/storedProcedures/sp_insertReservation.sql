-- this procedure is used to insert the Reservation data into reservation table
create procedure dbo.sp_InsertReservation

	   @custPhoneNumber              varchar(50)   = NULL,
	   @roomNumber 					 integer       = null,
       @checkInDate                  datetime      = NULL, 
       @checkOutDate                 datetime      = NULL,
	   @daysToStay                   tinyint       = NULL,
	   @totalprice                   decimal(19,4) = NULL
AS 
BEGIN 
set nocount on

insert into dbo.reservation

	(                    
	custPhoneNumber             ,
	roomNumber                  ,
	checkInDate                 ,
	checkOutDate                ,
	daysToStay                  ,
	totalprice                     
	) 
	VALUES 
	( 
	@custPhoneNumber            ,
	@roomNumber                 ,
	@checkInDate                ,
	@checkOutDate               ,
	@daysToStay                 ,
	@totalprice   
	); 
end




