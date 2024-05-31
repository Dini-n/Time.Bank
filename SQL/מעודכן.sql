/****** Object:  Table [dbo].[Categories]    Script Date: 09/03/2023 14:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[name] [nchar](30) NOT NULL,
	[fatherCategoryId] [smallint] NULL,
	[forGroup] [bit] NULL,
	[minGroup] [smallint] NULL,
	[maxGroup] [smallint] NULL,
	[approved] [bit] NULL,
	[amountPeopleOffered] [smallint] NULL,
 CONSTRAINT [PK_Categories_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberCategory]    Script Date: 09/03/2023 14:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberCategory](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[memberId] [smallint] NOT NULL,
	[categoryId] [smallint] NOT NULL,
	[place] [nchar](30) NULL,
	[possibilityComeCustomerHome] [bit] NULL,
	[experienceYears] [smallint] NULL,
	[restrictionsDescription] [nchar](30) NULL,
 CONSTRAINT [PK_MemberCategory_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 09/03/2023 14:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[name] [nchar](40) NOT NULL,
	[password] [nchar](8) NOT NULL,
	[mail] [nchar](40) NULL,
	[phone] [nchar](10) NOT NULL,
	[address] [nchar](50) NULL,
	[yearBorn] [int] NOT NULL,
	[gender] [bit] NOT NULL,
	[remainingHours] [time](7) NOT NULL,
	[active] [bit] NOT NULL,
	[toCheck] [bit] NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 09/03/2023 14:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[giverId] [smallint] NOT NULL,
	[categoryId] [smallint] NOT NULL,
	[date] [date] NOT NULL,
	[hour] [time](7) NOT NULL,
	[note] [nchar](100) NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportsDetails]    Script Date: 09/03/2023 14:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportsDetails](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[reportId] [smallint] NOT NULL,
	[memberId] [smallint] NOT NULL,
	[receiverApproved] [bit] NULL,
 CONSTRAINT [PK_ReportsDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_report_and_waiting_report_details] UNIQUE NONCLUSTERED 
(
	[memberId] ASC,
	[reportId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WaitingList]    Script Date: 09/03/2023 14:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WaitingList](
	[id] [smallint] NOT NULL,
	[memberId] [smallint] NOT NULL,
	[categoryId] [smallint] NOT NULL,
	[expiryDate] [date] NULL,
 CONSTRAINT [PK_WaitingList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([fatherCategoryId])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [dbo].[MemberCategory]  WITH CHECK ADD  CONSTRAINT [FK_MemberCategory_Categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[MemberCategory] CHECK CONSTRAINT [FK_MemberCategory_Categories]
GO
ALTER TABLE [dbo].[MemberCategory]  WITH CHECK ADD  CONSTRAINT [FK_MemberCategory_Members] FOREIGN KEY([memberId])
REFERENCES [dbo].[Members] ([id])
GO
ALTER TABLE [dbo].[MemberCategory] CHECK CONSTRAINT [FK_MemberCategory_Members]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_MemberCategory] FOREIGN KEY([categoryId])
REFERENCES [dbo].[MemberCategory] ([id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_MemberCategory]
GO
ALTER TABLE [dbo].[ReportsDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReportsDetails_Members] FOREIGN KEY([memberId])
REFERENCES [dbo].[Members] ([id])
GO
ALTER TABLE [dbo].[ReportsDetails] CHECK CONSTRAINT [FK_ReportsDetails_Members]
GO
ALTER TABLE [dbo].[ReportsDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReportsDetails_Reports] FOREIGN KEY([reportId])
REFERENCES [dbo].[Reports] ([id])
GO
ALTER TABLE [dbo].[ReportsDetails] CHECK CONSTRAINT [FK_ReportsDetails_Reports]
GO
ALTER TABLE [dbo].[WaitingList]  WITH CHECK ADD  CONSTRAINT [FK_WaitingList_Categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[WaitingList] CHECK CONSTRAINT [FK_WaitingList_Categories]
GO
ALTER TABLE [dbo].[WaitingList]  WITH CHECK ADD  CONSTRAINT [FK_WaitingList_Members] FOREIGN KEY([memberId])
REFERENCES [dbo].[Members] ([id])
GO
ALTER TABLE [dbo].[WaitingList] CHECK CONSTRAINT [FK_WaitingList_Members]
GO
