[Serializable]
[SqlUserDefinedAggregate(
    Format.Native,
    IsInvariantToDuplicates = false,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    IsNullIfEmpty = true)]
public struct WaitingOrders1
{
    SqlInt64 count;
    bool isInitialised;

    public void Init()
    {
        isInitialised = False;
    }

    public void Accumulate(SqlInt64 ok, SqlInt32 pk, SqlInt32 sk, SqlInt32 ln, SqlInt64 pCount)
    {
	if(!isInitialised)
	{
		count = pCount;
		isInitialised = True;
	}
        count += 1;
    }

    public void Merge(WaitingOrders1 other)
    {
        
    }

    public SingleReturn Terminate()
    {
        SingleReturn sr = new SingleReturn();
        sr.val = count;
        return sr;
    }
}