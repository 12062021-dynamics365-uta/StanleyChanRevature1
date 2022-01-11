/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [FlavorId]
      ,[FlavorName]
  FROM [SweetnSalty].[dbo].[Flavor]

  SELECT TOP 1 * FROM Flavor ORDER BY FlavorId DESC;
  SELECT * FROM Flavor WHERE FlavorId = (SELECT MAX(FlavorId) FROM Flavor);
