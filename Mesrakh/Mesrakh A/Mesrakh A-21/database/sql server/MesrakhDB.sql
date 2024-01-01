﻿--select * from TblSalesBill where SalesCartNo = 4

----*  201  *----------( انشاء قاعدة البيانات)---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create database Mesrakh;                                          --  انشاء قاعدة بيانات المبيعات 

GO

ALTER DATABASE Mesrakh COLLATE Arabic_CI_AS;                      --  تغيير الترميز او الكوليجن لتتعرف قاعدة البيانات على اللغة العربية  

GO

--use master
--GO
--alter database mesrakh set single_user with rollback immediate
--drop database mesrakh
--GO

use Mesrakh;

GO


----*  235  *----------( انواع طرق الاتصال  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblContactMethodsTypes
(
ContactMethodsTypeNo int primary key identity(1,1),  -- رقم طريقة الاتصال
ContactMethodsTypeNoNameAR varchar(50),     -- اسم نوع طريقة الاتصال عربي
ContactMethodsTypeNoNameEN varchar(50)      -- اسم نوع طريقة الاتصال انجليزي
)

GO
insert into TblContactMethodsTypes values ('جوال','mobile');
insert into TblContactMethodsTypes values ('هاتف ثابت','phone');
insert into TblContactMethodsTypes values ('ايميل الكتروني','elctronic mail');
insert into TblContactMethodsTypes values ('صندوق بريد','mail box');
insert into TblContactMethodsTypes values ('موقع ألكتروني','Website');
GO

----*  237  *----------( جدول تحزيم طرق الاتصال )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblConnectingMethodsOfCommunication
(
ConnectingMethodsOfCommunicationNO int primary key identity(1,1), -- رقم ربط طرق الاتصال
OtherDetails varchar(250)
)

GO
--insert into TblConnectingMethodsOfCommunication values (' ');
GO

----*  237  *----------( اجراء مخزن يقوم بإضافة رقم تحزيم ويعيده)---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create proc SpAddNewTblConnectingMethodsOfCommunication
@OtherDetails varchar(250),
@ConnectingMethodsOfCommunicationNO int out
as
begin
insert into TblConnectingMethodsOfCommunication values (@OtherDetails)
set @ConnectingMethodsOfCommunicationNO = SCOPE_IDENTITY()
return @ConnectingMethodsOfCommunicationNO
end

GO
----*  236  *----------( طرق الاتصال )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblMethodsOfCommunication
(
MethodsOfCommunicationNo int primary key identity(1,1), -- رقم طريقة الاتصال
ConnectingMethodsOfCommunicationNO int ,                -- رقم ربط طرق الاتصال
ContactMethodsTypeNo int,                               -- رقم نوع طريقة الاتصال
CommunicationNo varchar(100),                           -- رقم الاتصال
OtherDetails varchar(250)                                -- تفاصيل اخرى
)


-- ( ربط حقل رقم ربط طرق الاتصال بجدول ربط طرق الاتصال   )
alter table TblMethodsOfCommunication
add constraint PK_TblMethodsOfCommunication_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO foreign key (ConnectingMethodsOfCommunicationNO) references TblConnectingMethodsOfCommunication(ConnectingMethodsOfCommunicationNO)  ;


-- ( ربط حقل نوع طريقة الاتصال في جدول طرق الاتصال بجدول انواع طرق الاتصال   )
alter table TblMethodsOfCommunication
add constraint PK_TblMethodsOfCommunication_TblContactMethodsTypes_ContactMethodsTypeNo foreign key (ContactMethodsTypeNo) references TblContactMethodsTypes(ContactMethodsTypeNo)  ;


GO
--insert into TblMethodsOfCommunication values (1,1,'0543202334','مدير المبيعات محمد حسين')
GO

----* 1001 *----------(    اضافة طريقة اتصال جديدة    )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- اجراء مخزن يقوم بإضافة طريقة اتصال جديدة
create proc SpAddNewCommunicationMethod
 @tableName Nvarchar(50),              -- اسم الجدول
 @keyRecordName Nvarchar(50),            -- اسم الحقل الرئيسي
 @keyRecordValue int ,                  --   رقم السجل في الجدول
 @ContactMethodsTypeNo int,             -- نوع طريقة الاتصال
 @CommunicationNo Nvarchar(100),          -- رقم طريقة الاتصال
 @OtherDetails Nvarchar(300)            -- تفاصيل اخرى
 as
 begin
 declare @ConnectingMethodsOfCommunicationNO int 
 declare @CommandString01 Nvarchar(500)
  -- عرض بيانات الاتصالات الخاصة بالسجل المرسل اسمه وقيمته في واسم جدوله
set @CommandString01 = N'select @ConnectingMethodsOfCommunicationNO = TblConnectingMethodsOfCommunication.ConnectingMethodsOfCommunicationNO from TblConnectingMethodsOfCommunication inner join '+quotename(@tableName)+' on '+quotename(@tableName)+'.ConnectingMethodsOfCommunicationNO=TblConnectingMethodsOfCommunication.ConnectingMethodsOfCommunicationNO where '+@keyRecordName+' = '+CONVERT(NVARCHAR(50),@keyRecordValue)+' '
execute sp_executesql @CommandString01,N'@ConnectingMethodsOfCommunicationNO int OUTPUT ',@ConnectingMethodsOfCommunicationNO OUTPUT
-- اذا لم تكن هناك بيانات اتصالات سابقة يتم 
IF @ConnectingMethodsOfCommunicationNO IS NULL
BEGIN
-- انشاء سجل تحزيم لطرق الاتصال 
declare @CommandString02 nvarchar(500)
declare @Details nvarchar(100)
set @Details =  convert(nvarchar(25),getdate())+ ' >>  from SpAddNewCommunicationMethod procedure'
set @CommandString02 = N'insert into [TblConnectingMethodsOfCommunication] values (@Details); select @ConnectingMethodsOfCommunicationNO = SCOPE_IDENTITY() '
execute sp_executesql @CommandString02,N'@Details nvarchar(100) , @ConnectingMethodsOfCommunicationNO int OUTPUT ',@Details,@ConnectingMethodsOfCommunicationNO OUTPUT

-- ربط سجل تحزيم طرق الاتصال بالسجل المطلوب
declare @CommandString03 nvarchar(500)
set @CommandString03 = N'update '+quotename(@tableName) +' set ConnectingMethodsOfCommunicationNO = '+ CONVERT(NVARCHAR(50),@ConnectingMethodsOfCommunicationNO)+' where '+@keyRecordName+' = '+CONVERT(NVARCHAR(50),@keyRecordValue)+' '
execute sp_executesql @CommandString03
END
-- تضاف بيانات طريقة الاتصال في جدول طرق الاتصال
insert into TblMethodsOfCommunication values (@ConnectingMethodsOfCommunicationNO,@ContactMethodsTypeNo,@CommunicationNo,@OtherDetails);
end

-- لحذف هذا الاجراء المجمع
--drop procedure SpAddNewCommunicationMethod

-- طريقة تنفيذ هذا الاجراء المجمع

--SpAddNewCommunicationMethod 'TblManufacturers','ManufacturerNo',1,1,'05555555555','non'
--SpAddNewCommunicationMethod 'TblEmployees','EmployeeNo',6,1,'05555555555','non'

/*
string[] result = null;
DataTools.DataBases.SqlServer.RunProcedure(ref result, "", ConnectionsTools.ConMesrakhMainDB(),new object[][]{ new object[]{ "@tableName" , ""}, new object[] { "@keyRecordName" ,""}, new object[] { "@keyRecordValue",1 }, new object[] { "@ContactMethodsTypeNo" , 1 }, new object[] { "@CommunicationNo" , "0555"}, new object[] { "@OtherDetails", "no details " } });
*/

GO

----*  202  *----------( انشاء جدول الشركات الصانعة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblManufacturers
(
ManufacturerNo int primary key identity(1,1),             -- رقم الشركة الصانعة
CompanyNameAr varchar(100),                                -- اسم الشركة عربي
CompanyNameEn varchar(100) ,                               -- اسم الشركة انجليزي
ConnectingMethodsOfCommunicationNO int                    -- رقم ربط او تحزيم طرق الاتصال
);
GO

-- ( ربط حقل رقم ربط طرق الاتصال بجدول ربط طرق الاتصال   )
alter table TblManufacturers
add constraint PK_TblManufacturers_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO foreign key (ConnectingMethodsOfCommunicationNO) references TblConnectingMethodsOfCommunication(ConnectingMethodsOfCommunicationNO)  ;

GO
--insert into TblManufacturers values ('شركة جنيرال الكتريك','GE',1)
--insert into TblManufacturers values ('شركة السالم ','AL SALEM',1)
GO

----*  203  *----------( صندوق اجراءات مخزنة لإضافة شركة جديدة واعادة رقمها )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create proc spAddManufacturers
@CompanyNameAr varchar(100),                                -- اسم الشركة عربي
@CompanyNameEn varchar(100) ,                               -- اسم الشركة انجليزي
@ConnectingMethodsOfCommunicationNO int,                    -- رقم ربط او تحزيم طرق الاتصال
@ManufacturerNo int out                      -- رقم الشركة الصانعة 
as
begin
insert into TblManufacturers (CompanyNameAr,CompanyNameEn,ConnectingMethodsOfCommunicationNO) values (@CompanyNameAr,@CompanyNameEn,@ConnectingMethodsOfCommunicationNO)
set @ManufacturerNo = SCOPE_IDENTITY();
return @ManufacturerNo
end
GO


----*  203  *----------( انشاء جدول السلع والخدمات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblProductsAndServices
(
ProductOrServiceNumber int primary key identity(1,1), -- رقم السلعة او الخدمة 
ProductOrService bit,                    --  هل هو سلعة نعم سلعة لا خدمة
ProductOrServiceNameAR varchar(100),              -- اسم السلعة او الخدمة عربي
ProductOrServiceNameEN varchar(100),              -- اسم السلعة او الخدمة انجليزي
ProductOrServiceDescriptionAR varchar(200),       -- وصف السلعة او الخدمة عربي
ProductOrServiceDescriptionEN varchar(200)       -- وصف السلعة او الخدمة انجليزي
)

GO


----*  210  *----------( التصنيفات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
--select * from TblCategories
create table TblCategories
(
CategoryNo int primary key identity(1,1),         -- رقم الصنف
CategoryNameAr varchar(100) ,         -- اسم الصنف عربي
CategoryNameEn varchar(100) ,         -- اسم الصنف انجليزي
CategoryDescription varchar(200) ,    -- وصف الصنف
TopCategory int                       -- الصنف الاعلى
)

GO

-- ( ربط حقل النصف الاعلى  بحقل رقم الصنف  )

alter table TblCategories
add constraint PK_TblCategories_TblCategories_CateGOryNo foreign key (TopCateGOry) references TblCategories(CateGOryNo)  ;

GO
--insert into TblCategories values ('سيارات','Cars','السيارات',null);---------------------------------------1
--insert into TblCategories values ('المواد الغذائية','Food','المواد الغذائية',null);---------------------2
--insert into TblCategories values ('المشروبات','drinks','المشروبات',2); ----------------------------------3
--insert into TblCategories values ('مشروبات غازية','Soft drinks','مشروبات غازية',3);---------------------4
--insert into TblCategories values ('بسكوت','Biscuits','بسكوت',2);------------------------------------------5
--insert into TblCategories values ('العاب','games','العاب',null);------------------------------------------6
--insert into TblCategories values ('اجهزة الكترونية','Electronic Devices','اجهزة الكترونية',null);------7
GO
----*  210  *----------( اجراء مخزن لانشاء تصنيف جديد )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create proc spAddCategory
@CategoryNameAr varchar(100) ,         -- اسم الصنف عربي
@CategoryNameEn varchar(100) ,         -- اسم الصنف انجليزي
@CategoryDescription varchar(200) ,    -- وصف الصنف
@TopCategory varchar(200) ,                      -- الصنف الاعلى
@CategoryNo int out        -- رقم الصنف
as
begin
declare @TopCategoryyyy int
IF(@TopCategory != 'NULL')
   begin
      set @TopCategoryyyy = convert(int,@TopCategory)
      insert into TblCategories values (@CategoryNameAr,@CategoryNameEn,@CategoryDescription,@TopCategory)
   end
else
   begin
      insert into TblCategories values (@CategoryNameAr,@CategoryNameEn,@CategoryDescription,null)
   end
set @CategoryNo = SCOPE_IDENTITY();
return @CategoryNo 
end

GO
--drop proc spAddCategory
----*  211  *----------( ربط السلعة او الخدمة مع التصنيف )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblProductsOrServicesAndCategory
(
LinkNo int primary key identity(1,1),        -- رقم الربط
CateGOryNo int ,                             -- رقم الصنف
productOrServiceNumber int                   -- رقم السلعة او الخدمة
)

GO

-- ( ربط حقل رقم الصنف  بحقل رقم الصنف في جدول تصنيف المنتجات  )
alter table TblProductsOrServicesAndCategory
add constraint PK_TblProductsOrServicesAndCategory_TblCategories_CateGOryNo foreign key (CateGOryNo) references TblCategories(CateGOryNo)  ;
GO

-- ( ربط حقل رقم السعلة او الخدمة بحقل رقم رقم السعلة او الخدمة في جدول الخدمات والسلع  )
alter table TblProductsOrServicesAndCategory
add constraint PK_TblProductsOrServicesAndCategory_TblProductsOrServices_ProductNumber foreign key (productOrServiceNumber) references TblProductsAndServices(productOrServiceNumber) on delete cascade ;

GO
--delete from TblProductsAndCategory
--insert into TblProductsAndCategory values (1,1);
--insert into TblProductsAndCategory values (1,2);
--insert into TblProductsAndCategory values (4,3);
--insert into TblProductsAndCategory values (5,4);
--insert into TblProductsAndCategory values (6,5);
--insert into TblProductsAndCategory values (7,6);
GO
--select * from TblCategories inner join TblProductsAndCategory on TblCategories.CategoryNo = TblProductsAndCategory.CateGOryNo inner join TblProducts on TblProductsAndCategory.ProductNumber = TblProducts.ProductNumber 
----*  204  *----------( انشاء جدول وحدات القياس )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblMeasureUnit
(
MeasureUnitNo int primary key identity(1,1), -- رقم وحدة القياس
UnitNameAR varchar(50),                      -- اسم الوحدة عربي
UnitNameEN varchar(50),                      -- اسم الوحدة انجليزي
UnitCodeAR varchar(15),                      -- رمز الوحدة عربي
UnitCodeEN varchar(15),                      -- رمز الوحدة انجليزي
TopMeasureUnit int,                          -- رقم وحدة القياس الاعلى
EqualFromTopMeasureUnit decimal(8,2)         -- قيمة التحويل من الوحدة الأعلى
)
GO

-- ( ربط حقل رقم وحدة القياس الاعلى برقم وحدة القياس )

alter table TblMeasureUnit
add constraint PK_TblMeasureUnit_TopMeasureUnit_self foreign key (TopMeasureUnit) references TblMeasureUnit(MeasureUnitNo)  ;

GO
--insert into TblMeasureUnit values ('حبة','UNIT','ح','QTY',NULL,0);                        --1
--insert into TblMeasureUnit values ('طن','ton','طن','ton',NULL,0);                         --2
--insert into TblMeasureUnit values ('كيلو جرام','kelo gram','كجم','kg',2,0.1000);         --3
--insert into TblMeasureUnit values ('متر مكعب','Cubic meters','متر مكعب','cm',null,0);    --4
--insert into TblMeasureUnit values ('لتر','Liter','لتر','Liter',4,0.1000);                 --5
--insert into TblMeasureUnit values ('ملي لتر','milliliter','ملل','mill',5,0.1000);         --6
--GO
----*  204  *----------( اجراءات مخزنه لاضافة وحدات القياس الجديدة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create proc spAddMeasureUnit
@UnitNameAR varchar(50),                      -- اسم الوحدة عربي
@UnitNameEN varchar(50),                      -- اسم الوحدة انجليزي
@UnitCodeAR varchar(15),                      -- رمز الوحدة عربي
@UnitCodeEN varchar(15),                      -- رمز الوحدة انجليزي
@TopMeasureUnit int ,                          -- رقم وحدة القياس الاعلى
@EqualFromTopMeasureUnit decimal(8,2) ,         -- قيمة التحويل من الوحدة الأعلى
@MeasureUnitNo int out  -- رقم وحدة القياس
as
begin
insert into TblMeasureUnit values (@UnitNameAR , @UnitNameEN , @UnitCodeAR , @UnitCodeEN , @TopMeasureUnit , @EqualFromTopMeasureUnit)
set @MeasureUnitNo = SCOPE_IDENTITY();
return @MeasureUnitNo
end

--drop proc spAddMeasureUnit


--declare @MeasureUnitNo int
--exec spAddMeasureUnit 'a','a','a','a',null,null,@MeasureUnitNo out
--print @MeasureUnitNo
go
--select * from TblMeasureUnit
----*  204  *----------( اجراءات مخزنه لتعديل وحدات القياس  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create proc spEditMeasureUnit
@MeasureUnitNo int ,                         --  رقم وحدة القياس
@UnitNameAR varchar(50),                      -- اسم الوحدة عربي
@UnitNameEN varchar(50),                      -- اسم الوحدة انجليزي
@UnitCodeAR varchar(15),                      -- رمز الوحدة عربي
@UnitCodeEN varchar(15),                      -- رمز الوحدة انجليزي
@TopMeasureUnit int = null,                          -- رقم وحدة القياس الاعلى
@EqualFromTopMeasureUnit decimal(8,2) = null         -- قيمة التحويل من الوحدة الأعلى
as
begin
update TblMeasureUnit set  UnitNameAR = @UnitNameAR , UnitNameEN = @UnitNameEN ,UnitCodeAR = @UnitCodeAR , UnitCodeEN = @UnitCodeEN , TopMeasureUnit = @TopMeasureUnit , EqualFromTopMeasureUnit = @EqualFromTopMeasureUnit where MeasureUnitNo = @MeasureUnitNo
end
--drop proc spEditMeasureUnit
go
----*  205  *----------( انشاء جدول وحدات التغليف )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblEncapsulationUnits
(
EncapsulationUnitsNo int primary key identity(1,1),    -- رقم وحدة التغليف
UnitNameAR varchar(50),                    -- اسم الوحدة عربي
UnitNameEN varchar(50),                    -- اسم الوحدة انجليزي
UnitCodeAR varchar(15),                     -- رمز الوحدة عربي
UnitCodeEN varchar(15)                      -- رمز الوحدة انجليزي
)

GO
--insert into TblEncapsulationUnits values ('صندوق كرتون','carton box','صندوق كرتون','carton box');
--insert into TblEncapsulationUnits values ('صندوق خشب','wood box','صندوق خشب','wood box');
--insert into TblEncapsulationUnits values ('صندوق بلاستيك','plastic box','صندوق بلاستيك','plastic box');

--insert into TblEncapsulationUnits values ('كيس','saccule','كيس','sac');

--insert into TblEncapsulationUnits values ('طبلية','pallet','طبلية','pallet');

--insert into TblEncapsulationUnits values ('علبة معدنية','metal box','علبة معدنية','metal box');
--insert into TblEncapsulationUnits values ('علبة ورقية','paper box','علبة ورقية','paper box');
--insert into TblEncapsulationUnits values ('علبة بلاستيك','plastic box','علبة بلاستيك','plastic box');


GO
----*  206  *----------( انشاء جدول تفاصيل السلع والخدمات  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
--select * from TblproductAndServicesDetails
--inner join TblPriceCategories  on TblproductAndServicesDetails.UnitDetailsNo = TblPriceCategories.UnitDetailsNo 
--inner join TblFreeUnitsOffers on TblproductAndServicesDetails.UnitDetailsNo = TblFreeUnitsOffers.UnitDetailsNo
--inner join TblBarcode on TblproductAndServicesDetails.UnitDetailsNo = TblBarcode.UnitDetailsNo

create table TblproductAndServicesDetails
(
UnitDetailsNo int primary key identity(1,1), -- رقم تفاصيل الوحدة
productOrServiceNumber int ,            -- رقم السلعة او الخدمة
EncapsulationUnitsNo int,               -- رقم وحدة التغليف
MeasureUnitValue decimal(8,2),         -- قيمة وحدةالقياس
MeasureUnitNo int,                    -- رقم وحدة القياس
UnitDetailsValue decimal(8,2),     -- قيمة الوحدة المتبوعة
UnitDetailsNoSelfJoin int ,      -- رقم الوحدة المتبوعة
ManufacturerNo int,           -- الشركة الصانعة
ModelOrProductArabicDescription  varchar(100) ,  -- الموديل انجليزي او وصف السلعة عربي
ModelEnglishOrProductEnglishDescription  varchar(100) ,    -- الموديل انجليزي او وصف السلعة انجليزي
DetailedNameForProductOrServiceAr varchar(100),       -- الاسم المفصل للمنتج اوالخدمة عربي
DetailedNameForProductOrServiceEn varchar(100),       -- الاسم المفصل للمنتج اوالخدمة انجليزي
ShortArabicName varchar(50),   -- الاسم العربي المختصر
ShortEnglishName varchar(50),  -- الاسم الانجليزي المختصر
StockQuantity decimal(8,2), -- كمية المخزون
StockCost decimal(8,2), -- تكلفة المخزون
UnitCost decimal(8,2), -- تكلفة الوحدة
PriceCalculationMethod int -- اسلوب احتساب سعر البيع
)

GO

-- ( ربط حقل رقم وحدة القياس  برقم وحدة القياس في جدول وحدات القياس  )
alter table TblproductAndServicesDetails
add constraint PK_TblproductAndServicesDetails_TblMeasureUnit_MeasureUnitNo foreign key (MeasureUnitNo) references TblMeasureUnit(MeasureUnitNo)  ;

GO

-- ( ربط حقل رقم تفصيل الوحدة  برقم تفصيل الوحدة )
alter table TblproductAndServicesDetails
add constraint PK_TblproductAndServicesDetails_UnitDetailsNoSelfJoin_self foreign key (UnitDetailsNoSelfJoin) references TblproductAndServicesDetails(UnitDetailsNo)  ;

GO

-- ( ربط حقل رقم وحدة التغليف  برقم وحدة التغليف في جدول وحدات التغليف  )
alter table TblproductAndServicesDetails
add constraint PK_TblproductAndServicesDetails_TblEncapsulationUnits_EncapsulationUnitsNo foreign key (EncapsulationUnitsNo) references TblEncapsulationUnits(EncapsulationUnitsNo)  ;

GO

-- ( ربط حقل رقم رقم السلعة او الخدمة  برقم رقم السلعة او الخدمة في جدول رقم الخدمات والسلع  )
alter table TblproductAndServicesDetails
add constraint PK_TblproductAndServicesDetails_TblProductsOrServices_productOrServiceNumber foreign key (productOrServiceNumber) references TblProductsAndServices(productOrServiceNumber)  ;

GO

-- ( ربط حقل رقم الشركة الصانعة  في هذا الجدول رقم الشركة الصانعة في جدول الشركات الصانعة  )
alter table TblproductAndServicesDetails
add constraint PK_TblproductAndServicesDetails_TblManufacturers_ManufacturerNo foreign key (ManufacturerNo) references TblManufacturers(ManufacturerNo)  ;


GO
----*  206  *----------( انشاء إجراء مخزن لإضافة تفاصيل السلع والخدمات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create proc spAddProductAndServicesDetails
@productOrServiceNumber int ,            -- رقم السلعة او الخدمة
@EncapsulationUnitsNo int,               -- رقم وحدة التغليف
@MeasureUnitValue decimal(8,2),         -- قيمة وحدةالقياس
@MeasureUnitNo int,                    -- رقم وحدة القياس
@UnitDetailsValue decimal(8,2),     -- قيمة الوحدة المتبوعة
@UnitDetailsNoSelfJoin int ,        -- رقم الوحدة المتبوعة
@ManufacturerNo int,                -- الشركة الصانعة
@ModelOrProductArabicDescription  varchar(100) ,  -- الموديل انجليزي او وصف السلعة عربي
@ModelEnglishOrProductEnglishDescription  varchar(100) ,    -- الموديل انجليزي او وصف السلعة انجليزي
@DetailedNameForProductOrServiceAr varchar(100),       -- الاسم المفصل للمنتج اوالخدمة عربي
@DetailedNameForProductOrServiceEn varchar(100),       -- الاسم المفصل للمنتج اوالخدمة انجليزي
@ShortArabicName varchar(50),   -- الاسم العربي المختصر
@ShortEnglishName varchar(50),  -- الاسم الانجليزي المختصر
@StockQuantity decimal(8,2), -- كمية المخزون
@StockCost decimal(8,2), -- تكلفة شراء المخزون
@UnitCost decimal(8,2), -- تكلفة شراء الوحدة
@PriceCalculationMethod int, -- اسلوب احتساب سعر البيع
@UnitDetailsNo int out -- رقم تفاصيل الوحدة
as
begin
insert into TblproductAndServicesDetails values (@productOrServiceNumber , @EncapsulationUnitsNo ,@MeasureUnitValue ,@MeasureUnitNo ,@UnitDetailsValue ,@UnitDetailsNoSelfJoin ,@ManufacturerNo ,@ModelOrProductArabicDescription , @ModelEnglishOrProductEnglishDescription,  @DetailedNameForProductOrServiceAr ,@DetailedNameForProductOrServiceEn ,@ShortArabicName ,@ShortEnglishName ,@StockQuantity ,@StockCost,@UnitCost,@PriceCalculationMethod);
set @UnitDetailsNo = SCOPE_IDENTITY();
return @UnitDetailsNo
end
--drop proc spAddProductAndServicesDetails
GO

----*  207  *----------( انشاء جدول الباركود )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblBarcode
(
BarcodeSN int primary key identity(1,1),     -- الرقم المتسلسل للباركود
UnitDetailsNo int ,          -- رقم تفاصيل الوحدة
BarcodeNo varchar(20)                        -- رقم الباركود
)

GO

-- ( ربط حقل رقم تفاصيل الوحدة  بحقل رقم تفاصيل الوحدة في جدول تفاصيل السلع والخدمات  )
alter table TblBarcode
add constraint PK_TblBarcode_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo) on delete cascade ;

GO
--insert into TblBarcode values (11111,1,'');
--insert into TblBarcode values (11112,1);
--insert into TblBarcode values (22222,2);
--GO
----*  208  *----------( انشاء جدول عروض الوحدات المجانية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblFreeUnitsOffers
(
PromoNo int primary key identity(1,1),    -- رقم العرض
UnitDetailsNo int ,                     -- رقم تفاصيل الوحدة
LessQuantity decimal(8,2) ,               --  اقل كيمة
HighestQuantity decimal(8,2) ,            --  اعلى كمية
NumberOfFreeUnits   decimal(8,2) ,        -- عدد الوحدات المجانية
PromoStartDate datetime ,                 -- تاريخ بداية العرض
PromoEndDate  datetime                    -- تاريخ نهاية العرض
)

GO

-- ( ربط حقل رقم تفاصيل الوحدة  بحقل رقم تفاصيل الوحدة في جدول تفاصيل السلع والخدمات  )
alter table TblFreeUnitsOffers
add constraint PK2_TblFreeUnitsOffers_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo) on delete cascade ;

GO
--insert into TblFreeUnitsOffers values (1,5,10,1,'2021/1/1','2024/1/1');
--insert into TblFreeUnitsOffers values (1,11,20,2,'2021/1/1','2024/1/1');
--GO
----*  209  *----------( انشاء جدول الفئات السعرية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblPriceCategories
(
PriceCateGOryNo int primary key identity(1,1),        -- رقم الفئة السعرية
UnitDetailsNo int ,                           -- رقم تفاصيل الوحدة
LessQuantity decimal(8,2) ,               --  اقل كيمة
HighestQuantity decimal(8,2) ,            --  اعلى كمية
Price  decimal(8,2)                       -- السعر
)

GO

-- ( ربط حقل رقم تفاصيل الوحدة  بحقل رقم تفاصيل الوحدة في جدول تفاصيل السلع والخدمات  )
alter table TblPriceCategories
add constraint PK2_TblPriceCategories_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo) on delete cascade ;

GO
--insert into TblPriceCategories values (1,1,10,200);
--insert into TblPriceCategories values (2,11,50,190);
--insert into TblPriceCategories values (2,51,100,150);
--GO
----*  219  *----------( المنشآت )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  


create table TblEnterprise
(
EnterpriseNo int primary key identity(1,1),   -- رقم المنشأة
EnterpriseNameAR varchar(200),    -- اسم المنشأة عربي
EnterpriseNameEN varchar(200),     -- اسم المنشأة انجليزي
EnterpriseIcon varchar(max),       -- شعار المنشأة
EnterpriseDetails varchar(200) ,    -- تفاصيل
VATrate int -- نسبة الضريبة
)

GO
--insert into TblEnterprise values ('شركة السلام','alsalam company','fdsfet4et','لا توجد تفاصيل');
--GO


----*  220  *----------( فروع المنشأة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblEnterpriseBranches
(
BranchNumber int primary key identity(1,1),     -- رقم الفرع
EnterpriseNo int,                   -- رقم المنشأة
BranchTypeNo varchar(100),         --  نوع الفرع
BranchNameAR varchar(200),      -- اسم الفرع عربي
BranchNameEN varchar(200) ,     -- اسم الفرع انجليزي
NationalAddress varchar(200) ,       --  العنوان الوطني
BranchDetail varchar(500) ,         -- تفاصيل
ConnectingMethodsOfCommunicationNO int -- رقم ربط طرق الاتصال
)

GO
-- ( ربط حقل رقم المنشأة  بحقل رقم المنشأة في جدول المنشآت   )
alter table TblEnterpriseBranches
add constraint PK_TblEnterpriseBranches_TblEnterprise_EnterpriseNo foreign key (EnterpriseNo) references TblEnterprise(EnterpriseNo)  ;

GO


-- ( ربط حقل رقم ربط طرق الاتصال بجدول ربط طرق الاتصال   )
alter table TblEnterpriseBranches
add constraint PK_TblEnterpriseBranches_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO foreign key (ConnectingMethodsOfCommunicationNO) references TblConnectingMethodsOfCommunication(ConnectingMethodsOfCommunicationNO)  ;


GO
--insert into TblEnterpriseBranches values (1,1,'فرع رقم 1','enterprise 1',1,'التفاصيل مستودع',1);
--insert into TblEnterpriseBranches values (1,2,'فرع رقم 2','enterprise 2',2,'التفاصيل معرض',1);
--GO

----*  219  *----------( صندوق اجراءات مخزنة لإضافة فرع منشأة جديد واعادة رقمه )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create proc spAddEnterpriseBranches
@EnterpriseNo int,                   -- رقم المنشأة
@BranchTypeNo varchar(100),         --  نوع الفرع
@BranchNameAR varchar(200),      -- اسم الفرع عربي
@BranchNameEN varchar(200) ,     -- اسم الفرع انجليزي
@NationalAddress varchar(200) ,       --  العنوان
@BranchDetail varchar(500) ,         -- تفاصيل
@ConnectingMethodsOfCommunicationNO int , -- رقم ربط طرق الاتصال
@BranchNumber int out     -- رقم الفرع
as
begin
insert into TblEnterpriseBranches (EnterpriseNo,BranchTypeNo,BranchNameAR,BranchNameEN, NationalAddress ,BranchDetail,ConnectingMethodsOfCommunicationNO) values (@EnterpriseNo,@BranchTypeNo,@BranchNameAR,@BranchNameEN,@NationalAddress ,@BranchDetail,@ConnectingMethodsOfCommunicationNO)
set @BranchNumber  = SCOPE_IDENTITY();
return @BranchNumber 
end
GO

----*  248  *----------( الحسابات المحاسبية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
--update TblAccounts set AccountNameEN = 'aa' , AccountNameAR =  'aa' , AccountInformations = 'aa' , TopAccountNo = null,ClientsNo = null  where AccountNo = 4

create table TblAccounts --  انشاء جدول الحسابات 
(
AccountNo int primary key ,--------------------------------------------------------- رقم الحساب  
AccountNameEN varchar(100),------------------------------------------------- اسم الحساب بالانجليزي
AccountNameAR varchar(100),--------------------------------------------------- اسم الحساب بالعربي
AccountInformations varchar(250), -------------------------------------- معلومات الحساب
TopAccountNo int default null -------------------------------------------------------------- رقم الحساب الاعلى
);

-- &&&&&&&&&&&&&&&&&& ربط حقل رقم الحساب الاعلى بحقل رقم الحساب    
alter table TblAccounts
add constraint PK_TblAccounts_TopAccountNo_self foreign key (TopAccountNo) references TblAccounts(AccountNo)  ;

GO
---->>>>>>>>>>>>>> تسجيل بيانات حسابات جديدة
--*1
insert into TblAccounts values (1,'account1','اصول','لا توجد ملاحظات 1',null);-- لا تحذف لانها تحوي الحسابات الرئيسية التي تعتمد عليها الاستعلامات القادمة
   --**01
   insert into TblAccounts values (101,'account4','اصول ثابته ','لا توجد ملاحظات 4',1);
       --***001
       insert into TblAccounts values (101001,'account7','مباني','لا توجد ملاحظات 7',101);
       insert into TblAccounts values (101001001,'account7','مبنى المحجر','لا توجد ملاحظات 7',101001);
       insert into TblAccounts values (101001002,'account7','مبنى الصفى','لا توجد ملاحظات 7',101001);
       insert into TblAccounts values (101001003,'account7','مبنى الروضه','لا توجد ملاحظات 7',101001);
       --***002
       insert into TblAccounts values (101002,'account7','سيارات','لا توجد ملاحظات 7',101);
       insert into TblAccounts values (101002001,'account7','مرسيدس ن ق ق 705','لا توجد ملاحظات 7',101002);
       insert into TblAccounts values (101002002,'account7','تريله س م ه 648','لا توجد ملاحظات 7',101002);
       insert into TblAccounts values (101002003,'account7','باص ب ب ف 565','لا توجد ملاحظات 7',101002);
       --***003
       insert into TblAccounts values (101003,'account7','اثاث','لا توجد ملاحظات 7',101);
       --***004
       insert into TblAccounts values (101004,'account7','آلات','لا توجد ملاحظات 7',101);
       insert into TblAccounts values (101003001,'account7','مكينة طباعة رقم 991','لا توجد ملاحظات 7',101004);
       insert into TblAccounts values (101003002,'account7','مكينة تغليف رقم 992','لا توجد ملاحظات 7',101004);

   --**02
   insert into TblAccounts values (102,'account5','اصول متداولة','لا توجد ملاحظات 5',1);
       --***001
       insert into TblAccounts values (102001,'account7','نقدية','لا توجد ملاحظات 7',102);
              --****001
              insert into TblAccounts values (102001001,'account7','بنك الراجحي','لا توجد ملاحظات 7',102001);
              --****002
              insert into TblAccounts values (102001002,'account7','الفرع رقم 1','لا توجد ملاحظات 7',102001);
              insert into TblAccounts values (1020010021,'account7','الفرع رقم 1 / الكاشير رقم 1','لا توجد ملاحظات 7',102001002);
              insert into TblAccounts values (1020010022,'account7','الفرع رقم 1/ الكاشير رقم 2','لا توجد ملاحظات 7',102001002);
              --****003
              insert into TblAccounts values (102001003,'account7','الفرع رقم 2','لا توجد ملاحظات 7',102001);
              insert into TblAccounts values (1020010031,'account7','الفرع رقم 2 / الكاشير رقم 1','لا توجد ملاحظات 7',102001003);
              insert into TblAccounts values (1020010032,'account7','الفرع رقم 2 / الكاشير رقم 2','لا توجد ملاحظات 7',102001003);
       --***002
       insert into TblAccounts values (102002,'account7','مدينين','لا توجد ملاحظات 7',102);
       insert into TblAccounts values (102002001,'account7','شركة سعد','لا توجد ملاحظات 7',102002);
       insert into TblAccounts values (102002002,'account7','شركة شافي','لا توجد ملاحظات 7',102002);
       --***003
       insert into TblAccounts values (102003,'account7','اوراق قبض','لا توجد ملاحظات 7',102);
       insert into TblAccounts values (102003001,'account7','شركة سعد','لا توجد ملاحظات 7',102003);
       insert into TblAccounts values (102003002,'account7','شركة شافي','لا توجد ملاحظات 7',102003);
       --***004
       insert into TblAccounts values (102004,'account7','مصروفات مقدمة','لا توجد ملاحظات 7',102);
       insert into TblAccounts values (102004001,'account7','ايجار المعرض رقم 1','لا توجد ملاحظات 7',102004);
       insert into TblAccounts values (102004002,'account7','ايجار المعرض رقم 2','لا توجد ملاحظات 7',102004);

       --***005
       insert into TblAccounts values (102005,'account7','مخزون','لا توجد ملاحظات 7',102);


       --***006
       insert into TblAccounts values (102006,'account7','مصروفات','لا توجد ملاحظات 7',102);
 
       insert into TblAccounts values (102006001,'account7','ايجار','لا توجد ملاحظات 7',102006);
       insert into TblAccounts values (1020060011,'account7',' العمارة رقم 1','لا توجد ملاحظات 7',102006001);
       insert into TblAccounts values (1020060012,'account7','المستودع رقم 44','لا توجد ملاحظات 7',102006001);

       insert into TblAccounts values (102006002,'account7','مرتبات','لا توجد ملاحظات 7',102006);
       insert into TblAccounts values (1020060021,'account7','مرتب خالد','لا توجد ملاحظات 7',102006002);
       insert into TblAccounts values (1020060022,'account7','مرتب ايهم','لا توجد ملاحظات 7',102006002);


--#2
insert into TblAccounts values (2,'account2','خصوم','لا توجد ملاحظات 2',null);
   --##01
   insert into TblAccounts values (201,'account6','خصوم قصيرة الاجل','لا توجد ملاحظات 6',2);
       --###001

       --###002
       insert into TblAccounts values (201002,'account7','مصروفات مستحقة','لا توجد ملاحظات 7',201);
              --####001
              insert into TblAccounts values (201002001,'account7','العمارة رقم 22','لا توجد ملاحظات 7',201002);
              insert into TblAccounts values (201002002,'account7','قسط سيارة رقم س س ث 565','لا توجد ملاحظات 7',201002);
       --###003
       insert into TblAccounts values (201003,'account7','دائنين','لا توجد ملاحظات 7',201);
              --####001
              insert into TblAccounts values (201003001,'account7','شركة السعيد','لا توجد ملاحظات 7',201003);
              insert into TblAccounts values (201003002,'account7','شركة الدانة','لا توجد ملاحظات 7',201003);
       --###004
       insert into TblAccounts values (201004,'account7','اوراق دفع','لا توجد ملاحظات 7',201);
              --####001
              insert into TblAccounts values (201004001,'account7','شركة السعيد','لا توجد ملاحظات 7',201004);
              insert into TblAccounts values (201004002,'account7','شركة الدانة','لا توجد ملاحظات 7',201004);
       --###005
       insert into TblAccounts values (201001,'account3','ايرادات','لا توجد ملاحظات 3',201);
       insert into TblAccounts values (201001001,'account3','ايراد بيع سلع','لا توجد ملاحظات 3',201001);
       insert into TblAccounts values (201001002,'account3','ايراد ودائع','لا توجد ملاحظات 3',201001);

   --##02
   insert into TblAccounts values (202,'account7','خصوم طويلة الاجل','لا توجد ملاحظات 7',2);
       --###001
       insert into TblAccounts values (202001,'account7','قروض','لا توجد ملاحظات 7',202);
	          --####001
              insert into TblAccounts values (202001001,'account7','قرض بنك الراجحي','لا توجد ملاحظات 7',202001);
       insert into TblAccounts values (202002,'account7','مخصصات','لا توجد ملاحظات 7',202);


--$3
insert into TblAccounts values (3,'account3','حقوق الملكية','لا توجد ملاحظات 3',null);
   --$$01
   insert into TblAccounts values (301,'account3','راس المال','لا توجد ملاحظات 3',3);
       --&&&001
       insert into TblAccounts values (301001,'account3','راس المال / احمد سالم','لا توجد ملاحظات 3',301);
	                insert into TblAccounts values (301001001,'account3','استثمار / احمد سالم','لا توجد ملاحظات 3',301001);
					insert into TblAccounts values (301001002,'account3','مسحوبات / احمد سالم','لا توجد ملاحظات 3',301001);
       insert into TblAccounts values (301002,'account3','راس المال / مسفر سالم','لا توجد ملاحظات 3',301);
	                insert into TblAccounts values (301002001,'account3','استثمار / مسفر سالم','لا توجد ملاحظات 3',301002);
					insert into TblAccounts values (301002002,'account3','مسحوبات / مسفر سالم','لا توجد ملاحظات 3',301002);
   --$$02
   insert into TblAccounts values (302,'account3','الارباح المحتجزة','لا توجد ملاحظات 3',3);
       --&&&001
       insert into TblAccounts values (302001,'account3','الارباح المحتجزة','لا توجد ملاحظات 3',302);

   --$$03
   insert into TblAccounts values (303,'account3','فائض / خسائر اعادة التقييم','لا توجد ملاحظات 3',3);
       --&&&001
       insert into TblAccounts values (303001,'account3','فائض / خسائر اعادة التقييم','لا توجد ملاحظات 3',303);

   --$$04
   insert into TblAccounts values (304,'account3','الاحتياطيات','لا توجد ملاحظات 3',3);
       --&&&001
       insert into TblAccounts values (304001,'account3','احتياطي كوارث','لا توجد ملاحظات 3',304);

GO

----*  246  *----------( الحسابات البنكية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblBankAccounts 
(
Number int primary key identity(1,1),  -- الرقم
BranchNumber int,                   -- رقم الفرع
AccountHoldersName varchar(50),   -- اسم صاحب الحساب
Bank varchar(50),   -- ........... البنك
BankAccountNumber varchar(50) , -- رقم الحساب البنكي
IBAN varchar(50), -- رقم الايبان
AccountNo int -- رقم الحساب
)

GO

-- ( ربط حقل رقم الفرع  بحقل رقم الفرع في جدول فروع المنشآت     )
alter table TblBankAccounts
add constraint pk_TblBankAccounts_TblEnterpriseBranches_BranchNumber foreign key (BranchNumber) references TblEnterpriseBranches(BranchNumber)

GO
-- ( ربط حقل رقم الحساب  بالحقل المقابل في جدول الحسابات المحاسبية     )
alter table TblBankAccounts
add constraint pk_TblBankAccounts_TblAccounts_AccountNo foreign key (AccountNo) references TblAccounts(AccountNo)


GO

----*  246  *----------( صناديق النقدية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblCashBoxes 
(
Number int primary key identity(1,1),  -- الرقم
BranchNumber int,                   -- رقم الفرع
BoxCode varchar(50),   -- رمز الصندوق
AccountNo int -- رقم الحساب
)

GO

-- ( ربط حقل رقم الفرع  بحقل رقم الفرع في جدول فروع المنشآت     )
alter table TblCashBoxes
add constraint pk_TblCashBoxes_TblEnterpriseBranches_BranchNumber foreign key (BranchNumber) references TblEnterpriseBranches(BranchNumber)

GO
-- ( ربط حقل رقم الحساب  بالحقل المقابل في جدول الحسابات المحاسبية     )
alter table TblCashBoxes
add constraint pk_TblCashBoxes_TblAccounts_AccountNo foreign key (AccountNo) references TblAccounts(AccountNo)

GO

----*  246  *----------( وحدات العمليات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
--select * from TblOperationUnits
--update TblOperationUnits set devicenumber = null
create table TblOperationUnits
(
OperationUnitNumber int primary key identity(1,1),  -- رقم وحدة العمليات
BranchNumber int,                   -- رقم الفرع
UnitNoInBranch varchar(50),          -- رقم الوحدة في الفرع
DeviceNumber varchar(50),   -- رقم الجهاز
AccountNo int -- رقم الحساب
)

GO

-- ( ربط حقل رقم الفرع  بحقل رقم الفرع في جدول فروع المنشآت     )
alter table TblOperationUnits
add constraint pk_TblOperationUnits_TblEnterpriseBranches_BranchNumber foreign key (BranchNumber) references TblEnterpriseBranches(BranchNumber)

GO
-- ( ربط حقل رقم الحساب  بالحقل المقابل في جدول الحسابات المحاسبية     )
alter table TblOperationUnits
add constraint pk_TblOperationUnits_TblAccounts_AccountNo foreign key (AccountNo) references TblAccounts(AccountNo)


GO
--insert into TblOperationUnits values (1,'a12'); 
--insert into TblOperationUnits values (1,'a13'); 
--insert into TblOperationUnits values (2,'a12'); 
--insert into TblOperationUnits values (2,'a13'); 
--GO

----*  221  *----------( الأرفف )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblShelves
(
ShelfGeneralNo int primary key identity(1,1),      -- رقم الرف
ShelfCode varchar(50),                 -- كود الرف
BranchNumber int                       -- رقم الفرع
)

GO

-- ( ربط حقل رقم الفرع  بحقل رقم الفرع في جدول فروع المنشآت   )

alter table TblShelves
add constraint PK_TblShelves_TblEnterpriseBranches_BranchNumber foreign key (BranchNumber) references TblEnterpriseBranches(BranchNumber)  ;

GO
--insert into TblShelves values ('001',1);
--insert into TblShelves values ('002',1);
--insert into TblShelves values ('003',1);

--insert into TblShelves values ('001',2);
--insert into TblShelves values ('002',2);
--insert into TblShelves values ('003',2);
--GO

----*  221  *----------( ربط السلع والأرفف )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblConnectionTblShelvesAndTblProductsAndServices
(
ConnectionNo int primary key identity(1,1),      -- رقم الربط
ShelfGeneralNo int,                 -- رقم الرف
ProductOrServiceNumber int     -- رقم السلعة او الخدمة
)

go
-- ( ربط حقل رقم الرف بالحقل لمقابل في جدول الارفف   )
alter table TblConnectionTblShelvesAndTblProductsAndServices
add constraint PK_TblConnectionTblShelvesAndTblProductsAndServices_TblShelves_ShelfGeneralNo foreign key (ShelfGeneralNo) references TblShelves(ShelfGeneralNo)  ;

go
-- ( ربط حقل رقم السلعة او الخدمة بالحقل المقابل في جدول الخدمات والسلع   )
alter table TblConnectionTblShelvesAndTblProductsAndServices
add constraint PK_TblConnectionTblShelvesAndTblProductsAndServices_TblProductsAndServices_ProductOrServiceNumber foreign key (ProductOrServiceNumber) references TblProductsAndServices(ProductOrServiceNumber)  ;


----*  229  *----------( الدول )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblCountries 
(
CountryNo int primary key identity(1,1),      -- رقم الدولة
CountrNameAr varchar(50),  -- إسم الدولة عربي
CountrNameEn varchar(50),  -- إسم الدولة إنجليزي
NationalityMaleAr varchar(50),  -- الجنسية للذكور عربي
NationalityMaleEn varchar(50),-- الجنسية للذكور إنجليزي
NationalityFeMaleAr varchar(50),-- الجنسية للاناث عربي
NationalityFemaleEn varchar(50),-- الجنسية للاناث إنجليزي
CurrencyAr varchar(50) , -- إسم العملة عربي
CurrencyEn varchar(50) , -- إسم العملة إنجليزي
CurrencyAgainstTheUSDollar decimal(7,2) -- العملة مقابل الدولار الأمريكي
)

insert into TblCountries (CountrNameAr , CountrNameEn , NationalityMaleAr , NationalityMaleEn , NationalityFeMaleAr , NationalityFemaleEn , CurrencyAr , CurrencyEn , CurrencyAgainstTheUSDollar ) values ('المملكة العربية السعودية','Kingdom Saudi Arabia','سعودي','Saudi','سعودية','Saudi','ريال','Rial',3.75)
insert into TblCountries (CountrNameAr , CountrNameEn , NationalityMaleAr , NationalityMaleEn , NationalityFeMaleAr , NationalityFemaleEn , CurrencyAr , CurrencyEn , CurrencyAgainstTheUSDollar ) values ('جمهورية مصر العربية','The Egyptian Arabic Republic','مصري','Egypt','مصرية','Egyptian','','',1)
insert into TblCountries (CountrNameAr , CountrNameEn , NationalityMaleAr , NationalityMaleEn , NationalityFeMaleAr , NationalityFemaleEn , CurrencyAr , CurrencyEn , CurrencyAgainstTheUSDollar ) values ('جمهورية بنغلاديش الشعبية','Peoples Republic of Bangladesh','بنجلاديشي','Bangladeshi','بنجلاديشية','Bangladeshi','','',1)
insert into TblCountries (CountrNameAr , CountrNameEn , NationalityMaleAr , NationalityMaleEn , NationalityFeMaleAr , NationalityFemaleEn , CurrencyAr , CurrencyEn , CurrencyAgainstTheUSDollar ) values ('جمهورية الهند','Republic of India','Indian','Saudi','هندية','Indian','','',1)
insert into TblCountries (CountrNameAr , CountrNameEn , NationalityMaleAr , NationalityMaleEn , NationalityFeMaleAr , NationalityFemaleEn , CurrencyAr , CurrencyEn , CurrencyAgainstTheUSDollar ) values ('جمهورية السودان','Republic of Sudan','سوداني','Sudanese','سودانية','Sudanese','','',1)
insert into TblCountries (CountrNameAr , CountrNameEn , NationalityMaleAr , NationalityMaleEn , NationalityFeMaleAr , NationalityFemaleEn , CurrencyAr , CurrencyEn , CurrencyAgainstTheUSDollar ) values ('جمهورية الفلبين','Republic of the Philippines','فلبيني','Filipino','فلبينية','Filipino','','',1)
insert into TblCountries (CountrNameAr , CountrNameEn , NationalityMaleAr , NationalityMaleEn , NationalityFeMaleAr , NationalityFemaleEn , CurrencyAr , CurrencyEn , CurrencyAgainstTheUSDollar ) values ('جمهورية باكستان','Republic of Pakistan','باكستاني','Pakistani','باكستانية','Pakistani','','',1)

go
----*  229  *----------( الموظفين )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblEmployees
(
EmployeeNo int primary key identity(1,1),      -- رقم الموظف
EmployeeNameAR varchar(50),   -- اسم الموظف عربي
EmployeeNameEN varchar(50),   -- اسم الموظف انجليزي
Gendar int,            -- الجنس
CountryNo int,      -- الجنسية
ConnectingMethodsOfCommunicationNO int , -- رقم تحزيم طرق الاتصال
AccountNo int -- رقم الحساب في جدول الحسابات المحاسبية
)

GO
-- ( ربط حقل رقم او تحزيم طرق الاتصال بجدول تحزيم طرق الاتصال   )
alter table TblEmployees
add constraint PK_TblEmployees_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO foreign key (ConnectingMethodsOfCommunicationNO) references TblConnectingMethodsOfCommunication(ConnectingMethodsOfCommunicationNO)  ;

GO
-- ( ربط قل الجنسية بجدول الدول   )
alter table TblEmployees
add constraint PK_TblEmployees_TblCountries_CountryNo foreign key (CountryNo) references TblCountries(CountryNo)  ;

GO

-- ( ربط حقل رقم الحساب  بالحقل المقابل في جدول الحسابات المحاسبية     )
alter table TblEmployees
add constraint pk_TblEmployees_TblAccounts_AccountNo foreign key (AccountNo) references TblAccounts(AccountNo)

GO
--insert into TblEmployees values ('الموظف علي 002','ali 002','male',1,'image00655555',1);
--GO


 ----*   227   *----------( العملاء )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblClients
(
ClientsNo int primary key identity(1,1),         -- رقم العميل
ClientNameAR varchar(100),           -- اسم العميل عربي
ClientNameEN varchar(100),           -- اسم العميل انجليزي
Customer bit,                    -- زبون
Supplier bit,                   -- مورد
TaxNo varchar(50),                   -- الرقم الضريبي
OtherDetails varchar(200),           -- تفاصيل اخرى
InterestOnCapital decimal(5,2),      -- الفائدة على رأس المال
PartnersShareOfProfits decimal(5,2),  -- نسبة الشريك من الارباح
ConnectingMethodsOfCommunicationNO int,  -- رقم ربط او تحزيم طرق الاتصال
CountryNo int ,       -- رقم الدولة
ZipCode varchar(20),    -- الرمز البريدي
CityName varchar(20),    -- اسم المدينة
DistrictName varchar(20),    -- اسم الحي
StreetName varchar(20),    -- اسم الشارع
BuildingNo varchar(20),    -- رقم المبنى   
SecondaryNo varchar(20),    -- الرقم الفرعى
UnitNumber varchar(20),    -- رقم الوحدة
ShortAddress varchar(20),    -- العنوان المختصر
AccountNo int -- رقم الحساب المحاسبي
)


GO
-- ( ربط حقل رقم او تحزيم طرق الاتصال بجدول تحزيم طرق الاتصال   )
alter table TblClients
add constraint PK_TblClients_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO foreign key (ConnectingMethodsOfCommunicationNO) references TblConnectingMethodsOfCommunication(ConnectingMethodsOfCommunicationNO)  ;

GO
-- ( ربط حقل رقم الدولة  بالحقل المقابل في جدول الدول     )
alter table TblClients
add constraint pk_TblClients_TblCountries_CountryNo foreign key (CountryNo) references TblCountries(CountryNo)


GO
-- ( ربط حقل رقم الحساب  بالحقل المقابل في جدول الحسابات المحاسبية     )
alter table TblClients
add constraint pk_TblClients_TblAccounts_AccountNo foreign key (AccountNo) references TblAccounts(AccountNo)


GO
--insert into TblClients values ('شركة سعد','client 1',2,'tax 65465','لا توجد تفاصيل اخرى',5.5,2.5,1);    --1
--insert into TblClients values ('شركة شافي','client 2',2,'tax 77777','لا توجد تفاصيل اخرى',2.2,2.2,1);   --2
--insert into TblClients values ('مرتب خالد','client 3',4,'tax 88888','لا توجد تفاصيل اخرى',3.3,3.3,1);   --3
--insert into TblClients values ('مرتب ايهم','client 1',4,'tax 65465','لا توجد تفاصيل اخرى',5.5,2.5,1);   --4
--insert into TblClients values ('شركة السعيد','client 2',1,'tax 77777','لا توجد تفاصيل اخرى',2.2,2.2,1); --5
--insert into TblClients values ('شركة الدانة','client 3',1,'tax 88888','لا توجد تفاصيل اخرى',3.3,3.3,1); --6
--insert into TblClients values ('احمد سالم','client 1',3,'tax 65465','لا توجد تفاصيل اخرى',5.5,2.5,1);   --7
--insert into TblClients values ('مسفر سالم','client 2',3,'tax 77777','لا توجد تفاصيل اخرى',2.2,2.2,1);   --8
--GO


----***  243  ***----------( جدول الكائنات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblObjects
(
ObjectNo int primary key identity(1,1),  -- رقم الكائن
ObjectNameAR varchar(100),   -- اسم الكائن عربي
ObjectNameEN varchar(100)   -- اسم الكائن انجليزي
)

GO

insert into TblObjects values ('الاتصال بقواعد البيانات','DataBases Connections');
insert into TblObjects values ('الشركات الصانعة','manufacturers');
insert into TblObjects values ('حسابات المستخدمين','Users Accounts'); -- حسابات المستخدمين
insert into TblObjects values ('إدارة صلاحيات مجموعات المستخدمين','Manage User Group Permissions');
insert into TblObjects values ('السلع و الخدمات','Products And Services');
insert into TblObjects values ('الموظفين','Employees');
insert into TblObjects values ('التصنيفات','Categories');
insert into TblObjects values ('الحسابات','Accounting Accounts'); -- الحسابات المحاسبية
insert into TblObjects values ('وحدات القياس','Measurement units');
insert into TblObjects values ('وحدات التغليف','Encapsulation Units');
insert into TblObjects values ('تفاصيل السلع والخدمات','product And Services Details');
insert into TblObjects values ('الباركود','Barcode');
insert into TblObjects values ('الفئات السعرية','Price Categories');
insert into TblObjects values ('عروض الوحدات المجانية','Free Unit Offers');
insert into TblObjects values ('المنشآت','Enterprises');
insert into TblObjects values ('فروع المنشآت','Enterprise Branches');
insert into TblObjects values ('وحدات العمليات','Unit Branch');
insert into TblObjects values ('الأرفف','Shelves');
insert into TblObjects values ('الدول','Countries');
insert into TblObjects values ('الموظفين','Employees');
insert into TblObjects values ('العملاء','Clients');
insert into TblObjects values ('قيود اليومية','Journal Entry');
insert into TblObjects values ('الورديات','Shifts');
insert into TblObjects values ('وحدات العمليات','Operation Units');
insert into TblObjects values ('الحسابات البنكية','Bank Accounts');
insert into TblObjects values ('صناديق النقدية','Cash Boxes');
insert into TblObjects values ('المبيعات','Sales');

-- Shifts
--insert into TblObjects values ('كائن','object');

GO


----***  241  ***----------( مجموعات صلاحيات المستخدمين )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblUsersPermissionsGroup
(
PermissionGroupNo int primary key identity(1,1),  -- رقم مجموعة الصلاحيات
PermissionGroupNameAR varchar(100),   -- اسم مجموعة الصلاحيات عربي
PermissionGroupNameEN varchar(100)   -- اسم مجموعة الصلاحيات انجليزي
)

GO

 --select * from UsersPermissionsGroup
----***  244  ***----------( جدول الصلاحيات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblPermissions
(
PermissionNo int primary key identity(1,1),  -- رقم صلاحية 
ObjectNo int,                          -- رقم الكائن
PermissionGroupNo int,               -- رقم مجموعة الصلاحيات
ShowData bit,                            -- عرض
AddData bit,                             -- اضافة
EditData bit,                            -- تعديل
DeleteData bit                           -- حذف
)

GO

-- ( ربط حقل رقم الكائن  بحقل رقم الكائن في جدول الكائنات     )
alter table TblPermissions
add constraint pk_TblPermissions_TblObjects_ObjectNo foreign key (ObjectNo) references TblObjects(ObjectNo)

GO

-- ( ربط حقل رقم مجموعة الصلاحيات  بحقل رقم مجموعة الصلاحيات في جدول مجموعات الصلاحيات     )
alter table TblPermissions
add constraint pk_TblPermissions_TblUsersPermissionsGroup_PermissionGroupNo foreign key (PermissionGroupNo) references TblUsersPermissionsGroup(PermissionGroupNo)

Go

--insert into TblUsersPermissionsGroup values ('مدير البرنامج','program admin');
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (1,1 );
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (2,1 );
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (3,1 );
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (4,1 );
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (5,1 );
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (6,1 );
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (7,1 );
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (8,1 );
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (9,1 );
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (10,1 );
--insert into TblPermissions (ObjectNo,PermissionGroupNo) values (11,1 );
--Go
--delete from TblPermissions
---***  241  ***----------( تسجيل بيانات مجموعة جديدة واعادة رقم المجموعة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create proc SpAddUsersPermissionsGroup
 @PermissionGroupNameAR varchar(100),                   -- اسم مجموعة الصلاحيات عربي
 @PermissionGroupNameEN varchar(100),                   -- اسم مجموعة الصلاحيات انجليزي
 @PermissionGroupNo int out                             -- اعادة رقم المجموعة
 as
 begin
 insert into TblUsersPermissionsGroup values(@PermissionGroupNameAR,@PermissionGroupNameEN);
 set @PermissionGroupNo = SCOPE_IDENTITY();
  insert into TblPermissions (TblPermissions.ObjectNo,TblPermissions.PermissionGroupNo) select TblObjects.ObjectNo,@PermissionGroupNo from TblObjects  
  return @PermissionGroupNo
 end
 GO
 --drop procedure SpAddUsersPermissionsGroup

----***  242  ***----------( حسابات المستخدمين )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblUsersAccounts
(
UserAccountNo int primary key identity(1,1),  -- رقم المستخدم
UserAccountName varchar(50),      -- اسم المستخدم
UserAccountPassword varchar(50),  -- كلمة السر
PermissionGroupNo int ,           -- رقم مجموعة الصلاحيات
EmployeeNo int ,                   -- رقم الموظف
IsActive bit                         -- نشط
)

GO

-- ( ربط حقل رقم مجموعة الصلاحيات بحقل رقم مجموعة الصلاحيات في حقل مجموعات الصلاحيات    )

alter table TblUsersAccounts
add constraint pk_TblUsersAccounts_TblUsersPermissionsGroup_PermissionGroupNo foreign key (PermissionGroupNo) references TblUsersPermissionsGroup(PermissionGroupNo)

-- ( ربط حقل رقم الموظف  بحقل رقم الموظف في جدول الموظفين    )
alter table TblUsersAccounts
add constraint pk_TblUsersAccounts_TblEmployees_EmployeeNo foreign key (EmployeeNo) references TblEmployees(EmployeeNo)

GO

--insert into TblUsersAccounts values ('a','a',1,1,1)
--GO




----*  247  *----------( قيود اليومية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
-- تم وضعها في هذا المكان بسبب العلاقات مع جداول المشتريات والمبيعات ومرتجعات المشتريات ومرتجعات المبيعات

CREATE TABLE TblJournalEntry  -- جدول ارقام قيود اليومية
(
JournalEntryNo int primary key identity(1,1) ,--------رقم قيد اليومية//   رقم القيد المحاسبي الرئيسي في سجل اليومية
EntryDateTime datetime default getdate() ,------------ قيد التاريخ والوقت تم التعديل بتاريخ 2021/9/24
AccountingEntrytStatement varchar(300)----------------------- بيان القيد المحاسبي
)
GO
insert into TblJournalEntry values ('2001/1/1 9:20 PM','مبيعات');  

GO

--select TblSubJournalEntry.SubJornalEntryNo,TblAccounts.AccountNameAR,TblAccounts.AccountNameEN,TblSubJournalEntry.DebitValue,TblSubJournalEntry.CreditValue from TblSubJournalEntry inner join TblAccounts on TblAccounts.AccountNo = TblSubJournalEntry.AccountNo


----*  210  *----------( اجراء مخزن لانشاء حساب محاسبي جديد )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc spAddAccount
@AccountNo int  ,  --------------------------------------------------------- رقم الحساب 
@AccountNameEN varchar(100),------------------------------------------------- اسم الحساب بالانجليزي
@AccountNameAR varchar(100),--------------------------------------------------- اسم الحساب بالعربي
@AccountInformations varchar(250), -------------------------------------- معلومات الحساب
@TopAccountNo int = null  -------------------------------------------------------------- رقم الحساب الاعلى
as
begin
insert into TblAccounts values (@AccountNo,@AccountNameEN,@AccountNameAR,@AccountInformations,@TopAccountNo );
end

GO
--DROP PROC spAddAccount

----*  210  *----------( اجراء مخزن لتعديل حساب قديم )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc spEditAccount
@AccountNo int  ,  --------------------------------------------------------- رقم الحساب 
@AccountNameEN varchar(100),------------------------------------------------- اسم الحساب بالانجليزي
@AccountNameAR varchar(100),--------------------------------------------------- اسم الحساب بالعربي
@AccountInformations varchar(250), -------------------------------------- معلومات الحساب
@TopAccountNo int = null  -------------------------------------------------------------- رقم الحساب الاعلى
as
begin
update TblAccounts set AccountNameEN = @AccountNameEN,AccountNameAR = @AccountNameAR,AccountInformations = @AccountInformations,TopAccountNo = @TopAccountNo  where AccountNo = @AccountNo
end
GO

----*  249  *----------( جدول القيود المحاسبية الفرعية في سجل اليومية  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

CREATE TABLE TblSubJournalEntry  -- جدول الارقام الفرعية لارقام قيود اليومية
(
SubJornalEntryNo int primary key identity,-------- رقم القيد المحاسبي الفرعي في سجل اليومية
JournalEntryNo int  ,-------- رقم القيد المحاسبي الرئيسي في سجل اليومية
AccountNo int  ,------------------------------ رقم الحساب 
DebitValue decimal(8,2),---------------------------- قيمة الحساب المدين
CreditValue decimal(8,2),--------------------------- قيمة الحساب الدائن
AccountingEntrytStatement varchar(300)----------------------- بيان القيد محاسبي
);

-- &&&&&&&&&&&&&&&&&& ربط القيود الفرعية بالقيود الرئيسية
alter table TblSubJournalEntry
add constraint PK_TblSubJournalEntry_TblJournalEntry_JournalEntryNo foreign key (JournalEntryNo) references TblJournalEntry(JournalEntryNo) on delete cascade on update cascade;

-- &&&&&&&&&&&&&&&&&& ربط القيود الفرعية بالحسابات  
alter table TblSubJournalEntry
add constraint PK_TblSubJournalEntry_TblAccounts_AccountNo foreign key (AccountNo) references TblAccounts(AccountNo) on delete cascade on update cascade ;

GO

-->>>>>>>>>>>>>> تسجيل قيود محاسبية جديدة
insert into TblJournalEntry (AccountingEntrytStatement) values ('استثمار مبدئي')-- 1    
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (1,1020010021,0,2500 , 'من حساب الكاشير رقم 1')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (1,1020010022,0,2500 , 'من حساب الكاشير رقم 2')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (1,301001001,3000,0 , 'الى حساب راس مال احمد سالم')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (1,301002001,2000,0 , 'الى حساب راس مال مسفر سالم')

-->>>>>>>>>>>>>>
insert into TblJournalEntry (AccountingEntrytStatement) values (' شراء 10 كراسي')-- 2
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (2,101003,0,1000 , 'من حساب الاثاث')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (2,1020010021,500,0 , ' الى حساب الكاشير رقم 1')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (2,1020010022,500,0 , ' الى حساب الكاشير رقم 2')

-->>>>>>>>>>>>>>
insert into TblJournalEntry (AccountingEntrytStatement) values ('استثمار اضافي')-- 3
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (3,1020010021,0,5000 , ' من حساب الكاشير رقم 1')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (3,1020010022,0,13000 , ' من حساب الكاشير رقم 2')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (3,301001001,4000,0 , 'الى حساب راس مال احمد سالم')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (3,301002001,14000,0 , '  الى حساب راس مال مسفر سالم')


-->>>>>>>>>>>>>>
insert into TblJournalEntry (AccountingEntrytStatement) values ('بيع اثاث')-- 4
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (4,1020010021,0,300 , 'من حساب الكاشير رقم 1')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (4,101003,300,0 , 'الى حساب الاثاث')

-->>>>>>>>>>>>>>
insert into TblJournalEntry (AccountingEntrytStatement) values ('شراء 10 كتب')-- 5
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (5,102005,0,2000 , 'من حساب المخزون')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (5,1020010022,2000,0 , ' الى حساب الكاشير رقم 2')


-->>>>>>>>>>>>>>
insert into TblJournalEntry (AccountingEntrytStatement) values ('اثبات مسحوبات')-- 6
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (6,301001002,0,200 , '  من حساب مسحوبات احمد')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (6,1020010022,200,0 , ' الى الكاشير رقم 2')


-->>>>>>>>>>>>>>
insert into TblJournalEntry (AccountingEntrytStatement) values ('اثبات مصروفات')-- 7
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (7,1020060021,0,2000 , '  من حساب راتب خالد')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (7,1020060022,0,1500 , '  من حساب راتب ايهم')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (7,1020060011,0,1500 , '  من حساب ايجار العمارة رقم 1')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (7,1020010022,5000,0 , 'الى حساب الكاشير رقم 2')


-->>>>>>>>>>>>>>
insert into TblJournalEntry (AccountingEntrytStatement) values ('قسط سيارات على الحساب')-- 8
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (8,101002001,0,3500 , '  من حساب قسط سيارة')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (8,201003001,3500,0 , 'الى حساب الدائنين شركة السعيد')

-->>>>>>>>>>>>>>
insert into TblJournalEntry (AccountingEntrytStatement) values ('استخراج قرض من البنك الراجحي')-- 9
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (9,102001001,0,6000 , '  من حساب النقدية النقدية')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (9,202001001,6000,0 , 'الى حساب بنك الراجحي')


-->>>>>>>>>>>>>>
insert into TblJournalEntry (AccountingEntrytStatement) values ('بيع سلع لمستفيد على الحساب')-- 10
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (10,102002002,0,6000 , '  من حساب المدينين')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (10,201001001,6000,0 , 'الى حساب ايرادات مبيعات')

-->>>>>>>>>>>>>>
insert into TblJournalEntry (AccountingEntrytStatement) values ('قام احمد بسحب 500 ريال')-- 11
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (11,301001002,0,6000 , '  من حساب مسحوبات احمد')
insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (11,1020010022,6000,0 , 'الى حساب الكاشير رقم 2')

GO


----*  253  *----------( جدول الورديات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblShifts -- جدول الورديات
(
ShiftNumber int primary key identity(1,1), -- رقم الوردية
DateAndTimeOfShiftOpening datetime , -- تاريخ ووقت فتح الوردية
ReceivedShiftNumber int , -- رقم الوردية المستلمة
BalanceReceivedFromPreviousShift decimal(8,2) , -- الرصيد المستلم من الوردية السابقة
UserAccountNo int , -- رقم المستخدم
OperationUnitNumber int , -- رقم وحدة العمليات
ShiftStatus int , -- حالة الوردية
DateAndTimeOfShiftClosing datetime , -- تاريخ ووقت إقفال الوردية
ClosingUserAccountNo int , -- رقم الحساب الذي قام بالاقفال
BalanceInRecords decimal(8,2) , --الرصيد القيدي
ActualBalance decimal(8,2) , --الرصيد الفعلي
DifferenceBetweenTwoBalances as (ActualBalance-BalanceInRecords) , --الفرق بين الرصيدين
)
GO
-- ( ربط حقل رقم الوردية المستلمة بحقل رقم الوردية في نفس الجدول  )
alter table TblShifts
add constraint pk_TblShifts_ReceivedShiftNumber_TblShifts_ShiftNumber foreign key (ReceivedShiftNumber) references TblShifts(ShiftNumber)
GO

-- ( ربط حقل رقم المستخدم بالحقل المقابل في جدول حسابات المستخدمين  )
alter table TblShifts
add constraint pk_TblShifts_TblUsersAccounts_UserAccountNo foreign key (UserAccountNo) references TblUsersAccounts(UserAccountNo)
GO
-- ( ربط حقل رقم المستخدم الذي قام بإقفال الحساب بالحقل المقابل في جدول حسابات المستخدمين  )
alter table TblShifts
add constraint pk_TblShifts_ClosingUserAccountNo_TblUsersAccounts_UserAccountNo foreign key (ClosingUserAccountNo) references TblUsersAccounts(UserAccountNo)
GO

-- ( ربط حقل رقم وحدة العمليات بالحقل المقابل في جدول وحدات العمليات  )
alter table TblShifts
add constraint pk_TblShifts_TblOperationUnits_OperationUnitNumber foreign key (OperationUnitNumber) references TblOperationUnits(OperationUnitNumber)
GO



------*  253  *----------( سلال المبيعات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblSaleCarts
(
SalesCartNo int primary key identity(1,1), -- رقم سلة المبيعات
RegistrationDateAndTime datetime , -- تاريخ ووقت التسجيل
TotalSalePrice decimal(8,2) , -- مجموع سعر البيع
TotalDiscount decimal(8,2) , --مجموع الخصم التجاري
TotalSalePriceAfterDiscount decimal(8,2) , -- مجموع سعر البيع بعد الخصم التجاري
TotalOutputTax  decimal(8,2) , -- مجموع ضريبة المخرجات
TotalSellingPriceIncludingTax decimal(8,2) , --  مجموع سعر البيع شاملا الضريبة
ClientsNo int, -- رقم العميل
LinkType int -- نوع الارتباط
)
GO

-- ( ربط حقل رقم العميل بالحقل المقابل في جدول العميلاء  )
alter table TblSaleCarts
add constraint pk_TblSaleCarts_TblClients_ClientsNo foreign key (ClientsNo) references TblClients(ClientsNo)
GO

------*  253  *----------( اجراءات مخزنة لإضافة سلة مبيعات وإعادة رقمها )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc spAddSaleCarts
@RegistrationDateAndTime datetime , -- تاريخ ووقت التسجيل
@TotalSalePrice decimal(8,2) , -- مجموع سعر البيع
@TotalDiscount decimal(8,2) , --مجموع الخصم التجاري
@TotalSalePriceAfterDiscount decimal(8,2) , -- مجموع سعر البيع بعد الخصم التجاري
@TotalOutputTax  decimal(8,2) , -- مجموع ضريبة المخرجات
@TotalSellingPriceIncludingTax decimal(8,2) , --  مجموع سعر البيع شاملا الضريبة
@ClientsNo int, -- رقم العميل
@LinkType int, -- نوع الارتباط
@SalesCartNo int out  -- رقم السلة 

as
begin
insert into TblSaleCarts (RegistrationDateAndTime,TotalSalePrice,TotalDiscount ,TotalSalePriceAfterDiscount ,TotalOutputTax ,TotalSellingPriceIncludingTax,ClientsNo,LinkType ) values (@RegistrationDateAndTime,@TotalSalePrice,@TotalDiscount ,@TotalSalePriceAfterDiscount ,@TotalOutputTax ,@TotalSellingPriceIncludingTax,@ClientsNo,@LinkType ) 
set @SalesCartNo = SCOPE_IDENTITY();
return @SalesCartNo
end
GO

----*  253  *----------( تفاصيل سلة المبيعات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
--drop table TblSalesCartDetails
create table TblSalesCartDetails 
(
SalesCartDetailsNo int primary key identity(1,1), -- رقم تفصيل سلة المبيعات
SalesCartNo int , -- رقم سلة المبيعات
UnitDetailsNo int , -- رقم تفصيل الوحدة
ShortArabicName varchar(50), -- الاسم العربي المختصر
ShortEnglishName varchar(50), -- الاسم الانجليزي المختصر
UnitSalePrice decimal(8,2) , -- سعر بيع الوحدة
Quantity  decimal(8,2) , -- الكمية
FreeQuantity  decimal(8,2) , -- الكمية المجانية
TotalSalePrice  decimal(8,2) , -- مجموع سعر البيع
Discount decimal(8,2) , -- الخصم التجاري
TotalSalePriceAfterDiscount decimal(8,2) , -- مجموع سعر البيع بعد الخصم التجاري
VATrate decimal(8,2), -- نسبة ضريبة القيمة المضافة
OutputTax decimal(8,2) , -- ضريبة المخرجات
TotalSellingPriceIncludingTax decimal(8,2) -- مجموع سعر البيع شاملا الضريبة
)

GO

-- ( ربط حقل رقم سلة المبيعات بالحقل المقابل في جدول سلال المبيعات )
alter table TblSalesCartDetails
add constraint PK_TblSalesCartDetails_TblSaleCarts_SalesCartNo foreign key (SalesCartNo) references TblSaleCarts(SalesCartNo)  ;

GO

-- ( ربط حقل رقم تفصيل الوحدة بالحقل المقابل في جدول تفاصيل السلع والخدمات  )
alter table TblSalesCartDetails
add constraint pk_TblSalesCartDetails_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo)

GO
--alter table TblSalesCartDetails
--add FreeQuantity decimal(8,2)
----*  253  *----------( اجراء مخزن اضافة تفاصيل سلة المبيعات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc SpSalesCartDetails 
@SalesCartNo int , -- رقم سلة المبيعات
@UnitDetailsNo int , -- رقم تفصيل الوحدة
@ShortArabicName varchar(50), -- الاسم العربي المختصر
@ShortEnglishName varchar(50), -- الاسم الانجليزي المختصر
@UnitSalePrice decimal(8,2) , -- سعر بيع الوحدة
@Quantity  decimal(8,2) , -- الكمية
@FreeQuantity  decimal(8,2) , -- الكمية المجانية
@TotalSalePrice  decimal(8,2) , -- مجموع سعر البيع
@Discount decimal(8,2) , -- الخصم التجاري
@TotalSalePriceAfterDiscount decimal(8,2) , -- مجموع سعر البيع بعد الخصم التجاري
@VATrate decimal(8,2), -- نسبة ضريبة القيمة المضافة
@OutputTax decimal(8,2) , -- ضريبة المخرجات
@TotalSellingPriceIncludingTax decimal(8,2), -- مجموع سعر البيع شاملا الضريبة
@SalesCartDetailsNo int out -- رقم تفصيل سلة المبيعات
as 
begin
insert into TblSalesCartDetails (SalesCartNo , UnitDetailsNo ,ShortArabicName, ShortEnglishName, UnitSalePrice ,Quantity ,FreeQuantity , TotalSalePrice ,Discount ,  TotalSalePriceAfterDiscount ,VATrate ,  OutputTax , TotalSellingPriceIncludingTax ) values (@SalesCartNo , @UnitDetailsNo ,@ShortArabicName, @ShortEnglishName, @UnitSalePrice ,@Quantity ,@FreeQuantity,  @TotalSalePrice ,@Discount ,  @TotalSalePriceAfterDiscount ,@VATrate ,  @OutputTax , @TotalSellingPriceIncludingTax )
set @SalesCartDetailsNo = SCOPE_IDENTITY();
return  @SalesCartDetailsNo
end

GO

----*  253  *----------( اجراء مخزن تعديل تفاصيل سلة المبيعات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc SpSalesCartDetailsEdit 
@SalesCartDetailsNo int ,  -- رقم تفصيل سلة المبيعات
@UnitSalePrice decimal(8,2) , -- سعر بيع الوحدة
@Quantity  decimal(8,2) , -- الكمية
@FreeQuantity  decimal(8,2) , -- الكمية المجانية
@TotalSalePrice  decimal(8,2) , -- مجموع سعر البيع
@Discount decimal(8,2) , -- الخصم التجاري
@TotalSalePriceAfterDiscount decimal(8,2) , -- مجموع سعر البيع بعد الخصم التجاري
@VATrate decimal(8,2), -- نسبة ضريبة القيمة المضافة
@OutputTax decimal(8,2) , -- ضريبة المخرجات
@TotalSellingPriceIncludingTax decimal(8,2) -- مجموع سعر البيع شاملا الضريبة
as
begin
update TblSalesCartDetails set UnitSalePrice = @UnitSalePrice ,   Quantity = @Quantity , FreeQuantity = @FreeQuantity , TotalSalePrice = @TotalSalePrice  ,Discount = @Discount ,  TotalSalePriceAfterDiscount = @TotalSalePriceAfterDiscount ,VATrate = @VATrate ,  OutputTax = @OutputTax , TotalSellingPriceIncludingTax = @TotalSellingPriceIncludingTax   where SalesCartDetailsNo = @SalesCartDetailsNo
end

GO
----*  253  *----------( فواتير المبيعات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  


create table TblSalesBill 
(
SalesInvoiceNumber int primary key identity(1,1), -- رقم فاتورة البيع
RegistrationDateAndTime datetime , -- تاريخ ووقت التسجيل
SalesCartNo int , -- رقم سلة المبيعات
JournalEntryNo int , -- رقم قيد اليومية
ShiftNumber int , -- رقم الوردية
TotalBill decimal(8,2), -- اجمالي الفاتورة
DeservedAmount decimal(8,2), -- المبلغ المستحق
RemainingAmount decimal(8,2) -- المبلغ المتبقي -- عند تسليم البضاعة
)

GO

-- (ربط حقل رقم سلة المبيعات بالحقل المقابل في جدول سلال المبيعات) 
alter table TblSalesBill
add constraint PK_TblSalesBill_TblSaleCarts_SalesCartNo foreign key (SalesCartNo) references TblSaleCarts(SalesCartNo)  ;

GO

-- (ربط حقل رقم قيد اليومية بالحقل المقابل في جدول قيود اليومية) 
alter table TblSalesBill
add constraint pk_TblSalesBill_TblJournalEntry_JournalEntryNo foreign key (JournalEntryNo) references TblJournalEntry(JournalEntryNo)

GO

-- (ربط حقل رقم الوردية بالحقل المقابل في جدول الورديات)
alter table TblSalesBill
add constraint pk_TblSalesBill_TblShifts_ShiftNumber foreign key (ShiftNumber) references TblShifts(ShiftNumber)

GO



----*  253  *----------( اجراء مخزن لانشاء فاتورة مبيعات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
--0543202334
create proc SpSalesBill 
@RegistrationDateAndTime datetime , -- تاريخ ووقت التسجيل
@SalesCartNo int , -- رقم سلة المبيعات
@JournalEntryNo int , -- رقم قيد اليومية
@ShiftNumber int , -- رقم الوردية
@TotalBill decimal(8,2), -- اجمالي الفاتورة
@DeservedAmount decimal(8,2), -- المبلغ المستحق
@RemainingAmount decimal(8,2), -- المبلغ المتبقي -- عند تسليم البضاعة
@SalesInvoiceNumber int OUT -- رقم فاتورة البيع
as
begin
  insert into TblSalesBill (RegistrationDateAndTime , SalesCartNo , JournalEntryNo , ShiftNumber , TotalBill , DeservedAmount , RemainingAmount) values ( @RegistrationDateAndTime , @SalesCartNo , @JournalEntryNo , @ShiftNumber , @TotalBill , @DeservedAmount , @RemainingAmount) ;
  set @SalesInvoiceNumber = SCOPE_IDENTITY();
  return @SalesInvoiceNumber ;
end

GO
----*  253  *----------( سندات القبض )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblReceiptVouchers 
(
ReceiptVoucherNo int primary key identity(1,1), -- رقم سند القبض
RegistrationDateAndTime datetime , -- تاريخ ووقت التسجيل
SalesInvoiceNumber int , -- رقم فاتورة البيع
ClientsNo int , -- رقم العميل
cash decimal(8,2) , -- كاش
Bank decimal(8,2) , -- بنك
BankCheck decimal(8,2) , -- شيك بنك
DeferredPayment decimal(8,2) , -- آجل
JournalEntryNo int , -- رقم قيد اليومية
ShiftNumber int -- رقم الوردية
)

GO

-- ( ربط حقل رقم فاتورة البيع بالحقل المقابل في جدول فواتير المبيعات  )
alter table TblReceiptVouchers
add constraint pk_TblReceiptVouchers_TblSalesBill_SalesInvoiceNumber foreign key (SalesInvoiceNumber) references TblSalesBill(SalesInvoiceNumber)
GO

---- ( ربط حقل رقم العميل بالحقل المقابل في جدول العميلاء  )
alter table TblReceiptVouchers
add constraint pk_TblReceiptVouchers_TblClients_ClientsNo foreign key (ClientsNo) references TblClients(ClientsNo)

GO

-- (ربط حقل رقم قيد اليومية بالحقل المقابل في جدول قيود اليومية) 
alter table TblReceiptVouchers
add constraint pk_TblReceiptVouchers_TblJournalEntry_JournalEntryNo foreign key (JournalEntryNo) references TblJournalEntry(JournalEntryNo)

GO

-- (ربط حقل رقم الوردية بالحقل المقابل في جدول الورديات)
alter table TblReceiptVouchers
add constraint pk_TblReceiptVouchers_TblShifts_ShiftNumber foreign key (ShiftNumber) references TblShifts(ShiftNumber)

GO

----*  253  *----------( اجراء مخزن لاضافة سند قبض )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc SpReceiptVouchers 
@RegistrationDateAndTime datetime , -- تاريخ ووقت التسجيل
@SalesInvoiceNumber int , -- رقم فاتورة البيع
@ClientsNo int , -- رقم العميل
@cash decimal(8,2) , -- كاش
@Bank decimal(8,2) , -- بنك
@BankCheck decimal(8,2) , -- شيك بنك
@DeferredPayment decimal(8,2) , -- آجل
@JournalEntryNo int , -- رقم قيد اليومية
@ShiftNumber int -- رقم الوردية
as
begin
insert into TblReceiptVouchers ( RegistrationDateAndTime , SalesInvoiceNumber , ClientsNo , cash , Bank , BankCheck , DeferredPayment , JournalEntryNo , ShiftNumber ) values ( @RegistrationDateAndTime , @SalesInvoiceNumber , @ClientsNo , @cash , @Bank , @BankCheck , @DeferredPayment , @JournalEntryNo , @ShiftNumber )
end

GO
----*  253  *----------( فواتير مرتجعات المبيعات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblSalesReturnsInvoice
(
SalesReturnInvoiceNumber int primary key identity(1,1), -- رقم فاتورة مرتجعات المبيعات
RegistrationDateAndTime datetime , -- تاريخ ووقت التسجيل
SalesInvoiceNumber int,       -- رقم فاتورة البيع
TotalSalePrice decimal(8,2) , -- مجموع سعر البيع
TotalDiscount decimal(8,2) , --مجموع الخصم التجاري
TotalSalePriceAfterDiscount decimal(8,2) , -- مجموع سعر البيع بعد الخصم التجاري
TotalOutputTax  decimal(8,2) , -- مجموع ضريبة المخرجات
TotalSellingPriceIncludingTax decimal(8,2) , --  مجموع سعر البيع شاملا الضريبة
DateAndTimeOfSupply datetime , -- تاريخ ووقت التوريد
JournalEntryNo int, -- رقم قيد اليومية
ClientsNo int, -- رقم العميل
ShiftNumber int -- رقم الوردية
)
GO
-- ( ربط حقل رقم فاتورة البيع بالحقل المقابل في جدول فواتير المبيعات  )
alter table TblSalesReturnsInvoice
add constraint pk_TblSalesReturnsInvoice_TblSalesBill_SalesInvoiceNumber foreign key (SalesInvoiceNumber) references TblSalesBill(SalesInvoiceNumber)
GO

-- ( ربط حقل رقم قيد اليومية بالحقل المقابل في جدول قيود اليومية  )
alter table TblSalesReturnsInvoice
add constraint pk_TblSalesReturnsInvoice_TblJournalEntry_JournalEntryNo foreign key (JournalEntryNo) references TblJournalEntry(JournalEntryNo)
GO

-- ( ربط حقل رقم العميل بالحقل المقابل في جدول العميلاء  )
alter table TblSalesReturnsInvoice
add constraint pk_TblSalesReturnsInvoice_TblClients_ClientsNo foreign key (ClientsNo) references TblClients(ClientsNo)
GO

-- ( ربط حقل رقم الوردية بالحقل المقابل في جدول الورديات  )
alter table TblSalesReturnsInvoice
add constraint pk_TblSalesReturnsInvoice_TblShifts_ShiftNumber foreign key (ShiftNumber) references TblShifts(ShiftNumber)
GO


----*  253  *----------( تفاصيل فواتير مرتجعات المبيعات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblSalesReturnsInvoiceDetails 
(
SubInvoiceNumber int primary key identity(1,1), -- رقم رقم الفاتورة الفرعي
SalesReturnInvoiceNumber int , -- رقم فاتورة مرتجعات المبيعات
UnitDetailsNo int , -- رقم تفصيل الوحدة
UnitSalePrice decimal(8,2) , -- سعر بيع الوحدة
Quantity  decimal(8,2) , -- الكمية
TotalSalePrice  decimal(8,2) , -- مجموع سعر البيع
Discount decimal(8,2) , -- الخصم التجاري
TotalSalePriceAfterDiscount decimal(8,2) , -- مجموع سعر البيع بعد الخصم التجاري
VATrate decimal(8,2), -- نسبة ضريبة القيمة المضافة
OutputTax decimal(8,2) , -- ضريبة المخرجات
TotalSellingPriceIncludingTax decimal(8,2) -- مجموع سعر البيع شاملا الضريبة
)

-- ( ربط حقل رقم فاتورة مرتجعات المبيعات بالحقل المقابل في جدول فواتير مرتجعات المبيعات )
alter table TblSalesReturnsInvoiceDetails
add constraint PK_TblSalesReturnsInvoiceDetails_TblSalesReturnsInvoice_SalesReturnInvoiceNumber foreign key (SalesReturnInvoiceNumber) references TblSalesReturnsInvoice(SalesReturnInvoiceNumber)  ;

GO

-- ( ربط حقل رقم تفصيل الوحدة بالحقل المقابل في جدول تفاصيل السلع والخدمات  )
alter table TblSalesReturnsInvoiceDetails
add constraint pk_TblSalesReturnsInvoiceDetails_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo)

GO
--+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

--+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

----*  253  *----------( فواتير المشتريات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblPurchasesBill
(
PurchaseInvoiceNumber int primary key identity(1,1), -- رقم فاتورة البيع
SupplierInvoiceNumber nvarchar(50) , -- رقم الفاتورة لدى المورد
RegistrationDateAndTime datetime , -- تاريخ ووقت التسجيل
TotalPurchasePrice decimal(8,2) , -- مجموع سعر الشراء
TotalDiscount decimal(8,2) , --مجموع الخصم التجاري
TotalPurchasePriceAfterDiscount decimal(8,2) , -- مجموع سعر الشراء بعد الخصم التجاري
TotalInputTax  decimal(8,2) , -- مجموع ضريبة المدخلات
TotalPurchasePriceIncludingTax decimal(8,2) , --  مجموع سعر الشراء شاملا الضريبة
DateAndTimeOfSupply datetime , -- تاريخ ووقت التوريد
OperationUnitNumber int ,-- رقم وحدة العمليات
JournalEntryNo int, -- رقم قيد اليومية
ClientsNo int, -- رقم العميل
UserAccountNo int -- رقم المستخدم
)
GO
-- ( ربط حقل اسم المستخدم الحقل المقابل في جدول حسابات المستخدمين  )
alter table TblPurchasesBill
add constraint pk_TblPurchasesBill_TblUsersAccounts_UserAccountNo foreign key (UserAccountNo) references TblUsersAccounts(UserAccountNo)
GO
-- ( ربط حقل رقم العميل بالحقل المقابل في جدول العميلاء  )
alter table TblPurchasesBill
add constraint pk_TblPurchasesBill_TblClients_ClientsNo foreign key (ClientsNo) references TblClients(ClientsNo)
GO
-- ( ربط حقل رقم قيد اليومية بالحقل المقابل في جدول قيود اليومية  )
alter table TblPurchasesBill
add constraint pk_TblPurchasesBill_TblJournalEntry_JournalEntryNo foreign key (JournalEntryNo) references TblJournalEntry(JournalEntryNo)
GO
-- ( رقط حقل رقم وحدة العمليات بالحقل المقابل في جدول وحدات العمليات  )
alter table TblPurchasesBill
add constraint pk_TblPurchasesBill_TblOperationUnits_OperationUnitNumber foreign key (OperationUnitNumber) references TblOperationUnits(OperationUnitNumber)
GO



----*  253  *----------( تفاصيل فواتير المشتريات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblPurchaseInvoiceDetails 
(
SubInvoiceNumber int primary key identity(1,1), -- رقم رقم الفاتورة الفرعي
PurchaseInvoiceNumber int , -- رقم فاتورة الشراء
UnitDetailsNo int , -- رقم تفصيل الوحدة
UnitPurchasePrice decimal(8,2) , -- سعر شراء الوحدة
Quantity  decimal(8,2) , -- الكمية
TotalPurchasePrice  decimal(8,2) , -- مجموع سعر الشراء
Discount decimal(8,2) , -- الخصم التجاري
TotalPurchasePriceAfterDiscount decimal(8,2) , -- مجموع سعر الشراء بعد الخصم التجاري
VATrate decimal(8,2), -- نسبة ضريبة القيمة المضافة
InputTax decimal(8,2) , -- ضريبة المدخلات
TotalPurchasePriceIncludingTax decimal(8,2) -- مجموع سعر الشراء شاملا الضريبة
)

-- ( ربط حقل رقم فاتورة الشراء بالحقل المقابل في جدول فواتير المشتريات )
alter table TblPurchaseInvoiceDetails
add constraint PK_TblPurchaseInvoiceDetails_TblPurchasesBill_PurchaseInvoiceNumber foreign key (PurchaseInvoiceNumber) references TblPurchasesBill(PurchaseInvoiceNumber)  ;

GO

-- ( ربط حقل رقم تفصيل الوحدة بالحقل المقابل في جدول تفاصيل السلع والخدمات  )
alter table TblPurchaseInvoiceDetails
add constraint pk_TblPurchaseInvoiceDetails_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo)

GO


----*  253  *----------( فاتورة مرتجعات مشتريات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblPurchaseReturnsInvoice
(
PurchaseReturnsInvoiceNumber int primary key identity(1,1), -- رقم فاتورة مرتجعات المشتريات
SupplierInvoiceNumber nvarchar(50) , -- رقم الفاتورة لدى المورد
RegistrationDateAndTime datetime , -- تاريخ ووقت التسجيل
PurchaseInvoiceNumber int , -- رقم فاتورة الشراء
TotalPurchasePrice decimal(8,2) , -- مجموع سعر الشراء
TotalDiscount decimal(8,2) , --مجموع الخصم التجاري
TotalPurchasePriceAfterDiscount decimal(8,2) , -- مجموع سعر الشراء بعد الخصم التجاري
TotalInputTax  decimal(8,2) , -- مجموع ضريبة المدخلات
TotalPurchasePriceIncludingTax decimal(8,2) , --  مجموع سعر الشراء شاملا الضريبة
DateAndTimeOfReturn datetime , -- تاريخ ووقت الارجاع
OperationUnitNumber int ,-- رقم وحدة العمليات
JournalEntryNo int, -- رقم قيد اليومية
ClientsNo int, -- رقم العميل
UserAccountNo int -- رقم المستخدم
)
GO
-- ( ربط حقل رقم فاتورة الشراء بالحقل المقابل في جدول فواتير المشتريات  )
alter table TblPurchaseReturnsInvoice
add constraint pk_TblPurchaseReturnsInvoice_TblPurchasesBill_PurchaseInvoiceNumber foreign key (PurchaseInvoiceNumber) references TblPurchasesBill(PurchaseInvoiceNumber)
GO
-- ( ربط حقل اسم المستخدم الحقل المقابل في جدول حسابات المستخدمين  )
alter table TblPurchaseReturnsInvoice
add constraint pk_TblPurchaseReturnsInvoice_TblUsersAccounts_UserAccountNo foreign key (UserAccountNo) references TblUsersAccounts(UserAccountNo)
GO
-- ( ربط حقل رقم العميل بالحقل المقابل في جدول العميلاء  )
alter table TblPurchaseReturnsInvoice
add constraint pk_TblPurchaseReturnsInvoice_TblClients_ClientsNo foreign key (ClientsNo) references TblClients(ClientsNo)
GO
-- ( ربط حقل رقم قيد اليومية بالحقل المقابل في جدول قيود اليومية  )
alter table TblPurchaseReturnsInvoice
add constraint pk_TblPurchaseReturnsInvoice_TblJournalEntry_JournalEntryNo foreign key (JournalEntryNo) references TblJournalEntry(JournalEntryNo)
GO
-- ( رقط حقل رقم وحدة العمليات بالحقل المقابل في جدول وحدات العمليات  )
alter table TblPurchaseReturnsInvoice
add constraint pk_TblPurchaseReturnsInvoice_TblOperationUnits_OperationUnitNumber foreign key (OperationUnitNumber) references TblOperationUnits(OperationUnitNumber)
GO


----*  253  *----------( تفاصيل فواتير مرتجعات المشتريات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblPurchaseReturnsInvoiceDetails 
(
SubInvoiceNumber int primary key identity(1,1), -- رقم رقم الفاتورة الفرعي
PurchaseReturnsInvoiceNumber int , -- رقم فاتورة مرتجعات المشتريات
UnitDetailsNo int , -- رقم تفصيل الوحدة
UnitPurchasePrice decimal(8,2) , -- سعر شراء الوحدة
Quantity  decimal(8,2) , -- الكمية
TotalPurchasePrice  decimal(8,2) , -- مجموع سعر الشراء
Discount decimal(8,2) , -- الخصم التجاري
TotalPurchasePriceAfterDiscount decimal(8,2) , -- مجموع سعر الشراء بعد الخصم التجاري
VATrate decimal(8,2), -- نسبة ضريبة القيمة المضافة
InputTax decimal(8,2) , -- ضريبة المدخلات
TotalPurchasePriceIncludingTax decimal(8,2) -- مجموع سعر الشراء شاملا الضريبة
)

-- ( ربط حقل رقم فاتورة مرتجعات المشتريات بالحقل المقابل في جدول فواتير مرتجعات المشتريات )
alter table TblPurchaseReturnsInvoiceDetails
add constraint PK_TblPurchaseReturnsInvoiceDetails_TblPurchaseReturnsInvoice_PurchaseInvoiceNumber foreign key (PurchaseReturnsInvoiceNumber) references TblPurchaseReturnsInvoice(PurchaseReturnsInvoiceNumber)  ;

GO

-- ( ربط حقل رقم تفصيل الوحدة بالحقل المقابل في جدول تفاصيل السلع والخدمات  )
alter table TblPurchaseReturnsInvoiceDetails
add constraint pk_TblPurchaseReturnsInvoiceDetails_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo)

GO





----*  253  *----------( عمليات الاهلاك )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblDepreciationOperations
(
DepreciationOperationsNo int primary key identity(1,1), -- رقم عملية الاهلاك
DateAndTime datetime ,          -- التاريخ والوقت
TotalPurchaseCost decimal(8,2) , -- مجموع تكلفة الشراء
OperationUnitNumber int ,-- رقم وحدة العمليات
JournalEntryNo int, -- رقم قيد اليومية
UserAccountNo int -- رقم المستخدم
)
GO
-- ( ربط حقل اسم المستخدم الحقل المقابل في جدول حسابات المستخدمين  )
alter table TblDepreciationOperations
add constraint pk_TblDepreciationOperations_TblUsersAccounts_UserAccountNo foreign key (UserAccountNo) references TblUsersAccounts(UserAccountNo)
GO
-- ( ربط حقل رقم قيد اليومية بالحقل المقابل في جدول قيود اليومية  )
alter table TblDepreciationOperations
add constraint pk_TblDepreciationOperations_TblJournalEntry_JournalEntryNo foreign key (JournalEntryNo) references TblJournalEntry(JournalEntryNo)
GO
-- ( رقط حقل رقم وحدة العمليات بالحقل المقابل في جدول وحدات العمليات  )
alter table TblDepreciationOperations
add constraint pk_TblDepreciationOperations_TblOperationUnits_OperationUnitNumber foreign key (OperationUnitNumber) references TblOperationUnits(OperationUnitNumber)
GO

----*  253  *----------( تفاصيل عملية الاهلاك )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblDepreciationOperationDetails 
(
SubNumber int primary key identity(1,1), -- الرقم الفرعي
DepreciationOperationsNo int , -- رقم عملية الاهلاك
UnitDetailsNo int , -- رقم تفصيل الوحدة
UnitPurchasePrice decimal(8,2) , -- سعر شراء الوحدة
Quantity  decimal(8,2),  -- الكمية
TotalPurchaseCost  decimal(8,2) , -- مجموع تكلفة الشراء
)

-- ( ربط حقل رقم عملية الاهلاك بالحقل المقابل في جدول عمليات الاهلاك )
alter table TblDepreciationOperationDetails
add constraint PK_TblDepreciationOperationDetails_TblDepreciationOperations_DepreciationOperationsNo foreign key (DepreciationOperationsNo) references TblDepreciationOperations(DepreciationOperationsNo)  ;

GO

-- ( ربط حقل رقم تفصيل الوحدة بالحقل المقابل في جدول تفاصيل السلع والخدمات  )
alter table TblDepreciationOperationDetails
add constraint pk_TblDepreciationOperationDetails_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo)

GO


--+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


----*  301  *----------( عرض  حسابات الاصول والخصوم وحقوق الملكية بجميع تفرعاتها )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

-- Statement of financial position = SOFP 
create view SOFPAccountsView 
as 
select * from 
( select A.AccountNo as a1 , A.AccountNameEN as a2 , A.AccountNameAR as a3 , A.AccountInformations as a4 , A.TopAccountNo as a5   ,   B.AccountNo as b1 , B.AccountNameEN as b2 , B.AccountNameAR as b3 , B.AccountInformations as b4 , B.TopAccountNo as b5   ,   C.AccountNo as c1 , C.AccountNameEN as c2 , C.AccountNameAR as c3 , C.AccountInformations as c4 , C.TopAccountNo as c5   ,   D.AccountNo as d1 , D.AccountNameEN as d2 , D.AccountNameAR as d3 , D.AccountInformations as d4 , D.TopAccountNo as d5   ,   E.AccountNo as e1 , E.AccountNameEN as e2 , E.AccountNameAR as e3 , E.AccountInformations as e4 , E.TopAccountNo as e5   ,   F.AccountNo as f1 , F.AccountNameEN as f2 , F.AccountNameAR as f3 , F.AccountInformations as f4 , F.TopAccountNo as f5
from TblAccounts A
left outer join TblAccounts B  on A.AccountNo = B.TopAccountNo
left outer join TblAccounts c on B.AccountNo =  C.TopAccountNo
left outer join TblAccounts D on C.AccountNo =  D.TopAccountNo
left outer join TblAccounts E on D.AccountNo =  E.TopAccountNo
left outer join TblAccounts F on E.AccountNo =  F.TopAccountNo
) AS level001 
where a3 in ('اصول','خصوم','حقوق الملكية');

GO
--select * from SOFPAccountsView

----*  302  *----------( انشاء استعلام يمثل سجل اليومية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create view jornalShow
as 
select TblJournalEntry.JournalEntryNo  ,  TblJournalEntry.EntryDateTime  ,  TblJournalEntry.AccountingEntrytStatement as AccountingEntrytStatementMain ,
TblSubJournalEntry.SubJornalEntryNo  ,  TblSubJournalEntry.AccountNo  ,
TblAccounts.AccountNameAR  , TblSubJournalEntry.CreditValue  ,  TblSubJournalEntry.DebitValue , TblSubJournalEntry.AccountingEntrytStatement as AccountingEntrytStatementSub

from TblJournalEntry 
inner join TblSubJournalEntry on TblJournalEntry.JournalEntryNo = TblSubJournalEntry.JournalEntryNo
inner join TblAccounts on  TblAccounts.AccountNo = TblSubJournalEntry.AccountNo ;

--select * from jornalShow
GO

----*  303  *----------(  انشاء استعلام ميزان المراجعة المستخدم كاساس للقوائم الاخرى وليس للعرض )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
  
--  ميزان المراجعة المبدئي

create view InitialTrialBalance 
as 
select   level002.AccountNo,level002.AccountNameAR,level002.Finalcredit,level002.FinalDebit from 
(select level001.AccountNo,level001.AccountNameAR,credit_sum,debit_sum,Finalcredit=iif(credit_sum-debit_sum>=0,credit_sum-debit_sum,0) ,FinalDebit=iif(debit_sum-credit_sum>=0,debit_sum-credit_sum,0) from 
(select TblAccounts.AccountNo,TblAccounts.AccountNameAR,
sum(TblSubJournalEntry.CreditValue) as credit_sum , sum(TblSubJournalEntry.DebitValue) as debit_sum

from TblJournalEntry 
inner join TblSubJournalEntry on TblJournalEntry.JournalEntryNo = TblSubJournalEntry.JournalEntryNo
inner join TblAccounts on  TblAccounts.AccountNo = TblSubJournalEntry.AccountNo

group by TblAccounts.AccountNo,TblAccounts.AccountNameAR ) as level001 )  as level002;


--select * from InitialTrialBalance
----*  304 - 305 - 306 - 307 - 308 - 309  *----------( تجميع قيم الحسابات حسب التصنيفات  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

--الاصول والخصوم وحقوق الملكية
GO

--a

create view AView 
as
select a1,a2,a3,a4,a5,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit  
from
(
select a1,a2,a3,a4,a5,sum(Finalcredit) as credit,sum(FinalDebit) as Debit  
from  SOFPAccountsView
inner join InitialTrialBalance  on InitialTrialBalance.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5
)as level001

GO

--b

create view BView 
as
select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit 
from
(select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,sum(Finalcredit) as credit,sum(FinalDebit) as Debit  
from  SOFPAccountsView
inner join InitialTrialBalance  on InitialTrialBalance.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5,b1,b2,b3,b4,b5)as level001

GO

--c

create view CView 
as
 select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit 
 from
 (select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,sum(Finalcredit) as credit,sum(FinalDebit) as Debit 
from  SOFPAccountsView
inner join InitialTrialBalance  on InitialTrialBalance.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5) as level001

GO

--d

create view DView 
as
select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit 
from
(select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,sum(Finalcredit) as credit,sum(FinalDebit) as Debit 
from  SOFPAccountsView
inner join InitialTrialBalance  on InitialTrialBalance.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5) as level001

GO

--e

create view EView 
as
select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit 
from
(select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5,sum(Finalcredit) as credit,sum(FinalDebit) as Debit 
from  SOFPAccountsView
inner join InitialTrialBalance  on InitialTrialBalance.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5) as level001

GO

--f

create view FView 
as
select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5,f1,f2,f3,f4,f5 ,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit 
from
(select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5,f1,f2,f3,f4,f5,sum(Finalcredit) as credit,sum(FinalDebit) as Debit 
from  SOFPAccountsView
inner join InitialTrialBalance  on InitialTrialBalance.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5,f1,f2,f3,f4,f5) as level001
GO

----*  310  *----------( انشاء استعلام لعرض ميزان المراجعة  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create view TrialBalanceView
as 
select CView.a1  ,  CView.a2  ,  CView.a3  ,  CView.b2  ,  CView.b3  ,  CView.c1  ,  CView.c2  ,  CView.c3  ,  CView.credit  ,  CView.Debit from CView
union 
select 4 as a1  ,  'total' as a2  ,  'المجموع' as a3  ,  null as b2  ,  null as b3  ,  null as c1  ,  null as c2  ,  null as c3  , sum(CView.credit)  ,  sum(CView.Debit) from CView ;
GO

----*  311  *----------( ميزان مراجعة مفصل لغرض عرض قائمة التغيرات في حقوق الملكية   )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
  
 create view TrialBalanceDetailed
as 
select DView.a1  , DView.a2  ,  DView.a3  ,  DView.b2  ,  DView.b3  ,  DView.c1  ,  DView.c2  ,  DView.c3               ,DView.d1,DView.d2,DView.d3 ,  DView.credit  ,  DView.Debit from DView
union 
select 4 as a1  ,  'total' as a2  ,  'المجموع' as a3  ,  null as b2  ,  null as b3  ,  null as c1  ,  null as c2  ,  null as c3 , null as d1,null as d2,null as d3 , sum(CView.credit)  ,  sum(CView.Debit) from CView ;
GO

----*  312  *----------( انشاء استعلام لعرض قائمة الدخل  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create view IncomeList
as
select  DView.a1  ,  DView.c2  ,  DView.c3 ,  DView.d1  ,  DView.d2  ,  DView.d3  ,  DView.credit  ,  DView.Debit  from DView where DView.c3 in ('ايرادات','مصروفات')
union
select  4 as a1,'englesh' as c2,'صافي الربح او الخسارة' as c3,null as d1 ,'englesh' as d2, 'الفرق بين الايرادات والمصروفات' as d3  ,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as debit 
from
(select  4 as a1,'englesh' as c2,'صافي الربح او الخسارة' as c3,null as d1 ,'englesh' as d2, 'الفرق بين الايرادات والمصروفات' as d3  ,sum(DView.credit) as credit,sum(DView.Debit) as debit from DView where DView.c3 in ('ايرادات','مصروفات') )as xx
GO

----*  313  *----------( انشاء استعلام لعرض قائمة التغيرات في حقوق الملكية  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create view OwnersEquityList as 

select 1 as a1,d2,d3,sum(credit)as credit ,sum(debit) as debit from TrialBalanceDetailed where TrialBalanceDetailed.a3 = 'حقوق الملكية' and TrialBalanceDetailed.b3='راس المال'   group by a1,d2,d3 

union all

select 2 as a1, 'total','مجموع رؤوس الاموال ومجموع المسحوبات', sum(credit)as credit ,sum(debit) as debit from TrialBalanceDetailed where TrialBalanceDetailed.a3 = 'حقوق الملكية' and TrialBalanceDetailed.b3='راس المال'   group by a1

union all

select 3 as a1, 'total','رصيد راوس الاموال بعد خصم المسحوبات',iif( sum(credit)-sum(debit) >=0 ,sum(credit)-sum(debit),0)as credit ,iif( sum(debit)-sum(credit) >=0 ,sum(debit)-sum(credit),0) as debit from TrialBalanceDetailed where TrialBalanceDetailed.a3 = 'حقوق الملكية' and TrialBalanceDetailed.b3='راس المال'   group by a1

union all

select a1 as a1,c3,d3 as b3,Credit,Debit from IncomeList WHERE a1 =4

union all 

select 5 as a1,'رصيد راس المال اخر المدة','رصيد راس المال اخر المدة',iif ( sum(credit)- sum(debit) >=0 , sum(credit)- sum(debit) , 0)as credit,iif ( sum(debit)- sum(credit) >=0 , sum(debit)- sum(credit) , 0) as debit from 
(
select 3 as a1, 'total' as c3,'رصيد راوس الاموال بعد خصم المسحوبات' as d3,iif( sum(credit)-sum(debit) >=0 ,sum(credit)-sum(debit),0)as credit ,iif( sum(debit)-sum(credit) >=0 ,sum(debit)-sum(credit),0) as debit from TrialBalanceDetailed where TrialBalanceDetailed.a3 = 'حقوق الملكية' and TrialBalanceDetailed.b3='راس المال'   group by a1

union all

select a1 as a1,c3,d3 ,Credit,Debit from IncomeList WHERE a1 =4

)as level001
GO

----*  314  *----------( انشاء استعلام لعرض قائمة المركز المالي )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create view  StatementOfFinancialPosition
as
 select a1,a2,a3,b2,b3,c2,c3,credit,debit from TrialBalanceView where c3 <> 'ايرادات' and c3 <> 'مصروفات' and a1 <>3 and a1<=2

 union 

 select 3 as a1,'--'as a2,'حقوق الملكية' as a3,'--'as b2,'حقوق الملكية'as b3,'--' as c2,'حقوق الملكية' as c3,credit ,debit  from OwnersEquityList where a1=5

 union

 select 4 as a1,'--' as a2,'مجموع الجانبين' as a3,'--' as b3,'مجموع الجانبين' as b2,'--' as c2,'مجموع الجانبين' as c3,sum(level001.credit),sum(level001.Debit) from
(
  select a1    ,  a2   ,     a3  ,    b2   ,  b3   ,    c2   ,   c3,  credit,  debit from TrialBalanceView where c3 <> 'ايرادات' and c3 <> 'مصروفات' and a1 <>3 
 union 
  select 3 as a1,''as a2,'' as a3,'' as b2,'' as b3,d2 as c2,d3 as c3 ,credit ,debit from OwnersEquityList OwnersEquityList where a1=5 
 )as level001
  GO

 --select * from StatementOfFinancialPosition
 
 ----*  315  *----------( استعلام دفتر الاستاذ )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

declare @AccountNo int , @AccountNameEN VARCHAR(100)  , @AccountNameAR VARCHAR(100)
set @AccountNo = 301001
select @AccountNameAR = AccountNameAR,@AccountNameEN = AccountNameEN from TblAccounts where AccountNo = @AccountNo

select 1 as a1  , JournalEntryNo,EntryDateTime,  @AccountNo as AccountNo  ,  @AccountNameAR as AccountNameAR  ,  @AccountNameEN as AccountNameEN  ,  AccountingEntrytStatementSub  as AccountingEntrytStatement,  CreditValue  as Credit  ,  DebitValue  as Debit 
from SOFPAccountsView
inner join jornalShow  on jornalShow.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
where @AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1) 

union 

select 2 as a1  ,'' as JournalEntryNo,'' as EntryDateTime,  @AccountNo as AccountNo  ,  @AccountNameAR as AccountNameAR  ,  @AccountNameEN as AccountNameEN ,  'مجموع الطرفين'  as AccountingEntrytStatement,  sum(level001.Credit) as Credit  ,  sum(level001.Debit) as Debit from
(
select 1 as a1  ,jornalShow.JournalEntryNo,jornalShow.EntryDateTime,  @AccountNo as AccountNo  ,  @AccountNameAR as AccountNameAR  ,  @AccountNameEN as AccountNameEN  ,  AccountingEntrytStatementSub  as AccountingEntrytStatement,  CreditValue  as Credit  ,  DebitValue  as Debit 
from SOFPAccountsView
inner join jornalShow  on jornalShow.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
where @AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
)as level001
group by a1

union 

select 3 as a1  ,'' as JournalEntryNo,'' as EntryDateTime,  @AccountNo as AccountNo  ,  @AccountNameAR as AccountNameAR  ,  @AccountNameEN as AccountNameEN ,  'رصيدالحساب'  as AccountingEntrytStatement, iif( sum(Credit) -sum(Debit) >=0 , sum(Credit) -sum(Debit),0 )  as Credit  ,iif( sum(Debit) -sum(Credit) >=0,sum(Debit) -sum(Credit),0 ) as Debit 
from(select 2 as a1  ,'' as JournalEntryNo,'' as EntryDateTime,  @AccountNo as AccountNo  ,  @AccountNameAR as AccountNameAR  ,  @AccountNameEN as AccountNameEN ,  'المجموع'  as AccountingEntrytStatement,  sum(level001.Credit) as Credit  ,  sum(level001.Debit) as Debit 
from(select 1 as a1  ,jornalShow.JournalEntryNo,jornalShow.EntryDateTime,  @AccountNo as AccountNo  ,  @AccountNameAR as AccountNameAR  ,  @AccountNameEN as AccountNameEN  ,  AccountingEntrytStatementSub  as AccountingEntrytStatement,  CreditValue  as Credit  ,  DebitValue  as Debit 
from SOFPAccountsView
inner join jornalShow  on jornalShow.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
where @AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
)as level001
group by a1
)level002
order by a1,JournalEntryNo
GO




-- بيانات الحساب والموظف والجنسية
--select * from UsersAccounts241 
--inner join Employees on UsersAccounts241.EmployeeNo = Employees.EmployeeNo
--inner join Countries on Employees.Nationality = Countries.CountryNo

