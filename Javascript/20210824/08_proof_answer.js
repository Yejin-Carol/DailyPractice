//로직의 잘못된 점 개선, 타이틀 해당하는 부분 색깔칠하기
document.addEventListener('DOMContentLoaded',
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
    
    for(let i = 0; i<numArr.length; i++)
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
    }
    //색깔칠하기
    //document.querySelector('h1:last-child').style.background = 'yellow'


     document.querySelector('h1.num'+maxIndex).setAttribute('class', 'max')
     document.querySelector('h2.num'+maxIndex).setAttribute('class', 'max')
     document.getElementsByTagName('h1')[0].style.color = 'pink'
     document.getElementsByTagName('h1')[2].style.color = 'pink'
     document.getElementsByTagName('h1')[4].style.color = 'pink'
     document.getElementsByTagName('h1')[6].style.color = 'pink'
     document.getElementsByTagName('h1')[8].style.color = 'pink'
     document.getElementsByTagName('h1')[10].style.color = 'pink'
     
    }
)