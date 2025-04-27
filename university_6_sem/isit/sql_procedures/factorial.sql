CREATE PROCEDURE factorial
    @n INT,
    @result INT OUTPUT
AS
BEGIN
    IF @n < 1
    BEGIN 
        SET @result = NULL
        RETURN
    END

    SET @result = 1
    WHILE @n > 1
    BEGIN
        SET @result = @result * @n
        SET @n = @n - 1
    END
END;