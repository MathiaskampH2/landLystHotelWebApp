-- view used by cleaning department to get dirty rooms
create view dbo.vRoomsToClean as


select room.roomNumber as 'room number', floorLevel as 'floor level', condition as 'condition' from room
where condition = 'dirty' and hotelNumber = 1;