USE W1


declare @name nvarchar(128)
declare @sql nvarchar(2000)
set @sql = '';
declare SyncEntryCursor cursor local for
										(select StableName from Subs where Stype = 1)

open SyncEntryCursor
fetch SyncEntryCursor into @name

while @@fetch_status = 0
begin
	set @sql = @sql + 'delete from ' + @name + ' where ObjectTypeCode not in (select OtCode from EView)' ;
    fetch SyncEntryCursor into @name
end

close SyncEntryCursor
deallocate SyncEntryCursor

select @sql as ans;
	
