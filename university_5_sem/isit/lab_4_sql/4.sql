SELECT ФИО
FROM ЭкзаменПлюс
GROUP BY ФИО
HAVING SUM(Оценка) / (SELECT COUNT(*) FROM Дисциплина) > 3.5;
