package eigochannel.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import eigochannel.model.User;

public class UserDAO {

	public boolean getUserFromDB(User user) {
		try {
			DataBaseCommon common = new DataBaseCommon();
			if(!common.connectDB()) {
				return false;
			}
			Connection connection = common.getConnection();
			 // SQL文の実行
		    PreparedStatement pstmt = connection.prepareStatement("select * from users");
		    ResultSet rs = pstmt.executeQuery();

		    while (rs.next()) {
		     if(user.getUserID().equals(rs.getString("userid"))) {
		    	 //ユーザーIDが見つかった
		    	 return true;
		     }
		    }
		    //ユーザーIDが存在しない
			return false;
		}catch (Exception e) {
			return false;
		}finally {

		}
	}

}
