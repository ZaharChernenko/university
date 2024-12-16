SELECT *, (CASE WHEN Наличие_детей = 1 AND ((SELECT COUNT(*) FROM Студент WHERE Наличие_детей = 1) >= 3) THEN Стипендия * 2 ELSE Стипендия END) AS Новая_стипендия
FROM Студент;