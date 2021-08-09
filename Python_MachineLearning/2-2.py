import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.neighbors import KNeighborsClassifier
import matplotlib.pyplot as plt

#bream 도미 35
#smelt 빙어 14
# 큰 물고기인지 작은 물고기인지 판별해주는 프로그램
fish_length = [25.4, 26.3, 26.5, 29.0, 29.0, 29.7, 29.7, 30.0, 30.0, 30.7, 31.0, 31.0,
                31.5, 32.0, 32.0, 32.0, 33.0, 33.0, 33.5, 33.5, 34.0, 34.0, 34.5, 35.0,
                35.0, 35.0, 35.0, 36.0, 36.0, 37.0, 38.5, 38.5, 39.5, 41.0, 41.0, 9.8,
                10.5, 10.6, 11.0, 11.2, 11.3, 11.8, 11.8, 12.0, 12.2, 12.4, 13.0, 14.3, 15.0]
fish_weight = [242.0, 290.0, 340.0, 363.0, 430.0, 450.0, 500.0, 390.0, 450.0, 500.0, 475.0, 500.0,
                500.0, 340.0, 600.0, 600.0, 700.0, 700.0, 610.0, 650.0, 575.0, 685.0, 620.0, 680.0,
                700.0, 725.0, 720.0, 714.0, 850.0, 1000.0, 920.0, 955.0, 925.0, 975.0, 950.0, 6.7,
                7.5, 7.0, 9.7, 9.8, 8.7, 10.0, 9.9, 9.8, 12.2, 13.4, 12.2, 19.7, 19.9]

#fish_length = np.array(fish_length)
fish_data = np.column_stack([fish_length, fish_weight])
# print(fish_data[:5])
# [1]*35 + [0]*14
fish_target = np.concatenate((np.ones(35), np.zeros(14)))
#print(fish_target)

train_input,test_input,train_target,test_target = train_test_split(fish_data,fish_target, random_state=42)

# print(train_input.shape)
# print(test_input.shape)

#plt.scatter(train_input[:,0],train_input[:,1])
#plt.scatter(test_input[:,0],test_input[:,1])
plt.xlabel('length')
plt.ylabel('weight')


knclf = KNeighborsClassifier()
knclf.fit(train_input, train_target)
knclf.score(test_input, test_target)


print(knclf.predict([[25,150]]))


# plt.show()
#
# def doa():
#     return 1,2,3,4,5
#
# a,b,c,d,e = doa()
#
# print(a)
# print(b)

#표준편차로 변경

#distances, indexes = knclf.kneighbors([[25, 150]])

#plt.scatter(train_input[indexes,0],train_input[indexes,1], marker='D')
#plt.xlim((0, 1000))

mean = np.mean(train_input, axis=0) #훈련데이터 평균값
std = np.std(train_input, axis=0) #표준점수..

train_scaled = (train_input - mean) / std

new = ([25,150]-mean)/std
print(new[0],new[1])

plt.scatter(new[0],new[1],marker='^')

plt.scatter(train_scaled[:,0],train_scaled[:,1])
#plt.show()

'''
[100,200,300] / 100 = [1,2,3]
[[100,200],[300,400],[500,600]]/100 = [[1,2],[3,4],[5,6]]
'''
# print(distances)
# print(indexes)

#5가 보통 기본값
knclf = KNeighborsClassifier(n_neighbors=5)
knclf.fit(train_scaled,train_target)

distances, indexes = knclf.kneighbors([new])
plt.scatter(train_scaled[indexes,0],train_scaled[indexes,1])
plt.show()

prevalues = knclf.predict([new])
print(prevalues)


'''
    train_test_split -> 셔플로 훈련데이터랑 테스트데이터 
    1, 10 -> 1
    2, 20 -> 1
    3, 30 -> 1
    0, 5 -> 0
    0, 1 -> 0

    (실제데이터-평균값)/표준점수
        
    x좌표축의 데이터 범위와 y 좌표축의 데이터범위가 다를 때에는
    데이터 전처리
    표준점수로 구해주어야 한다. 
    
    train_scaled -> 표준점수 나온 훈련데이터
    kneighborsclassfier 학습기에다가 학습시켜
    neighbors() 제일가까운 좌표 5개 구합니다.
    5개 데이터를 그래프에다가 시각화 합시다.
'''



