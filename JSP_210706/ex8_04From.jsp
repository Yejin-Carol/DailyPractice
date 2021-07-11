<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    
<% request.setCharacterEncoding("utf-8");%>
<%
 String id="";
 String passwd="";
 
 id = request.getParameter("id");
 passwd = request.getParameter("passwd");
 
 if(id==null || id.equals(""))
	 id="test";
 
 if(passwd==null || passwd.equals(""))
	 passwd="testPass";
 
 %>    

 ex8_04To.jsp 페이지로 포워딩합니다. <br>
 
 <jsp:forward page="ex8_04To.jsp">
 	<jsp:param name="id" value="<%=id%>"/>
 	<jsp:param name="passwd" value="<%=passwd%>"/>
 
 </jsp:forward>