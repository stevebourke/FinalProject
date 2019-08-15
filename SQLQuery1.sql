CREATE DATABASE [SurfDB];
GO

USE [SurfDB];
GO

CREATE TABLE [SurfReport] (
[ReportID] int NOT NULL IDENTITY,
[TimeStamp] int NOT NULL,
[Period] int NOT NULL,
[Speed] int NOT NULL,
CONSTRAINT [PK_SurfReport] PRIMARY KEY ([ReportID])
);
GO