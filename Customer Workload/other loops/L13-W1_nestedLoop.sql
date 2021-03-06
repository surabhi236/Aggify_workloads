USE W1

declare @bizId uniqueidentifier
declare @userid uniqueidentifier
set @bizId = ;
set @userid = ;
declare @pbId uniqueidentifier
select @pbId = ParentBusinessUnitId from BuBase where BuId = @bizId

declare @prId uniqueidentifier
select @prId = null

declare @rId uniqueidentifier
select @rId = null

declare @asId uniqueidentifier
set @asId = 'fd140aae-4df4-11dd-bd17-0019b9312238'

declare @rootId uniqueidentifier
declare @depth int

create table #roles(id uniqueidentifier)
insert into #roles select Rid from RTable where BuId = @pbId and rtId is null

declare c cursor local FORWARD_ONLY READ_ONLY for select BuId, depth from dbo.Table1(@bizId) order by depth
open c
fetch next from c into @rootId, @depth
while (@@fetch_status = 0)
begin
	select @pbId = ParentBusinessUnitId from BuBase where BuId = @rootId
	declare RoleCursor cursor local for
		select Rid from RTable where BuId = @pbId and rtId is null
		and Rid in (select Rid from RTable where BuId = @pbId and rtId is null)
		
	open RoleCursor
	fetch RoleCursor into @rId
	while (@@fetch_status = 0)
	begin

		declare @newRoleId uniqueidentifier
		select @newRoleId = newid()

		insert into Temptable1(RoleId) values (@newRoleId) 	

		insert into Temptable2(RoleId, rtId, Oid, Name, BuId, CreatedOn, ModifiedOn, CreatedBy, ModifiedBy, prId, SolutionId
				, ParentRootRoleId)
		select @newRoleId, rtId, Oid, Name, @rootId, getutcdate(), null, @userid, null, @rId, @asId
		from RTable where Rid = @rId

		fetch next from RoleCursor into @rId
	end

	insert into #roles select Rid from RTable where BuId = @rootId and rtId is null
		and prId in (select id from #roles)

	close RoleCursor
	deallocate RoleCursor
	fetch next from c into @rootId, @depth

end
close c
deallocate c

drop table #roles

end
GO
