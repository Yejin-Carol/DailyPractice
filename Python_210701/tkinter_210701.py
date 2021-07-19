#!/usr/bin/env python
# coding: utf-8

# In[30]:


import requests 
from bs4 import BeautifulSoup


# In[40]:


#변수 url
url = "http://www.kric.go.kr/jsp/industry/rss/citystapassList.jsp?q_org_cd=A010010024&q_fdate=2021"
htmlText = requests.get(url).text
bsoup = BeautifulSoup(htmlText, "html.parser")
btab = bsoup.find("table",{"class":"listtbl_c100"})
btrs = btab.find("tbody").find_all("tr")
btdcols = btrs[1].find_all("td", {"class": "tdcol"})
btds = btrs[1].find_all("td")

passenger = []

for tr in btrs[1:] :
    dic  = {}
    tds = tr.find_all("td")
    dic['station'] = tds[0].text
    dic['geton'] = tds[2].text
    dic['getoff'] = tds[3].text
    passenger.append(dic)    


# In[41]:


passenger


# In[ ]:


from tkinter import Tk, ttk, Label, Button, Text, END

window = Tk()
window.title("인원관리 프로그램")
window.geometry("400x400")
window.resizable(0,0) #사이즈 조정 안되게함

title="지하철 승하차 인원관리"
title_feature = Label(window, text = title, font = ("Calibri", 20))
title_feature.pack(padx = 10, pady = 15) #위치 지정

treeTable = ttk.Treeview(window)
treeTable["columns"] = ("station", "geton", "getoff")
treeTable.column("#0", width = 50, anchor = "center")
treeTable.column("station", width = 50, anchor = "center")
treeTable.column("geton", width = 50, anchor = "center")
treeTable.column("getoff", width = 50, anchor = "center")

treeTable.heading("#0", text="No.", anchor = "center")
treeTable.heading("station", text="역이름", anchor = "center")
treeTable.heading("geton", text="승차인원", anchor = "center")
treeTable.heading("getoff", text="하차인원", anchor = "center")

def setTableItem() :
    treeTable.delete(*treeTable.get_children())
    for idx, report in enumerate(passenger) :
        station = report['station']
        geton = report['geton']
        getoff = report['getoff']
        treeTable.insert("", 'end', iid = None, text = str(idx), values = [station, geton, getoff])
        
setTableItem()
        
treeTable.place(x=10, y=90, width=380, height=200)






window.mainloop()

