import sys
import yt_dlp as youtube_dl

Url = "https://www.youtube.com/watch?v=H_Nc-zjRmK4"

def download_channel_videos(Url):
    # ダウンロードオプションを定義
    ydl_opts = {
        'format': 'best',  # 動画の最適なフォーマットをダウンロード
        'outtmpl': '%(title)s.%(ext)s',  # 保存するファイル名のフォーマット
        'ignoreerrors': True  # エラーがあっても処理を継続する
    }

    with youtube_dl.YoutubeDL(ydl_opts) as ydl:
        ydl.download([Url])

# チャンネルのURLを指定
download_channel_videos(Url)