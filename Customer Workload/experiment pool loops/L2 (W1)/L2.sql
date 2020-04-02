--L2 W1
--running the loop as a batch
USE w1;
GO

create table tableT 
	(
	o uniqueidentifier NOT NULL,
	t int NOT NULL,
	c int NOT NULL,
	) 
go

declare @y int
DECLARE yc CURSOR static forward_only FOR (SELECT DISTINCT t FROM table1)
OPEN yc
FETCH NEXT FROM yc INTO @y
while(0=@@FETCH_STATUS)
begin
	if(@y=113)
	begin
		insert into tableT(o,t,c)select o.IncidentId,112,1 from tableI o,c c where c.t=113 
	end
	if(@y=3231)
	begin
		insert into tableT(o,t,c)select o.ConnectionId,3234,18 from tableC o,c c where c.t=3231 
		insert into tableT(o,t,c)select o.ConnectionId,3234,16 from tableC o,c c where c.t=3231 
	end
	if(@y=9935 )
	begin
		insert into tableT(o,t,c)select o.RecommendationModelId,9933,20 from tableR o,c c where c.t=9935 
	end
	if(@y=8)
	begin
		insert into tableT(o,t,c)select o.BookableResourceId,1150,44 from tableB o,c c where c.t=8 
	end
	if(@y=9333)
	begin
		insert into tableT(o,t,c)select o.SolutionId,7100,36 from tableS o,c c where c.t=9333 
	end
	if(@y=7100 )
	begin
		insert into tableT(o,t,c)select o.DependencyNodeId,7106,5 from tableD o,c c where c.t=7100 
	end
	if(@y=9866)
	begin
		insert into tableT(o,t,c)select o.OrganizationId,1019,369 from tableO o,c c where c.t=9866 
	end
	if(@y=2024)
	begin
		insert into tableT(o,t,c)select o.QueueId,2020,1 from tableQ o,c c where c.t=2024 
	end
	if(@y=2023)
	begin
		insert into tableT(o,t,c)select o.QueueId,2020,1 from tableQ o,c c where c.t=2023 
	end
	if(@y=4703 )
	begin
		insert into tableT(o,t,c)select o.AsyncOperationId,4700,32 from TableAs o,c c where c.t=4703 
	end
	if(@y=4710 )
	begin 
		insert into tableT(o,t,c)select o.ProcessSessionId,4710,26 from TablePr o,c c where c.t=4710 
		insert into tableT(o,t,c)select o.ProcessSessionId,4710,36 from TablePr o,c c where c.t=4710 
		insert into tableT(o,t,c)select o.ProcessSessionId,4710,24 from TablePr o,c c where c.t=4710
	end
	if(@y=9100)
	begin 
		insert into tableT(o,t,c)select o.ReportLinkId,9104,13 from TableRe o,c c where c.t=9100 
		insert into tableT(o,t,c)select o.ReportId,9100,23 from TableRe o,c c where c.t=9100
	end
	if(@y=1056)
	begin
		insert into tableT(o,t,c)select o.ContractDetailId,1011,31 from TableCo o,c c where c.t=1056
		insert into tableT(o,t,c)select o.ProductPriceLevelId,1026,4 from TableP o,c c where c.t=1056
	end
	FETCH NEXT FROM yc INTO @y
end
CLOSE yc
DEALLOCATE yc

GO

--Aggified query. Entire loop replaced with SQL query invoking custom aggregate.
select dbo.agg_L2_W1(p.t) from (select distinct t from table1)p
