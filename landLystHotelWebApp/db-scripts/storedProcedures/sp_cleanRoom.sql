-- this procedure is used by the cleaning department.
-- they will execute it with the roomNumber as parameter to make the room clean.
create procedure dbo.sp_cleanRoom
@roomNumber integer = null
as
begin
    set nocount on
    update room set condition ='clean' where roomNumber = @roomNumber and condition = 'dirty'
end;
