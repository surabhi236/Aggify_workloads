using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.SqlClient;


[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SqlUserDefinedAggregate(
    Format.Native,
    IsInvariantToDuplicates = true,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    IsNullIfEmpty = true)]

public class Agg_L6_W2
{
    SqlInt32 ret;
    int isSysFolder;
    int parentEntityTableId;
    bool isInitialized;

    public void Init()
    {
    	isInitialized = false;
        ret = 0;
    }

    public void Accumulate(SqlInt32 child_id)
    {


        using (SqlConnection conn = new SqlConnection("Trusted_Connection=True; Enlist=False"))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(conn);
            cmd.ExecuteScalar();
            if (result.Read())
            {
                isSysFolder = (int)result["sf"];
                parentEntityTableId = (int)result["pe"];
            }
            if (isSysFolder == 1)
            {
                cmd = new SqlCommand(
                    "insert into newTab(ParentFileAndLinkFolderID, Descr, parentId, parentEntityTableId, viewSeq, isSysFold) " +
                                        "(select 965, (select[Description] from FileAndLinkFolder where FileAndLinkFolderID =" + child_id + "), " +
                                        "[ParentID], [ParentEntityTableID], " +
                                        "5760, 0 from FileAndLinkFolder " +
                                        "where FileAndLinkFolderID = 965)", conn);
                cmd.ExecuteScalar();
            }
        }
    }

    public void Merge(Agg_L6_W2 other)
    {

    }

    public SqlInt32 Terminate()
    {
        return ret;
    }
}