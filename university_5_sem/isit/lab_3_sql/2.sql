SELECT * FROM Студент
WHERE Стипендия = (SELECT MAX(Стипендия) FROM Студент);