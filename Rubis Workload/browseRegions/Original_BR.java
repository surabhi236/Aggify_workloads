import java.io.IOException;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Original_BR
{
	static String dbName = "java";
	static String connectionUrl = "<<>>";
	static String originalQuery = "Select name, r_id from regions";

    public static void main(String[] args) throws SQLException, Exception {

	    Connection conn = DriverManager.getConnection(connectionUrl);

	    PreparedStatement ostmt = conn.prepareStatement(originalQuery);
	    long startTime1 = System.nanoTime();
	    regionList_original(ostmt, conn);
	    long endTime1 = System.nanoTime();
	    long timeElapsed1 = endTime1 - startTime1;
	    System.out.println("Original;  Time(ms): " + timeElapsed1 / 1000000);
	    conn.close();
    }

	private static void regionList_original(PreparedStatement stmt, Connection conn) throws SQLException, Exception {
		String regionName;
		String toPrint = "";
		int pr = 0;
		String errorString = "";
		String toPrintRegion = "";
		ResultSet rs = null;
		StringBuilder sb = new StringBuilder();

		try
		{
			rs = stmt.executeQuery();
			System.out.println("ok");
		}
		catch (Exception e)
		{
			System.out.println(e);
			errorString += "Failed to execute Query for the list of regions: " + e;
			conn.close();
			return;
		}
		try
		{
			int i = 1;
			while(rs.next())
			{
				if(i==1){
					toPrint += "Currently available regions";
					i+=1;
				}
				regionName = rs.getString("name");
				sb.append(regionName);
			}
		}
		catch (Exception e)
		{
			errorString += "Exception getting region list: " + e;
			System.out.println(e);
		}
		conn.close();
	}
}