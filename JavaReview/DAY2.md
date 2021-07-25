# Java Review - DAY 2

## Ch6. 메소드 변수의 스코프

### 6-1 메소드란?
```java
public static void main(String[] args) {
		
		int num1 = 2;
		int num2 = 4;
		System.out.println("2 + 4 = " + (num1+num2));
		}
```
* method 명은 main (java 프로그램은 main이라는 이름의 method에서부터 시작한다는 약속에 근거!)
* method 중괄호({ }) 내에 존재하는 문장들이 위에서 아래로 순차적으로 실행됨.
```java
public static void main(String[] args) {
		
		System.out.println("Program begins");
		btsBillboard(1);//call btsBillboard by sending 1, 메소드 btsBillboard를 호출하는 문장, 숫자 1은 btsBillboard(int rank) rank에 전달됨. 
		System.out.println("Program ends");
		}
	
	//메소드 btsBillboard의 정의
	public static void btsBillboard(int rank) {
		System.out.println("Permission to Dance");
		System.out.println("BTS celebrate Billboard Hot 100 number " + rank);
	}
```
* 매개변수
	- 메소드 호출 시 전달되는 값을 받기 위해 선언된 변수
	- 메소드 호출 시 선언되어, 전달되는 값을 저장함.
	- 매개변수가 선언된 메소드 내에서만 유효한 변수
	- 매개변수 두 개인 메소드
```java
public static void main(String[] args) {
		
		System.out.println("Program begins");
		btsJimin(26, 173.6);//age, height 매개변수에 값 전달
		System.out.println("Program ends");
		}
		
	public static void btsJimin(int age, double height) {
		System.out.println("Jimin's profile");
		System.out.println("Jimin is " + age + " years old");
		System.out.println("Jimin is " + height + " cm");
	}
```
* void: 이 메소드는 값을 반환하지 않는다.
        
```java
public static void main(String[] args) {
		
		int result;
		result = add(2, 4); //add가 반환하는 값 result에 저장
		System.out.println("2 + 4 = " + result);
		System.out.println("3.5 x 3.5 = " + square(3.5));
		}
	
	
	public static int add(int num1, int num2) {
		int addResult = num1 + num2;
		return addResult; //addResult의 값을 반환
	}
	public static double square(double num) {
		return num * num; //num * num의 결과를 반환
			
	}
```
* add 메소드는 int 형 값을 반환한다.
* square 메소드는 double형 값을 반환한다.
* int add(): 반환형 (자료형)
* return 변수; 값의 반환을 명령
* 키워드 return이 갖는 의미
	- 메소드를 호출한 영역으로 값을 반환
	- 메소드의 종료 

* 메소드 응용 문제 1. (ch12. 콘솔 입력과 출력의 Scanner 클래스 포함): 3개의 숫자 입력 받아 큰 순서대로 출력
```java
public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.println("num1: ");
		int num1 = sc.nextInt();
		System.out.println("num2: ");
		int num2 = sc.nextInt();
		System.out.println("num3: ");
		int num3 = sc.nextInt();	
			
		System.out.println("Program begins");
		numArrange(num1, num2, num3);
		System.out.println("Program ends");
	}
	
	public static void numArrange(int num1, int num2, int num3) {
		
		System.out.println("num1: " + num1 + "num2: " + num2 + "num3: " + num3);
				
		if (num1> num2) {// num1 > num2 일때
			if (num1 > num3) // num1 > num3 이고
			{
				if (num2 > num3) // num2 > num3 이면
				{
				System.out.println(num1 + "-" + num2 + "-" + num3);
				}
				else 
				{ // num2 < num3 이면
				System.out.println(num1 + "-" + num3 + "-" + num2);	
				}
			}
			else
			{ // num1 > num2 이지만 num1 < num3이면 num3이 가장 큼!
				System.out.println(num3 + "-" + num1 + "-" + num2);				
			}
		}
		else { //num1 < num2
			if (num2 > num3) //num2이 가장 큼 
			{
				if (num1 > num3)
				{
					System.out.println(num2 + "-" + num1 + "-" + num3);
				}
				else//num1 < num2 이면서 num1 < num3 
				{
					System.out.println(num2 + "-" + num3 + "-" + num1);
				}
			}
			else// num1 < num2 이면서 num2 < num3 즉 num3가 가장 큼
			{
				System.out.println(num3 + "-" + num2 + "-" + num1);
			}
		}
		
		
	}
```
### 6-2 변수의 스코프
	- 임의의 변수에 대한 '변수의 접근 가능 영역' 또는 '변수가 소멸되지 않고 존재할 수 있는 영역'
	- 가시성(Visibility)
		- 중괄호 사용되었던 때 ({...})
			1. if문 또는 if ~ else
			2. 다양한 반복문과 switch문
			3. 메소드의 몸체 부분을 감싸는 용도
	- 중괄호로 특정 영역 감싸면, 해당 영역은 변수에 관한 별도의 스코프 형성하게 함. 
	- 중괄호 내에 선언된 변수들 = 지역 변수(Local Variables)
		- for문의 초기화 부분에 선언되는 변수와 매개변수 또한 지역 변수
		- 중요 특징: ***"지역변수는 선언된 지역을 벗어나면 메모리 공간에서 소멸됨."***

