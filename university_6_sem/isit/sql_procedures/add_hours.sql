CREATE PROC add_hours
	@exam NVARCHAR(255),
	@hours INT
AS
	UPDATE e
	SET e.����������_����� = e.����������_����� + @hours
	FROM ������� e
	WHERE e.���_���������� = (SELECT ���_���������� FROM ���������� WHERE @exam = ������������_����������);
