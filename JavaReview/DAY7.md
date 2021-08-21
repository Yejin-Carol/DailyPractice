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
* Optional 클래스의 기본적인 사용 방법
	- 멤버 value에 인스턴스를 저장하는 일종의 Wrapper 클래스.
```java
import java.util.Optional;

public class StringOptional1 {
	public static void main(String[] args) {
		Optional<String> os1 = Optional.of(new String("Toy1"));
//String 인스턴스를 저장한 Optional 인스턴스 생성, of 메소드 호출
		Optional<String> os2 = Optional.ofNullable(new String("Toy2"));
//String 인스턴스를 저장한 Optional 인스턴스 생성, ofNullable 메소드 호출		
		if(os1.isPresent())//내용물 존재하면 isPresent는 true 반환
			System.out.println(os1.get());//get을 통한 내용물 반환
	
		if(os2.isPresent())
			System.out.println(os2.get());
	}
}
```
```java
class StringOptional2 {
	public static void main(String[] args) {
		Optional<String> os1 = Optional.of(new String("Toy1"));
		Optional<String> os2 = Optional.ofNullable(new String("Toy2"));
		os1.ifPresent(s -> System.out.println(s)); //람다식 버전
		os2.ifPresent(System.out::println); //메소드 참조 버전
	}
}
```
* Optional 클래스를 사용하면 if~else문을 대신할 수 있음: map 메소드의 소개
```java
import java.util.Optional;
class OptionalMap {
	public static void main(String[] args) {
		Optional<String> os1 = Optional.of("Optional String");
		Optional<String> os2 = os1.map(s -> s.toUpperCase());// 문자열의 모든 문자를 대문자로 바꿔서 반환
		System.out.println(os2.get());
		
		Optional<String> os3 = os1.map(s -> s.replace(' ', '_'))
					              .map(s -> s.toLowerCase());
		System.out.println(os3.get());
	}
}
```
apply 메소드가 반환하는 대상을 Optional 인스턴스에 담아서 반환한다.

* Optional 클래스 사용, if~else 대신: orElse 메소드 관계
```java
Optional<String> os1 = Optional.empty();
		Optional<String> os2 = Optional.of("So Basic");
		
		String s1 = os1.map(s -> s.toString())
						.orElse("Empty");
				
		String s2 = os2.map(s -> s.toString())
						.orElse("Empty");
```		
* map과 orElse
```java
String phone = ci.map(c -> c.getPhone())
							.orElse("There is no phone number.");
```
* NullPointerCaseStudy.java의 개선 결과
```java
class NullPointerCaseStudy {
	public static void showCompAddr(Optional<Friend> f) {
		String addr = f.map(Friend::getCmp)
					   .map(Company::getCInfo)
					   .map(ContInfo::getAdrs)
					   .orElse("There's no address information.");
		System.out.println(addr);
	}
	
	public static void main(String[] args) {
		ContInfo ci = new ContInfo("123-456-789", "Republic of Korea");
		Company cp = new Company("Army Co., Ltd.", ci);
		Friend frn = new Friend("Jimin", cp);
		showCompAddr(Optional.of(frn)); //친구가 다니느 회사의 주소 출력
	}
}
```
* Optional 클래스의 flatMap 메소드
```java
Optional<String> os3 = os1.flatMap(s -> Optional.of(s.toLowerCase()));
```
* flatMap + orElse
```java
String phone = ci.flatMap(c -> c.getPhone())
						     .orElse("There is no phone number.")
```
```java
class NullPointerCaseStudy {
	public static void showCompAddr(Optional<Friend> f) {
		String addr = f.map(Friend::getCmp)
					   .map(Company::getCInfo)
					   .map(ContInfo::getAdrs)
					   .orElse("There's no address information.");
		System.out.println(addr);
	}
	
	public static void main(String[] args) {
		Optional<ContInfo> ci = Optional.of(
			new ContInfo(Optional.ofNullable(null), Optional.of("Republic of Korea"))
		);
		Optional<Company> cp = Optional.of(new Company("Army Co., Ltd.", ci));
		Optional<Friend> frn = Optional.of(new Friend("Jimin", cp));
		showCompAddr(frn);
	}
}
```
### 28-3 OptionalInt, OptionalLong, OptionalDouble 클래스
* Optional과 OptionalXXX와의 차이점
```java
Optional<Integer< oi1 = Optional.of(3);
OptionalInt oi1 = OptionalInt.of(3);
```
## Ch 29. 스트림 1
### 29-1 스트림 이해와 생성
* Stream: 데이터 흐름, 배열 또는 컬렉션 인스턴스에 저장된 데이터를 꺼내서 파이프에 흘려보냄. (흘려 보내는 것 = 스트림)
	- 중간 연산(Intermediate Operation)
	- 최종 연산(Terminal Operation): 마지막에 진행되는 연산
