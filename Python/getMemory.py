import psutil 

# メモリ容量を取得
mem = psutil.virtual_memory()
mem_k = mem.total /1024
mem_m = mem_k / 1024
mem_g = mem_m / 1024
print("メモリ容量を取得")
print(str(mem_g) + "GByte") 
print("メモリ使用量を取得")
print(str(mem.used / 1024 / 1024) + "M") 
print("メモリ空き容量を取得")
print(str(mem.available / 1024 / 1024) + "M")