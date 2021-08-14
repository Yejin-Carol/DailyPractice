
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


```java
import java.util.TreeSet;

class Person implements Comparable<Person> {
	private String name;
	private int age;
	
	public Person(String name, int age) {
		this.name = name;
		this.age = age;
	}
	
	@Override
	public String toString() { return name + " : " + age;}
	
	// 인자로 전달된 인스턴스의 나이가 더 많으면 음수로 반환되는 오름차순 정렬 순서상 뒤쪽에 위치함. 반대는 return p.age-this.age;
	@Override
	public int compareTo(Person p) {
		return this.age - p.age;
	}	
}

class ComparablePerson {

	public static void main(String[] args) {
		TreeSet<Person> tree = new TreeSet<>();
		tree.add(new Person("V", 25));
		tree.add(new Person("Jin", 28));
		tree.add(new Person("Jungkook", 23));
		
		for(Person p : tree)
			System.out.println(p);
	}

}
```
* Comparator<T> 인터페이스를 기반으로 TreeeSet<E>의 정렬 기준 제시하기
```java
class PersonCompartor implements Comparator<Person> {
	//int compare(T o1, To2)의 구현을 통해 정렬 기준 결정함
	public int compare(Person p1, Person p2) {
			return p2.age - p1.age; //나이가 많은 사람 세우는 연산
	}
}

class ComparatorPerson {
	public static void main(String[] args) {
		//pubclic TreeSet(Comparator<? super E > comparator)
		TreeSet<Person> tree = new TreeSet<>(new PersonCompartor());
		tree.add(new Person("V", 25));
		tree.add(new Person("Jin", 28));
		tree.add(new Person("Jungkook", 23));
		
		for(Person p : tree)
			System.out.println(p);

	}

}
```
int compare(T o1, T o2)
	- o1이 o2보다 크면 양의 정수 반환
	- o1이 o2보다 작으면 음의 정수 반환
	- o1과 o2가 같다면 0반환

* 문자열 길이 순 비고
```
class StringComparator implements Comparator<String> {
		public int compare(String s1, String s2) {
				return s1.length() - s2.length();
				}
	}
```	

*  중복된 인스턴스 삭제
	- List\<E>를 구현하는 컬렉션 클래스는 인스턴스의 중복 삽입 허용함.
```java
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;

public class ConvertCollection {

	public static void main(String[] args) {
		List<String> lst = Arrays.asList("Bts", "Army", "Bts", "Army");
		ArrayList<String> list = new ArrayList<>(lst);
		
		for(String s : list)
			System.out.print(s.toString()+ '\t');
		System.out.println();

		//중복된 인스턴스를 걸너 내기 위한 작업
		//다른 컬렉션 인스턴스로부터 HashSet<E> 인스턴스 생성
		HashSet<String> set = new HashSet<>(list);
		//원래대로 ArrayList<String> 인스턴스로 저장물 옮김.
		list = new ArrayList<>(set);
		
		for(String s : list)
			System.out.print(s.toString() + '\t');
		System.out.println();
	}
}
```

### 23-4 Queue/<E> 인터페이스를 구현하는 컬렉션 클래스들
* Stack & Queue
	- Stack: LIFO (Last In First Out), 먼저 저장된 데이터 마지막에 빠져나감
	- Queue: FIFO (First In First Out), 먼저 저장된 데이터 먼저 빠져나감.
* Queue/<E> 인터페이스와 큐(Queue) 구현
	- 큐 자료구조를 위한 세 가지 메소드
		- boolean add(E e) 넣기
		- E remove() 꺼내기: 인스턴스 참조 값을 반환하면서 해당 인스턴스를 저장소에서 삭제하는 메소드
		- E element() 확인하기: 인스턴스의 참조 값을 반환하지만 삭제하지 않음. 무엇이 들어 있는지 확인하는 메소드
	- 위의 메소드는 꺼낼 인스턴스가 없을 때 혹은 저장 공간이 부족할 때 예외를 발생시킨다. 다음 메소드는 특정값 (null 혹은 flase) 반환함.
		- boolean offer(E e): 넣기, 넣을 공간 부족시 false 반환
		- E poll(): 꺼내기, 꺼낼 대상 없으면 null 반환
		- E peek(): 확인하기, 확인할 대상 없으면 null 반환
