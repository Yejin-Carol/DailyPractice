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
## Ch 32. I/O Stream
### I/O 스트림에 대한 이해
* Stream vs. I/O Stream

| Stream  | I/O Stream |
|--|--|
|데이터를 어떻게 원하는 형태로 걸러내고 가공  | 어떻게 데이터를 입/출력  |
| 컬렉션 인스턴스에 저장된 문자열 중 길이가 5 이상인 문자열만 출력 | 파일에 저장된 문자열을 꺼내어 컬렉션 인스턴스에 저장  |
* I/O Stream 모델
	- 파일, 키보드/모니터, 그래픽카드/사운드카드, 프린터/팩스 같은 출력장치, 인터넷으로 연결되어 있는 서버 또는 클라이언트
* I/O 모델과 Stream 이해, 파일 대상의 입력 스트림 생성
	- - Stream: 데이터 흐름
	- Input Stream: 실행 중인 자바 프로그램으로 데이터를 읽어 들이는 스트림, 데이터의 입력 통로
	- Output Stream: 실행 중인 자바 프로그램으로 데이터를 내보내는 스트림, 데이터의 출력 통로
	- InputStream in = new FileInputStream("data.dat"); //FileInputStream 클래스는 InputStream 클래스를 상속함 . 입력 스트림 생성
	- public abstract int read() throws IOException //java.io.InputStream의 메소드
	- int data = in.read(); //데이터 읽어 들임
	- in.close(); //입력 스트림 종료
	- OutputStream out = new FileOutStream("data.dat"); //출력스트림 생성, FileOutputStream 클래스는 OutputStream 클래스 상속함.
	- out.write(7); //데이터 7을 파일에 전달
	- out.close(); //출력 스트림의 종료 및 소멸 
* 입출력 스트림 관련 코드의 개선(try-with-resources 문 사용)
```java
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;

public class Write7ToFile2 {
	public static void main(String[] args) throws IOException {
		OutputStream out = null;
		
		try {
			out = new FileOutputStream("data.dat");
			out.write(7);
		}
		finally {
			if(out != null) //출력 스트림 생성에 성공했다면,
				out.close();
		}
	}
}
```
```java
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

public class Read7FromFile3 {
	public static void main(String[] args) {
		try(InputStream in = new FileInputStream("data.dat")) {
			int dat = in.read();
			System.out.println(dat);
		}
		catch(IOException e) {
			e.printStackTrace();
		}
	}
}
```
* Byte 단위 입출력 스트림
* 보다 빠른 속도의 파일 복사 프로그램
```java
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.Scanner;

public class BytesFileCopier {
	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.print("대상 파일: ");
		String src = sc.nextLine();
		
		System.out.print("사본 이름: ");
		String dst = sc.nextLine();
		
		try(InputStream in  = new FileInputStream(src);
			OutputStream out = new FileOutputStream(dst)) {
			byte buf[] = new byte[1024];
			int len;
			
			while(true) {
				len = in.read();// 배열 buf로 데이터 읽어 들임
				if (len == -1) //더 이상 읽어 들일 데이터 없으면,
					break;//반복문 탈출
				out.write(buf, 0, len);//len 바이트만큼 데이터 저장
			}
		}
		catch(IOException e) {
			e.printStackTrace();
		}
	}
}
```
### 32-2 필터 스트림의 이해와 활용
* 바이트 단위로 데이터를 읽고 쓸 줄은 알지만 
	- 필터 스트림 생성 및 연결
		- DataInputStream fIn = new DataInputStream(in); 
		- 기본 자료형 데이터의 입력을 위한 필터 스트림
		- DataOutputStream fOut = new DataOutputStream(out);
		- 기본 자료형 데이터의 출력을 위한 필터 스트림
* DataOutputStream out = new DataOutputStream(new FileOutputStream("data.dat"))

