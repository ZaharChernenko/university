CREATE PROC add_cash_where_greater
    @bound FLOAT
AS
BEGIN
    IF @bound < (SELECT AVG(����������_�����) FROM �������)
    BEGIN
        UPDATE s
        SET s.��������� = s.��������� * 2
        FROM ������� s
    END;
END;