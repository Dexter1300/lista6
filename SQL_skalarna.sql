GO
CREATE FUNCTION sAverageAge
(

)
RETURNS INT 
AS

BEGIN
	
	RETURN 
	(
		SELECT AVG(Age) FROM Studenci
	)
END;

 
GO
SELECT dbo.sAverageAge() FROM Studenci
SELECT * FROM Studenci