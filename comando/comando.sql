USE [Comando]
GO
/****** Object:  Table [dbo].[Agente]    Script Date: 19/05/2018 18:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agente](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Cognome] [nvarchar](100) NOT NULL,
	[Grado] [nvarchar](100) NULL,
	[PoliziaGiudiziaria] [bit] NULL,
 CONSTRAINT [PK_Agente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Applications]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[ApplicationName] [nvarchar](235) NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK_Applications] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Applications](
	[ApplicationName] [nvarchar](256) NOT NULL,
	[LoweredApplicationName] [nvarchar](256) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK_aspnet_Applications] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Membership](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[MobilePIN] [nvarchar](16) NULL,
	[Email] [nvarchar](256) NULL,
	[LoweredEmail] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NOT NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_aspnet_Membership] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Paths]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Paths](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NOT NULL,
	[Path] [nvarchar](256) NOT NULL,
	[LoweredPath] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_aspnet_Paths] PRIMARY KEY CLUSTERED 
(
	[PathId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationAllUsers]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers](
	[PathId] [uniqueidentifier] NOT NULL,
	[PageSettings] [varbinary](max) NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_aspnet_PersonalizationAllUsers] PRIMARY KEY CLUSTERED 
(
	[PathId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationPerUser]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_PersonalizationPerUser](
	[Id] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[PageSettings] [varbinary](max) NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_aspnet_PersonalizationPerUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Profile]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Profile](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [nvarchar](max) NOT NULL,
	[PropertyValuesString] [nvarchar](max) NOT NULL,
	[PropertyValuesBinary] [varbinary](max) NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_aspnet_Profile] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[LoweredRoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK_aspnet_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_SchemaVersions](
	[Feature] [nvarchar](128) NOT NULL,
	[CompatibleSchemaVersion] [nvarchar](128) NOT NULL,
	[IsCurrentVersion] [bit] NOT NULL,
 CONSTRAINT [PK_aspnet_SchemaVersions] PRIMARY KEY CLUSTERED 
(
	[Feature] ASC,
	[CompatibleSchemaVersion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[LoweredUserName] [nvarchar](256) NOT NULL,
	[MobileAlias] [nvarchar](16) NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
 CONSTRAINT [PK_aspnet_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 19/05/2018 18:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_UsersInRoles](
	[aspnet_Roles_RoleId] [uniqueidentifier] NOT NULL,
	[aspnet_Users_UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_aspnet_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[aspnet_Roles_RoleId] ASC,
	[aspnet_Users_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_WebEvent_Events](
	[EventId] [char](32) NOT NULL,
	[EventTimeUtc] [datetime] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventType] [nvarchar](256) NOT NULL,
	[EventSequence] [decimal](19, 0) NOT NULL,
	[EventOccurrence] [decimal](19, 0) NOT NULL,
	[EventCode] [int] NOT NULL,
	[EventDetailCode] [int] NOT NULL,
	[Message] [nvarchar](1024) NULL,
	[ApplicationPath] [nvarchar](256) NULL,
	[ApplicationVirtualPath] [nvarchar](256) NULL,
	[MachineName] [nvarchar](256) NOT NULL,
	[RequestUrl] [nvarchar](1024) NULL,
	[ExceptionType] [nvarchar](256) NULL,
	[Details] [nvarchar](max) NULL,
 CONSTRAINT [PK_aspnet_WebEvent_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attore]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attore](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nchar](100) NULL,
	[Cognome] [nchar](100) NULL,
	[DataNascita] [datetime] NULL,
	[CittaNascita] [nchar](100) NULL,
	[StatoNascita] [nchar](100) NULL,
	[CapNascita] [nchar](10) NULL,
	[CittaResidenza] [nchar](100) NULL,
	[ViaResidenza] [nchar](100) NULL,
	[CivicoResidenza] [nchar](20) NULL,
	[CapResidenza] [nchar](10) NULL,
	[CF] [nchar](20) NULL,
	[DocumentoTipo] [nvarchar](200) NULL,
	[DocumentoNumero] [nvarchar](200) NULL,
	[Ruolo] [nvarchar](100) NULL,
 CONSTRAINT [PK_Attore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Avvocato]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avvocato](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Cognome] [nvarchar](50) NOT NULL,
	[IndirizzoStudio] [nvarchar](1000) NULL,
	[TelefonoStudio] [nvarchar](50) NULL,
	[FaxStudio] [nvarchar](50) NULL,
	[Cellulare] [nvarchar](50) NULL,
	[Email] [nvarchar](500) NULL,
	[Foro] [nvarchar](200) NULL,
	[CittaStudio] [nvarchar](100) NULL,
	[Assegnato] [bit] NULL,
 CONSTRAINT [PK_Avvocato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriaVerbale]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaVerbale](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nchar](70) NULL,
	[IDPadre] [bigint] NULL,
	[Pagina] [nvarchar](200) NULL,
	[Sotto] [int] NULL,
 CONSTRAINT [PK_CategoriaVerbale] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comuni]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comuni](
	[Id] [int] NOT NULL,
	[nome] [nchar](200) NOT NULL,
	[idprovincia] [int] NOT NULL,
	[idregione] [int] NOT NULL,
	[catasto] [nvarchar](25) NULL,
 CONSTRAINT [PK_Comuni] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Custode]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Custode](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Comune] [nvarchar](100) NULL,
	[Ditta] [nvarchar](500) NULL,
	[Indirizzo] [nvarchar](500) NULL,
	[Nome] [nvarchar](100) NULL,
	[Cognome] [nvarchar](100) NULL,
 CONSTRAINT [PK_Custode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[documenti_categorie]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[documenti_categorie](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descrizione] [varchar](250) NOT NULL,
	[Categoria] [int] NULL,
	[SottoCategoria] [int] NULL,
 CONSTRAINT [PK_documenti_categorie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documento]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nchar](70) NULL,
	[Titolo] [nchar](70) NULL,
	[Numero] [nchar](1000) NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentoCollegato]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentoCollegato](
	[Id] [binary](10) NOT NULL,
	[Path] [nvarchar](500) NULL,
	[Verbale_Id] [bigint] NULL,
 CONSTRAINT [PK_DocumentoCollegato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentoWord]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentoWord](
	[Id] [bigint] NOT NULL,
	[Path] [nvarchar](500) NULL,
	[Titolo] [nvarchar](100) NULL,
	[Verbale_Id] [bigint] NULL,
	[Categoria] [bigint] NULL,
 CONSTRAINT [PK_DocumentoWord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaComuni]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaComuni](
	[ID] [int] NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[CAP] [nvarchar](5) NOT NULL,
	[Cestino] [int] NOT NULL,
	[IDProv] [bigint] NULL,
 CONSTRAINT [PK_ListaComuni] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Memberships]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memberships](
	[UserId] [uniqueidentifier] NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowsStart] [datetime] NOT NULL,
	[Comment] [nvarchar](256) NULL,
 CONSTRAINT [PK_Memberships] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Categoria] [nchar](50) NULL,
	[Numero] [nchar](40) NULL,
	[RilasciataDa] [nchar](100) NULL,
	[Data] [datetime] NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [nvarchar](max) NOT NULL,
	[PropertyValueStrings] [nvarchar](max) NOT NULL,
	[PropertyValueBinary] [varbinary](max) NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proprietario]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proprietario](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nchar](100) NULL,
	[Cognome] [nchar](100) NULL,
	[CittaNascita] [nchar](100) NULL,
	[DataNascita] [datetime] NULL,
	[CittaResidenza] [nchar](100) NULL,
	[IndirizzoResidenza] [nchar](500) NULL,
	[PatenteId] [bigint] NULL,
 CONSTRAINT [PK_Proprietario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[idprovincia] [int] NOT NULL,
	[nomeprovincia] [nvarchar](20) NOT NULL,
	[idregione] [int] NOT NULL,
	[siglaprovincia] [nchar](4) NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[idprovincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regioni]    Script Date: 19/05/2018 18:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regioni](
	[idregione] [int] NOT NULL,
	[nomeregione] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Regioni] PRIMARY KEY CLUSTERED 
(
	[idregione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stati]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stati](
	[Codice2] [nchar](6) NULL,
	[Codice3] [nchar](6) NULL,
	[Id] [bigint] NOT NULL,
	[Nome] [nchar](100) NOT NULL,
	[NomeOriginale] [nchar](100) NULL,
	[Sigla] [nvarchar](5) NULL,
 CONSTRAINT [PK_Stati] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipologiaAnagrafica]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipologiaAnagrafica](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nchar](70) NULL,
	[IDPadre] [bigint] NULL,
 CONSTRAINT [PK_TipologiaAnagrafica] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoVeicolo]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoVeicolo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TipoVeicolo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trasgressore]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trasgressore](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nchar](100) NULL,
	[Cognome] [nchar](100) NULL,
	[DataNascita] [datetime] NULL,
	[CittaNascita] [nchar](100) NULL,
	[StatoNascita] [nchar](100) NULL,
	[CapNascita] [nchar](10) NULL,
	[CittaResidenza] [nchar](100) NULL,
	[ViaResidenza] [nchar](100) NULL,
	[CivicoResidenza] [nchar](20) NULL,
	[CapResidenza] [nchar](10) NULL,
	[CF] [nchar](20) NULL,
	[Sesso] [nchar](1) NULL,
	[CIttaDomicilio] [nvarchar](100) NULL,
	[IndirizzoDomicilio] [nvarchar](500) NULL,
	[PatenteId] [bigint] NULL,
 CONSTRAINT [PK_Trasgressore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[Roles_RoleId] [uniqueidentifier] NOT NULL,
	[Users_UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[Roles_RoleId] ASC,
	[Users_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersOpenAuthAccounts]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersOpenAuthAccounts](
	[ApplicationName] [nvarchar](128) NOT NULL,
	[ProviderName] [nvarchar](128) NOT NULL,
	[ProviderUserId] [nvarchar](128) NOT NULL,
	[ProviderUserName] [nvarchar](max) NOT NULL,
	[MembershipUserName] [nvarchar](128) NOT NULL,
	[LastUsedUtc] [datetime] NULL,
 CONSTRAINT [PK_UsersOpenAuthAccounts] PRIMARY KEY CLUSTERED 
(
	[ApplicationName] ASC,
	[ProviderName] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersOpenAuthData]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersOpenAuthData](
	[ApplicationName] [nvarchar](128) NOT NULL,
	[MembershipUserName] [nvarchar](128) NOT NULL,
	[HasLocalPassword] [bit] NOT NULL,
 CONSTRAINT [PK_UsersOpenAuthData] PRIMARY KEY CLUSTERED 
(
	[ApplicationName] ASC,
	[MembershipUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[Id] [bigint] NOT NULL,
	[Login] [nchar](50) NULL,
	[Pwd] [nchar](50) NULL,
	[UltimoAccesso] [datetime] NULL,
	[Descrizione] [nvarchar](50) NULL,
	[Amministratore] [bit] NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Veicolo]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Veicolo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[marca] [nvarchar](100) NULL,
	[modello] [nvarchar](100) NULL,
	[targa] [nvarchar](100) NULL,
	[telaio] [nvarchar](100) NULL,
	[colore] [nvarchar](100) NULL,
	[TipoVeicolo_Id] [int] NOT NULL,
	[Nome] [nchar](100) NULL,
	[Id_Proprietario] [bigint] NULL,
	[Id_Custode] [bigint] NULL,
 CONSTRAINT [PK_Veicolo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Verbale]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Verbale](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nchar](100) NULL,
	[Path] [nchar](100) NULL,
	[Registro] [nchar](50) NULL,
	[DataOraApertura] [datetime] NULL,
	[DataOraChiusura] [datetime] NULL,
	[Protocollo] [nvarchar](100) NULL,
	[Data] [datetime] NULL,
	[Indirizzo] [nvarchar](1000) NULL,
	[Violazione_Id] [bigint] NULL,
	[Doc_Id] [bigint] NULL,
	[Category_Id] [bigint] NULL,
	[Timestamp]  AS (getdate()),
	[Agente2_Id] [bigint] NULL,
	[Agente1_Id] [bigint] NULL,
	[Avvocato_Id] [bigint] NULL,
	[CategoriaVerbale_ID] [bigint] NULL,
	[Trasgressore_Id] [bigint] NULL,
	[Utente_Id] [bigint] NULL,
	[Veicolo_Id] [bigint] NULL,
 CONSTRAINT [PK_Verbale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VerbaleAgente]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VerbaleAgente](
	[Agente_Id] [bigint] NOT NULL,
	[Verbale_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_VerbaleAgente] PRIMARY KEY CLUSTERED 
(
	[Agente_Id] ASC,
	[Verbale_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VerbaleElezioneDomicilio]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VerbaleElezioneDomicilio](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Titolo] [nvarchar](500) NULL,
	[Giorno] [nchar](100) NULL,
	[Ora] [nchar](20) NULL,
	[PenitGrado] [nvarchar](50) NULL,
	[PenitNome] [nvarchar](250) NULL,
	[PenitCognome] [nvarchar](250) NULL,
	[DataTrasgressione] [datetime] NULL,
	[DataVerbale] [datetime] NULL,
	[IdentificatoMediante] [nvarchar](250) NULL,
	[LingueParlate] [nvarchar](max) NULL,
	[MiChiamo] [nvarchar](200) NULL,
	[SonoNato] [nvarchar](200) NULL,
	[DataNascita] [datetime] NULL,
	[ResidenteA] [nvarchar](150) NULL,
	[InVia] [nvarchar](250) NULL,
	[AvvocatoNominato] [nvarchar](200) NULL,
	[AvvocatoStudioVia] [nvarchar](200) NULL,
	[AvvocatoStudioTel] [nvarchar](50) NULL,
	[AvvocatoStudioFax] [nvarchar](50) NULL,
	[AvvocatoStudioCell] [nvarchar](50) NULL,
	[AvvocatoStudioEmail] [nvarchar](500) NULL,
 CONSTRAINT [PK_VerbaleElezioneDomicilio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Violazione]    Script Date: 19/05/2018 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Violazione](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](150) NULL,
	[Descrizione] [nvarchar](500) NULL,
	[Data] [datetime] NULL,
	[Articolo] [nvarchar](100) NULL,
	[Indirizzo] [nvarchar](500) NULL,
	[Citta] [nvarchar](200) NULL,
	[Verbale_Id] [bigint] NULL,
 CONSTRAINT [PK_Violazione] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Me__Appli__37FA4C37] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Membership] CHECK CONSTRAINT [FK__aspnet_Me__Appli__37FA4C37]
GO
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Me__UserI__38EE7070] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_Membership] CHECK CONSTRAINT [FK__aspnet_Me__UserI__38EE7070]
GO
ALTER TABLE [dbo].[aspnet_Paths]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pa__Appli__6991A7CB] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Paths] CHECK CONSTRAINT [FK__aspnet_Pa__Appli__6991A7CB]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pe__PathI__6F4A8121] FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] CHECK CONSTRAINT [FK__aspnet_Pe__PathI__6F4A8121]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pe__PathI__731B1205] FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] CHECK CONSTRAINT [FK__aspnet_Pe__PathI__731B1205]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pe__UserI__740F363E] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] CHECK CONSTRAINT [FK__aspnet_Pe__UserI__740F363E]
GO
ALTER TABLE [dbo].[aspnet_Profile]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pr__UserI__4CF5691D] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_Profile] CHECK CONSTRAINT [FK__aspnet_Pr__UserI__4CF5691D]
GO
ALTER TABLE [dbo].[aspnet_Roles]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Ro__Appli__567ED357] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Roles] CHECK CONSTRAINT [FK__aspnet_Ro__Appli__567ED357]
GO
ALTER TABLE [dbo].[aspnet_Users]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Us__Appli__27C3E46E] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Users] CHECK CONSTRAINT [FK__aspnet_Us__Appli__27C3E46E]
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Roles] FOREIGN KEY([aspnet_Roles_RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] CHECK CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Roles]
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Users] FOREIGN KEY([aspnet_Users_UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] CHECK CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Users]
GO
ALTER TABLE [dbo].[DocumentoCollegato]  WITH CHECK ADD  CONSTRAINT [FK_DocumentoCollegato_VerbaleElezioneDomicilio] FOREIGN KEY([Verbale_Id])
REFERENCES [dbo].[VerbaleElezioneDomicilio] ([Id])
GO
ALTER TABLE [dbo].[DocumentoCollegato] CHECK CONSTRAINT [FK_DocumentoCollegato_VerbaleElezioneDomicilio]
GO
ALTER TABLE [dbo].[DocumentoWord]  WITH CHECK ADD  CONSTRAINT [FK_VerbaleElezioneDomicilioDocumentoWord] FOREIGN KEY([Verbale_Id])
REFERENCES [dbo].[VerbaleElezioneDomicilio] ([Id])
GO
ALTER TABLE [dbo].[DocumentoWord] CHECK CONSTRAINT [FK_VerbaleElezioneDomicilioDocumentoWord]
GO
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [FK_MembershipEntity_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [FK_MembershipEntity_Application]
GO
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [FK_MembershipEntity_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [FK_MembershipEntity_User]
GO
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [FK_ProfileEntity_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_ProfileEntity_User]
GO
ALTER TABLE [dbo].[Proprietario]  WITH CHECK ADD  CONSTRAINT [FK_Proprietario_Patente] FOREIGN KEY([PatenteId])
REFERENCES [dbo].[Patente] ([Id])
GO
ALTER TABLE [dbo].[Proprietario] CHECK CONSTRAINT [FK_Proprietario_Patente]
GO
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [FK_RoleEntity_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [FK_RoleEntity_Application]
GO
ALTER TABLE [dbo].[TipologiaAnagrafica]  WITH CHECK ADD  CONSTRAINT [FK_TipologiaAnagrafica_TipologiaAnagrafica] FOREIGN KEY([ID])
REFERENCES [dbo].[TipologiaAnagrafica] ([ID])
GO
ALTER TABLE [dbo].[TipologiaAnagrafica] CHECK CONSTRAINT [FK_TipologiaAnagrafica_TipologiaAnagrafica]
GO
ALTER TABLE [dbo].[Trasgressore]  WITH CHECK ADD  CONSTRAINT [FK_Trasgressore_Patente] FOREIGN KEY([PatenteId])
REFERENCES [dbo].[Patente] ([Id])
GO
ALTER TABLE [dbo].[Trasgressore] CHECK CONSTRAINT [FK_Trasgressore_Patente]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Application]
GO
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRoles_Roles] FOREIGN KEY([Roles_RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [FK_UsersInRoles_Roles]
GO
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRoles_Users] FOREIGN KEY([Users_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [FK_UsersInRoles_Users]
GO
ALTER TABLE [dbo].[UsersOpenAuthAccounts]  WITH CHECK ADD  CONSTRAINT [FK_OpenAuthUserData_Accounts] FOREIGN KEY([ApplicationName], [MembershipUserName])
REFERENCES [dbo].[UsersOpenAuthData] ([ApplicationName], [MembershipUserName])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersOpenAuthAccounts] CHECK CONSTRAINT [FK_OpenAuthUserData_Accounts]
GO
ALTER TABLE [dbo].[Veicolo]  WITH CHECK ADD  CONSTRAINT [FK_Veicolo_Custode] FOREIGN KEY([Id_Custode])
REFERENCES [dbo].[Custode] ([Id])
GO
ALTER TABLE [dbo].[Veicolo] CHECK CONSTRAINT [FK_Veicolo_Custode]
GO
ALTER TABLE [dbo].[Veicolo]  WITH CHECK ADD  CONSTRAINT [FK_Veicolo_TipoVeicolo] FOREIGN KEY([TipoVeicolo_Id])
REFERENCES [dbo].[TipoVeicolo] ([Id])
GO
ALTER TABLE [dbo].[Veicolo] CHECK CONSTRAINT [FK_Veicolo_TipoVeicolo]
GO
ALTER TABLE [dbo].[Veicolo]  WITH CHECK ADD  CONSTRAINT [FK_VeicoloProprietario] FOREIGN KEY([Id_Proprietario])
REFERENCES [dbo].[Proprietario] ([Id])
GO
ALTER TABLE [dbo].[Veicolo] CHECK CONSTRAINT [FK_VeicoloProprietario]
GO
ALTER TABLE [dbo].[Verbale]  WITH CHECK ADD  CONSTRAINT [FK_Verbale_Agente1] FOREIGN KEY([Agente1_Id])
REFERENCES [dbo].[Agente] ([Id])
GO
ALTER TABLE [dbo].[Verbale] CHECK CONSTRAINT [FK_Verbale_Agente1]
GO
ALTER TABLE [dbo].[Verbale]  WITH CHECK ADD  CONSTRAINT [FK_Verbale_Agente2] FOREIGN KEY([Agente2_Id])
REFERENCES [dbo].[Agente] ([Id])
GO
ALTER TABLE [dbo].[Verbale] CHECK CONSTRAINT [FK_Verbale_Agente2]
GO
ALTER TABLE [dbo].[Verbale]  WITH CHECK ADD  CONSTRAINT [FK_Verbale_Avvocato] FOREIGN KEY([Avvocato_Id])
REFERENCES [dbo].[Avvocato] ([Id])
GO
ALTER TABLE [dbo].[Verbale] CHECK CONSTRAINT [FK_Verbale_Avvocato]
GO
ALTER TABLE [dbo].[Verbale]  WITH CHECK ADD  CONSTRAINT [FK_Verbale_CategoriaVerbale] FOREIGN KEY([CategoriaVerbale_ID])
REFERENCES [dbo].[CategoriaVerbale] ([ID])
GO
ALTER TABLE [dbo].[Verbale] CHECK CONSTRAINT [FK_Verbale_CategoriaVerbale]
GO
ALTER TABLE [dbo].[Verbale]  WITH CHECK ADD  CONSTRAINT [FK_Verbale_Trasgressore] FOREIGN KEY([Trasgressore_Id])
REFERENCES [dbo].[Trasgressore] ([Id])
GO
ALTER TABLE [dbo].[Verbale] CHECK CONSTRAINT [FK_Verbale_Trasgressore]
GO
ALTER TABLE [dbo].[Verbale]  WITH CHECK ADD  CONSTRAINT [FK_Verbale_Utente] FOREIGN KEY([Utente_Id])
REFERENCES [dbo].[Utente] ([Id])
GO
ALTER TABLE [dbo].[Verbale] CHECK CONSTRAINT [FK_Verbale_Utente]
GO
ALTER TABLE [dbo].[Verbale]  WITH CHECK ADD  CONSTRAINT [FK_Verbale_Veicolo] FOREIGN KEY([Veicolo_Id])
REFERENCES [dbo].[Veicolo] ([Id])
GO
ALTER TABLE [dbo].[Verbale] CHECK CONSTRAINT [FK_Verbale_Veicolo]
GO
ALTER TABLE [dbo].[VerbaleAgente]  WITH CHECK ADD  CONSTRAINT [FK_VerbaleAgente_Agente] FOREIGN KEY([Agente_Id])
REFERENCES [dbo].[Agente] ([Id])
GO
ALTER TABLE [dbo].[VerbaleAgente] CHECK CONSTRAINT [FK_VerbaleAgente_Agente]
GO
ALTER TABLE [dbo].[VerbaleAgente]  WITH CHECK ADD  CONSTRAINT [FK_VerbaleAgente_Verbale] FOREIGN KEY([Verbale_Id])
REFERENCES [dbo].[Verbale] ([Id])
GO
ALTER TABLE [dbo].[VerbaleAgente] CHECK CONSTRAINT [FK_VerbaleAgente_Verbale]
GO
ALTER TABLE [dbo].[Violazione]  WITH CHECK ADD  CONSTRAINT [FK_VerbaleViolazione] FOREIGN KEY([Verbale_Id])
REFERENCES [dbo].[Verbale] ([Id])
GO
ALTER TABLE [dbo].[Violazione] CHECK CONSTRAINT [FK_VerbaleViolazione]
GO
