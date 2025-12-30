import os

dir_path = "/Users/ryo/Pictures/女子高生画像"

files = os.listdir(dir_path)

print("ファイル数は" + str(len(files)) + "です。")