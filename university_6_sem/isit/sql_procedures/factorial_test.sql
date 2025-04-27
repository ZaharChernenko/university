DECLARE @res INT;
EXEC factorial @n = 2, @result = @res OUTPUT;
SELECT @res AS Factorial;