```java
package collectionclass;

import java.util.LinkedList;
import java.util.Queue;

class LinkedListQueue {
	public static void main(String[] args) {
		Queue<String> que = new LinkedList<>(); // LinkedList<E> 인스턴스 생성
		que.offer("BTS");
		que.offer("Army");
		que.offer("PTD");
		
		//무엇이 다음에 나올지 확인
		System.out.println("next: " + que.peek());
		//첫 번째, 두 번째 인스턴스 꺼내기
		System.out.println(que.poll());
		System.out.println(que.poll());
		//무엇이 다음에 나올지 확인
		System.out.println("next: " + que.peek());
		//마지막 인스턴스 꺼내기
		System.out.println(que.poll());
	}

}
```
* 스택(Stack) 구현
	- public class Stack\<E> extends Vector\<E>: Stack\<E>는 동기화된 클래스로 멀티 쓰레드에 안전하지만, 성능의 저하가 발생함. 
	- 대신에 public interface Deque\<E> extends Queue\<E> 사용: 덱은 외형 구조가 큐와 유사함. 한쪽 방향으로만 넣고 꺼내는 큐와 달리 덱은 양쪽 끝에서 넣고 빼는 것이 가능한 자료구조. 덱을 스택처럼 사용하는 것 가능 (큐로도 가능함)
	- Deque\<E>의 대표 메소드
		```
		- 앞으로 넣고, 꺼내고, 확인하기
			void add First(E e): 넣기
			E removeFirst(): 꺼내기
			E getFirst(): 확인하기
		- 뒤로 넣고, 꺼내고, 확인하기
			void addLast(E e): 넣기
			E removeLast(): 꺼내기
			E getLast(): 확인하기
		```
	- Deque\<E> 공간 부족시 특정값 반환
		```
		- 앞으로 넣고, 꺼내고, 확인하기
				boolean offerFirst(E e): 넣기, 공간 부족시 false 반환
				E pollFirst(): 꺼내기, 꺼낼 대상 없으면 null 반환
				E peekFirst(): 확인하기, 확인할 대상 없으면 null반환
		- 뒤로 넣고, 꺼내고, 확인하기
				boolean offerLast(E e): 넣기, 공간이 부족하면 false 반환
				E pollLast(): 꺼내기, 꺼낼 대상 없으면 null 반환
				E peekLast(): 확인하기, 확인할 대상 없으면 null반환
		- 스택 필요시 
				offerFirst & pollFirst: 앞으로 넣고 앞에서 꺼내기
				offerLast & pollLast: 뒤로 넣고 뒤에서 꺼내기
		```
	- Deque\<E>을 구현하는 ArrayDeque\<E> 클래스의 인스턴스를 스택처럼 활용

```java
import java.util.ArrayDeque;
import java.util.Deque;

public class ArrayDequeCollection {
	public static void main(String[] args) {
		//배열을 기반으로 하는 덱의 구성
		Deque<String> deq = new ArrayDeque<>();		
		//Deque<String> deq = new LinkedList<>(); 리스트 기반으로 하는 덱으로 구성 대신할 수 있음. 이유는 이 클래스가 Deque<E>, List<E>, Queue<E> 세가지 인터페이스 모두 구현하기 때문임.
		
		// 앞으로 넣고
		deq.offerFirst("1. BTS");
		deq.offerFirst("2. ARMY");
		deq.offerFirst("3. PTD");
		
		// 앞에서 꺼내기
		System.out.println(deq.pollFirst());
		System.out.println(deq.pollFirst());
		System.out.println(deq.pollFirst());
	}
}
```
	- 스택에 넣기: push
	- 스택에서 꺼내기: pop
	- Deque과 Stack의 혼란을 줄이기 위해 스택 필요시 별도의 클래스 정의필요.
