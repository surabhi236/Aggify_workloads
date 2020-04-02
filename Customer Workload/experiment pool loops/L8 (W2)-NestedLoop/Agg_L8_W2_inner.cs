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

public class Agg_L8_W2_inner : IBinarySerialize
{
    SqlInt32 isSelected;
    StringBuilder concatStr;
    bool isInitialized;

    public void Init()
    {
    	isInitialized = False;
    }

    public void Accumulate(SqlInt32 branch_name)
    {
    	if(!isInitialized)
    	{
    		concatStr = new StringBuilder();
       		isSelected = 0;
    		isInitialized = True;
    	}
        isSelected = 1;
        concatStr.append("UPDATE";// #SupplierSortCodes_temp SET" [" + branch_name + "] = " + " WHERE scId = @SortCodeID'");
    }

    public void Merge(Agg_L8_W2_inner other)
    {

    }

    public SqlString Terminate()
    {
        return concatStr.toString();
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