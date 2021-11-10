// Function: fundamental building block in the program
//subprogram can be used multiple times
//performs a task or calculates a value
//1. Function declaration
//function name(param1, param2) {body..return;}
//one function === one thing
//naming: doSomething, command, verb
//e.g. createCardAndPoint -> createCard, createPoint
//function is object in JS 함수는 객체의 일종!

function printHello() {
  console.log("Hello");
}
printHello();

//TypeScript (타입 표시!)
//function log(message: string): number {
//} return 0;

function log(message) {
  console.log(message);
}
log("Hello@");
log(1234);

//2. Parameters
//premitive parameters: passed by value
//object parameters: passed by reference
function changeName(obj) {
  obj.name = "coder";
}
const carol = { name: "carol" };
changeName(carol);
console.log(carol);

//3. Default parameters (added in ES6)
function showMessage(message, from = "unknown") {
  // if(from === undefined) {
  //     from = 'unknown'
  console.log(`${message} by ${from}`);
}
showMessage("Hi");

//4. Rest parameters ...(added in ES6)
function printAll(...args) {
  for (let i = 0; i < args.length; i++) {
    console.log(args[i]);
  }

  for (const arg of args) {
    console.log(arg);
  }

  args.forEach((arg) => console.log(arg));
}
printAll("feliz", "coding", "carol");

//5. Local sope
//밖에서는 안이 보이지 않고, 안에서만 밖을 볼 수 있다.
let globalMessage = "global"; //global variable
function printMessage() {
  let message = "hello";
  console.log(message); //local variable
  console.log(globalMessage);
  function printAnother() {
    console.log(message);
    let childMessage = "hello";
  }
  //console.log(childMessage); //error
}
printMessage();

//6. Return a value
function sum(a, b) {
  return a + b;
}
const result = sum(1, 2); //3
console.log(`sum: ${sum(1, 2)}`);

//7. Early return, early exit
//bad
function upgradeUser(user) {
  if (user.point > 10) {
    //long upgrade logic...
  }
}
//good
function upgradeUser(user) {
  if (user.point <= 10) {
    return;
  }
  //long upgrade logic...
}

//First-class function
// functions are treated like any other variable
// can be assigned as a vaclue to variable
// can be passed as an argument to other functions.
// can be returned by another fucntion
// 1. Function expression
// a function declaration can be called earlier than it is defined. (hoisted)
// a function epxression is created when the execution reaches it.

const print = function () {
  //anonymous function
  console.log("print");
};
print();
const printAgain = print;
printAgain();
const sumAgain = sum;
console.log(sumAgain(1, 3));

//2. Callback function using function expression
function randomQuiz(answer, printYes, printNo) {
  if (answer === "love you") {
    printYes();
  } else {
    printNo();
  }
}
//anonymous function
const printYes = function () {
  console.log("yes!");
};

//named function
//better debugging in debugger's stack traces
//recursions
const printNo = function print() {
  console.log("no!");
};

randomQuiz("wrong", printYes, printNo);
randomQuiz("love you", printYes, printNo);

//Arrow funtion
//always anonymous
const simplePrint = function () {
  console.log("simplePrint!");
};

const simplePrint1 = () => console.log("simplePrint1!");
const add = (a, b) => a + b;
const simpleMultiply = (a, b) => {
  //do something more
  return a * b;
};

// IIFE: Immediately Invoked Function Expression
(function hello() {
  console.log("IIFE");
})();

//Quiz
function calculate(command, a, b) {
  if (command === "add") {
    console.log(a + b);
  }
  if (command === "substract") {
    console.log(a - b);
  }
  if (command === "divie") {
    console.log(a / b);
  }
  if (command === "multiply") {
    console.log(a * b);
  }
  if (command === "remainder") {
    console.log(a % b);
  }
}

calculate("multiply", 3, 5);
calculate("remainder", 4, 3);

//정해진 경우 switch문이 더 좋음
function calculate_better(command, a, b) {
  switch (command) {
    case "add":
      return a + b;
    case "substract":
      return a - b;
    case "divide":
      return a / b;
    case "multiply":
      return a * b;
    case "remainder":
      return a % b;
    default:
      throw Error("unknown command");
  }
}
console.log(calculate("add", 2, 3));
