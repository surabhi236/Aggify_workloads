using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;
using System.IO;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SqlUserDefinedAggregate(
    Format.Native,
    IsInvariantToDuplicates = false,
    IsInvariantToNulls = true,
    IsInvariantToOrder = false,
    IsNullIfEmpty = true,
    MaxByteSize = -1)]

public class Agg_L4_W2: IBinarySerialize
{
    StringBuilder concatStr;
    StringBuilder concatBool;
    StringBuilder concatDate;
    StringBuilder concatErr;
 	bool isInitialized;

    public void Init()
    {
    	isInitialized = False;
    }

    public void Accumulate(SqlString strVal, SqlInt32 typeID)
    {
    	if(!isInitialized)
    	{
    		concatStr = new stringBuilder();
    		concatBool = new stringBuilder();
    		concatDate = new stringBuilder();
    		concatErr = new stringBuilder();
    		isInitialized = True;
    	}
        if (typeID == 1)
         	concatStr.append(strVal);

        else if (typeID == 2)
	        concatBool.append(strVal);

        else if (typeID == 3)
         	concatDate.append(strVal);

        else
            concatErr.append(strVal);
    }

    public void Merge(Agg_L4_W2 other)
    {
       
    }

    public FourReturnInt Terminate()
    {
        FourReturnString sp = new FourReturnString();
        sp.str1 = concatStr.ToString();
        sp.str2 = concatBool.ToString();
        sp.str3 = concatDate.ToString();
        sp.str4 = concatErr.ToString();
        return sp;
    }
    public void Read(BinaryReader r)
    {
    	concatStr = new StringBuilder(r.ReadString());
    	concatBool = new StringBuilder(r.ReadString());
    	concatDate = new StringBuilder(r.ReadString());
    	concatErr = new StringBuilder(r.ReadString());
    }
   
   	public void Write(BinaryWriter w)
    {
        w.Write(concatStr.ToString());
        w.Write(concatBool.ToString());
        w.Write(concatDate.ToString());
        w.Write(concatErr.ToString());
    }
}