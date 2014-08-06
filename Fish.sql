USE [CaughtItHere]
GO

/****** Object:  Table [dbo].[Fish]    Script Date: 8/6/2014 11:04:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Fish](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FishTypeId] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[Weight] [int] NULL,
	[Image] [image] NULL,
	[LureType] [varchar](50) NULL,
	[ImageLure] [image] NULL,
	[Comment] [text] NULL,
	[TimeDate] [datetime] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
 CONSTRAINT [PK_Fish] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Fish]  WITH CHECK ADD  CONSTRAINT [FK_Fish_FishType] FOREIGN KEY([FishTypeId])
REFERENCES [dbo].[FishType] ([Id])
GO

ALTER TABLE [dbo].[Fish] CHECK CONSTRAINT [FK_Fish_FishType]
GO

