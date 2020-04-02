import java.io.IOException;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Aggify_SC
{
    static String dbName = "java";
    static String connectionUrl = ""<<>>;
	static int categoryId = 2, page = 500, nbOfItems = 500;
	static String categoryName;
	static String aggifyQuery = "select dbo.Aggify_sc(name, id, end_date, max_bid, nbids, initPrice) from (SELECT name, id, end_date, max_bid, nbids, initPrice FROM items WHERE items.cat_id=?)Q";

	public static void main(String[] args) throws SQLException, Exception {
		Connection conn = DriverManager.getConnection(connectionUrl);
	    PreparedStatement ostmt = conn.prepareStatement(aggifyQuery);
	    ostmt.setInt(1, categoryId);
	    long startTime1 = System.nanoTime();
	    itemList_aggify(ostmt, conn);
	    long endTime1 = System.nanoTime();
	    long timeElapsed1 = endTime1 - startTime1;
	    System.out.println("Aggify: ;  Time(ms): " + timeElapsed1 / 1000000);
	    conn.close();	
	}

	private static boolean itemList_aggify(PreparedStatement stmt, Connection conn) throws SQLException, Exception {
		String errorString = "";
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