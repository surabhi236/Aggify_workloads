import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

/**
 * Cumulative ROI computation, original program.
 * See Section 10 (Evaluation) for more details.
 */
public class CumulativeROIOriginal {
    static int runs = 1;
    static final String connectionUrl = "<<>>";

    public static void main(String[] args) throws SQLException, Exception {
        if(args.length == 1){
            runs = Integer.parseInt(args[0]);
        }

        String ORIGINAL_QUERY = "SELECT TOP XX [ROI1], [ROI2], [ROI3], [ROI4], [ROI5], [ROI6], [ROI7], [ROI8], [ROI9], [ROI10], [ROI11], [ROI12], [ROI13], [ROI14], [ROI15], [ROI16], [ROI17], [ROI18], [ROI19], [ROI20], [ROI21], [ROI22], [ROI23], [ROI24], [ROI25], [ROI26], [ROI27], [ROI28], [ROI29], [ROI30], [ROI31], [ROI32], [ROI33], [ROI34], [ROI35], [ROI36], [ROI37], [ROI38], [ROI39], [ROI40], [ROI41], [ROI42], [ROI43], [ROI44], [ROI45], [ROI46], [ROI47], [ROI48], [ROI49], [ROI50]  from RoiTable WHERE investor_id < ? and st_date >= ?";
        
        Connection conn = DriverManager.getConnection(connectionUrl);    
        int investorId = 5;
        java.sql.Date fromDate = new java.sql.Date(new SimpleDateFormat("yyyy/MM/dd").parse("2011/01/01").getTime());

        for(int i = 0; i < runs; i ++){

            // Loop from 30 rows to 3 million rows in multiples of 10.
            for(int j = 30; j <= 3000000; j *= 10){

                // Insert TOP XX to vary number of rows
                String q = ORIGINAL_QUERY.replace("XX", String.valueOf(j));

                PreparedStatement ostmt = conn.prepareStatement(q);
                ostmt.setInt(1, investorId);
                ostmt.setDate(2, fromDate);    

                long startTime1 = System.nanoTime();
                double[] cumulativeReturn = computeCumulativeReturn(investorId, fromDate, conn, ostmt);
                long endTime1 = System.nanoTime();
                long timeElapsed1 = endTime1 - startTime1;
                
                ostmt.close();
                System.out.println(j);
                printResults("Original", cumulativeReturn, timeElapsed1);  
            }
        }           
        conn.close();
    }

    /**
     * This is a variant of the method given in the paper (Figure 2) as explained in Section 10. Instead of a single value for cumulative Return,
     * it has 50 values corresponding to different investment categories.
     */    
    public static double[] computeCumulativeReturn(int investorId, Date fromDate, Connection conn, PreparedStatement stmt) throws SQLException {  
        double[] cumulativeReturn = new double[50];
        for(int i = 1; i <= 50; i++){
            cumulativeReturn[i-1] = 1.0;
        }

        ResultSet rs = stmt.executeQuery();
        while(rs.next()){
            for(int i = 1; i <= 50; i++){
                double monthlyROI  = rs.getDouble("roi" + String.valueOf(i));    
                cumulativeReturn[i-1]=cumulativeReturn[i-1] * (monthlyROI+1);
            }
        }

        for(int i = 1; i <= 50; i++){
            cumulativeReturn[i-1] = cumulativeReturn[i-1] - 1;   
        }
        
        rs.close();                
        return cumulativeReturn;   
    }
    
    public static void printResults(String title, double cumulativeReturn[], long timeElapsed){
        System.out.println(title + "; Output: " + cumulativeReturn[0] + "; Time(ms): " + timeElapsed / 1000000);
    }
}