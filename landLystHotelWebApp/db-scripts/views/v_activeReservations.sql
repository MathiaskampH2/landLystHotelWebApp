-- view used by hans peter and poul.
-- they have to use it like this in order to get it sorted - select * from dbo.vCurrentReservations order by checkInDate asc
create view dbo.vCurrentReservations as

select * from reservation;
