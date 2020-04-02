import java.io.IOException;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Aggify_BC
{
    static String dbName = "java";
    static String connectionUrl = "<<>>";
    static String aggifiedQuery = "Select dbo.Aggify_bc(Q.name, Q.u_id, Q.r_id) as p from (select name, u_id, r_id from categories where cat_id<70) Q";

    public static void main(String[] argpars) throws SQLException, Exception {

        Connection conn = DriverManager.getConnection(connectionUrl);

        PreparedStatement ostmt = conn.prepareStatement(aggifiedQuery);
        long startTime1 = System.nanoTime();
        categoryList_aggified(ostmt, conn);
        long endTime1 = System.nanoTime();
        long timeElapsed1 = endTime1 - startTime1;
        System.out.println("Aggify;  Time(ms): " + timeElapsed1 / 1000000);
        conn.close();
    }

    private static boolean categoryList_aggified(PreparedStatement stmt, Connection conn) throws SQLException, Exception {
        ResultSet rs = null;
        String errorString = "";

        try
        {
            rs = stmt.executeQuery();
        }
        catch (Exception e)
        {
            errorString += "Failed to execute query for categories list: " + e;
            conn.close();
            System.out.println(e);
            return false;
        }
        return true;
    }
}