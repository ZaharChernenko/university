CREATE PROC add_cash_where_equal
	@equal_to INT,
	@add_amount INT
AS
	UPDATE s
	SET s.��������� = s.��������� + @add_amount
	FROM ������� s
	WHERE s.��������� = @equal_to;
