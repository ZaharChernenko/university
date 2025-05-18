CREATE PROCEDURE factorial_1
    @n INT
AS
BEGIN
    DECLARE @result INT;
    EXEC factorial @n = @n, @result = @result OUTPUT;
    SELECT @result AS factorial;
END;