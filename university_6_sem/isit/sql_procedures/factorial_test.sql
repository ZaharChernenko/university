DECLARE @res INT;
EXEC factorial @n = 5, @result = @res OUTPUT;
SELECT @res AS Factorial;