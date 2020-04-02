using System;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.UserDefined,
     IsByteOrdered = true, MaxByteSize = 8000)]
public struct SingleReturnDecimal : INullable, IBinarySerialize
{
    private bool is_Null;
    private decimal _val;

    public bool IsNull
    {
        get
        {
            return (is_Null);
        }
    }

    public static SingleReturnDecimal Null
    {
        get
        {
            SingleReturnDecimal sr = new SingleReturnDecimal();
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
    public static SingleReturnDecimal Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
 
        SingleReturnDecimal sr = new SingleReturnDecimal();
        string xy = s.Value;
        sr.val = decimal.Parse(xy);

        // Call ValidatePoint to enforce validation  
        // for string conversions.  
        if (!sr.ValidatePoint())
            throw new ArgumentException("Invalid value");
        return sr;
    }

    // sum and prod exposed as properties.  
    public decimal val
    {
        get
        {
            return this._val;
        }
        // Call ValidatePoint to ensure valid range of Point values: not needed actually  
        set
        {
            decimal temp = _val;
            _val = value;
            if (!ValidatePoint())
            {
                _val = temp;
                throw new ArgumentException("Invalid sum value.");
            }
        }
    }

    private bool ValidatePoint()
    {
        return true;
    }

    public void Read(System.IO.BinaryReader r)
    {
        _val = r.ReadDecimal();
    }
    public void Write(System.IO.BinaryWriter w)
    {
        w.Write(_val);
    }
}
