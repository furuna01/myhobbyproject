import math

def checkPrime(number):
    if(number == 2):
        return True
    limit = math.ceil(math.sqrt(number)) + 1
    for i in range(2, limit):
        if number % i == 0:
            return False
    return True

number_str = input("自然数を入れてください: ")
number = int(number_str)

old_prime = 2
difference = 2
old_difference = 2

for i in range(2, number):
    if checkPrime(i):
        print(i)
        difference = i - old_prime
        if difference > old_difference:
            old_difference = difference
        old_prime = i

print("そすうの間の差の最大値は " + str(old_difference) + "です。")
        