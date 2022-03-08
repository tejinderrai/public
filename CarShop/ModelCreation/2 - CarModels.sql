SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarModels](
    [CarModelId] [bigint] IDENTITY(1,1) NOT NULL,
    [Model] [varchar](35) NOT NULL,
    [ManufacturerId] [bigint] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarModels] ADD PRIMARY KEY CLUSTERED 
(
    [CarModelId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarModels]  WITH CHECK ADD FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[CarManuFacturers] ([ManufacturerID])
GO