SELECT * FROM ������� s
WHERE 5 IN (SELECT ������ FROM ������� e WHERE e.�����_������� = s.�����_��������_������);

EXEC add_cash_where_5 @amount = 1;

SELECT * FROM ������� s
WHERE 5 IN (SELECT ������ FROM ������� e WHERE e.�����_������� = s.�����_��������_������);