```java
import java.util.ArrayDeque;
import java.util.Deque;

interface DIStack<E>{ //정의한 인터페이스
	public boolean push(E item);
	public E pop();
}

class DCStack<E> implements DIStack<E> { //정의한 클래스
	private Deque<E> deq;

	public DCStack(Deque<E> d) {
		deq = d;
	}
	public boolean push(E item) {
		return deq.offerFirst(item);
	}
	public E pop() {
		return deq.pollFirst();
	}
}

class DefinedStack {
	public static void main(String[] args) {
		//리스트 기반의 스택 생성됨
		DIStack<String> stk = new DCStack<>(new ArrayDeque<String>());
		
		//PUSH 연산
		stk.push("1. BTS");
		stk.push("2. ARMY");
		stk.push("3. PTD");
		
		//POP 연산
		System.out.println(stk.pop());
		System.out.println(stk.pop());
		System.out.println(stk.pop());
	}
}
```
### 23-5 Map<K, V> 인터페이스를 구현하는 컬렉션 클래스들
* Key-Value 방식의 데이터 저장과 HashMap<K, V> 클래스
	- Collection\<E>를 구현하는 클래스가 Value를 저장하는 구조라면 Map\<K, V>를 구현하는 클래스는 Value를 저장할 때, Key를 함께 저장하는 구조임. 따라서 Key는 중복될 수 없음. 
	- "Key는 지표이므로 중복될 수 없다. 하지만 Key만 다르면 Value는 중복되어도 상관없음"
	- 대표 클래스 HashMap\<K, V>와 TreeMap\<K, V>이 있음. 이 둘의 차이점은 트리 자료구조를 기반으로 구현된 TreeMap<K, V>은 정렬 상태를 유지한다 것.
	- HashMap\<K, V> 사용
```java
import java.util.HashMap;
public class HashMapCollection {
	public static void main(String[] args) {
		//Key도 Value도 인스턴스이어야 함.		
		HashMap<Integer, String> map = new HashMap<>();

		//Key-Value 기반 데이터 저장
		map.put(25, "Jimin");
		map.put(28, "Suga");
		map.put(26, "RM");
		
		//데이터 탐색
		System.out.println("26살: " + map.get(26));
		System.out.println("28살: " + map.get(28));
		System.out.println("25살: " + map.get(25));
		System.out.println();
		//데이터 삭제
		map.remove(28);
		
		//데이터 삭제 확인
		System.out.println("28살: " + map.get(28));
	}
}
```
* HashMap<K, V>의 순차적 접근 방법
	- 클래스는 Interable\<T> 인터페이스 구현하지 않으니 for-each 혹은 '반복자'를 얻어서 순차적 접근 진행 안됨. 
	- public Set\<K> keySet() : 이 메소드는 Set\<E>를 구현하는 컬렌션 인스턴스 생성하고, 모든 Key를 담아서 반환함. Key를 따로 모으고, 이를 통한 순차적 접근을 진행할 수 있음.
