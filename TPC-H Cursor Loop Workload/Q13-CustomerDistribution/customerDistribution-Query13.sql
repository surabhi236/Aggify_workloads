create or alter function OrdersByCustomer(@ckey int)
returns int 
as
begin
	declare @custkey int;
	set @custkey = @ckey;
	declare @okey bigint;
	declare @val int;
	set @val =0 ; 
	declare c1 cursor static forward_only for (select O_ORDERKEY from orders where O_CUSTKEY = @custkey)
	open c1;
	fetch next from c1 into @okey;
	while(@@FETCH_STATUS = 0)
	begin
		set @val+=1;
		fetch next from c1 into @okey;
	end
	close c1;
	deallocate c1;
	return @val;
end
go

--UDF call
select C_CUSTKEY, dbo.OrdersByCustomer(C_CUSTKEY) from customer

--rewritten query from Aggify and Froid
select C_CUSTKEY, (select dt4.retval 
		   from (
				(select C_CUSTKEY as ckey) dt0
					cross apply
				(select 0 as val) dt1
					cross apply 
				(select dbo.OrdersByCustomer1(dt2.O_ORDERKEY, dt1.val) as udtVal from (select O_ORDERKEY from orders where O_CUSTKEY = dt0.ckey)dt2 ) dt3
					cross apply
 				(select dt2.udtVal.val as retval)dt4
			)	
		  )
from customer



