<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>장바구니-상품선택</title>
<%
	request.setCharacterEncoding("UTF-8");
	
	session.setAttribute("username", request.getParameter("username"));
%>
</head>
<body>
<h2>상품 선택</h2>
<hr />
<%= session.getAttribute("username") %> 님 어서오세요!<br />
<hr />
<div>
<form name="selProductForm" method="POST" action="add.jsp">
	<select name="product">
		<option>사과</option>
		<option>귤</option>
		<option>파인애플</option>
		<option>자몽</option>
		<option>레몬</option>
	</select>
	<input type="submit" value="추가" />
</form>
<a href="checkOut.jsp">장바구니 보기</a><br />
</div>
</body>
</html>