import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

/**
 * The Java implementation of TPC-H Q2 functionality. 
 * See Section 10 (Evaluation) for more details.
 */
public class MinCostSupplierOriginal {
    static String dbName = "tpch10g";
    static String connectionUrl = "<<>>";

    static String OUTER_QUERY = "SELECT P_PARTKEY FROM part WHERE P_PARTKEY <= ?";
    static String INNER_QUERY = "SELECT PS_SUPPLYCOST, S_NAME FROM partsupp, supplier WHERE PS_PARTKEY = ? AND PS_SUPPKEY = S_SUPPKEY";
    public static void main(String[] args) throws SQLException, Exception {
        Connection conn = DriverManager.getConnection(connectionUrl);    

        for(long i = 200; i <=2000000; i*=10){
            PreparedStatement ostmt = conn.prepareStatement(OUTER_QUERY);
            ostmt.setLong(1, i);
            long startTime1 = System.nanoTime();
            original(conn, ostmt);
            long endTime1 = System.nanoTime();
            long timeElapsed1 = endTime1 - startTime1;
            System.out.println("Original:"  + i  + " rows; Time(ms): " + timeElapsed1 / 1000000);
        }
        conn.close();         

    }

    public static void original(Connection conn, PreparedStatement ostmt) throws SQLException, Exception {
        ResultSet rs = ostmt.executeQuery();
        while(rs.next()){
            double minCost = 100000;
            String suppName = ""; 
            int partKey  = rs.getInt("P_PARTKEY");
 
            PreparedStatement istmt = conn.prepareStatement(INNER_QUERY);
            istmt.setInt(1, partKey);

            ResultSet irs = istmt.executeQuery();
            while(irs.next()){
                double pCost =  irs.getDouble("PS_SUPPLYCOST");
                String sName = irs.getString("S_NAME");
                if(pCost < minCost){
                    minCost = pCost;
                    suppName = sName;
                }
            }
            irs.close();
            istmt.close();
            // Output can be written to a file, or discarded.
            // System.out.println("Part:" + partKey + "; Supplier: " + suppName);
        }
        
        rs.close();       
        ostmt.close();
    }
}