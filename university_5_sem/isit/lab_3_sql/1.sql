SELECT (SELECT Наименование_дисциплины FROM Дисциплина WHERE Код_дисциплины = Экзамен.Код_дисциплины) FROM Экзамен
GROUP BY Код_дисциплины
HAVING AVG(Оценка) > (SELECT AVG(Оценка) FROM Экзамен);