### 6-3 메소드의 재귀 호출

* 재귀(Recursion) 
	- 팩토리얼(Factorial) !
		- f(n)= 
			- 1 )  n>=2, n x f(n-1), 
			- 2 )  n=1, 1 		
```java
	public static void main(String[] args) {
		//재귀적 메소드
		System.out.println("3 factorial: " + factorial(3));
		System.out.println("12 factorial: " + factorial(12));
	}
		
	public static int factorial(int n) {//3과 12를 이자로 전달
		if(n==1)
			return 1;
		else
			return n * factorial(n-1);//인자로 3-1, 12-1 전달하며 factorial n=1이 될때까지 호출
	}
```
* 메소드 응용 문제 2. 1개의 숫자를 입력받아서 구구단 출력 
조건1) 숫자 입력 main()에서 입력 받기
조건2) 숫자를 매개변수로 전달하여 구구단 출력하는 메소드 작성
```java
public static void main(String[] args) {
	
		Scanner sc = new Scanner(System.in);
		System.out.println("구구단 몇단?: ");
		int num = sc.nextInt();		
		multiplicationTable(num);
	}
	
	public static void multiplicationTable(int num) {
		
		int i = num;
			for(int j=1; j<=9; j++)
			{
				System.out.println(num + " x " + j + " = " + num*j);
			}
	}
```
* 메소드 응용 문제 3. 숫자2개와 사칙연산자 입력 받아서 간단한 계산기 프로그램
조건1) 숫자 2개와 사칙연산는 main()에 입력받음
조건2) 숫자 2개와 사칙연산을 메소드에 매개변수로 전달
조건3) 계산 결과값은 메소드 리턴값 받아서 출력
```java
import java.util.Scanner;

public class CalculatorMethod {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.println("num1: ");
		int num1 = sc.nextInt();
		System.out.println("num2: ");
		int num2 = sc.nextInt();
		System.out.println("원하는 사칙연산(+, -, *, /) 선택: ");
		String operation = sc.next();
		calculator(num1, num2, operation);
		int result;
		if (operation == "+") {
			result = add(num1, num2);
		} else if (operation == "-") {
			result = minus(num1, num2);
		} else if (operation == "*") {
			result = multiply(num1, num2);
		} else {
			result = divide(num1, num2);
		}
	}
	//void로 값 반환하지 않음
	public static void calculator(int num1, int num2, String operation) {
		System.out.println("1st number: " + num1);
		System.out.println("원하는 연산: " + operation);
		System.out.println("2nd number: " + num2);
		System.out.println("그 결과값은?");

	}
	//return 값 반환
	public static int add(int num1, int num2) {
		int addResult = num1 + num2;
		System.out.println(addResult);
		return addResult;
		
	}

	public static int minus(int num1, int num2) {
		int minusResult = num1 - num2;
		System.out.println(minusResult);
		return minusResult;
	}

	public static int multiply(int num1, int num2) {
		int multiplyResult = num1 * num2;
		System.out.println(multiplyResult);
		return multiplyResult;
	}

	public static int divide(int num1, int num2) {
		int divideResult = num1 / num2;
		int rest = num1 % num2;
		System.out.println("몫: " + divideResult);
		System.out.println("나머지는: " + rest);
		return divideResult;
	}

}
```

