Create Trigger Insert_Transakcjas
ON Transakcjas
AFTER INSERT
AS
BEGIN
DECLARE
@x numeric,
@id numeric
SELECT @x = INSERTED.Ilosc, @id = INSERTED.ID_transakcji FROM INSERTED
UPDATE Artykuls SET Ilosc = Ilosc - @x WHERE Id_towaru = @id
END