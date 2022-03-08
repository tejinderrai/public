SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
    [VehicleId] [bigint] IDENTITY(1,1) NOT NULL,
    [ModelID] [bigint] NOT NULL,
    [MANUFACTURERID] [bigint] NOT NULL,
    [PurchaseDate] [datetime] NOT NULL,
    [COLOURID] [int] NULL,
    [CREATEDON] [datetime] NOT NULL,
    [VIN] [varchar](25) NOT NULL,
    [REGISTRATION] [varchar](10) NOT NULL,
    [FUELTYPEID] [int] NOT NULL,
    [REGISTRATIONDATE] [datetime] NOT NULL,
    [PreviousOwners] [int] NULL,
    [StatusId] [int] NULL,
    [ENGINESIZEID] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Vehicles] ADD PRIMARY KEY CLUSTERED 
(
    [VehicleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Vehicles] ADD  CONSTRAINT [UNIQUE_VIN] UNIQUE NONCLUSTERED 
(
    [VIN] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT (getdate()) FOR [CREATEDON]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT ((1)) FOR [PreviousOwners]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT ((1)) FOR [StatusId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD FOREIGN KEY([COLOURID])
REFERENCES [dbo].[CarColours] ([CarColourId])
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD FOREIGN KEY([ENGINESIZEID])
REFERENCES [dbo].[EngineSize] ([EngineSizeId])
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD FOREIGN KEY([FUELTYPEID])
REFERENCES [dbo].[CarFuelTypes] ([FuelTypeId])
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD FOREIGN KEY([MANUFACTURERID])
REFERENCES [dbo].[CarManuFacturers] ([ManufacturerID])
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD FOREIGN KEY([ModelID])
REFERENCES [dbo].[CarModels] ([CarModelId])
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD FOREIGN KEY([StatusId])
REFERENCES [dbo].[VehicleStatus] ([StatusId])
GO
