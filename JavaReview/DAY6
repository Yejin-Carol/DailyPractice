
# Java Review - DAY 6

## Ch 23. 컬렉션 프레임워크 1
### 23-1 컬렉션 프레임워크의 이해
* 제네릭을 공부하는 이유 중 하나: 프레임워크 활용 위한 것
* Framework: 프로그래머들이 쓸 수 있도록 잘 정의된 클래스들의 모임. -> 전부라면 라이브러리, 컬렉션 프레임워크...
* 자료구조: 데이터의 저장과 관련된 학문, 데이터의 효율적인 저장 방법을 연구하는 학문. 예) List, Stack, Queue, Tree, Hash
* 알고리즘: 저장된 데이터의 일부 또는 젠체를 대상으로 하는 각종 가공 및 처리의 방법을 연구하는 학문. 예) Bubble Sort, Quick Sort, Binary Search
* Collection Framework? 데이터의 저장 방법, 이와 관련된 알고리즘에 대한 프레임 워크. 컬렉션 프레임워크 이용하면 자료구조 몰라도 트리 기반으로 데이터 저장, 알고리즘 몰라도 이진 탐색 수행할 수 있음. 구현한 인터페이스에 따라서 컬렉션 클래스의 데이터 저장 방식이 결정됨. (구현한 인터페이스 종류 확인이 매우 중요함!)
### 23-2 List<E> 인터페이스를 구현하는 컬렉션 클래스들
* 컬렉션 인스턴스들은 인스턴스의 저장을 목적으로 함. java.util 패키지로 대부분 묶여 있음
* ArrayList<E> 클래스 
	- ArrayList<E> 배열 기반 자료구조, 배열 이용하여 인스턴스 저장
	- LinkedList<E> 리스트 기반 자료구조, 리스트를 구성하여 인스턴스 저장
	- List<E> 인터페이스를 구현하는 컬렉션 클래스들이 갖는 공통점
		- 1. 인스턴스의 저장 순서 유지
		- 2. 동일한 인스턴스의 중복 저장 허용함.

```java
package collectionclass;

import java.util.ArrayList;
import java.util.List;

class ArrayListCollection {
	public static void main(String[] args) {
		List<String> list = new ArrayList<>(); //컬렉션 인스턴스 생성
		
		//컬레션 인스턴스에 문자열 인스턴스 저장
		list.add("V");
		list.add("RM");
		list.add("Jin");
		
		//저장된 문자열 인스턴스의 참조
		for(int i = 0; i <list.size(); i++)
			System.out.print(list.get(i) + '\t');
		System.out.println();
		
		list.remove(0); //첫 번째 인스턴스 삭제
		
		//첫 번째 인스턴스 삭제 후 나머지 인스턴스들을 참조
		for(int i = 0; i <list.size(); i++)
			System.out.print(list.get(i) + '\t');
		System.out.println();
	}
}
```
*  컬렉션 인스턴스를 사용하면 배열처럼 길이를 신경 쓰지 않아도 됨. 
	- public ArrayList(int initialCapacity) -> 인자로 전달된 수의 인스턴스를 저장할 수 잇는 공간을 미리 확보
	- public ArrayList() -> 10개의 인스턴스를 저장할 수 있는 공간을 미리 확보
* LinkedList<E> 클래스
	- List<String> list = new ArrayList<>(); -> List<String> list = new LinkedList<>();
* ArrayList<E> vs. LinkedList<E>

| 비교 | ArrayList\<E> | LinkedList\<E>  |
|--|--|--|
|단점  | 1. 저장 공간 늘리는 과정에서 시간이 비교적 많이 소요됨. 2. 인스턴스의 삭제 과정에서 많은 연산이 필요 즉, 느릴 수 있음.  | 저장된 인스턴스의 참조 과정이 배열에 비해 복잡함. 즉, 느릴 수 있음 |
|장점 | 저장된 인스턴스의 참조가 빠름 | 1. 저장 공간을 늘리는 과정 간단, 2. 저장된 인스턴스의 삭제 과정이 단순함.|

* 저장된 인스턴스의 순차적 접근 방법 1: enhanced for문의 사용(for-each문)
	- 저장된 모든 인스턴스들에 순차적 접근
	- for-each문을 통한 순차적 접근의 대상이 되려면, 해당 컬렉션 클래스 다음 인터페이스 구현해야함
	- public interface Iterable\<T>
	- public interface Collections\<E> extends Iterable\<E>
