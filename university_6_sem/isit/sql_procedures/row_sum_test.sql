DECLARE @res INT;
EXEC row_sum @n = 10, @result = @res OUTPUT;
SELECT @res AS result;