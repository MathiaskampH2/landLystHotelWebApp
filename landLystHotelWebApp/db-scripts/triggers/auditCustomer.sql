-- trigger to log changes of customer table
if exists (select * from sys.objects where type ='TR' and name = 'trg_customer')
    drop trigger [dbo].[trg_customer]
GO
create trigger trg_customer on [dbo].[customer] for insert, update, delete

    as
    set nocount on

BEGIN

    declare @trg_username varchar (50);
    declare @audit_action varchar(100);
    declare @audit_timestamp datetime;

    select @trg_username = system_user;
    select @audit_timestamp = getdate();

    if exists (select * from inserted) and exists (select * from deleted)
        select @audit_action = 'updated'
    else if exists (select * from inserted)
        select @audit_action ='inserted'
    else
        select @audit_action = 'deleted'


    insert customerAudit (fname, lname, zipcode, address, phoneNumber, email, username, audit_action, audit_timestamp)
    select fname, lname, zipcode, address, phoneNUmber, email, @trg_username, @audit_action + '_old', @audit_timestamp
    from deleted

    insert customerAudit (fname, lname, zipcode, address, phoneNumber, email, username, audit_action, audit_timestamp)
    select fname, lname, zipcode, address, phoneNUmber, email, @trg_username, @audit_action + '_new', @audit_timestamp
    from inserted

end;