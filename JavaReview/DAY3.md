# Java Review - DAY 3

## Ch 9. 정보은닉 그리고 캡슐화
### 9-1 정보은닉 (Information Hiding)
	- Java의 정보 = 인스턴스 변수 (클래스 내에 선언되는 변수)
	- 정보은닉 필요한 이유? 클래스 사용자가 잘못된 값을 인스턴스 변수에 저장하지 않도록 하기 위해. 
		- 정보 은닉을 위한 private 선언
		- Getter (인스턴스 변수의 값을 참조하는 용도로 저의된 메소드, 예-getName)/Setter(인스턴스 변수의 값을 설정하는 용도로 정의된 메소드, 예-setName)
		- private 필요에 따라 getter/setter 정의가능
	
### 9-2 접근 수준 지시자(Access-leve Modifiers)
	- public/protected/private/default: 아무런 선언도 하지 않는 상황
	- 클래스 정의 대상: public, default
		- public class AAA { //어디서든 인스턴스 생성 가능
		- class ZZZ{ // default-동일 패키지로 묶인 클래스 내에서만 인스턴스 생성을 허용함.
	- 클래스 public 선언: 1. 하나의 소스 파일에 하나의 클래스만 public으로 선언해야함, 2. 소스파일의 이름과 public으로 선언된 클래스의 이름 일치시켜야함!
	- 인스턴스 변수와 메소드 대상: 
		- public: 어디서든 접근 가능
		- default: 동일 패키지로 묶인 클래스 내에서만 접근 가능
		- private: 클래스 내부에서만 접근 가능
		- protected: default 선언이 허용하는 접근 모두 허용함 + default가 허용하지 않는 ***'한 영역'***에서의 접근도 허용. (상속 관계에 있는 두 클래스가 다른 패키지로 묶여 있어도 가능) -> protected로 선언된 멤버는 상속 관계에 있는 다른 클래스에서 접근 가능함.
```java
package alpha;

public class AAA {
	protected int num;
}
```
```java
// 다른(alpha) 패키지 클래스 AAA 상속 
public class ZZZ extends alpha.AAA{
	public void init(int n) {
		num = n;//컴파일 오류로, AAA 클래스 int num을 protected로 변경
	}
}
```
* 인스턴스 멤버 대상 public/protected/private/default 선언에 대한 정리 (접근 허용 범위: public > protected > default > private)

|지시자|클래스 내부  |동일 패키지| 상속 받은 클래스 | 이외의 영역 	
|--|--|--|--|--| 
|private  | O  |X|X|X|
|default  | O  |O|X|X|
|protected  | O  |O|O|X|
|public  | O  |O|O|O|

### 9-3 캡슐화(Encapsulation)
* 하나의 목적을 이루기 위해 관련 있는 모든 것을 하나의 클래스에 담아두는 것 
	- 클래스 큰 것과 상관없이 내용이 중요. 즉, 해당 클래스와 관련 있는 내용을 하나의 클래스에 모두 담되 부족하게 담아서도 넘치게 담아서도 안됨.
1. 하나의 클래스로 캡슐화 완성하기
2. 포함 관계로 캡슐화 완성하기
3. [OOP 학습내용 참고](https://github.com/Yejin-Carol/DailyPractice/blob/main/OOP_%EA%B0%9D%EC%B2%B4%EC%A7%80%ED%96%A5%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%B0%8D.md)

## Ch10. 클래스 변수와 클래스 메소드
### 10-1 static 선언을 붙여서 선언하는 클래스 변수
* 인스턴스 변수는 인스턴스 생성시 인스턴스 안에 존재하는 변수이나 클래스 변수는 인스턴스의 생성과 상관없이 존재하는 변수
* 선언된 클래스의 모든 인스턴스가 공유하는 '클래스 변수(static 변수)' 예) **static** int num = 0;
* static으로 선언된 변수는 변수가 선언된 클래스의 모든 인스턴스가 공유하는 변수. (어떠한 인스턴스에도 속하지 않는 상태로 메모리 공간에 딱 하나만 존재하는 변수)
* 클래스 내부 접근: 변수의 이름을 통해 직접 접근
* 클래스 외부 접근: 클래스 또는 인스턴스의 이름을 통해 접근

```java
class ClassAccess {
	static int num = 0;// 클래스 변수 (static 변수) default로 선언됨

	ClassAccess() {
		plusCount();
	}

	void plusCount() {
		num++; //클래스 내부에서 이름을 통한 접근 
	}
}

public class ClassVariable {

	public static void main(String[] args) {
		ClassAccess ca = new ClassAccess();//// 참조변수 선언과 인스턴스 생성
		ca.num++; // 외부에서 인스턴스의 이름을 통한 접근
		ClassAccess.num++; // 외부에서 클래스의 이름을 통한 접근
		System.out.println("num = " + ClassAccess.num);
	}
}
```
* 클래스 변수는 인스턴스 생성 이전에 메모리 공간에 존재함
* Class Loading: 클래스 정보를 가상머신이 읽는다. (특정 클래스의 인스턴스 생성을 위해 해당 클래스가 반드시 가상머신에 의해 로딩되어야 함) -> 클래스 로딩이 인스턴스 생성보다 먼저 발생!
* 인스턴스간 데이터 공유 필요시 클래스 변수 선언
* static final double PI = 3.1413; 와 같이 참조를 목적으로만 존재하는 final 선언이 된 클래스 변수에 담음. 
### 10-2 static 선언을 붙여서 선언하는 클래스 메소드
 *클래스 메소드의(static 메소드의) 정의와 호출
	 - 클래스 변수와 같이 인스턴스 생성 이전부터 접근이 가능
	 - 어느 인스턴스에도 속하지 않음
* 메소드 static 선언 추가함으로 인해 불필요한 인스턴스의 생성 과정을 생략할 수 있게 됨.
* 클래스 메소드에서 인스턴스 변수 및 메소드 접근 불가능하나 하기 코드와 같이 클래스 메소드는 같은 클래스에 정의되어 있는 다른 클래스 메소드나 성격이 동일한 클래스 변수에 접근 가능
```java
class AAA {
	static int num = 0;
	static void showNum() {
		System.out.println(num); //클래스 변수 접근
	}
	static void addNum(int n) {
		num += n; //클래스 변수 접근 가능
		showNum(); //클래스 메소드 호출 가능
	}
}
```
### 10-3 기타
* System.out.println() 
	- 자바에서 제공하는 클래스로 java.lang 패키지에 묶여있음. 원래 java.lang.System.out.println(...); 하지만 컴파일러가 생략 (import java.lang*;)
	-  	out은 System 클래스 내에 하기와 같이 선언된 클래스 변수
		public final class System extends Object {
			public static final PrintStream out; //참조 변수 out .. }
	- println은 PrintStream 클래스의 인스턴스 메소드
	- 즉, **System에 위치한 클래스 변수 out이 참조하는 인스턴스의 println 메소드를 호출하는 문장**
			
* public static void main(String[] args)
	- main 메소드는 public 그리고 static으로 선언해야함. 일종의 약속! (main 메소드는 인스턴스 생성 이전에 호출됨. static 선언!)
	- 일반적으로 main 메소드를 담기 위한 별도의 클래스 정의함.

* static 초기화 블록 (Static Initialization Block)
```java
import java.time.LocalDate;

class DataOfExecution {
	static String date;
	
	static { // 클래스 로딩시 단 한번 실행됨 (static initialization block)
		LocalDate nDate = LocalDate.now();
		date = nDate.toString();
	}
	public static void main(String[] args) {
		System.out.println(date);
	}//static 초기화 블록 사용하면 클래스 변수 선언과 동시에 초기화 가능!
}
```
* static import 선언 (적당히 사용할 것!)
	- import static java.lang.Math.*;//모든 클래스 변수와 메소드에 대한 import 선언
	- import static java.lang.Math.PI; //PI에 대한 static import 선언

## Ch 11. Method Overloading과 String Class
### 11-1 Method Overloading (중복 정의)
* 메소드 오버로딩: 한 클래스 내에 동일한 이름 메소드 둘 이상 정의 허용되지 않지만 매개변수 선언하여 중복 정의하는 것
	- 메소드 오버로딩 조건: 1. 메소드 이름, 2 메소드의 매개변수 정보 예) 
>MyHome home = new MyHome();
> home.mySimpleRoom(3, 5)
>메소드 이름: mySimpleRoom
>3과 5를 인자로 전달받을 수 있는 메소드
```
class MyHome {
	void mySimpleRoom(int n) {...}
	void mySimpleRoom(int n1, int n2) {...}
	void mySimpleRoom(double d1, double d2) {...}
}
```
* 메소드의 이름이 같아도 매개변수 선언이 다르면 메소드 호출문의 전달인자를 통해서 호출된 메소드를 구분할 수 있음.
* 매개변수의 선언이 다르면 동일한 이름의 메소드 정의를 허용 -> "Method Overloading"
> 단, 반환형이 다른 경우 적용 안됨!
> int mySimpleRoom( ) {...}
	double mySimpleRoom( ) {...}
* 오버로딩 된 메소드 호출시 전달인자의 자료형과 매개변수의 자료형을 일치시키는 것이 좋음!
* 생성자(constructor)도 오버로딩 가능
* 키워드 this를 이용한 다른 생성자의 호출
> Person(int num, int pnum) {
	> regiNum = rnum;
	> passNum =pnum; 
	}
> Person(int num) {
> this(rnum, 0);//this는 오버로딩 된 다른 생성자
> }
* 키워드 this를 이용한 인스턴스 변수의 접근
	- this는 이 문장이 속한 인스턴스를 의미
```java
class ThisExample {
	private int data;//클래스 내 인스턴스 변수
	ThisExample(int data) { //data 매개변수로 선언
		this.data = data; //매개변수 data의 값을 인스턴스 변수 data에 저장
	}
}
```
### 11-2 String Class (문자열 표현을 위해 정의된 클래스)
* String 클래스의 인스턴스 생성
> String str = new String("Simple String");
