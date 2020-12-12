-- this script will run in a event every evening at 00:00
-- it checks if theres any reservations check out date that will expire at this date.
-- it will move the reservation to archiveReservation table and set the room dirty.
-- so that the cleaning department knows which rooms are dirty on the day.

create procedure dbo.sp_checkForExpiredReservations
as
declare @checkOutDate date
declare @archiveReservation table (resNumber int ,custPhoneNumber varchar(50) ,roomNumber int ,checkInDate date ,checkOutDate date ,daysToStay tinyint ,totalprice decimal(19,4))

    set @checkOutDate =getdate();

    set nocount on
begin
    if exists(select *  from reservation where  @checkOutDate > reservation.checkOutDate)

        insert into @archiveReservation select * from reservation where  @checkOutDate > reservation.checkOutDate;

        insert into dbo.archiveReservation select * from @archiveReservation;

        update room set condition = 'dirty' where roomNumber in (select roomNumber from @archiveReservation);

        delete reservation where  @checkOutDate > reservation.checkOutDate;
end;