## Ch7. 클래스와 인스턴스
### 7-1 클래스의 정의와 인스턴스 생성
* Class = Data + Method
	- Data: 프로그램상에서 유지하고 관리해야 할 데이터(변수의 선언을 통해 유지 및 관리됨)		
	- 기능: 데이터를 처리하고 조작하는 기능
	- 변수에  저장된 데이터는 '메소드의 호출'을 통해 처리됨. (위의 마지막 예제는 CalculatorMethod 클래스의 정의로 프로그램상 기능으로는 calculator/add/minus/multiply/divide이 있다.)
* 클래스의 구성과 인스턴스화
	- 클래스 내에 위치한 변수와 메소드
		- 인스턴스 변수: 클래스 내에 선언된 변수
		- 인스턴스 메소드: 클래스 내에 정의된 메소드
		- 인스턴스 변수가 선언된 위치는 메소드 내부로 중괄호 안에 선언되는 지역변수와 다름!
		- ***"인스턴스 변수는 같은 클래스 내에 위치한 메소드 내에서 접근이 가능함"***
		- 인터스턴스 변수 = 멤버 변수, 필드(Fields)
		- new BankAccount(); //클래스 BankAccount의 인스턴스화(Instantiation), 만들어진 인스턴스를 참조할 수 있는(가리키고 있을 수 있는) '참조 변수(Referene Variable) 필요!
		- 키워드 new를 통해 인스턴스 생성시 인스턴스의 주솟값이 반화됨. 
		- 참조변수는 인스턴스를 참조함, 참조 변수는 인스턴스를 가리킴
```
Menu m = new Menu();//참조변수 선언과 인스턴스 생성
```
- instance = object 객체! 인스턴스 생성 = 객체 생성
```java
BankAccount ref = new BankAccount(); //참조변수 선언과 인스턴스 생성
		ref.deposit(3000);
		ref.withdraw(300);
		check(ref);//참조 값의 전달
```
- ref = null;// ref가 참조하는 인스턴스와의 관계를 끊음
- BankAccount ref = null;
### 7-2 생성자(Constructor)와 String 클래스

- String 클래스
	 - 문자열을 메소드의 인자로 전달 가능
	 - 매개변수로 String형 참조변수를 선언하여 문자열을 인자로 전달받을 수 있음.
- public static void printString(String str) { System.out.print(str); }//String 참조변수를 매개변수로 선언하여 문자열을 전달 받을 수 있음.
```java
class BankAccount {

	String accNumber;// 인스턴스 변수-계좌번호
	String idNumber; // 인스턴스 변수-주민번호
	int balance = 0; // 인스턴스 변수-예금 잔액 선언 및 초기화

	// 초기화를 위한 메소드
	public void initAccount(String acc, String id, int bal) {
		accNumber = acc;
		idNumber = id;
		balance = bal;
	}

	public int deposit(int amount)// 인스턴스 메소드
	{
		balance += amount;
		return balance;
	}

	public int withdraw(int amount) {
		balance -= amount;
		return balance;
	}

	public int checkMyBalance() {
		System.out.println("계좌번호 : " + accNumber);
		System.out.println("주민번호 : " + idNumber);
		System.out.println("잔액 : " + balance + '\n');
		return balance;
	}

}

class BankAccountUniID { // 클래스 정의
	public static void main(String[] args) {
		BankAccount jimin = new BankAccount();// 계좌 생성
		jimin.initAccount("12345","951212-12345", 10000); //초기화
		
		BankAccount jennie = new BankAccount();// 계좌 생성
		jennie.initAccount("67891","961112-21234", 5000);//초기화		
	
		jimin.deposit(30000);
		jennie.deposit(10000);
		jimin.withdraw(5000);
		jennie.deposit(2000);
		jimin.checkMyBalance();
		jennie.checkMyBalance();	
	}
}
```
* 계좌 개설 시 예금액으로 초기화하는 메소드 추가
	- 인스턴스의 초기화를 위한 메소드
	- 인스턴스 생성 시 반드시 한번 호출해서 초기화를 진행해야함. 

