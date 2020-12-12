-- trigger to log the changes of room table
if exists (select * from sys.objects where type ='TR' and name = 'trg_room')
    drop trigger [dbo].[trg_room]
GO
create trigger trg_room on [dbo].[room] for insert, update, delete

    as
    set nocount on
begin


    declare @trg_userName    varchar(50);
    declare @audit_action    varchar(100);
    declare @audit_timestamp datetime;

    select @trg_username = system_user;
    select @audit_timestamp = getdate();

    if exists (select * from inserted) and exists (select * from deleted)
        select @audit_action = 'updated'
    else if exists (select * from inserted)
        select @audit_action ='inserted'
    else
        select @audit_action = 'deleted'

    insert roomAudit (roomNumber, hotelNumber, floorLevel, condition, price, userName, audit_action, audit_timestamp)
    select roomNumber, hotelNumber, floorLevel, condition, price, @trg_userName, @audit_action + '_old', @audit_timestamp
    from deleted

    insert roomAudit (roomNumber, hotelNumber, floorLevel, condition, price, userName, audit_action, audit_timestamp)
    select roomNumber, hotelNumber, floorLevel, condition, price, @trg_userName, @audit_action + '_new', @audit_timestamp
    from inserted
end;