```java
import java.util.HashMap;
import java.util.Iterator;
import java.util.Set;

class HashMapIteration {
	public static void main(String[] args) {
		HashMap<Integer, String> map =new HashMap<>();
		map.put(25, "Jimin");
		map.put(28, "Suga");
		map.put(26, "RM");
		
		//Key만 담고 있는 컬렉션 인스턴스 생성
		Set<Integer> ks = map.keySet();
	
		//전체 Key 출력 (for-each문 기반)
		for(Integer n: ks)
			System.out.println(n.toString() + '\t');
		System.out.println();
		
		//전체 Value 출력 (for-each문 기반)
		for(Integer n: ks)
			System.out.print(map.get(n).toString() + '\t');
		System.out.println();
		
		//전체 Value 출력 (반복자 기반)
		for(Iterator<Integer> itr = ks.iterator(); itr.hasNext(); )
			System.out.print(map.get(itr.next()) + '\t');
		Sysem.out.println();
	}
}
```
* TreeMap<K, V>의 순차적 접근 방법: 오름차순 정렬 (HashMap도 그렇게 됐음;;;;)
```java
class TreeMapIteration {
	public static void main(String[] args) {
		TreeMap<Integer, String> map =new TreeMap<>();
```
* Comparator<T> 인터페이스를 기반으로 내림차순 정렬 (Integr가 key)
```java
class AgeComparator implements Comparator<Integer> {
	public int compare(Integer n1, Integer n2) {
		return n2.intValue() - n1.intValue();
	}
}
class TreeMapIteration {
	public static void main(String[] args) {
		TreeMap<Integer, String> map =new TreeMap<>(new AgeCompar
ator());
```
## Ch 24. 컬렉션 프레임워크 2
### 24-1 컬렉션 기반 알고리즘 (거의 제네릭 복습)
* 정렬
	- List<E>를 구현한 컬렉션 클래스들은 저장된 인스턴스를 정렬된 상태로 유지하지 않음. 대신에 정렬시 다음 메소드 사용
	- public static \<T extends Comparable\<T>> void sort(List\<T> list)
	- Collections 클래스에 정의되어 있는 제네릭 메소드로 인자로 List\<T>의 인스턴스 모두 전달 가능하나, 단 T는 Comparable\<T> 인터페이스 구현한 상태여야 함.
	- public final class String extends Object implements Comparable\<String>: List\<String> 인스턴스는 sort 메소드의 인자로 전달 될 수 있음.
```java
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;

public class SortCollections {
	public static void main(String[] args) {
		List<String> list = Arrays.asList("BTS", "ARMY", "PTD", "Butter");
		list = new ArrayList<>(list);
		
		//정렬 이전 출력
		for(Iterator<String> itr = list.iterator(); itr.hasNext(); )
			System.out.print(itr.next() + '\t');
		System.out.println();
		
		//정렬
		Collections.sort(list);
		
		//정렬 이후 출력
		for(Iterator<String> itr = list.iterator(); itr.hasNext(); )
			System.out.print(itr.next() + '\t');
		Systemout.println();
	}
}
```
* \<T extends Comparable\<T>> 아니고 \<T extends Comparable\<? superT>> 
	- public static \<T extends Comparable\<? super T>> void sort(List\<T> list)

```java
class Car implements Comparable<Car> {
	protected int disp; //배기량
	
	public Car(int d) { disp = d; } 
	
	@Override
	public String toString() {
		return "cc: " + disp;
	}
	@Override
	public int compareTo(Car o) {
		return disp - o.disp;
	}
}

class ECar extends Car { //전기 자동차를 표현한 클래스
	private int battery; //배터리
	
	public ECar(int d, int b) {
		super(d);
		battery = b;
	}
	
	@Override
	public String toString() {
		return "cc: " + disp + ", b
a: " + battery;
	}	
}

class ECarSortCollections {
	public static void main(String[] args) {
		List<ECar> list = new ArrayList<>();
		list.add(new ECar(1200, 99));
		list.add(new ECar(3000, 55));
		list.add(new ECar(1800, 87));
		Collections.sort(list); //정렬
		
		for(Iterator<ECar> itr = list.iterator(); itr.hasNext(); )//출력
			System.out.println(itr.next().toString() + '\t');
	}
}
```

* 정렬: Comparable<T> 기반
	- public static \<T> void sort(List\<T> list, Comparator\<? super T> c) 
	- 매개변수 c를 대상으로 T형 인스턴스를 넣는(전달하는) 메소드 호출만 ok"
