# 객체지향 프로그래밍 (Object Oriented Programming, OOP)

## Basic
1. 객체지향의 구성
- 클래스(Class): 객체의 타입 정의하고 객체 생성의 틀 의미, 같은 종류의 객체들의 집합에 공통 속성과 행위를 정의하는 OOP의 기본적인 User Define Type
- 객체(Object): 개체(entity), 속성(attribute), 메소드(method)로 구성된 ***클래스의 instance*** 의미
- 속성(Attribute): 객체의 데이터
- 메소드(Method): 객체의 행위(함수, 메소드), 클래스로부터 생성도니 객체를 사용하는 방법임
- 메시지(Message): 객체 간의 통신

``` java class Human { //클래스 선언
	public static int UNKNOWN = 0;// 클래스 변수, 클래스 이름으로 접근
	public static int MALE = 1;// "
	public static int FEMALE = 2;// "

	public String name; // 멤버 변수, 객체 생성 후 접근 가능 (public)
	private int age; // 멤버 변수, 접근 불가 (private)
	private int gender; // "

	public Human(String name, int age, int gender) { // 생성자.
		this.name = name;
		this.age = age;
		setGender(gender);
	}

	public int setGender(int gender) { // 멤버 함수. 객체 생성 후 접근 가능(public)
		if (gender == MALE || gender == FEMALE) {
			return gender;
		} else {
			return UNKNOWN;
		}
	}
}
```
```java public class OOP {
	
	public static void main(String[] args) {

		//생성자를 통해 클래스를 객체로 만듬
		Human human = new Human("홍길동", 17, Human.FEMALE);
		human.setGender(Human.MALE);//객체 통한 멤버함수 접근
		
		//객체를 통한 멤버변수 접근
		System.out.println("name=" + human.name);
		//System.out.println("age=" + human.age); private으로 접근 불가
		
		//클래스 변수는 클래스 이름으로 접근
		System.out.println("MALE=" + Human.MALE);
		System.out.println("FEMALE = " + Human.FEMALE);
	}
}
```

2. 객체지향의 기법
- 캡슐화(Encapsulation)
  - 속성(데이터)과 메소드(연산)을 하나로 묶어서 객체로 구성, 가독성(Readability) 향상으로 유지보수 용이, 
  - 재사용성이 높은 S/W 개발 가능, 정보은닉으로 내부자료 일관성 유지, 객체 간 인터페이스 이용, 종속성 최소화
  - 하기 코드에서 name, age, birthYear 멤버 변수들을 private으로 선언 후, 생성자와 getter메소드로 구성함. 
  - 즉, 속성과 함수를 하나의 클래스로 구현하는 캡슐화
```java import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;

public class Encapsulation {
	private String name; // 정보은닉
	private int age; // 정보은닉, 무결성(setAge()로 자동설정)
	private int birthYear; // 정보은닉

	public Encapsulation(String name, int birthYear) { // 생성자
		this.name = name;
		this.birthYear = birthYear;
		setAge();
	}

	public void setAge() { // 멤버함수. 객체 생성 후 접근 가능(public)
		Date date = new Date();
		Calendar calendar = new GregorianCalendar();
		calendar.setTime(date);
		int year = calendar.get(Calendar.YEAR);
		age = year - birthYear; // 나이 자동 설정
	}

	public String getName() { // 외부 공개
		return name;
	}

	public int getAge() { // 외부 공개
		return age;
	}

	public static void main(String[] args) {
		Encapsulation e = new Encapsulation("BTS", 2010);
		String name = e.getName();
		int age = e.getAge();
		System.out.println("name=" + name + ", age=" +age);
	}
}
```
- 정보은닉(Information Hiding)
  - 캡슐화된 항목을 다른 객체로 부터 숨기며 메세지 전달에 의해 다른 클래스 내의 메소드가 호출됨
  - 정보은닉 범위에는 private(동일 클래스에만)/package(동일 클래스, 패키지만 접근 가능)/protected(동일 클래스, 패키지 상속관계에서만 접근 가능)/public이 있음
  - 상기 코드에서 멤버 변수 name, age, birthYear는 private으로 선언되어 외부에서 접근 불가, 오로지 생성자를 통해 세팅 가능, public getter 함수 사용하여 가져올 수 있음
    
- 추상화(Abstraction)
  - 공통 성질을 추출하여 Super Class 구성, 객체 중심의 안정된 모델 구축, 현실 세계를 자연스럽게 표현, 분석의 초점이 명확해짐
  - 실체에서 공통되는 속성이나 관심있는 부분만 추출하여 모델링 하는 개념
  - 하기 코드에서 hp, mp 등의 공통 속성이 있고 이동과 같은 공격, 이동과 같은 공통 동작 표현
