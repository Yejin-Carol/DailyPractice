# Code Up 기초 문제 100제
## 문제 풀이 중 기억안나는 기초 개념 요약 


### DAY1 (1~24)

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
---
### DAY2 (25~41)

- 문제 6027 
  - 10진수 입력받아 16 진수(hexademical, %x)로 출력 
  - 참고로 %x = 소문자, %X = 대문자 출력
  - 16진수: 0 ~ 9, a, b, c, d, e, f 로 구성됨
  - 8진수는 octal, %o
 ```python
a = input()
num = int(a)
print('%x'% num)
 ```
- 문제 6029
  - 16진수 입력받아 8진수(octal)로 출력
```python
a = input()
n = int(a, 16)      #입력된 a를 16진수로 인식해 변수 n에 저장
print('%o' % n)  #n에 저장되어있는 값을 8진수(octal) 형태 문자열로 출력
```
- 문제 6030/31
   - n = ord(input())  #입력받은 문자를 10진수 유니코드 값으로 변환한 후, n에 저장
   - ord()는 어떤 문자의 순서 위치(ordinal position) 값 의미, 문자 -> 정수값 
   - (a = int(input(a)) chr()는 정수값 -> 문자 
   - 응용 6033: 문자 1개 입력받아 다음 문자로 출력
```python
 a = ord(input())
print(chr(a+1))
```
- 문제 6040
  - python언어에서는 나눈 몫을 계산하는 연산자(//, floor division)를 제공한다.
  - a//b 와 같이 작성하면, a를 b로 나눈 몫(quotient)을 계산

---
### DAY3 (42~62)
- 문제 6043
  - 실수 2개(f1, f2)를 입력받아 f1 을 f2 로 나눈 값 출력
  - 소숫점 넷째자리에서 반올림하여 무조건 소숫점 셋째 자리까지 출력
  - 두 줄 코드로 끝내려고 했는데 생각보다 잘 되지 않았고. .2f처럼 .3f 똑같이 하면 안됐음.
```python
f1, f2 = input().split()
d = float(f1)/float(f2)
print(f'{d:.3f}')
```
- 문제 6046/47
  - 시프트(<<, >>) 2의 거듭제곱
- 문제 6052/53/56
  - bool(): 입력값 0이면 False, 0 아니면 True
```python
a = bool(int(input()))
print(not a) #문제 53 bool 값 반대 
b, c = input().split()
d = bool(int(b))
e = bool(int(c))
print((c and (not d)) or ((not c) and d))#문제 56 XOR
#(exclusive or, 배타적 논리합, 참 거짓 서로 다를때만 True로 계산)
```
- 문제 6059~62
  - 비트 연산자 (~, &(and: 둘 다 1인 자리만 1로)6, |(or: 둘 중 하나가 1인 거는 1로), ^(xor: 둘 다 1인 것 0 즉 False) 

### DAY3 (63~95)
- 문제 6064
  - 3 숫자 중 작은 값
```python
a, b, c = input().split()
a = int(a) 
b = int(b)
c = int(c)
d = (a if a<b else b) if ((a if a<b else b)<c) else c
print(int(d))
```
- 문제 6094
  - 출석 번호를 n번 무작위로 불렀을 때, 가장 빠른 번호를 출력

```python
n = int(input()) 
a = input().split() 
for i in range(n) : 
	a[i] = int(a[i]) 
	
min = a[0] 
for i in range(0, n) : 
	if a[i] < min : 
		min = a[i] 
print(min)
```
- 문제 6095
  - 바둑판 흰 돌 놓기
```python
d=[]                   #대괄호 [ ] 를 이용해 아무것도 없는 빈 리스트 만들기
for i in range(20) :
  d.append([])         #리스트 안에 다른 리스트 추가해 넣기
  for j in range(20) : 
    d[i].append(0)    #리스트 안에 들어있는 리스트 안에 0 추가해 넣기

n = int(input())
for i in range(n) :
  x, y = input().split()
  d[int(x)][int(y)] = 1

for i in range(1, 20) :
  for j in range(1, 20) : 
    print(d[i][j], end=' ')    #공백을 두고 한 줄로 출력
  print()     
```
- 문제 6096
  - 바둑알 십자 뒤집기
```python
d=[]                        #대괄호 [ ] 를 이용해 아무것도 없는 빈 리스트 만들기
for i in range(20) :
  d.append([])         #리스트 안에 다른 리스트 추가해 넣기
  for j in range(20) : 
    d[i].append(0)   

for i in range(19) :
	d[i] = list(map(int, input().split()))

n = int(input())
for i in range(n) :
  x, y = map(int, input().split())
  for j in range(19) :
    if d[j][y-1] == 0 :
      d[j][y-1] = 1
    else :
      d[j][y-1] = 0

    if d[x-1][j] == 0 :
      d[x-1][j] = 1
    else :
      d[x-1][j] = 0

for i in range(19) :
  for j in range(19) :
    print(d[i][j], end = ' ')
  print()
```
- 문제 6097
  - 설탕과자 뽑기
```python
t().split()) #가로, 세로
n = int(input()) #막대수 입력받기

sugar = []

for i in range(h+1): #판 생성
  sugar.append([])
  for j in range(w+1):
    sugar[i].append(0)  

for i in range(n) :
  l, d, x, y = map(int, input().split()) #막대 정보 입력
  for i in range(l) :
    if d == 0 : # 가로 막대
      sugar[x][y+i] = 1
    else :# 세로 막대
      sugar[x+i][y] = 1

for i in range(1, h+1) :
  for j in range(1, w+1) : 
    print(sugar[i][j], end=' ')    #공백을 두고 한 줄로 출력
  print() #줄바꿈    
```
- 문제 6098
  - 성실한 개미 2차 배열 문제
```python
da = [] #da=diligent ant
x = 1
y = 1

# 2차배열 input
for i in range(10):
    temp = list(map(int,input().split()))
    da.append(temp)
    
while True:
    if da[x][y] == 2: #먹이를 발견했을때
        da[x][y] = 9
        break
    elif da[x+1][y] == 1 and da[x][y+1] == 1:
        da[x][y] = 9
        break
    da[x][y] = 9
    if da[x][y+1] == 1: # 오른쪽이 벽이면 아래로 1칸
        x += 1
    elif da[x+1][y] == 1: # 아래쪽이 벽이면 오른쪽으로 1칸
        y += 1
    else: y += 1 # 주변에 벽이 없으면 오른쪽으로 1칸

for i in da:
    for j in i:
        print(j,end=' ')
    print()
 ```
