USE W2;
GO

DECLARE @bName as nvarchar(200)
DECLARE @UpdateString as nvarchar(1024)
DECLARE @concatStr as nvarchar(1024)
DECLARE @ParmDefinition nvarchar(50)
DECLARE @IsSelected As BIT
DECLARE @pcId AS INT
DECLARE @scId AS INT
DECLARE sCursor CURSOR static forward_only FOR
Select Table2.bName, Table3.pcId 
FROM Table1 INNER JOIN Table2 ON Table1.cId = Table2.cId INNER JOIN Table3 ON Table2.cbId = Table3.cbId
Where Table1.ctId=1 And Table3.pId=473

OPEN sCursor
FETCH NEXT FROM sCursor INTO @bName, @pcId
WHILE @@FETCH_STATUS = 0
	BEGIN
		set @concatStr += 'ALTER TABLE #tableTemp ADD [' + @bName + '] bit not null DEFAULT(0)';
		DECLARE record_cursor2 CURSOR static forward_only FOR (SELECT scId from tableTemp)
		OPEN record_cursor2
		FETCH NEXT FROM record_cursor2 INTO @scId
		WHILE @@FETCH_STATUS = 0
			BEGIN
				Set @IsSelected = 0
				SET @UpdateString = 'UPDATE #tableTemp SET [' + @bName + '] = ' + CAST(@IsSelected As nvarchar(10)) + ' WHERE scId = @scId'
				SET @ParmDefinition = N'@scId int';
				FETCH NEXT FROM record_cursor2 INTO @scId
			END
		CLOSE record_cursor2
		DEALLOCATE record_cursor2
		FETCH NEXT FROM sCursor INTO @bName, @pcId
	END
CLOSE sCursor
Deallocate sCursor


--Aggified Query
select dbo.Agg_L8_W2(t.bn, t.ci) from (Select Table2.bName as bn, Table3.pcId as ci
										FROM Table1 INNER JOIN Table2 ON Table1.cId = Table2.cId INNER JOIN Table3 ON Table2.cbId = Table3.cbId
										Where Table1.ctId=1 And Table3.pId=473)t