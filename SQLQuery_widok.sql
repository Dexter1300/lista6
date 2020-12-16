CREATE VIEW widok
AS
SELECT Studenci.Id,Studenci.FirstName,Studenci.LastName, Klasy.nr_klasy, Klasy.kierunek
FROM Klasy
INNER JOIN Studenci ON Studenci.Id = Klasy.id_studenta;

SELECT * FROM widok;