* 생성자 (Constructor)
	- 생성자 메소드 (Constructor Method)로 표현하기도 함.
	- i) 생성자의 이름은 클래스의 이름과 동일해야함 (클래스명으로 맞춰주기)
	- ii) 생성자는 값을 반환하지 않고 반환형도 표시하지 않음. (void 지우기)
```java
public BankAccount(String acc, String id, int bal) {//기존 initAccount 메소드 생성자 위해-> 클래스명인 BankAccount로 변경하고 void도 지우기
		accNumber = acc; //변수 accNumber 초기화
		idNumber = id;//변수 idNumber 초기화
		balance = bal;//변수 balance 초기화
	}
```
* 인스턴스 생성의 마지막 단계는 생성자 호출
* 생성자 호출이 생략된 인스턴스는 인스턴스가 아니다.
* 참고: Default constructor, 생성자를 생략한 상태의 클래스 정의하면 자바 컴파일러 '디폴트 생성자'라는 것을 클래스의 정의에 넣어줌
		- public BankAccount() { //컴파일러에 의해 자동 삽입되는 '디폴트 생성자'		// empty
### 7-3 자바의 Naming Rule
* Class: CamelCase
	- 클래스 이름의 첫 문자는 대문자로 시작
	- 둘 이상의 단어가 묶여서 하나의 이름을 이룰때 새로 시작하는 단어는 대문자. 예) User + Info = UserInfo
* Method: 변형된 camelCase
	- 첫 문자 소문자로 시작. 예) Your + Age = yourAge
* 상수: 변수와 구분되게 모든 문자 대문자로 구성
	- final int COLOR_RAINBOW = 7;

## Ch 8. Package와 Class Path
* Class Path
	- 경로(Path), 클래스 패스(Class Path)는 "자바 가상머신이 클래스 파일을 찾는 경로"
	- 현재 디렉토리 = 명령 프롬프트 상에서 작업이 진행 중인 디렉토리 위치
	- C:\PackageStudy\MyClass
	-  절대 경로: C:\를 기준으로 지정한 경로
		(. 그리고 .\MyClass)
	- 상대경로: set classpath = .;/\MyClass , "현재 디렉토리의 서브(하위) 디렉토리인 MyClass 디렉토리" 현재 디렉토리 기준으로 파일이나 디렉토리의 위치를 가리키는 것
	- 현재 디렉토리가 바뀌면 상대 경로가 지정하는 모든 경로가 그에 맞게 수정됨. (유연함)

* Package
	- 패키지는 클래스를 묶는 단위
	- public class 
		- 하나의 소스파일에 public으로 선언된 클래스의 정의를 하나만 둘 수 있음
		- 소스파일의 이름은 public으로 선언된 클래스의 이름과 동일해야 함.
	- 이름 충돌 패키지로 해결
		- 클래스 접근 방법 구분
			- 서로 다른 패키지의 두 클래스는 인스턴스 생성 시 사용하는 이름이 다름.
		- 클래스의 공간적인 구분
			- 서로 다른 패키지의 두 클래스 파일은 저장되는 위치 다름.
	- 패키지 Naming Rule
		- 클래스의 이름과 구분 되도록 모두 소문자
		- 인터넷 도메인 이름의 역순으로 패키지 이름 구성
		- 패키지 이름의 끝에 클래스를 정의한 주체 또는 팀을 구분하는 이름 추가
		- 예) abc.com의 data 팀: com.abc.data
		- 패키지 Circle 인스턴스 생성 문장
		  예) com.abc.data.Circle c1 = new com.abc.data.Circle(3.5)
		 - 패키지 선언. 예) package com.abc.data;
		 - import 선언 예) import com.abc.data.Circle;
		   (import 선언은 이름 충돌 발생하고 의도치 않게 클래스 인스턴스를 생성하는 상황으로 이어질 수 있으므로 사용 자제할 것 권고!)
