using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
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

public class Agg_L8_W2_outer : IBinarySerialize
{
    SqlInt32 isSelected;
    StringBuilder concatStr;

    public void Init()
    {
    	isInitialized = False;
    }

    public void Accumulate(SqlString branch_name, SqlInt32 projectCompanyId)
    {
    	if(!isInitialized)
    	{
    		isSelected = 0;
    		concatStr = new StringBuilder();
    		isInitialized = True;
    	}
        concatStr.append("ALTER TABLE #SupplierSortCodes_temp ADD [" + branch_name + "] bit not null DEFAULT(0)");
        using (SqlConnection conn = new SqlConnection("Trusted_Connection=True; Enlist=False"))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select dbo.Agg_L8_W2_inner(t.p) as udtVal from (select ScId as p from tableTemp) as t", conn);
            cmd.ExecuteScalar();
        }
    }

    public void Merge(Agg_L8_W2_outer other)
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