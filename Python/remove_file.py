import glob, os

def remove_file(list1, list2, path):
    for file_name1 in list1:
        for file_name2 in list2:
            if file_name1 == file_name2:
                os.remove(path + "\\" + file_name1)

print("比べたいファイルのフォルダ名直下のファイルと同じファイルを削除します")
print("削除したいファイルのフォルダ名を入れてください")
folder_name1 = input()
print("比べたいファイルのフォルダ名を入れてください「")
folder_name2 = input()

path_list1 = glob.glob(folder_name1 + "\\*")
path_list2 = glob.glob(folder_name2 + "\\*")

file_list1 = []
file_list2 = []
for i in path_list1:
    array1 = i.split("\\")
    file_list1.append(array1[len(array1) - 1])
for i in path_list2:
    array1 = i.split("\\")
    file_list2.append(array1[len(array1) - 1])

for i in file_list1:
    print(i)

remove_file(file_list1, file_list2, folder_name1)