import matplotlib.pyplot as plt
from flask import Flask, render_template, request  # html 활용위해
from sklearn.neighbors import KNeighborsClassifier

app = Flask(__name__)  # 객체 생성 Fask app new Flask(__name__)이랑 비슷함

# bream = 도미
bream_length = [25.4, 26.3, 26.5, 29.0, 29.0, 29.7, 29.7, 30.0, 30.0, 30.7, 31.0, 31.0, 31.5, 32.0, 32.0, 32.0, 33.0,
                33.0,
                33.5, 33.5, 34.0, 34.0, 34.5, 35.0, 35.0, 35.0, 35.0, 36.0, 36.0, 37.0, 38.5, 38.5, 39.5, 41.0, 41.0]
bream_weight = [242.0, 290.0, 340.0, 363.0, 430.0, 450.0, 500.0, 390.0, 450.0, 500.0, 475.0, 500.0, 500.0, 340.0, 600.0,
                600.0, 700.0, 700.0, 610.0, 650.0, 575.0, 685.0, 620.0, 680.0, 700.0, 725.0, 720.0, 714.0, 850.0,
                1000.0, 920.0, 955.0, 925.0, 975.0, 950.0]

# shift + d 한줄 삭제
# 실행 단축키 shift + F10 or ctrl+shift + F10
# python flask django
# java jsp spring

# smelt = 빙어
smelt_length = [9.8, 10.5, 10.6, 11.0, 11.2, 11.3, 11.8, 11.8, 12.0, 12.2, 12.4, 13.0, 14.3, 15.0]
smelt_weight = [6.7, 7.5, 7.0, 9.7, 9.8, 8.7, 10.0, 9.9, 9.8, 12.2, 13.4, 12.2, 19.7, 19.9]
plt.scatter(bream_length, bream_weight, marker='d', c='b')  # 산점도
plt.scatter(smelt_length, smelt_weight, marker='*', c='r')
plt.scatter([30, 10], [600, 20], marker='^')  # 여러개 배열로 넣으면 됨.
plt.xlabel('length')
plt.ylabel('weight')
plt.savefig('static/bream.png')
plt.close()
#  plt.show()
length = bream_length + smelt_length
weight = bream_weight + smelt_weight

fish_data = [[l, w] for l, w in zip(length, weight)]  # 리스트 내포
# print(fish_data[:5])  # [:5] 슬라이싱 문법으로 앞에서 5개만 보여주세요!

fish_target = [1] * 35 + [0] * 14  # bream 35마리[1], smetl 14마리[0]에 대해 binary classification 이진 분류

# print(fish_target[-2:-1])  # 뒤에서 2~1개

# 여기까지 데이터 전처리

knc = KNeighborsClassifier()  # k-최근접 이웃
# 학습 진행하세요. fit! 외워두기! 예측: predict, 점수확인: score
knc.fit(fish_data, fish_target)
predictive = knc.predict([[30, 600], [10, 20]])
print('예측치 = ', predictive)
# kn49 = KNeighborsClassifier(n_neighbors=49) hyber parameter

@app.route("/") #데코레이터 문법
def home():  # route에 왔을때 "즐거운 하루입니다." return
    # global bream_length, bream_weight, smelt_length, smelt_weight
    inlength = request.args.get('length', default='0')
    inweight = request.args.get('weight', default='0')
    print('inlenght', inlength)
    print('inweight', inweight)
    prevalue = knc.predict([[int(inlength),int(inweight)]])
    print('prevalue', prevalue)
    str = 'bream'
    if prevalue == 1:
        str = 'bream'
    else:
        str = 'smelt'
    print(bream_length)
    plt.scatter(bream_length, bream_weight, marker='*', c='r')  # 산점도
    plt.scatter(smelt_length, smelt_weight, marker='D', c='b')
    plt.scatter(int(inlength), int(inweight), marker='^', c='green')
    plt.xlabel('length')
    plt.ylabel('weight')
    plt.savefig('static/bream.png')
    plt.close()
    return render_template("index.html", prevalue=str) #진자방식? timeif방식?


@app.route("/aa")  # aa 경로에 들어로 때는 aa.html
def aa():
    return render_template("aa.html")

app.run(host="0.0.0.0", port="10000")  # tomcat 실행처럼 사용자가 url 켜고 들어오는 것 처럼 기다림.
