import java.io.IOException;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Original_SR
{
    static String dbName = "java";
    static String connectionUrl = "<<>>";

	static int categoryId =2 , page, nbOfItems, regionId = 4;
	static String categoryName;
	static String originalQuery = "SELECT name, items.id, end_date, max_bid, nbids, initPrice FROM items,users WHERE items.cat_id=? AND items.seller=users.id AND users.region=? ORDER BY items.end_date";

	public static void main(String[] args) throws SQLException, Exception {
		Connection conn = DriverManager.getConnection(connectionUrl);
	    PreparedStatement ostmt = conn.prepareStatement(originalQuery);
	    ostmt.setInt(1, categoryId);
		ostmt.setInt(2, regionId);

	    long startTime1 = System.nanoTime();
	    itemList_original(ostmt, conn);
	    long endTime1 = System.nanoTime();
	    long timeElapsed1 = endTime1 - startTime1;
	    System.out.println("Original;  Time(ms): " + timeElapsed1 / 1000000);
	    conn.close();
	}

	private static boolean itemList_original(PreparedStatement stmt, Connection conn) throws SQLException, Exception {
		String itemName, endDate, errorString  = "", toPrint = "";
		long itemId, nbOfBids = 0;
		long maxBid;
		int tp = 0;
		ResultSet rs = null;
		StringBuilder sb = new StringBuilder();

		try{
            rs = stmt.executeQuery();
        }
        catch (Exception e){
            errorString += "Exception getting item list: " + e;
            System.out.println(e);
            conn.close();
            return false;
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
				sb.append(endDate);
			}
		}
		catch (Exception e)
		{
			errorString += "Exception getting item list: " + e;
			System.out.println(e);
			return false;
		}
		conn.close();
		return true;
	}
}