<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"  import="java.util.ArrayList" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>장바구니-상품추가</title>
</head>
<body>
<%
	request.setCharacterEncoding("UTF-8");
	String productName = request.getParameter("product");
	
	ArrayList<String> list = (ArrayList<String>) session.getAttribute("productList");
	if (list == null) {
		list = new ArrayList<String>();
		session.setAttribute("productList", list);
	}
	
	list.add(productName);	
%>
<script>
	alert("<%= productName %> 이(가) 추가 되었습니다.");
	history.go(-1);
</script>
</body>
</html>