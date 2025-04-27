CREATE PROC add_cash
AS
    UPDATE s
    SET s.Стипендия =
        CASE
            WHEN (s.Наличие_детей = 1 AND s.Стипендия != 0 AND s.Стипендия IS NOT NULL) THEN s.Стипендия * 3
            WHEN (s.Наличие_детей = 1) THEN 2200
            ELSE s.Стипендия + 1100
        END
    FROM Студент s;