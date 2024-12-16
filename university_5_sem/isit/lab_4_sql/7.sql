SELECT *,
	CASE WHEN (
		SELECT 1 FROM ЭкзаменПлюс AS "inner"
		WHERE "inner".Номер_зачетки = ЭкзаменПлюс.Номер_зачетки
		GROUP BY Номер_зачетки
		HAVING MIN(Оценка) > 2
	) = 1
	AND
	Стипендия < (SELECT AVG(Стипендия * 1.0) FROM ЭкзаменПлюс)
	THEN Стипендия + 1000 ELSE Стипендия END AS Новая_стипендия

FROM ЭкзаменПлюс


UPDATE ЭкзаменПлюс
SET Стипендия = CASE WHEN (
		SELECT 1 FROM ЭкзаменПлюс AS "inner"
		WHERE "inner".Номер_зачетки = ЭкзаменПлюс.Номер_зачетки
		GROUP BY Номер_зачетки
		HAVING MIN(Оценка) > 2
	) = 1
	AND
	Стипендия < (SELECT AVG(Стипендия * 1.0) FROM ЭкзаменПлюс)
	THEN Стипендия + 1000 ELSE Стипендия END;