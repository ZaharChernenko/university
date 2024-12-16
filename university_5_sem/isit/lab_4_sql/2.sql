UPDATE ЭкзаменПлюс
SET Примечание = CASE
	WHEN (SELECT SUM(Оценка) FROM ЭкзаменПлюс AS "inner" WHERE ЭкзаменПлюс.Номер_зачетки = "inner".Номер_зачетки) * 1.0 / (SELECT COUNT(Код_дисциплины) FROM Дисциплина) > 4.9 THEN 'блестяще'
	WHEN (SELECT SUM(Оценка) FROM ЭкзаменПлюс AS "inner" WHERE ЭкзаменПлюс.Номер_зачетки = "inner".Номер_зачетки) * 1.0 / (SELECT COUNT(Код_дисциплины) FROM Дисциплина) BETWEEN 4.0 AND 4.9 THEN 'хорошо' ELSE 'посредственно' END;
SELECT * FROM ЭкзаменПлюс;