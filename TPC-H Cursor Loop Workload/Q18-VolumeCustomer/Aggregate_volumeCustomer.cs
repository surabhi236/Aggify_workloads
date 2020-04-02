[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SqlUserDefinedAggregate(
    Format.UserDefined,
    IsInvariantToDuplicates = false,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    IsNullIfEmpty = true,
    MaxByteSize = -1)]

public class VolumeCustomer1 : IBinarySerialize
{
    decimal sumQty;
    SqlInt64 ret;
    bool isInitialised;

    public void Init()
    {
	isInitialised = False;
    }

    public void Accumulate(decimal qty, decimal pSumQty, SqlInt64 pRet)
    {
	if(!isInitialised){
		ret = pRet;
		sumQty = pSumQty;
		isInitialised = True;
	}
        sumQty += qty;
    }

    public void Merge(VolumeCustomer1 other)
    {
        
    }

    public IntDecimal Terminate()
    {
        IntDecimal sd = new IntDecimal();
        sd.i = ret;
        sd.d = sumQty;
        return sd;
    }
    public void Read(BinaryReader r)
    {
        sumQty = r.ReadDecimal();
    }

    public void Write(BinaryWriter w)
    {
        w.Write(sumQty);
    }
}