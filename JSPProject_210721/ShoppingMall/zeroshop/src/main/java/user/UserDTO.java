package user;

public class UserDTO {
	//Data Transfer object = DVO 혹은 VO
	//데이터 베이스에 전송하거나 전송될 객체
	//alt + shift + s 누른뒤 r  // get set 만드는 단축키
	
	
	String loginID;
	String loginPW;
	String name;
	
	
	public String getLoginID() {
		return loginID;
	}
	public void setLoginID(String loginID) {
		this.loginID = loginID;
	}
	public String getLoginPW() {
		return loginPW;
	}
	public void setLoginPW(String loginPW) {
		this.loginPW = loginPW;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	
		
}


