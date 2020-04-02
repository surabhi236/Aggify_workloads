[Serializable]
[SqlUserDefinedAggregate(
    Format.Native,
    IsInvariantToDuplicates = false,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    IsNullIfEmpty = true)]
public struct OrdersByCustomer1
{
    SqlInt64 pCount;
    SqlInt64 count;
    bool isInitialised;

    public void Init()
    {
	isInitialised = False;
    }

    public void Accumulate(SqlInt64 ok, SqlInt64 pCount)
    {
	if(!isInitiliased)
	{
		count = pCount;
		isInitialised = True;
	}
        count += 1;
    }

    public void Merge(OrdersByCustomer1 other)
    {
       
    }

    public SingleReturn Terminate()
    {
        SingleReturn sr = new SingleReturn();
        sr.val = count;
        return sr;
    }
}