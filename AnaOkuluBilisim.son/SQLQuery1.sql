


create table Ogrenciler
(OgrenciId varchar(20) primary key,
AdiSoyadi char(30),
Adres varchar(20),
Semt char(20),
ilce char(20),
il char(20),
PostaKodu int,
EvTel int,
KanGrubu varchar(15),
TcNo int,
Uyruk char(20),
Cinsiyet char(2),
KimlikSeriNo varchar(20),
DogumYeri char(20),
DogumTarihi date,
Dogumili char(20),
Dogumilce char(20),
Mahalle char(20),
Koy char(20),
Cilt varchar(20),
Aile char(20),
SiraNo int,
VerilisYeri char(20),
KayitNo int,Resim image,
KayitTarihi date,
CikisTarihi date,
SinifId varchar(20),
ServisAdi varchar(20),
DavranisSorunu varchar(50),
Yapilanlar varchar(50),YasitlariylaIliskisi varchar(50),
Fobileri varchar(50),
SevdigiYiyecekler varchar(50),
Asilar varchar(50),
GecirdigiHastaliklar varchar(50),
Alerjiler varchar(50),
Ameliyatlar varchar(50),
SaglikSorunlari varchar(50),
ilac varchar(50),
Protez varchar(50),
Diyet varchar(50),
RuhsalDurum varchar(50));


create table Veliler
(Adi char(20),Soyadi char(20),Ceptel varchar(20),EvTel int,
TcNo int,YakinlikDerecesi char(20),Meslek char(20),
OgrenciId int ,Email varchar(20), foreign key(OgrenciId) references Ogrenciler);


create table UcuncuSahislar
(Adi char(20),Soyadi char(20),Ceptel varchar(20),EvTel int,
TcNo int,YakinlikDerecesi char(20),Meslek char(20),
OgrenciId int ,Email varchar(20), foreign key(OgrenciId) references Ogrenciler);