```java
for(String s : list)
			System.out.print(s + '\t');
		System.out.println();
		
		list.remove(0);
		
		for(String s : list)
			System.out.print(s + '\t');
		System.out.println(); 
```
* 저장된 인스턴스의 순차적 접근 방법 2
	- Collection\<E>가 Iterator\<T>를 상속함. 
	- Iterator\<T> iterator()//반복자(Iterator) 반환
	- Iterator\<String> itr = list.iterator(); //반복자 획득, itr이 반복자 참조
	-  Iterator\<E> 메소드
		- E next() : 다음 인스턴스의 참조 값을 반환
		- boolean hasNext(): next 메소드 호출 시 참조 값 반환 가능 여부 확인
		- void remove(): next 메소드 호출을 통해 반환했던 인스터스 삭제
```java
//반복자를 이용한 순차적 참조
while(itr.hasNext()) {//next 메소드가 반환할 대상이 있다면,
	str = itr.next(); //next 메소드를 호출함...
}

//반복자를 이용한 참조 과정 중 인스턴스의 삭제
while(itr.hasNext()) {
	str = itr.next();
	if(str.equals("Box"))
		itr.remove(); //위에서 next 메소드가 반환한 인스턴스 삭제
```
* for-each문도 컴파일 과정에서 반복자를 이용하는 코드로 수정됨. 즉, 반복자에 의한 순차적 접근 진행 가능.
>for(Iterator\<String> itr = list.iterator(); itr.hasNext(); )
	System.out.print(itr.next() + '\t');

