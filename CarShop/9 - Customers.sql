SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
    [CustomerID] [bigint] IDENTITY(1,1) NOT NULL,
    [FIRSTNAME] [nvarchar](50) NOT NULL,
    [LASTNAME] [nvarchar](50) NOT NULL,
    [HOUSENUMBER] [int] NOT NULL,
    [STREETNAME] [varchar](50) NOT NULL,
    [AREA] [varchar](50) NOT NULL,
    [CITY] [varchar](50) NOT NULL,
    [POSTCODE] [varchar](10) NOT NULL,
    [TELEPHONE] [varchar](20) NOT NULL,
    [CREATEDON] [datetime] NOT NULL,
    [MIDDLENAME] [varchar](50) NULL,
    [SalutationId] [int] NOT NULL,
    [EmailAddress] [varchar](100) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [PK_CustomerID] PRIMARY KEY CLUSTERED 
(
    [CustomerID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (getdate()) FOR [CREATEDON]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD FOREIGN KEY([SalutationId])
REFERENCES [dbo].[Salutation] ([SalutationId])
GO