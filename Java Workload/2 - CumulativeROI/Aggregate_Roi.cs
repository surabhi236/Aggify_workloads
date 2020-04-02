[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SqlUserDefinedAggregate(
    Format.UserDefined,
    IsInvariantToDuplicates = false,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    IsNullIfEmpty = true,
    MaxByteSize = -1)]

public struct RoiExample50 : IBinarySerialize
{
    double[] cumulativeRoi;
    bool isInitialised;

    public void Init()
    {
        cumulativeRoi = new double[50];
	isInitialised =  False;
    }

    [SqlFunction(DataAccess = DataAccessKind.Read)]
    public void Accumulate(double fr1, double fr2, double fr3, double fr4, double fr5, double fr6, double fr7, double fr8, 
                double fr9, double fr10, double fr11, double fr12, double fr13, double fr14, double fr15, double fr16, double fr17, 
                double fr18, double fr19, double fr20, double fr21, double fr22, double fr23, double fr24, double fr25, double fr26, 
                double fr27, double fr28, double fr29, double fr30, double fr31, double fr32, double fr33, double fr34, double fr35, 
                double fr36, double fr37, double fr38, double fr39, double fr40, double fr41, double fr42, double fr43, double fr44, 
                double fr45, double fr46, double fr47, double fr48, double fr49, double fr50, 
		double pCr1, double pCr2, double pCr3, double pCr4, double pCr5, double pCr6, double pCr7, double pCr8, 
		double pCr9, double pCr10, double pCr11, double pCr12, double pCr13, double pCr14, double pCr15, double pCr16, double pCr17, 
		double pCr18, double pCr19, double pCr20, double pCr21, double pCr22, double pCr23, double pCr24, double pCr25, double pCr26, 
		double pCr27, double pCr28, double pCr29, double pCr30, double pCr31, double pCr32, double pCr33, double pCr34, double pCr35, 
		double pCr36, double pCr37, double pCr38, double pCr39, double pCr40, double pCr41, double pCr42, double pCr43, double pCr44, 
		double pCr45, double pCr46, double pCr47, double pCr48, double pCr49, double pCr50)
    {
	if(!isInitialised)
	{
		cumulativeRoi[0] = pCr0;
		cumulativeRoi[1] = pCr1;
		cumulativeRoi[2] = pCr2;
		cumulativeRoi[3] = pCr3;
		cumulativeRoi[4] = pCr4;
		cumulativeRoi[5] = pCr5;
		cumulativeRoi[6] = pCr6;
		cumulativeRoi[7] = pCr7;
		cumulativeRoi[8] = pCr8;
		cumulativeRoi[9] = pCr9;
		cumulativeRoi[10] = pCr10;
		cumulativeRoi[11] = pCr11;
		cumulativeRoi[12] = pCr12;
		cumulativeRoi[13] = pCr13;
		cumulativeRoi[14] = pCr14;
		cumulativeRoi[15] = pCr15;
		cumulativeRoi[16] = pCr16;
		cumulativeRoi[17] = pCr17;
		cumulativeRoi[18] = pCr18;
		cumulativeRoi[19] = pCr19;
		cumulativeRoi[20] = pCr20;
		cumulativeRoi[21] = pCr21;
		cumulativeRoi[22] = pCr22;
		cumulativeRoi[23] = pCr23;
		cumulativeRoi[24] = pCr24;
		cumulativeRoi[25] = pCr25;
		cumulativeRoi[26] = pCr26;
		cumulativeRoi[27] = pCr27;
		cumulativeRoi[28] = pCr28;
		cumulativeRoi[29] = pCr29;
		cumulativeRoi[30] = pCr30;
		cumulativeRoi[31] = pCr31;
		cumulativeRoi[32] = pCr32;
		cumulativeRoi[33] = pCr33;
		cumulativeRoi[34] = pCr34;
		cumulativeRoi[35] = pCr35;
		cumulativeRoi[36] = pCr36;
		cumulativeRoi[37] = pCr37;
		cumulativeRoi[38] = pCr38;
		cumulativeRoi[39] = pCr39;
		cumulativeRoi[40] = pCr40;
		cumulativeRoi[41] = pCr41;
		cumulativeRoi[42] = pCr42;
		cumulativeRoi[43] = pCr43;
		cumulativeRoi[44] = pCr44;
		cumulativeRoi[45] = pCr45;
		cumulativeRoi[46] = pCr46;
		cumulativeRoi[47] = pCr47;
		cumulativeRoi[48] = pCr48;
		cumulativeRoi[49] = pCr49;
		isInitialised = True;
	}
        cumulativeRoi[0] *= fr1;  cumulativeRoi[1] *= fr2; cumulativeRoi[2] *= fr3; cumulativeRoi[3] *= fr4; cumulativeRoi[4] *= fr5; cumulativeRoi[5] *= fr6; cumulativeRoi[6] *= fr7; cumulativeRoi[7] *= fr8; cumulativeRoi[8] *= fr9; cumulativeRoi[9] *= fr10;
        cumulativeRoi[10] *= fr11;cumulativeRoi[11] *= fr12; cumulativeRoi[12] *= fr13; cumulativeRoi[13] *= fr14; cumulativeRoi[14] *= fr15; cumulativeRoi[15] *= fr16; cumulativeRoi[16] *= fr17; cumulativeRoi[17] *= fr18; cumulativeRoi[18] *= fr19; cumulativeRoi[19] *= fr20;
        cumulativeRoi[20] *= fr21;cumulativeRoi[21] *= fr22; cumulativeRoi[22] *= fr23; cumulativeRoi[23] *= fr24; cumulativeRoi[24] *= fr25; cumulativeRoi[25] *= fr26; cumulativeRoi[26] *= fr27; cumulativeRoi[27] *= fr28; cumulativeRoi[28] *= fr29; cumulativeRoi[29] *= fr30;
        cumulativeRoi[30] *= fr31; cumulativeRoi[31] *= fr32; cumulativeRoi[32] *= fr33; cumulativeRoi[33] *= fr34; cumulativeRoi[34] *= fr35; cumulativeRoi[35] *= fr36; cumulativeRoi[36] *= fr37; cumulativeRoi[37] *= fr38; cumulativeRoi[38] *= fr39; cumulativeRoi[39] *= fr40;
        cumulativeRoi[40] *= fr41; cumulativeRoi[41] *=fr42; cumulativeRoi[42] *= fr43; cumulativeRoi[43] *= fr44; cumulativeRoi[44] *= fr45; cumulativeRoi[45] *= fr46; cumulativeRoi[46] *= fr47; cumulativeRoi[47] *= fr48; cumulativeRoi[48] *= fr49; cumulativeRoi[49] *= fr50;
    }

