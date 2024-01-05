import re

fin = open("Export.txt", "r", encoding="utf-8")
fout = open("Input.txt", "w")
lines = fin.readlines()
for line in lines:
    fout.write(line)
    if ("Name	Comment	Data type	Length	Format adaptation	Connection" in line):
        break
pair = {"DB": "DB", "DD": "DBD", "DW": "DBW"}
for line in lines:

    addTo1 = 0
    multiple2 = 2
    if re.findall(r"[0-9]+ in", line):
        multiple2 = 1
        num = int(re.findall(r"[0-9]+", re.findall(r"[0-9]+ in", line)[0])[0])
        if num >= 8:
            line = re.sub(re.findall(r"[0-9]+ in", line)[0], str(num - 8) + " in", line)
        else:
            addTo1 = 1

    for key, value in pair.items():
        reg_exp = re.escape(key) + r"[0-9]+"
        list = (re.findall(reg_exp, line))
        if not list:
            continue
        if key != "DB":
            line = re.sub(reg_exp, value + str(int(re.findall(reg_exp, line)[0][2:]) * multiple2), line)
        else:
            line = re.sub(reg_exp, value + str(int(re.findall(reg_exp, line)[0][2:]) * 2 + addTo1), line)

    fout.write(line)
