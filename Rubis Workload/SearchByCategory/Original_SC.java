import java.io.IOException;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Original_SC
{
    static String dbName = "java";
    static String connectionUrl = "<<>>";
	static long categoryId = 2, page = 500, nbOfItems = 500;
	static String categoryName;
	static String originalQuery = "SELECT name, id, end_date, max_bid, nbids, initPrice FROM items where cat_id = ?";

	public static void main(String[] args) throws SQLException, Exception {
		Connection conn = DriverManager.getConnection(connectionUrl);
	    PreparedStatement ostmt = conn.prepareStatement(originalQuery);
	    ostmt.setLong(1, categoryId);
	    long startTime1 = System.nanoTime();
	    itemList_original(ostmt, conn);
	    long endTime1 = System.nanoTime();
	    long timeElapsed1 = endTime1 - startTime1;
	    System.out.println("Original;  Time(ms): " + timeElapsed1 / 1000000);
	    conn.close();	
	}

	private static void itemList_original(PreparedStatement stmt, Connection conn) throws SQLException, Exception {
		String itemName, endDate;
		long itemId;
		long maxBid;
		int tp = 0;
		String errorString = "";
		String toPrint = "";
		long nbOfBids = 0;
		ResultSet rs = null;
		StringBuilder sb = new StringBuilder();

		try
		{
			rs = stmt.executeQuery();
		}
		catch (Exception e)
		{
			System.out.println(e);
			errorString += "Failed to execute Query for the list of items: " + e;
			conn.close();
			return;
		}

		try
		{
			while(rs.next())
			{
				itemName = rs.getString("name");
				itemId = rs.getLong("id");
				endDate = rs.getString("end_date");
				maxBid = rs.getLong("max_bid");
				nbOfBids = rs.getLong("nbids");
				long initialPrice = rs.getLong("initPrice"); 
				if (maxBid < initialPrice)
				{
					maxBid = initialPrice;
				}
				sb.append(itemName);
				sb.append(itemId);
				sb.append(endDate);
			}
		}
		catch (Exception e)
		{
			errorString += "Exception getting item list: " + e;
			System.out.println(e);
		}
		conn.close();
	}
}