``` java public class GameCharacter {
  int hp;
	int mp;
		public GameCharacter() {
		this.hp = 100;
		this.mp = 100;
		}
	
	public void attack() {
		System.out.println("공격합니다.");
	}
	
	public void move() {
		System.out.println("이동합니다.");
	}
	
	public static void main(String[] args) {
	  GameCharacter game = new GameCharacter();
	  game.attack();
	  game.move();
	}
}
```
- 상속성(Inheritance)
```java public class Human {
		protected int hp;
		public Human() {
			hp = 100;
		}
		public void mvoe() {
			System.out.println("이동");
		}
	}
	
	public interface Heal {
		void fillEnergy(Human human);
	}
	
	public class Soldier extends Human {
		public void attack() { //공격
			System.out.println("공격");
		}
	}
	
	public class Medic extends Human implements Heal {
		private int mp;
		public Medic() {
			super();//mp 초기화
			this.mp = 10;
		}
			
	public void fillEnergy(Human human) {
		human.hp = 100;
	}
```

- 다형성(Polymorphism)
  - 동일한 이름의 여러 오퍼레이션(메소드)이 각 클래스마다 다른 사양으로 정의될 수 있다는 개념
  - 1) 오버로딩 (overloading): 한 클래스에 동일한 메서드가 중복 정의, 하기 코드에서 동일한 sum 함수 호출했지만, parameter로 넘긴 값의 데이터 타입에 따라 다른 sum 함수가 호출됨.
   - ![image](https://user-images.githubusercontent.com/81130006/123496463-23766480-d663-11eb-9393-26a0b27ff21f.png)
      
```java public class OverLoading {
	public int sum(int a, int b) {
		System.out.println("int Sum이 호출됨");
		return a + b;
	}
	
	public double sum(double a, double b) {
		System.out.println("double Sum이 호출됨");
		return a + b;
	}
	
	public String sum(String e, String f) {
		System.out.println("String Sum이 호출됨");
		return e + f;
	}
		
	public static void main(String[] args) {
		OverLoading overLoading = new OverLoading();
		
		int a = 10, b = 10;
		double c = 100.1, d = 200.1;
		String e = "abc", f= "def";
		
		overLoading.sum(a, b);
		overLoading.sum(c, d);
		overLoading.sum(e, f);

	}

}
```

   - 2) 오버라이딩 (overriding)
   - 메소드 재정의로 추상, 일반 클래스 모두 사용 가능 , 슈퍼클래스 타입으로 하위 클래스에서 오버라이딩 한 메소드에 접근 할 수 있는 것이 큰 장점! 
   - 오버라이딩 객체지향 설계의 OCP (Open Close Principle), LSP(Liskov Substitution Principle), DIP (Dependency Inversion Principle) 구현하기 위한 필수 요소이며, 다형성의 핵심. 다양한 디자인 패턴에 사용됨. 
   - ![image](https://user-images.githubusercontent.com/81130006/123496723-70a70600-d664-11eb-8c30-e1da64a67bb4.png) 
```java abstract void draw();
}

class Circle extends Shape {
	void draw() {
		System.out.println("Circle의 draw");
	}
}

class Rect extends Shape {
	void draw() {
		System.out.println("Rect의 draw");
	}
}
```
  - 상속시, 추상(abstract) 클래스, 추상 메소드로 구현 (다형성 polymorphism)
  - ![image](https://user-images.githubusercontent.com/81130006/123496588-c0390200-d663-11eb-90d0-d3a3d04f0d0d.png)

*참고: 기사패스 정보처리기사 바이블 & 1100제의 개념 및 예제, (그림 출처: 네이버 백과사전)



  
-----------------------------------------------------------------------------------------------------------------
## Design Patterns
(교재: Head First Design Patterns 참고)

### 디자인 원칙
1. 애플리케이션에서 달라지는 부분을 찾아내고, 달라지지 않는 부분으로 분리시킴

   : 한 클래스내 여러 메소드의 오버리딩(재정의)가 필요한 경우 달라지는 부분이 
     나머지 코드에 영향 주지 않게 "캡슐화". 즉, 바뀌는 부분만 캡슐화!
   
2. 구현이 아닌 인터페이스에 맞춰 프로그래밍

   : 특정 행위 인터페이스 구현, 별도의 클래스 (예- Behavior)내에 구체적인
     행위를 서브클래스 즉, 각 인터페이스로 구성
 
- 추상클래스(Animal), 구상클래스(Dog, Cat) 있을시
```java 
Dog d = new Dog();
d.bark();
```
- 인터페이스/상위 형식에 맞춰 프로그래밍
```java 
Animal animal = new Dog();
animal.makeSound();
```
- 구체적인 객체 실행시 대입
```java 
a = getAnimal();
a.makeSound();
```






- 상위 형식의 인스턴스를 만드는 과정
```java 
a = getAnimal();
a.makeSound();
```
