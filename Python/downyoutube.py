from __future__ import unicode_literals
import youtube_dl
ydl_opts = {}
url = "https://www.youtube.com/watch?v=eZoMo4z-giwS"
with youtube_dl.YoutubeDL(ydl_opts) as ydl:
    ydl.download([url])