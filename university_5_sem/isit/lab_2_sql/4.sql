SELECT *, (CASE WHEN �������_����� = 1 AND ((SELECT COUNT(*) FROM ������� WHERE �������_����� = 1) >= 3) THEN ��������� * 2 ELSE ��������� END) AS �����_���������
FROM �������;