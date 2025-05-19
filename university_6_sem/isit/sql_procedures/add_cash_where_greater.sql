CREATE PROC add_cash_where_greater
    @bound FLOAT
AS
BEGIN
    IF @bound < (SELECT AVG(Количество_часов) FROM Экзамен)
    BEGIN
        UPDATE s
        SET s.Стипендия = s.Стипендия * 2
        FROM Студент s
    END;
END;