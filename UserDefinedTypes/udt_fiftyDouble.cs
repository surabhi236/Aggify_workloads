using System;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

//user defined collection with one bigint and one decimal value

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.UserDefined,
     IsByteOrdered = true, MaxByteSize = 8000)]
public struct FiftyDouble : INullable, IBinarySerialize
{
    private bool is_Null;
    private double _fr1; private double _fr2; private double _fr3; private double _fr4; private double _fr5; private double _fr6; private double _fr7; private double _fr8; private double _fr9; private double _fr10;
    private double _fr11; private double _fr12; private double _fr13; private double _fr14; private double _fr15; private double _fr16; private double _fr17;
    private double _fr18; private double _fr19; private double _fr20; private double _fr21; private double _fr22; private double _fr23; private double _fr24; private double _fr25; private double _fr26;
    private double _fr27; private double _fr28; private double _fr29; private double _fr30; private double _fr31; private double _fr32; private double _fr33; private double _fr34; private double _fr35;
    private double _fr36; private double _fr37; private double _fr38; private double _fr39; private double _fr40; private double _fr41; private double _fr42; private double _fr43; private double _fr44;
    private double _fr45; private double _fr46; private double _fr47; private double _fr48; private double _fr49; private double _fr50;

    public bool IsNull
    {
        get
        {
            return (is_Null);
        }
    }

    public static FiftyDouble Null
    {
        get
        {
            FiftyDouble sp = new FiftyDouble();
            sp.is_Null = true;
            return sp;
        }
    }

