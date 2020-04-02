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
    MaxByteSize = 8000)]

public class Agg_L5_W2 : IBinarySerialize
{
    Stringbuilder concatStr;
    bool isInitialized;

    public void Init()
    {
	    isInitialized = false;
    }

    public void Accumulate(SqlString colName, SqlString colId, SqlString ColVal)
    {
    	if(!isInitialized)
    	{
    		concatStr = new StringBuilder();
    		isInitialized = true;	
    	}
        if ((SqlInt32)colId < 50 && (SqlInt32)ColVal < 2)
            concatStr = concatStr + colId + "," + ColVal + ".";
    }

    public void Merge(Agg_L5_W2 other)
    {

    }

    public SingleReturnString Terminate()
    {
        SingleReturnString sp = new SingleReturnString();
        sp.val = concatStr.ToString();
        return sp;
    }
    public void Read(BinaryReader r)
    {
        concatStr = new StringBuilder(r.ReadString());
    }

    public void Write(BinaryWriter w)
    {
        w.Write(concatStr.ToString());
    }
}