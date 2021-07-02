#!/usr/bin/env python
# coding: utf-8

# In[226]:


import requests 
from bs4 import BeautifulSoup


# In[227]:


url = "https://ncv.kdca.go.kr/mainStatus.es?mid=a11702000000"
htmlText = requests.get(url).text
bsoup = BeautifulSoup(htmlText, "html.parser")
btab = bsoup.find_all("tbody")
btrs = btab[1].find_all("tr")
# btrs = btab.find_all("tbody")
# btdcols = btrs[3].find_all("th")
# btds = btrs[3].find_all("td")


# In[228]:


vaccine = []

for td in btrs[1:] :
    dic= {}
    tds = td.find_all("th")
    tdr = td.find_all("td")
    dic['city'] = tds[0].text
    dic['first_vaccine'] = tdr[1].text
    dic['second_vaccine'] = tdr[3].text
    vaccine.append(dic)


# In[229]:


vaccine


# In[230]:


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
treeTable["columns"] = ("city", "first_vaccine", "second_vaccine")
treeTable.column("#0", width = 50, anchor = "center")
treeTable.column("city", width = 50, anchor = "center")
treeTable.column("first_vaccine", width = 50, anchor = "center")
treeTable.column("second_vaccine", width = 50, anchor = "center")

treeTable.heading("#0", text="No.", anchor = "center")
treeTable.heading("city", text="시도별", anchor = "center")
treeTable.heading("first_vaccine", text="1차 접종현황", anchor = "center")
treeTable.heading("second_vaccine", text="2차 접종현황", anchor = "center")

def setTableItem() :
    treeTable.delete(*treeTable.get_children())
    for idx, report in enumerate(vaccine) :
        city = report['city']
        first_vaccine = report['first_vaccine']
        second_vaccine = report['second_vaccine']
        treeTable.insert("", 'end', iid = None, text = str(idx), values = [city, first_vaccine, second_vaccine])
 
btn1 = Button(window, text = 'Search', bg='black', fg='white')
btn1.place(x=100,y=300, relx = 0.5, width = 60, height = 40)

# import thinkter as tk
# def create_window():
#     window = tk.Toplevel(root)
# root = tk.Tk()
# b = tk.Button(root, text="Create new window", command=create_window)
# b.pack()
# root.mainloop()

setTableItem()
treeTable.place(x=10, y=90, width=380, height=200)

window.mainloop()


# In[ ]:





# In[ ]:





# In[ ]:





# In[ ]:





# In[ ]:





# In[ ]:




