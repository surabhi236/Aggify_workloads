import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class CumulativeROIRewritten {
    static int runs = 1;
    static final String connectionUrl = "<<>>";

    public static void main(String[] args) throws SQLException, Exception {
        if(args.length == 1){
            runs = Integer.parseInt(args[0]);
        }

        String ORIGINAL_QUERY = "SELECT TOP XX [ROI1], [ROI2], [ROI3], [ROI4], [ROI5], [ROI6], [ROI7], [ROI8], [ROI9], [ROI10], [ROI11], [ROI12], [ROI13], [ROI14], [ROI15], [ROI16], [ROI17], [ROI18], [ROI19], [ROI20], [ROI21], [ROI22], [ROI23], [ROI24], [ROI25], [ROI26], [ROI27], [ROI28], [ROI29], [ROI30], [ROI31], [ROI32], [ROI33], [ROI34], [ROI35], [ROI36], [ROI37], [ROI38], [ROI39], [ROI40], [ROI41], [ROI42], [ROI43], [ROI44], [ROI45], [ROI46], [ROI47], [ROI48], [ROI49], [ROI50]  from RoiTable WHERE investor_id < ? and st_date >= ?";

        // Query rewritten using Aggify. Composes the ORIGINAL_QUERY as is.
        // RoiExample50() is the constructed aggregate function. See RoiExample50.cs for the implementation of the custom aggregate.
        String AGGIFY_QUERY = "SELECT croi.fr1 as fr1, croi.fr2 as fr2, croi.fr3 as fr3, croi.fr4 as fr4, croi.fr5 as fr5, croi.fr6 as fr6, croi.fr7 as fr7, croi.fr8 as fr8, croi.fr9 as fr9, croi.fr10 as fr10, croi.fr11 as fr11, croi.fr12 as fr12, croi.fr13 as fr13, croi.fr14 as fr14, croi.fr15 as fr15, croi.fr16 as fr16, croi.fr17 as fr17, croi.fr18 as fr18, croi.fr19 as fr19, croi.fr20 as fr20, croi.fr21 as fr21, croi.fr22 as fr22, croi.fr23 as fr23, croi.fr24 as fr24, croi.fr25 as fr25, croi.fr26 as fr26, croi.fr27 as fr27, croi.fr28 as fr28, croi.fr29 as fr29, croi.fr30 as fr30, croi.fr31 as fr31, croi.fr32 as fr32, croi.fr33 as fr33, croi.fr34 as fr34, croi.fr35 as fr35, croi.fr36 as fr36, croi.fr37 as fr37, croi.fr38 as fr38, croi.fr39 as fr39, croi.fr40 as fr40, croi.fr41 as fr41, croi.fr42 as fr42, croi.fr43 as fr43, croi.fr44 as fr44, croi.fr45 as fr45, croi.fr46 as fr46, croi.fr47 as fr47, croi.fr48 as fr48, croi.fr49 as fr49, croi.fr50 as fr50  FROM (SELECT dbo.RoiExample50(Q.[ROI1], Q.[ROI2], Q.[ROI3], Q.[ROI4], Q.[ROI5], Q.[ROI6], Q.[ROI7], Q.[ROI8], Q.[ROI9], Q.[ROI10], Q.[ROI11], Q.[ROI12], Q.[ROI13], Q.[ROI14], Q.[ROI15], Q.[ROI16], Q.[ROI17], Q.[ROI18], Q.[ROI19], Q.[ROI20], Q.[ROI21], Q.[ROI22], Q.[ROI23], Q.[ROI24], Q.[ROI25], Q.[ROI26], Q.[ROI27], Q.[ROI28], Q.[ROI29], Q.[ROI30], Q.[ROI31], Q.[ROI32], Q.[ROI33], Q.[ROI34], Q.[ROI35], Q.[ROI36], Q.[ROI37], Q.[ROI38], Q.[ROI39], Q.[ROI40], Q.[ROI41], Q.[ROI42], Q.[ROI43], Q.[ROI44], Q.[ROI45], Q.[ROI46], Q.[ROI47], Q.[ROI48], Q.[ROI49], Q.[ROI50]) AS croi FROM ( " + ORIGINAL_QUERY + " ) Q) A";

        Connection conn = DriverManager.getConnection(connectionUrl);    
        int investorId = 5;
        java.sql.Date fromDate = new java.sql.Date(new SimpleDateFormat("yyyy/MM/dd").parse("2011/01/01").getTime());
        
        for(int i = 0; i < runs; i ++){   

            // Loop from 30 rows to 3 million rows in multiples of 10.        
            for(int j = 30; j <= 3000000; j *= 10){

                // Insert TOP XX to vary number of rows
                String q = AGGIFY_QUERY.replace("XX", String.valueOf(j));
                PreparedStatement astmt = conn.prepareStatement(q);

                // astmt.setDouble(1,1.0);
                astmt.setInt(1,investorId);
                astmt.setDate(2,fromDate);
                
                long startTime2 = System.nanoTime();
                double cumulativeReturn2[] = computeCumulativeReturn(investorId, fromDate, conn, astmt);
                long endTime2 = System.nanoTime();
                long timeElapsed2 = endTime2 - startTime2;
                
                astmt.close();
                System.out.println(j);
                printResults("Aggified", cumulativeReturn2[0], timeElapsed2);       
                }
        }   

        conn.close();
}

    public static double[] computeCumulativeReturn(int investorId, Date fromDate, Connection conn, PreparedStatement stmt) throws SQLException {  
        double[] cumulativeReturn = new double[50];

        ResultSet rs=stmt.executeQuery();
        rs.next();
        for(int i = 1; i <= 50; i++){
            cumulativeReturn[i-1]  = rs.getDouble("fr" + String.valueOf(i)) - 1;    
        }

        rs.close();stmt.close();
        return cumulativeReturn;
    }

    
    public static void printResults(String title, double cumulativeReturn, long timeElapsed){
        System.out.println(title + "; Output: " + cumulativeReturn + "; Time(ms): " + timeElapsed / 1000000);
    }
}