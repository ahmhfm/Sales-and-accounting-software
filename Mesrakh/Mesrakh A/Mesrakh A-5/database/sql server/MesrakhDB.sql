--select * from TblEncapsulationUnits 

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
PriceCalculationMethod varchar(30)   -- اسلوب احتساب السعر
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



--alter table TblMeasureAndEncapsulationUnits drop constraint PK_TblMeasureAndEncapsulationUnits_TblProducts_ProductNumber 
GO
--drop proc spAddProductAndServicesDetails

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
@PriceCalculationMethod varchar(30),   -- اسلوب احتساب السعر
@UnitDetailsNo int out -- رقم تفاصيل الوحدة
as
begin
insert into TblproductAndServicesDetails values (@productOrServiceNumber , @EncapsulationUnitsNo ,@MeasureUnitValue ,@MeasureUnitNo ,@UnitDetailsValue ,@UnitDetailsNoSelfJoin ,@ManufacturerNo , @ModelOrProductArabicDescription , @ModelEnglishOrProductEnglishDescription,  @DetailedNameForProductOrServiceAr ,@DetailedNameForProductOrServiceEn ,@PriceCalculationMethod );
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
EnterpriseIcon varchar(max),              -- شعار المنشأة
EnterpriseDetails varchar(200)     -- تفاصيل
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
TheAddress varchar(200) ,       --  العنوان
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
@TheAddress varchar(200) ,       --  العنوان
@BranchDetail varchar(500) ,         -- تفاصيل
@ConnectingMethodsOfCommunicationNO int , -- رقم ربط طرق الاتصال
@BranchNumber int out     -- رقم الفرع
as
begin
insert into TblEnterpriseBranches (EnterpriseNo,BranchTypeNo,BranchNameAR,BranchNameEN,TheAddress ,BranchDetail,ConnectingMethodsOfCommunicationNO) values (@EnterpriseNo,@BranchTypeNo,@BranchNameAR,@BranchNameEN,@TheAddress ,@BranchDetail,@ConnectingMethodsOfCommunicationNO)
set @BranchNumber  = SCOPE_IDENTITY();
return @BranchNumber 
end
GO


