use W2;


select * from Table2 where valueStr<2 and idStr<50 

DECLARE @ColumnName AS nvarchar(100)
DECLARE @ColumnID AS INT
DECLARE @ColumnIDStr AS nvarchar(100)
DECLARE @CellValueStr AS nvarchar(100)
DECLARE @concatStr as NVARCHAR(max)
SET @concatStr = ''
DECLARE cursor1 CURSOR static forward_only FOR (SELECT colName, idStr, valueStr  from Table2)
OPEN cursor1
FETCH NEXT FROM cursor1 INTO @ColumnName, @ColumnIDStr, @CellValueStr
WHILE @@FETCH_STATUS = 0
	BEGIN
		if(@ColumnIDStr<50 and @CellValueStr<2)
			SET @concatStr = @concatStr + @ColumnIDStr + ',' + @CellValueStr + '.'
	FETCH NEXT FROM cursor1 INTO @ColumnName, @ColumnIDStr, @CellValueStr
	END
CLOSE cursor1
DEALLOCATE cursor1	
select @concatStr as ans