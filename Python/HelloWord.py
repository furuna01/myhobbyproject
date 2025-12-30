def kaijyou(n):
    sum = 1
    for i in range(n):
        sum = sum * (i + 1)
    return sum

c1 = 2
d1 = 1
c2 = c1 * 2 + 5 * d1
d2 = c1 + 2 * d1
c3 = c2 * 2 + 5 * d2
d3 = c2 + 2 * d2
c4 = c3 * 2 + 5 * d3
d4 = c3 + 2 * d3
c5 = 2 * c4 + 5 * d4
d5 = c4 + 2 * d4
c6 = 2 * c5 + 5 * d5
d6 = c5 + 2 * d5
c7 = 2 * c6 + 5 * d6
d7 = c6 + 2 * d6
c8 = 2 * c7 + 5 * d7
d8 = c7 + 2 * d7

print(str(c1) + " " + str(d1))
print(str(c2) + " " + str(d2))
print(str(c3) + " " + str(d3))
print(str(c4) + " " + str(d4))
print(str(c5) + " " + str(d5))
print(str(c6) + " " + str(d6))
print(str(c7) + " " + str(d7))
print(str(c8) + " " + str(d8))
print("-------")
print("7! = " + str(kaijyou(7)))
print("8! = " + str(kaijyou(8)))
print("9! = " + str(kaijyou(9)))
print("10! = " + str(kaijyou(10)))
print("11! = " + str(kaijyou(11)))