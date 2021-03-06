USE [master]
GO
/****** Object:  Database [AMS]    Script Date: 12/3/2019 7:56:07 PM ******/
CREATE DATABASE [AMS]

GO

USE [AMS]
GO
/****** Object:  Table [dbo].[AssetCategory]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Comment] [varchar](100) NOT NULL,
 CONSTRAINT [PK__AssetCat__3214EC270A85ACC9] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetPurchaseOrderMapping]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetPurchaseOrderMapping](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssetID] [int] NOT NULL,
	[PurchaseOrderID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetRequest]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetRequest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RequestedBy] [int] NOT NULL,
	[RequestedTo] [int] NOT NULL,
	[AssetRequestStatusID] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[RequestedAsset] [nvarchar](1000) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,

 CONSTRAINT [PK_AssetRequest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetRequestApprovalHistory]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetRequestApprovalHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssetRequestID] [int] NOT NULL,
	[RequestID] [int] NOT NULL,
	[ApproverID] [int] NOT NULL,
	[Comments] [nvarchar](1000) NOT NULL,
	[ApprovalStatus] [int] NOT NULL,
	[RequestedAsset] [nvarchar](1000) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,

 CONSTRAINT [PK_AssetRequestApprovalHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetRequestStatus]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetRequestStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AssetRequestStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assets]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssetTypeID] [int] NOT NULL,
	[AssetName] [varchar](100) NOT NULL,
	[SerialNumber] [varchar](100) NOT NULL,
	[AssetStatusID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK__Assets__3214EC27FDDAE35C] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetStatus]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK__AssetSta__3214EC274F9DF58A] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetTracker]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetTracker](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssetID] [int] NOT NULL,
	[EmpID] [int] NULL,
	[AssetStatusID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Remarks] [nvarchar](500) NULL,
 CONSTRAINT [PK__AssetTra__3214EC27BC1F6045] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetTypes]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[AssetCategoryID] [int] NOT NULL,
 CONSTRAINT [PK__AssetTyp__3214EC277868B57A] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponentAssetMapping]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentAssetMapping](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ComponentID] [int] NOT NULL,
	[AssignedAssetID] [int] NULL,
	[ActualAssetID] [int] NULL,
	[AssignedDate] [datetime] NULL,
	[AssignedBy] [int] NULL,
	[ComponentStatusId] [int] NOT NULL,
	[ComponentTypeID] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,

 CONSTRAINT [PK_ComponentAssetMapping] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Components]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Components](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ComponentTypeID] [int] NOT NULL,
	[ComponentName] [varchar](100) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,

 CONSTRAINT [PK__Components] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponentStatus]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK__ComponentSta__3214EC274F9DF58A] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponentTracker]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentTracker](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ComponentID] [int] NOT NULL,
	[AssetID] [int] NOT NULL,
	[ComponentStatusID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Remarks] [nvarchar](500) NULL,
 CONSTRAINT [PK__ComponentTra__3214EC27BC1F6045] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponentType]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[AssetTypeID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Mandatory] [bit] NOT NULL,
	[ComponentCategory] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,

 CONSTRAINT [PK__ComponentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[EmployeeRoleID] [int] NOT NULL,
	[EmployeeName] [nvarchar](500) NOT NULL,
	[SeatID] [int] NULL,
	[MailID] [nvarchar](100) NOT NULL,
	[ISActive] [bit] NOT NULL,
	[ManagerID] [int] NULL,
	[CorpId] [varchar](50) NULL,
	[RelievingDate] [date] NULL,
	[JoiningDate] [date] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,

 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAssetMapping]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAssetMapping](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[AssetID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeAssetMapping] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeRole]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EmployeeRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HardwareAssets]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HardwareAssets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssetID] [int] NOT NULL,
	[Model] [nvarchar](500) NOT NULL,
	[ServiceTag] [nvarchar](500) NOT NULL,
	[Manufacturer] [nvarchar](500) NOT NULL,
	[WarrantyStartDate] [datetime] NOT NULL,
	[WarrantyEndDate] [datetime] NOT NULL,
	[Comment] [nvarchar](500) NULL,
 CONSTRAINT [PK__Hardware__3214EC27F0501CA2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Location] [nvarchar](500) NOT NULL,
	[Building] [nvarchar](500) NOT NULL,
	[Floor] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Thread] [varchar](255) NULL,
	[Level] [varchar](50) NULL,
	[Logger] [varchar](255) NULL,
	[Message] [varchar](4000) NULL,
	[Exception] [varchar](2000) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuotationID] [int] NOT NULL,
	[InvoiceNumber] [nvarchar](200) NULL,
	[InvoiceFilePath] [nvarchar](200) NULL,
	[PurchaseStatusID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseStatus]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quotation]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [int] NOT NULL,
	[AssetRequestID] [int] NOT NULL,
	[QuotationFilePath] [nvarchar](1) NULL,
	[QuotationStatusID] [int] NOT NULL,
	[QuotationReceivedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuotationStatus]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotationStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LocationID] [int] NOT NULL,
	[SeatName] [nvarchar](500) NOT NULL,
	[IsFilled] [bit] NULL,
 CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoftwareAssets]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoftwareAssets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssetID] [int] NOT NULL,
	[ProductName] [nvarchar](500) NOT NULL,
	[LicenceNumber] [nvarchar](500) NOT NULL,
	[LicencePurchaseDate] [datetime] NOT NULL,
	[LicenceExpiryDate] [datetime] NOT NULL,
	[Comment] [nvarchar](500) NULL,
 CONSTRAINT [PK__Software__3214EC2725D3A9CA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 12/3/2019 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](2000) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[ContactNumber] [nvarchar](50) NOT NULL,
	[ContactPerson] [nvarchar](200) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ComponentType] ADD  CONSTRAINT [mandatory_default]  DEFAULT ((0)) FOR [Mandatory]
GO
ALTER TABLE [dbo].[EmployeeAssetMapping] ADD  CONSTRAINT [DF_EmployeeAssetMapping]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Quotation] ADD  DEFAULT (getdate()) FOR [QuotationReceivedDate]
GO
ALTER TABLE [dbo].[Vendor] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[AssetPurchaseOrderMapping]  WITH CHECK ADD  CONSTRAINT [FK_AssetPurchaseOrderMapping_Assets] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Assets] ([ID])
GO
ALTER TABLE [dbo].[AssetPurchaseOrderMapping] CHECK CONSTRAINT [FK_AssetPurchaseOrderMapping_Assets]
GO
ALTER TABLE [dbo].[AssetPurchaseOrderMapping]  WITH CHECK ADD  CONSTRAINT [FK_AssetPurchaseOrderMapping_PurchaseOrder] FOREIGN KEY([PurchaseOrderID])
REFERENCES [dbo].[PurchaseOrder] ([ID])
GO
ALTER TABLE [dbo].[AssetPurchaseOrderMapping] CHECK CONSTRAINT [FK_AssetPurchaseOrderMapping_PurchaseOrder]
GO
ALTER TABLE [dbo].[AssetRequest]  WITH CHECK ADD FOREIGN KEY([AssetRequestStatusID])
REFERENCES [dbo].[AssetRequestStatus] ([ID])
GO
ALTER TABLE [dbo].[AssetRequestApprovalHistory]  WITH CHECK ADD FOREIGN KEY([ApprovalStatus])
REFERENCES [dbo].[AssetRequestStatus] ([ID])
GO
ALTER TABLE [dbo].[AssetRequestApprovalHistory]  WITH CHECK ADD FOREIGN KEY([AssetRequestID])
REFERENCES [dbo].[AssetRequest] ([ID])
GO
ALTER TABLE [dbo].[Assets]  WITH NOCHECK ADD  CONSTRAINT [FK_Assets_AssetStatus] FOREIGN KEY([AssetStatusID])
REFERENCES [dbo].[AssetStatus] ([ID])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_AssetStatus]
GO
ALTER TABLE [dbo].[Assets]  WITH NOCHECK ADD  CONSTRAINT [FK_Assets_AssetTypes] FOREIGN KEY([AssetTypeID])
REFERENCES [dbo].[AssetTypes] ([ID])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_AssetTypes]
GO
ALTER TABLE [dbo].[Assets]  WITH NOCHECK ADD  CONSTRAINT [FK_Assets_Employee] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_Employee]
GO
ALTER TABLE [dbo].[AssetTracker]  WITH CHECK ADD  CONSTRAINT [FK_AssetTracker_Assets] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Assets] ([ID])
GO
ALTER TABLE [dbo].[AssetTracker] CHECK CONSTRAINT [FK_AssetTracker_Assets]
GO
ALTER TABLE [dbo].[AssetTracker]  WITH CHECK ADD  CONSTRAINT [FK_AssetTracker_AssetStatus] FOREIGN KEY([AssetStatusID])
REFERENCES [dbo].[AssetStatus] ([ID])
GO
ALTER TABLE [dbo].[AssetTracker] CHECK CONSTRAINT [FK_AssetTracker_AssetStatus]
GO
ALTER TABLE [dbo].[AssetTracker]  WITH CHECK ADD  CONSTRAINT [FK_AssetTracker_Employee] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[AssetTracker] CHECK CONSTRAINT [FK_AssetTracker_Employee]
GO
ALTER TABLE [dbo].[AssetTypes]  WITH NOCHECK ADD  CONSTRAINT [FK_AssetTypes_AssetCategory] FOREIGN KEY([AssetCategoryID])
REFERENCES [dbo].[AssetCategory] ([ID])
GO
ALTER TABLE [dbo].[AssetTypes] CHECK CONSTRAINT [FK_AssetTypes_AssetCategory]
GO
ALTER TABLE [dbo].[ComponentAssetMapping]  WITH CHECK ADD  CONSTRAINT [FK__Component__Actua__44CA3770] FOREIGN KEY([ActualAssetID])
REFERENCES [dbo].[Assets] ([ID])
GO
ALTER TABLE [dbo].[ComponentAssetMapping] CHECK CONSTRAINT [FK__Component__Actua__44CA3770]
GO
ALTER TABLE [dbo].[ComponentAssetMapping]  WITH CHECK ADD  CONSTRAINT [FK__Component__Assig__43D61337] FOREIGN KEY([AssignedAssetID])
REFERENCES [dbo].[Assets] ([ID])
GO
ALTER TABLE [dbo].[ComponentAssetMapping] CHECK CONSTRAINT [FK__Component__Assig__43D61337]
GO
ALTER TABLE [dbo].[ComponentAssetMapping]  WITH CHECK ADD  CONSTRAINT [FK_ComponentAssetMapping_Components] FOREIGN KEY([ComponentID])
REFERENCES [dbo].[Components] ([ID])
GO
ALTER TABLE [dbo].[ComponentAssetMapping] CHECK CONSTRAINT [FK_ComponentAssetMapping_Components]
GO
ALTER TABLE [dbo].[ComponentAssetMapping]  WITH CHECK ADD  CONSTRAINT [FK_ComponentAssetMapping_ComponentStatus] FOREIGN KEY([ComponentStatusId])
REFERENCES [dbo].[ComponentStatus] ([ID])
GO
ALTER TABLE [dbo].[ComponentAssetMapping] CHECK CONSTRAINT [FK_ComponentAssetMapping_ComponentStatus]
GO
ALTER TABLE [dbo].[ComponentAssetMapping]  WITH CHECK ADD  CONSTRAINT [FK_ComponentAssetMapping_ComponentTypeID] FOREIGN KEY([ComponentTypeID])
REFERENCES [dbo].[ComponentType] ([ID])
GO
ALTER TABLE [dbo].[ComponentAssetMapping] CHECK CONSTRAINT [FK_ComponentAssetMapping_ComponentTypeID]
GO
ALTER TABLE [dbo].[Components]  WITH NOCHECK ADD  CONSTRAINT [FK_Components_ComponentType] FOREIGN KEY([ComponentTypeID])
REFERENCES [dbo].[ComponentType] ([ID])
GO
ALTER TABLE [dbo].[Components] CHECK CONSTRAINT [FK_Components_ComponentType]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([EmployeeRoleID])
REFERENCES [dbo].[EmployeeRole] ([ID])
GO
ALTER TABLE [dbo].[EmployeeAssetMapping]  WITH CHECK ADD  CONSTRAINT [FK__EmployeeA__Asset__1EA48E88] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Assets] ([ID])
GO
ALTER TABLE [dbo].[EmployeeAssetMapping] CHECK CONSTRAINT [FK__EmployeeA__Asset__1EA48E88]
GO
ALTER TABLE [dbo].[EmployeeAssetMapping]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAssetMapping_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[EmployeeAssetMapping] CHECK CONSTRAINT [FK_EmployeeAssetMapping_Employee]
GO
ALTER TABLE [dbo].[HardwareAssets]  WITH NOCHECK ADD  CONSTRAINT [FK_HardwareAssets_Assets] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Assets] ([ID])
GO
ALTER TABLE [dbo].[HardwareAssets] CHECK CONSTRAINT [FK_HardwareAssets_Assets]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_PurchaseStatus] FOREIGN KEY([PurchaseStatusID])
REFERENCES [dbo].[PurchaseStatus] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_PurchaseStatus]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Quotation] FOREIGN KEY([QuotationID])
REFERENCES [dbo].[Quotation] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Quotation]
GO
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_AssetRequest] FOREIGN KEY([AssetRequestID])
REFERENCES [dbo].[AssetRequest] ([ID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_AssetRequest]
GO
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_QuotationStatus] FOREIGN KEY([QuotationStatusID])
REFERENCES [dbo].[QuotationStatus] ([ID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_QuotationStatus]
GO
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([ID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_Vendor]
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([ID])
GO
ALTER TABLE [dbo].[SoftwareAssets]  WITH CHECK ADD  CONSTRAINT [FK_SoftwareAssets_Assets] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Assets] ([ID])
GO
ALTER TABLE [dbo].[SoftwareAssets] CHECK CONSTRAINT [FK_SoftwareAssets_Assets]
GO
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_Employee] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_Employee]

SET IDENTITY_INSERT [dbo].[AssetRequestStatus] ON 
GO
INSERT [dbo].[AssetRequestStatus] ([ID], [Description]) VALUES (1, N'New')
GO
INSERT [dbo].[AssetRequestStatus] ([ID], [Description]) VALUES (2, N'Approval Pending')
GO
INSERT [dbo].[AssetRequestStatus] ([ID], [Description]) VALUES (3, N'Approved')
GO
INSERT [dbo].[AssetRequestStatus] ([ID], [Description]) VALUES (4, N'Rejected')
GO
INSERT [dbo].[AssetRequestStatus] ([ID], [Description]) VALUES (5, N'Waiting for new Assets')
GO
INSERT [dbo].[AssetRequestStatus] ([ID], [Description]) VALUES (6, N'Assets Assigned')
GO
INSERT [dbo].[AssetRequestStatus] ([ID], [Description]) VALUES (7, N'Request Completed')
GO
SET IDENTITY_INSERT [dbo].[AssetRequestStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[QuotationStatus] ON 
GO
INSERT [dbo].[QuotationStatus] ([ID], [Description]) VALUES (1, N'In Progress')
GO
INSERT [dbo].[QuotationStatus] ([ID], [Description]) VALUES (2, N'Approval Pending')
GO
INSERT [dbo].[QuotationStatus] ([ID], [Description]) VALUES (3, N'Approved')
GO
INSERT [dbo].[QuotationStatus] ([ID], [Description]) VALUES (4, N'Rejected')
GO
INSERT [dbo].[QuotationStatus] ([ID], [Description]) VALUES (5, N'Cancelled')
GO
INSERT [dbo].[QuotationStatus] ([ID], [Description]) VALUES (6, N'Completed')
GO
INSERT [dbo].[QuotationStatus] ([ID], [Description]) VALUES (7, N'Closed')
GO
SET IDENTITY_INSERT [dbo].[QuotationStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeRole] ON 
GO
INSERT [dbo].[EmployeeRole] ([ID], [Designation]) VALUES (1, N'Admin')
GO
INSERT [dbo].[EmployeeRole] ([ID], [Designation]) VALUES (2, N'Manager')
GO
INSERT [dbo].[EmployeeRole] ([ID], [Designation]) VALUES (3, N'HR')
GO
INSERT [dbo].[EmployeeRole] ([ID], [Designation]) VALUES (4, N'Employee')
GO
SET IDENTITY_INSERT [dbo].[EmployeeRole] OFF
GO
SET IDENTITY_INSERT [dbo].[AssetStatus] ON 
GO
INSERT [dbo].[AssetStatus] ([ID], [Description]) VALUES (1, N'New')
GO
INSERT [dbo].[AssetStatus] ([ID], [Description]) VALUES (2, N'Assign')
GO
INSERT [dbo].[AssetStatus] ([ID], [Description]) VALUES (3, N'Unassign')
GO
INSERT [dbo].[AssetStatus] ([ID], [Description]) VALUES (4, N'Reassign')
GO
INSERT [dbo].[AssetStatus] ([ID], [Description]) VALUES (5, N'Expire')
GO
INSERT [dbo].[AssetStatus] ([ID], [Description]) VALUES (6, N'Renew')
GO
INSERT [dbo].[AssetStatus] ([ID], [Description]) VALUES (7, N'Damage')
GO
INSERT [dbo].[AssetStatus] ([ID], [Description]) VALUES (8, N'Scraped')
GO
INSERT [dbo].[AssetStatus] ([ID], [Description]) VALUES (9, N'Retire')
GO
SET IDENTITY_INSERT [dbo].[AssetStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[ComponentStatus] ON 
GO
INSERT [dbo].[ComponentStatus] ([ID], [Description]) VALUES (1, N'New')
GO
INSERT [dbo].[ComponentStatus] ([ID], [Description]) VALUES (2, N'Assign')
GO
INSERT [dbo].[ComponentStatus] ([ID], [Description]) VALUES (3, N'Unassign')
GO
INSERT [dbo].[ComponentStatus] ([ID], [Description]) VALUES (4, N'Reassign')
GO
INSERT [dbo].[ComponentStatus] ([ID], [Description]) VALUES (5, N'Expire')
GO
INSERT [dbo].[ComponentStatus] ([ID], [Description]) VALUES (6, N'Renew')
GO
INSERT [dbo].[ComponentStatus] ([ID], [Description]) VALUES (7, N'Damage')
GO
INSERT [dbo].[ComponentStatus] ([ID], [Description]) VALUES (8, N'Scraped')
GO
INSERT [dbo].[ComponentStatus] ([ID], [Description]) VALUES (9, N'Retire')
GO
SET IDENTITY_INSERT [dbo].[ComponentStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseStatus] ON 
GO
INSERT [dbo].[PurchaseStatus] ([ID], [Description]) VALUES (1, N'Ordered')
GO
INSERT [dbo].[PurchaseStatus] ([ID], [Description]) VALUES (2, N'Pending Delivery')
GO
INSERT [dbo].[PurchaseStatus] ([ID], [Description]) VALUES (3, N'Received')
GO
INSERT [dbo].[PurchaseStatus] ([ID], [Description]) VALUES (4, N'Cancelled')
GO
INSERT [dbo].[PurchaseStatus] ([ID], [Description]) VALUES (5, N'Completed')
GO
INSERT [dbo].[PurchaseStatus] ([ID], [Description]) VALUES (6, N'Closed')
GO
SET IDENTITY_INSERT [dbo].[PurchaseStatus] OFF
GO

GO
SET IDENTITY_INSERT [dbo].[AssetCategory] ON 
GO
INSERT [dbo].[AssetCategory] ([ID], [Description], [Comment]) VALUES (1, N'Hardware', N'Individual Hardwares.')
GO
INSERT [dbo].[AssetCategory] ([ID], [Description], [Comment]) VALUES (2, N'Software', N'Includes Softwares with Licence and free versions.')
GO
SET IDENTITY_INSERT [dbo].[AssetCategory] OFF


SET IDENTITY_INSERT [dbo].[AssetTypes] ON 
GO
INSERT [dbo].[AssetTypes] ([ID], [Description], [AssetCategoryID]) VALUES (1, N'Laptop', 1)
GO
INSERT [dbo].[AssetTypes] ([ID], [Description], [AssetCategoryID]) VALUES (2, N'CPU', 1)
GO
SET IDENTITY_INSERT [dbo].[AssetTypes] OFF
GO

