create or alter function VolumeCustomer(@orderkey bigint) 
returns int
as
begin
	declare @ok bigint = @orderkey;
	declare @qty decimal(12, 2);
	declare @i int = 0;
	declare @d decimal(12, 2);
	set @d = 0;
	declare c1 cursor static forward_only for(select L_QUANTITY from lineitem where L_ORDERKEY = @ok)
	open c1;
	fetch next from c1 into @qty;
	while(@@fetch_status=0)
	begin
		set @d += @qty;
		fetch next from c1 into @qty;
	end
	if(@d>300)
		set @i = 1;
	close c1;
	deallocate c1;
	return @i;
end
go



--UDF call
select O_ORDERKEY, O_TOTALPRICE from orders where dbo.VolumeCustomer(O_ORDERKEY) = 1

--Rewritten Query from Aggify and froid

select O_ORDERKEY, O_TOTALPRICE from orders where ( 
						   select dt4.retval from (
								(select O_ORDERKEY as ok) dt0
										cross apply
								(select dbo.VolumeCustomer1(dt1.L_QUANTITY) as udtVal from (select L_QUANTITY 
															   from lineitem
															   where L_ORDERKEY = dt0.ok) dt1 )dt2
										cross apply
								(select dt2.udtVal.d as sumQuant, dt2.udtVal.i as i) dt3)
										cross apply
								(select case when dt3.sumQuant>300 then 1 else 0 end as retval)dt4 
					          ) = 1