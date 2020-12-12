-- this procedure is used to get the total price of a room with its features.
-- it take a roomNumber as parameter and will return the total price.
CREATE procedure [dbo].[sp_GetRoomPrice]

@roomNumber integer = NULL

as

begin

    set nocount on

    select sum(features.price) + room.price as totalprice from room inner join roomfeatures on room.roomNumber = roomfeatures.roomNumber inner join features on
            roomfeatures.featureNumber = features.featureNumber where room.roomNumber = @roomNumber group by room.roomNumber, room.price

end;
GO