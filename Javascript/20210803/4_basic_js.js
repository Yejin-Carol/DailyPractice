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

//js에서는 자동으로 메모리 할당
let array = []

//객체
let obj = //JSON(javascript object notation)
{
    name : "54", //왼쪽: property(속성), 오른쪽: 값(value)
    age: 5,
    "직업": "가수",
    123: "속성에 숫자 가능",
    _: "언더바도 가능",
    "!": "특수문자도 가능"
}

console.log(obj)
console.log(obj.name)
console.log(obj.age)
console.log(obj.직업)
console.log(obj[123])
console.log(obj._)
console.log(obj["!"])


//객체 속성 제거
delete obj[123]
console.log(obj)
//객체 속성 추가 - 그냥 추가하면 됨
obj.gender = "femle"

console.log(obj)



console.log("순서 헷갈리나요")
let arraybaby = []
console.log(arraybaby)
arraybaby[4] = 400
console.log(arraybaby)
arraybaby[9] = 900
console.log(arraybaby)


//객체에 대해서도 순서에 대한 논란
var bts = {}
console.log(bts)
bts.v = "뷔"
console.log(bts)
bts.rm = "알엠"
console.log(bts)
bts.jin = "진"
console.log(bts)
bts.suga = "슈가"
console.log(bts)
bts.members = 6
console.log(bts)
delete bts.suga
console.log(bts)

//생성자 (특이함)
//Student 객체 만들기
function Student(name, age, regNo)
{
    this.name = name
    this.age = age
    this.regNo = regNo
    this.Sleep = function()
    {
        console.log("ZZZZ")
    }
}


Student.prototype.DoStudy = function()
{
    alert("오늘도 즐거운 하루입니다. 열공하세요")
}

const bt = new Student('정국', 24, '20003123')
const sb = new Student('알엠', 28, '20001212')
console.log(bt)
console.log(bt.name)
console.log(bt.age)
console.log(bt.regNo)
bt.DoStudy
console.log(sb)
console.log(sb.name)
console.log(sb.age)
console.log(sb.regNo)
sb.DoStudy
bt.Sleep()
sb.Sleep()
