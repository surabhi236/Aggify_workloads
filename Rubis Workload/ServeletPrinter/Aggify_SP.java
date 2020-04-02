import java.io.IOException;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Aggify_SP
{
	static String dbName = "java";
    static String connectionUrl = "<<>>";
	static String aggifyQuery = "select dbo.Aggify_sp(qty, max_bid) from (SELECT id,qty,max_bid FROM bids WHERE item_id<10000 ORDER BY id) Q";
	static long qty= 50000;

	public static void main(String[] args) throws SQLException, Exception {
		Connection conn = DriverManager.getConnection(connectionUrl);
	    PreparedStatement ostmt = conn.prepareStatement(aggifyQuery);
	    long startTime1 = System.nanoTime();
	    printItemDescription_aggify(qty, ostmt, conn);
	    long endTime1 = System.nanoTime();
	    long timeElapsed1 = endTime1 - startTime1;
	    System.out.println("Original;  Time(ms): " + timeElapsed1 / 1000000);
	    conn.close();
	}

	static void printItemDescription_aggify(Long quantity ,PreparedStatement stmt, Connection conn) throws SQLException, Exception 
	{
		String firstBid;
		try
		{
			if (quantity > 1)
			{
				try
				{
					ResultSet rs = stmt.executeQuery();
				}
				catch (Exception e)
				{
					System.out.println(e);
					conn.close();
					return;
				}
			}
		}
		catch (Exception e)
		{
			System.out.println("Unable to print Item description (exception: " + e + ")");
		}
	}
}