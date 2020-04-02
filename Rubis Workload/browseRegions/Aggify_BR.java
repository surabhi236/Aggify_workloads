import java.io.IOException;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Aggify_BR
{
    static String dbName = "java";
    static String connectionUrl = "<<>>";
	static String AggifyQuery = "Select dbo.Aggify_br(Q.name, Q.r_id) from (select name, r_id from regions)Q";

    public static void main(String[] args) throws SQLException, Exception {

	    Connection conn = DriverManager.getConnection(connectionUrl);

	    PreparedStatement ostmt = conn.prepareStatement(AggifyQuery); 
	    long startTime1 = System.nanoTime();
	    regionList_aggify(ostmt, conn);
	    long endTime1 = System.nanoTime();
	    long timeElapsed1 = endTime1 - startTime1;
	    System.out.println("Aggify;  Time(ms): " + timeElapsed1 / 1000000);
	    conn.close();
    }

	private static boolean regionList_aggify(PreparedStatement stmt, Connection conn) throws SQLException, Exception {
		String regionName;
		String toPrint = "";
		String errorString = "";
		String toPrintRegion = "";
		ResultSet rs = null;

        try
        {
            rs = stmt.executeQuery();
        }
        catch (Exception e)
        {
            errorString += "Failed to execute query for region list: " + e;
            conn.close();
            return false;
        }
        return true;
	}
}