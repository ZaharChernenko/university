-- 5.	Вывести на экран наименование группы, в которой количество студентов, получающих стипендию, больше, чем в остальных.
SELECT Номер_группы
FROM Студент
WHERE Стипендия != 0
GROUP BY Номер_группы
HAVING COUNT(*) = (
    SELECT MAX(CountGroup)
    FROM (
        SELECT COUNT(*) AS CountGroup
        FROM Студент
        WHERE Стипендия != 0
        GROUP BY Номер_группы
    ) AS GroupCounts
);