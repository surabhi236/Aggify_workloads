create or alter function WaitingOrders(@suppkey bigint)
returns bigint
as
begin
	declare @skey bigint = @suppkey;
	declare @val bigint;
	set @val = 0;
	declare @ok bigint;
	declare @pk int;
	declare @sk int;
	declare @ln int;
	declare c1 cursor static forward_only for (select L_ORDERKEY, L_PARTKEY, L_SUPPKEY, L_LINENUMBER 
						   from lineitem l1, orders 
						   where l1.L_SUPPKEY = @skey and O_ORDERKEY = l1.L_ORDERKEY AND O_ORDERSTATUS = 'F' AND l1.L_RECEIPTDATE> l1.L_COMMITDATE
							  AND EXISTS (SELECT * FROM lineitem L2 WHERE L2.L_ORDERKEY = l1.L_ORDERKEY 
												AND L2.L_SUPPKEY <> l1.L_SUPPKEY) 
							  AND NOT EXISTS (SELECT * FROM lineitem L3 WHERE L3.L_ORDERKEY = l1.L_ORDERKEY 
												    AND L3.L_SUPPKEY <> l1.L_SUPPKEY 
											            AND L3.L_RECEIPTDATE > L3.L_COMMITDATE)
						  )
	open c1;
	fetch next from c1 into @ok, @pk, @sk, @ln
	while(@@fetch_status=0)
	begin
		set @val +=1;
		fetch next from c1 into @ok, @pk, @sk, @ln;
	end
	close c1;
	deallocate c1;
	return @val;
end
go



-- UDF calling
select S_NAME, S_SUPPKEY from supplier where dbo.WaitingOrders(S_SUPPKEY)>0


--Rewrittten Query from Aggify + Froid
select S_NAME, S_SUPPKEY
from supplier 
where ( 
	select dt3.retval from (
				(select S_SUPPKEY as sk) dt0
					cross apply
				(select WaitingOrders1() as udtVal from (select L_ORDERKEY, L_PARTKEY, L_SUPPKEY, L_LINENUMBER 
									from lineitem l1, orders 
									where l1.L_SUPPKEY = dt0.sk and O_ORDERKEY = l1.L_ORDERKEY AND O_ORDERSTATUS = 'F' 
									AND l1.L_RECEIPTDATE > l1.L_COMMITDATE
									AND EXISTS (SELECT * FROM lineitem L2 WHERE L2.L_ORDERKEY = l1.L_ORDERKEY 
													      AND L2.L_SUPPKEY <> l1.L_SUPPKEY) 
									AND NOT EXISTS (SELECT * FROM lineitem L3 WHERE L3.L_ORDERKEY = l1.L_ORDERKEY 
													          AND L3.L_SUPPKEY <> l1.L_SUPPKEY 
														  AND L3.L_RECEIPTDATE > L3.L_COMMITDATE)
									) dt1 
				)dt2
					cross apply
				(select dt2.udtVal.val as retval) dt3
			       ) 
	) > 0
