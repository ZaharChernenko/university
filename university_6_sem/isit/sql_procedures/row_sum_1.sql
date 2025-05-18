CREATE PROC row_sum_1
    @n INT
AS
BEGIN
    DECLARE @result INT;
    EXEC row_sum @n = @n, @result = @result OUTPUT;
    SELECT @result AS row_sum;
END;