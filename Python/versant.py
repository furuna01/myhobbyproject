total = 0
number = int(input("文章校正の点は？"))
total = total + number * 0.3
number = int(input("語彙の点は？"))
total = total + number * 0.2
number = int(input("流暢性の点は？"))
total = total + number * 0.3
number = int(input("発音の点は？"))
total = total + number * 0.2

print("Versantの点は " + str(total) + "です")