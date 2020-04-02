create or alter function DiscountedRevenue() 
returns decimal(15, 2) 
as
begin
	declare @extendedPrice decimal (15, 2);
	declare @discount decimal(15, 2);
	declare @val decimal (15, 2);
	declare c1 cursor static forward_only for (select L_EXTENDEDPRICE, L_DISCOUNT from dbo.lineitem, dbo.part where (P_PARTKEY = L_PARTKEY AND P_BRAND = 'Brand#12' 
							AND P_CONTAINER IN ('SM CASE', 'SM BOX', 'SM PACK', 'SM PKG') AND L_QUANTITY >= 1 AND L_QUANTITY <= 1 + 10 
							AND P_SIZE BETWEEN 1 AND 5 AND L_SHIPMODE IN ('AIR', 'AIR REG') AND L_SHIPINSTRUCT = 'DELIVER IN PERSON')
							OR (P_PARTKEY = L_PARTKEY AND P_BRAND ='Brand#23' AND P_CONTAINER IN ('MED BAG', 'MED BOX', 'MED PKG', 'MED PACK') 
							AND L_QUANTITY >=10 AND L_QUANTITY <=10 + 10 AND P_SIZE BETWEEN 1 AND 10 AND L_SHIPMODE IN ('AIR', 'AIR REG') 
							AND L_SHIPINSTRUCT = 'DELIVER IN PERSON') OR (P_PARTKEY = L_PARTKEY AND P_BRAND = 'Brand#34' 
							AND P_CONTAINER IN ( 'LG CASE', 'LG BOX', 'LG PACK', 'LG PKG') AND L_QUANTITY >=20 AND L_QUANTITY <= 20 + 10 
							AND P_SIZE BETWEEN 1 AND 15 AND L_SHIPMODE IN ('AIR', 'AIR REG') AND L_SHIPINSTRUCT = 'DELIVER IN PERSON'));

	set @val=0;
	open c1;
	fetch next from c1 into @extendedPrice, @discount;
	while(@@fetch_status=0)
	begin
		set @val = @val+ (@extendedPrice* (1-@discount));
		fetch next from c1 into @extendedPrice, @discount;
	end
	close c1;
	deallocate c1;
	return @val;
end
go

--udf call 
select dbo.DiscountedRevenue() as dr



--rewritten query from Aggify

select DiscountedRevenue1(L_EXTENDEDPRICE, L_DISCOUNT) 
from 
	(select L_EXTENDEDPRICE, L_DISCOUNT 
	from dbo.lineitem, dbo.part 
	where (P_PARTKEY = L_PARTKEY AND P_BRAND = 'Brand#12' 
		AND P_CONTAINER IN ('SM CASE', 'SM BOX', 'SM PACK', 'SM PKG') AND L_QUANTITY >= 1 AND L_QUANTITY <= 1 + 10 
		AND P_SIZE BETWEEN 1 AND 5 AND L_SHIPMODE IN ('AIR', 'AIR REG') AND L_SHIPINSTRUCT = 'DELIVER IN PERSON')
		OR (P_PARTKEY = L_PARTKEY AND P_BRAND ='Brand#23' AND P_CONTAINER IN ('MED BAG', 'MED BOX', 'MED PKG', 'MED PACK') 
		AND L_QUANTITY >=10 AND L_QUANTITY <=10 + 10 AND P_SIZE BETWEEN 1 AND 10 AND L_SHIPMODE IN ('AIR', 'AIR REG') 
		AND L_SHIPINSTRUCT = 'DELIVER IN PERSON') OR (P_PARTKEY = L_PARTKEY AND P_BRAND = 'Brand#34' 
		AND P_CONTAINER IN ( 'LG CASE', 'LG BOX', 'LG PACK', 'LG PKG') AND L_QUANTITY >=20 AND L_QUANTITY <= 20 + 10 
		AND P_SIZE BETWEEN 1 AND 15 AND L_SHIPMODE IN ('AIR', 'AIR REG') AND L_SHIPINSTRUCT = 'DELIVER IN PERSON'))dt1;
