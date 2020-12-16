SELECT * FROM Studenci 

GO
CREATE FUNCTION fNazwiskoNa
(
	@LastName VARCHAR(1)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Studenci WHERE LEFT(LastName,1) = @LastName
)

GO
SELECT * FROM fNazwiskoNa('W') 

SELECT  AVG(Age) FROM Studenci