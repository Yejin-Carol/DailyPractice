package com.carol.yj.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;

import org.apache.ibatis.session.SqlSession;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.datasource.DriverManagerDataSource;
import org.springframework.stereotype.Component;

import com.carol.yj.dto.TestDto;

@Component
public class TestDao {

	@Autowired
	DriverManagerDataSource datasource;

	@Autowired
	SqlSession sqlSession;
	
	public void doInsert() {
		sqlSession.insert("test.insert");
	}
	
	public ArrayList<TestDto> doList() {
		ArrayList<TestDto> list = new ArrayList<TestDto>();
		System.out.println("dolist");

		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		String url = "jdbc:mysql://localhost:3306/test";

		try { // jar 파일
			Class.forName("com.mysql.cj.jdbc.Driver");
			// mysql db 연결 id root pw 1234
			conn = DriverManager.getConnection(url, "root", "1234");
			// select문 작성
			pstmt = conn.prepareStatement("select * from test");
			// 실행 반환되는 값 rs 담는거
			rs = pstmt.executeQuery();
			// rs..next
			while (rs.next()) {
				TestDto dto = new TestDto();
				dto.setPara1(rs.getString(1));
				dto.setPara2(rs.getString(2));
				list.add(dto);
//				System.out.println("rs.getString(1) = "+rs.getString(1) );
//				System.out.println("rs.getString(2) = "+rs.getString(2)); 
//				list.add(rs.getString(1));
//				list.add(rs.getString(2));
			}
			// 문제되면 exception으로
		} catch (Exception e) {
			e.printStackTrace();
		}

		// list.add("a");
		// list.add("b");
		return list;

	}

	public void mylist() {
		Connection conn = null;		
		try {
			conn = datasource.getConnection();
		} catch (Exception e) {
		}
	}

}
