SELECT * FROM Студент;

EXEC add_cash_where_equal
	@equal_to = 0,
	@add_amount = 228;

SELECT * FROM Студент;