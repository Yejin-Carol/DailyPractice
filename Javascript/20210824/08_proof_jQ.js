//$(document).ready() document생략
//$().ready(
$(
function()
    {
        let BigCount = prompt("대수의 법칙을 증명할 수는?", 1000)
        let numArr = [0,0,0,0,0,0]
        //for문을 돌면서 계속 태그에 글자를 적을 예정
       for(let i = 0; i<BigCount; i++)
       {
           let random = Math.floor(Math.random()*6)
           numArr[random]++ 
       }
    //가장 큰 숫자에 대하여 색깔도 칠하고 각각의 숫자에 대한 확률도 적어보자.
      //6칸짜리 배열에 숫자가 잘 나오는 것 확인 
      console.log(numArr)
    
      for(let i = 0; i<numArr.length; i++)
      {
          $('h1.num'+(i+1)).text(numArr[i])
            // document.querySelector('h1.num'+(i+1)).innerText = numArr[i]
      }
  
  
      //가장 큰 숫자에 대하여 색깔도 칠하고 각각의 숫자에 대한 확률도 적어보자.
      let max = numArr[0]
      let maxIndex = 0
  
      for(let i = 1; i<=6; i++)
      {
        let value = $('h1.num'+i).text()
        if(max<value)
          {
              max = numArr[i]
              maxIndex = i
          }
          value=(value/BigCount) * 100
          $('h2.num'+1).text(parseFloat(value).toFixed(2)+'%')
      }
        $('h1.numTitle'+maxIndex).addClass('max')
        $('h1.num'+maxIndex).addClass('max')
        $('h1.num'+maxIndex).addClass('max')
    }
)