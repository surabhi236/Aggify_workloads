USE W2;
GO

declare @strConcat as nvarchar(max) = '';
declare @boolConcat as nvarchar(max) = '';
declare @dateConcat as nvarchar(max) = '';
declare @errorConcat as nvarchar(max) = '';

declare @errorNum as int = 0;
	
declare @DataTypeID as int;
declare @strValue as nvarchar(64)  = '';
declare cursor1 cursor static forward_only for (select val, dataTypeID from Table1);
open cursor1;
fetch next from cursor1 into @strValue, @DataTypeID;
while (@@FETCH_STATUS = 0)
begin
	if (@DataTypeID = 1)
	begin
		set @strConcat = @strConcat+@strValue;
	end

	else if (@DataTypeID = 2)
	begin
		set @boolConcat = @boolConcat+@strValue;
	end

	else if (@DataTypeID = 3)
	begin
		set @dateConcat = @dateConcat + @strValue;
	end

	else
	begin
		set @errorNum+=1;
	end

	fetch next from cursor1 into @strValue, @DataTypeID;
end
close cursor1;
deallocate cursor1;
select @strConcat as sc;
select @boolConcat as bc;
select @dateConcat as dc;
select @errorNum as ec;
go


--manually Aggified Query
SELECT dt2.ANS1, dt2.ANS2, dt2.ANS3, dt2.ANS4 FROM
(select (dbo.Agg_L4_W2(val, dataTypeID)) as UDTVAL from (select val, dataTypeID from Table1) as t) dt1
	CROSS APPLY
(SELECT DT1.UDTVAL.val1 AS ANS1, DT1.UDTVAL.val2 AS ANS2, DT1.UDTVAL.val3 AS ANS3, DT1.UDTVAL.val4 AS ANS4) DT2
option (maxdop 1)

