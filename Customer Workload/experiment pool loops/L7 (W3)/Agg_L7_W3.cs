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

public class Agg_L7_W3 : IBinarySerialize
{
    StringBuilder concatStr;
    bool isInitialized;

    public void Init()
    {
    	isInitialized = False;
    }

    public void Accumulate(SqlString name, SqlInt32 authscheme, SqlInt64 len)
    {
    	if(!isInitialized)
    	{
    		isInitialized = True;
    		concatStr = new StringBuilder();
    	}
        if (len < 20 && authscheme<5)
            concatStr.append(name);
    }

    public void Merge(Agg_L7_W3 other)
    {

    }

    public SqlString Terminate()
    {
        return concatStr.ToString();
    }
    public void Read(BinaryReader r)
    {
        concatStr = new stringBuilder(r.ReadString());
    }

    public void Write(BinaryWriter w)
    {
        w.Write(concatStr.ToString());
    }
}