CREATE PROC add_cash
AS
    UPDATE s
    SET s.��������� =
        CASE
            WHEN (s.�������_����� = 1 AND s.��������� != 0 AND s.��������� IS NOT NULL) THEN s.��������� * 3
            WHEN (s.�������_����� = 1) THEN 2200
            ELSE s.��������� + 1100
        END
    FROM ������� s;