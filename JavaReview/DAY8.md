#  Java Review - DAY 8

## Ch 30. Stream 2
### 30-1 스트림의 생성과 연결
* 스트림 생성: 스트림 생성에 필요한 데이터 직접 전달
	- List\<String> sl = Arrays.asList("Bts", "Army", "PTD");
Stream.of(sl) // [Bts, Army, PTD] 출력
	-  Stream.of 메소드에 컬렉션 인스턴스 전달하면 해당 인스턴스 하나로 이뤄진 스트림이 생성됨. Stream.of 메소드에 배열을 전달하면 그때는 하나의 배열로 이뤄진 스트림이 생성되는 것이 아니라, 배열에 저장된 요소로 이뤄진 스트림이 생성됨.
* DoubleStream, IntStream, LongStream
	- IntStream.of(7, 5, 3,) //7, 5, 3
	- IntStream.range(5, 8) //5, 6, 7
	- IntStream.rangeClosed(5,8) //5, 6, 7, 8

* 병렬 스트림으로 변경
 ```
	String str = ss.parallel()//병렬 스트림 생성
	               .reduce("", lc);
 ```
* 스트림 연결 
```
	Stream.concat(ss1, ss2)
	      .forEach(s -> System.out.println(s));
```
### 30-2 스트림의 중간 연산
* Mapping에 대한 추가 정리
```
[Stream<T>의 map 시리즈 메소드]
<R> Stream<R> map(Function<T, R> mapper)
IntStream mapToInt(ToIntFunction<T> mapper)
LongStream mapToLong(ToLongFunction<T> mapper)
DoubleStream mapToDouble(ToDoubleFunction<T> mapper)

[Stream<T>의 flatMap 시리즈 메소드들]
<R> Stream<R> flatMap(Function<? Stream<R>> mapper)
-> Function<T, R>의 추상 메소드는 R apply(T t), 위 메소드 호출시 람다식이 구현해야할 메소드는 Stream<R> apply (T t)

IntStream flatMapToInt(Function<T,IntStream> mapper)
LongStream flatMapToLong(Function<T, LongStream> mapper)
DoubleStream flatMapToDouble(Function<T, DoubleStream> mapper)
```
* - flatMap에 전달한 람다식에서는 '스트림을 생성하고 이를 반환'해야함. 반면 map에 전달할 람다식에서는 스트림을 구성할 데이터만 반환하면 됨.
```java
import java.util.Arrays;
import java.util.stream.Stream;

public class FlatMapStream {
	public static void main(String[] args) {
		Stream<String> ss1 = Stream.of("MY_DREAM", "YOUR_LIFE");
		
		//아래 람다식에서 스트림 생성: 인자로 전달된 구분자 정보를 기준으로 문자열 나누고,
		//이를 배열에 담아서 반환
		Stream<String> ss2 = ss1.flatMap(s -> Arrays.stream(s.split("_")));
		ss2.forEach(s -> System.out.print(s + "\t"));
		System.out.println();
	}
}
```

```java
import java.util.Arrays;
import java.util.stream.IntStream;
import java.util.stream.Stream;

class ReportCard {
	private int kor;//국어점수
	private int eng;//영어점수
	private int math;//수학점수
	
	public ReportCard(int k, int e, int m) {
		kor = k;
		eng = e;
		math = m;
	}
	public int getKor() { return kor; }
	public int getEng() { return eng; }
	public int getMath() { return math; }
}

class GradeAverage {
	public static void main(String[] args) {
		ReportCard[] cards = {
				new ReportCard(70, 80, 90),
				new ReportCard(90, 80, 70),
				new ReportCard(80, 80, 80)
		};
		
		//ReportCard 인스턴스로 이뤄진 스트림 생성
		Stream<ReportCard> sr = Arrays.stream(cards);
		
		//학생들의 점수 정보로 이뤄진 스트림 생성
		IntStream si = sr.flatMapToInt(
			r -> IntStream.of(r.getKor(), r.getEng(), r.getMath()));
	
		//평균을 구하기 위한 최종 연산 average 진행
		double avg = si.average().getAsDouble();
		System.out.println("avg. " + avg);	
	}
}
```
OptionalDouble 
```java
Arrays.stream(cards)
			  .flatMapToInt(r -> IntStream.of(r.getKor(), r.getEng(), r.getMath()))
			  .average()
			  .ifPresent(avg -> System.out.println("avg. " + avg));
```
* 정렬
```
Stream<T> sorted(Comparator<? super T> comparator)//Stream<T>의 메소드
Stream<T> sorted() //Stream<T>의 메소드
IntStream sorted() //IntStream의 메소드
LongStream sorted() //LongStream의 메소드
DoubleStream sorted() //DoubleStream의 메소드
```java
import java.util.stream.Stream;

