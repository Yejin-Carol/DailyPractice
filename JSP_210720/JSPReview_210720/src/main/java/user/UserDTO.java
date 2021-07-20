package user;

public class UserDTO {
	//Data Transfer object = DVO 혹은 VO
	//stydent 같은 객체들
	//데이터 베이스에 전송하거나 전송될 객체
	//alt + shift + s 누른뒤 r  // get set 만드는 단축키
	
	
	String userID;
	String userPassword;
	
	public String getUserID() {
		return userID;
	}
	public void setUserID(String userID) {
		this.userID = userID;
	}
	public String getUserPassword() {
		return userPassword;
	}
	public void setUserPassword(String userPassword) {
		this.userPassword = userPassword;
	}
	
	
}
