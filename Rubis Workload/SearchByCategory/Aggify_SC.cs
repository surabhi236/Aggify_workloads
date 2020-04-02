using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SqlUserDefinedAggregate(
    Format.UserDefined,
    IsInvariantToDuplicates = true,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    IsNullIfEmpty = true,
    MaxByteSize = -1)]

public class Aggify_sc : IBinarySerialize
{
    StringBuilder sb;
    SqlInt64 tp;
    public void Init()
    {
        sb = new StringBuilder();
        tp = 0;
    }

    public void Accumulate(SqlString itemName, SqlInt64 itemId, SqlString endDate, SqlInt64 maxBid, SqlInt64 nBids, SqlInt64 initPrice)
    {
        if (maxBid < initPrice)
        {
            maxBid = initPrice;
        }
        sb.Append(itemName.Value);
        sb.Append(itemId.Value);
        sb.Append(endDate.Value);
    }

    public void Merge(Aggify_sc other)
    {

    }

    public SqlString Terminate()
    {
        string ans = sb.ToString();
        return new SqlString(ans);
    }
    public void Read(BinaryReader r)
    {
        sb = new StringBuilder(r.ReadString());
    }

    public void Write(BinaryWriter w)
    {
        w.Write(sb.ToString());
    }
}