public class IntSortedStream {
	public static void main(String[] args) {
		Stream.of("Bts", "Army", "PTD", "Butter")
		      .sorted()
		      .forEach(s -> System.out.print(s + '\t'));
		System.out.println();

		Stream.of("Bts", "Army", "PTD", "Butter")
		      .sorted((s1, s2) -> s1.length() - s2.length())
		      .forEach(s -> System.out.print(s + '\t'));
		System.out.println();
	}
}
```
* Looping
	- 스트림을 이루는 모든 데이터 각각을 대상으로 특정 연산을 진행하는 행위
```java
import java.util.stream.IntStream;

public class LazyOpStream {
	public static void main(String[] args) {
		//최종 연산이 생략된 스트림의 파이프라인
		IntStream.of(1, 3, 5)
				 .peek(d-> System.out.print(d + "\t"));
		System.out.println();//최종 연산 없으므로 중간 연산 진행되지 않음
		
		//최종 연산이 존재하는 스트림의 파이프라인
		IntStream.of(5, 3, 1)
				 .peek(d -> System.out.print(d + "\t"))//중간 연산 진행
				 .sum();// sum 반환 값 저장 혹은 출력하지 않음
		System.out.println();
	}			
}
```
### 30-3 스트림의 최종 연산
* sum(), count(), average(), min(), max()
```java
import java.util.stream.IntStream;

public class OpIntStream {
	public static void main(String[] args) {
	
		int sum = IntStream.of(1, 3, 5, 7, 9)
						   .sum();
		System.out.println("sum =" + sum);

		long count = IntStream.of(1, 3, 5, 7, 9)
				   .count();
		System.out.println("count =" + count);
		
		IntStream.of(1, 3, 5, 7, 9)
				 .average()
				 .ifPresent(av -> System.out.println("avg = " + av));
		
		IntStream.of(1, 3, 5, 7, 9)
				 .min()
				 .ifPresent(mn -> System.out.println("min = " + mn));
		
		IntStream.of(1, 3, 5, 7, 9)
		 	     .max()
		 	     .ifPresent(mx -> System.out.println("max = " + mx));
	}
}
```
* forEach
```
void forEach(Consumer<? super T> action)
void forEach(DoubleConsumer action)...
```

* allMatch, anyMatch, noneMAtch
``` 
boolean allMatch(IntPredicate predicate)...
boolean anyMatch(DoublePredicate predicate)...
```
```java
import java.util.stream.IntStream;

public class MatchStream {
	public static void main(String[] args) {
		boolean b = IntStream.of(1, 2, 3, 4, 5)
							.allMatch(n -> n%2 == 0);
		System.out.println("모두 짝수이다. " + b);
		
		b = IntStream.of(1, 2, 3, 4, 5)
				.anyMatch(n -> n%2 == 0);
		System.out.println("짝수가 하나는 있다. " + b);

		b = IntStream.of(1, 2, 3, 4, 5)
				.noneMatch(n -> n%2 == 0);
		System.out.println("짝수가 하나도 없다. " + b);
	}
}
```
* collect
	- 한번 파이프라인에 흘려보낸 스트림은 되돌리거나 다른 파이프라인에 다시 흘려보낼 수 없다.
	- 필요하다면 파이프라인을 통해서 가공되고 걸러진 데이터를 최종 연산 과정에서 별도로 저장해야함.
	- Collect 메소드는 람다식을 기반으로 데이터 저장할 저장소를 생성함. 
```java
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

