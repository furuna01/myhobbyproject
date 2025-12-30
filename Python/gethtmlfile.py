import requests

url = input("URLを入力して下さい。コピーしましょう")
file_name = input("保存するファイル名を指定しましょう")

site_data = requests.get(url)

with open(file_name, "w") as f:
    f.write(site_data.text)

print("書き込みが完了しました")