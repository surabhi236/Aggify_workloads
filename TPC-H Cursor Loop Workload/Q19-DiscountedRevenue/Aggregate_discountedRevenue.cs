public class DiscountedRevenue1 : IBinarySerialize
{
    decimal DiscRevenue;
    decimal intermediateVal;
    bool isInitialised;

    public void Init()
    {
        isInitialised = False;
    }

    public void Accumulate(decimal extended_price, decimal discount, decimal pDiscRevenue)
    {
	if(!isInitialised){
		DiscRevenue = pDiscRevenue;	
        	isInitialised = True;
	}
	intermediateVal = extended_price * (1- discount);
        DiscRevenue = intermediateVal + DiscRevenue;
    }

    public void Merge(DiscountedRevenue1 other)
    {
        
    }

    public SingleReturnDecimal Terminate()
    {
        SingleReturnDecimal sd = new SingleReturnDecimal();
        sd.val = DiscRevenue;
        return sd;
    }
    public void Read(BinaryReader r)
    {
        DiscRevenue = r.ReadDecimal();
    }

    public void Write(BinaryWriter w)
    {
        w.Write(DiscRevenue);
    }
}