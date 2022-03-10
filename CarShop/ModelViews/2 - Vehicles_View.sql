SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vehicles_View]
AS Select v.VehicleId, m.Manufacturer, n.model, c.colour, v.REGISTRATIONDATE, v.REGISTRATION, f.Fuel, s.STATUS, v.PreviousOwners, v.purchasedate
FROM dbo.vehicles v, dbo.CarManufacturers m, dbo.CarModels n, dbo.carcolours c, dbo.carfueltypes f, dbo.VehicleStatus s
WHERE v.manufacturerId = m.ManufacturerID
AND v.modelId = n.carmodelId
AND v.COLOURID = c.CarColourId
AND v.FuelTypeId = f.FuelTypeId
AND v.StatusId = s.StatusId
GO
