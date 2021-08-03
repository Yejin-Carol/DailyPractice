var test1 = '안녕'
let test2 = "안녕"
test3 = "헐"
console.log(test3)

console.log('안녕 "이동준" 학생')
console.log("안녕 '이동준' 학생")
console.log("안녕 \"이동준\" 학생")
console.log('안녕 \'이동준\' 학생')

//참고... var나 let 없이도 변수가 선언은 된다.
//하지만 공식 문서에 표기된 내용은 아니므로 비권장사항
let test = 100

test = [] //한 칸도 없는 배열

console.log(test.length)

test[5] = 100    
test[10] = 111

console.log(test)
console.log(test[5])

for(var i = 0; i<test.length; i++)
{
    console.log(i+"="+test[i])
}

test = [1,2,3,"문자열", function(){console.log("hey")}]
for(var i = 0; i<test.length; i++)
{
    console.log(i+"="+test[i])
}

//배열에 저장된 함수 호출
test[4]()


//자바스크립트는 배열이 유동적이므로 아래와 같이 보통... 선언한다.
let array = [] 

//객체 
let obj =
{
    name : "이동준", //왼쪽 : propery(속성)  오른쪽: 값(value)
    age : 33,
    "직업" : "선생님",
    777 : "속성에 숫자도 가능",
    _ : "언더바도 됩니다.",
    "!" : "이렇게 이상한 것도 들어감"
}

console.log(obj)
console.log(obj.name)
console.log(obj.age)
console.log(obj["직업"])
console.log(obj.직업)
console.log(obj["!"])
//객체 속성 제거
delete obj["777"] 
console.log(obj)
//객체 속성 추가 - 그냥 추가하면 됨.
obj.gender = "남성"
console.log(obj)



//순서에 대한 논란
console.log("순서에 대해서 다들 좀 헷갈려 하시니 정리해봅시다.")
let arraybaby = []
console.log(arraybaby)
arraybaby[4] = 400
console.log(arraybaby)
arraybaby[9] = 900
console.log(arraybaby)
//객체에 대해서도 순서에 대한 논란
var 객체 = {}
console.log(객체)
객체.게임하는사람 = "이재혁"
console.log(객체)
객체.반장 = "박정민"
console.log(객체)
객체.담임 = "이나겸"
console.log(객체)
객체.붕어 = "이동준"
console.log(객체)
객체.인원수 = 22
console.log(객체)
delete 객체.붕어
console.log(객체)

객체.name = "603호"
객체.평균연령 = 40
객체.종족 = "인간"
평균