-- this procedure is used to insert the customer data into customer table
create procedure dbo.sp_InsertCustomer
       
	   @fname                        varchar(50)   = NULL,
	   @lname 						 varchar(50)   = null,
       @zipcode                      integer       = NULL, 
       @address                      varchar(50)   = NULL,
	   @phoneNumber                  varchar(50)   = NULL,
	   @email                        varchar(50)   = NULL
AS 

     SET NOCOUNT ON 
	 
	if not exists (select * from customer where phoneNumber = @phoneNumber)
	
	 BEGIN 

     INSERT INTO dbo.customer
          (                    
            fname                      ,
            lname                      ,
            zipcode                    ,
			address                    ,
			phoneNumber                ,
			email                     
          ) 
     VALUES 
          ( 
            @fname                     ,
            @lname                     ,
            @zipcode                   ,
			@address                   ,
			@phoneNumber               ,
			@email   
          ); 

END 
