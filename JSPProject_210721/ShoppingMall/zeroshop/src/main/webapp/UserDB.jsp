<%@ page contentType="text/html; charset=utf-8"%>
<%@ page import="java.sql.DriverManager"%>
<%@ page import="java.sql.Connection"%>
<%@ page import="java.sql.Statement"%>
<%@ page import="java.sql.ResultSet"%>
<%@ page import="java.sql.SQLException"%>
<html>
<head>
<title>Member List</title>


</head>
<body>
	<h1>회원 조회</h1>
	<table border="1">
		<tr >
			<td>loginID</td>
			<td>loginPW</td>
			<td>name</td>
		</tr>
		<%
		// MySQL JDBC Driver Loading 
		Class.forName("com.mysql.cj.jdbc.Driver");
		Connection conn = null;
		Statement stmt = null;
		ResultSet rs = null;
		try {
			String jdbcDriver = "jdbc:mysql://localhost:3306/basicjsp?" + "useUnicode=true&characterEncoding=utf8";
			//String jdbcDriver = "jdbc:mysql://localhost:3306/TUTORIAL?useSSL=false&serverTimezone=UTC";
			//String jdbcDriver = "jdbc:mysql://localhost:3306/TUTORIAL?serverTimezone=UTC"; 

			String dbUser = "root";
			String dbPass = "1234";
			String query = "select * from customer"; // Create DB 
			conn = DriverManager.getConnection(jdbcDriver, dbUser, dbPass);
			// Create Statement 
			stmt = conn.createStatement();
			// Run Qeury 
			rs = stmt.executeQuery(query);
			// Print Result (Run by Query) 
			while (rs.next()) {
		%>
		<tr>
			<td><%=rs.getString("loginID")%></td>
			<td><%=rs.getString("loginPW")%></td>
			<td><%=rs.getString("name")%></td>
		</tr>
		<%
		}
		} catch (

		SQLException ex) {
		out.println(ex.getMessage());
		ex.printStackTrace();
		} finally { // Close Statement 
		if (rs != null)
		try {
			rs.close();
		} catch (SQLException ex) {
		}
		if (stmt != null)
		try {
			stmt.close();
		} catch (SQLException ex) {
		}
		// Close Connection 
		if (conn != null)
		try {
			conn.close();
		} catch (SQLException ex) {
		}
		}
		%>
	</table>
</body>
</html>


