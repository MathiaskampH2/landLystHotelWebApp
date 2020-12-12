-- create user poul
if not exists (select * from sys.database_principals where name =N'poul')

begin

	create LOGIN poul with password ='Kode1234!'

	create user [poul] for login [poul]

	--permissions to poul

	Grant select on dbo.vCurrentReservations to poul

end;

-- create user hans_peter
if not exists (select * from sys.database_principals where name =N'hans_peter')

    begin

        create LOGIN hans_peter with password ='Kode1234!'

        create user [hans_peter] for login [hans_peter]

        --permissions to hans_peter

        Grant select on dbo.vCurrentReservations to hans_peter

    end;

-- create user lis
if not exists (select * from sys.database_principals where name =N'lis')

begin

	create LOGIN lis with password ='Kode1234!'

	create user [lis] for login [lis]

	--permissions to lis

	Grant select on dbo.vRoomsToClean to lis

	grant execute on dbo.sp_cleanRoom to lis

end;

-- create user marianne
if not exists (select * from sys.database_principals where name =N'marianne')

begin

	create LOGIN marianne with password ='Kode1234!'

	create user [marianne] for login [marianne]

	--permissions to marianne

	Grant select on dbo.vRoomsToClean to marianne

end;
	
	

