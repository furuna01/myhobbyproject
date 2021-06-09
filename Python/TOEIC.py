import requests, bs4
from tkinter import messagebox
import datetime
#<div class="mod-schedule-vertical_sub_body">                        <p>2021年<em>4</em>月<em>22</em>日(木) <em>12:00</em> ～<br class="only-sp"> 2021年<em>4</em>月<em>26</em>日(月) <em>15:00</em> 締切</p> 

#今の時間が引数で指定された時間内であるかどうかをチェック
def checkTimeRange(time_begin, time_end):
    dt_now = datetime.datetime.now()
    dt_now_str = str(dt_now.month) + "/" + str(dt_now.day) + " " + str(dt_now.hour) + ":" + str(dt_now.minute)
    print(time_begin + "～" + time_end)
    if time_begin <= dt_now_str and dt_now_str <= time_end:
        return True
    else:
        return False


url = "https://www.iibc-global.org/toeic/test/lr/guide01/schedule.html"
response = requests.get(url)
soup = bs4.BeautifulSoup(response.content, "html.parser")
class_list = soup.find_all(class_="mod-schedule-vertical_sub_body")
begin_month = list()
begin_day = list()
begin_hour = list()
end_month = list()
end_day = list()
end_hour = list()
count = 0
count2 = 0
for line in class_list:
    em_list = line.find_all("em")
    for em in em_list:
        if count % 6 == 0:
            begin_month.append(em.text)
        if count % 6 == 1:
            begin_day.append(em.text)
        if count % 6 == 2:
            begin_hour.append(em.text)
        if count % 6 == 3:
            end_month.append(em.text)
        if count % 6 == 4:
            end_day.append(em.text)
        if count % 6 == 5:
            end_hour.append(em.text)
        count = count + 1
    count2 = count2 + 1
time_begin_list = list()
time_end_list = list()
for i in range(count2):
    time_begin_list.append(begin_month[i] + "/" + begin_day[i] + " " + begin_hour[i])
    time_end_list.append(end_month[i] + "/" + end_day[i] + " " + end_hour[i])
print("TOEICの申込期間")
for i in range(count2):
    if checkTimeRange(time_begin_list[i], time_end_list[i]):
        messagebox.showinfo("TOEIC申し込み期間", "今はTOEICの申込期間です")
input("")