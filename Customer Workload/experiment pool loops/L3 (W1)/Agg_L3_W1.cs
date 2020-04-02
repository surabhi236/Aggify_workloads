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
    //IsInvariantToOrder = true,
    IsNullIfEmpty = true)]

public struct Agg_L3_W1
{
	bool isInitialized;
    SqlInt32 intVar;
    SqlInt32 u;
    SqlInt32 lVar;

    public void Init()
    {
    	isInitialized = False;
    }

    [SqlFunction(DataAccess = DataAccessKind.Read)]
    public void Accumulate(SqlInt32 y)
    {
    	if(!isInitialized)
    	{
    		isInitialized = True;
    		intVar = 0;
	        u = 1;
	        lVar = 1;
    	}
        using (SqlConnection conn = new SqlConnection("Trusted_Connection=True; Enlist=False"))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(conn);
            cmd.ExecuteScalar();

            if (y == 9957)
            {
                cmd = new SqlCommand("tableB(o,t,d,s) select KAId,-9953,@c,0 from KA o join tableB c on c.o=o.LLId and c.d=@c and c.t=9957", conn);
                cmd.ExecuteScalar();
            }

            if (y == 4618)
            {
                if (u == 1)
                {
                    cmd = new SqlCommand("insert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x; insert into tableB(o,t,d,s)select o.stepId,4608,@n,ComponentState from MLTable o,tableB c where c.t=4618 and c.o=o.Eh and o.ETCode=4618 and c.d=@c", conn); cmd.ExecuteScalar();
                }
                else
                {
                    cmd = new SqlCommand("insert into tableB(o,t,d,s)select o.stepId,4608,@n,0 from MTable o,tableB c where c.t=4618 and c.o=o.Eh and o.ETCode=4618 and c.d=@c", conn); cmd.ExecuteScalar();
                }
            }

            if (y == 1234)
            {
                if (u == 1)
                {
                    cmd = new SqlCommand("insert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x; insert into tableB(o,t,d,s)select o.ChannelPropertyId,1236,0,ComponentState from ChannelPropertyLogicalAsIfPublished o,tableB c where c.t=1234 and c.o=o.RegardingObjectId and o.RegardingObjectTypeCode=1234 and c.d=-1", conn); cmd.ExecuteScalar();
                }
                else
                {
                    cmd = new SqlCommand("insert into tableB(o, t, d, s)select o.ChannelPropertyId,1236,0,0 from ChannelPropertyAsIfPublished o,tableB c where c.t = 1234 and c.o = o.RegardingObjectId and o.RegardingObjectTypeCode = 1234 and c.d = -1", conn); cmd.ExecuteScalar(); 	
        
                }
            }

            if (y == 4810)
            {
                cmd = new SqlCommand("nsert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x;  insert into tableB(o,t,d,s)select o.TimeZoneRuleId,4811,0,0 from TimeZoneRule o,tableB c where c.t=4810 and c.o=o.TimeZoneDefinitionId and c.d=-1 ; insert into tableB(o, t, d, s)select o.TimeZoneLocalizedNameId,4812,0,0 from TimeZoneLocalizedName o,tableB c where c.t = 4810 and c.o = o.TimeZoneDefinitionId and c.d = -1", conn); cmd.ExecuteScalar(); 
        
    }

            if (y == 1002)
            {
                cmd = new SqlCommand("nsert into tableB(o,t,d,s) select 'FFDFDEFE-CF82-4E72-AC06-5850DA7657A8',t,9957,0 from x; insert tableB(o,t,d,s) select ActivityMimeAttachmentId,-1001,-1,0 from ActivityAttachmentAsIfPublished o join tableB c on c.o=o.AttachmentId and c.d=-1 and c.t=1002", conn); cmd.ExecuteScalar();
            }

            if (y == 9603)
            {
                cmd = new SqlCommand("insert tableB(o,t,d,s) select GoalId,-9600,-1,0 from Goal o join tableB c on c.o=o.MetricId and c.d=-1 and c.t=9603; insert into tableB(o, t, d, s)select o.RollupFieldId,9604,0,0 from RollupField o,tableB c where c.t = 9603 and c.o = o.MetricId and c.d = -1", conn); cmd.ExecuteScalar(); 
            }

            if (y == 1200)
            {
                cmd = new SqlCommand("insert into tableB(o,t,d,s)select o.TeamProfileId,1203,0,0 from TeamProfiles o,tableB c where c.t=1200 and c.o=o.FieldSecurityProfileId and c.d=-1", conn); cmd.ExecuteScalar();

                if (u == 1)
                {
                    cmd = new SqlCommand("insert into tableB(o, t, d, s)select o.FieldPermissionId,1201,0,ComponentState from FieldPermissionLogicalAsIfPublished o, tableB c where c.t = 1200 and c.o = o.FieldSecurityProfileId and c.d = -1", conn); cmd.ExecuteScalar(); 
                 }
                else {
                    cmd = new SqlCommand("insert into tableB(o, t, d, s)select o.FieldPermissionId,1201,0,0 from FieldPermissionAsIfPublished o,tableB c where c.t = 1200 and c.o = o.FieldSecurityProfileId and c.d = -1", conn); cmd.ExecuteScalar();
                }     
    }

            if (y == 92)
            {
                cmd = new SqlCommand("insert into tableB(o,t,d,s)select o.TeamId,9,0,0 from Team o,tableB c where c.t=92 and c.o=o.TeamTemplateId and c.d=-1", conn); cmd.ExecuteScalar();
            }

            if (y == 9602)
            {
                cmd = new SqlCommand("insert tableB(o,t,d,s) select GoalId,-9600,-1,0 from Goal o join tableB c on c.o=o.RollUpQueryInprogressMoneyId and c.d=-1 and c.t=9602; " +
                    "insert tableB(o, t, d, s) select GoalId,-9600,-1,0 from Goal o join tableB c on c.o = o.RollupQueryActualIntegerId and c.d = -1 and c.t = 9602; " +
                    "insert tableB(o, t, d, s) select GoalId,-9600,-1,0 from Goal o join tableB c on c.o = o.RollUpQueryCustomMoneyId and c.d = -1 and c.t = 9602 ; " +
                    "insert tableB(o, t, d, s) select GoalId,-9600,-1,0 from Goal o join tableB c on c.o = o.RollUpQueryActualDecimalId and c.d = -1 and c.t = 9602", conn); cmd.ExecuteScalar();
            }

            if (y == 7101)
            {
                cmd = new SqlCommand("insert tableB(o,t,d,s) select SolutionId,-7100,-1,0 from Solution o join tableB c on c.o=o.PublisherId and c.d=-1 and c.t=7101; " +
                    "insert into tableB(o, t, d, s)select o.PublisherAddressId,7102,0,0 from PublisherAddress o,tableB c where c.t = 7101 and c.o = o.ParentId and c.d = -1", conn); cmd.ExecuteScalar(); 
            }

            if (y == 3231)
            {
                cmd = new SqlCommand("insert into tableB(o,t,d,s)select o.ConnectionRoleAssociationId,3232,0,0 from ConnectionRoleAssociation o,tableB c where c.t=3231 and c.o=o.ConnectionRoleId and c.d=-1 and o.ConnectionRoleAssociationId not in(select o from tableB where t=3232) ; insert into tableB(o,t,d,s)select o.ConnectionRoleObjectTypeCodeId,3233,0,0 from ConnectionRoleObjectTypeCode o,tableB c where c.t=3231 and c.o=o.ConnectionRoleId and c.d=-1 ; insert into tableB(o,t,d,s)select o.ConnectionRoleAssociationId,3232,0,0 from ConnectionRoleAssociation o,tableB c where c.t=3231 and c.o=o.AssociatedConnectionRoleId and c.d=-1 and o.ConnectionRoleAssociationId not in(select o from tableB where t=3232)", conn); cmd.ExecuteScalar();
            }

            if (y == 4605)
            {
                if (u == 1)
                {
                    cmd = new SqlCommand("insert into tableB(o,t,d,s)select o.PluginTypeId,4602,0,ComponentState from PluginTypeLogicalAsIfPublished o,tableB c where c.t=4605 and c.o=o.PluginAssemblyId and c.d=-1", conn); cmd.ExecuteScalar();
                }
                else
                {
                    cmd = new SqlCommand("insert into tableB(o,t,d,s)select o.PluginTypeId,4602,0,0 from PluginTypeAsIfPublished o,tableB c where c.t=4605 and c.o=o.PluginAssemblyId and c.d=-1", conn); cmd.ExecuteScalar();
                }
            }
        }
    }

    public void Merge(CRM_agg_cascadeDelete other)
    {

    }

    public SqlInt32 Terminate()
    {
        return intVar;
    }
}
