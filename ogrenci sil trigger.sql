CREATE TRIGGER [Trigger]
	ON [dbo].[Ogrenciler]
	FOR DELETE
	AS
	BEGIN
		Declare @id int
		select @id=OgrenciId from deleted
		delete from Veliler where OgrenciId=@id
		delete from UcuncuSahislar where OgrenciId=@id
	END
