SELECT MAX(YEAR(CURRENT_TIMESTAMP) - YEAR(Дата_рождения)) AS Максимальный_возраст, MIN(YEAR(CURRENT_TIMESTAMP) - YEAR(Дата_рождения)) AS Минимальный_возраст
FROM Студент
WHERE Дата_рождения > '19950101';

-- Минимальный возраст
SELECT  YEAR(CURRENT_TIMESTAMP) - YEAR(MAX(Дата_рождения)) AS 'Минимальный возраст' FROM Студент;

-- Максимальный возраст
SELECT  YEAR(CURRENT_TIMESTAMP) - YEAR(MIN(Дата_рождения)) AS 'Максимальный возраст' FROM Студент;

-- Студенты, которые старше самого молодого не больше чем на 5 лет
SELECT *, YEAR(CURRENT_TIMESTAMP) - YEAR(Дата_рождения) AS 'Текущий возраст' FROM Студент
WHERE YEAR(CURRENT_TIMESTAMP) - YEAR(Дата_рождения) <= (SELECT MIN(YEAR(CURRENT_TIMESTAMP) - YEAR(Дата_рождения)) FROM Студент) + 5;

SELECT Код_факультета, 
(CASE WHEN (SELECT COUNT(*) FROM Студент WHERE Фамилия LIKE 'А%' OR Фамилия LIKE 'Я%' AND Код_факультета = "outer".Код_факультета) > (SELECT COUNT(*) FROM Студент WHERE Фамилия LIKE '%ов' AND Код_факультета = "outer".Код_факультета)
THEN 'Больше'
ELSE 'Меньше' END)
FROM Студент AS "outer"
GROUP BY Код_факультета;