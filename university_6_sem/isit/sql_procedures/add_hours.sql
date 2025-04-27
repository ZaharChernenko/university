CREATE PROC add_hours
	@exam NVARCHAR(255),
	@hours INT
AS
	UPDATE e
	SET e.Количество_часов = e.Количество_часов + @hours
	FROM Экзамен e
	WHERE e.Код_дисциплины = (SELECT Код_дисциплины FROM Дисциплина WHERE @exam = Наименование_дисциплины);
