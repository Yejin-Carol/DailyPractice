//Q1. make a string out of an array
{
  const fruits = ["apple", "banana", "orange"];
  const result = fruits.join(",");
  console.log(result);
}

//Q2. make an array out of a string
{
  const fruits = "🍎, 🥝, 🍌, 🍒";
  const result = fruits.split(",");
  console.log(result);
}
//Q3. make this array reverse
{
  const array = [1, 2, 3, 4, 5];
  const result = array.reverse(",");
  console.log(result);
  console.log(array); //array까지 reverse함!
}
//Q4. make new array without the first two elements (splice vs slice)
{
  const array = [1, 2, 3, 4, 5];
  //   const result = array.splice(0, 2); //array 자체 변경이 아닌 새로운 array만드는 것
  const result = array.slice(2, 5); //slice: This is exclusive of the element at the index 'end'
  console.log(result);
  console.log(array);
}

//Q5~
class Student {
  constructor(name, age, enrolled, score) {
    this.name = name;
    this.age = age;
    this.enrolled = enrolled;
    this.score = score;
  }
}
const students = [
  new Student("A", 29, true, 45),
  new Student("B", 28, false, 80),
  new Student("C", 30, true, 90),
  new Student("D", 40, false, 66),
  new Student("E", 18, true, 88),
];
//Q5. find a student with the score 90
{
  //   const result = students.find(function (student, index) {
  //     return student.score === 90; //한 줄로~
  const result = students.find((student) => student.score === 90);
  console.log(result);
}
//Q6. make an array of enrolled students
{
  const result = students.filter((student) => student.enrolled);
  console.log(result);
}
console.clear();
//Q7. make an array containing only the students' scores result should be: [45 ,80, 90, 66, 88]
{
  const result = students.map((student) => student.score);
  console.log(result);
}
console.clear();
//Q8. check if there is a student with the score lower than 50
{
  const result = students.some((student) => student.score < 50);
  console.log(result);

  const result2 = !students.every((student) => student.score <= 50);
  console.log(result2);
}
console.clear();
//Q9. compute students' average score
// {
//   const result = students.reduce((prev, curr) => {
//     console.log("--------");
//     console.log(prev);
//     console.log(curr);
//     return prev + curr.score;
//   }, 0); //간단하게
{
  const result = students.reduce((prev, curr) => prev + curr.score, 0);
  console.log(result / students.length);
}
console.clear();
//Q10. make a string containing all the scores result should be: 45, 80, 90, 66 88
{
  const result = students
    .map((student) => student.score) //점수로 변환
    //.filter((score) => score >=50)//50점 이상인 값만 출력
    .join();
  console.log(result);
}
console.clear();
//Bonus do Q10 sorted in ascending order, result should be: '45, 66, 80, 88, 90'
{
  const result = students
    .map((student) => student.score) //점수로 변환
    .sort((a, b) => a - b) //desc b-a
    .join();
  console.log(result);
}
