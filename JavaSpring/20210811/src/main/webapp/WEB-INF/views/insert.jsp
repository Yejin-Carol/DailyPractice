<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<script type="text/javascript">
	window.onload = function() {
		alert('윈도우 다 부르고 나서 함수 실행');
		var send = document.getElementById('send');
		alert(send);
		send.onclick = function() {}
		$('#frm').submit();
	}
	
</script>
<!-- cdm파일 -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

<script type="text/javascript">
	$(document).ready(function(){
		alert('윈도우 다 부르고 나서 실행');
		var send = $('#send')
		});


</script>
</head>
<body>
<h1>insert/delete/update</h1>

<form id=frm action="insertproc" method="post">
	<input type="text" name="para1"/>
	<input type="text" name="para2"/>
	<input type="submit" value="입력"/>	
</form>
<div id="send">aaa</div>



<form action="deleteproc" method="post">
	<input type="text" name="para1"/>
	<input type="submit" value="삭제"/>	
</form>


<form action="updateproc" method="post">
	<input type="text" name="para1"/>
	<input type="text" name="para2"/>
	<input type="submit" value="수정"/>	
</form>

</html>