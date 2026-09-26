/* SQL Server / LocalDB database used by appsettings.json */
IF DB_ID(N'HoVaTenMaSV_exam') IS NULL
	CREATE DATABASE [HoVaTenMaSV_exam];
GO
USE [HoVaTenMaSV_exam];
GO

IF OBJECT_ID(N'dbo.HvtStudent', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.HvtStudent
	(
		MaSV          nvarchar(20)  NOT NULL CONSTRAINT PK_HvtStudent PRIMARY KEY,
		HoTen         nvarchar(100) NOT NULL,
		GioiTinh      nvarchar(20)  NULL,
		NgaySinh      datetime2     NULL,
		Email         nvarchar(254) NULL,
		SoDienThoai   nvarchar(20)  NULL,
		DangHoc       bit           NOT NULL CONSTRAINT DF_HvtStudent_DangHoc DEFAULT (1)
	);
END;
