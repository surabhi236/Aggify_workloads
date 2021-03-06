USE W1

declare @name nvarchar(200)
declare @description nvarchar(max)
declare @fetchxml nvarchar(max)
declare @rtc int
declare @qt int

declare c cursor local FORWARD_ONLY READ_ONLY for
	select Name, Description, FetchXml, ReturnedTypeCode, QueryType from Ftable

open c
fetch next from c into @name, @description, @fetchxml, @rtc, @qt

while (@@fetch_status = 0)
begin

	insert into tempTable (UserQueryId, Name, Description, OwnerId, obUnit, FetchXml, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, ReturnedTypeCode, QueryType)
	values(newid(), @name, @description, @userid, @bizid, @fetchxml, @userid, dbo.fn_GetUtcDateTrunc(), @userid, dbo.fn_GetUtcDateTrunc(), @rtc, @qt)
	
	fetch next from c into @name, @description, @fetchxml, @rtc, @qt

end

close c
deallocate c

