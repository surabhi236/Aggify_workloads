import java.io.IOException;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Original_SP
{
	static String dbName = "java";
    static String connectionUrl = "<<>>";
	static String originalQuery = "SELECT id, qty, max_bid FROM bids WHERE item_id<10000 ORDER BY id DESC";
	static long qty = 50000;

	public static void main(String[] args) throws SQLException, Exception {
		Connection conn = DriverManager.getConnection(connectionUrl);
	    PreparedStatement ostmt = conn.prepareStatement(originalQuery);
	    long startTime1 = System.nanoTime();
	    printItemDescription_original(qty, ostmt, conn);
	    long endTime1 = System.nanoTime();
	    long timeElapsed1 = endTime1 - startTime1;
	    System.out.println("Original;  Time(ms): " + timeElapsed1 / 1000000);
	    conn.close();
	}

	static void printItemDescription_original(Long quantity ,PreparedStatement stmt, Connection conn)
	{
		String firstBid;
		long maxBid=0;
		try
		{
			if (quantity > 1)
			{
				try
				{
					ResultSet rs = stmt.executeQuery();
					int numberOfItems = 0;
					int qty;
					while(rs.next())
					{
						qty = rs.getInt("qty");
						numberOfItems = numberOfItems + qty;
						if (numberOfItems >= quantity)
						{
							maxBid = rs.getLong("max_bid");
						}
					}
				}
				catch (Exception e)
				{
					System.out.println(e);
					conn.close();
					return;
				}
			}
			firstBid = Float.toString(maxBid);
		}
		catch (Exception e)
		{
			System.out.println("Unable to print Item description (exception: " + e + ")");
		}
	}
}