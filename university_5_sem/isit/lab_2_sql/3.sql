SELECT COUNT(*) AS ����������_���������, SUM(���������) AS ���������_���������, ���_����������, YEAR(CURRENT_TIMESTAMP) - YEAR(����_��������) AS �������
FROM �������
GROUP BY YEAR(CURRENT_TIMESTAMP) - YEAR(����_��������), ���_����������;