    // Use StringBuilder to provide string representation of UDT.  
    public override string ToString()
    {
        // Since InvokeIfReceiverIsNull defaults to 'true'  
        // this test is unneccesary if Point is only being called  
        // from SQL.  
        if (this.IsNull)
            return "NULL";
        else
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_fr1); builder.Append(",");
            builder.Append(_fr2); builder.Append(",");
            builder.Append(_fr3); builder.Append(",");
            builder.Append(_fr4); builder.Append(",");
            builder.Append(_fr5); builder.Append(",");
            builder.Append(_fr6); builder.Append(",");
            builder.Append(_fr7); builder.Append(",");
            builder.Append(_fr8); builder.Append(",");
            builder.Append(_fr9); builder.Append(",");
            builder.Append(_fr10); builder.Append(",");
            builder.Append(_fr11); builder.Append(",");
            builder.Append(_fr12); builder.Append(",");
            builder.Append(_fr13); builder.Append(",");
            builder.Append(_fr14); builder.Append(",");
            builder.Append(_fr15); builder.Append(",");
            builder.Append(_fr16); builder.Append(",");
            builder.Append(_fr17); builder.Append(",");
            builder.Append(_fr18); builder.Append(",");
            builder.Append(_fr19); builder.Append(",");
            builder.Append(_fr20); builder.Append(",");
            builder.Append(_fr21); builder.Append(",");
            builder.Append(_fr22); builder.Append(",");
            builder.Append(_fr23); builder.Append(",");
            builder.Append(_fr24); builder.Append(",");
            builder.Append(_fr25); builder.Append(",");
            builder.Append(_fr26); builder.Append(",");
            builder.Append(_fr27); builder.Append(",");
            builder.Append(_fr28); builder.Append(",");
            builder.Append(_fr29); builder.Append(",");
            builder.Append(_fr30); builder.Append(",");
            builder.Append(_fr31); builder.Append(",");
            builder.Append(_fr32); builder.Append(",");
            builder.Append(_fr33); builder.Append(",");
            builder.Append(_fr34); builder.Append(",");
            builder.Append(_fr35); builder.Append(",");
            builder.Append(_fr36); builder.Append(",");
            builder.Append(_fr37); builder.Append(",");
            builder.Append(_fr38); builder.Append(",");
            builder.Append(_fr39); builder.Append(",");
            builder.Append(_fr40); builder.Append(",");
            builder.Append(_fr41); builder.Append(",");
            builder.Append(_fr42); builder.Append(",");
            builder.Append(_fr43); builder.Append(",");
            builder.Append(_fr44); builder.Append(",");
            builder.Append(_fr45); builder.Append(",");
            builder.Append(_fr46); builder.Append(",");
            builder.Append(_fr47); builder.Append(",");
            builder.Append(_fr48); builder.Append(",");
            builder.Append(_fr49); builder.Append(",");
            builder.Append(_fr50);
            return builder.ToString();
        }
    }

    [SqlMethod(OnNullCall = false)]
    public static FiftyDouble Parse(SqlString s)
    {
        // With OnNullCall=false, this check is unnecessary if   
        // Point only called from SQL.  
        if (s.IsNull)
            return Null;

        // Parse input string to separate out sum and prod.  
        FiftyDouble sp = new FiftyDouble();
        string[] cumulativeRoi = s.Value.Split(",".ToCharArray());
        sp.fr1 = double.Parse(cumulativeRoi[0]);
        sp.fr2 = double.Parse(cumulativeRoi[1]);
        sp.fr3 = double.Parse(cumulativeRoi[2]);
        sp.fr4 = double.Parse(cumulativeRoi[3]);
        sp.fr5 = double.Parse(cumulativeRoi[4]);
        sp.fr6 = double.Parse(cumulativeRoi[5]);
        sp.fr7 = double.Parse(cumulativeRoi[6]);
        sp.fr8 = double.Parse(cumulativeRoi[7]);
        sp.fr9 = double.Parse(cumulativeRoi[8]);
        sp.fr10 = double.Parse(cumulativeRoi[9]);
        sp.fr11 = double.Parse(cumulativeRoi[10]);
        sp.fr12 = double.Parse(cumulativeRoi[11]);
        sp.fr13 = double.Parse(cumulativeRoi[12]);
        sp.fr14 = double.Parse(cumulativeRoi[13]);
        sp.fr15 = double.Parse(cumulativeRoi[14]);
        sp.fr16 = double.Parse(cumulativeRoi[15]);
        sp.fr17 = double.Parse(cumulativeRoi[16]);
        sp.fr18 = double.Parse(cumulativeRoi[17]);
        sp.fr19 = double.Parse(cumulativeRoi[18]);
        sp.fr20 = double.Parse(cumulativeRoi[19]);
        sp.fr21 = double.Parse(cumulativeRoi[20]);
        sp.fr22 = double.Parse(cumulativeRoi[21]);
        sp.fr23 = double.Parse(cumulativeRoi[22]);
        sp.fr24 = double.Parse(cumulativeRoi[23]);
        sp.fr25 = double.Parse(cumulativeRoi[24]);
        sp.fr26 = double.Parse(cumulativeRoi[25]);
        sp.fr27 = double.Parse(cumulativeRoi[26]);
        sp.fr28 = double.Parse(cumulativeRoi[27]);
        sp.fr29 = double.Parse(cumulativeRoi[28]);
        sp.fr30 = double.Parse(cumulativeRoi[29]);
        sp.fr31 = double.Parse(cumulativeRoi[30]);
        sp.fr32 = double.Parse(cumulativeRoi[31]);
        sp.fr33 = double.Parse(cumulativeRoi[32]);
        sp.fr34 = double.Parse(cumulativeRoi[33]);
        sp.fr35 = double.Parse(cumulativeRoi[34]);
        sp.fr36 = double.Parse(cumulativeRoi[35]);
        sp.fr37 = double.Parse(cumulativeRoi[36]);
        sp.fr38 = double.Parse(cumulativeRoi[37]);
        sp.fr39 = double.Parse(cumulativeRoi[38]);
        sp.fr40 = double.Parse(cumulativeRoi[39]);
        sp.fr41 = double.Parse(cumulativeRoi[40]);
        sp.fr42 = double.Parse(cumulativeRoi[41]);
        sp.fr43 = double.Parse(cumulativeRoi[42]);
        sp.fr44 = double.Parse(cumulativeRoi[43]);
        sp.fr45 = double.Parse(cumulativeRoi[44]);
        sp.fr46 = double.Parse(cumulativeRoi[45]);
        sp.fr47 = double.Parse(cumulativeRoi[46]);
        sp.fr48 = double.Parse(cumulativeRoi[47]);
        sp.fr49 = double.Parse(cumulativeRoi[48]);
        sp.fr50 = double.Parse(cumulativeRoi[49]);
        return sp;
    }

    public double fr1
    {
        get
        {
            return this._fr1;
        }
        set
        {
            double temp = _fr1;
            _fr1 = value;
        }
    }

    public double fr2
    {
        get
        {
            return this._fr2;
        }
        set
        {
            double temp = _fr2;
            _fr2 = value;
        }
    }

    public double fr3
    {
        get
        {
            return this._fr3;
        }
        set
        {
            double temp = _fr3;
            _fr3 = value;
        }
    }

    public double fr4
    {
        get
        {
            return this._fr4;
        }
        set
        {
            double temp = _fr4;
            _fr4 = value;
        }
    }

    public double fr5
    {
        get
        {
            return this._fr5;
        }
        set
        {
            double temp = _fr5;
            _fr5 = value;
        }
    }

    public double fr6
    {
        get
        {
            return this._fr6;
        }
        set
        {
            double temp = _fr6;
            _fr6 = value;
        }
    }

    public double fr7
    {
        get
        {
            return this._fr7;
        }
        set
        {
            double temp = _fr7;
            _fr7 = value;
        }
    }

    public double fr8
    {
        get
        {
            return this._fr8;
        }
        set
        {
            double temp = _fr8;
            _fr8 = value;
        }
    }

    public double fr9
    {
        get
        {
            return this._fr9;
        }
        set
        {
            double temp = _fr9;
            _fr9 = value;
        }
    }

    public double fr10
    {
        get
        {
            return this._fr10;
        }
        set
        {
            double temp = _fr10;
            _fr10 = value;
        }
    }

    public double fr11
    {
        get
        {
            return this._fr11;
        }
        set
        {
            double temp = _fr11;
            _fr11 = value;
        }
    }

    public double fr12
    {
        get
        {
            return this._fr12;
        }
        set
        {
            double temp = _fr12;
            _fr12 = value;
        }
    }

    public double fr13
    {
        get
        {
            return this._fr13;
        }
        set
        {
            double temp = _fr13;
            _fr13 = value;
        }
    }

    public double fr14
    {
        get
        {
            return this._fr14;
        }
        set
        {
            double temp = _fr14;
            _fr14 = value;
        }
    }

    public double fr15
    {
        get
        {
            return this._fr15;
        }
        set
        {
            double temp = _fr15;
            _fr15 = value;
        }
    }

    public double fr16
    {
        get
        {
            return this._fr16;
        }
        set
        {
            double temp = _fr16;
            _fr16 = value;
        }
    }

    public double fr17
    {
        get
        {
            return this._fr17;
        }
        set
        {
            double temp = _fr17;
            _fr17 = value;
        }
    }

    public double fr18
    {
        get
        {
            return this._fr18;
        }
        set
        {
            double temp = _fr18;
            _fr18 = value;
        }
    }

    public double fr19
    {
        get
        {
            return this._fr19;
        }
        set
        {
            double temp = _fr19;
            _fr19 = value;
        }
    }
    public double fr20
    {
        get
        {
            return this._fr20;
        }
        set
        {
            double temp = _fr20;
            _fr20 = value;
        }
    }

    public double fr21
    {
        get
        {
            return this._fr21;
        }
        set
        {
            double temp = _fr21;
            _fr21 = value;
        }
    }

    public double fr22
    {
        get
        {
            return this._fr22;
        }
        set
        {
            double temp = _fr22;
            _fr22 = value;
        }
    }

    public double fr23
    {
        get
        {
            return this._fr23;
        }
        set
        {
            double temp = _fr23;
            _fr23 = value;
        }
    }

    public double fr24
    {
        get
        {
            return this._fr24;
        }
        set
        {
            double temp = _fr24;
            _fr24 = value;
        }
    }

    public double fr25
    {
        get
        {
            return this._fr25;
        }
        set
        {
            double temp = _fr25;
            _fr25 = value;
        }
    }

    public double fr26
    {
        get
        {
            return this._fr26;
        }
        set
        {
            double temp = _fr26;
            _fr26 = value;
        }
    }

    public double fr27
    {
        get
        {
            return this._fr27;
        }
        set
        {
            double temp = _fr27;
            _fr27 = value;
        }
    }

    public double fr28
    {
        get
        {
            return this._fr28;
        }
        set
        {
            double temp = _fr28;
            _fr28 = value;
        }
    }

    public double fr29
    {
        get
        {
            return this._fr29;
        }
        set
        {
            double temp = _fr29;
            _fr29 = value;
        }
    }

    public double fr30
    {
        get
        {
            return this._fr30;
        }
        set
        {
            double temp = _fr30;
            _fr30 = value;
        }
    }

    public double fr31
    {
        get
        {
            return this._fr31;
        }
        set
        {
            double temp = _fr31;
            _fr31 = value;
        }
    }

    public double fr32
    {
        get
        {
            return this._fr32;
        }
        set
        {
            double temp = _fr32;
            _fr32 = value;
        }
    }

    public double fr33
    {
        get
        {
            return this._fr33;
        }
        set
        {
            double temp = _fr33;
            _fr33 = value;
        }
    }

    public double fr34
    {
        get
        {
            return this._fr34;
        }
        set
        {
            double temp = _fr34;
            _fr34 = value;
        }
    }

    public double fr35
    {
        get
        {
            return this._fr35;
        }
        set
        {
            double temp = _fr35;
            _fr35 = value;
        }
    }

    public double fr36
    {
        get
        {
            return this._fr36;
        }
        set
        {
            double temp = _fr36;
            _fr36 = value;
        }
    }

    public double fr37
    {
        get
        {
            return this._fr37;
        }
        set
        {
            double temp = _fr37;
            _fr37 = value;
        }
    }

    public double fr38
    {
        get
        {
            return this._fr38;
        }
        set
        {
            double temp = _fr38;
            _fr38 = value;
        }
    }

    public double fr39
    {
        get
        {
            return this._fr39;
        }
        set
        {
            double temp = _fr39;
            _fr39 = value;
        }
    }
    public double fr40
    {
        get
        {
            return this._fr40;
        }
        set
        {
            double temp = _fr40;
            _fr40 = value;
        }
    }
    public double fr41
    {
        get
        {
            return this._fr41;
        }
        set
        {
            double temp = _fr41;
            _fr41 = value;
        }
    }

    public double fr42
    {
        get
        {
            return this._fr42;
        }
        set
        {
            double temp = _fr42;
            _fr42 = value;
        }
    }

    public double fr43
    {
        get
        {
            return this._fr43;
        }
        set
        {
            double temp = _fr43;
            _fr43 = value;
        }
    }

    public double fr44
    {
        get
        {
            return this._fr44;
        }
        set
        {
            double temp = _fr44;
            _fr44 = value;
        }
    }

    public double fr45
    {
        get
        {
            return this._fr45;
        }
        set
        {
            double temp = _fr45;
            _fr45 = value;
        }
    }

    public double fr46
    {
        get
        {
            return this._fr46;
        }
        set
        {
            double temp = _fr46;
            _fr46 = value;
        }
    }

    public double fr47
    {
        get
        {
            return this._fr47;
        }
        set
        {
            double temp = _fr47;
            _fr47 = value;
        }
    }

    public double fr48
    {
        get
        {
            return this._fr48;
        }
        set
        {
            double temp = _fr48;
            _fr48 = value;
        }
    }

    public double fr49
    {
        get
        {
            return this._fr49;
        }
        set
        {
            double temp = _fr49;
            _fr49 = value;
        }
    }

    public double fr50
    {
        get
        {
            return this._fr50;
        }
        set
        {
            double temp = _fr50;
            _fr50 = value;
        }
    }

    public void Read(System.IO.BinaryReader r)
    {
        _fr1 = r.ReadDouble();
        _fr2 = r.ReadDouble();
        _fr3 = r.ReadDouble();
        _fr4 = r.ReadDouble();
        _fr5 = r.ReadDouble();
        _fr6 = r.ReadDouble();
        _fr7 = r.ReadDouble();
        _fr8 = r.ReadDouble();
        _fr9 = r.ReadDouble();
        _fr10 = r.ReadDouble();
        _fr11 = r.ReadDouble();
        _fr12 = r.ReadDouble();
        _fr13 = r.ReadDouble();
        _fr14 = r.ReadDouble();
        _fr15 = r.ReadDouble();
        _fr16 = r.ReadDouble();
        _fr17 = r.ReadDouble();
        _fr18 = r.ReadDouble();
        _fr19 = r.ReadDouble();
        _fr20 = r.ReadDouble();
        _fr21 = r.ReadDouble();
        _fr22 = r.ReadDouble();
        _fr23 = r.ReadDouble();
        _fr24 = r.ReadDouble();
        _fr25 = r.ReadDouble();
        _fr26 = r.ReadDouble();
        _fr27 = r.ReadDouble();
        _fr28 = r.ReadDouble();
        _fr29 = r.ReadDouble();
        _fr30 = r.ReadDouble();
        _fr31 = r.ReadDouble();
        _fr32 = r.ReadDouble();
        _fr33 = r.ReadDouble();
        _fr34 = r.ReadDouble();
        _fr35 = r.ReadDouble();
        _fr36 = r.ReadDouble();
        _fr37 = r.ReadDouble();
        _fr38 = r.ReadDouble();
        _fr39 = r.ReadDouble();
        _fr40 = r.ReadDouble();
        _fr41 = r.ReadDouble();
        _fr42 = r.ReadDouble();
        _fr43 = r.ReadDouble();
        _fr44 = r.ReadDouble();
        _fr45 = r.ReadDouble();
        _fr46 = r.ReadDouble();
        _fr47 = r.ReadDouble();
        _fr48 = r.ReadDouble();
        _fr49 = r.ReadDouble();
        _fr50 = r.ReadDouble();

    }
    public void Write(System.IO.BinaryWriter w)
    {
        w.Write(_fr1);
        w.Write(_fr2);
        w.Write(_fr3);
        w.Write(_fr4);
        w.Write(_fr5);
        w.Write(_fr6);
        w.Write(_fr7);
        w.Write(_fr8);
        w.Write(_fr9);
        w.Write(_fr10);
        w.Write(_fr11);
        w.Write(_fr12);
        w.Write(_fr13);
        w.Write(_fr14);
        w.Write(_fr15);
        w.Write(_fr16);
        w.Write(_fr17);
        w.Write(_fr18);
        w.Write(_fr19);
        w.Write(_fr20);
        w.Write(_fr21);
        w.Write(_fr22);
        w.Write(_fr23);
        w.Write(_fr24);
        w.Write(_fr25);
        w.Write(_fr26);
        w.Write(_fr27);
        w.Write(_fr28);
        w.Write(_fr29);
        w.Write(_fr30);
        w.Write(_fr31);
        w.Write(_fr32);
        w.Write(_fr33);
        w.Write(_fr34);
        w.Write(_fr35);
        w.Write(_fr36);
        w.Write(_fr37);
        w.Write(_fr38);
        w.Write(_fr39);
        w.Write(_fr40);
        w.Write(_fr41);
        w.Write(_fr42);
        w.Write(_fr43);
        w.Write(_fr44);
        w.Write(_fr45);
        w.Write(_fr46);
        w.Write(_fr47);
        w.Write(_fr48);
        w.Write(_fr49);
        w.Write(_fr50);
    }
}
