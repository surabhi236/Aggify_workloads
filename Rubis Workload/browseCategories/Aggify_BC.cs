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

public struct Aggify_bc : IBinarySerialize
{
    SqlString toPrint, printRegion, printSellName, printCat;
    SqlInt64 tp, pr, psn, pc;
    StringBuilder sb;
    int i;

    public void Init()
    {
        i = 1;
        tp = pr = psn = pc = 0;
        toPrint = "";
        printRegion = "";
        printSellName = "";
        printCat = "";
        sb = new StringBuilder();
    }

    public void Accumulate(SqlString cat_name, SqlInt64 userId, SqlInt64 regionId)
    {
        if (i == 1)
        {
            toPrint += "curently available categories";
            i += 1;
        }
        if (regionId != -1)
        {
            sb.Append(cat_name.Value);
        }
        else
        {
            if (userId != -1)
                sb.Append(cat_name.Value);
            else
                sb.Append(cat_name.Value);
            //printCat += cat_name;
        }
    }

    public void Merge(Aggify_bc other)
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