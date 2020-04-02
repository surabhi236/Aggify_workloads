using System;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.SqlTypes;
using System.Data;
using System.Data.SqlClient;



[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SqlUserDefinedAggregate(
    Format.Native,
    IsInvariantToDuplicates = false,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    IsNullIfEmpty = true)]

public struct Agg_L3_W1
{
    SqlInt32 intVar;
    bool IsInitialized;

    public void Init()
    {
    	IsInitialized = False;
    }

    [SqlFunction(DataAccess = DataAccessKind.Read)]
    public void Accumulate(SqlInt32 y)
    {
        using (SqlConnection conn = new SqlConnection("Trusted_Connection=True; Enlist=False"))
        {
        	if(!IsInitialized())
        	{
        		intVar = 0;
        		IsInitialized = True;	
        	}
            conn.Open();
            SqlCommand cmd = new SqlCommand(conn);
 
            if (y == 113) 
                 { cmd = new SqlCommand("insert into tableT(o, t, c)select o.IncidentId,112,1 from Incident o,c c where c.t = 113", conn); cmd.ExecuteScalar(); 
                }

            if (y == 3231)
            {
                cmd = new SqlCommand("insert into tableT(o, t, c) select o.ConnectionId,3234,18 from Connection o,c c where c.t = 3231 ; insert into tableT(o, t, c) select o.ConnectionId,3234,16 from Connection o,c c where c.t = 3231", conn); cmd.ExecuteScalar();
            }
            if (y == 9935) {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.RecommendationModelId,9933,20 from RecommendationModelAsIfPublished o,c c where c.t = 9935", conn); cmd.ExecuteScalar();
            }

            if (y == 8)
            {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.BookableResourceId,1150,44 from BookableResource o,c c where c.t = 8", conn); cmd.ExecuteScalar();
            }


            if (y == 9333)
            {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.SolutionId,7100,36 from Solution o,c c where c.t = 9333", conn); cmd.ExecuteScalar();

            }
            if (y == 7100)
            {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.dependencyNodeId,7106,5 from dependencyNode o,c c where c.t = 7100", conn); cmd.ExecuteScalar();
            }

            if (y == 9866)
            {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.OrganizationId,1019,369 from Organization o,c c where c.t = 9866", conn); cmd.ExecuteScalar();
            }

            if (y == 2024)
            {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.QueueId,2020,1 from Queue o,c c where c.t = 2024", conn); cmd.ExecuteScalar();
            }

            if (y == 2023)

            {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.QueueId,2020,1 from Queue o,c c where c.t = 2023", conn); cmd.ExecuteScalar();
            }

            if (y == 4703)
            {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.AsyncOperationId,4700,32 from AsyncOperation o,c c where c.t = 4703", conn); cmd.ExecuteScalar();
            }



            if (y == 4710)
            {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.ProcessSessionId,4710,26 from ProcessSession o,c c where c.t = 4710; insert into tableT(o, t, c)select o.ProcessSessionId,4710,36 from ProcessSession o,c c where c.t = 4710; insert into tableT(o, t, c)select o.ProcessSessionId,4710,24 from ProcessSession o,c c where c.t = 4710", conn); cmd.ExecuteScalar();
            }

            if (y == 9100)
            {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.ReportLinkId,9104,13 from ReportLink o,c c where c.t = 9100;  insert into tableT(o, t, c)select o.ReportId,9100,23 from ReportAsIfPublished o,c c where c.t = 9100", conn); cmd.ExecuteScalar();
            }

            if (y == 1056)
            {
                cmd = new SqlCommand("insert into tableT(o, t, c)select o.ContractDetailId,1011,31 from ContractDetail o,c c where c.t = 1056; insert into tableT(o, t, c)select o.ProductPriceLevelId,1026,4 from ProductPriceLevel o,c c where c.t = 1056", conn); cmd.ExecuteScalar();
            }

            cmd.ExecuteScalar();
        }
    }


    public void Merge(Agg_L3_W1 other)
    {

    }

    public SqlInt32 Terminate()
    {
        return intVar;
    }
}
