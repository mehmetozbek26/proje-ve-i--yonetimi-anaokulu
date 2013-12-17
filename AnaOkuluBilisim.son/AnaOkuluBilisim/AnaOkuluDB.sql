
create table Personeller(
id int primary key,adi text,soyadi text,sicilno varchar(20),basvurutarihi varchar(20),
baslamatarihi varchar(20),askerlikdurumu varchar(20),tecilbitisyili varchar(20),
kangrubu char(10),cinsiyet varchar(10),adres varchar(20),semt varchar(20),
ilce varchar(20),il varchar(20), mail varchar(20),evtel varchar(20),ceptel varchar(20),
egitimdurumu varchar(20),ayrilistarihi varchar(20),resim varchar(20),tcno int,
Departman char(20),KtcNo int,Kuyruk char(20),Kcinsiyet char(1),
KkimlikSeriNo varchar(20),KdogumYeri char(20),KdogumTarihi date,Kdogumili char(20),
Kdogumilce char(20),Kmahalle char(20),Kkoy char(20),Kcilt char(20),Kaile char(20),
KSiraNo int,KVerilisYeri char(20),KKayitNo int);

create table Demirbaslar 
(Adi char(20),Turu char(20),Cinsi char(20),Adet int,Birim int,
AlindigiYer varchar(20),AlisTarihi date,GirisTutari money,AlisFaturaNo varchar(20),
KdvOrani int,KdvTutari money,SatisYeri char(20),SatisTarihi date,
SatisTutari money,SatisFaturaNo varchar(20),SatisKdvTutari money,SatisNedeni varchar(20));




create table Siniflar(
 sinifid  int primary key,Sinifadi char(10),Kapasitesi int,id int,OgretmenAdi char(20),
 ogretmenSoyadi char(20),foreign key(id) references Personeller);

 create table Ogretmenler(
 id int primary key,foreign key(id) references Personeller);
 
 
 
 create table pwd  
(
createpassword varchar(20),firstname char(20),lastname char(20),yas int,
cinsiyet char(10),yil int,adres varchar(20),irtibatno varchar(20),userid varchar(20),
sifre varchar(20),confirmpassword varchar(20),comdepart varchar(20),gun int,ay int);

create table Ogrenciler
(OgrenciId int primary key,Adi varchar(20),Soyadi varchar(20),Adres varchar(20),
Semt char(20),ilce char(20),il char(20),PostaKodu int,EvTel int,
KanGrubu varchar(15),TcNo int,Uyruk char(20),Cinsiyet varchar(10),
KimlikSeriNo varchar(20),DogumYeri char(20),DogumTarihi date,
Dogumili char(20),Dogumilce char(20),Mahalle char(20),Koy char(20),
Cilt varchar(20),Aile char(20),SiraNo int,VerilisYeri char(20),KayitNo int,Resim image,
KayitTarihi date,CikisTarihi date,SinifId int,Sinifi char(10),Servisi varchar(20),
DavranisSorunu varchar(50),Yapilanlar varchar(50),YasitlariylaIliskisi varchar(50),
Fobileri varchar(50),SevdigiYiyecekler varchar(50),Asilar varchar(50),GecirdigiHastaliklar varchar(50),
Alerjiler varchar(50),Ameliyatlar varchar(50),SaglikSorunlari varchar(50),ilac varchar(50),
Protez varchar(50),Diyet varchar(50),RuhsalDurum varchar(50));

create table Veliler
(Adi char(20),Soyadi char(20),Ceptel varchar(20),EvTel int,
TcNo int,YakinlikDerecesi char(20),Meslek char(20),
OgrenciId int ,Email varchar(20),foreign key(OgrenciId) references Ogrenciler);

create table UcuncuSahislar
(Adi char(20),Soyadi char(20),Ceptel varchar(20),EvTel int,
TcNo int,YakinlikDerecesi char(20),Meslek char(20),
OgrenciId int ,Email varchar(20),foreign key(ogrenciId) references Ogrenciler);

create table Yemekler(
Corba varchar(20),AnaYemek varchar(20),Tatli varchar(20),Tarih dateTime);

create table YoklamaEkle(
OgrenciId int primary key,Adi char(20),Soyadi char(20),Sinifi char(10),
Tarih dateTime,DevamsizlikTuru varchar(20),Aciklama text,
SinifId int,foreign key(ogrenciId) references Ogrenciler);

create table Servisler
(Servisi varchar(20));
insert into pwd
values ('1234','mehmet','ozbek',22,'erkek',1991,'eskisehir','0555','mehmet','1234','1234','YONETIM',12,12);

select * from pwd;