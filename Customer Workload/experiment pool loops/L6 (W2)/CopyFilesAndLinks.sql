USE W2
GO

create table newTab
(
	parent_entity_id int,
	Descr nvarchar(256),
	parentId int,
	var1 int, 
	viewSeq int, 
	isSysFold int
)


go
declare @newTarget as int, @var1 as int
declare @child_count int
declare @child_id int
declare @IsSystemFolder int = 1;
DECLARE child_nodes CURSOR static forward_only for (SELECT entity_id FROM dummy)
open child_nodes
FETCH NEXT FROM child_nodes INTO @child_id
WHILE @@FETCH_STATUS = 0
BEGIN
	if (@IsSystemFolder = 1)
	begin
		insert into newTab(parent_entity_id, Descr, parentId, var1, viewSeq, isSysFold) 
			(select 965 , (select [Description] from table3 where entity_id=@child_id), [ParentID], [var1], (select MAX(ViewSequence) + 1 from FileAndLinkFolder), 0
			from table3
			where entity_id=965)
	end
	FETCH NEXT FROM child_nodes INTO @child_id
END
close child_nodes;
deallocate child_nodes;

--aggify version
select dbo.Agg_L6_w2(t.entity_id) from (SELECT entity_id FROM Table)t;