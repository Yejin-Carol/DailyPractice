# Code Up 기초 문제 100제

## DAY1

- 문제 6007 특수문자 입력시 헷갈리지 말 것!
  * "C:\Download\'hello'.py" 출력하기
``` python
print('"C:\\Download\\\'hello\'.py"')
```

- 문제 6008 
  * print("Hello\nWorld") 출력하기
```python 
print('print("Hello\\nWorld")')
```
- 문제 6015 
  * 공백을 두고 문자(character) 2개를 입력받아 순서를 바꿔 출력
  * 참고로 python 입력 정수, 실수, 문자 타입 지정없이 다 받을 수 있음
```python
a, b = input().split() # input과 split 한꺼번에 사용!
print(b, a)
```
- 문제 6019
 * 연도.월.일"을 입력받아 "일-월-연도" 순서로 바꿔 출력 (프른트 순서 눈크게 뜨고!)
```python
year, month, day  = input().split('.') #2021.10.04 입력
print(day, month, year, sep='-') #04-10-2021 출력
```

- 문제 6021
  * 알파벳과 숫자로 이루어진 단어 1개가 입력된다. 입력받은 단어의 각 문자를 한 줄에 한 문자씩 분리해 출력
 ```python
 word = input()
for letter in word:
	print(letter)
 ```
 
 - 문제 6022 
  * 6자리의 연월일(YYMMDD)을 입력받아 나누어 출력
 ```python
 birth = input()
print(birth[0:2], birth[2:4], birth[4:6]) 



```
