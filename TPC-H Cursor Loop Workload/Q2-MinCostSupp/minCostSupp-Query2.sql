-- ## Query adapted from tpch query 2

create or alter function MinCostSupp(@pk bigint)
returns char(25) as
begin
	declare @key bigint = @pk;
	declare @fetchedCost decimal(15, 2);
	declare @fetchedName char(25);
	declare @minCost decimal(25, 2);
	declare @val char(25);
	set @minCost = 100000;

	declare c1 cursor static forward_only for (select PS_SUPPLYCOST, S_NAME from dbo.partsupp, dbo.supplier where PS_PARTKEY = @key and PS_SUPPKEY = S_SUPPKEY);
	open c1;
	fetch next from c1 into @fetchedCost, @fetchedName;
	while(@@fetch_status=0)
	begin
		if(@fetchedCost<@minCost)
		begin
			set @minCost = @fetchedCost;
			set @val = @fetchedName;
			fetch next from c1 into @fetchedCost, @fetchedName;
		end
	end
	close c1;
	deallocate c1;
	return @val;
end
go

--UDF Call
select P_PARTKEY, dbo.MinCostSupp(P_PARTKEY) from part

-- Rewritten Query with Aggify and Froid

select P_PARTKEY, (select dt4.retval 
		   from (
				(select P_PARTKEY as pkey) dt0
					cross apply
				(select 10000 as minCost) dt1
					cross apply
				(select dbo.MinCostSupp1(dt2.PS_SUPPLYCOST, dt2.S_NAME, dt1.minCost) as udtVal from (select PS_SUPPLYCOST, S_NAME 
														     from dbo.partsupp, dbo.supplier 
													             where PS_PARTKEY = dt0.pkey and PS_SUPPKEY = S_SUPPKEY)dt2
				) dt3
					cross apply 
				(select dt2.udtVal.val as retval)dt4
		  )
from part