class CollectStringStream {
	public static void main(String[] args) {
		String[] words = {"Bts", "Army", "PTD", "Butter"};
		Stream<String> ss = Arrays.stream(words);
		
		List<String> ls = ss.filter(s -> s.length() < 5)
							.collect(() -> new ArrayList<>(),
									(c, s) -> c.add(s),
									(lst1, lst2) -> lst1.addAll(lst2));
		System.out.println(ls);
	}
}
```
* 병렬 스트림에서의 collect : 속도 느려지는 경우 있으므로 적합성 판단 후 진행
```java
List<String> ls = ss.parallel()
							.filter(s -> s.length() < 5)
							.collect(() -> new ArrayList<>(),
									(c, s) -> c.add(s),
									(lst1, lst2) -> lst1.addAll(lst2));
```
## Ch. 31 시각과 날짜의 처리
### 31-1 시각과 날짜 관련 코드의 작성
* 시간이 얼마나 걸렸지? : Instant 클래스
	- 시각: 시간의 어느 한 시점
		- java.time.Instant : 흐르는 시간 속 특정 시점
		- Instant now = Instant.now(); //now 메소드 호출을 통한 Instant 인스턴스의 생성
	- 시간: 어떤 시각에서 어떤 시각까지의 사이
```java
import java.util.List;
import java.time.Duration;
import java.time.Instant;
import java.util.Arrays;

class HowLongParallel {
	public static long fibonacci(long n) {
		if(n == 1 || n == 2)
			return 1;
		return fibonacci(n-1) + fibonacci(n-2);
	}
	
	public static void main(String[] args) {
		List<Integer> nums = Arrays.asList(41, 42, 43, 44, 45, 45);
		
		Instant start = Instant.now(); //스톱워치 시작
		nums.parallelStream() //병렬 스트림 생성
		    .map(n -> fibonacci(n))
		    .forEach(r -> System.out.println(r));
		
		Instant end = Instant.now(); //스톱워치 멈춤
		System.out.println("Parallel Processing Time: " +
			Duration.between(start, end).toMillis());
	}
}
```
* LocalData 클래스
```java
import java.time.LocalDate;

public class LocalDateDemo1 {
	public static void main(String[] args) {
		// Today
		LocalDate today = LocalDate.now();
		System.out.println("Today: " + today);
		
		// This year's Christmas
		LocalDate xmas = LocalDate.of(today.getYear(), 12, 25);
		System.out.println("Xmas: " + xmas);

		// This year's Christmas Eve
		LocalDate eve = xmas.minusDays(1);
		System.out.println("Xmas Eve: " + eve);
	}
}
```
* - LocalTime mt = now.plusHours(2); //시 정보를 2 증가
	- mt = mt.plusMinutes(10); //분 정보를 10 증가
	- plus Seconds
	- Duration between = Duration.between(start, end);

* LocalDateTime 클래스
```
LocalDateTime dt = LocalDateTime.now();
LocalDateTime mt = dt.plusHours(22);
mt = mt. plusMinutes(35) //22시간 35분 뒤 
```
* - plusYears(long years) ~ plusSeconds(long seconds)
```java
import java.time.Duration;
import java.time.LocalDateTime;
import java.time.Period;

