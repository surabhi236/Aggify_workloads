USE W1

declare  @iid uniqueidentifier
declare @eid uniqueidentifier
declare @iName sysname
declare @baseTableName sysname
declare @EtableName sysname
declare @isClustered bit
declare @isPrimary bit

declare @sqlstr nvarchar(2048)
select @sqlstr = N'DBCC DBREINDEX(@table_name_value, @index_name_value)'
declare @parameters nvarchar(max)
select @parameters = N'@table_name_value sysname, @index_name_value sysname'

declare indexCursor cursor local FORWARD_ONLY READ_ONLY for
	select Iid, Eid, Name, IsClustered, IsPrimaryKey from EIndex

open indexCursor
fetch next from indexCursor into  @iid, @eid, @iName, @isClustered, @isPrimary

while (@@fetch_status = 0)
begin

	declare @hasBaseIndex int
	declare @hasExtensionIndex int

	select @hasBaseIndex =  count(*) 
	from AView 
	where IsStoredOnPrimaryTable = 1 and 
	Aid in (select Aid from Iat where Iid =  @iid)

	select @hasExtensionIndex =  count(*) 
	from AView 
	where IsStoredOnPrimaryTable = 0 and 
	Aid in (select Aid from Iat where Iid =  @iid)

	select @baseTableName = BaseTableName, @EtableName = ETableName from EView where Eid = @eid
	
	if (@isClustered <> 0 and @isPrimary <> 0)
	begin
		fetch next from indexCursor into  @iid, @eid, @iName, @isClustered, @isPrimary
		continue
	end

	fetch next from indexCursor into  @iid, @eid, @iName, @isClustered, @isPrimary

end
close indexCursor
deallocate indexCursor


declare entityCursor cursor local FORWARD_ONLY READ_ONLY for
	select ETableName from EView where IsCustomizable <> 0 and ETableName is not null
open entityCursor
fetch next from entityCursor into @EtableName
while (@@fetch_status = 0)
begin
	select @iName = 'PK_' + @EtableName
	fetch next from entityCursor into @EtableName
end
close entityCursor
deallocate entityCursor

