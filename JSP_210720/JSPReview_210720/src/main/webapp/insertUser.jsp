<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>

<form action="./userJoinAction.jsp" method="post">
	<input type="text" name="userID"><br>
	<input type="password" name="userPassword">
	<input type="submit" value="ȸ������">
</form>
<form action="./UserDB.jsp" method="post">
	<input type="submit" value="��ȸ">
</form>
</body>
</html>