```java
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;

class LinkedListcollection {
	public static void main(String[] args) {
		List<String> list = new LinkedList<>(); //유일한 변화
		list.add("Suga");
		list.add("Jungkook");
		list.add("J-hope");
		list.add("V");
		
		Iterator<String> itr = list.iterator(); //반복자 처음 획득
		
		//반복자를 이용한 순차적 참조
		while(itr.hasNext())
			System.out.print(itr.next() + '\t');
		System.out.println();
		
		itr = list.iterator();//반복자 다시 획득
		
		//모든 "J-hope" 삭제
		String str;
		while(itr.hasNext()) {
			str = itr.next();
			if(str.equals("J-hope"))
				itr.remove();
		}
		itr = list.iterator(); //반복자 다시 획득
		
		//삭제 후 결과 확인
		while(itr.hasNext())
			System.out.print(itr.next() + '\t');
		System.out.println();
	}
}
```
* 배열보다는 컬렉션 인스턴스가 좋다: 컬렉션 변환
	- 1. 인스턴스 저장과 삭제가 편함.
	- 2. 반복자를 쓸 수 있음. (새로운 인스턴스의 추가나 삭제가 필요한 상황에서는 ArrayList\<E> 인스턴스를 생성해야함.
> class ArrayList\<E>  {
> public ArrayList(Collection<? extends E> c) {...} //생성자
> ... }


```java
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
import java.util.List;

class AsListCollection {
	public static void main(String[] args) {
		List<String> list = Arrays.asList("V", "RM", "Jin", "Suga");
		list = new ArrayList<>(list);
		
		//for문 기반의 반복자 획득과 순차적 참조
		for(Iterator<String> itr = list.iterator(); itr.hasNext();)
			System.out.print(itr.next() + '\t');
		System.out.println();
		
		//"V"를 모두 삭제하기 위한 반복문
		for(Iterator<String> itr = list.iterator(); itr.hasNext();) {
			if(itr.next().equals("V"))
				itr.remove();
		}
		for(Iterator<String> itr=list.iterator(); itr.hasNext();)
			System.out.print(itr.next() + '\t');
		System.out.println();	
	}
}
```
* 기본 자료형 데이터의 저장과 참조
```java
import java.util.Iterator;
import java.util.LinkedList;

class PrimitiveCollection {
	public static void main(String[] args) {
		LinkedList<Integer> list = new LinkedList<>();
		list.add(10); list.add(20); list.add(30); //저장 과정에서 오토 박싱 진행
		
		int n;
		for(Iterator<Integer> itr = list.iterator(); itr.hasNext();) {
			n = itr.next(); //오토 언박싱 진행
			System.out.print(n + "\t");
		}
		System.out.println();
	}
}
```
* 연결 리스트만 갖는 양방향 반복자
	- 메소드가 반환하는 반복자를 대상으로 호출할 수 있는 대표 메소드
		- E next(): 다음 인스턴스의 참조 값을 반환
		- boolean hasNext(): next 메소드 호출 시 참조 값 반환 가능 여부 확인
		- void remove(): next 메소드 호출을 통해 반환했던 인스턴스 삭제
		- E previous(): next 메소드와 기능은 같고 방향만 반대
		- boolean hasPrevious(): hasNext 메소드와 기능은 같고 방향만 반대
		- void add(E e): 인스턴스의 추가
		- void set(E e): 인스턴스의 변경

### 23-3 Set\<E> 인터페이스를 구현하는 컬렉션 클래스들 
* Set\<E> 인터페이스를 구현하는 제네릭 클래스의 특성
	- 저장 순서가 유지되지 않음
	- 데이터의 중복 저장을 허용하지 않음
```java
import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;

public class SetCollectionFeature {
	public static void main(String[] args) {
		Set<String> set = new HashSet<>();
		set.add("Jin");
		set.add("RM");
		set.add("Jungkook");
		set.add("J-hope");
		System.out.println("인스턴스 수: " + set.size());

		//반복자를 이용한 전체 출력
		for(Iterator<String> itr = set.iterator(); itr.hasNext();)
			System.out.print(itr.next() + '\t');
		System.out.println();
		
		//for-each문을 이용한 전체 출력
		for(String s : set)
			System.out.print(s + '\t');
		System.out.println();		
	}
}
```
> public boolean equals(Object obj)
> public int hasCode()

* 해쉬 알고리즘과 hashCode 메소드
	- 인스턴스가 다르면 Object 클래스의 hashCode 메소드는 다른 값을 반환함.
	- 인스턴스가 다르면Object 클래스의 equals 메소드는 false를 반환함.

* hashCode 메소드의 다양한 정의
```java
import java.util.HashSet;

class Car {
	private String model;
	private String color;

	public Car(String m, String c) {
		model = m;
		color = c;
	}
	@Override
	public String toString() {
		return model + " : " + color;
	}
	@Override
	public int hashCode() {
		return (model.hashCode() + color.hashCode()) / 2;
	}
	
	@Override
	public boolean equals(Object obj) {
		String m = ((Car)obj).model;
		String c = ((Car)obj).color;
		
		if(model.equals(m) && color.equals(c))
			return true;
		else
			return false;		
	}
}
class HowHashCode {
	public static void main(String[] args) {
		HashSet<Car> set = new HashSet<>();
		set.add(new Car("HY_MD_301", "RED"));
		set.add(new Car("HY_MD_301", "BLACK"));
		set.add(new Car("HY_MD_302", "RED"));
		set.add(new Car("HY_MD_302", "WHITE"));
		set.add(new Car("HY_MD_301", "BLACK"));
		System.out.println("인스턴스 수: "+ set.size());

		for(Car car : set)
			System.out.println(car.toString() + '\t');
	}
}
```
* TreeSet\<E> 클래스의 이해와 활용
```java
import java.util.Iterator;
import java.util.TreeSet;

class SortedTreeSet {
	public static void main(String[] args) {
		TreeSet<Integer> tree = new TreeSet<Integer>();
		tree.add(3); tree.add(1);
		tree.add(2); tree.add(4);
		System.out.println("인스턴스 수: " + tree.size());
		
		//for-each문에 의한 반복
		for(Integer n : tree)
			System.out.print(n.toString() + '\t');
		System.out.println();
		//Iterator 반복자에 의한 반복
		for(Iterator<Integer> itr = tree.iterator(); itr.hasNext();)
			System.out.print(itr.next().toString() + '\t');
		System.out.println();	
	}
}
```
- 인스턴스들의 참조 순서는 오름차순을 기준으로 함
	- public interface Comparable<T> -> 이 인터페이스에 위치한 유일한 추상 메소드 int compareTo(T o)
	- Comparable & Comparable\<T> 인터페이스 
* 인스턴스의 비교 기준을 정의하는 Comparable\<T> 인터페이스의 구현 기준
	- int compareTo(T o) 
	- 인자로 전달된 o가 작다면 양의 정수 반환
	- 인자로 전달된 o가 크다면 음의 정수 반환
	- 인자로 전달될 o가 같다면 0을 반환
* compareTo 메소드가 호출되었을 때
	- my.compareTo(your); 
