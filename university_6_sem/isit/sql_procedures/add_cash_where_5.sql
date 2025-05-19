CREATE PROC add_cash_where_5
    @amount INT
AS
BEGIN
    UPDATE s
    SET s.Стипендия = s.Стипендия + @amount
    FROM Студент s
    WHERE 5 IN (SELECT Оценка FROM Экзамен WHERE Экзамен.Номер_зачетки = s.Номер_зачетной_книжки);
END;