```java
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;

public class DataFilterInputStream {
	public static void main(String[] args) {
		try(DataInputStream in =
				new DataInputStream(new FileInputStream("data.dat"))) {
			int num1 = in.readInt(); // int형 데이터 저장
			double num2 = in.readDouble(); //double형 데이터 저장
			
			System.out.println(num1);
			System.out.println(num2);
		}
		catch(IOException e) {
			e.printStackTrace();
		}
	}
}
```
 ```java
 public class DataFilterOutputStream {
	public static void main(String[] args) {
		try(DataOutputStream out =
				new DataOutputStream(new FileOutputStream("data.dat"))) {
			out.writeInt(370);//int형 데이터 꺼냄
			out.writeDouble(3.14);//double형 데이터 꺼냄
		}
		catch(IOException e) {
			e.printStackTrace();
		}
	}
}
```
* 버퍼링 기능을 제공하는 필터 스트림
	- BufferedInputStream: 버퍼링 기능을 제공하는 버퍼 입력 스트림
	- BufferedOutputStream: 버퍼링 기능을 제공하는 버퍼 출력 스트림
	- 버퍼 입력 스트림 내부에 '버퍼(메모리 공간)'을 가짐. read메소드 호출시 파일에 저장된 데이터 반환이 아니라, 버퍼 스트림의 저장된 데이터 반환함. -> 성능 향상의 핵심
	- 버퍼링: 메모리를 어느 정도 채운 다움에 데이터를 이동
* 버퍼링 기능에 대한 대책, flush 메소드 호출
	- public void flush() throws IOException //java.io.OutputStream의 메소드, 실제 파일에 데이터 저장되지 않았을 때, 버퍼 비우라고(파일로 데이터를 보내라고) 명령
* 파일에 기본 자료형 데이터 저장, 버퍼링 기능도 추가
```
try(DataOutputStream out =
		new DataOutputStream(
			new BufferedOutputStream(
				new FileOutputStream("data.dat")))) 
```
### 32-3 문자 스트림의 이해와 활용
* Byte Stream과 문자 스트림
	- 영문과 특수문자: 1byte로 표현(인코딩)
	- 한글: 2byte로 표현(인코딩)
* FileReader & FileWriter
	- FileReader: 파일 대상 문자 입력 스트림 생성
	- FileWriter: 파일 대상 문자 출력 스트림 생성
* BufferedReader & BufferedWriter
	- BufferedInputStream: 바이트 기반 버퍼 입력 스트림
	- BufferedOutputStream: 바이트 기반 버퍼 출력 스트림
```java
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;

public class StringWriter {
	public static void main(String[] args) {
		String ks = "공부에 있어 돈이 꼭 필요한 것은 아니다.";
		String es = "Life is long if you know how to use it.";
		
		try(BufferedWriter bw =
				new BufferedWriter(new FileWriter("String.txt"))) {
			bw.write(ks, 0, ks.length());
			bw.newLine(); //줄 바꿈 문자 삽입
			bw.write(es, 0, es.length());
		}
		catch(IOException e) {
			e.printStackTrace();
		}
	}
}
```
```java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class StringReader {
	public static void main(String[] args) {
		try(BufferedReader br = new BufferedReader(new FileReader("String.txt"))) {
			String str;
			while(true) {
				str = br.readLine(); //한 문장 읽어 들이기
				if(str == null)
					break;
				System.out.println(str);
			}
		}
		catch(IOException e) {
			e.printStackTrace();
		}
	}
}
```
### 32-4 IO 스트림 기반의 인스턴스 저장
* 객체 직렬화(Object Serialization): 인스턴스를 통째로 저장
* 객체 역 직렬화(Object Deserialization): 역으로 저장된 인스턴스를 꺼내는 것
* ObjectInputStream & ObjectOutputStream
	- 필터 입력/출력 스트림이 상속하는 클래스
	- 입출력의 대상이 되는 인스턴스의 클래스는 java.io.Serializable을 구현
```java
public class SBox implements java.io.Serializable {
	String s;//s가 참조하는 인스턴스까지 함께 저장
	//transient String s; 이 참조변수가 참조하는 대상은 저장하지 않겠다는 선언
	public SBox(String s) { this.s = s; }
	public String get() { return s; }
}
```
	- 인스턴스를 저장하면 인스턴스 변수가 참조하는 인스턴스까지 함께 저장됨.
	- 위 클래스 인스턴스 바이트 스트림 통한 입출력 가능
	- transient 선언 추가하면 이 변수가 참조하는 인스턴스는 저장되지 않고 복원시 이 참보변수는 null로 초기화됨.
