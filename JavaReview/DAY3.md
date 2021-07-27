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
* 하나의 인스턴스 생성 후 공유 가능 왜냐하면 String 인스턴스는 그 안에 저장된 데이터를 수정할 수 없는, 참조만 가능한 인스턴스이기 때문이다. 
> 참고 equals( )
> if(str1.equals(str2)) //문자열 내용이 같으면 equals 메소드는 true 반환
* String 인스턴스를 이용한 switch문의 구성
> 자바 7 부터가능, 
> switch(str) {
> case "one" : .....}

### 11-3 String 클래스의 메소드
* 자바 문자 참고: (https://docs.oracle.com/javase/8/docs/api/index.html)
* 문자열 연결시키기: Concatenating 
> public String concat(String str)
> String1.concat(String2); //String1과 String2 연결한 결과를 반환
> String st3 = "Hi".concat(2) 도 가능!
*문자열 일부 추출: Substring
> public String substring(int beginIndex) // beginIndex ~ 끝까지 추출
> String str = "abcdef";
> str.substring(2); -> 결과값: "cdef"
> String st3 = st1.substring(2, 4) -> st3 결과값: "cd"
"cdef"가 담긴 인스턴스가 생성, 이 인스턴스 참조 값 반환돔. substring 메소드 오버로딩 됨.
* 문자열 내용 비교: comparing
	- public boolean equals(Object object) -> true/false
	- public int compareTo (String anotherString)
	- public int compareToIgnoreCase(String str)
* 기본 자료형의 값을 문자열로 바꾸기
	- static String valueOf(boolean b)
	- static String valueOf(char c)
	- static String valueOf(double d)
	- static String valueOf(float f)
	- static String valueOf(int i)
	- static String valueOf(long l)
> 클래스 메소드 이므로 사용법 간단함.
> double e = 3.143123;
> String se = String.valueOf(e);
* 문자열을 대상으로 하는 +연산과 +=연산
	- System.out.println("hot" + "summer"); //문자열 + 문자열
	- ("hot".concat("summer"));
	- String str = "hot" + "summer";
	- String str = "age: ".concat(String.valueOf(17));
> String str = "hot"; 
> str += "summer"; //str = str + "summer" 

* concat 메소드 이어서 호출 가능
	- String str = "AB".concat("CD").concat("EF");
		-> String str = "ABCDEF";
		-> String str = ("AB".concat("CD")).concat("EF");
		->String str = ("ABCD".concat("EF");
* 문자열 결합의 최적화: Optimization of String Concatenation
* StringBuilder 클래스
	- 내부적으로 문자열을 저장하기 위한 메모리 공간을 지님
	- public StringBuilder append(int i)  -> 기본 자료형 데이터를 문자열 내용에 추가
	- public StringBuilder delete(int start, int end) -> 인덱스 start에서부터 end 이전까지의 내용을 삭제
	- public StringBuilder insert(int offset, String str) -> 인덱스 offset 위치에 str에 전달된 문자열 추가
	- public StringBuilder replace(int start, int end, String str) -> 인덱스 start에서부터 end 이전까지의 내용을 str의 문자열로 대체
	- public StringBuilder reverse() -> 저장된 문자열의 내용을 뒤집는다.
	- public String substring(int start, int end) -> 인덱스 start에서부터 end 이전까지의 내용만 담은 String 인스턴스의 생성 및 반환
	- public String toString() -> 저장된 문자열의 내용을 담은 String 인스턴스의 생성 및 반환
* StringBuilder 클래스 이전에 사용이 되던 StringBuffer 클래스
* 공통점
	- 생성자를 포함한 메소드의 수
	- 메소드의 기능
	- 메소드의 이름과 매개변수의 선언
* StringBuffer는 쓰레드에 안전하지만, StringBuilder는 쓰레드에 안전하지 않음
* 멀티 쓰레드에 안전하게 설계된 StringBuffer 클래스는 속도가 느림.

## Ch 12 콘솔 입력과 출력
### 12-1 콘솔 출력(Console Output)
* 콘솔: 컴퓨터 대상으로 데이터를 입력 및 출력하는 장치의 총칭. 키보드와 모니터도 콘솔 입출력 장치에 해당함.
> System.out.println(stb.toString()); : 참조 값이 전달되면, 이 값의 인스턴스를 대상으로 toString 메소드를 호출함. 이때 반환되는 문자열을 출력함.
> System.out.print (개행 없음)
* 문자열을 조합해서 출력하는 System.out.printf("정수는 %d, 실수는 %f, 문자는 %c", 12, 24.5, 'A');
	* printf (1. 출력의 기본 구성을 담은 문자열, 2 문자열 채우기 위한 값)
		- %d :  10진수 정수 형태
		- %f : 10진수 실수 형태
		- %c : 문자 형태, %s: 문자열 형태
### 12-2 콘솔 입력(Console Input)
* Scanner 클래스
	- Scanner (File Source)
	- Scanner (String source)
	- Scanner (InputStream source)
> Scanner sc = new Scanner(source);
* Scanner 클래스의 키보드 적용
	- Scanner sc =new Scanner(source); -> Scanner sc = new Scanner(*System.in*);
* Scanner 클래스의 주요 메소드들
	- int nextInt( )
	- byte nextByte( )
	- String nextLine( )
	- double nextDouble( )
	- boolean nextBoolean( )

## Ch 13. 배열 (Array)
### 13-1 1차원 배열의 이해와 활용
* 배열은 '자료형이 같은 둘 이상의 값'을 저장할 수 있는 메모리 공간을 의미함.
* 1차원 배열 생성 방법
	- 타입이 같은 둘 이상의 데이터를 저장할 수 있는 1차원 구조의 메모리 공간
	- 자바는 배열도 인스턴스임!
	- int [ ] : int형 변수로 이뤄진 배열을 참조한다는 의미!
	- 다양한 배열 생성 -> 메모리 할당
> int[ ] ref = new int[5]; //길이가 5인 int형 1차원 배열의 생성문
> int[ ] ref : int형 1차원 배열 인스턴스를 참조할 수 있는 '참조변수의 선언', ref (참조변수) -> 참조 변수 생성 
> new int[5] : int형 값 5개를 저장할 수 있는 '배열 인스턴스의 생성', length = 5 (인스턴스 변수 length) , 인스턴스 생성 다섯 개의 int형 변수. 즉 배열 생성
```java
public static void main(String[] args) {
		//1. 길이가 3인 int형 1차원 배열 생성
		int[] arr1 = new int[3];
				
		//2. 길이가 5인 double형 1차원 배열 생성
		double[] arr2 = new double[5];
		
		//3. 배열의 참조변수와 인스턴스 생성 분리
		float[] arr3;
		arr3 = new float[7];
		
		//4. 배열의 인스턴스 변수 접근
		System.out.println("배열 arr1 길이: " + arr1.length);
		System.out.println("배열 arr2 길이: " + arr2.length);
		System.out.println("배열 arr3 길이: " + arr3.length);
	}
```
* 배열 생성과 동시에 초기화
> int[ ] arr = new int[3]; //왼쪽 더 선호 하지만 int arr[ ] = new int[3]; 가능!
> int[ ] arr = new int[ ] {1, 2, 3};
> int[ ] arr = {1, 2, 3};

* 배열의 초기화와 배열의 복사
	- int[ ] arr = new int[10]; //배열의 모든 요소 0으로 초기화
	- String[ ] arrs = new String[10];//배열의 모든 요소 null로 초기화
	- java.util.Arrays 클래스에 정의되어있음
>public satic void fill(int[] a, int val) -> 두 번째 인자로 전달된 값으로 배열 초기화
> public static void fill(int[] a, int fromIndex, int toIndex, int val) -> 인덱스 fromIndex ~ (toIndex-1)의 범위까지 val의 값으로 배열 초기화
* - java.lang.System 클래스
> public static void arraycopy(Object src, int srcPos, Object dest, int destPos, int length) -> 복사 원본의 위치: 배열 src 인덱스 srcPos
> 복사 대상의 위치: 배열 dest의 인덱스 destPos
> 복사할 요소의 수: length
* main 메소드의 매개변수 선언
> String[] bts = new String[] {"Jimin", "Jin", "RM", "V", "Jungkook", "Suga", "J-Hope};
> main(bts);
```java
public static void main(String[] args) {
	
		String[] bts = new String[] 
				{"Jimin", "Jin", "RM", "V", "Jungkook", "Suga", "J-Hope"};
		for(int i=0; i<bts.length; i++) {
			System.out.println("BTS 멤버 " + (i+1) + " = " + bts[i]);
		}		
	}
```
> 결과 출력
> BTS 멤버 1 = Jimin
BTS 멤버 2 = Jin
BTS 멤버 3 = RM
BTS 멤버 4 = V
BTS 멤버 5 = Jungkook
BTS 멤버 6 = Suga
BTS 멤버 7 = J-Hope

### 13-2 enhanced for(for-each)문
* 새로운 for문의 장점
	- 코드의 양이 절대적으로 줄어듬
	- 반복문 구성 과정에서 배열의 길이 정보를 직접 확인하고 입력할 필요가 없음
	- for(요소: 배열) { 반복할 문장들 }
```java
int[] arr = {1, 2, 3, 4, 5};
		for(int e : arr) {
			System.out.println(e);
		}
```
```java

	int[] arr = {1, 2, 3, 4, 5};
		int sum = 0;
		for(int e : arr) {
			sum += e;
		}
		System.out.println(sum);
```
* 인스턴스 배열을 대상으로 하는 enhanced for 문
	- '기본 자료형의 값'이 아닌 '인스턴스 참조 값'인 경우에도 사용 가능
	- e가 String형 참조변수로 선언되었음.
```java
for(String e : bts) { 
			//e = bts[0];
			System.out.println(e);
		}
```

### 13-3 다차원 배열의 이해와 활용
* 2차원 배열의 생성과 접근
* int[ ][ ] arr = new int [4][3]

|[0][0]  | [0][1]  | [0][2] |
|--|--|--|
|[1][0]  | [1][1]  | [1][2] |
|[2][0]  | [2][1]  | [2][2] |
|[3][0]  | [3][1]  | [3][2] |


```java
int[][] arr = new int[3][4];
		int num = 1;
		// 배열에 값 저장
		for (int i = 0; i < arr.length; i++) {
			for (int j = 0; j < arr[i].length; j++) {
				arr[i][j] = num;
				num++;
			}
		}
		for (int i = 0; i < arr.length; i++) {
			for (int j = 0; j < arr[i].length; j++) {
				System.out.println(arr[i][j] + "\t");
				;
				num++;
			}
			System.out.println();
		}

```
```java
int[][] arr = { { 11 }, { 22, 33 }, { 44, 55, 66 } };
		// 배열의 구조대로 내용 출력
		for (int i = 0; i < arr.length; i++) {
			for (int j = 0; j < arr[i].length; j++) {
				System.out.println(arr[i][j] + "\t");
			}
			System.out.println();
		}
```
