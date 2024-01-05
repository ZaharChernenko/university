from collections import UserDict


class Synonims(UserDict):
    def __setitem__(self, key, value):
        super().__setitem__(key, value)


def Separator(str):
    k = str.find(";")
    if k == -1:
        words.append(str)
        return
    else:
        words.append(str[0:k])
        Separator(str[k + 2:])


def GenerateSynonims(arr):
    for i in range(len(arr)):
        temp = arr.pop(0)
        if temp in vcb:
            vcb[temp] = arr[:] + vcb[temp]
        else:
            vcb[temp] = arr[:]
        arr.append(temp)


def FindSynonim(word):
    if word in vcb:
        print("Синонимы для слова ", word, ": ", sep="", end="")
        print(*vcb[word], sep=", ")
        question = input("Устроил ли вас подбор синонима? ")
        if question.lower() == "нет":
            return AddSynonims(word)
        else:
            return

    else:
        question = input("К сожалению, синонима к данному слову еще нет, хотите добавить? ")
        if question.lower() == "нет":
            return
        else:
            return AddSynonims(word)


def AddSynonims(word):
    x = input("Введите слово: ")
    newwords = word.title() + " - " + x + "\n"
    file.write(newwords)
    return


vcb = Synonims()
file = open("synonyms.txt", "r+")
lines = file.readlines()
for line in lines:
    if line == '\n':
        continue
    i = line.find(" ")
    words = [line[0:i].lower()]
    line = line[i + 3:-1]  # remove \n
    Separator(line)
    GenerateSynonims(words)


print(vcb)
FindSynonim(input("Введите слово: "))
file.close()