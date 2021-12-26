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
    month_day_begin = time_begin.split("/")
    month_day2_begin = month_day_begin[1].split(" ")
    month_begin = int(month_day_begin[0])
    day_begin = int(month_day2_begin[0])
    year = dt_now.year
    month_day_end = time_end.split("/")
    month_day2_end = month_day_end[1].split(" ")
    month_end = int(month_day_end[0])
    day_end = int(month_day2_end[0])
    begin_time = datetime.date(year, month_begin, day_begin)
    end_time = datetime.date(year, month_end, day_end)
    dt_current = datetime.date(dt_now.year, dt_now.month, dt_now.day)
    
    if begin_time <= dt_current and dt_current <= end_time:
        return True
    else:
        return False

#TOEICの受験情報をすべて表示する
def showDate(time_begin_list, time_end_list, exam_time_list):
    count = 0
    dt_now = datetime.datetime.now()
    dt_now_str = str(dt_now.month) + "/" + str(dt_now.day) + " " + str(dt_now.hour) + ":" + str(dt_now.minute)
    dt_year = dt_now.year
    for list in time_begin_list:
        month_day = time_end_list[count].split("/")
        month_day2 = month_day[1].split(" ")
        #print(month_day2[1])
        month = int(month_day[0])
        #print(month)
        day = int(month_day2[0])
        exam_date = datetime.date(dt_year, month, day)
        now_date = datetime.date(dt_now.year, dt_now.month, dt_now.day)
        if exam_date > now_date:
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