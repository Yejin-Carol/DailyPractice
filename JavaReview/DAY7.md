# Java Review - DAY 7

## Ch27. 람다 표현식
### 27-1 람다와 함수형 인터페이스
* 인스턴스보다 기능 하나가 필요한 상황을 위한 람다
	- 기능 하나를 정의해서 전달해야 하는 상황
```java
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

class SLenComp implements Comparator<String> {
	@Override
	public int compare(String s1, String s2) {
		return s1.length() - s2.length();
	}
}

class SLenComparator {
	public static void main(String[] args) {
		List<String> list = new ArrayList<>();
		list.add("Butter");
		list.add("BTS");
		list.add("ARMY");
		list.add("PTD");
				
		Collections.sort(list,new SLenComp()); //정렬
		
		for(String s : list)
			System.out.println(s);
	}
}
```
* 매개변수가 있고 반환하지 않는 람다식
```java
interface Printable {
	void print(String s); //매개변수 하나, 반환형 void
}

class OneParamNoReturn {
	public static void main(String[] args) {
		Printable p;
		p = (String s) -> { System.out.println(s); };//줄임 없는 표현
		p.print("Lambda exp one.");

		p = (String s) -> System.out.println(s);//중괄호 생략
		p.print("Lambda exp two.");
		
		p = (s) -> System.out.println(s);//매개변수 형 생략
		p.print("Lambda exp three.");
		
		p = s -> System.out.println(s);//매개변수 소괄호 생략
		p.print("Lambda exp four.");	
	}
}
```
```java
interface Calculate {
	void cal(int a, int b); //매개변수 둘, 반환형 void
}

class TwoParamNoReturn {
	public static void main(String[] args) {
		Calculate c;
		c = (a, b) -> System.out.println(a + b);
		c.cal(4, 3);// 이번엔 덧셈이 진행
		
		c = (a,b) -> System.out.println(a - b);
		c.cal(4, 3);// 이번엔 뺄셈이 진행
		
		c = (a,b) -> System.out.println(a * b);
		c.cal(4, 3);// 이번엔 곱셈이 진행
	}
}
```
* 매개변수가 있고 반환하는 람다식
```java
interface Calculate {
	int cal(int a, int b); //값을 반환하는 추상 메소드
}

class TwoParamAndReturn {
	public static void main(String[] args) {
		Calculate c;
		c = (a, b) -> { return a + b; };
		System.out.println(c.cal(4, 3));

		c = (a, b) -> a + b;
		System.out.println(c.cal(4, 3));
	}
}
```
```java
interface HowLong {
	int len(String s); //값을 반환하는 메소드
}

class OneParamAndReturn {
	public static void main(String[] args) {
			HowLong h1 = s -> s.length();
			System.out.println(h1.len("I am so happy"));
	}
}
```
* 매개변수가 없는 람다식
```java
interface Generator {
	int rand(); //매개변수 없는 메소드
	}

class NoParamAndReturn {
	public static void main(String[] args) {
		Generator gen = () -> {
			Random rand = new Random();
			return rand.nextInt(50);
		};
			System.out.println(gen.rand());
	}
}
```
* 함수형 인터페이스 (Functional Interfaces)와 어노테이션
* 람다식과 제네릭
```java
interface Calculate <T> { //제네릭 기반의 함수형 인터페이스
	T cal(T a, T b);
}

class LambdaGeneric {
	public static void main(String[] args) {
		Calculate<Integer> ci = (a, b) -> a + b;
		System.out.println(ci.cal(4, 3));

		Calculate<Double> cd = (a, b) -> a + b;
		System.out.println(cd.cal(4.32, 3.45));
	}
}
```
### 27-2 정의되어 있는 함수형 인터페이스
* 미리 정의되어 있는 함수형 인터페이스
*  Predicate\<T>를 구체화하고 다양화 한 인터페이스들
* Supplier\<T> 
	- IntSupplier  				int getAsInt()
	- LongSupplier 			long getAsLong()
	- DoubleSupplier		double getAsDouble()
	- BooleanSupplier		boolean getAsBoolean()
* Consumer\<T>
	- void accept(T t);//전달된 인자 기반으로 '반환' 이외의 다른 결과를 보일 때 
* Function\<T, R>
```java
import java.util.function.Function;

public class FunctionDemo {
	public static void main(String[] args) {
		Function<String, Integer> f = s -> s.length();
		System.out.println(f.apply("BTS"));
		System.out.println(f.apply("ARMY"));
	}
}
```
```java
public class FunctionDemo {
	public static void main(String[] args) {
		Function<Double, Double> cti = d -> d*0.393701;
		Function<Double, Double> itc = d -> d*2.54;
		System.out.println("1cm = " + cti.apply(1.0) + "inch"); //cm -> inch
		System.out.println("1inch = " + itc.apply(1.0) + "cm");//inch -> cm
	}
}
```
* Function\<T, R>을 구체화하고 다양화한 인터페이스
	- IntToDoubleFunction: double applyAsDouble(int value)
	- DoubleToIntFunction: int applyAsInt(double value)
	- IntUnaryOperator: int applyAsInt(int operand)
	- DoubleUnaryOperator: double applyAsDouble(double operand)
	- BiFuction\<T, U, T>: R apply(T t, U u)
	- IntFunction\<R>: R apply(int value)
	- DoubleFunction\<R>: R apply(double value)
	- ToIntFunction\<T>: int applyAsInt(T value)
	- ToDoubleFunction\<T>: double applyAsDouble(T value)
	- ToIntBiFunction\<T, U>: int applyAsInt(T t, U u)
	- ToDoubleBiFunction\<T, U>:double applyAsDouble(T t, U u)