----*  246  *----------( وحدات العمليات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblOperationUnits
(
OperationUnitNumber int primary key identity(1,1),  -- رقم وحدة العمليات
BranchNumber int,                   -- رقم الفرع
UnitNoInBranch varchar(50)          -- رقم الوحدة في الفرع
)

GO

-- ( ربط حقل رقم الفرع  بحقل رقم الفرع في جدول فروع المنشآت     )

alter table TblOperationUnits
add constraint pk_TblOperationUnits_TblEnterpriseBranches_BranchNumber foreign key (BranchNumber) references TblEnterpriseBranches(BranchNumber)

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

----*  229  *----------( الدول )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table TblCountries 
(
CountrNo int primary key identity(1,1),      -- رقم الدولة
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

----*  229  *----------( الموظفين )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblEmployees
(
EmployeeNo int primary key identity(1,1),      -- رقم الموظف
EmployeeNameAR varchar(50),   -- اسم الموظف عربي
EmployeeNameEN varchar(50),   -- اسم الموظف انجليزي
Gendar varchar(5),            -- الجنس
CountrNo int,      -- الجنسية
ConnectingMethodsOfCommunicationNO int -- رقم تحزيم طرق الاتصال
)

GO
-- ( ربط حقل رقم او تحزيم طرق الاتصال بجدول تحزيم طرق الاتصال   )
alter table TblEmployees
add constraint PK_TblEmployees_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO foreign key (ConnectingMethodsOfCommunicationNO) references TblConnectingMethodsOfCommunication(ConnectingMethodsOfCommunicationNO)  ;

GO
-- ( ربط قل الجنسية بجدول الدول   )
alter table TblEmployees
add constraint PK_TblEmployees_TblCountries_CountrNo foreign key (CountrNo) references TblCountries(CountrNo)  ;

GO

--insert into TblEmployees values ('الموظف احمد 001','ahmed 001','male',1,'image00654',1);
--insert into TblEmployees values ('الموظف علي 002','ali 002','male',1,'image00655555',1);
--GO


 ----*   227   *----------( العملاء )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblClients
(
ClientsNo int primary key identity(1,1),         -- رقم العميل
ClientNameAR varchar(100),           -- اسم العميل عربي
ClientNameEN varchar(100),           -- اسم العميل انجليزي
ClientsTypesNo varchar(100),                  -- نوع العميل
TaxNo varchar(50),                   -- الرقم الضريبي
OtherDetails varchar(200),           -- تفاصيل اخرى
InterestOnCapital decimal(5,2),      -- الفائدة على رأس المال
PartnersShareOfProfits decimal(5,2),  -- نسبة الشريك من الارباح
ConnectingMethodsOfCommunicationNO int  -- رقم ربط او تحزيم طرق الاتصال
)


GO
-- ( ربط حقل رقم او تحزيم طرق الاتصال بجدول تحزيم طرق الاتصال   )
alter table TblClients
add constraint PK_TblClients_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO foreign key (ConnectingMethodsOfCommunicationNO) references TblConnectingMethodsOfCommunication(ConnectingMethodsOfCommunicationNO)  ;

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



----*  212  *----------( التشغيلة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblBatch
(
BatchNo int primary key identity(1,1),           -- رقم التشغيلة
OfficialNumberForBatch varchar(30),  -- الرقم الرسمي للتشغيلة
LotNo varchar(30) ,                  -- رقم الشحنة
ProductionDate datetime ,    -- تاريخ الانتاج
ExpiryDate datetime ,        -- تاريخ الانتهاء
WarningDuration int ,        -- مدة التحذير
ExchangeStopDate datetime,   -- تاريخ ايقاف الصرف
Notes varchar(200)           -- ملاحظات
)

GO


--insert into TblBatch values ('batch444','lot444',3,'2021/5/6','2022/5/6',5,2,'لا توجد ملاحظات على هذه التشغيلة');
--insert into TblBatch values ('batch555','lot555',3,'2021/8/8','2022/8/8',5,2,'لا توجد ملاحظات على هذه التشغيلة');
--GO

----*  261  *--------- ( المخزون )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create table TblStock
(
UnitDetailsNo int identity(1,1),  -- رقم تفاصيل الوحدة
ShelfGeneralNo int ,       -- الرقم العام للرف
BatchNo int,               -- رقم التشغيلة
Quantity decimal(9,2),     -- كمية المخزون
StockValue decimal(9,2),    -- قيمة المخزون
primary key (UnitDetailsNo,ShelfGeneralNo,BatchNo)
)

GO

-- ( ربط حقل رقم وحدة القياس والتغليف  بحقل رقم وحدة القياس والتغليف في جدول وحدات القياس والتغليف )
alter table TblStock
add constraint pk_TblStock_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo)

GO

-- (ربط حقل من الرف رقم بحقل الرقم العام للرف في جدول الارفف)
alter table TblStock
add constraint pk_TblStock_TblShelves_ShelfGeneralNo foreign key (ShelfGeneralNo) references TblShelves(ShelfGeneralNo)

GO

-- ( ربط حقل رقم التشغيلة  بحقل رقم التشغيلة في جدول التشغيلات )

alter table TblStock
add constraint pk_TblStock_TblBatch_BatchNo foreign key (BatchNo) references TblBatch(BatchNo)

GO

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
JournalEntryNo int primary key identity(1,1) ,-------- رقم القيد المحاسبي الرئيسي في سجل اليومية
EntryDateTime datetime default getdate() ,------------ قيد التاريخ والوقت تم التعديل بتاريخ 2021/9/24
AccountingEntrytStatement varchar(300)----------------------- بيان القيد المحاسبي
)
GO
insert into TblJournalEntry values ('2001/1/1 9:20 PM','مبيعات');  

GO


----*  248  *----------( الحسابات المحاسبية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
--update TblAccounts set AccountNameEN = 'aa' , AccountNameAR =  'aa' , AccountInformations = 'aa' , TopAccountNo = null,ClientsNo = null  where AccountNo = 4

create table TblAccounts --  انشاء جدول الحسابات 
(
AccountNo int primary key ,--------------------------------------------------------- رقم الحساب  
AccountNameEN varchar(100),------------------------------------------------- اسم الحساب بالانجليزي
AccountNameAR varchar(100),--------------------------------------------------- اسم الحساب بالعربي
AccountInformations varchar(250), -------------------------------------- معلومات الحساب
TopAccountNo int default null, -------------------------------------------------------------- رقم الحساب الاعلى
ClientsNo  int default null-------------------------------------------------------------------- رقم العميل
);


-- &&&&&&&&&&&&&&&&&& ربط حقل رقم الحساب الاعلى بحقل رقم الحساب    
alter table TblAccounts
add constraint PK_TblAccounts_TopAccountNo_self foreign key (TopAccountNo) references TblAccounts(AccountNo)  ;

-- &&&&&&&&&&&&&&&&&& ربط حقل رقم العميل بحقل رقم العميل في جدول العملاء    
alter table TblAccounts
add constraint PK_TblAccounts_TblClients_ClientsNo foreign key (ClientsNo) references TblClients(ClientsNo)  ;

GO
---->>>>>>>>>>>>>> تسجيل بيانات حسابات جديدة
--*1
insert into TblAccounts values (1,'account1','اصول','لا توجد ملاحظات 1',null,null);-- لا تحذف لانها تحوي الحسابات الرئيسية التي تعتمد عليها الاستعلامات القادمة
   --**01
   insert into TblAccounts values (101,'account4','اصول ثابته ','لا توجد ملاحظات 4',1,null);
       --***001
       insert into TblAccounts values (101001,'account7','مباني','لا توجد ملاحظات 7',101,null);
       insert into TblAccounts values (101001001,'account7','مبنى المحجر','لا توجد ملاحظات 7',101001,null);
       insert into TblAccounts values (101001002,'account7','مبنى الصفى','لا توجد ملاحظات 7',101001,null);
       insert into TblAccounts values (101001003,'account7','مبنى الروضه','لا توجد ملاحظات 7',101001,null);
       --***002
       insert into TblAccounts values (101002,'account7','سيارات','لا توجد ملاحظات 7',101,null);
       insert into TblAccounts values (101002001,'account7','مرسيدس ن ق ق 705','لا توجد ملاحظات 7',101002,null);
       insert into TblAccounts values (101002002,'account7','تريله س م ه 648','لا توجد ملاحظات 7',101002,null);
       insert into TblAccounts values (101002003,'account7','باص ب ب ف 565','لا توجد ملاحظات 7',101002,null);
       --***003
       insert into TblAccounts values (101003,'account7','اثاث','لا توجد ملاحظات 7',101,null);
       --***004
       insert into TblAccounts values (101004,'account7','آلات','لا توجد ملاحظات 7',101,null);
       insert into TblAccounts values (101003001,'account7','مكينة طباعة رقم 991','لا توجد ملاحظات 7',101004,null);
       insert into TblAccounts values (101003002,'account7','مكينة تغليف رقم 992','لا توجد ملاحظات 7',101004,null);

   --**02
   insert into TblAccounts values (102,'account5','اصول متداولة','لا توجد ملاحظات 5',1,null);
       --***001
       insert into TblAccounts values (102001,'account7','نقدية','لا توجد ملاحظات 7',102,null);
              --****001
              insert into TblAccounts values (102001001,'account7','بنك الراجحي','لا توجد ملاحظات 7',102001,null);
              --****002
              insert into TblAccounts values (102001002,'account7','الفرع رقم 1','لا توجد ملاحظات 7',102001,null);
              insert into TblAccounts values (1020010021,'account7','الفرع رقم 1 / الكاشير رقم 1','لا توجد ملاحظات 7',102001002,null);
              insert into TblAccounts values (1020010022,'account7','الفرع رقم 1/ الكاشير رقم 2','لا توجد ملاحظات 7',102001002,null);
              --****003
              insert into TblAccounts values (102001003,'account7','الفرع رقم 2','لا توجد ملاحظات 7',102001,null);
              insert into TblAccounts values (1020010031,'account7','الفرع رقم 2 / الكاشير رقم 1','لا توجد ملاحظات 7',102001003,null);
              insert into TblAccounts values (1020010032,'account7','الفرع رقم 2 / الكاشير رقم 2','لا توجد ملاحظات 7',102001003,null);
       --***002
       insert into TblAccounts values (102002,'account7','مدينين','لا توجد ملاحظات 7',102,null);
       insert into TblAccounts values (102002001,'account7','شركة سعد','لا توجد ملاحظات 7',102002,null);
       insert into TblAccounts values (102002002,'account7','شركة شافي','لا توجد ملاحظات 7',102002,null);
       --***003
       insert into TblAccounts values (102003,'account7','اوراق قبض','لا توجد ملاحظات 7',102,null);
       insert into TblAccounts values (102003001,'account7','شركة سعد','لا توجد ملاحظات 7',102003,null);
       insert into TblAccounts values (102003002,'account7','شركة شافي','لا توجد ملاحظات 7',102003,null);
       --***004
       insert into TblAccounts values (102004,'account7','مصروفات مقدمة','لا توجد ملاحظات 7',102,null);
       insert into TblAccounts values (102004001,'account7','ايجار المعرض رقم 1','لا توجد ملاحظات 7',102004,null);
       insert into TblAccounts values (102004002,'account7','ايجار المعرض رقم 2','لا توجد ملاحظات 7',102004,null);

       --***005
       insert into TblAccounts values (102005,'account7','مخزون','لا توجد ملاحظات 7',102,null);


       --***006
       insert into TblAccounts values (102006,'account7','مصروفات','لا توجد ملاحظات 7',102,null);
 
       insert into TblAccounts values (102006001,'account7','ايجار','لا توجد ملاحظات 7',102006,null);
       insert into TblAccounts values (1020060011,'account7',' العمارة رقم 1','لا توجد ملاحظات 7',102006001,null);
       insert into TblAccounts values (1020060012,'account7','المستودع رقم 44','لا توجد ملاحظات 7',102006001,null);

       insert into TblAccounts values (102006002,'account7','مرتبات','لا توجد ملاحظات 7',102006,null);
       insert into TblAccounts values (1020060021,'account7','مرتب خالد','لا توجد ملاحظات 7',102006002,null);
       insert into TblAccounts values (1020060022,'account7','مرتب ايهم','لا توجد ملاحظات 7',102006002,null);


--#2
insert into TblAccounts values (2,'account2','خصوم','لا توجد ملاحظات 2',null,null);
   --##01
   insert into TblAccounts values (201,'account6','خصوم قصيرة الاجل','لا توجد ملاحظات 6',2,null);
       --###001

       --###002
       insert into TblAccounts values (201002,'account7','مصروفات مستحقة','لا توجد ملاحظات 7',201,null);
              --####001
              insert into TblAccounts values (201002001,'account7','العمارة رقم 22','لا توجد ملاحظات 7',201002,null);
              insert into TblAccounts values (201002002,'account7','قسط سيارة رقم س س ث 565','لا توجد ملاحظات 7',201002,null);
       --###003
       insert into TblAccounts values (201003,'account7','دائنين','لا توجد ملاحظات 7',201,null);
              --####001
              insert into TblAccounts values (201003001,'account7','شركة السعيد','لا توجد ملاحظات 7',201003,null);
              insert into TblAccounts values (201003002,'account7','شركة الدانة','لا توجد ملاحظات 7',201003,null);
       --###004
       insert into TblAccounts values (201004,'account7','اوراق دفع','لا توجد ملاحظات 7',201,null);
              --####001
              insert into TblAccounts values (201004001,'account7','شركة السعيد','لا توجد ملاحظات 7',201004,null);
              insert into TblAccounts values (201004002,'account7','شركة الدانة','لا توجد ملاحظات 7',201004,null);
       --###005
       insert into TblAccounts values (201001,'account3','ايرادات','لا توجد ملاحظات 3',201,null);
       insert into TblAccounts values (201001001,'account3','ايراد بيع سلع','لا توجد ملاحظات 3',201001,null);
       insert into TblAccounts values (201001002,'account3','ايراد ودائع','لا توجد ملاحظات 3',201001,null);

   --##02
   insert into TblAccounts values (202,'account7','خصوم طويلة الاجل','لا توجد ملاحظات 7',2,null);
       --###001
       insert into TblAccounts values (202001,'account7','قروض','لا توجد ملاحظات 7',202,null);
	          --####001
              insert into TblAccounts values (202001001,'account7','قرض بنك الراجحي','لا توجد ملاحظات 7',202001,null);
       insert into TblAccounts values (202002,'account7','مخصصات','لا توجد ملاحظات 7',202,null);


--$3
insert into TblAccounts values (3,'account3','حقوق الملكية','لا توجد ملاحظات 3',null,null);
   --$$01
   insert into TblAccounts values (301,'account3','راس المال','لا توجد ملاحظات 3',3,null);
       --&&&001
       insert into TblAccounts values (301001,'account3','راس المال / احمد سالم','لا توجد ملاحظات 3',301,null);
	                insert into TblAccounts values (301001001,'account3','استثمار / احمد سالم','لا توجد ملاحظات 3',301001,null);
					insert into TblAccounts values (301001002,'account3','مسحوبات / احمد سالم','لا توجد ملاحظات 3',301001,null);
       insert into TblAccounts values (301002,'account3','راس المال / مسفر سالم','لا توجد ملاحظات 3',301,null);
	                insert into TblAccounts values (301002001,'account3','استثمار / مسفر سالم','لا توجد ملاحظات 3',301002,null);
					insert into TblAccounts values (301002002,'account3','مسحوبات / مسفر سالم','لا توجد ملاحظات 3',301002,null);
   --$$02
   insert into TblAccounts values (302,'account3','الارباح المحتجزة','لا توجد ملاحظات 3',3,null);
       --&&&001
       insert into TblAccounts values (302001,'account3','الارباح المحتجزة','لا توجد ملاحظات 3',302,null);

   --$$03
   insert into TblAccounts values (303,'account3','فائض / خسائر اعادة التقييم','لا توجد ملاحظات 3',3,null);
       --&&&001
       insert into TblAccounts values (303001,'account3','فائض / خسائر اعادة التقييم','لا توجد ملاحظات 3',303,null);

   --$$04
   insert into TblAccounts values (304,'account3','الاحتياطيات','لا توجد ملاحظات 3',3,null);
       --&&&001
       insert into TblAccounts values (304001,'account3','احتياطي كوارث','لا توجد ملاحظات 3',304,null);

GO

----*  210  *----------( اجراء مخزن لانشاء حساب محاسبي جديد )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc spAddAccount
@AccountNo int  ,  --------------------------------------------------------- رقم الحساب 
@AccountNameEN varchar(100),------------------------------------------------- اسم الحساب بالانجليزي
@AccountNameAR varchar(100),--------------------------------------------------- اسم الحساب بالعربي
@AccountInformations varchar(250), -------------------------------------- معلومات الحساب
@TopAccountNo int = null , -------------------------------------------------------------- رقم الحساب الاعلى
@ClientsNo int = null   -------------------------------------------------------------------- رقم العميل
as
begin
insert into TblAccounts values (@AccountNo,@AccountNameEN,@AccountNameAR,@AccountInformations,@TopAccountNo ,@ClientsNo );
end

GO
--DROP PROC spAddAccount

----*  210  *----------( اجراء مخزن لتعديل حساب قديم )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc spEditAccount
@AccountNo int  ,  --------------------------------------------------------- رقم الحساب 
@AccountNameEN varchar(100),------------------------------------------------- اسم الحساب بالانجليزي
@AccountNameAR varchar(100),--------------------------------------------------- اسم الحساب بالعربي
@AccountInformations varchar(250), -------------------------------------- معلومات الحساب
@TopAccountNo int = null , -------------------------------------------------------------- رقم الحساب الاعلى
@ClientsNo int  = null  -------------------------------------------------------------------- رقم العميل
as
begin
update TblAccounts set AccountNameEN = @AccountNameEN,AccountNameAR = @AccountNameAR,AccountInformations = @AccountInformations,TopAccountNo = @TopAccountNo,ClientsNo = @ClientsNo where AccountNo = @AccountNo
end
GO


----*  249  *----------( جدول القيود المحاسبية الفرعية في سجل اليومية  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

CREATE TABLE TblSubJournalEntry  -- جدول الارقام الفرعية لارقام قيود اليومية
(
SubJornalEntryNo int primary key identity,-------- رقم القيد المحاسبي الفرعي في سجل اليومية
JournalEntryNo int  ,-------- رقم القيد المحاسبي الرئيسي في سجل اليومية
AccountNo int  ,------------------------------ رقم الحساب 
DebitValue decimal(11,2),---------------------------- قيمة الحساب المدين
CreditValue decimal(11,2),--------------------------- قيمة الحساب الدائن
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


 ----*  250  *----------( انواع العمليات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblOperationsTypes
(
OperationTypeNo int primary key identity(1,1),  -- رقم نوع الفاتورة
TypeArabic varchar(100),                        -- النوع بالعربي
TypeEnglish varchar(100)                        -- النوع بالانجليزي
)
GO

insert into TblOperationsTypes values ('عرض سعر','');
insert into TblOperationsTypes values ('مشتريات','');
insert into TblOperationsTypes values ('مبيعات','');
insert into TblOperationsTypes values ('مرتجع مشتريات','');
insert into TblOperationsTypes values ('مرتجع مبيعات','');
GO

----*  251  *----------( العمليات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblOperations
(
OperationNo int primary key identity(1,1),  -- رقم العملية
OperationTypeNo int ,                       -- رقم نوع العملية
OperationUnitNumber int,                    -- رقم وحدة العمليات
RegistrationDateAndTime datetime,           -- تاريخ ووقت التسجيل
UserAccountNoWhoRegistered int ,                    -- رقم المستخدم الذي قام بتسجيل العملية
PendinGOperation bit ,                      -- عملية معلقة
ExecutionDateAndTime datetime,              -- تاريخ ووقت التنفيذ
UserAccountNoWhoHxecuted int ,                       -- رقم المستخدم الذي قام بتنفيذ العملية
Notes varchar(200) ,                         -- ملاحظات
JournalEntryNo int                           -- رقم قيد اليومية
)

GO

-- ( ربط حقل رقم نوع العملية  بحقل رقم رقم نوع العمية في جدول وحدات انواع العمليات )

alter table TblOperations
add constraint pk_TblOperations_TblOperationsTypes_OperationTypeNo foreign key (OperationTypeNo) references TblOperationsTypes(OperationTypeNo)

GO

-- ( ربط حقل رقم وحدة العمليات  بحقل رقم وحدة العمليات في جدول وحدات العمليات )

alter table TblOperations
add constraint pk_TblOperations_TblOperationUnits_OperationUnitNumber foreign key (OperationUnitNumber) references TblOperationUnits(OperationUnitNumber)

GO

-- ( ربط حقل رقم المستخدم الذي قام بتسجيل العملية  بحقل رقم المستخدم في جدول الستخدمين )

alter table TblOperations
add constraint pk_TblOperations_UserAccountNoWhoRegistered_TblUsersAccounts_UserAccountNo foreign key (UserAccountNoWhoRegistered) references TblUsersAccounts(UserAccountNo) 

GO

-- ( ربط حقل رقم رقم المستخدم الذي قام بتنفيذ العملية  بحقل رقم المستخدم في جدول الستخدمين )

alter table TblOperations
add constraint pk_TblOperations_UserAccountNoWhoHxecuted_TblUsersAccounts_UserAccountNo foreign key (UserAccountNoWhoHxecuted) references TblUsersAccounts(UserAccountNo)

GO

-- ( ربط حقل رقم قيد اليومية  بحقل رقم قيد اليومية في جدول ارقام قيود اليومية )

alter table TblOperations
add constraint pk_TblOperations_TblJournalEntry_JournalEntryNo foreign key (JournalEntryNo) references TblJournalEntry(JournalEntryNo)


--insert into TblOperations251 values (2,1,'2021/1/1 09:15 am',1,0,'2021/1/1 09:15 am',1,'لا توجد ملاحظات',null);
--insert into TblOperations251 values (2,2,'2021/1/1 09:15 am',1,0,'2021/1/1 09:15 am',1,'لا توجد ملاحظات',null);

--insert into TblOperations251 values (3,1,'2021/1/1 09:15 am',1,0,'2021/1/1 09:15 am',1,'لا توجد ملاحظات',null);
--insert into TblOperations251 values (3,2,'2021/1/1 09:15 am',1,0,'2021/1/1 09:15 am',1,'لا توجد ملاحظات',null);

--insert into TblOperations251 values (4,1,'2021/1/1 09:15 am',1,0,'2021/1/1 09:15 am',1,'لا توجد ملاحظات',null);
--insert into TblOperations251 values (4,2,'2021/1/1 09:15 am',1,0,'2021/1/1 09:15 am',1,'لا توجد ملاحظات',null);

--insert into TblOperations251 values (5,1,'2021/1/1 09:15 am',1,0,'2021/1/1 09:15 am',1,'لا توجد ملاحظات',null);
--insert into TblOperations251 values (5,2,'2021/1/1 09:15 am',1,0,'2021/1/1 09:15 am',1,'لا توجد ملاحظات',null);


GO


------*  252  *----------( الفواتير )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblInvoice
(
 MainInvoiceNo int primary key identity(1,1),  -- الرقم الرئيسي للفاتورة 
 MainInvoiceNoSelf int ,             -- رقم الفاتورة الرئيسي المرتبط
OperationNo int,                          -- رقم العملية
CostPriceTotal decimal(8,2),              -- اجمالي سعر التكلفة
SubtotalSellingPrice decimal(8,2),        -- اجمالي سعر البيع
ProfitTotal decimal(8,2),                 -- اجمالي الربحية 
TaxPercentage decimal(5,2),               -- نسبة الضريبة
AmountOfTax decimal(8,2),                 -- مبلغ الضريبة
InvoiceTotalValue decimal(8,2),           -- اجمالي قيمة الفاتورة
ClientsNo int,                            -- رقم العميل
SupplierInvoiceNo varchar(20),            -- رقم فاتورة المورد
SupplierInvoiceDate datetime              -- تاريخ فاتورة المورد
)


GO
-- (ربط حقط رقم الفاتورة الرئيسي المرتبط مع حقل الرقم الرئيسي للفاتورة  )
alter table TblInvoice
add constraint pk_TblInvoice_MainInvoiceNoSelf_TblInvoice_MainInvoiceNo foreign key ( MainInvoiceNoSelf) references TblInvoice(MainInvoiceNo)

GO

-- ( ربط حقل رقم العملية  بحقل رقم العملية في جدول العمليات )

alter table TblInvoice
add constraint pk_TblInvoice_TblOperations_OperationNo foreign key (OperationNo) references TblOperations(OperationNo)

GO

-- ( ربط حقل رقم العميل  بحقل رقم العميل في جدول العملاء  )

alter table TblInvoice
add constraint pk_TblInvoice_TblClients_ClientsNo foreign key (ClientsNo) references TblClients(ClientsNo)

GO
--insert into TblInvoice252 values (NULL,3,1500,1600,100,.15,160,102,1,'inv10155551','2021/1/1');
--insert into TblInvoice252 values (NULL,3,1700,1600,200,.15,170,103,1,'inv10155551','2022/2/2');

GO

----*  253  *----------( تفاصيل الفواتير )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblInvoicesDetails 
(
SubInvoiceNumber int primary key identity(1,1),   -- رقم تفصيل الفاتورة
MainInvoiceNo int,                                -- رقم الفاتورة الرئيسي
BarcodeNo varchar(20) ,                           -- رقم الباركود
productOrServiceNumber int,                       -- رقم السلعة او الخدمة
UnitDetailsNo int ,               -- رقم تفاصيل الوحدة
BatchNo int,                                      -- رقم التشغيلة
ShelfGeneralNo int,                               -- الرقم العام للرف
NonFreeQuantity decimal(8,2),                     -- الكمية الغير مجانية
FreeQuantity decimal(8,2),                        -- الكمية المجانية
UnitCost decimal(8,2),                            -- تكلفة الوحدة
UnitPrice decimal(8,2),                           -- سعر الوحدة
UnitProfit decimal(8,2),                          -- ربحية الوحدة
SubtotalCostPrice decimal(8,2),                   -- الاجمالي الفرعي لسعر التكلفة 
SubtotalSellingPrice decimal(8,2),                -- الاجمالي الفرعي لسعر البيع 
SubProfitTotal decimal(8,2),                      -- اجمالي الربحية الفرعي 
QuantityDebit decimal(8,2),                       -- الكمية المدينة
QuantityCreditor decimal(8,2),                    -- الكمية الدائنة
StockValueDebit decimal(8,2),                     -- قيمة المخزون المدينة
StockValueCreditor decimal(8,2)                   -- قيمة المخزون الدائنة
)


GO
-- ( ربط حقل رقم الفاتورة الرئيسي  بحقل رقم الفاتورة الرئيسي في جدول الفواتير  )

alter table TblInvoicesDetails
add constraint pk_TblInvoicesDetails_TblInvoice_MainInvoiceNo foreign key (MainInvoiceNo) references TblInvoice(MainInvoiceNo)

GO

-- ( ربط حقل رقم السلعة او الخدمة  بحقل رقم السلعة او الخدمة في جدول الخدمات والسلع    )
alter table TblInvoicesDetails
add constraint PK_TblInvoicesDetails_TblProductsAndServices_productOrServiceNumber foreign key (productOrServiceNumber) references TblProductsAndServices(productOrServiceNumber)  ;

GO

-- ( ربط حقل رقم التشغيلة  بحقل رقم التشغيلة في جدول التشغيلات )

alter table TblInvoicesDetails
add constraint pk_TblInvoicesDetails_TblBatch_BatchNo foreign key (BatchNo) references TblBatch(BatchNo)

GO

-- ( ربط حقل رقم تفاصيل الوحدة  بحقل رقم تفاصيل الوحدة في جدول تفاصيل السلع والخدمات  ) 
alter table TblInvoicesDetails
add constraint PK2_TblInvoicesDetails_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo) on delete cascade ;

GO
--insert into TblInvoicesDetails253 values (1,'',1,1,1,1,10,5,1.5,3,.5,22.5,30,7.5,0,15,0,22.5);
--GO




------*  257  *----------( عمليات الاهلاك )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblDepreciationOperations
(
DepreciationOperationsNo int primary key identity(1,1),  -- رقم عملية الاهلاك
OperationNo int,                             -- رقمالعملية
LossValue decimal(9,2),                      -- قيمة الخسائر
Notes varchar(200)                           -- ملاحظات
)

--(ربط حقل رقم العملية بحقل رقم العملية في جدول العمليات)

alter table TblDepreciationOperations
add constraint pk_TblDepreciationOperations_TblOperations_OperationNo   foreign key (OperationNo) references TblOperations(OperationNo) 

GO

------*  258  *----------( تفاصيل عمليات الاهلاك )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblDepreciationOperationDetails
(
DepreciationOperationDetailsNo int primary key identity(1,1),  -- الرقم الفرعي
DepreciationOperationsNo int,                      -- رقم عملية الاهلاك
DepreciationReason  varchar(200),                  -- سبب عملية الاهلاك
productOrServiceNumber int,                          -- رقم الخدمة او السلعة
UnitDetailsNo int ,               -- رقم تفاصيل الوحدة
BatchNo   int,                                     -- التشغيلة
ShelfGeneralNo int,                                -- الرقم العام للرف
Quantity decimal(8,2),                             -- الكمية
UnitCost decimal(8,2),                             -- تكلفة شراء الوحدة
SubTotal  decimal(9,2)                            -- الاجمالي الفرعي
)


-- ( ربط حقل رقم عملية الاهلاك  بحقل رقم عملية الاهلاك في جدول عمليات الاهلاك )

alter table TblDepreciationOperationDetails
add constraint pk_TblDepreciationOperationDetails_TblDepreciationOperations_DepreciationOperationsNo foreign key (DepreciationOperationsNo) references TblDepreciationOperations(DepreciationOperationsNo)

GO

-- ( ربط حقل رقم السلعة او الخدمة  بحقل رقم السلعة او الخدمة في جدول الخدمات والسلع    )
alter table TblDepreciationOperationDetails
add constraint PK_TblDepreciationOperationDetails_TblProductsAndServices_productOrServiceNumber foreign key (productOrServiceNumber) references TblProductsAndServices(productOrServiceNumber)  ;

GO

---- ( ربط حقل رقم التشغيلة  بحقل رقم التشغيلة في جدول التشغيلات )

alter table TblDepreciationOperationDetails
add constraint pk_TblDepreciationOperationDetails_TblBatch_BatchNo foreign key (BatchNo) references TblBatch(BatchNo)

GO

-- ( ربط حقل الرقم العام للرف  بحقل الرقم العام للرف في جدول الارفف  )

alter table TblDepreciationOperationDetails
add constraint pk_TblDepreciationOperationDetails_TblShelves_ShelfGeneralNo foreign key (ShelfGeneralNo) references TblShelves(ShelfGeneralNo)

GO
-- ( ربط حقل رقم تفاصيل الوحدة  بحقل رقم تفاصيل الوحدة في جدول تفاصيل السلع والخدمات  ) 
alter table TblDepreciationOperationDetails
add constraint PK2_TblDepreciationOperationDetails_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo) on delete cascade ;

GO


------*  259  *----------( عمليات نقل الارصدة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblInventoryTransfer
(
InventoryInventoryTransferNo int primary key identity(1,1),
OperationNo int,
Notes varchar(200)
)

GO

----(ربط حقل رقم العملية بحقل رقم العملية في جدول العمليات)

alter table TblInventoryTransfer
add constraint pk_TblInventoryTransfer_TblOperations_OperationNo   foreign key (OperationNo) references TblOperations(OperationNo) 

GO

------*  260  *----------( تفاصيل عملية النقل )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblTransferTransferDetails
(
TransferTransferDetailsNo int primary key identity(1,1),  -- الرقم الفرعي
InventoryTransferNo int,                               -- رقم عملية النقل
productOrServiceNumber int,                                -- رقم السلعة او الخدمة
UnitDetailsNo int ,               -- رقم تفاصيل الوحدة
BatchNo int,                                  -- التشغيلة
Quantity decimal(8,2),                        -- الكمية
UnitCost  decimal(8,2),                       -- تكلفة شراء الوحدة
TotalCost decimal(9,2),                       -- التكلفة الكلية
ShelfGeneralNoFrom int,                       -- من الرف رقم
ShelfGeneralNoTo int,                         -- الى الرف رقم 
Notes varchar(200)                           -- ملاحظات
)

GO

-- ( ربط حقل رقم عملية النقل  بحقل رقم عملية النقل في جدول عمليات نقل الارصدة )

alter table TblTransferTransferDetails
add constraint pk_TblTransferTransferDetails_TblInventoryTransfer_InventoryInventoryTransferNo foreign key (InventoryTransferNo) references TblInventoryTransfer(InventoryInventoryTransferNo)

GO

-- ( ربط حقل رقم السلعة او الخدمة  بحقل رقم السلعة او الخدمة في جدول الخدمات والسلع    )
alter table TblTransferTransferDetails
add constraint PK_TblTransferTransferDetails_TblProductsAndServices_productOrServiceNumber foreign key (productOrServiceNumber) references TblProductsAndServices(productOrServiceNumber)  ;


GO

-- ( ربط حقل رقم التشغيلة  بحقل رقم التشغيلة في جدول التشغيلات )

alter table TblTransferTransferDetails
add constraint pk_TblTransferTransferDetails_TblBatch_BatchNo foreign key (BatchNo) references TblBatch(BatchNo)

GO

-- ( ربط حقل رقم تفاصيل الوحدة  بحقل رقم تفاصيل الوحدة في جدول تفاصيل السلع والخدمات  ) 
alter table TblTransferTransferDetails
add constraint PK2_TblTransferTransferDetails_TblproductAndServicesDetails_UnitDetailsNo foreign key (UnitDetailsNo) references TblproductAndServicesDetails(UnitDetailsNo) on delete cascade ;

GO

-- (ربط حقل من الرف رقم بحقل الرقم العام للرف في جدول الارفف)
alter table TblTransferTransferDetails
add constraint pk_TblTransferTransferDetails_ShelfGeneralNoFrom_TblShelves_ShelfGeneralNo foreign key (ShelfGeneralNoFrom) references TblShelves(ShelfGeneralNo)

GO

-- (ربط حقل الى الرف رقم بحقل الرقم العام للرف في جدول الارفف)
alter table TblTransferTransferDetails
add constraint pk_TblTransferTransferDetails_ShelfGeneralNoTo_TblShelves_ShelfGeneralNo foreign key (ShelfGeneralNoTo) references TblShelves(ShelfGeneralNo)

GO


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

