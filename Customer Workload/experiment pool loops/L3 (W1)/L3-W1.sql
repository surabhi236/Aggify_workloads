USE W1
GO

--loop batch

declare @u int = 1;
declare @c int=-1
declare @n int=0
declare @l int=1
declare @y int

DECLARE yc CURSOR STATIC FOR (SELECT DISTINCT t FROM x)
OPEN yc
FETCH NEXT FROM yc INTO @y
while(0=@@FETCH_STATUS)
begin

	if(@y=9957)
	begin
	print 'here'
	insert tableB(o,t,d,s) select KAId,-9953,@c,0 from KA o join tableB c on c.o=o.LLId and c.d=@c and c.t=9957
	end
	
	if(@y=4618)
	begin
		if(@u=1)
		begin
			insert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x
			insert into tableB(o,t,d,s)select o.stepId,4608,@n,ComponentState from MLTable o,tableB c where c.t=4618 and c.o=o.Eh and o.ETCode=4618 and c.d=@c
		end
		else 
			insert into tableB(o,t,d,s)select o.stepId,4608,@n,0 from MTable o,tableB c where c.t=4618 and c.o=o.Eh and o.ETCode=4618 and c.d=@c
	end
	
	if(@y=1234)
	begin
		print 'here'
		if(@u=1)
		begin
			insert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x
			insert into tableB(o,t,d,s)select o.cpId,1236,@n,ComponentState from PLTable o,tableB c where c.t=1234 and c.o=o.ROid and o.RTCode=1234 and c.d=@c
	 	end
		else 
	 		insert into tableB(o,t,d,s)select o.cpId,1236,@n,0 from PTable o,tableB c where c.t=1234 and c.o=o.ROid and o.RTCode=1234 and c.d=@c	
	end
	
	if(@y=4810)
	begin
	insert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x
	insert into tableB(o,t,d,s)select o.TimeZoneId,4811,@n,0 from TRule o,tableB c where c.t=4810 and c.o=o.TdefId and c.d=@c
	insert into tableB(o,t,d,s)select o.TNameId,4812,@n,0 from TName o,tableB c where c.t=4810 and c.o=o.TdefId and c.d=@c
	end
	
	if(@y=1002)
	begin
	insert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x
	insert tableB(o,t,d,s) select ActivityMimeAttachmentId,-1001,@c,0 from ActivityAttachmentAsIfPublished o join tableB c on c.o=o.AttachmentId and c.d=@c and c.t=1002
	end
	
	if(@y=9603)
	begin
	insert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x
	insert tableB(o,t,d,s) select GoalId,-9600,@c,0 from Goal o join tableB c on c.o=o.MetricId and c.d=@c and c.t=9603
	insert into tableB(o,t,d,s)select o.RollupFieldId,9604,@n,0 from RollupField o,tableB c where c.t=9603 and c.o=o.MetricId and c.d=@c
	end
	
	if(@y=1200)
	begin
		insert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x
		insert into tableB(o,t,d,s)select o.TeamProfileId,1203,@n,0 from TeamProfiles o,tableB c where c.t=1200 and c.o=o.FieldSecurityProfileId and c.d=@c
		if(@u=1)insert into tableB(o,t,d,s)select o.FieldPermissionId,1201,@n,ComponentState from FieldPermissionLogicalAsIfPublished o,tableB c where c.t=1200 and c.o=o.FieldSecurityProfileId and c.d=@c
		else insert into tableB(o,t,d,s)select o.FieldPermissionId,1201,@n,0 from FieldPermissionAsIfPublished o,tableB c where c.t=1200 and c.o=o.FieldSecurityProfileId and c.d=@c
		insert into tableB(o,t,d,s)select o.SystemUserProfileId,1202,@n,0 from SystemUserProfiles o,tableB c where c.t=1200 and c.o=o.FieldSecurityProfileId and c.d=@c
	end
	
	if(@y=92)
	begin
	insert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x
	insert into tableB(o,t,d,s) select o.TeamId,9,@n,0 from Team o,tableB c where c.t=92 and c.o=o.TeamTemplateId and c.d=@c
	end
	
	if(@y=9602)
	begin
	insert tableB(o,t,d,s) select GoalId,-9600,@c,0 from Goal o join tableB c on c.o=o.RollUpQueryCustomIntegerId and c.d=@c and c.t=9602
	insert tableB(o,t,d,s) select GoalId,-9600,@c,0 from Goal o join tableB c on c.o=o.RollUpQueryCustomDecimalId and c.d=@c and c.t=9602
	insert tableB(o,t,d,s) select GoalId,-9600,@c,0 from Goal o join tableB c on c.o=o.RollUpQueryInprogressIntegerId and c.d=@c and c.t=9602
	insert tableB(o,t,d,s) select GoalId,-9600,@c,0 from Goal o join tableB c on c.o=o.RollUpQueryActualMoneyId and c.d=@c and c.t=9602
	insert tableB(o,t,d,s) select GoalId,-9600,@c,0 from Goal o join tableB c on c.o=o.RollUpQueryInprogressDecimalId and c.d=@c and c.t=9602
	insert tableB(o,t,d,s) select GoalId,-9600,@c,0 from Goal o join tableB c on c.o=o.RollUpQueryInprogressMoneyId and c.d=@c and c.t=9602
	insert tableB(o,t,d,s) select GoalId,-9600,@c,0 from Goal o join tableB c on c.o=o.RollupQueryActualIntegerId and c.d=@c and c.t=9602
	insert tableB(o,t,d,s) select GoalId,-9600,@c,0 from Goal o join tableB c on c.o=o.RollUpQueryCustomMoneyId and c.d=@c and c.t=9602
	insert tableB(o,t,d,s) select GoalId,-9600,@c,0 from Goal o join tableB c on c.o=o.RollUpQueryActualDecimalId and c.d=@c and c.t=9602
	end
	
	if(@y=7101)
	begin
	print 'here'
	insert tableB(o,t,d,s) select SolutionId,-7100,@c,0 from Solution o join tableB c on c.o=o.PublisherId and c.d=@c and c.t=7101
	insert into tableB(o,t,d,s)select o.PublisherAddressId,7102,@n,0 from PublisherAddress o,tableB c where c.t=7101 and c.o=o.ParentId and c.d=@c
	end
	
	if(@y=3231)
	begin
	print 'here'
	insert into tableB(o,t,d,s)select o.ConnectionRoleAssociationId,3232,@n,0 from ConnectionRoleAssociation o,tableB c where c.t=3231 and c.o=o.ConnectionRoleId and c.d=@c and o.ConnectionRoleAssociationId not in(select o from tableB where t=3232)
	insert into tableB(o,t,d,s)select o.ConnectionRoleObjectTypeCodeId,3233,@n,0 from ConnectionRoleObjectTypeCode o,tableB c where c.t=3231 and c.o=o.ConnectionRoleId and c.d=@c
	insert into tableB(o,t,d,s)select o.ConnectionRoleAssociationId,3232,@n,0 from ConnectionRoleAssociation o,tableB c where c.t=3231 and c.o=o.AssociatedConnectionRoleId and c.d=@c and o.ConnectionRoleAssociationId not in(select o from tableB where t=3232)
	end
	
	if(@y=4605)
	begin
		print 'here'
		if(@u=1)
			insert into tableB(o,t,d,s)select o.PluginTypeId,4602,@n,ComponentState from PluginTypeLogicalAsIfPublished o,tableB c where c.t=4605 and c.o=o.PluginAssemblyId and c.d=@c
	 	else 
	 		insert into tableB(o,t,d,s)select o.PluginTypeId,4602,@n,0 from PluginTypeAsIfPublished o,tableB c where c.t=4605 and c.o=o.PluginAssemblyId and c.d=@c
	end
	
	FETCH NEXT FROM yc INTO @y
end

CLOSE yc
DEALLOCATE yc


--Aggified Query
select dbo.Agg_L3_W1(p.t) from (select distinct t from x) p
option (maxdop 1)

