package eigochannel.model;

import eigochannel.dao.UserDAO;

public class LoginLogic {

	private String message = "";
	public boolean doLogin(String userId, String password) {
		//すでにログインIDが存在するかチェック
		UserDAO usrDao = new UserDAO();
		if(!usrDao.getUserFromDB(userId)) {
			//ログインしようとしているユーザーが存在しない
			message = "ログインユーザーが存在しません、ユーザーを登録してください。";
			return false;
		}

		return true;
	}

}
