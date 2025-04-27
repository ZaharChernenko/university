CREATE TRIGGER student_check_age_update
ON Студент
AFTER UPDATE, INSERT
AS
IF (
    EXISTS(
        SELECT 1
        FROM inserted
        WHERE
        YEAR(CURRENT_TIMESTAMP) - YEAR(Дата_рождения) < 35
    )
)
BEGIN
    ROLLBACK TRANSACTION
    PRINT 'Невозможно обновить данные студента, т.к. он младше 35 лет'
END;