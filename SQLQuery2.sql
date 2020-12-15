/****** Script for SelectTopNRows command from SSMS  ******/
GO 
CREATE PROCEDURE pDodanieStudenta
@Id INT, @FirstName VARCHAR(40), @LastName VARCHAR(40), @Age INT, @Pesel BIGINT, @Obraz VARCHAR(100)
AS
INSERT INTO Studenci (Id, FirstName, LastName, Age, Pesel, Obraz)VALUES(@Id, @FirstName, @LastName, @Age, @Pesel, @Obraz)

EXEC pDodanieStudenta 4, Wojciech, Adamczak, 42, 99093456782, obraz


GO 
CREATE PROCEDURE pZmiana
@Id INT, @FirstName VARCHAR(40), @LastName VARCHAR(40), @Age INT, @Pesel BIGINT, @Obraz VARCHAR(100)
AS
UPDATE Studenci SET FirstName = @FirstName, LastName = @LastName, Age = @Age, Pesel = @Pesel, Obraz = @Obraz WHERE Id = @Id

EXEC pZmiana 1,Adam,Nowak,32,90902323432,obrazek1 