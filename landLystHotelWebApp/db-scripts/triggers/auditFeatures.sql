-- trigger to log changes on features table
if exists (select * from sys.objects where type ='TR' and name = 'trg_features')
    drop trigger [dbo].[trg_features]
GO
create trigger trg_features on [dbo].[features] for insert, update, delete

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




    insert featuresAudit (featureNumber, description ,price , username,  audit_action, audit_timestamp)
    select featureNumber, description ,price , @trg_username, @audit_action + '_old', @audit_timestamp
    from deleted

    insert featuresAudit (featureNumber, description ,price , username,  audit_action, audit_timestamp)
    select featureNumber, description ,price , @trg_username, @audit_action + '_new', @audit_timestamp
    from inserted
end;