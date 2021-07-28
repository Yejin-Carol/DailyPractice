# Java Review - DAY 4
## Ch 14. 클래스의 상속 1: 상속의 기본
### 14-1 상속의 기본 문법 이해
* 상속의 가장 기본적인 특성
```java
class Bts {
	String name;
	public void tellYourName() {
		System.out.println("My group name is " + name);
	}
}

class FanArmy extends Bts { //Bts를 상속하는 FanArmy
	String organization;
	String position;
	public void tellYourInfo() {
		System.out.println("Our organization is based on " + organization);
		System.out.println("Our position is " + position);
		tellYourName(); //Bts 클래스를 상속했기 때문에 호출 가능
	}
}
```
* Bts 클래스: 상속의 대상이 되는 클래스/상위클래스/기초클래스/부모클래스
* FanArmy 클래스: 상속을 하는 클래스/하위클래스/유도클래스/자식클래스
* Bts (참조변수) -> FanArmy 인스턴스
	- String name;
	- String organization;
	- String position;
	- void tellYourName(){..} : Bts의 멤버
	- void tellYourInfo(){..}  

```mermaid
graph LR
A[FanArmy]  --> B[Bts]
```
* 상속 관계에 있는 두 클래스의 적절한  생성자 정의
	- 자바는 상속 관계에 있을지라도, 인스턴스 변수는 각 클래스의 생성자를 통해서 초기화해야 한다는 것!
```java
class Bts {
	
	String name;
	
	public Bts(String name) {
		this.name = name;
	}

	public void tellYourName() {
		System.out.println("Our favourite song is " + name);
	}
}

class FanArmy extends Bts { // Bts를 상속하는 FanArmy
	String organization;
	String position;

	public FanArmy(String name, String organization, String position) {
		//상위 클래스의 생성자 호출
		super(name);
		// 클래스 FanArmy의 멤버 초기화
		this.organization = organization;
		this.position = position;
	}
	public void tellYourInfo() {
		System.out.println("Our organization is based on " + organization);
		System.out.println("Our position is " + position);
		tellYourName(); // Bts 클래스를 상속했기 때문에 호출 가능
	}
}

class BtsFanArmy {
	public static void main(String[] args) {
		FanArmy fa = new FanArmy("Butter", "Weverse", "Member");
		fa.tellYourInfo();
	}
}
```
>실행 결과
>Our organization is based on Weverse
Our position is Member
Our favourite song is Butter

### 14-2 클래스 변수, 클래스 메소드와 상속
* static 선언이 붙는 '클래스 변수'와 '클래스 메소드'의 상속
	- 인스턴스의 생성과 상관 없이 접근 가능하다.
	- 클래스 내부와 외부에서(접근 수준 지시자가 허용하면) 접근이 가능하다.
	- 클래스 변수와 클래스 메소드가 위치한 클래스 내에서는 직접 접근이 가능하다.
```java
class SuperClass {
	static int count = 0; //클래스 변수
	public SuperClass() {
		count++; //클래스 내에서는 직접 접근이 가능
	}
}

class SubClass extends SuperClass {
	public void showCount() {
		System.out.println(count);// 상위 클래스에 위치하는 클래스 변수에 접근
	}
}

class SuperSubStatic {
	public static void main(String[] args) {
		SuperClass obj1 = new SuperClass(); //count 값 1 증가
		SuperClass obj2 = new SuperClass(); //count 값 1 증가
		
		//아래 인스턴스 생성 과정에서 SuperClass 생성자 호출되므로,
		SubClass obj3 = new SubClass(); //count 값 1 증가
		obj3.showCount();
	
		}
}
```

## Ch 15. 클래스의 상속 2: Overriding
### 15-1 상속을 위한 두 클래스의 관계
* 상속의 기본 조건 'IS-A 관계'
	- 하위 클래스는 상위 클래스의 모든 특성을 지닌다.
	- 더불어, 하위 클래스는 자신만의 추가적인 특성을 더하게 됨.
	- 인생은 여행이다./노트북은 컴퓨터이다.....등 IS-A 관계
	- class Laptop extends Computer { ... }

### 15-2 메소드 오버라이딩 (재정의)
* 상위 클래스의 참조변수는 하위 클래스의 인스턴스를 참조할 수 있음.
* 참조변수의 형을 기준으로 접근 가능한 멤버를 제한하는 것은 코드를 단순하게 함.