```java
package collectionclass;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Iterator;
import java.util.List;

class Car {
	protected int disp;
	public Car(int d) { disp = d; }
	
	@Override
	public String toString() { return "cc: " + disp; }
 }

// Car의 정렬을 위한 클래스
class CarComp implements Comparator<Car> {
	@Override
	public int compare(Car o1, Car o2) { return o1.disp - o2.disp; }
}

class ECar extends Car { //전기 자동차를 표현한 클래스
	private int battery; //배터리
	
	public ECar(int d, int b) {
		super(d);
		battery = b;
	}
	
	@Override
	public String toString() { return "cc: " + disp + ", ba: " + battery; }	
}

class CarComparator {
	public static void main(String[] args) {
		List<Car> clist = new ArrayList<>();
		clist.add(new Car(1200));
		clist.add(new Car(3000));
		clist.add(new Car(1800));
		
		List<ECar> elist = new ArrayList<>();
		elist.add(new ECar(1200, 55));
		elist.add(new ECar(3000, 77));
		elist.add(new ECar(1800, 66));
		
		CarComp comp = new CarComp();
		
		//각각 정렬, 가능한 이유: Comparator<T>가 아닌 Comparator<? super T>이기에 가능함.
		Collections.sort(clist, comp);
		Collections.sort(elist, comp);
		
		for(Iterator<Car> itr = clist.iterator(); itr.hasNext(); )//출력
			System.out.println(itr.next().toString() + '\t');
		System.out.println();
		
		for(Iterator<ECar> itr = elist.iterator(); itr.hasNext(); )//출력
			System.out.println(itr.next(
).toString() + '\t');
		System.out.println();	
	}		
}
```

* 찾기
	- public static \<T> int binarySearch(List\<? extends Comparable\<? super T>> list, T key)
	- list에서 key를 찾아 그 인덱스 값 반환, 못 찾으면 음의 정수 반환
	- 첫 번째 인자로 List\<E> 인스턴스는 무엇이든 올 수 있으나 단, 이때 E는 Comparable\<T>를 구현해야함.
```java
class StringBinarySearch {
	public static void main(String[] args) {
		List<String> list = new ArrayList<>();
		list.add("BTS");
		list.add("ARMY");
		list.add("PDT");
		Collections.sort(list); //정렬
		int idx = Collections.binarySearch(list, "BTS"); //탐색
		System.out.println(list.get(idx)); //탐색의 결과 
출력
	}
}
```
* 찾기: Comparator<T> 기반
```java
class StrComp implements Comparator<String> {
	@Override
	public int compare(String s1, String s2) {
		return s1.compareToIgnoreCase(s2); // 대문자, 소문자 구분없이 비교, 두 문자열이 같을 때 0을 반환
	}
}
class StringComparator {
	public static void main(String[] args) {
		List<String> list = new ArrayList<>();
		list.add("BTS");
		list.add("Army");
		list.add("PTD");
		list.add("Butter");
		
		StrComp cmp = new StrComp(); //정렬과 탐색의 기준
		Collections.sort(list, cmp); //정렬
		int idx = Collections.binarySearch(list, "ARMY", cmp);//탐색
		System.out.println(list.get(idx)); //탐색 결과 출
	}
}
```
* 복사하기
```java
class CopyList {
	public static void main(String[] args) {
		List<String> src = Arrays.asList("Army", "Bts", "PTD", "Butter");
		//복사본 만들기
		List<String> dest = new ArrayList<>(src);
		//정렬하여 그 결과를 출력
		Collections.sort(dest);
		System.out.println(dest);
		//dest에 저장된 내용을 src에 저장된 내용으로 덮어씀
		Collections.copy(dest, src);
		//되돌림 확인
		System.out.println(dest); //컬렉션 인스턴스에 저장된 내용 전부 출
력
	}

}
```

