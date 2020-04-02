using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SqlUserDefinedAggregate(
    Format.Native,
    IsInvariantToDuplicates = true,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    IsNullIfEmpty = true)]

public class Aggify_sp
{
    SqlInt64 numberOfItems;
    SqlInt64 quantity;
    SqlInt64 maxBid;
    public void Init()
    {
        quantity = 50000;
        numberOfItems = 0;
    }

    public void Accumulate(SqlInt64 qty, SqlInt64 max_bid)
    {
        numberOfItems += qty;
        if(numberOfItems >= quantity)
        {
            maxBid = max_bid;
        }
    }

    public void Merge(Aggify_sp other)
    {

    }

    public SqlInt64 Terminate()
    {
        return maxBid;
    }
}