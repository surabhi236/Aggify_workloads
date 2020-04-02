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

public class Aggify_br : IBinarySerialize
{
    SqlInt64 tp, pr, psn, pc;
    SqlString toPrint, printRegion;
    StringBuilder sb;
    int i;

    public void Init()
    {
        i = 1;
        toPrint = "";
        tp = pr = psn = pc = 0;
        sb = new StringBuilder();
    }

    public void Accumulate(SqlString regionName, SqlInt64 id)
    {
        if (i == 1)
        {
            toPrint += "curently available regions: ";
            i += 1;
        }
        sb.Append(regionName.Value);
    }

    public void Merge(Aggify_br other)
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