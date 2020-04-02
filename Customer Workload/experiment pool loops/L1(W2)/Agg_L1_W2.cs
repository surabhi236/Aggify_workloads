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
    IsInvariantToDuplicates = false
    IsInvariantToNulls = false,
    IsInvariantToOrder = false,
    IsNullIfEmpty = false,
    MaxByteSize = -1)]

public class Agg_L1_W2 : IBinarySerialize
{
    SqlString concatStr;
    StringBuilder sb;
    bool isInitlialized;

    public void Init()
    {
	isInitialized = False;
    }

    public void Accumulate(SqlString colId, SqlString factor)
    {
	if(!isInitialized)
	{
	    sb = new StringBuilder();
	    isInitialized = True;
	}
        if((SqlInt32)colId<50)
           sb.Append(factor);
    }

    public void Merge(Agg_L1_W2 other)
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