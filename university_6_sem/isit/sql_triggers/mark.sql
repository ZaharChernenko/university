CREATE TRIGGER check_student_deletion
ON Студент
AFTER DELETE
AS
IF (
	(
		SELECT COUNT(*)
		FROM deleted AS d, Экзамен AS e
		WHERE d.Номер_зачетной_книжки = e.Номер_зачетки 
		AND
		e.Оценка = 2 AND e.Оценка IS NOT NULL
	)
	!=
	(
		SELECT COUNT(*)
		FROM Дисциплина
	)
)
BEGIN
	ROLLBACK TRANSACTION
	PRINT 'Невозможно удалить студента, есть положительно сданные экзамены'
END
