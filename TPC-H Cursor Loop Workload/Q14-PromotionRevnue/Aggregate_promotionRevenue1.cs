[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SqlUserDefinedAggregate(
    Format.UserDefined,
    IsInvariantToDuplicates = false,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    IsNullIfEmpty = true,
    MaxByteSize = -1)]


public class PromoRevenue1 : IBinarySerialize
{
    decimal revenue;
    decimal intermediateVal;
    decimal pRevenue;
    decimal isInitialised;

    public void Init()
    {
	isInitialised = False;
    }

    public void Accumulate(decimal extended_price, decimal discount, decimal pRevenue)
    {
	if(!isInitialised)
	{
		revenue = pRevenue
	}
        intermediateVal = extended_price * (1-discount);
        revenue = revenue + intermediateVal;
    }

    public void Merge(PromoRevenue1 other)
    {
        
    }

    public SingleReturnDecimal Terminate()
    {
        SingleReturnDecimal sd = new SingleReturnDecimal();
        sd.val = revenue;
        return sd;
    }
    public void Read(BinaryReader r)
    {
        revenue = r.ReadDecimal();
    }

    public void Write(BinaryWriter w)
    {
        w.Write(revenue);
    }
}