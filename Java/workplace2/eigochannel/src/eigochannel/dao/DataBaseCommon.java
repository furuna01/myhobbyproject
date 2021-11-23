package eigochannel.dao;

import java.sql.Connection;
import java.sql.DriverManager;

public class DataBaseCommon {

	private String dataBaseName = "eigochannel";
	private String userName = "yonezawa";
	private String password = "suminftyj=1";
	private Connection connection = null;
	public Connection getConnection() {
		return connection;
	}
	public void setConnection(Connection connection) {
		this.connection = connection;
	}
	public boolean connectDB() {

		try {
			 connection = DriverManager.getConnection(
				      "jdbc:mysql://localhost/" + dataBaseName + "?useSSL=false",
				      userName,
				      password
				    );
			return true;
		}catch(Exception e) {
			return false;
		}finally {

		}
	}
	public boolean closeDB() {
		try {
			connection.close();
			return true;
		}catch (Exception e) {
			return false;
		}finally {

		}
	}

}
