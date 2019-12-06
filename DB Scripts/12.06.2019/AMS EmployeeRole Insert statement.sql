/*Remove Default Constraint from Employee*/
DECLARE @ConstraintName nvarchar(200)
SELECT 
@ConstraintName = KCU.CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS RC 
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU
ON KCU.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG 
AND KCU.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA 
AND KCU.CONSTRAINT_NAME = RC.CONSTRAINT_NAME
WHERE
KCU.TABLE_NAME = 'Employee' AND
KCU.COLUMN_NAME = 'EmployeeRoleID'
IF @ConstraintName IS NOT NULL EXEC('alter table Employee drop CONSTRAINT ' + @ConstraintName)

/*Truncate Existing Records in EmployeeRole*/
TRUNCATE TABLE [dbo].[EmployeeRole]

/*Insert New Records in EmployeeRole*/
GO
SET IDENTITY_INSERT [dbo].[EmployeeRole] ON 
GO
INSERT [dbo].[EmployeeRole] ([ID], [Designation]) VALUES (1, N'IT')
GO
INSERT [dbo].[EmployeeRole] ([ID], [Designation]) VALUES (2, N'Employee')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
/*Add Constraint from Employee*/
ALTER TABLE [dbo].[Employee]  ADD  CONSTRAINT [FK_Employee_EmployeeRole] FOREIGN KEY([EmployeeRoleID])
REFERENCES [dbo].[EmployeeRole] ([ID])
GO
/*Alter EmployeeID Column in Employee */
ALTER TABLE [dbo].[Employee] ALTER COLUMN EmployeeID NVARCHAR(10)
GO
/*Add Constraint from ComponentType*/
ALTER TABLE [dbo].[ComponentType]  ADD  CONSTRAINT [FK_ComponentType_AssetType] FOREIGN KEY([AssetTypeID])
REFERENCES [dbo].[AssetTypes] ([ID])