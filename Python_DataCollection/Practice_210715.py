
import pandas as pd

dict_data = {'a':1, 'b':2, 'c':3}
sr=pd.Series(dict_data)
print(type(sr))
print('\n')
print(sr[[0]])

list_data = ['2021-07-15', 3.14, 'ABC', 100, True]
sr = pd.Series(list_data)
print(sr.index)
print(sr.values)


data = ("Carol",'2021-07-15','여',False)
sr=pd.Series(data, index=['이름','생년월일','성별', '학생여부'])
print(sr[[1, 2]])
print(sr[['생년월일', '성별' ]])

dict_data={'c0':[1, 2, 3], 'c1':[4,5,6], 'c2':[7,8,9], 'c3':[10,11,12], 'c4':[13,14,15]}
df = pd.DataFrame(dict_data)
print(type(df))
print('\n')
print(df)


df = pd.DataFrame([[15, '남', '덕영중'], [17, '여', '수리중']],
                  index = ['준서', '예은'],
                  columns=['나이','성별','학교'])
df1 = df
df.rename(columns={'나이':'연령','성별':'남녀','학교':'소속'},inplace=True)
df.rename(index={'준서':'학생1','예은':'학생2'},inplace=True)
print(df)
print(df1)


exam_data = {'수학':[90,80,70],'영어':[98,89,95],
             '음악':[85,95,100], '체육':[100,90,80]}

df=pd.DataFrame(exam_data, index=['서준','우현','인아'])
print(df)
print('\n')

#행삭제
#1. 우현 삭제
df1 = df[:]
df1.drop('우현', inplace=True)
print(df1)
print('\n')

#2. 서준만
df2 = df[:]
df2.drop(['우현','인아'],axis=0, inplace=True)
print(df2)
print('\n')

#열 삭제

df3 = df[:]
df3.drop(['수학'], axis=1, inplace=True)
print(df3)
print('\n')

df4= df[:]
df4.drop(['수학','체육'], axis=1, inplace=True)
print(df4)
print('\n')


#랭킹 뉴스 csv 파일 생성

import requests
from bs4 import BeautifulSoup
import pandas as pd

req = requests.get('http://media.daum.net/ranking/popular/')
html = req.text
soup = BeautifulSoup(html, 'html.parser')
newstitle = soup.select('a.link_txt')
newscomname = soup.select('.info_news')

lst1 = []
lst2 = []


for i in range(len(newscomname)):
    lst1.append(newscomname[i].text.strip())
    lst2.append(newstitle[i].text.strip())

result_file = pd.DataFrame({'newstitle':lst2, 'newscomname':lst1})
result_file.to_csv("C:\\Users\\KB\\Documents\\Carol\\result.csv", index=False, encoding='euc-kr')



req = requests.get('http://www.kyobobook.co.kr/bestSellerNew/bestseller.laf?orderClick=d79')
html = req.text
soup = BeautifulSoup(html, 'html.parser')

bookranking = soup.select('strong.rank')
booktitle = soup.select('strong')
author = soup.select('div.author')

lst1 = []
lst2 = []
lst3 = []

for i in range(len(bookranking)):
    lst1.append(bookranking[i].text.strip())
    lst2.append(booktitle[i].text.strip())
    lst3.append(author[i].text.strip())

result_file = pd.DataFrame({'bookranking':lst1, 'booktitle':lst2, 'author':lst3})
print(result_file)
result_file.to_csv("C:\\Users\\KB\\Documents\\Carol\\book.csv", index=False, encoding='euc-kr')
