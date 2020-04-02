--nested loop example

USE W2;
GO

DECLARE @Jid int
Set @Jid = 2;
DECLARE @factorTId int
set @factorTId = 30;
DECLARE @Fid AS INT
DECLARE @Description AS nvarchar(64)
DECLARE @concatDesc AS nvarchar(128)
DECLARE @JIndus int
DECLARE @imp AS BIT
SET @imp = 1
IF (@factorTId = 2)
	BEGIN
		SET @imp = (SELECT Imp
					FROM Job
					WHERE Jid = @Jid)
	END
SELECT @JIndus=Industry FROM Job WHERE Jid=@Jid
DECLARE @UpdateString as nvarchar(1024)
DECLARE record_cursor CURSOR LOCAL FOR
									SELECT Description 
									FROM Table3 
									WHERE dbo.function_call(Industry,@JIndus)=1 ORDER BY ViewSequence
OPEN record_cursor
FETCH NEXT FROM record_cursor INTO @Description
WHILE @@FETCH_STATUS = 0
	BEGIN
		set @concatDesc = @concatDesc + @Description;
		FETCH NEXT FROM record_cursor INTO @Description
	END
CLOSE record_cursor



DECLARE @lfValue AS decimal(6,3)
DECLARE @LfColName AS nvarchar(64)
DECLARE @ParmDefinition NVARCHAR(500);
DECLARE record_cursor2 CURSOR LOCAL FOR SELECT LfId from table1

OPEN record_cursor2
FETCH NEXT FROM record_cursor2 INTO @Fid
	WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE record_cursor3 CURSOR FOR
				SELECT Lfact, Table3.Description AS ColumnHeader
				FROM	table1 INNER JOIN dbo.Table2 ON table1.LfId = Table2.LfId INNER JOIN Table3 ON Table2.LfCid = Table3.LfCid AND dbo.function_call(Industry,@JIndus)=1
				WHERE (table1.Jid = @Jid) AND (table1.LfId = @Fid)
				
			OPEN record_cursor3
			FETCH NEXT FROM record_cursor3 INTO @lfValue, @LfColName
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @UpdateString = 'UPDATE #LaborFactor_Acc_d086bd33 SET [' + @LfColName + '] = ' + CAST(@lfValue AS nvarchar(10)) + ' WHERE LfId = @Fid'
					SET @ParmDefinition = N'@Fid int';
					FETCH NEXT FROM record_cursor3 INTO @lfValue, @LfColName
				END
			CLOSE record_cursor3
			DEALLOCATE record_cursor3
		FETCH NEXT FROM record_cursor2 INTO @Fid
	END
CLOSE record_cursor2