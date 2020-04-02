USE W2;
GO

declare @iId as int
declare @fname nvarchar(64)
declare @vTypeId as int
set @vTypeId = -1
declare key_cursor cursor static forward_only for (select id, fname, typeId from table1)
open key_cursor
fetch next from key_cursor INTO @iId, @fname, @vTypeId
WHILE @@FETCH_STATUS = 0
	BEGIN											
	insert into @resultTable (@fname, @iId, @vTypeId)											
	FETCH NEXT FROM key_cursor INTO @iId, @fname,@vTypeId 		
END
CLOSE key_cursor
DEALLOCATE key_cursor	