public class LocalDateTimeDemo2 {
	public static void main(String[] args) {

		LocalDateTime today = LocalDateTime.of(2021, 8, 22, 12, 00);
		LocalDateTime flight1 = LocalDateTime.of(2021, 9, 10, 15, 00);
		LocalDateTime flight2 =  LocalDateTime.of(2021, 9, 9, 17, 30);
		
		//빠른 항공편 선택
		LocalDateTime myFlight;
		if(flight1.isBefore(flight2))//flight1이 flight2보다 이전인가? 
		//flight2.isAfter(flight1): flight2가 flight1보다 이후인가?
			myFlight = flight1;
		else
			myFlight = flight2;
		
		//빠른 항공편의 비행 탑승까지 남은 날짜 계산
		Period day = Period.between(today.toLocalDate(), myFlight.toLocalDate());
		
		//빠른 항공편의 비행 탑승까지 남은 시간 계산
		Duration time = Duration.between(today.toLocalTime(), myFlight.toLocalTime());
		
		//비행 탑승까지 남은 날짜와 시간 출력
		System.out.println(day);
		System.out.println(time);	
	}
} 
```
* - Period: 날짜의 차
	- Duration: 시각의 차
```java
		LocalDateTime dt3 = LocalDateTime.of(2021, Month.JANUARY, 12, 15, 30);
		LocalDateTime dt4 = LocalDateTime.of(2021, Month.FEBRUARY, 13, 14, 29);

		Duration drDate2 = Duration.between(dt3, dt4);
		System.out.println(drDate2);//결과값 PT766H59M
```
### 31-2 시간대를 적용한 코드 작성 그리고 출력 포맷의 지정
* 세계의 시간대
	- UTC (Universal Time Coordinated), 한국 UTC + 9
```java
import java.time.Duration;
import java.time.ZoneId;
import java.time.ZonedDateTime;

public class ZoneDateTimeDemo1 {
	public static void main(String[] args) {
		ZonedDateTime here = ZonedDateTime.now();
		System.out.println(here);
		
		//동일한 날짜와 시각의 파리
		ZonedDateTime paris = ZonedDateTime.of(
							here.toLocalDateTime(), ZoneId.of("Europe/Paris"));
		System.out.println(paris);
		
		//이곳과 파리의 시차
		Duration diff = Duration.between(here, paris);
		System.out.println(diff);//PT7H
	}
}
```
```java
import java.time.Duration;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.ZonedDateTime;

public class ZoneDateTimeDemo2 {
	public static void main(String[] args) {
		//departure in Seoul 
		ZonedDateTime departure = ZonedDateTime.of(
				LocalDateTime.of(2021,  8, 27, 00, 50), ZoneId.of("Asia/Seoul"));
		System.out.println("Departure : " + departure);
		
		//arrival in Paris
		ZonedDateTime arrival = ZonedDateTime.of(
				LocalDateTime.of(2021, 8, 27, 06, 00), ZoneId.of("Europe/Paris"));
		System.out.println("Arrival: " + arrival);
		
		//Journey duration
		System.out.println(Duration.between(departure, arrival));
	}
}

//결과값
//Departure : 2021-08-27T00:50+09:00[Asia/Seoul]
//Arrival: 2021-08-27T06:00+02:00[Europe/Paris]
//PT12H10M
```
* 날짜와 시각 정보의 출력 포맷 지정
```java
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.ZonedDateTime;
import java.time.format.DateTimeFormatter;

public class DateTimeFormatterDemo {
	public static void main(String[] args) {
		ZonedDateTime date = ZonedDateTime.of(
				LocalDateTime.of(2021,  8, 22, 12, 45), ZoneId.of("Asia/Seoul"));
		
		//21-8-22
		DateTimeFormatter fm1 = 
				DateTimeFormatter.ofPattern("yy-M-d");
		//2021-08-22, 12:45:0
		DateTimeFormatter fm2 = 
				DateTimeFormatter.ofPattern("yyyy-MM-d, H:m:s");
		//2021-08-22, 12:45:00 Asia/Seoul
		DateTimeFormatter fm3 = 
				DateTimeFormatter.ofPattern("yyyy-MM-d, HH:mm:ss VV");
		
		System.out.println(date.format(fm1));
		System.out.println(date.format(fm2));
		System.out.println(date.format(fm3));
	}
}
```



## Ch 34. Thread & Synchronization
### 34-1 쓰레드의 이해와 쓰레드의 생성
* 쓰레드는 실행 중인 프로그램 내에서 '또 다른 실행의 흐름을 형성하는 주체'
```java
public class CurrentThreadName {
	public static void main(String[] args) {
		Thread ct = Thread.currentThread();//main 메소드를 실행하는 쓰레드의 정보를 담고 있는 인스턴스의 참조
		String name = ct.getName(); //참조하는 쓰레드의 이름을 반환
		System.out.println(name);
	}
}
```
> 실행 결과: main // main 쓰레드

* 쓰레드 생성하는 방법 1. 
	- start 메소드 호출 -> 가상머신은 쓰레드를 생성해서 Thread 인스턴스 생성 시 전달된 run 메소드를 실행하게 함.
	- 결과 Thread-0은 기본적으로 주어진 이름.
```java
public class MakeThreadDemo {

