#  Java Review - DAY 8
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
