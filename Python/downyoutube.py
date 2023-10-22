import sys

args = sys.argv

for str in args:
    print(str)

Url = ""
if len(args) == 1:
    Url = "https://www.youtube.com/watch?v=4IKLtDBL9lQ&t=297s"
elif len(args) == 2:
    url = args[1]

from yt_dlp import YoutubeDL
with YoutubeDL() as ydl:
    result = ydl.download([url])