data = ['フレンチドック',
        'ヨークシャテリア',
        'ダックスフンド',
        'ポメラニアン',
        'コーギー']

result = filter(lambda v:len(v) < 6, data)
print(list(result))