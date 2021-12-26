total = 0
while(True):
    number_str = input("足す数字を入れてください: Please Enter the word exit to stop this program ")
    if(number_str == "exit"):
        break
    try:
        number = int(number_str)
    except:
        number = 0
    total = total + number
    print("合計は、" + str(total) + " です")