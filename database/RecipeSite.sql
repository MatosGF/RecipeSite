/*
  RecipeSite - database script (schema + sample data)
  Target: SQL Server 2019+ / SQL Server Express

  Creates the RecipeSite database, tables, constraints and sample data.
  Test accounts (password for both: 123456):
    admin@recipesite.com  (administrator)
    user@recipesite.com   (regular user)
*/
USE [master]
GO
CREATE DATABASE [RecipeSite]
GO
USE [RecipeSite]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Difficulties]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Difficulties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Difficulties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasurementTypes]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MeasurementTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RatingValue] [decimal](18, 2) NOT NULL,
	[UserId] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeCategories]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_RecipeCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeIngredients]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeIngredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NOT NULL,
	[MeasurementTypeId] [int] NOT NULL,
	[IngredientId] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[PreparationTime] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[DifficultyId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13/10/2026 20:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[BirthDate] [datetime] NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[IsRegistered] [bit] NULL,
	[IsAdmin] [bit] NULL,
	[Favorites] [nvarchar](max) NULL,
	[Recipes] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsBlocked] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [IsActive]) VALUES (12, N'Invernos', 0)
INSERT [dbo].[Categories] ([Id], [Name], [IsActive]) VALUES (13, N'Verão', 0)
INSERT [dbo].[Categories] ([Id], [Name], [IsActive]) VALUES (14, N'Primavera', 0)
INSERT [dbo].[Categories] ([Id], [Name], [IsActive]) VALUES (15, N'Outono', 0)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [Comments], [UserId], [RecipeId], [IsActive], [CreatedAt]) VALUES (7, N'Muito fácil de fazer!', 3, 21, 0, CAST(N'2026-06-22T13:01:40.003' AS DateTime))
INSERT [dbo].[Comments] ([Id], [Comments], [UserId], [RecipeId], [IsActive], [CreatedAt]) VALUES (8, N'Ficou ótima, vou repetir!', 2, 21, 0, CAST(N'2026-06-22T18:32:52.437' AS DateTime))
INSERT [dbo].[Comments] ([Id], [Comments], [UserId], [RecipeId], [IsActive], [CreatedAt]) VALUES (9, N'Adorei a combinação de sabores.', 2, 21, 0, CAST(N'2026-06-22T18:33:53.633' AS DateTime))
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Difficulties] ON 

INSERT [dbo].[Difficulties] ([Id], [Name], [IsActive]) VALUES (7, N'Fácil', 1)
INSERT [dbo].[Difficulties] ([Id], [Name], [IsActive]) VALUES (9, N'Difícil', 1)
INSERT [dbo].[Difficulties] ([Id], [Name], [IsActive]) VALUES (10, N'Médio', 0)
INSERT [dbo].[Difficulties] ([Id], [Name], [IsActive]) VALUES (11, N'Rápidos', 0)
SET IDENTITY_INSERT [dbo].[Difficulties] OFF
GO
SET IDENTITY_INSERT [dbo].[Favorites] ON 

INSERT [dbo].[Favorites] ([Id], [UserId], [RecipeId], [IsActive]) VALUES (26, 5, 19, 1)
INSERT [dbo].[Favorites] ([Id], [UserId], [RecipeId], [IsActive]) VALUES (27, 3, 21, 1)
INSERT [dbo].[Favorites] ([Id], [UserId], [RecipeId], [IsActive]) VALUES (29, 1, 19, 1)
INSERT [dbo].[Favorites] ([Id], [UserId], [RecipeId], [IsActive]) VALUES (30, 2, 19, 1)
SET IDENTITY_INSERT [dbo].[Favorites] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredients] ON 

INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (8, N'Tomate', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (12, N'Vagem', 0)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (19, N'Brócolis', 0)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (20, N'Alface romana', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (21, N'Alface iceberg', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (22, N'Alface frisada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (23, N'Alface roxa', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (24, N'Rúcula', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (25, N'Agrião', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (26, N'Espinafre', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (27, N'Couve kale', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (28, N'Couve lombarda', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (29, N'Couve chinesa', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (30, N'Repolho roxo', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (31, N'Repolho branco', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (32, N'Endívia', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (33, N'Radicchio', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (34, N'Canónigos', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (35, N'Coentros', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (36, N'Salsa', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (37, N'Cebolinho', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (38, N'Manjericão', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (39, N'Hortelã', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (40, N'Tomilho', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (41, N'Orégãos frescos', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (42, N'Alecrim', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (43, N'Funcho', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (44, N'Aipo', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (45, N'Pepino', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (46, N'Pepino mini', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (47, N'Tomate cereja', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (48, N'Tomate coração de boi', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (49, N'Tomate seco', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (50, N'Tomate pera', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (51, N'Tomate amarelo', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (52, N'Pimento vermelho', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (53, N'Pimento amarelo', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (54, N'Pimento verde', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (55, N'Pimento laranja', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (56, N'Cebola roxa', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (57, N'Cebola branca', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (58, N'Cebola caramelizada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (59, N'Alho francês', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (60, N'Rabanete', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (61, N'Beterraba', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (62, N'Beterraba dourada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (63, N'Cenoura', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (64, N'Cenoura roxa', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (65, N'Curgete', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (66, N'Curgete grelhada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (67, N'Beringela grelhada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (68, N'Espargos verdes', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (69, N'Espargos brancos', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (70, N'Cogumelos paris', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (71, N'Cogumelos portobello', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (72, N'Cogumelos shiitake', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (73, N'Milho doce', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (74, N'Ervilhas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (75, N'Favas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (76, N'Grão de bico', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (77, N'Feijão preto', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (78, N'Feijão vermelho', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (79, N'Feijão branco', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (80, N'Lentilhas verdes', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (81, N'Lentilhas vermelhas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (82, N'Quinoa branca', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (83, N'Quinoa vermelha', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (84, N'Arroz integral', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (85, N'Arroz selvagem', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (86, N'Cuscuz', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (87, N'Bulgur', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (88, N'Massa fusilli', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (89, N'Massa penne', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (90, N'Batata doce ', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (91, N'Batata nova', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (92, N'Abóbora assada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (93, N'Abacate', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (94, N'Manga', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (95, N'Maçã verde', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (96, N'Maçã vermelha', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (97, N'Pera', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (98, N'Figo fresco', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (99, N'Figo seco', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (100, N'Romã', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (101, N'Laranja', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (102, N'Toranja', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (103, N'Kiwi', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (104, N'Ananás', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (105, N'Melancia', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (106, N'Melão', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (107, N'Uvas verdes', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (108, N'Uvas roxas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (109, N'Mirtilos', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (110, N'Framboesas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (111, N'Morangos', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (112, N'Cranberries secas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (113, N'Passas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (114, N'Damascos secos', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (115, N'Tâmara', 1)
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (116, N'Nozes', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (117, N'Amêndoas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (118, N'Avelãs', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (119, N'Caju', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (120, N'Pistácio', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (121, N'Pinhões', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (122, N'Sementes de chia', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (123, N'Sementes de linhaça', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (124, N'Sementes de sésamo', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (125, N'Sementes de abóbora', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (126, N'Sementes de girassol', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (127, N'Tofu fumado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (128, N'Tofu natural', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (129, N'Tempeh', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (130, N'Seitan', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (131, N'Queijo feta', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (132, N'Queijo de cabra', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (133, N'Mozzarella fresca', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (134, N'Parmesão', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (135, N'Queijo azul', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (136, N'Burrata', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (137, N'Ovo cozido', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (138, N'Azeitonas pretas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (139, N'Azeitonas verdes', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (140, N'Alcaparras', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (141, N'Pepino em pickle', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (142, N'Cebola em pickle', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (143, N'Gengibre em conserva', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (144, N'Algas wakame', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (145, N'Edamame', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (146, N'Rebentos de soja', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (147, N'Rebentos de alfafa', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (148, N'Rebentos de rabanete', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (149, N'Rebentos de ervilha', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (150, N'Pêra abacate', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (151, N'Nabo', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (152, N'Nabo roxo', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (153, N'Pastinaca', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (154, N'Aipo nabo', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (155, N'Chucrute', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (156, N'Kimchi', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (157, N'Jalapenho', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (158, N'Malagueta vermelha', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (159, N'Malagueta verde', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (160, N'Pimenta rosa', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (161, N'Pimenta preta', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (162, N'Caril', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (163, N'Cominhos', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (164, N'Paprica fumada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (165, N'Mostarda dijon', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (166, N'Mostarda antiga', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (167, N'Vinagre balsâmico', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (168, N'Vinagre de maçã', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (169, N'Vinagre de vinho tinto', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (170, N'Azeite virgem extra', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (171, N'Óleo de sésamo', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (172, N'Molho de soja', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (173, N'Tahini', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (174, N'Iogurte grego', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (175, N'Iogurte natural', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (176, N'Limão', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (177, N'Lima', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (178, N'Mel', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (179, N'Xarope de ácer', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (180, N'Molho pesto', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (181, N'Húmus', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (182, N'Falafel', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (183, N'Croûtons', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (184, N'Pão pita torrado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (185, N'Tortilha crocante', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (186, N'Cebola frita', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (187, N'Alho crocante', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (188, N'Grão torrado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (189, N'Amêndoa laminada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (190, N'Noz pecã', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (191, N'Castanha assada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (192, N'Castanha de caju tostada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (193, N'Amendoim torrado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (194, N'Coco ralado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (195, N'Coco tostado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (196, N'Papaia', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (197, N'Maracujá', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (198, N'Pêssego', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (199, N'Nectarina', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (200, N'Ameixa', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (201, N'Cerejas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (202, N'Figos caramelizados', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (203, N'Abóbora manteiga', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (204, N'Couve flor assada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (205, N'Brócolos', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (206, N'Brócolos assados', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (207, N'Couve de bruxelas', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (208, N'Couve de bruxelas assada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (209, N'Erva doce', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (210, N'Alho assado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (211, N'Beterraba assada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (212, N'Cenoura assada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (213, N'Pimento assado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (214, N'Courgette assada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (215, N'Beringela assada', 1)
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (216, N'Cogumelos assados', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (217, N'Tofu grelhado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (218, N'Tempeh grelhado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (219, N'Seitan grelhado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (220, N'Queijo halloumi', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (221, N'Halloumi grelhado', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (222, N'Mozzarella fumada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (223, N'Ricotta', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (224, N'Ricotta temperada', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (225, N'Queijo fresco', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (226, N'Queijo flamengo', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (227, N'Queijo cheddar', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (228, N'Queijo emmental', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (229, N'Queijo gouda', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (230, N'Queijo brie', 1)
INSERT [dbo].[Ingredients] ([Id], [Name], [IsActive]) VALUES (231, N'Queijo camembert', 1)
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
GO
SET IDENTITY_INSERT [dbo].[MeasurementTypes] ON 

INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (1, N'unidade', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (2, N'grama', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (3, N'fatia', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (4, N'Unidade', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (5, N'Colher de sopa', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (6, N'Colher de chá', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (7, N'Chávena', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (8, N'Taça', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (9, N'Fatia', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (10, N'Folha', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (11, N'Dente', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (12, N'Ramo', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (13, N'Punhado', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (14, N'Ml', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (15, N'Gramas', 1)
INSERT [dbo].[MeasurementTypes] ([Id], [Name], [IsActive]) VALUES (16, N'Kg', 1)
SET IDENTITY_INSERT [dbo].[MeasurementTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 

INSERT [dbo].[Ratings] ([Id], [RatingValue], [UserId], [RecipeId], [IsActive]) VALUES (9, CAST(4.00 AS Decimal(18, 2)), 5, 19, 0)
INSERT [dbo].[Ratings] ([Id], [RatingValue], [UserId], [RecipeId], [IsActive]) VALUES (10, CAST(5.00 AS Decimal(18, 2)), 3, 21, 0)
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
SET IDENTITY_INSERT [dbo].[RecipeIngredients] ON 

INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (73, 2, 7, 82, 19, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (74, 1, 4, 45, 19, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (75, 1, 7, 47, 19, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (76, 1, 4, 56, 19, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (77, 1, 7, 131, 19, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (78, 2, 5, 170, 19, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (79, 1, 4, 176, 19, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (85, 1, 8, 20, 21, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (86, 1, 4, 93, 21, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (87, 1, 13, 116, 21, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (88, 1, 4, 45, 21, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (89, 2, 5, 170, 21, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (90, 1, 4, 176, 21, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (100, 2, 8, 26, 24, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (101, 1, 7, 111, 24, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (102, 1, 13, 116, 24, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (103, 1, 7, 131, 24, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (104, 1, 7, 127, 25, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (105, 1, 7, 146, 25, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (106, 1, 4, 63, 25, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (107, 1, 4, 45, 25, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (108, 2, 5, 172, 25, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (109, 1, 5, 171, 25, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (110, 1, 5, 124, 25, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (125, 1, 13, 24, 23, 0)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (126, 1, 4, 94, 23, 0)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (127, 1, 7, 131, 23, 0)
INSERT [dbo].[RecipeIngredients] ([Id], [Amount], [MeasurementTypeId], [IngredientId], [RecipeId], [IsActive]) VALUES (128, 1, 5, 124, 23, 0)
SET IDENTITY_INSERT [dbo].[RecipeIngredients] OFF
GO
SET IDENTITY_INSERT [dbo].[Recipes] ON 

INSERT [dbo].[Recipes] ([Id], [Title], [Description], [PreparationTime], [CategoryId], [DifficultyId], [UserId], [Status], [IsActive], [ImageUrl]) VALUES (19, N'Salada Mediterrânica de Quinoa e Feta', N'Coza a quinoa e deixe arrefecer. Misture com tomate cereja, pepino, cebola roxa e queijo feta. Tempere com azeite, limão e orégãos.', N'20 min', 13, 7, 1, N'Approved', 1, N'https://images.unsplash.com/photo-1546069901-ba9599a7e63c')
INSERT [dbo].[Recipes] ([Id], [Title], [Description], [PreparationTime], [CategoryId], [DifficultyId], [UserId], [Status], [IsActive], [ImageUrl]) VALUES (21, N'Salada Verde com Abacate e Nozes', N'Junte folhas verdes, abacate fatiado, pepino e nozes. Tempere com limão e azeite.', N'15 min', 12, 7, 3, N'Approved', 1, N'https://images.unsplash.com/photo-1490645935967-10de6ba17061')
INSERT [dbo].[Recipes] ([Id], [Title], [Description], [PreparationTime], [CategoryId], [DifficultyId], [UserId], [Status], [IsActive], [ImageUrl]) VALUES (23, N'Salada Tropical com Manga e Rúcula', N'Misture manga fresca, rúcula e queijo feta. Finalize com sementes de sésamo e molho cítrico.', N'10', 13, 7, 6, N'Approved', 1, N'https://localhost:7048/uploads/c901f4bf-16b7-42c1-a983-556d6dc8f488_salada-de-rucula-com-manga-refrescante-e-saborosa-2-768x512.webp')
INSERT [dbo].[Recipes] ([Id], [Title], [Description], [PreparationTime], [CategoryId], [DifficultyId], [UserId], [Status], [IsActive], [ImageUrl]) VALUES (24, N'Salada de Espinafre com Morangos', N'Combine espinafres frescos, morangos laminados e nozes tostadas. Regue com vinagre balsâmico.', N'20 min', 14, 7, 2, N'Approved', 1, N'https://images.unsplash.com/photo-1512852939750-1305098529bf')
INSERT [dbo].[Recipes] ([Id], [Title], [Description], [PreparationTime], [CategoryId], [DifficultyId], [UserId], [Status], [IsActive], [ImageUrl]) VALUES (25, N'Salada Asiática com Tofu e Sésamo', N'Grelhe o tofu e misture com legumes frescos e molho de soja com óleo de sésamo.', N'30 min', 14, 10, 3, N'Approved', 1, N'https://images.unsplash.com/photo-1540189549336-e6e99c3679fe')
SET IDENTITY_INSERT [dbo].[Recipes] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [LastName], [Phone], [Location], [BirthDate], [Email], [Password], [IsRegistered], [IsAdmin], [Favorites], [Recipes], [IsActive], [IsBlocked]) VALUES (1, N'Gabriela M.', N'Matos', NULL, NULL, NULL, N'admin@recipesite.com', N'$2a$11$TOkL/LH39aBU/EB.J9kUsuCQko6uoOLhaEQZexF8AMboRDnj.oOIq', 1, 1, N'[0]', N'[0]', 1, 0)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Phone], [Location], [BirthDate], [Email], [Password], [IsRegistered], [IsAdmin], [Favorites], [Recipes], [IsActive], [IsBlocked]) VALUES (2, N'Bruno', NULL, NULL, NULL, NULL, N'user@recipesite.com', N'$2a$11$TOkL/LH39aBU/EB.J9kUsuCQko6uoOLhaEQZexF8AMboRDnj.oOIq', 0, 0, N'[]', N'[]', 0, 0)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Phone], [Location], [BirthDate], [Email], [Password], [IsRegistered], [IsAdmin], [Favorites], [Recipes], [IsActive], [IsBlocked]) VALUES (3, N'Ana', NULL, NULL, NULL, NULL, N'ana@recipesite.com', N'$2a$11$TOkL/LH39aBU/EB.J9kUsuCQko6uoOLhaEQZexF8AMboRDnj.oOIq', 0, 0, N'[]', N'[]', 0, 0)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Phone], [Location], [BirthDate], [Email], [Password], [IsRegistered], [IsAdmin], [Favorites], [Recipes], [IsActive], [IsBlocked]) VALUES (5, N'Carlos', NULL, NULL, NULL, NULL, N'carlos@recipesite.com', N'$2a$11$TOkL/LH39aBU/EB.J9kUsuCQko6uoOLhaEQZexF8AMboRDnj.oOIq', 0, 0, N'[]', N'[]', 0, 0)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Phone], [Location], [BirthDate], [Email], [Password], [IsRegistered], [IsAdmin], [Favorites], [Recipes], [IsActive], [IsBlocked]) VALUES (6, N'Marta', NULL, NULL, NULL, NULL, N'marta@recipesite.com', N'$2a$11$TOkL/LH39aBU/EB.J9kUsuCQko6uoOLhaEQZexF8AMboRDnj.oOIq', 0, 0, N'[]', N'[]', 0, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_RecipeCategories_CategoryId]    Script Date: 13/10/2026 20:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_RecipeCategories_CategoryId] ON [dbo].[RecipeCategories]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipeIngredients_IngredientId]    Script Date: 13/10/2026 20:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_RecipeIngredients_IngredientId] ON [dbo].[RecipeIngredients]
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipeIngredients_MeasurementTypeId]    Script Date: 13/10/2026 20:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_RecipeIngredients_MeasurementTypeId] ON [dbo].[RecipeIngredients]
(
	[MeasurementTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipeIngredients_RecipeId]    Script Date: 13/10/2026 20:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_RecipeIngredients_RecipeId] ON [dbo].[RecipeIngredients]
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Recipes_CategoryId]    Script Date: 13/10/2026 20:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_Recipes_CategoryId] ON [dbo].[Recipes]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Recipes_DifficultyId]    Script Date: 13/10/2026 20:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_Recipes_DifficultyId] ON [dbo].[Recipes]
(
	[DifficultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Recipes_UserId]    Script Date: 13/10/2026 20:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_Recipes_UserId] ON [dbo].[Recipes]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Recipes] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Recipes]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Recipes] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Recipes]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Recipes] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Recipes]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RI_Ingredients] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredients] ([Id])
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RI_Ingredients]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RI_Measurements] FOREIGN KEY([MeasurementTypeId])
REFERENCES [dbo].[MeasurementTypes] ([Id])
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RI_Measurements]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RI_Recipes] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RI_Recipes]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Categories]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Difficulties] FOREIGN KEY([DifficultyId])
REFERENCES [dbo].[Difficulties] ([Id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Difficulties]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Users]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Users_UserId]
GO
