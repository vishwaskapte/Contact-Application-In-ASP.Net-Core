USE [master]
GO
/****** Object:  Database [EventDB]    Script Date: 10/16/2017 09:25:50 ******/
CREATE DATABASE [ContactDB] ON  PRIMARY 
( NAME = N'ContactDB', FILENAME = N'D:\Projects\.Net Core\ContactInformationCore\ContactInformationCore.WebAPI\DBScript\ContactDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ContactDB_Log', FILENAME = N'D:\Projects\.Net Core\ContactInformationCore\ContactInformationCore.WebAPI\DBScript\ContactDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EventDB] SET COMPATIBILITY_LEVEL = 100
GO