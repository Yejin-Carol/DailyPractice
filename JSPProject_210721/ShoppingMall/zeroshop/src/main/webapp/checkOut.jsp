<%@ page language="java" contentType="text/html; charset=UTF-8" import="java.util.ArrayList" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>장바구니-장바구니</title>
</head>
<body>
<h2>장바구니</h2>
<hr />
<%= session.getAttribute("username") %>님의 장바구니 목록<br />
<hr />
<%
	ArrayList<String> list = (ArrayList<String>) session.getAttribute("productList");
	if (list == null) {
		out.println("선택한 상품이 없습니다!");
	}
	else {
		for (String item : list)
			out.println(item + "<br />");	
	}
	
%>

</body>
</html>