```
public class IBox implements java.io.Serializable {
	transient int n; //이 변수의 값은 저장 대상에서 제외함.
	public IBox(int n) { this.n = n; }
	public int get() { return n; }
}
```
```java
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;

class ObjectOutput {
	public static void main(String[] args) {
		SBox box1 = new SBox("Cafe Latte");
		SBox box2 = new SBox("Capuccino");
		
		try(ObjectOutputStream oo = 
				new ObjectOutputStream(new FileOutputStream("Object.bin"))) {//Object.bin 파일 생성
			oo.writeObject(box1); //menu1이 참조하는 인스턴스 저장
			oo.writeObject(box2); //menu2이 참조하는 인스턴스 저장
		}
		catch(IOException e) {
			e.printStackTrace();
		}
	}
}
```
```java
import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;

public class ObjectInput {
	public static void main(String[] args) {
		try(ObjectInputStream oi=
				new ObjectInputStream(new FileInputStream("Object.bin"))) {
			SBox box1 = (SBox) oi.readObject();//인스턴스 복원
			System.out.println(box1.get());
			SBox box2 = (SBox) oi.readObject();//인스턴스 복원
			System.out.println(box2.get());
		}
		catch(ClassNotFoundException e) {
			e.printStackTrace();
		}
		catch(IOException e) {
			e.printStackTrace();
		}
	}
}
```
## Ch 33. NIO 그리고 NIO.2
### 33-1 File System

* 기본적인 파일 시스템
	-	절대경로: root directory부터 시작하는 파일의(디렉토리) 위치 정보
		-	윈도우 절대 경로 C:\javastudy\simple.java
		-	 리눅스 절대 경로: /javastudy/simple.java
	- 상대경로: '현재 디렉토리' 기준으로 파일(디렉토리)의 위치 표현
		- 윈도우 상대 경로: javastudy\simple.java
		- 리눅스  상대 경로: javastudy/simple.java

* Paths와 Path 클래스
	- java.nio.file.Path 경로 표현 인터페이스
	- Path path = Paths.get("C:\\JavaStudy\\PathDemo.java");
	- Paths.get 메소드가 반환하는 '경로 정보를 담은 인스턴스'를 참조하는 참조변수 선언에 사용됨. 
```java
import java.nio.file.Path;
import java.nio.file.Paths;

public class PathDemo {
	public static void main(String[] args) {
		Path pt1 = Paths.get("C:\\Practice\\src\\ch32\\SBox.java");
		Path pt2 = pt1.getRoot();//루트 디렉토리 반환
		Path pt3 = pt2.getParent();//부모 디렉토리 반환
		Path pt4 = pt1.getFileName();//파일 이름 반환
		
		System.out.println("Absolute: " + pt1);
		//Absolute: C:\Practice\src\ch32\SBox.java
		System.out.println("Root: " + pt2);
		//Root: C:\
		System.out.println("Parent: " + pt3);
		//Parent: null
		System.out.println("File: " + pt4);
		//File: SBox.java
	}
}
```
* 현재 디렉토리
```java
public class CurrentDir {
	public static void main(String[] args) {
		Path cur = Paths.get("");//현재 디렉토리 정보 담긴 인스턴스 생성
		String cdir;
		
		if(cur.isAbsolute())
			cdir = cur.toString();
		else
			cdir = cur.toAbsolutePath().toString();
		
		System.out.println("Current dir: " + cdir);
	}
}
```
* 파일 및 디렉토리 생성과 소멸
```java
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

class MakeFileAndDir {
	public static void main(String[] args) throws IOException {
		Path fp = Paths.get("C:\\IT_Programs\\empty.txt");
		fp = Files.createFile(fp); //파일생성
		
		Path dp1 = Paths.get("C:\\IT_Programs\\Empty");
		dp1 = Files.createDirectory(dp1); //디렉토리 생성
		
		Path dp2 = Paths.get("C:\\IT_Programs\\Full");
		dp2 = Files.createDirectory(dp2);//경로의 모든 디렉토리 생성
		
		System.out.println("File: " + fp);
		System.out.println("Dir1: " + dp1);
		System.out.println("Dir2: " + dp2);
	}
```
* 파일을 대상으로 하는 간단한 입력 및 출력
```java
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;

class SimpleBinWriteRead {
	public static void main(String[] args) throws IOException {
		Path fp = Paths.get("C:\\IT_Programs\\Empty\\simple.bin");
		
		//파일 생성, 파일이 존재하면 예외 발생
		fp = Files.createFile(fp);
		
		byte buf1[] = {0x13, 0x14, 0x15}; //파일에 쓸 데이터
		for(byte b : buf1) // 저장할 데이터의 출력을 위한 반복문
			System.out.print(b + "\t");
		System.out.println();
		
		//파일에 데이터 쓰기
		Files.write(fp, buf1, StandardOpenOption.APPEND);//fp가 지시하는 파일에 배열 buf1의 데이터 전부가 저장됨!
		
		//파일로부터 데이터 읽기
		byte buf2[] = Files.readAllBytes(fp);
		
		for(byte b : buf2) // 읽어 들인 데이터의 출력을 위한 반복문
			System.out.print(b + "\t");
		System.out.println();
	}
}
```
* - APPEND: 파일의 끝에 데이터를 추가
* CREATE: 파일이 존재하지 않으면 생성함
* CREATE_NEW: 새 파일 생성. 이미 파일 존재시 예외
* TRUNCATE_EXISTING: 쓰기 위해 파일 여는데 파일이 존재하면 파일의 내용 덮어씀.