```java
import java.util.Arrays;
import java.util.stream.IntStream;

public class MyFirstStream {
	public static void main(String[] args) {
		int[] ar = {1, 2, 3, 4, 5};
		IntStream stm1 = Arrays.stream(ar);//배열 ar로부터 스트림 생성. stm1이 참조
		IntStream stm2 = stm1.filter(n -> n%2 == 1); //stm1이 참조하는 스트림 대상으로 filter 중간 연산 실행 
		int sum = stm2.sum(); // 최종 연산 진행
		System.out.println(sum);
	}
}
```
* 스트림(Stream) 특성
```java
import java.util.Arrays;
public class MyFirstStream2 {
	public static void main(String[] args) {
		int[] ar = {1, 2, 3, 4, 5};
		
		int sum = Arrays.stream(ar) //스트림 생성
						.filter(n -> n%2 == 1) //filter 통과,
						.sum(); //sum 통과시켜 그 결과 반환
		System.out.println(sum);
	}
}
```
스트림의 연산은 효율과 성능을 고려하여 '지연(Lazy) 처리' 방식으로 동작
* 스트림 생성: 배열
```java
import java.util.Arrays;
import java.util.stream.Stream;

public class StringStream {
	public static void main(String[] args) {
		String[] names = {"Jungkook", "RM", "Jin"}; 
		Stream<String> stm = Arrays.stream(names); //스트림 생성
		stm.forEach(s -> System.out.println(s)); // 최종 연산 진행
	}
}
```
Arrays.stream(names) //스트림 생성
			  .forEach(s -> System.out.println(s)); // 최종 연산 진행
중간 연산 없이 최종 연산으로 진행 가능
* double stream
```java
import java.util.Arrays;

public class DoubleStream {
	public static void main(String[] args) {
		double[] ds = {1.1, 2.2, 3.3, 4.4, 5.5};
		
		Arrays.stream(ds)
			.forEach(d -> System.out.print(d + "\t"));
		System.out.println();
		Arrays.stream(ds, 1, 4) //인덱스 1부터 인덱스 4 이전까지
			   .forEach(d -> System.out.print(d + "\t"));
		System.out.println();
	}
}
```
* 스트림 생성하기: Collection Instance
```java
public class ListStream {
	public static void main(String[] args) {
		List<String> list = Arrays.asList("Bts", "PTD", "Butter");
		list.stream()
		    .forEach(s -> System.out.print(s + "\t"));
		System.out.println();
	}
}
```
### 29-2 Filtering & Mapping
* Filtering
	- Stream\<T> filter(Predicate<? super T > predicate): Stream\<T>에 존재
	- Predicate\<T>: boolean test(T t)
```java
class FilterStream {
	public static void main(String[] args) {
		int[] ar = {1, 2, 3, 4, 5};
		Arrays.stream(ar) //배열 기반 스트림 생성
			  .filter(n -> n%2 == 1)//홀수만 통과시킴
			  .forEach(n -> System.out.print(n + "\t"));
		System.out.println();
		
		List<String> sl = Arrays.asList("Bts", "PTD", "Butter");
		sl.stream() //컬렉션 인스턴스 기반 스트림 생성
		  .filter(s -> s.length() == 3)// 길이가 3이면 통과시킴
		  .forEach(s -> System.out.print(s + "\t"));
		System.out.println();
	}
}
```
* Mapping 1
```java
class MapToInt {
	public static void main(String[] args) {
		List<String> ls = Arrays.asList("Bts", "PTD", "Butter");
		
		ls.stream() //컬렉션 인스턴스 기반 스트림 생성
		  .map(s -> s.length())
		  .forEach(n -> System.out.print(n + "\t"));
		System.out.println();
	}
}
```
* Mapping 2
	- 두 번의 중간 연산
```java
import java.util.ArrayList;
import java.util.List;

class CafePriceInfo { // 카페 메뉴벌 가격 정보
	private String menu; //메뉴명
	private int price; //가격
	
	public CafePriceInfo(String m, int p) {
		menu = m;
		price = p;
	} 
	public int getPrice() {
		return price;
	}
}

class CafeStream {
	public static void main(String[] args) {
		List<CafePriceInfo> ls = new ArrayList<>();
		ls.add(new CafePriceInfo("Americano", 3000));
		ls.add(new CafePriceInfo("Cafe Latte", 3500));
		ls.add(new CafePriceInfo("Capuccino", 4000));

		int sum = ls.stream()
					.filter(p -> p.getPrice() < 4000)//4000미만 가격 정보만 모아서 스트림 생성
					.mapToInt(t -> t.getPrice())//인스턴스에 저장되어 있는 가격 정보 꺼내서 int형 스트림에 저장
					.sum();// 정가가 4000원 미만인 메뉴의 총합
		System.out.println("sum = " + sum);
	}
}
```
### 29-3 리덕션(Reduction), 병렬 스트림(Parallel Streams)
* 리덕션과 reduce 메소드
	- Reduction: 데이터를 축소하는 연산
	- T reduce(T identity, BinaryOperator\<T> accumulator) //Stream\<T>에 존재
```java
import java.util.Arrays;
import java.util.List;
import java.util.function.BinaryOperator;

public class ReduceStream {
	public static void main(String[] args) {
		List<String> ls = Arrays.asList("Bts", "Army", "PTD", "Butter");
		BinaryOperator<String> lc = (s1, s2) -> {
			if(s1.length() > s2.length())
				return s1;
			else
				return s2;
			};
		String str = ls.stream()
					   .reduce("", lc);//스트림이 빈 경우 빈 문자열 반환, .reduce("Empty Stream", lc) 빈 경우 "Empty Stream" 반환
		System.out.println(str);
	}
}
```
* 병렬 스트림 (Parallel Stream): 연산 횟수보다는 연산의 단계를 줄임!
String str = ls.parallelStream() //병렬 처리를 위한 스트림 생성
						   .reduce("", lc);
	- 빈 문자열과 각 인자 비교
	- "Bts" vs. "Army", "PTD" vs. "Butter"
	- "Army" vs. "Butter"		
