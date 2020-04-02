USE W2;
GO

--runing the loop as a batch
DECLARE @var1 AS INT
DECLARE @ColumnIdStr AS nvarchar(100)
DECLARE @FactorStr AS nvarchar(100)
DECLARE @Factor AS decimal(6,3)
DECLARE @var2 AS BIT
SET @var2 = 1
SET @var2 = (SELECT var2
			FROM Table2
			WHERE Table2ID = 537)

SELECT @var1 = SCOPE_IDENTITY()
DECLARE @concatStr nvarchar(512)
SET @concatStr = ''
DECLARE record_cursor CURSOR static forward_only FOR (select column_id, factor from Table1 where column_id<62000)
										
OPEN record_cursor
FETCH NEXT FROM record_cursor INTO @ColumnIdStr, @FactorStr
WHILE @@FETCH_STATUS = 0
      BEGIN
			if(@ColumnIdStr < 50)
				SET @concatStr = @ConcatStr + @FactorStr;
			FETCH NEXT FROM record_cursor INTO @ColumnIdStr, @FactorStr
      END
CLOSE record_cursor
DEALLOCATE record_cursor
select @concatStr as ans 
  


--manually Aggified query
select dt2.concatString from( 
(SELECT var2 FROM Table2 WHERE Table2ID = 537) dt1
cross apply
(select dbo.Agg_L1_w2(column_id, factor) as concatString  from Table1 where column_id<62000) dt2
)
option (maxdop 1)