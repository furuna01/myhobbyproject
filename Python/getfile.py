import requests, bs4, datetime, os, time


#相対パスを含むパスがあれば絶対パスにして返す
def makeAbsPath(link_list, url):
    result = []
    for i in link_list:
        if i.find('https') >= 0 or i.find('http') >= 0:
            result.append(i)
        else:
            #絶対パスを作る
            result.append(url + i)
    return result
#このサイトの最新の画像をダウンロードするプログラム
def getFileName(path):
    temp_list = path.split('/')
    extension = temp_list[len(temp_list) - 1].split(".")
    if extension != None or extension != "":
        if extension[len(extension) - 1] == "jpg" or extension[len(extension) - 1] == "gif":
            return temp_list[len(temp_list) - 1]
        else:
            return ""
    
#元あるファイルのurlから拡張子がjpgのファイルのみ選んでリストを作る
def makeJpgList(link_list3):
    result = []
    for i in link_list3:
        temp_list = i.split('/')
        extension = temp_list[len(temp_list) - 1].split(".")
        if extension != None or extension != "":
            if extension[len(extension) - 1] == "jpg" or extension[len(extension) - 1] == "gif":
                result.append(i)
    return result

def downloadFile(url):
    response = requests.get(url)
    soup = bs4.BeautifulSoup(response.text, "html.parser")
    links = soup.findAll('img')

    link_list = []
    for link in links:
        if link != None and link.get('src') != None:
            link_list.append(link.get('src'))
    

    links2 = soup.findAll('a')

    link_list2 = []
    for link in links2:
        if link != None and link.get('href') != None:
            link_list2.append(link.get('href'))
    

    link_list.extend(link_list2)
    #相対パスを絶対パスにする
    link_list3 = makeAbsPath(link_list, url)
    #拡張子がjpgのファイルのみ取得
    link_list4 = makeJpgList(link_list3)
    #ファイル名のリストを取得
    file_list = []
    for i in link_list4:
        if i != None:
            fname = getFileName(i)
            if fname != "":
                file_list.append(fname)
                file_list.append(fname)
    #フォルダ名は現在の日時
    dt_now = datetime.datetime.now()
    folder_name = str(dt_now.year) + "-" + str(dt_now.month) + "-" + str(dt_now.day)
    if os.path.exists(folder_name):
        exit()
    else:
        os.mkdir(folder_name)
    for i, j in zip(link_list4, file_list):
        print(i)
        response = requests.get(i)
        file_name = open(folder_name + "\\" + j, mode='wb').write(response.content)
url1 = "https://1000giribest.com/554486.html#more-554486"
url2 = ""
url3 = ""
#url = "https://eromomo.com/?p=111005"
downloadFile(url1)