using System;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.UserDefined,
    MaxByteSize = 8000)]
public struct SingleReturnString : INullable, IBinarySerialize
{
    private bool is_Null;
    private SqlString _val;

    public bool IsNull
    {
        get
        {
            return (is_Null);
        }
    }

    public static SingleReturnString Null
    {
        get
        {
            SingleReturnString sr = new SingleReturnString();
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
    public static SingleReturnString Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;


        SingleReturnString sr = new SingleReturnString();
        sr.val = s.Value.ToString();

        return sr;
    }

    public SqlString val
    {
        get
        {
            return this._val;
        }
        set
        {
            SqlString temp = _val;
            _val = value;
        }
    }

    public void Read(System.IO.BinaryReader r)
    {
        _val = r.ReadString();
    }
    public void Write(System.IO.BinaryWriter w)
    {
        w.Write(_val.ToString());
    }
}
