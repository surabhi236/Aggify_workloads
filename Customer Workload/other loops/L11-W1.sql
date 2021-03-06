USE W1
	
declare @newRoot uniqueidentifier, @oldRoot uniqueidentifier
declare @sRoots table (
	NewId uniqueidentifier not null,
	oldId uniqueidentifier not null
)

insert into @sRoots
(NewId, oldId)
select scb1.ScId, scb2.ScId from ScBase scb1 join ScBase scb2 on scb1.ObjectId=scb2.ObjectId and scb1.SolutionId=@parentId and scb2.SolutionId=@childId

declare rootCursor cursor for (select NewId, oldId from @sRoots)

open rootCursor
fetch next from rootCursor into @newRoot, @oldRoot

while @@fetch_status = 0
begin
	update ScBase set RootSolutionComponentId = @newRoot where SolutionId=@childId and RootSolutionComponentId=@oldRoot and ObjectId not in (select ObjectId from ScBase where SolutionId = @parentId)
	fetch next from rootCursor into @newRoot, @oldRoot
end