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
	
	<title>�α��� ȭ��</title>
</head>
<body>
<!-- �α��� ��� -->
<div class="container"> <!-- �ϳ��� ���� ���� -->	
  <div class="col-lg-4"> <!--  ����ũ�� -->
    <!-- ����Ʈ���� Ư�� ������, �ε巯���� �ϴ� ū �ڽ� -->
    <div class="jumbotron" style="padding-top:20px;">
		<form action="./userJoinAction.jsp" method="post">
	  		<h3 style="text-align: center;">ȸ�����</h3>
	    	<div class="form-group">
	    		<input type="text" class="form-control" placeholder="���̵�" name="loginID" maxlength="20">
	  		</div>	
	  		<div class="form-group">	
				<input type="password" class="form=control" placeholder="��й�ȣ" name="loginPW" maxlength="20">
	  		</div>	
	  		<div class="form-group">		
				<input type="text" class="form-control" placeholder="�̸�" name="name" maxlength="20">
	 		</div>	
				<input type="submit" class="btn btn-primary form-control" value="�Է¿Ϸ�">
			</form>
		<form action="./UserDB.jsp" method="post">
			<input type="reset" value="�ٽ��Է�"> 
			<input type="submit" value="��ȸ">
			<input type="submit" value="��ǰȮ��">
		</form>
		
  </div>
</div>
</div>
</body>
</html>