#!/usr/bin/env python
# coding: utf-8

# In[94]:


import requests 
from bs4 import BeautifulSoup


# In[95]:


url = "https://ncv.kdca.go.kr/mainStatus.es?mid=a11702000000"
htmlText = requests.get(url).text
bsoup = BeautifulSoup(htmlText, "html.parser")
btab = bsoup.find_all("tbody")
btrs = btab[1].find_all("tr")
# btrs = btab.find_all("tbody")
# btdcols = btrs[3].find_all("th")
# btds = btrs[3].find_all("td")


# In[96]:


vaccine = []

for td in btrs[1:] :
    dic= {}
    tds = td.find_all("th")
    tdr = td.find_all("td")
    dic['city'] = tds[0].text
    dic['first_vaccine'] = tdr[1].text
    dic['second_vaccine'] = tdr[3].text
    vaccine.append(dic)


# In[97]:


vaccine


# In[98]:


import pandas as pd
df = pd.read_csv("행정구역_시군구_별__성별_인구수_20210701145504.csv", header=1, encoding= 'cp949')
population = df[1:]
population


# In[99]:


import numpy as np
np.array(population['총인구수 (명)'].tolist())
list(np.array(population['총인구수 (명)'].tolist()))
list_population = list(np.array(population['총인구수 (명)'].tolist()))
list_population


# In[101]:


vaccine2 = []

for td,value in zip(btrs[1:],list_population) :
#     print(type(int((td.find_all("td")[1].text).replace(",",""))))
#     print(td,temp)
    dic= {}
    tds = td.find_all("th")
    tdr = td.find_all("td")
    dic['city'] = tds[0].text
    dic['first_vaccine'] = tdr[1].text
    dic['second_vaccine'] = tdr[3].text
    dic['population'] = value;
    dic['total_vaccine'] = int(tdr[1].text.replace(",",""))+int(tdr[3].text.replace(",",""));
    vaccine2.append(dic)
vaccine2


# In[105]:


from tkinter import Tk, ttk, Label, Button, Text, END
from tkinter import messagebox

window = Tk()
window.title("백신접종 현황")
window.geometry("400x400")
window.resizable(0,0) #사이즈 조정 안되게함

title="시도별 백신접종 현황"
title_feature = Label(window, text = title, font = ("Calibri", 20))
title_feature.pack(padx = 10, pady = 15) #위치 지정

treeTable = ttk.Treeview(window)
treeTable["columns"] = ("city", "first_vaccine", "second_vaccine", "total_vaccine", "population")
treeTable.column("#0", width = 20, anchor = "center")
treeTable.column("city", width = 30, anchor = "center")
treeTable.column("first_vaccine", width = 60, anchor = "center")
treeTable.column("second_vaccine", width = 60, anchor = "center")
treeTable.column("total_vaccine", width = 60, anchor = "center")
treeTable.column("population", width = 50, anchor = "center")

treeTable.heading("#0", text="No.", anchor = "center")
treeTable.heading("city", text="시도별", anchor = "center")
treeTable.heading("first_vaccine", text="1차 접종현황", anchor = "center")
treeTable.heading("second_vaccine", text="2차 접종현황", anchor = "center")
treeTable.heading("total_vaccine", text="총 접종현황", anchor = "center")
treeTable.heading("population", text="총 인구", anchor = "center")

def setTableItem() :
    treeTable.delete(*treeTable.get_children())
    for idx, report in enumerate(vaccine2) :
        city = report['city']
        first_vaccine = report['first_vaccine']
        second_vaccine = report['second_vaccine']
        total_vaccine = report['total_vaccine']
        population = report['population']
        treeTable.insert("", 'end', iid = None, text = str(idx), values = [city, first_vaccine, second_vaccine, total_vaccine, population])
 
btn1 = Button(window, text = 'Search', bg='black', fg='white')
btn1.place(x=100,y=300, relx = 0.5, width = 60, height = 40)
# photo = PhotoImage(file="/vaccine.jpg")
# pLabel = Label(w, image=photo)
# pLabel.pack(expand=1, anchor=CENTER)

# import thinkter as tk
# def create_window():
#     window = tk.Toplevel(root)
# root = tk.Tk()
# b = tk.Button(root, text="Create new window", command=create_window)
# b.pack()
# root.mainloop()

setTableItem()
treeTable.place(x=10, y=90, width=380, height=200)

from tkinter import *
from tkinter import messagebox

ws = Tk()
ws.title('접종 현황')
ws.geometry('300x300')

def helloMsg(city):
    city= textBox_city.get()
    return messagebox.showinfo('', f'{city} ' )

Label(ws, text='접종현황을 알고싶은 곳을 넣고 enter 키를 누르세요').pack(pady=50)
textBox_city = Entry(ws)
textBox_city.bind('<Return>', helloMsg)
textBox_city.pack()

ws.mainloop()

window.mainloop()


# In[ ]:





# In[ ]:





# In[ ]:





# In[43]:


import numpy as np
np.array(population['행정구역(시군구)별'].tolist())
list(np.array(population['행정구역(시군구)별'].tolist()))


# In[ ]:





# In[ ]:





# In[202]:


import csv
f = open('행정구역_시군구_별__성별_인구수_20210701145504.csv', 'r', encoding= 'cp949')
rdr = csv.reader(f)

for line in rdr:
    print(line)
    
f.close()


# In[ ]:





# In[ ]:





# In[ ]:





# In[ ]:





# In[ ]:





# In[ ]:





# In[ ]:




