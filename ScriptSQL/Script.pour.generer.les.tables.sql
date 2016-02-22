SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Client]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Client](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[numero] [int] NOT NULL,
	[nom] [nvarchar](50) NOT NULL,
	[prenom] [nvarchar](50) NOT NULL,
	[raison_sociale] [nvarchar](50) NOT NULL,
	[adresse] [nvarchar](100) NOT NULL,
	[telephone] [nvarchar](50) NOT NULL,
	[pseudo] [nvarchar](50) NOT NULL,
	[mot_de_passe] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED
(
	[ID] ASC
) WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Compte]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Compte](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[numero] [int] NOT NULL,
	[iDClient] [uniqueidentifier] NOT NULL,
	[mode_de_facturation] [nvarchar](50) NOT NULL,
	[total_du_mois] [float] NOT NULL,
	[solde] [float] NOT NULL,
 CONSTRAINT [PK_Compte] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ServiceDiffusion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ServiceDiffusion](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[numero] [int] NOT NULL,
	[nom] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ServiceDiffusion] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Equipement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Equipement](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[numero] [int] NOT NULL,
	[nom] [nvarchar](100) NOT NULL,
	[tarif_mensuel_de_location] [float] NOT NULL,
	[idCompte] [uniqueidentifier],
 CONSTRAINT [PK_Equipement] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Installation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Installation](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[iDClient] [uniqueidentifier],
	[numero] [int] NOT NULL,
	[date_programmation] [nvarchar](50) NOT NULL,
	[date_realisation] [nvarchar](50) NOT NULL,
	[frais] [float] NOT NULL,
 CONSTRAINT [PK_Installation] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Chaine]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Chaine](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[numero] [int] NOT NULL,
	[sigle] [nvarchar](50) NOT NULL,
	[nom] [nvarchar](50) NOT NULL,
	[nature] [nvarchar](50) NOT NULL,
	[prix] [float] NOT NULL,
 CONSTRAINT [PK_Chaine] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdresseBranchee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AdresseBranchee](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[adresse] [nvarchar](50) NOT NULL,
	[branchee] [nvarchar] NOT NULL,
 CONSTRAINT [PK_AdresseBranchee] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompteChaine]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CompteChaine](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[id_compte] [nvarchar](100) NOT NULL,
	[id_chaine] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CompteChaine] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompteService]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CompteService](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[id_compte] [nvarchar](100) NOT NULL,
	[id_service] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CompteService] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ServiceChaine]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ServiceChaine](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[id_service] [nvarchar](100) NOT NULL,
	[id_chaine] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ServiceChaine] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employe]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employe](
	[iD] [uniqueidentifier] DEFAULT NEWSEQUENTIALID() NOT NULL,
	[numero] [int] NOT NULL,
	[nom] [nvarchar](50) NOT NULL,
	[prenom] [nvarchar](50) NOT NULL,
	[fonction] [nvarchar](50) NOT NULL,
	[adresse] [nvarchar](100) NOT NULL,
	[telephone] [nvarchar](50) NOT NULL,
	[salaire] [float] NOT NULL,
	[pseudo] [nvarchar](50) NOT NULL,
	[mot_de_passe] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employe] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
