import math

scoresum = 0
cnt = 0
while(True):
    number_str = input("Input the score on IELTS or write exit to exit the program ")
    if number_str == "exit":
        break
    number = float(number_str)
    cnt = cnt + 1
    scoresum = scoresum + number

print("IELTS score is " + str(float(scoresum / cnt)))
