CREATE PROC add_cash_where_equal
	@equal_to INT,
	@add_amount INT
AS
	UPDATE s
	SET s.Стипендия = s.Стипендия + @add_amount
	FROM Студент s
	WHERE s.Стипендия = @equal_to;