```java
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Arrays;
import java.util.List;

class SimpleTxtWriteRead {
	public static void main(String[] args) throws IOException {
		Path fp = Paths.get("C:\\IT_Programs\\Full\\simple.txt");
		String st1 = "One Simple String";
		String st2 = "Two Simple String";
		List<String> lst1 = Arrays.asList(st1, st2);
		// write 메소드의 두 번째 인자로 전달 가능
		Files.write(fp, lst1); //파일에 문자열 저장
		List<String> lst2 = Files.readAllLines(fp); //파일로부터 문자열 읽기
		System.out.println(lst2);
	}
}
```
* 파일 및 디렉토리의 복사와 이동
	- REPLACE_EXISTING: 이미 파일이 존재한다면 해당 파일을 대체함.
	- COPY_ATTRIBUTES: 파일의 속성까지 복사함
```java
//src가 지시하는 파일을 dst가 지시하는 위치와 이름으로 복사
Files.copy(src, dst, StandardCopyOption.REPLACE_EXISTING);

//src가 지시하는 디렉토리를 dst가 지시하는 디렉토리로 이동
Files.move(src, dst, StandardCopyOption.REPLACE_EXISTING);
```
### 33-2 NIO.2 기반의 I/O 스트림 생성
* Byte Stream의 생성
```
Path fp = Paths.get("data.dat");
InputStream in = Files.newInputStream(fp);
```
* 문자 스트림 생성
```
Path fp = Paths.get("String.txt");
BufferedWriter bw = Files.newBufferedWriter(fp);//버퍼링 하는 문자 출력 스트림 생성
```
### 33-3 NIO 기반의 입출력
* NIO의 채널(Channel)과 버퍼(Buffer)
	- 파일을 대상으로 하는 채널의 데이터 출력 경로: 데이터 -> 버퍼-> 채널 -> 파일
	- 파일을 대상으로 하는 채널의 데이터 입력 경로: 데이터 <- 버퍼 <- 채널 <- 파일
* File Random Access
- Position: 대상이 채널이건 버퍼 건 어느 위치까지 데이터를 썼는지, 어느 위치까지 데이터를 읽었는지 표시하기 위해 '포지션' 위치 정보 유지.
```java
import java.io.IOException;
import java.nio.ByteBuffer;
import java.nio.channels.FileChannel;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;

class FileRandomAccess {
	public static void main(String[] args) {
		Path fp = Paths.get("data.dat");
		
		//버퍼 생성, Non-direct 버퍼
		ByteBuffer wb = ByteBuffer.allocate(1024);
		//ByteBuffer.allocateDirect(1024); Direct 버퍼 생성 하면 VM 버퍼 거치지 않음.
		//버퍼에 데이터 저장
		wb.putInt(120);//int, 메소드 호출 후 포지션 4 
		wb.putInt(240);// 메소드 호출 후 포지션 8
		wb.putDouble(0.94); //실수 8 byte
		wb.putDouble(0.75);
		
		//하나의 채널 생성 (fp가 지시하는 파일의 내용을 생성,읽기,쓰기 위한 채널 생성)
		try(FileChannel fc = FileChannel.open(fp, 
							StandardOpenOption.CREATE,
							StandardOpenOption.READ,
							StandardOpenOption.WRITE)) {
			wb.flip();//메소드 호출 후 포지션 0
			fc.write(wb);//버퍼에서 fc로 데이터 전송 
			
			//파일로부터 읽기
			ByteBuffer rb = ByteBuffer.allocate(1024); //버퍼 생성
			fc.position(0); // 채널의 포지션을 맨 앞으로 이동
			fc.read(rb);
			
			//이하 버퍼로부터 데이터 읽기
			rb.flip();
			System.out.println(rb.getInt());
			rb.position(Integer.BYTES * 2); //버퍼의 포지션 이동
			System.out.println(rb.getDouble());
			System.out.println(rb.getDouble());
			
			rb.position(Integer.BYTES); //버퍼의 포지션 이동
			System.out.println(rb.getInt());
		} catch(IOException e) {
			e.printStackTrace();
		}
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
