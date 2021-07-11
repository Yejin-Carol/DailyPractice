<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.sql.*" %>
<%@ include file="dbConnection.jsp" %>
<%
	String action = request.getParameter("action");
	String move_url = "./";
	PreparedStatement pstmt = null;
	
	/**
	 * index.jsp와 update.jsp에서 form을 전송할 때
	 * action을 hidden값으로 전송한다. 해당 값에 맞는 명령을 수행하도록  작성 
	 */
	switch (action) {
	case "insert" :
		sql = "INSERT INTO member_tbl_02 values(member_seq.nextval, ?, ?, ?, ?, ?, ?)";
		pstmt = conn.prepareStatement(sql);
		pstmt.setString(1, request.getParameter("custname"));
		pstmt.setString(2, request.getParameter("phone"));
		pstmt.setString(3, request.getParameter("address"));
		pstmt.setString(4, request.getParameter("joindate"));
		pstmt.setString(5, request.getParameter("grade"));
		pstmt.setString(6, request.getParameter("city"));
		break;
	case "update" :
		sql  = "update member_tbl_02 SET custname = ?, phone = ?, address = ?, joindate = ?, grade = ?, city = ? where custno = ?";
		pstmt = conn.prepareStatement(sql);
		pstmt.setString(1, request.getParameter("custname"));
		pstmt.setString(2, request.getParameter("phone"));
		pstmt.setString(3, request.getParameter("address"));
		pstmt.setString(4, request.getParameter("joindate"));
		pstmt.setString(5, request.getParameter("grade"));
		pstmt.setString(6, request.getParameter("city"));
		pstmt.setInt(7, Integer.parseInt(request.getParameter("custno")));
		move_url = "./list.jsp";
		break;
	}
	//out.println(sql.trim());
	//if(true) return;
	pstmt.executeQuery();
%>
<script>
	alert('완료되었습니다.');
	location.replace("<%=move_url%>");
</script>