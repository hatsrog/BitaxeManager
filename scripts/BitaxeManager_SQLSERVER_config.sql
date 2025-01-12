USE [BitaxeManager]
GO
/****** Object:  Table [dbo].[DeviceStatusLogs]    Script Date: 12/01/2025 22:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceStatusLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Timestamp] [datetime2](7) NOT NULL,
	[HashRate] [float] NOT NULL,
	[Temperature] [real] NOT NULL,
	[SharesAccepted] [int] NOT NULL,
	[FanSpeed] [int] NOT NULL,
	[FanRPM] [int] NOT NULL,
 CONSTRAINT [PK_DeviceStatusLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
