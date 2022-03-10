SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CarModels_View]
AS  
SELECT CarModelId, a.Model, c.Manufacturer
FROM dbo.CarModels a, dbo.CarManuFacturers c
WHERE a.ManufacturerId = c.ManufacturerID

GO
