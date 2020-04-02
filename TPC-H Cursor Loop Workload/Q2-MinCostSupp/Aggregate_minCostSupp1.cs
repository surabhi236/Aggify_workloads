[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SqlUserDefinedAggregate(
    Format.UserDefined,
    IsInvariantToDuplicates = true,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    IsNullIfEmpty = true,
    MaxByteSize = 8000)]

public class MinCostSupp1: IBinarySerialize
{
    bool isInitialised;
    SqlString suppName;
    decimal min;

    public void Init()
    {
	isInitialised = False;
    }

    public void Accumulate(decimal fetchedCost, SqlString name, decimal pMin)
    {
        if(!isInitialised)
        {
	    min = pMin;
	    isInitialised = True;
        }
	if(min<fetchedCost)
	{
	    min = fetchedCost;
            suppName = name;	
	}
    }

    public void Merge(MinCostSupp1 other)
    {
        
    }

    public SingleReturnString Terminate()
    {
        SingleReturnString sp = new SingleReturnString();
        sp.val = suppName;
        return sp;
    }
    public void Read(BinaryReader r)
    {
        suppName = r.ReadString();
    }

    public void Write(BinaryWriter w)
    {
        w.Write(suppName.ToString());
    }
}