	public static void main(String[] args) {
		//java.lang.Runnable 인터페이스 구현하는 클래스의 인스턴스 생성. 
		//void run() 추상 메소드만 존재하는 함수형 인터페이스
		//구현된 메소드는 새로 생성되는 쓰레드에 의해 실행되는 메소드
		Runnable task = () -> { //쓰레드가 실행하게 할 내용
			int n1 = 10;
			int n2 = 20;
			String name = Thread.currentThread().getName();
			System.out.println(name + ": " + (n1 + n2));			
		};
		// Thread 인스턴스 생성해야 함. 
		Thread t = new Thread(task);//인스턴스 생성 시 run 메소드의 구현 내용 전달
		t.start(); // 쓰레드 생성 및 실행. 
		System.out.println("End" + Thread.currentThread().getName());
	}
}
```
> 실행 결과: Endmain
Thread-0: 30
* 쓰레드는 자신의 일을 마치면(run 메소드의 실행을 완료하면) 자동으로 소멸된다. 

*  두 개 이상의 쓰레드 생성
	- public static void sleep(long millis) throws InterruptedException
	- millisecond = 1/1000초 만큼 실행을 멈춤
```java
package Thread;

public class MakeThreadMultiDemo {

	public static void main(String[] args) {
		Runnable task1 = () -> { // 20 미만 짝수 출력
			try {
				for(int i = 0; i < 20; i++) {
					if(i % 2 == 0)
						System.out.println(i + " ");
					Thread.sleep(100); //0.1 초간 잠을 잔다. 
				}
			} catch(InterruptedException e) {
				e.printStackTrace();
			}			
		};
		Runnable task2 = () -> { //20 미만 홀수 출력
			try {
				for(int i = 0; i < 20; i++) {
					if(i % 2 == 1)
						System.out.println(i + " ");
					Thread.sleep(100); //0.1 초간 잠을 잔다. 
				}
			} catch(InterruptedException e) {
				e.printStackTrace();
			}
		}; 
		
		Thread t1 = new Thread(task1);
		Thread t2 = new Thread(task2);
		t1.start();
		t2.start();
		}
}
```
> 0.1 초씩 잠이 듬.
* 쓰레드 하나에 CPU 코어 하나가 할당되어 동시에 실행이 이뤄짐.

```java
public class ThreadMultiNoSleepDemo {

	public static void main(String[] args) {
		Runnable task1 = () -> { // 20 미만 짝수 출력
			for (int i = 0; i < 20; i++) {
				if (i % 2 == 0)
					System.out.println(i + " ");
			}

		};
		Runnable task2 = () -> { // 20 미만 홀수 출력
			for (int i = 0; i < 20; i++) {
				if (i % 2 == 1)
					System.out.println(i + " ");
			}
		};

		Thread t1 = new Thread(task1);
		Thread t2 = new Thread(task2);
		t1.start();
		t2.start();
	}
}
```
* 쓰레드가 코드의 수보다 ㅁ낳이 생성되면
	- CPU 코어가 둘 이상인 것과 같은 효과
	- 하나의 코어가 둘 이상의 쓰레드를 담당하므로 코어의 활용도 높음

* 쓰레드 생성 방법 2.
	- 1단계: Runnable 구현한 인스턴스 생성 (Thread를 상속하는 클래스의 정의와 인스턴스 생성)
	- 2단계: Thread 인스턴스 생성 (start 메소드 호출)
	- 3단계: start 메소드 호출
```java
class Task extends Thread {
	public void run() { //Thread의 run 메소드 overriding
			int n1 = 10;
			int n2 = 20;
			String name = Thread.currentThread().getName();
			System.out.println(name + ": " + (n1 + n2));			
		}
}

