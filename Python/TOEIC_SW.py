import requests, bs4
from tkinter import messagebox
import webbrowser
import datetime
#<div class="mod-schedule-vertical_sub_body">                        <p>2021年<em>4</em>月<em>22</em>日(木) <em>12:00</em> ～<br class="only-sp"> 2021年<em>4</em>月<em>26</em>日(月) <em>15:00</em> 締切</p> 

#今の時間が引数で指定された時間内であるかどうかをチェック
def checkTimeRange(time_begin, time_end):
    dt_now = datetime.datetime.now()
    dt_now_str = str(dt_now.month) + "/" + str(dt_now.day) + " " + str(dt_now.hour) + ":" + str(dt_now.minute)
    #print(time_begin + "～" + time_end)
    if time_begin <= dt_now_str and dt_now_str <= time_end:
        return True
    else:
        return False

#TOEICの受験情報をすべて表示する
def showDate(time_begin_list, time_end_list, exam_time_list):
    count = 0
    dt_now = datetime.datetime.now()
    dt_now_str = str(dt_now.month) + "/" + str(dt_now.day) + " " + str(dt_now.hour) + ":" + str(dt_now.minute)
    for list in time_begin_list:
        if time_end_list[count] > dt_now_str:
            print(" TOEIC(S&W)試験 " + "試験日" + exam_time_list[count] + " インターネット受付日 " + time_begin_list[count] + "～" + time_end_list[count])
        count = count + 1

url = "https://www.iibc-global.org/toeic/test/sw/guide01.html"
response = requests.get(url)
soup = bs4.BeautifulSoup(response.content, "html.parser")
class_date_list = soup.find_all(class_="mod-schedule-vertical")
exam_month = list()
exam_day = list()
begin_month = list()
begin_day = list()
begin_hour = list()
end_month = list()
end_day = list()
end_hour = list()

for date in class_date_list:
    class_list = date.find_all(class_="mod-schedule-vertical_main_date")
    count = 0
    count2 = 0
    for line in class_list:
        em_list = line.find_all("em")
        for em in em_list:
            if count % 3 == 0:
                exam_month.append(em.text)
            if count % 3 == 1:
                exam_day.append(em.text)
            count = count + 1            

count = 0
for date in class_date_list:
    class_list = date.find_all(class_="mod-schedule-vertical_sub_body")
    count = 0
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
exam_time_list = list()
for i in range(count2):
    time_begin_list.append(begin_month[i] + "/" + begin_day[i] + " " + begin_hour[i])
    time_end_list.append(end_month[i] + "/" + end_day[i] + " " + end_hour[i])
    exam_time_list.append(exam_month[i] + "/" + exam_day[i])
showDate(time_begin_list, time_end_list, exam_time_list)
for i in range(count2):
    if checkTimeRange(time_begin_list[i], time_end_list[i]):
        ret = messagebox.askyesno("TOEICの申し込み期間", "今はTOEICの申込期間です")
        if ret == True:
            webbrowser.open(url)
input("press Enter key")