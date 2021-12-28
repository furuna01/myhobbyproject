total = 0
while(True):
    number = input("足す数字を入れてください:(やめるにはexitを入力): ")
    if number == "exit":
        break
    total = total + number;
    print("合計は" + str(total) + "です")