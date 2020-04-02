using System;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native,
     IsByteOrdered = true, ValidationMethodName = "ValidatePoint")]
public struct SingleReturn : INullable
{
    private bool is_Null;
    private SqlInt64 _val;

    public bool IsNull
    {
        get
        {
            return (is_Null);
        }
    }

    public static SingleReturn Null
    {
        get
        {
            SingleReturn sr = new SingleReturn();
            sr.is_Null = true;
            return sr;
        }
    }

    // Use StringBuilder to provide string representation of UDT.  
    public override string ToString()
    {
        if (this.IsNull)
            return "NULL";
        else
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_val);
            return builder.ToString();
        }
    }

    [SqlMethod(OnNullCall = false)]
    public static SingleReturn Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;

        SingleReturn sr = new SingleReturn();
        string xy = s.Value;
        sr.val = Int64.Parse(xy);
        return sr;
    }

    public SqlInt64 val
    {
        get
        {
            return this._val;
        }  
        set
        {
            SqlInt64 temp = _val;
            _val = value;
        }
    }
}
