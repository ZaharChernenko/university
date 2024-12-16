SELECT COUNT(*) AS Количество_студентов, SUM(Стипендия) AS Суммарная_стипендия, Код_факультета, YEAR(CURRENT_TIMESTAMP) - YEAR(Дата_рождения) AS Возраст
FROM Студент
GROUP BY YEAR(CURRENT_TIMESTAMP) - YEAR(Дата_рождения), Код_факультета;