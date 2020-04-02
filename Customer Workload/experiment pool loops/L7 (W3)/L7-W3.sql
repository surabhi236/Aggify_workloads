use W3

declare @pnConfig nvarchar(1024);
SET @pnConfig = '';

-- Enumerate endpoints 
DECLARE epCursor CURSOR static forward_only FOR (SELECT Nam, authscheme, leng FROM Table1) 
DECLARE @Name NVARCHAR(512) 
DECLARE @CAscheme INT
DECLARE @rlimitLength BIGINT
 
OPEN epCursor  
FETCH NEXT FROM epCursor INTO @Name, @CAscheme, @rlimitLength
WHILE @@FETCH_STATUS = 0  
BEGIN 
	if(@rlimitLength<20 and @CAscheme<5)
	begin
		SET @pnConfig = @pnConfig + @Name 
	end
    FETCH NEXT FROM epCursor INTO @Name, @CAscheme, @rlimitLength
 
END 
CLOSE epCursor
DEALLOCATE epCursor
select @pnConfig as ans

--Aggified Query
select dbo.Agg_L7_W3(Nam, authscheme, leng) FROM Table1