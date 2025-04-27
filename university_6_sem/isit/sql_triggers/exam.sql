CREATE TRIGGER check_exam_update
ON Экзамен
AFTER UPDATE, INSERT
AS
IF (
	NOT EXISTS (
		SELECT 1
		FROM inserted AS i, Дисциплина
		WHERE
		i.Код_дисциплины = Дисциплина.Код_дисциплины
	)
)
BEGIN
	ROLLBACK TRANSACTION
	PRINT 'Невозможно добавить экзамен, предмета не существует'
END