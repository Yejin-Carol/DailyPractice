//로직의 잘못된 점 개선, 타이틀 해당하는 부분 색깔칠하기
document.addEventListener('DOMContentLoaded', //웹페이지가 실행될 때 중괄호 안에거 실행하겠음
()=>
{
    let BigCount = prompt("대수의 법칙을 증명할 수는?", 1000)
    let numArr = [0,0,0,0,0,0]
    //for문을 돌면서 계속 태그에 글자를 적을 예정
    for(let i = 0; i<BigCount; i++)
    {
        // 0이상 6미만의 값을 넣는다.
        let random = Math.floor(Math.random()*6)
        numArr[random]++ 
        //배열 인덱스는 0부터 시작..
        //random이 0이 나와서 numArr 0번째 값에 1을 더하게 되면
        //주사위 던져서 1이 나온 것과 똑같은 효과
    }
    //6칸짜리 배열에 숫자가 잘 나오는 것 확인 
    console.log(numArr)
    
    for(let i = 0; i<numArr.length; i++)//배열의 길이 만큼(6) for문 돌아감
    {
        document.querySelector('h1.num'+(i+1)).innerText = numArr[i]
    }


    //가장 큰 숫자에 대하여 색깔도 칠하고 각각의 숫자에 대한 확률도 적어보자.
    let max = numArr[0]
    let maxIndex = 0

    for(let i = 1; i<=6; i++)
    {
        if(max<numArr[i])
        {
            max = numArr[i]
            maxIndex = i
        }
        value = (value/BigCount) * 100
        document.querySelector('h2.num' + i).innerText = parseFloat(value).toFixed(2)+'%'
    }
    //색깔칠하기
    //document.querySelector('h1:last-child').style.background = 'yellow'
    //태그에 직접 스타일 주는게 우선순위가 높음. 클래스 주는 거 먼저 배치후 그 밑에 태그에 직접 스타일 주는 것 배치함.


     document.querySelector('h1.numTitle'+maxIndex).setAttribute('class', 'max')
     document.querySelector('h1.num'+maxIndex).setAttribute('class', 'max')
     document.querySelector('h2.num'+maxIndex).setAttribute('class', 'max')

     let list = document.querySelectorAll('h1')
    for(let i = 1; i<=list.length; i++)
    {
        if(i%2 == 1)
        document.querySelector(`h1:nth-of-type(${i})`).style.background = 'yellow'
    }
    
    }
)