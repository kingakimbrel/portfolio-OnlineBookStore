CREATE TABLE [dbo].[Authors] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [First] NVARCHAR (100) NOT NULL,
    [Last]  NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Categories] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Value] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Books] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (100)  NOT NULL,
    [Description] NVARCHAR (500)  NULL,
    [CategoryId]  INT             NULL,
    [AuthorId]    INT             NULL,
    [Price]       DECIMAL (16, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
    FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id])
);

CREATE TABLE [dbo].[ShippingDetails] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [Line1]     NVARCHAR (MAX) NOT NULL,
    [Line2]     NVARCHAR (MAX) NULL,
    [Line3]     NVARCHAR (MAX) NULL,
    [City]      NVARCHAR (MAX) NOT NULL,
    [Zip]       NVARCHAR (MAX) NOT NULL,
    [Country]   NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Orders] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [OrderDate]        DATETIME2 (0) NULL,
    [ShippingDetailId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ShippingDetailId]) REFERENCES [dbo].[ShippingDetails] ([Id])
);

CREATE TABLE [dbo].[OrderItems] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [OrderId] INT NULL,
    [BookId]  INT NULL,
    [Amount]  INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]),
    FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id])
);

SET IDENTITY_INSERT [dbo].[Authors] ON
INSERT INTO [dbo].[Authors] ([Id], [First], [Last]) VALUES (1, N'Nicholas', N'Sparks')
INSERT INTO [dbo].[Authors] ([Id], [First], [Last]) VALUES (2, N'Hape', N'Kerkeling')
INSERT INTO [dbo].[Authors] ([Id], [First], [Last]) VALUES (3, N'Adam', N'Freeman')
INSERT INTO [dbo].[Authors] ([Id], [First], [Last]) VALUES (4, N'Ryszard', N'Kapuscinski')
INSERT INTO [dbo].[Authors] ([Id], [First], [Last]) VALUES (5, N'Simon', N'Beckett')
SET IDENTITY_INSERT [dbo].[Authors] OFF

SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([Id], [Value]) VALUES (1, N'Romance')
INSERT INTO [dbo].[Categories] ([Id], [Value]) VALUES (2, N'Adventure')
INSERT INTO [dbo].[Categories] ([Id], [Value]) VALUES (3, N'Criminal')
INSERT INTO [dbo].[Categories] ([Id], [Value]) VALUES (4, N'Science')
INSERT INTO [dbo].[Categories] ([Id], [Value]) VALUES (5, N'Documentary')
SET IDENTITY_INSERT [dbo].[Categories] OFF

SET IDENTITY_INSERT [dbo].[Books] ON
INSERT INTO [dbo].[Books] ([Id], [Title], [Description], [CategoryId], [AuthorId], [Price]) VALUES (1, N'Notebook', N'Every so often a love story so captures our hearts that it becomes more than a story-it becomes an experience to remember forever. The Notebook is such a book. It is a celebration of how passion can be ageless and timeless, a tale that moves us to laughter and tears and makes us believe in true love all over again... ', 1, 1, CAST(25.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Books] ([Id], [Title], [Description], [CategoryId], [AuthorId], [Price]) VALUES (2, N'I''m Off Then: Losing and Finding Myself on the Camino de Santiago', N'It has sold over 3 million copies and been translated into eleven different languages. Pilgrims have increased along the Camino by 20 percent since the book was published. Hape Kerkeling’s spiritual epiphany has struck a nerve. ', 2, 2, CAST(22.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Books] ([Id], [Title], [Description], [CategoryId], [AuthorId], [Price]) VALUES (3, N'Pro ASP.NET MVC 4', N'The ASP.NET MVC 4 Framework is the latest evolution of Microsoft’s ASP.NET web platform. It provides a high-productivity programming model that promotes cleaner code architecture, test-driven development, and powerful extensibility, combined with all the benefits of ASP.NET.', 4, 3, CAST(55.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Books] ([Id], [Title], [Description], [CategoryId], [AuthorId], [Price]) VALUES (4, N'The Shadow of the Sun', N'In 1957, Ryszard Kapuscinski arrived in Africa to witness the beginning of the end of colonial rule as the first African correspondent of Poland''s state newspaper. From the early days of independence in Ghana to the ongoing ethnic genocide in Rwanda, Kapuscinski has crisscrossed vast distances pursuing the swift, and often violent, events that followed liberation. Kapuscinski hitchhikes with caravans, wanders the Sahara with nomads, and lives in the poverty-stricken slums of Nigeria.', 5, 4, CAST(39.70 AS Decimal(16, 2)))
INSERT INTO [dbo].[Books] ([Id], [Title], [Description], [CategoryId], [AuthorId], [Price]) VALUES (5, N'The Chemistry of Death', N'The Chemistry of Death is a novel by the British crime fiction writer Simon Beckett, first published in 2006. The novel introduced the character of Dr David Hunter, who has gone on to feature in other novels by the writer. The Chemistry of Death was nominated for the Duncan Lawrie Dagger by the Crime Writer''s Association in 2006.', 3, 5, CAST(21.54 AS Decimal(16, 2)))
INSERT INTO [dbo].[Books] ([Id], [Title], [Description], [CategoryId], [AuthorId], [Price]) VALUES (6, N'Written in Bone', N'Set in the Outer Hebrides, this crime novel features forensic anthropologist Dr. David Hunter. In this volume, he is called in to examine a badly burned body found in a deserted house on a small island while contending with both personal and professional obstacles. It received positive reviews as being better than Beckett''s first novel, with satisfying plot twists and well-implemented scientific details.', 3, 5, CAST(21.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Books] ([Id], [Title], [Description], [CategoryId], [AuthorId], [Price]) VALUES (7, N'The Longest Ride', N'After being trapped in an isolated car crash, the life of elderly widower Ira Levinson becomes entwined with that of young college student, Sophia Danko and the cowboy whom she loves, named Luke. The novel is told through the perspectives of these three characters as they go through their lives, both separately and together.', 1, 1, CAST(45.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Books] ([Id], [Title], [Description], [CategoryId], [AuthorId], [Price]) VALUES (8, N'Example Book', N'Example description.', 5, 4, CAST(9.99 AS Decimal(16, 2)))
SET IDENTITY_INSERT [dbo].[Books] OFF
