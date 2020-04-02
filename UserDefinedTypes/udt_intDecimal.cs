using System;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

//user defined collection with one bigint and one decimal value

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.UserDefined,
     IsByteOrdered = true, ValidationMethodName = "ValidatePoint", MaxByteSize = 8000)]
public struct IntDecimal : INullable, IBinarySerialize
{
    private bool is_Null;
    private SqlInt64 _i;
    private decimal _d;

    public bool IsNull
    {
        get
        {
            return (is_Null);
        }
    }

    public static IntDecimal Null
    {
        get
        {
            IntDecimal sp = new IntDecimal();
            sp.is_Null = true;
            return sp;
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
            builder.Append(_i);
            builder.Append(",");
            builder.Append(_d);
            return builder.ToString();
        }
    }

    [SqlMethod(OnNullCall = false)]
    public static IntDecimal Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;

        // Parse input string to separate out sum and prod.  
        IntDecimal sp = new IntDecimal();
        string[] xy = s.Value.Split(",".ToCharArray());
        //sp.sum = Int64.Parse(xy[0]);
        sp.i = SqlInt64.Parse(xy[0]);
        sp.d = decimal.Parse(xy[1]);

        // Call ValidatePoint to enforce validation  
        // for string conversions.  
        if (!sp.ValidatePoint())
            throw new ArgumentException("Invalid sum and prod values");
        return sp;
    }
 
    public SqlInt64 i  //sqlint64
    {
        get
        {
            return this._i;
        }
        
        set
        {
            SqlInt64 temp = _i; //sqlint64
            _i = value;
        }
    }

    public decimal d
    {
        get
        {
            return this._d;
        }
        set
        {
            decimal temp = _d;
            _d = value;
            if (!ValidatePoint())
            {
                _d = temp;
                throw new ArgumentException("Invalid prod value.");
            }
        }
    }

    public void Read(System.IO.BinaryReader r)
    {
        _d = r.ReadDecimal();

    }
    public void Write(System.IO.BinaryWriter w)
    {
        w.Write(_d);

    }
}
