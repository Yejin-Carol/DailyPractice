<%@ page import= "user.UserDAO"%>
<%@ page import= "user.UserDTO"%>
<%@ page import= "java.io.PrintWriter" %>
<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>

<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
<%
	request.setCharacterEncoding("EUC-KR");
	UserDTO NewUser = new UserDTO();
	if(request.getParameter("loginID")!=null)
	{
		NewUser.setLoginID(request.getParameter("loginID"));
	}
	if(request.getParameter("loginPW")!=null)
	{
		NewUser.setLoginPW(request.getParameter("loginPW"));
	}
	if(request.getParameter("name")!=null)
	{
		NewUser.setName(request.getParameter("name"));
	}
	if(NewUser.getLoginID().equals("")|| NewUser.getLoginPW().equals("") || NewUser.getName().equals("") )
	{
		PrintWriter script = response.getWriter();
		script.println("<script>");
		script.println("alert('�Է��� �� �� �� �ִ�.')");
		script.println("location.href='insertUser.jsp'");
		script.println("</script>");
		script.close();
		return;
	}
	
	//ID�� ��й�ȣ�� ��� �ִ� ���
	UserDAO userDAO = new UserDAO();
	int result = userDAO.join(NewUser.getLoginID(), NewUser.getLoginPW(), NewUser.getName());
	if(result == 1) //���������� ������ ���
	{
		PrintWriter script = response.getWriter();
		script.println("<script>");
		script.println("alert('ȸ�������� �����մϴ�.')");
		script.println("location.href='insertUser.jsp'");
		script.println("</script>");
		script.close();
	}
			
%>
</body>
</html>