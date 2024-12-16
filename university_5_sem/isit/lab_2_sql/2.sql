SELECT AVG(YEAR(CURRENT_TIMESTAMP) - YEAR(Дата_рождения)) AS "Средний возраст", Код_факультета
FROM Студент
GROUP BY Код_факультета;