class MakeThreadDemo2 {
	public static void main(String[] args) {
		Task t1 = new Task();
		Task t2 = new Task();
		t1.start();
		t2.start();
		System.out.println("End" + Thread.currentThread().getName());
	}
}
```
> 실행 결과: Endmain
					Thread-0: 30
					Thread-1: 30

### 34-2 쓰레드의 동기화
* 쓰레기의 메모리 접근 방식과 그에 따른 문제점
* 둘 이상의 쓰레드가 하나의 메모리 공간에(하나의 변수에_ 접근 했을 때 문제 발생) 즉, 둘 이상의 쓰레드가 동일한 변수에 접근하는 것은 문제를 일으킬 수 있음.
```java

class MutualAccess {
	public static Counter cnt = new Counter();
	
	public static void main(String[] args) throws InterruptedException {
		Runnable task1 = () -> {
			for(int i = 0; i < 1000; i++)
				cnt.increment(); //값을 1 증가;
		};
		
		Runnable task2 = () -> {
			for(int i = 0; i < 1000; i++)
				cnt.decrement(); //값을 1 감소;
		};
		
		Thread t1 = new Thread(task1);
		Thread t2 = new Thread(task2);
		t1.start();
		t2.start();
		t1.join();//t1이 참조하는 스레드의 종료를 기다림
		t2.join();//t2가 참조하는 스레드의 종료를 기다림
		System.out.println(cnt.getCount());	
	}
}
```
* 실행할 때 마다 문제 발생 -> '동기화(Synchronization)' 필요!
* 동기화 메소드
* synchronized public void increment() {...}
```java
class Counter {
	int count = 0; //두 쓰레드에 의해 공유되는 변수
	//동기화
	synchronized public void increment() {
		count++; //첫 번째 쓰레드에 의해 실행되는 문장
	}
	//동기화
	synchronized public void decrement() {
		count--; //또 다른 쓰레드에 의해 실행되는 문장
	}
	public int getCount() {return count;}
} //결과 0으로만 나옴!
```
* 동기화 블록 (동기화가 불필요한 부분을 실행하는 동안에도 다른 쓰레드의 접근을 막는 일 발생 -> 동기화 블록)
```java
class Counter {
	int count = 0; // 두 쓰레드에 의해 공유되는 변수

	public void increment() {
		synchronized (this) { // 동기화 블록
		count++; // 첫 번째 쓰레드에 의해 실행되는 문장
		}
	}

	public void decrement() {
		synchronized (this) { // 동기화 블록
		count--; // 또 다른 쓰레드에 의해 실행되는 문장

		}
	}

