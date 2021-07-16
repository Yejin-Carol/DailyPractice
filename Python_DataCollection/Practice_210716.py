from selenium import webdriver
import time

browser = webdriver.Chrome('C:/temp/chromedriver')
browser.get("http://python.org")

html = browser.page_source
soup = BeautifulSoup(html, 'html.paser')


menus = browser.find_elements_by_css_selector('#top ul.menu li')

pypi = None
for m in menus:
    if m.text == "PyPI":
        pypi = m
    #print(m.text)

pypi.click()  # 클릭

time.sleep(5)  # 5초 대기
browser.quit()  # 브라우저 종료

# 2. 세계 부자 순위 (동적-> pandas dataframe -> csv 파일까지!)


from selenium import webdriver
import time
import requests
from bs4 import BeautifulSoup
import pandas as pd

driver = webdriver.Chrome('C:/temp/chromedriver')
url = ("https://www.forbes.com/real-time-billionaires/#653c74b53d78")
driver.get(url)

html = driver.page_source
soup = BeautifulSoup(html, 'html.parser')

# billionaires_data = []
# rank = 1
#
# billionaires = soup.select('#row-3 div table tbody tr')

name = soup.select('#row-3 div table tbody tr td div h3 a')
net = soup.select('#row-3 div table tbody tr td.Net.Worth div span')
company = soup.select('#row-3 div table tbody tr td.source div span')
country = soup.select('#row-3 div table tbody tr td.Country\\/Territory div span')

ls_name = []
ls_net = []
ls_company = []
ls_country = []

for i in range(len(name)):
    ls_name.append(name[i].text.strip())
    ls_net.append(net[i].text.strip())
    ls_company.append(company[i].text.strip())
    ls_country.append(country[i].text.strip())

result_file = pd.DataFrame({'name':ls_name, 'net':ls_net, 'company':ls_company,'country':ls_country})
print(result_file)
result_file.to_csv("C:\\Users\\KB\\Documents\\Carol\\rank_billion_210716.csv", index=False, encoding='latin1')
