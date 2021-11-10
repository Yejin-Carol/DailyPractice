//Objects
//one of JavaScript's data types.
//a colletion of related ata and/or functionality.
//Nearly all objects in JavaScript are instances of Object
//Object = {key : value};

//1. Literals and properties
const obj1 = {}; //'object literal' syntax
const obj2 = new Object(); //'object constructor' syntax

function print(person) {
  console.log(person.name);
  console.log(person.age);
}

const carol = { name: "carol", age: 10 };
print(carol);

//with Js magic (dynamically typed language)
//can add properties later
carol.hasJob = true;
console.log(carol.hasJob);

//can delete properties later
delete carol.hasJob;
console.log(carol.hasJob);

//2. Computed properties
console.log(carol.name); //코딩시
console.log(carol["name"]); //string 타입으로 해야함! runtime에 정해지는 것
carol["hasJob"] = true;
console.log(carol.hasJob);

function printValue(obj, key) {
  console.log(obj[key]); //동적으로 받아올 때
}
printValue(carol, "name");
printValue(carol, "age");

//3. Property value shorthand
const person1 = { name: "bob", age: 2 };
const person2 = { name: "steve", age: 3 };
const person3 = { name: "dave", age: 4 };
// const person4 = makePerson("carol", 20);
// console.log(person4);
// function makePerson(name, age) {
//   return {
//     name, //name: name key, value 이름 동일하면 하나로 shorthand 가능
//     age,
//   };
// }

const person4 = new Person("carol", 20);
console.log(person4);

//4. Constructor Function
function Person(name, age) {
  //this = {};
  this.name = name;
  this.age = age;
  //return this;
}

//5. in operator: property existence check (key in obj)
console.log("name" in carol);
console.log("age" in carol);
console.log("random" in carol);
console.log(carol.random);

//6. for..in vs for..of
//for (key in obj)
console.clear();
for (key in carol) {
  console.log(key);
}

//for (value of iterable)
const array = [1, 2, 4, 5];
// for(let i= 0; i< array.length; i++)
for (value of array) {
  console.log(value);
}

//7. Fun coding
//Object.assign(dest, [obj1, obj2, obj3,...])
const user = { name: "carol", age: "20" };
const user2 = user;
user2.name = "coder";
console.log(user);

//old way
const user3 = {};
for (key in user) {
  user3[key] = user[key];
}
console.clear();
console.log(user3);

//new
const user4 = Object.assign({}, user);
console.log(user4);

//example
const fruit1 = {color: 'red'};
const fruit2 = {color; 'blue', size: 'big'};
const mixed = Object.assign({}, fruit1, fruit2);//뒤에가 앞에거 덮어씀
console.log(mixed.color);
console.log(mixed.size);