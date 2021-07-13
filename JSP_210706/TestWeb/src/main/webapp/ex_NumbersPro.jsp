<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<title>Insert title here</title>
</head>
<body>
	<h2>insert data</h2>
	<% request.setCharacterEncoding("utf-8");%>

<%
  int num1 = Integer.parseInt(request.getParameter("num1"));
  int num2 = Integer.parseInt(request.getParameter("num2"));
  
  int sum = num1+num2;
     
%>
sum:<%=sum %><br>

</body>
</html>