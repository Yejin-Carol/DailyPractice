# Java Review - DAY 1

## Ch2. 변수
	- int num1 = 10; //변수 num1 선언과 동시에 10으로 초기화
	- 자료형 종류와 구분 (기본 자료형-Primitive Data Type)
		- boolean(1byte), char(2), byte(1), short(2), int(4), long(8), float(4), double(8)
	- double num1, num2; // 동일한 자료형 변수 둘을 한번 에 선언 가능 (컴퓨터 실수 표현 오차 존재)
	- 자료형 (int, double)과 같은 단어를 keyword라 하며 키워드는 변수의 이름으로 사용 안됨!

## Ch3. 상수(Constants)와 형 변환
* 상수 (Constants)
	> 상수(constants)는 값이 변하지 않는 수를 의미함.
	>변수 선언할 때 그 앞에 final 이라는 선언 추가하면 상수가 됨.
	> 1) 값을 딱 한 번만 할당, 2) 한 번 할당된 값은 변경 불가능함.
	> final char CONST_CHAR ='상';
	> Literals 예) int num =157; //숫자 157은 Literal Constant. 즉, 컴파일러는 숫자 157를 int형 정수로 인식한다. (그렇게 약속됨.) 
	> 8진수: int num = 011 + 022 + 033; //숫자 앞에 0 삽입
	> 16진수: int num = 0x11 + 0x22 + 0x33; //숫자 앞에 0 또는 0X 삽입
	> 실수형 상수: 1) double pi = 3.1415;//뒤에 d 붙여도 됨, 2) float 형 뒤에 f 붙이면 됨.  <br>
* 형 변환
	> 1. 자동 형 변환 (Implicit Conversion)
	> 		규칙 1. 자료형의 크기가 큰 방향으로 형 변환 일어남
	> 		규칙 2. 자료형의 크기에 상관없이 정수 자료형보다 실수 자료형이 우선함.
	> 		System.out.println(59L + 34.5); //결과값 93.5
	> 2. 명시적 변환(Explicit Conversion)
	> 		double pi = 3.1415;
			int wholeNumber  = (int)pi; //pi 값을 int형(소괄호!)으로 명시적 형 변환
	 >     short num3 = (short)(num1 + num2)//short num1 = 1, num2 =2; int 형으로 메모리 임시 저장됨.

## Ch4. 연산자(Operators)
* 자바 연산자들

|연산기호                |결합 방향                          |우선순위                   |
|----------------|-------------------------------|-----------------------------|
|[], .|->            |1(높음)     |
|후위++, 후위--        |<-           |2            |
|++전위, ++전위, +전위, -전위, ~, !, (type)          |<-|3|
|*, /, %          |->|4|
|+, -          |->|5|
|<<, >>, >>>          |->|6|
 |<, >, <=, >=, instanceof          |->|7|
|==, !=          |->|8|
|&          |->|9|
|^         |->|10|
|`|`          |->|11|
|&&          |->|12|
|`||`          |->|13|
|? expr : expr          |->|14|
|=, +=, -=, *=, /= 등      |->|15 (낮음)|

```java
        //증가 연산자
        int num = 5;
		System.out.println((num++) + " ");//postfix++ 5 출력 후-> 6
		System.out.println((num++) + " ");//출력 후 값 증가 6 출력 후-> 7
		System.out.println(num + "\n"); //7
		System.out.println((num--) + " ");//postfix-- 7 출력 후 -> 6 
		System.out.println((num--) + " ");//출력 후 값 감소 6 출력 후 -> 5
		System.out.println(num);//5
```
## Ch.5 실행 흐름의 컨트롤 

* if
"if문, 그리고 if절과 else 절에 속한 문장이 하나인 경우에 중괄호 생략 가능"
if/else if/else 와 같이 헷갈릴 수 있으니 중괄호('{ }') 잘 사용하기!

```java
		int num = 120;
		if (num >0 && (num %2) == 0) 
			System.out.println("양수이면서 짝수");
```
* switch와 break
switch문은 switch, case, default로 이루어짐 (label = case, default)
```java
		int  n = 3; //n이 3이므로 label이 3인것 부터, 즉 case 3부터 출력
		switch(n) {
		case 1: //case 띄우고 1
			System.out.println("Hello Java");
		case 2:
			System.out.println("Happy Java");
		case 3: //n=3이므로 여기서 부터 출력됨
			System.out.println("Great Java");
		default:
			System.out.println("I love JAVA");
		}
		System.out.println("Let's practice JAVA together!");
	}
```
case별 break문 추가하면 case 3와 default 값만 출력됨
* if 조건문 switch 문으로 변경해보기
```java
		int n = 24;
		if(n >= 0 && n < 10)
			System.out.println("0이상 10미만의 수");
		else if(n >= 10 && n < 20)
			System.out.println("10이상 20미만의 수");
		else if(n >= 20 && n < 30)
			System.out.println("20이상 30미만의 수");
		else
			System.out.println("음수 혹은 30 이상의 수");
```
```java
switch(n/10) { 
		
		case 2:
			System.out.println("20이상 30미만의 수");
			break;
		case 1:
			System.out.println("10이상 20미만의 수");
			break;
		case 0:
			System.out.println("0이상 10미만의 수");
			break;
		default:
			System.out.println("음수 혹은 30 이상의 수");	
			}
```
* 반복문 1: while 문
```java
//1~99까지의 합을 구하는 while문
		int num=1;
		int sum=0;
		while (num < 100) {
			sum += num;
			num++;
		}
		System.out.println(sum);
```
* 반복문 2: do~while 문
```java
//1~100까지 출력
		int num1 = 1;
		do 
		{
			System.out.println(num1);
			num1++;
						
		} while (num1 <= 100);
```
* 반복문 3: for 문
```java
		int n=1;
		while (n<100)
		{
			System.out.println(n);
			n++;
		}
		
		//거꾸로 100~1 출력
		
	/*	do
		{
			n--;
			System.out.println(n);
		} while(n>1);
	*/
		for (; n >= 1; n--)
		{
			System.out.println(n);
		}
```			
* continue문과 break 문
	- 문제: 자연수 1부터 시작해서 모든 홀수 더해가기. 그 합이 언제 1000을 넘어서는지, 1000을 넘어선 값은 얼마가 되는지 출력. (은근 오래걸렸음)
```java
int num = 1;
		int sum = 0;
		
		while (true) {
			//홀수이면
			if (num % 2 == 1)
			{
				sum += num;
				num++;
				if (sum > 1000) {
					System.out.println("num이 " + num + "일때 합계는 " + sum);
					break;
				}
			}
			else 
			{
				num++;
			}
						
		}
```
* 반복문 중첩
```java
public static void main(String[] args) {
		
		//구구단 짝수단만 출력 2단은 2x2, 4단은 4x4,....8단은 8x8까지만
		for (int i = 2; i<=9; i++) {	
			for(int j = 1; j<=9; j++)
			{
				if (j<=i)
				System.out.println(i+"x"+j+"="+ i*j);				
			}	
		i = i+1;
		}
	}
```
