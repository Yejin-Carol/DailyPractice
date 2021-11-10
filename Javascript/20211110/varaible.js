//js is very flexible = dangerous
//1. Use strict
//added ECMAScript 5
'use strict';
console.log('Hello World');

//2. Varaible, rw(read/write)
//let (added in ES6)
let globalName = 'global name';
{
    let name = 'carol';
    console.log(name);
    name = 'hello';
    console.log(name);
}
console.log(name);
console.log(globalName);

//Don't use VAR, var hoisting, has no block scope
{
    age = 4;
    var age;
}

//3. Constants (<-> Mutable type let!), r(read only)
//use const whenever possible. only use let if variable needs to change.
//favor immutable data type always for a few reasons:
//-security, thread safety, reduce human mistakes
const daysInWeek = 7;
const maxNumber = 5;

//Note!
//Immutable data types: premitive types, frozen objects (i.e. object.freeze()): 변경 불가!
//Mutable data types: all objects by default are mutable in JS (기본적으로 대부분 객체 변경 가능)
//4. Variable types
//primitive, single item: number, string, boolean, null, undefined, symbol
//objet (reference), box container
//function, first-class function

const count = 17;//integer
const size =  17.1;//decimal number
console.log(`value: ${count}, type: ${typeof count}`);
console.log(`value: ${size}, type: ${typeof size}`);

//number - speical numeric values: infinity, -infinity, NaN

const infinity = 1 / 0;
const negativeInfinity = -1 / 0;
const nAn = 'not a number' / 2;
console.log(infinity);
console.log(negativeInfinity);
console.log(nAn);

//bigInt (fiarly new, don't use it yet)
const bigInt = 12345678213254364576576854434324331232543657n;
console.log(`value: ${bigInt}, type: ${typeof bigInt}`);

//string
const char = 'c';
const carol = 'carol';
const greeting = 'hello ' + carol;
console.log(`value: ${greeting}, type: ${typeof greeting}`);
const helloB = `hi ${carol}!`; //template literals (string)
console.log(`value: ${helloB}, type: ${typeof helloB}`);

//boolean
//false: 0, null, undefined, NaN, ''
//true: any other vlaues
const canRead = true;
const test = 3 < 1; //false
console.log(`value: ${canRead}, type: ${typeof canRead}`);
console.log(`value: ${test}, type: ${typeof test}`);

//null
let nothing = null;
console.log(`value: ${nothing}, type: ${typeof nothing}`);

//undefined
let x;
console.log(`value: ${x}, type: ${typeof x}`);

//symbol, create unique identifiers for objects (고유한 식별자 만들때 사용)
const symbol1 = Symbol('id');
const symbol2 = Symbol('id');
console.log(symbol1 === symbol2);
//똑같은거 만들때 Symbol.for
const gSymbol1 = Symbol.for('id');
const gSymbol2 = Symbol.for('id');
console.log(gSymbol1 === gSymbol2);//true
console.log(`value: ${symbol1.description}, type: ${typeof symbol1}`);

//object, real-life object, data structure
const who = {name: 'carol', age:20};
who.age = 21;


//5. Dynamic typing: dynamically typed language! 
let text = 'hello';
console.log(text.charAt(0));//h
console.log(`value: ${text}, type: ${typeof text}`);
text = 1;
console.log(`value: ${text}, type: ${typeof text}`);
text = '7' + 5;
console.log(`value: ${text}, type: ${typeof text}`);//automatically string
text = '8' /'2';
console.log(`value: ${text}, type: ${typeof text}`);//automatically number
console.log(text.charAt(0));//Typeerror - > that's why TS came out!