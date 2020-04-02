create or alter function PromoRevenue(@partkey int) 
returns decimal(25, 5)
as
begin
	declare @pkey int = @partkey;
	declare @val decimal(25, 5);
	declare @fetchedPrice decimal(12, 2);
	declare @fetchedDiscount decimal(12, 2);
	declare c1 cursor static forward_only  for (select L_EXTENDEDPRICE, L_DISCOUNT from lineitem where L_PARTKEY = @pkey);
	set @val = 0;
	open c1;
	fetch next from c1 into @fetchedPrice, @fetchedDiscount;
	while(@@fetch_status=0)
	begin
		set @val = @val + @fetchedPrice * (1-@fetchedDiscount)
		fetch next from c1 into @fetchedPrice, @fetchedDiscount;
	end
	close c1;
	deallocate c1;
	return @val
end
go

--UDF call
select P_PARTKEY, dbo.PromoRevenue(P_PARTKEY) from part where P_TYPE like 'PROMO%%' 

--Rewritten query with Aggify and Froid
select P_PARTKEY, (select dt4.retval 
		   from (
				  (select P_PARTKEY as pkey) dt0
					cross apply
			          (select 0 as val)dt1
					cross apply
				  (select dbo.PromoRevenue1(dt2.L_EXTENDEDPRICE, dt2.L_DISCOUNT, dt1.val) as udtVal from (select L_EXTENDEDPRICE, L_DISCOUNT 
															  from lineitem 
														          where L_PARTKEY = dt0.pkey)dt2 ) dt3
					cross apply 
				  (select dt3.udtVal.val as retval)dt4
			  )
		  )
from part
where P_TYPE like 'PROMO%%'

