SELECT * FROM Студент s
WHERE 5 IN (SELECT Оценка FROM Экзамен e WHERE e.Номер_зачетки = s.Номер_зачетной_книжки);

EXEC add_cash_where_5 @amount = 1;

SELECT * FROM Студент s
WHERE 5 IN (SELECT Оценка FROM Экзамен e WHERE e.Номер_зачетки = s.Номер_зачетной_книжки);