	public int getCount() {
		return count;
	}
}
```
* StringBuffer는 쓰레드에 안전하지만, StringBuilder는 쓰레드에 안전하지 않음. -> StringBuffer가 동기화 되어 있어서, 이 인스턴스를 대상으로 둘 이상의 쓰레드가 동시에 접근해도 문제가 되지 않음 의미. 

### 34-3 쓰레드를 생성하는 더 좋은 방법
* 처리해야 할 일이 있을 때마다 쓰레드를 생성하는 것 -> 성능 저하 -> '쓰레드 풀 (Thread Pool)' 생성해 두고 이를 재활용하는 기술 사용. 
* 멀티 쓰레드 프로그래밍에서 쓰레드 풀의 활용 매우 중요. 
* concurrent 패키지 활용하면 간단히 쓰레드 풀 생성

```java
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ExecutorsDemo {

	public static void main(String[] args) {
		Runnable task = () -> { //스레드에 시킬 작업
			int n1 = 10;
			int n2 = 20;
			String name = Thread.currentThread().getName();		
			System.out.println(name + ": " + (n1 + n2));
		};
		
		ExecutorService exr = Executors.newSingleThreadExecutor(); //스레드 풀 생성
		exr.submit(task); //스레드 풀에 작업을 전달
		
		System.out.println("End " + Thread.currentThread().getName());
		exr.shutdown(); //스레드 풀과 그 안에 있는 스레드 소멸
	}
}
```
* newSingleThreadExecutor : 풀 안에 하나의 쓰레드만 생성하고 유지(하나의 코어 기준 활용도 매우 높음!)
* newFixedThreadPool: 풀 안에 인자로 전달된 수의 쓰레드를 생성하고 유지
* newCachedThreadPool: 풀 안의 쓰레드 수를 작업의 수에 맞게 유동적으로 관리

* Callable & Future

```java
package Thread;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ExecutorsDemo {

	public static void main(String[] args) {
		Runnable task1 = () -> { //스레드에 시킬 작업
			String name = Thread.currentThread().getName();		
			System.out.println(name + ": " + (5 + 7));
		};
		
		Runnable task2 = () -> { //스레드에 시킬 작업
			String name = Thread.currentThread().getName();		
			System.out.println(name + ": " + (7 - 5));
		};
		
		ExecutorService exr = Executors.newFixedThreadPool(2);//전달인자 2이므로 두 개의 스레드 존재
		exr.submit(task1); //스레드 풀에 작업을 전달
		exr.submit(task2);
		exr.submit(() -> {
			String name = Thread.currentThread().getName();		
			System.out.println(name + ": " + (5 * 7));
		});
		
		exr.shutdown(); //스레드 풀과 그 안에 있는 스레드 소멸
	}

}
```





```java
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

public class CollableDemo {

	public static void main(String[] args)
		throws InterruptedException, ExecutionException {
			Callable<Integer> task = () -> {
				int sum = 0;
				for(int i = 0; i < 10; i++)
					sum += i;
				return sum; //반환 값 int형
			};
			ExecutorService exr = Executors.newSingleThreadExecutor();
			Future<Integer> fur = exr.submit(task);
			
			Integer r = fur.get(); //스레드 반환 값 획득
			System.out.println("result: " + r);
			exr.shutdown();
		}

	}
```
* Future 타입 인자는 Callable 타입 인자와 일치시켜야 함.
* ReentrantLock  클래스
> ReentrantLock criticObj = new ReentrantLock();
> void myMethod(int arg) {
>          criticObj.lock(); //문을 잠금.....
>          try{ .....// 한 스레드에 의해서만 실행
>          } finally {
>          criticObj.unlock(); //문을 연다
>          }
>          }

* 컬렉션 인스턴스 동기화
* public static <T> Set<T> sychronizedSet(Set<T> s)
* public static <T> List<T> sychronizedSet(List<T> list)
* public static <K, V> Map<K, V> sychronizedMap(Map<K, V> m)
* public static <T> Collection<T> sychronizedCollection(Collection <T> c)
* List<String> lst = Collections.synchronizedList(new ArrayList<String>());
```java
package Thread;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.ListIterator;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class SyncArrayList {
	public static List<Integer> lst =
				Collections.synchronizedList(new ArrayList<Integer>());
	
	public static void main(String[] args) throws InterruptedException {
		for (int i = 0; i < 16; i++)
			lst.add(i);
		System.out.println(lst);
		
		Runnable task = () -> {
			synchronized(lst) {//이 영역에 실행 시 lst에 다른 쓰레드 접근 불가!
				ListIterator<Integer> itr = lst.listIterator();
				while(itr.hasNext())
					itr.set(itr.next() + 1);
			}
		};
		
		ExecutorService exr = Executors.newFixedThreadPool(3);
		exr.submit(task);
		exr.submit(task);
		exr.submit(task);
		
		exr.shutdown();
		exr.awaitTermination(100, TimeUnit.SECONDS);//최대 100초까지 기다려 주겠음.
		System.out.println(lst);
	}

}
```
* 동기화 블록의 내부를 실행할 때 lst에 다른 쓰레드 접근 허용하지 않음.
* 동기화 처리가 된 Vector 클래스 (기본적으로 동기화 되어있음)
