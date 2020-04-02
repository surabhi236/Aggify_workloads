import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

/**
 * The rewritten version of MinCostSupplierOriginal. 
 * Manually done in accordance with the Aggify technique.
 * See Section 10 (Evaluation) for more details.
 */
public class MinCostSupplierRewritten {
    static String dbName = "tpch10g";
    static String connectionUrl = "<<>>";

    static String OUTER_QUERY = "SELECT P_PARTKEY FROM part WHERE P_PARTKEY <= ?";
    static String INNER_QUERY = "SELECT PS_SUPPLYCOST, S_NAME FROM partsupp, supplier WHERE PS_PARTKEY = ? AND PS_SUPPKEY = S_SUPPKEY";

    // INNER_QUERY rewritten using Aggify. 
    // MinCostSupp1() is the generated custom aggregate function. See MinCostSupp1.cs for the definition of the aggregate.
    static String AGGIFIED_QUERY = "select dbo.MinCostSupp1(Q.PS_SUPPLYCOST, Q.S_NAME) as suppName FROM ("+INNER_QUERY+") Q";

    // This is the rewritten query including Aggify followed by applying the technique of Emani et. al (SIGMOD 2016)
    static String AGGIFIED_FULL = "SELECT P.P_PARTKEY, dbo.MinCostSupp1(Q.PS_SUPPLYCOST, Q.S_NAME) as suppName " +
                                    " FROM part P OUTER APPLY (SELECT PS_SUPPLYCOST, S_NAME FROM partsupp, supplier WHERE PS_PARTKEY = P.P_PARTKEY AND PS_SUPPKEY = S_SUPPKEY) Q " +
                                    " WHERE P.P_PARTKEY <= ? " +
                                    " GROUP BY P_PARTKEY";


    public static void main(String[] args) throws SQLException, Exception {

        Connection conn = DriverManager.getConnection(connectionUrl);    

        // Loop from 200 rows to 2 million rows in multiples of 10.
        for(long i = 200; i <=2000000; i*=10){
            PreparedStatement ostmt = conn.prepareStatement(AGGIFIED_FULL);
            ostmt.setLong(1, i);
            long startTime1 = System.nanoTime();
            aggifiedFull(conn, ostmt);
            long endTime1 = System.nanoTime();
            long timeElapsed1 = endTime1 - startTime1;
            System.out.println("Aggified; " + i  + " rows; Time(ms): " + timeElapsed1 / 1000000);    
        }
        conn.close();         
    }

    public static void aggifiedFull(Connection conn, PreparedStatement ostmt) throws SQLException, Exception {
        ResultSet rs = ostmt.executeQuery();
        while(rs.next()){
            int partKey = rs.getInt("P_PARTKEY");
            String suppName = rs.getString("suppName");

            // Output can be written to a file, or discarded.
            // System.out.println("Part:" + partKey + "; Supplier: " + suppName);
        }
        
        rs.close();       
        ostmt.close();
    }
}