    public void Merge(RoiExample50 other)
    {

    }

    public FiftyDouble Terminate()
    {
        FiftyDouble ufd = new FiftyDouble();
        ufd.fr1 = cumulativeRoi[0];
        ufd.fr2 = cumulativeRoi[1];
        ufd.fr3 = cumulativeRoi[2];
        ufd.fr4 = cumulativeRoi[3];
        ufd.fr5 = cumulativeRoi[4];
        ufd.fr6 = cumulativeRoi[5];
        ufd.fr7 = cumulativeRoi[6];
        ufd.fr8 = cumulativeRoi[7];
        ufd.fr9 = cumulativeRoi[8];
        ufd.fr10 = cumulativeRoi[9];
        ufd.fr11 = cumulativeRoi[10];
        ufd.fr12 = cumulativeRoi[11];
        ufd.fr13 = cumulativeRoi[12];
        ufd.fr14 = cumulativeRoi[13];
        ufd.fr15 = cumulativeRoi[14];
        ufd.fr16 = cumulativeRoi[15];
        ufd.fr17 = cumulativeRoi[16];
        ufd.fr18 = cumulativeRoi[17];
        ufd.fr19 = cumulativeRoi[18];
        ufd.fr20 = cumulativeRoi[19];
        ufd.fr21 = cumulativeRoi[20];
        ufd.fr22 = cumulativeRoi[21];
        ufd.fr23 = cumulativeRoi[22];
        ufd.fr24 = cumulativeRoi[23];
        ufd.fr25 = cumulativeRoi[24];
        ufd.fr26 = cumulativeRoi[25];
        ufd.fr27 = cumulativeRoi[26];
        ufd.fr28 = cumulativeRoi[27];
        ufd.fr29 = cumulativeRoi[28];
        ufd.fr30 = cumulativeRoi[29];
        ufd.fr31 = cumulativeRoi[30];
        ufd.fr32 = cumulativeRoi[31];
        ufd.fr33 = cumulativeRoi[32];
        ufd.fr34 = cumulativeRoi[33];
        ufd.fr35 = cumulativeRoi[34];
        ufd.fr36 = cumulativeRoi[35];
        ufd.fr37 = cumulativeRoi[36];
        ufd.fr38 = cumulativeRoi[37];
        ufd.fr39 = cumulativeRoi[38];
        ufd.fr40 = cumulativeRoi[39];
        ufd.fr41 = cumulativeRoi[40];
        ufd.fr42 = cumulativeRoi[41];
        ufd.fr43 = cumulativeRoi[42];
        ufd.fr44 = cumulativeRoi[43];
        ufd.fr45 = cumulativeRoi[44];
        ufd.fr46 = cumulativeRoi[45];
        ufd.fr47 = cumulativeRoi[46];
        ufd.fr48 = cumulativeRoi[47];
        ufd.fr49 = cumulativeRoi[48];
        ufd.fr50 = cumulativeRoi[49];
        return ufd;
    }

    public void Read(BinaryReader r)
    {
        cumulativeRoi = new double[50];
        for (int i=0;i<50;i++)
            cumulativeRoi[i] = r.ReadDouble();
    }

    public void Write(BinaryWriter w)
    {
        for (int i = 0; i < 50; i++)
            w.Write(cumulativeRoi[i]);
    }
}
