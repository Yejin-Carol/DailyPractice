<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
	<head>
 	<!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <!-- <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"> -->
	<link rel="stylesheet" href="bootstrap4.css">
	
	<title>로그인 화면</title>
</head>
<body>
<!-- 로그인 양식 -->
<div class="container"> <!-- 하나의 영역 생성 -->	
  <div class="col-lg-4"> <!--  영역크기 -->
    <!-- 점보트론은 특정 컨텐츠, 두드러지게 하는 큰 박스 -->
    <div class="jumbotron" style="padding-top:20px;">
		<form action="./userJoinAction.jsp" method="post">
	  		<h3 style="text-align: center;">회원등록</h3>
	    	<div class="form-group">
	    		<input type="text" class="form-control" placeholder="아이디" name="loginID" maxlength="20">
	  		</div>	
	  		<div class="form-group">	
				<input type="password" class="form=control" placeholder="비밀번호" name="loginPW" maxlength="20">
	  		</div>	
	  		<div class="form-group">		
				<input type="text" class="form-control" placeholder="이름" name="name" maxlength="20">
	 		</div>	
				<input type="submit" class="btn btn-primary form-control" value="입력완료">
			</form>
		<form action="./UserDB.jsp" method="post">
			<input type="reset" value="다시입력"> 
			<input type="submit" value="조회">
			<input type="submit" value="상품확인">
		</form>
		
  </div>
</div>
</div>
</body>
</html>