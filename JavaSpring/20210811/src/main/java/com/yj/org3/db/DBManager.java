package com.yj.org3.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

import org.springframework.stereotype.Component;

@Component
public class DBManager {

	public void inserttest(String para1, String para2) {
		Connection conn = null;
		PreparedStatement pstmt = null;
		
		
		try {
			// 이 클래스 파일 없으면 catch 구문으로 진행
			// 파일 있으면 다음 줄 진행
			//ip는 전화번호, 포트는 내선번호 //포트번호: 윈도우에서 0~65000?? 톰캣 올릴때 8282?사용
			Class.forName("com.mysql.cj.jdbc.Driver");
			conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/carol","root","1234");	
			pstmt = conn.prepareStatement("insert into test values (?,?)");
			pstmt.setString(1, para1);
			pstmt.setString(2, para2);
			pstmt.execute(); //실행		
		}catch (Exception e) {
			e.printStackTrace();
		}
		finally {
			try {
				if(conn != null)
				   conn.close(); 
				if(pstmt!=null)
				   pstmt.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
		
	}
		
		public void deletetest(String para1) {
			Connection conn = null;
			PreparedStatement pstmt = null;
			
			
			try {
				Class.forName("com.mysql.cj.jdbc.Driver");
				conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/carol","root","1234");	
				pstmt = conn.prepareStatement("delete from test where para1=?");
				pstmt.setString(1, para1);
				pstmt.execute(); //실행		
			} catch (Exception e) {
				e.printStackTrace();
			}
			finally {
				try {
					if(conn != null)
					   conn.close(); 
					if(pstmt!=null)
					   pstmt.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
		}	
		
		public void updatetest(String para1) {
			Connection conn = null;
			PreparedStatement pstmt = null;
			
			
			try {
				Class.forName("com.mysql.cj.jdbc.Driver");
				conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/carol","root","1234");	
				pstmt = conn.prepareStatement("update test set para2='777' where para1=?");
				pstmt.setString(1, para1);
				//pstmt.setString(2, para2);
				pstmt.execute(); //실행		
			} catch (Exception e) {
				e.printStackTrace();
			}
			finally {
				try {
					if(conn != null)
					   conn.close(); 
					if(pstmt!=null)
					   pstmt.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
		}	
							
	}

