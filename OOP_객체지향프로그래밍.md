# 객체지향 프로그래밍 (Object Oriented Programming, OOP)

## Basic
1. 객체지향의 구성
- 클래스(Class)
- 객체(Object)
- 속성(Attribute)
- 메소드(Method)
- 메시지(Message)

2. 객체지향의 기법
- 캡슐화(Encapsulation)
- 추상화(Abstraction)
- 다형성(Polymorphism)
- 정보은닉(Information Hiding)
- 상속성(Inheritance)

To be updated...





## Overriding/Overloading

1. 오버라이딩 (overriding)

- 메소드 재정의로 추상, 일반 클래스 모두 사용 가능

  ![image](https://user-images.githubusercontent.com/81130006/123496723-70a70600-d664-11eb-8c30-e1da64a67bb4.png)


2. 오버로딩 (overloading)

- 한 클래스에 동일한 메서드가 중복 정의 
  
   ![image](https://user-images.githubusercontent.com/81130006/123496463-23766480-d663-11eb-9393-26a0b27ff21f.png)

- 상속시, 추상(abstract) 클래스, 추상 메소드로 구현 (다형성 polymorphism)

  ![image](https://user-images.githubusercontent.com/81130006/123496588-c0390200-d663-11eb-90d0-d3a3d04f0d0d.png)

    (모든 그림 출처: 네이버 백과사전)
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
