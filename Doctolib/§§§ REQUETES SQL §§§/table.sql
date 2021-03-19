Drop Table if exists Patient;
Drop Table if exists RDV;
Drop Table if exists Medecin;
Drop Table if exists Specialite;


/*
*Création table Patient
*/
CREATE TABLE dbo.Patient
(
[CodePatient] INT IDENTITY (1,1) NOT NULL,
[NomPatient] VARCHAR(50) NOT NULL,
[AdressePatient] VARCHAR(50) NOT NULL,
[DateNaissance] date NOT NULL,
[SexePatient] VARCHAR(50) NOT NULL,
[TelPatient] VARCHAR(50) NOT NULL,
PRIMARY KEY CLUSTERED ([CodePatient] ASC)
);


/*
*Création table RDV
*/
CREATE TABLE dbo.RDV
(
[NumeroRDV] INT IDENTITY (1,1) NOT NULL,
[DateRDV] date NOT NULL,
[HeureRDV] VARCHAR(50) NOT NULL,
[CodeMedecin] INT NOT NULL,
[CodePatient] INT NOT NULL,
PRIMARY KEY CLUSTERED ([NumeroRDV] ASC)
);


/*
*Création table Medecin
*/
CREATE TABLE dbo.Medecin
(
[CodeMedecin] INT IDENTITY (1,1) NOT NULL,
[NomMedecin] VARCHAR(50) NOT NULL,
[TelMedecin] VARCHAR(50) NOT NULL,
[DateEmbauche] date NOT NULL,
[IdSpecialiteMedecin] INT NOT NULL,
PRIMARY KEY CLUSTERED ([CodeMedecin] ASC)
);

/*
*Création table Specialite
*/
CREATE TABLE dbo.Specialite
(
[IdSpecialite] INT IDENTITY (1,1) NOT NULL,
[NomSpecialite] VARCHAR(100) NOT NULL,
PRIMARY KEY CLUSTERED ([IdSpecialite] ASC)
);


/*
Remplissage table Patient
*/
INSERT INTO [dbo].[Patient] ([NomPatient], [AdressePatient], [DateNaissance], [SexePatient], [TelPatient]) VALUES
(N'Patient1', N'Adresse1', N'06/02/1985', N'M', N'0987654321'),
(N'Patient2', N'Adresse2', N'06/05/1989', N'M', N'0612345678'),
(N'Patient3', N'Adresse3', N'06/02/1993', N'F', N'0987654321');


/*
Remplissage table Medecin
*/
INSERT INTO [dbo].[Medecin] ([NomMedecin], [TelMedecin], [DateEmbauche], [IdSpecialiteMedecin]) VALUES
(N'Medecin1', N'0987654321', N'06/02/2005', N'7'),
(N'Medecin2', N'0612345678', N'06/05/2009', N'8'),
(N'Medecin3', N'0987654321', N'06/02/2003', N'6');


/*
Remplissage table RDV
*/
INSERT INTO [dbo].[RDV] ([DateRDV], [HeureRDV], [CodeMedecin], [CodePatient]) VALUES
(N'02/01/2016', N'08:00', N'2', N'1'),
(N'03/01/2016', N'08:00', N'2', N'1'),
(N'02/01/2016', N'09:00', N'2', N'2'),
(N'02/01/2016', N'10:00', N'2', N'3');

/*
Remplissage table Specialite
*/
INSERT INTO [dbo].[Specialite] ([NomSpecialite]) VALUES
(N'Cardiologie'),
(N'Chirurgie'),
(N'Dermatologie'),
(N'Gériatrie'),
(N'Oncologie'),
(N'Pédiatrie'),
(N'Psychiatrie'),
(N'Allergologie');