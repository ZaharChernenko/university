CREATE PROC add_cash_where_5
    @amount INT
AS
    UPDATE s
    SET s.��������� = s.��������� + @amount
    FROM ������� s
    WHERE 5 IN (SELECT ������ FROM ������� WHERE �������.�����_������� = s.�����_��������_������);