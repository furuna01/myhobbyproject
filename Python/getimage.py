import requests, bs4, urllib
import urllib.parse
from urllib.parse import urlparse
import os
import datetime
import sys

def get_file_name(file_path):
    var_array = file_path.split('/')
    file_name = var_array[len(var_array) - 1]
    return file_name

def get_extention(file_name):
    print(file_name)
    if file_name == None:
        return "None"
    var_array = file_name.split('/')
    last_file = var_array[len(var_array) - 1]
    extention_array = last_file.split('.')
    extention = extention_array[len(extention_array) - 1]
    return extention
def is_target_file(file_path):
    extention = get_extention(file_path)
    if extention == "jpeg" or extention == "jpg" or extention == "gif":
        return True
    else:
        return False

def get_target_file(file_path_list):
    target_file_path_list = []
    for file in file_path_list:
        if is_target_file(file):
            target_file_path_list.append(file)
    return target_file_path_list

def getLink(text):
    list = []
    while(True):
        num = text.find('"')
        if num == -1:
            print('not found')
            break
        text = text[num + 1 : ]
        num = text.find('"')
        text2 = text[ : num]
        text = text[num + 1 :]
        if 'https:' in text2:
            print(text2)
            list.append(text2)
    return list


def down_all_jpgfile(Url):
    res = requests.get(Url)
    res.raise_for_status()
    soup = bs4.BeautifulSoup(res.text, "html.parser")
    down_file_path_list = []
    if(Url == "https://pashalism.com/3775/"):
        down_file_path_list = getLink(soup)
    else:
        contents_of_img = soup.select('img')
    
        for var in contents_of_img:
            down_file_path_list.append(var.get('src'))
        contents_of_a = soup.select('a')
        for var in contents_of_a:
            down_file_path_list.append(var.get('href'))
        if len(down_file_path_list) == 0 or not down_file_path_list:
            print("This application was not able to find target files")
            exit(0)

    for var in down_file_path_list:
        print(var)

    target_file_path_list = get_target_file(down_file_path_list)

    #for file in target_file_path_list:
    #    print(file)

    if len(target_file_path_list) == 0 or not target_file_path_list:
        print("This application was not able to find target files")
        exit(0)
    current_path = os.getcwd()
    
    folder_name = "temp"

    folder_path = current_path + "/" + folder_name
    os.makedirs(folder_path)
    for file in target_file_path_list:
        file_path = folder_name + "/" + get_file_name(file)
        print(file_path)
        if not ("https" in file or "http" in file):
            parsed_url = urlparse(Url)
            file = parsed_url.scheme + "://" + parsed_url.netloc + "/" + file
        response = requests.get(file)
        image = response.content

        result_file = open(file_path, "wb")
        result_file.write(image)
Url = "https://pashalism.com/8789-2/"

down_all_jpgfile(Url)
