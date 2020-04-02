import java.io.IOException;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Aggify_SR
{
    static String dbName = "java";
    static String connectionUrl = "<<>>";

	static int categoryId=2, page, nbOfItemsm=4, regionId, nbOfItems; 
	static String categoryName;
	static String aggifyQuery = "select dbo.Aggify_sr(name, id, end_date, max_bid, nbids, initPrice) from (SELECT name, items.id, end_date, max_bid, nbids, initPrice FROM items,users WHERE items.cat_id=? AND items.seller=users.id AND users.region=? ORDER BY items.end_date)Q";

	public static void main(String[] args) throws SQLException, Exception {
		Connection conn = DriverManager.getConnection(connectionUrl);
	    PreparedStatement ostmt = conn.prepareStatement(aggifyQuery);
	    ostmt.setInt(1, categoryId);
		ostmt.setInt(2, regionId);

	    long startTime1 = System.nanoTime();
	    itemList_aggify(ostmt, conn);
	    long endTime1 = System.nanoTime();
	    long timeElapsed1 = endTime1 - startTime1;
	    System.out.println("Aggify;  Time(ms): " + timeElapsed1 / 1000000);
	    conn.close();
	}

	/** List items in the given category for the given region */
	private static boolean itemList_aggify(PreparedStatement stmt, Connection conn) throws SQLException, Exception {
		String errorString = "";
		float maxBid;
		ResultSet rs = null;

		try{
            rs = stmt.executeQuery();
        }
        catch (Exception e){
            errorString += "Exception getting item list: " + e;
            System.out.println(e);
            conn.close();
            return false;
        }
		conn.close();
        return true;
	}
}