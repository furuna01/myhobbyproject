
def checkDividNum(number):
    sum = 0
    for i in range(1, number):
        if number % i == 0:
            sum += i
    if number < sum:
        return 1
    elif number == sum:
        return 0
    else:
        return -1


print("入力した数まで約数の環がその数自身より小さい数の数と、大きな数の数と、同じ数を出力します。")
number = int(input())
#約数の環がその数自身より小さい数
small_num = 0
#訳数がその数自身より大きい数
big_num = 0
#同じ数
equal_num = 0
for i in range(2, number + 1):
    print(i)
    ret = checkDividNum(i)
    if ret == 1:
        big_num += 1
    elif ret == 0:
        equal_num += 1
    else:
        small_num += 1
print("大きな数は " + str(big_num))
print("等しい数は " + str(equal_num))
print("小さい数は　" + str(small_num))