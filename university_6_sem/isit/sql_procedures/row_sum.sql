CREATE PROC row_sum
    @n INT,
    @result INT OUTPUT
AS
BEGIN
    IF @n < 1
    BEGIN
        SET @result = NULL
        RETURN
    END

    SET @result = @n * (@n + 1) / 2
END;