* removeIf 메소드를 사용해 보자
```java
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.function.Predicate;

public class RemoveIfDemo {
	public static void main(String[] args) {
		List<Integer> ls1 = Arrays.asList(1, -2, 3, -4, 5);
		ls1 = new ArrayList<>(ls1);
		
		List<Double> ls2 = Arrays.asList(-1.1, 2.2, 3.3, -4.4, 5.5);
		ls2 = new ArrayList<>(ls2);
		
		Predicate<Number> p = n -> n.doubleValue() < 0.0; //삭제의 조건
		ls1.removeIf(p);//List<Integer> 인스턴스에 전달
		ls2.removeIf(p); //List<Double> 인스턴스에 전달
		
		System.out.println(ls1);
		System.out.println(ls2);		
	}
}
```
## Ch 28. 메소드 참조와 Optional
### 28-1 메소드 참조 (Method Reference)
* 메소드 정의는 람다식 대신할 수 있음
* 메소드 참조
	- static 메소드 참조
```java
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.function.Consumer;

class ArrangeList {
	public static void main(String[] args) {
		List<Integer> ls = Arrays.asList(1, 3, 5, 7, 9);
		ls = new ArrayList<>(ls);
		
		Consumer<List<Integer>> c = l -> Collections.reverse(l);//람다식
		c.accept(ls); //순서 뒤집기 		System.out.println(ls); //출력
	}
}
// Consumer<T> void accept(T t)
```
accept 메소드 호출 시 전달되는 인자를 reverse 메소드를 호출하면서 그대로 전달함 (람다식 생략 가능) 

Consumer<List<Integer>> c = Collections::reverse;//메소드 참조

*	- 참조변수를 통한 인스턴스 메소드 참조
		- 인스턴스 메소드의 참조 1: 인스턴스가 존재하는 상황에서 참조
```java
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.function.Consumer;

class JustSort {
	public void sort(List<?> lst) { //인스턴트 메소드
		Collections.reverse(lst);		
	}
}

class ArrangeList3 {
	public static void main(String[] args) {
		List<Integer> ls = Arrays.asList(1,3,5,7,9);
		ls = new ArrayList<>(ls);
		JustSort js = new JustSort();
		
		Consumer<List<Integer>> c = e -> js.sort(e); //람다식 기반(람다식에서 같은 지역 내에 선언된 참조변수 js에 접근
		c.accept(ls);
		System.out.println(ls);
	}
}
```
Consumer<List<Integer>> c = js::sort; //메소드 기반
ReferenceName::instanceMethodName 수정!
```java
public class forEachDemo {
	public static void main(String[] args) {
		List<String> ls = Arrays.asList("BTS", "ARMY");
		ls.forEach(s -> System.out.println(s)); //람다식 기반
		ls.forEach(System.out::println); //메소드 참조 기반
	}
}	
```
같은 결과값
*	- 	- 인스턴스 메소드의 참조 2: 인스턴스 없이 인스턴스 메소드 참조
```java
import java.util.function.ToIntBiFunction;

class IBox {
	private int n;
	public IBox(int i) { n = i; }
	public int larger(IBox b) {
		if(n > b.n)
			return n;
		else
			return b.n;
	}
}

class NoObjectMethodRef {
	public static void main(String[] args) {
		IBox ib1 = new IBox(5);
		IBox ib2 = new IBox(7);
		
		//두 상자에 저장된 값 비교하여 더 큰 값 반환
		ToIntBiFunction<IBox, IBox> bf = IBox::larger;//메소드 참조 방식
		int bigNum = bf.applyAsInt(ib1, ib2);
		System.out.println(bigNum);
	}
}//ToIntBiFunction<T, U> int applyAsInt(T t, U u)
```
* - 생성자 참조
```java
import java.util.function.Function;

class StringMaker {
	public static void main(String[] args) {
		Function<char[], String> f = ar -> {
			return new String(ar);
		};
		char[] src = { 'B', 't', 's' };
		String str =f.apply(src);
		System.out.println(src);
	}
}
// Fuction<T, R> R apply(T t)
```
Function<char[], String> f = String::new; //생성자 참조 방식
ClassName::new
f의 참조 대상이 String::new이므로, f는 String의 생성자를 참조하게 되는데, 참조 변수 f의 자료형이 Function<char[], String>이므로 매개변수 형이 char[]인 다음 생성자를 참조함.
### 28-2 Optional 클래스
* NullPointerException 예외의 발생 상황
```java
class NullPointerCaseStudy {
	public static void showCompAddr(Friend f) { //친구가 다니는 회사 주소 출력
		String addr = null;
		
		if(f != null) {//인자로 전달된 것이 null일 수도 있으니
			Company com = f.getCmp();
		if(com != null) {//회사 정보가 없을 수도 있으니
			ContInfo info = com.getcInfo();
			if(info != null)//회사의 연락처 정보가 없을 수도 있으니
				addr = info.getAdrs();
			}
		}
		if (addr != null)//위의 코드에서 주소 정보를 얻지 못했을 수 있으니
			System.out.println(addr);
		else
			System.out.println("There's no address information");		
	}
```

