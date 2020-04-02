import java.io.IOException;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Original_BC
{
	static String dbName = "java";
	static String connectionUrl = "<<>>";
	static String originalQuery = "Select name, u_id, r_id from categories where cat_id<70";

    public static void main(String[] args) throws SQLException, Exception {
	    Connection conn = DriverManager.getConnection(connectionUrl);

	    PreparedStatement ostmt = conn.prepareStatement(originalQuery);
	    long startTime1 = System.nanoTime();
	    categoryList_original(ostmt, conn);
	    long endTime1 = System.nanoTime();
	    long timeElapsed1 = endTime1 - startTime1;
	    System.out.println("Original;  Time(ms): " + timeElapsed1 / 1000000);
	    conn.close();
    }

    private static void closeConnection(PreparedStatement stmt, Connection conn)
    {
    	try {
    		conn.close();
    	}

    	catch(Exception e){
    	}
    }
	/** List all the categories in the database */
	private static boolean categoryList_original(PreparedStatement stmt, Connection conn) throws SQLException, Exception {
		String categoryName;
		int regionId;
		int userId;
		String toPrint = "";
		String errorString = "";
		int pri = 0;
		String printRegion = "";
		String printSellName = "";
		int psn = 0;
		String printCategory = "";
		int pc = 0;
		int categoryId;
		ResultSet rs = null;
		StringBuilder sb = new StringBuilder();
		try
		{
			rs = stmt.executeQuery();
		}
		catch (Exception e)
		{
			errorString += "Failed to execute query for categories list: " + e;
			System.out.println("failed");
			conn.close();
			return false;
		}
		int i = 1;
		int count= 0;
		while(rs.next()){
			count+=1;
			if(i==1)
			{
				sb.append("currently available categories");
				i+=1;
			}
			categoryName = rs.getString("name");
			regionId = rs.getInt("r_id");
			userId = rs.getInt("u_id");
			if (regionId != -1)
			{
				sb.append(categoryName);
			}
			else
			{
				if (userId != -1)
				{
					sb.append(categoryName);
				}
				else
				{
					//printCategory += categoryName;
				}
			}
		}
		System.out.println(count);
		return true;
	}
}