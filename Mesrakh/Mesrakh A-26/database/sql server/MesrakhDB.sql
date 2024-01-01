
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

insert into TblManufacturers values ('رسف','rest',null);
insert into TblManufacturers values ('بيرين','berain',null);

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

insert into TblProductsAndServices values (1,'ماء','water','ماء','water');

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
insert into TblMeasureUnit values ('لتر','leter','ل','l',null,null);
insert into TblMeasureUnit values ('مليليتر','melileter','ملل','ml',1,1000);
GO
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

go
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
insert into TblEncapsulationUnits values ('قارورة','Flask','قارورة','Flask');
insert into TblEncapsulationUnits values ('صندوق','box','صندوق','box');
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
ShortArabicName varchar(50),   -- الاسم العربي المختصر
ShortEnglishName varchar(50),  -- الاسم الانجليزي المختصر
StockQuantity decimal(8,2), -- كمية المخزون
StockCost decimal(8,2), -- تكلفة المخزون
PriceCalculationMethod int  -- اسلوب احتساب سعر البيع
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
insert into TblproductAndServicesDetails values (1,1,200,2,null,null,1,null,null,'ماء رست 200 ملم','rest water 200 mlm','ماء رست 200 ملم','rest water 200 mlm',100,50,1);
insert into TblproductAndServicesDetails values (1,1,1500,1,null,null,2,null,null,'ماء بيرين  بيرين 1.5 لتر','berain water 1.5 leter','ماء بيرين 1.5 لتر','berain water 1.5 leter',100,200,1);
insert into TblproductAndServicesDetails values (1,1,null,null,10,2,null,null,null,'كرتون ماء بيرين  بيرين 1.5 لتر','berain box water 1.5 leter','كرتون ماء بيرين 1.5 لتر','berain box water 1.5 leter',100,2000,1);
GO

--select * from TblproductAndServicesDetails inner join TblBarcode on TblproductAndServicesDetails.UnitDetailsNo = TblBarcode.UnitDetailsNo

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
@PriceCalculationMethod int, -- اسلوب احتساب سعر البيع
@UnitDetailsNo int out -- رقم تفاصيل الوحدة
as
begin
insert into TblproductAndServicesDetails values (@productOrServiceNumber , @EncapsulationUnitsNo ,@MeasureUnitValue ,@MeasureUnitNo ,@UnitDetailsValue ,@UnitDetailsNoSelfJoin ,@ManufacturerNo ,@ModelOrProductArabicDescription , @ModelEnglishOrProductEnglishDescription,  @DetailedNameForProductOrServiceAr ,@DetailedNameForProductOrServiceEn ,@ShortArabicName ,@ShortEnglishName ,@StockQuantity ,@StockCost,@PriceCalculationMethod);
set @UnitDetailsNo = SCOPE_IDENTITY();
return @UnitDetailsNo
end
GO


----*  206  *----------( انشاء إجراء مخزن لخصم كميات السلع )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create proc spQuantityDiscount
 @UnitDetailsNo int ,-- رقم تفصيل الوحدة او السلعة
 @Qty decimal(8,2) -- الكمية المخصومة
 as
 begin
    declare @productOrServiceNumber int -- الرقم الرئيسي للسلعة او الخدمة
    declare @StockQuantity decimal(8,2) -- كمية المخزون
	declare @StockCost decimal(8,2) -- تكلفة المخزون
	declare @UnitCost decimal(8,2) -- تكلفة الوحدة
    select @productOrServiceNumber = productOrServiceNumber , @StockQuantity = StockQuantity ,@StockCost = StockCost from TblproductAndServicesDetails where UnitDetailsNo = @UnitDetailsNo -- ايجاد كمية المخزون وتكلفة المخزون ورقم السلعة او الخدمة  
	set @UnitCost = (@StockCost / @StockQuantity)
    declare @ProductOrService bit
    select @ProductOrService = ProductOrService from TblProductsAndServices where ProductOrServiceNumber = @productOrServiceNumber  -- ايجاد النوع سلعة ام خدمة
    if @ProductOrService = 1 -- اذا كان النوع سلعة
       begin
          update TblproductAndServicesDetails set StockQuantity = (@StockQuantity - @Qty ) , StockCost = ((@StockQuantity - @Qty ) * @UnitCost )  where UnitDetailsNo = @UnitDetailsNo -- خصم كمية المخزون
       end
 end

 GO

 --spQuantityDiscount 1 , 1
 -- select * from TblproductAndServicesDetails inner join TblBarcode on TblproductAndServicesDetails.UnitDetailsNo = TblBarcode.UnitDetailsNo

 --  update TblproductAndServicesDetails set StockQuantity = 100 ,StockCost = 50 where UnitDetailsNo = 1
 -- update TblproductAndServicesDetails set StockQuantity = 100 ,StockCost = 200 where UnitDetailsNo = 2
 -- update TblproductAndServicesDetails set StockQuantity = 100 ,StockCost = 2000 where UnitDetailsNo = 3
  --drop proc spQuantityDiscount

 ----*  206  *----------( انشاء إجراء مخزن للتحويل من الوحدة الاكبر للوحدة الاصغر )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

 -- خفظ كمية الوحدة الكبيرة وزيادة الوحدة الصغيرة
 -- خفظ تكلفة مخزون الوحدة الكبيرة وزيادة تكلفة مخزون الوحدة الصغيرة حسب سعر الوحدة الكبيرة

create proc spConvertingToSmallestUnit
 @UnitDetailsNo int ,-- رقم تفصيل الوحدة او السلعة
 @Qty decimal(8,2) -- الكمية المحولة للوحدة الاصغر
 as
 begin
    declare @StockQuantityBig decimal(8,2) -- الكمية المتوفرة من الوحدة الاكبر
	declare @StockCostBig decimal(8,2) -- تكلفة مخزون الوحدة الكبيرة
	declare @UnicCostBig decimal(8,2) -- تكلفة الوحدة الكبيرة

	declare @StockQuantitySmall decimal(8,2) -- الكمية المتوفرة من الوحدة الاصغر
	declare @StockCostSmall decimal(8,2) -- تكلفة مخزون الوحدة الاصغر

    declare @UnitDetailsNoSelfJoin int -- رقم تفصيل الوحدة او السلعة الاصغر
    declare @UnitDetailsValue decimal(8,2) -- قيمة التحويل من الوحدة الاكبر الى الوحدة الاصغر

	declare @UnicCostNewSmall decimal(8,2) -- تكلفة الوحدة الصغيرة الجدية

    select  @StockQuantityBig = StockQuantity ,@StockCostBig = StockCost , @UnitDetailsNoSelfJoin = UnitDetailsNoSelfJoin , @UnitDetailsValue = UnitDetailsValue  from TblproductAndServicesDetails where UnitDetailsNo = @UnitDetailsNo -- ايجاد كمية الوحدة الكبيرة وتكلفة المخزون ورقم الوحدة الصغيرة وقيمة التحويل الى الصغيرة من الكبيرة 
	set @UnicCostBig = @StockCostBig / @StockQuantityBig -- تكلفة الوحدة الكبيرة

	select  @StockQuantitySmall = StockQuantity , @StockCostSmall = StockCost  from TblproductAndServicesDetails where UnitDetailsNo = @UnitDetailsNoSelfJoin -- ايجاد كمية الوحدة الصغيرة و تكلفة المخزون منها
	set @UnicCostNewSmall =  @UnicCostBig /  @UnitDetailsValue -- تكلفة الوحدة الصغيرة
	
	if @UnitDetailsNoSelfJoin is not null 
	begin
	    update TblproductAndServicesDetails set StockQuantity = (@StockQuantityBig - @Qty ) , StockCost = ((@StockQuantityBig - @Qty ) * @UnicCostBig)  where UnitDetailsNo = @UnitDetailsNo -- خصم الكمية من الوحدة الكبيرة وتخفيض تكلفة المخزون 
        update TblproductAndServicesDetails set StockQuantity = ( @StockQuantitySmall + (@UnitDetailsValue * @Qty )) , StockCost =  (@StockCostSmall + (@UnicCostNewSmall * (@Qty * @UnitDetailsValue )))  where UnitDetailsNo = @UnitDetailsNoSelfJoin -- اضافة الكمية الى الوحدة الصغيرة وزيادة تكلفة المخزون 
	end
 end

 GO
 
 --select * from TblproductAndServicesDetails where UnitDetailsNoSelfJoin is not null




 --spConvertingToSmallestUnit 1 , 3
 --select * from TblproductAndServicesDetails

 --drop proc  spConvertingToSmallestUnit
  --update TblproductAndServicesDetails set StockQuantity = 100 ,StockCost = 50 where UnitDetailsNo = 1
  --update TblproductAndServicesDetails set StockQuantity = 100 ,StockCost = 200 where UnitDetailsNo = 2
  --update TblproductAndServicesDetails set StockQuantity = 100 ,StockCost = 2000 where UnitDetailsNo = 3
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
insert into TblBarcode values (1,'6287007800022');
insert into TblBarcode values (2,'6281101220779');
insert into TblBarcode values (3,'6294003539153');
GO
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
insert into TblPriceCategories values (1,1,10000,1);
insert into TblPriceCategories values (2,1,10000,2.5);
insert into TblPriceCategories values (3,1,10000,25);
GO
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
insert into TblEnterprise values ('شركة السلام','alsalam company',null,'',15);
GO
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
insert into TblEnterpriseBranches values (1,'معرض','الفرع الرئيسي','mane branch','نجران حبونا','بدون تفاصيل',null);

go

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


---------------------------------------------------------------------------------------------------------- الدليل المحاسبي
--  https://www.youtube.com/watch?v=nTyS_ZL_WrA 

--  /1
insert into TblAccounts values (1 ,'أصول','أصول','1',null);

    -- /2
    insert into TblAccounts values (11 ,'أصول غير متداولة','أصول غير متداولة','2', 1);

	       --  /_3
	       insert into TblAccounts values (1101 ,'أصول ثابتة ملموسة','أصول ثابتة ملموسة','3',11 );

			     --  /_4
		      	  insert into TblAccounts values ( 110101,'مباني','مباني','4', 1101);

				  	    --  /_._5
		         	    insert into TblAccounts values (110101001 ,'المبنى الرئيسي','المبنى الرئيسي','5', 110101);

			     --  /_4
			     insert into TblAccounts values (110102 ,'آلات ومعدات','آلات ومعدات','4', 1101);


			     --  /_4
			     insert into TblAccounts values ( 110103,'سيارات','سيارات','4', 1101);

				 		--  /_._5
		         	    insert into TblAccounts values (110103001 ,'سيارة لوحة رقم 11','سيارة لوحة رقم 11','5',110103 );

			     --  /_4
			     insert into TblAccounts values (110104 ,'أراضي','أراضي','4', 1101);

			     --  /_4
			     insert into TblAccounts values ( 110105 ,'الأثاث','الأثاث','4', 1101);

				 		--  /_._5
		         	    insert into TblAccounts values ( 110105001,'اثاث الفرع الرئيسي','اثاث الفرع الرئيسي','5',110105 );

	       --  /_3
	       insert into TblAccounts values (1102 ,'أصول ثابتة غير ملموسة','أصول ثابتة غير ملموسة','3',11 );

			     --  /_4
			     insert into TblAccounts values (110201 ,'الشهرة','الشهرة','4', 1102);

			     --  /_4
			     insert into TblAccounts values (110202 ,'العلامات التجارية','العلامات التجارية','4',1102 );

			     --  /_4
			     insert into TblAccounts values ( 110203,'براءات الإختراع','براءات الإختراع','4', 1102);

			     --  /_4
			     insert into TblAccounts values ( 110204 ,'البرامج','البرامج','4', 1102);

				 		--  /_._5
		         	    insert into TblAccounts values ( 110204001,'برنامج المبيعات','برنامج المبيعات','5', 110204);

    --  /2
    insert into TblAccounts values (12 ,'أصول متداولة','أصول متداولة','2', 1);

	       --  /_3
	       insert into TblAccounts values ( 1201,'النقدية وما شابهها','النقدية وما شابهها','3',12 );

			     --  /_4
			     insert into TblAccounts values (120101 ,'الحسابات الجارية بالبنوك','الحسابات الجارية بالبنوك','4', 1201);

				 		--  /_._5
		         	    insert into TblAccounts values ( 120101001,'الراجحي الحساب رقم 654654654654','الراجحي الحساب رقم 654654654654','5', 120101);

						--  /_._5
		         	    insert into TblAccounts values ( 120101002,'الأهلي الحساب رقم 100000000054','الأهلي الحساب رقم 100000000054','5', 120101);

			     --  /_4
			     insert into TblAccounts values ( 120102,'صناديق النقدية','صناديق النقدية','4',1201 );


							 --  /_._5
		         	         insert into TblAccounts values ( 120102001,'الكاشير رقم 1','الكاشير رقم 1','5', 120102);

							  --  /_._5
		         	         insert into TblAccounts values ( 120102002,'الكاشير رقم 2','الكاشير رقم 2','5', 120102);

							 --  /_._5
		         	         insert into TblAccounts values ( 120102003,'صندوق النقدية رقم 505','صندوق النقدية رقم 505','5',120102 );

	       --  /_3
	       insert into TblAccounts values ( 1202,'أوراق القبض','أوراق القبض','3',12 );



	       --  /_3
	       insert into TblAccounts values ( 1203,'المخزون','المخزون','3',12 );

		   		 --  /_4
			     insert into TblAccounts values ( 120301,'مخزون الفرع الرئسي','مخزون الفرع الرئسي','4',1203 );


	       --  /_3
	       insert into TblAccounts values (1204 ,'المدينين','المدنين','3',12 );


		   		 --  /_4
			     insert into TblAccounts values ( 120401,'مدينين المجموعة 1','مدينين المجموعة 1','4', 1204);

							 --  /_._5
							 insert into TblAccounts values ( 120401001,'ح/مدين/محمد سالم','ح/مدين/محمد سالم','5',120401 );

							 --  /_._5
							 insert into TblAccounts values ( 120401002,'ح/مدين/علي صالح','ح/مدين/علي صالح','5',120401 );



	       --  /_3
	       insert into TblAccounts values ( 1205,'العهد','العهد','3',12 );

		   		 --  /_4
			     insert into TblAccounts values ( 120501,'المجموعة 1 عهد','المجموعة 1 عهد','4', 1205);

				 			 --  /_._5
							 insert into TblAccounts values ( 120501001,'ح/عهدة/محمد صالح','ح/عهدة/محمد صالح','5',120501 );

							  --  /_._5
							 insert into TblAccounts values ( 120501002,'ح/عهدة/علي محمد','ح/عهدة/علي محمد','5',120501 );


	       --  /_3
	       insert into TblAccounts values ( 1206,'مصروفات مقدمة','مصروفات مقدمة','3',12 );


	       --  /_3
	       insert into TblAccounts values ( 1207,'ضريبة مشتريات / مدخلات','ضريبة مشتريات / مدخلات','3', 12);

		   --  /_3
	       insert into TblAccounts values ( 1208,'إيرادات مستحقة','إيرادات مستحقة','3', 12);
		   

		   --  /_3
	       insert into TblAccounts values ( 1209,'مجمع إهلاك','مجمع إهلاك','4', 12);

			     --  /_4
			     insert into TblAccounts values (120901 ,'مجمع إهلاك المباني','مجمع إهلاك المباني','4', 1209);

			     --  /_4
			     insert into TblAccounts values (120902 ,'مجمع إهلاك الآلات والمعدات','مجمع إهلاك الآلات والمعدات','4', 1209);

			     --  /_4
			     insert into TblAccounts values ( 120903,'مجمع إهلاك السيارات','مجمع إهلاك السيارات','4', 1209);


			     --  /_4
			     insert into TblAccounts values ( 120904,'مجمع إهلاك الأثاث','مجمع إهلاك الأثاث','4', 1209);

	       
		   		   --  /_3
	       insert into TblAccounts values ( 1210,'ذمم الموظفين','ذمم الموظفين','3',12 );

			     --  /_4
			     insert into TblAccounts values ( 121001,'ذمم الموظفين بالفرع / 1','ذمم الموظفين بالفرع / 1','4', 1210);
		   
		   				 	--  /_._5
							 insert into TblAccounts values ( 121001001,'ح/ذمم / الموظفن / ايهم','ح/ذمم / الموظفن / ايهم','5',121001 );

							  --  /_._5
							 insert into TblAccounts values ( 121001002,'ح/ذمم / الموظفن / صالح','ح/ذمم / الموظفن / صالح','5',121001 );

		   
		   --  /_3
	       insert into TblAccounts values ( 1211,'الأرصدة المدينة الأخرى','الأرصدة المدينة الأخرى','3',12 );

			     --  /_4
			     insert into TblAccounts values ( 121101,'إيرادات مستحقة عند التوريد للزبون','إيرادات مستحقة عند التوريد للزبون','4', 1211);


--  /1
insert into TblAccounts values ( 2,'الإلتزامات','الإلتزامات','1',null);

    --  /2
    insert into TblAccounts values (21 ,'إلتزامات غير متداولة','إلتزامات غير متداولة','2', 2);

	       --  /_3
	       insert into TblAccounts values ( 2101,'قروض طويلة الأجل','قروض طويلة الأجل','3', 21);

		   
		   		 --  /_4
			     insert into TblAccounts values ( 210101,'قروض بنك الراجحي','قروض بنك الراجحي','4', 2101);

				 			  --  /_._5
							 insert into TblAccounts values ( 210101001,'ح/قرض/بنك الراجحي','ح/قرض/بنك الراجحي','5',210101 );


	       --  /_3
	       insert into TblAccounts values ( 2102,'إلتزامات ضريبية مؤجلة','إلتزامات ضريبية مؤجلة','3', 21);


    --  /2
    insert into TblAccounts values (22 ,'إلتزامات متداولة','إلتزامات متداولة','2', 2);

	       --  /_3
	       insert into TblAccounts values (2201 ,'دائنين','دائنين','3', 22);

		   		 --  /_4
			     insert into TblAccounts values ( 220101,'دائنين المجموعة 1','دائنين المجموعة 1','4', 2201);

				 			  --  /_._5
							 insert into TblAccounts values ( 220101001,'ح/دائن/علي محمد','ح/دائن/علي محمد','5',220101 );

							 --  /_._5
							 insert into TblAccounts values ( 220101002,'ح/دائن/هادي سعد','ح/دائن/هادي سعد','5',220101 );

	       --  /_3
	       insert into TblAccounts values ( 2202,'قروض قصيرة الأجل','قروض قصيرة الأجل','3', 22);

	       --  /_3
	       insert into TblAccounts values ( 2203,'مصروفات مستحقة','مصروفات مستحقة','3', 22);

		   --  /_3
	       insert into TblAccounts values ( 2204,'ايرادات مقدمة','ايرادات مقدمة','3', 22);

		   --  /_3
	       insert into TblAccounts values ( 2205,'أوراق دفع','أوراق دفع','3',22);
		   

		   --  /_3
	       insert into TblAccounts values ( 2206,'ضريبة مبيعات / مخرجات','ضريبة مبيعات / مخرجات','3', 22);


	       --  /_3
	       insert into TblAccounts values ( 2207,'الأرصدة الدائنة الأخرى','الأرصدة الدائنة الأخرى','3', 22);






--  /1
insert into TblAccounts values ( 3,'حقوق الملكية','حقوق الملكية','1',null);

    --  / 2
    insert into TblAccounts values ( 31,'رأس المال','رأس المال','2', 3);
	
	--  /2
	insert into TblAccounts values (311 ,'المسحوبات','المسحوبات','3',3 );

		   --  /_3
		   insert into TblAccounts values (31101 ,'حساب مسحوبات /  احمد','حساب مسحوبات /  احمد','4',311 );

		   --  /_3
		   insert into TblAccounts values (31102 ,'حساب مسحوبات /  مسفر','حساب مسحوبات /  مسفر','4',311 );


--  /1
insert into TblAccounts values (4 ,'مصروفات','مصروفات','1',null);

	--  / 2
    insert into TblAccounts values (41 ,'تكلفة المبيعات','تكلفة المبيعات','2', 4);

	       --  / _3
	       insert into TblAccounts values (4101 ,'المشتريات','المشتريات','3', 41);

	       --  / _3
	       insert into TblAccounts values ( 4102,'مصاريف المشتريات','مصاريف المشتريات','3', 41);

		   --  / _3
	       insert into TblAccounts values ( 4103,'مصاريف نقل المشتريات','مصاريف نقل المشتريات','3', 41);

		   --  / _3
	       insert into TblAccounts values ( 4104,'مردودات المشتريات','مردودات المشتريات','3', 41);

		   --  / _3
	       insert into TblAccounts values ( 4105,'خصم مكتسب','خصم مكتسب','3', 41);


	--  / 2
    insert into TblAccounts values ( 42,'مصاريف بيعية وتسويقية','مصاريف بيعية وتسويقية','2',4 );

	       --  / _3
	       insert into TblAccounts values ( 4201,'دعاية وإعلان','دعاية وإعلان','3', 42);

	       --  / _3
	       insert into TblAccounts values ( 4202,'عينات مجانية','عينات مجانية','3', 42);

	       --  / _3
	       insert into TblAccounts values ( 4203,'شحن وتوصيل الطلبيات','شحن وتوصيل الطلبيات','3', 42);

	       --  / _3
	       insert into TblAccounts values ( 4204,'بضاعة تالفة ومنتهية','بضاعة تالفة ومنتهية','3', 42);

		   --  / _3
	       insert into TblAccounts values ( 4205,'تسويات جردية','تسويات جردية','3', 42);

		   --  / _3
	       insert into TblAccounts values ( 4206,'تكاليف التغليف','تكاليف التغليف','3', 42);


	--  / 2
    insert into TblAccounts values ( 43,'مصاريف تشغيلية','مصاريف تشغيلية','2', 4);

		   --  / _3
	       insert into TblAccounts values ( 4301,'المحروقات','المحروقات','3', 43);


	       --  / _3
	       insert into TblAccounts values ( 4302,'الرواتب والاجور','الرواتب والاجور','3', 43);


	       --  / _3
	       insert into TblAccounts values ( 4303,'إيجار','إيجار','3', 43);

		   
		   	       --  / _4
	              insert into TblAccounts values ( 430301,'ايجارات مدينة جدة','ايجارات مدينة جدة','4', 4303);

				  		   --  / _5
	                       insert into TblAccounts values ( 430301001,'ح/ايجار /العمارة 1','ح/ايجار /العمارة 1','5', 430301);

						   --  / _5
	                       insert into TblAccounts values ( 430301002,'ح/ايجار /العمارة 1','ح/ايجار /العمارة 1','5', 430301);


	       --  / _3
	       insert into TblAccounts values ( 4304,'كهرباء','كهرباء','3', 43);

	       --  / _3
	       insert into TblAccounts values ( 4305,'شركات الإتصالات','شركات الإتصالات','3',43 );

	       --  / _3
	       insert into TblAccounts values ( 4306,'ماء','ماء','3', 43);

	       --  / _3
	       insert into TblAccounts values ( 4307,'صيانة','صيانة','3', 43);



	--  / 2
    insert into TblAccounts values ( 44,'مصاريف إدارية وعمومية','مصاريف إدارية وعمومية','2', 4);

	       --  / _3
	       insert into TblAccounts values ( 4401,'رسوم حكومية','رسوم حكومية','3', 44);

	       --  / _3
	       insert into TblAccounts values ( 4402,'غرامات','غرامات','3', 44);

		    --  / _3
	       insert into TblAccounts values ( 4403,'التأمين الصحي','التأمين الصحي','3',44 );

		   --  / _3
	       insert into TblAccounts values ( 4404,'نظافة','نظافة','3', 44);

		   --  / _3
	       insert into TblAccounts values ( 4405,'قرطاسية ومطبوعات','قرطاسية ومطبوعات','3',44 );


	--  / 2
    insert into TblAccounts values ( 45,'المخصصات','المخصصات','2',4 );

			     --  /_3
			     insert into TblAccounts values ( 4501,'مصروف إهلاك المباني','مصروف إهلاك المباني','3', 45);

			     --  /_3
			     insert into TblAccounts values ( 4502,'مصروف إهلاك الآلات والمعدات','مصروف إهلاك الآلات والمعدات','3', 45);

			     --  /_3
			     insert into TblAccounts values ( 4503,'مصروف إهلاك السيارات','مصروف إهلاك السيارات','3', 45);

			     --  /_3
			     insert into TblAccounts values ( 4504,'مصروف إهلاك الأثاث','مصروف إهلاك الأثاث','3', 45);


--  /1
insert into TblAccounts values (5 ,'إيرادات','إيرادات','1',null);

	--  / 2
	insert into TblAccounts values ( 51,'المبيعات','المبيعات','2', 5);

		   --  / _3
		   insert into TblAccounts values ( 5101,'حساب المبيعات','حساب المبيعات','3', 51);

		   --  / _3
		   insert into TblAccounts values ( 5102,'مردودات مبيعات','مردودات مبيعات','3',51 );

		   --  / _3
		   insert into TblAccounts values ( 5103,'الخصم المسموح به','الخصم المسموح به','3',51 );


	--  / 2
    insert into TblAccounts values ( 52,'إيرادات متنوعة','إيرادات متنوعة','2',5 );

	       --  / _3
	       insert into TblAccounts values ( 5201,'إيرادات إستثمارات','إيرادات إستثمارات','3', 52);

		   --  / _3
	       insert into TblAccounts values ( 5202,'خصومات على الموظفين','خصومات على الموظفين','3', 52);

		   --  / _3
	       insert into TblAccounts values ( 5203,'فوائض نقدية','فوائض نقدية','3', 52);

----  /1
--insert into TblAccounts values (6 ,'التدفقات النقدية','التدفقات النقدية','1',null);

GO




----*  248  *----------( الحسابات المعيارية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblStandardAccounts --  انشاء جدول الحسابات المعيارية 
(
StandardAccountNo int primary key ,--------------------------------------------------------- رقم الحساب المعياري  
AccountNameEN varchar(100),------------------------------------------------- اسم الحساب بالانجليزي
AccountNameAR varchar(100),--------------------------------------------------- اسم الحساب بالعربي
AccountInformations varchar(250), -------------------------------------- معلومات الحساب
AccountNo int --------------------------------------------------------- رقم الحساب المحاسبي  
);

--  ربط حقل رقم الحساب الاعلى بحقل رقم الحساب في جدول الحسابات المحاسبية    
alter table TblStandardAccounts
add constraint PK_TblStandardAccounts_TblAccounts_AccountNo foreign key (AccountNo) references TblAccounts(AccountNo) on delete set null on update CASCADE ;

GO
insert into TblStandardAccounts values (1 , 'Assets' , 'الأصول' ,'', 1);
insert into TblStandardAccounts values (2 , 'Liabilities' , 'الإلتزامات' ,'', 2);
insert into TblStandardAccounts values (3 , 'Property rights' , 'حقوق الملكية' ,'', 3);
insert into TblStandardAccounts values (4 , 'Expenses' , 'المصروفات' ,'', 4);
insert into TblStandardAccounts values (5 , 'Revenues' , 'الإيرادات' ,'', 5);
insert into TblStandardAccounts values (6 , '' , '' ,'', null);

insert into TblStandardAccounts values (7 , 'Sales Account' , 'حساب المبيعات' ,'', 5101);
insert into TblStandardAccounts values (8 , 'Notes Receivable Account' , 'حساب أوراق القبض' ,'', 1202);
insert into TblStandardAccounts values (9 , 'Payable bills account' , 'حساب أوراق الدفع' ,'', 2205);
insert into TblStandardAccounts values (10 , 'output tax' , 'ضريبة المدخلات' ,'', 1207);
insert into TblStandardAccounts values (11 , 'output tax' , 'ضريبة المخرجات' ,'', 2206);
insert into TblStandardAccounts values (12 , 'Revenue Account Due On Supply' , 'حساب إيرادات تستحق عند التوريد' ,'', 121101); -- عند وجود دفعة اولى وباقي الفاتورة في مراحل
insert into TblStandardAccounts values (13 , 'cash income/surplus' , 'إيرادات / فوائض نقدية' ,'', 5203); -- عند عمل جرد للخزينه وايجاد فائض يسجل هنا
insert into TblStandardAccounts values (14 , 'The main account for employee receivables in the branch' , 'الحساب الرئيسي لذمم الموظفين بالفرع' ,'', 1210); -- لاضافة حساب ذمم للمظف بشكل اوتوماتيكي
--delete from TblStandardAccounts
GO

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

----*  246  *----------( الحسابات البنكية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblBankAccounts 
(
Number int primary key identity(1,1),  -- الرقم
BranchNumber int,                   -- رقم الفرع
AccountHoldersName varchar(50),   -- اسم  الحساب
Bank varchar(50),   -- ........... البنك
BankAccountNumber varchar(50) , -- رقم الحساب البنكي
IBAN varchar(50), -- رقم الايبان
AccountNo int -- رقم الحساب المحاسبي
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
insert into TblBankAccounts values (1,'حساب الفرع الرئيسي','مصرف الراجحي','sa654654658','sa_6546545666666',120101001);
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
insert into TblCashBoxes values (1,'box 505',120102003);
GO
----*  246  *----------( وحدات العمليات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

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
insert into TblOperationUnits values (1,'device no 1','BFBFFCE99BF99000',120102001);
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
AccountNo int -- رقم  حساب ذمم الموظف في جدول الحسابات المحاسبية
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
insert into TblEmployees values ('ايهم','AIHAM',1,1,null,121001001);
insert into TblEmployees values ('صالح','SALEH',1,1,null,121001002);
GO
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
insert into TblClients values ('محمد سالم','mohd salem',1,null,'','',0,0,null,1,'','','','','','','','',120401001);
insert into TblClients values ('علي صالح','ali saleh',1,null,'','',0,0,null,1,'','','','','','','','',120401001);
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
insert into TblObjects values ('الموظفين','Employees');
insert into TblObjects values ('العملاء','Clients');
insert into TblObjects values ('قيود اليومية','Journal Entry');
insert into TblObjects values ('الورديات','Shifts');
insert into TblObjects values ('وحدات العمليات','Operation Units');
insert into TblObjects values ('الحسابات البنكية','Bank Accounts');
insert into TblObjects values ('صناديق النقدية','Cash Boxes');
insert into TblObjects values ('المبيعات','Sales');
insert into TblObjects values ('الحسابات المعيارية','Standard Accounts');
insert into TblObjects values ('عمليات المخزون','Inventory Operations');

GO


----***  241  ***----------( مجموعات صلاحيات المستخدمين )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table TblUsersPermissionsGroup
(
PermissionGroupNo int primary key identity(1,1),  -- رقم مجموعة الصلاحيات
PermissionGroupNameAR varchar(100),   -- اسم مجموعة الصلاحيات عربي
PermissionGroupNameEN varchar(100)   -- اسم مجموعة الصلاحيات انجليزي
)

GO
insert into TblUsersPermissionsGroup values ('مدير','admin');

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
insert into TblPermissions values (1,1,1,1,1,1);
insert into TblPermissions values (2,1,1,1,1,1);
insert into TblPermissions values (3,1,1,1,1,1);
insert into TblPermissions values (4,1,1,1,1,1);
insert into TblPermissions values (5,1,1,1,1,1);
insert into TblPermissions values (6,1,1,1,1,1);
insert into TblPermissions values (7,1,1,1,1,1);
insert into TblPermissions values (8,1,1,1,1,1);
insert into TblPermissions values (9,1,1,1,1,1);
insert into TblPermissions values (10,1,1,1,1,1);
insert into TblPermissions values (11,1,1,1,1,1);
insert into TblPermissions values (12,1,1,1,1,1);
insert into TblPermissions values (13,1,1,1,1,1);
insert into TblPermissions values (14,1,1,1,1,1);
insert into TblPermissions values (15,1,1,1,1,1);
insert into TblPermissions values (16,1,1,1,1,1);
insert into TblPermissions values (17,1,1,1,1,1);
insert into TblPermissions values (18,1,1,1,1,1);
insert into TblPermissions values (19,1,1,1,1,1);
insert into TblPermissions values (20,1,1,1,1,1);
insert into TblPermissions values (21,1,1,1,1,1);
insert into TblPermissions values (22,1,1,1,1,1);
insert into TblPermissions values (23,1,1,1,1,1);
insert into TblPermissions values (24,1,1,1,1,1);
insert into TblPermissions values (25,1,1,1,1,1);
insert into TblPermissions values (26,1,1,1,1,1);
insert into TblPermissions values (27,1,1,1,1,1);
insert into TblPermissions values (28,1,1,1,1,1);
insert into TblPermissions values (29,1,1,1,1,1);

GO
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
insert into TblUsersAccounts values ('a','a',1,1,1);
GO
----*  247  *----------( قيود اليومية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
-- تم وضعها في هذا المكان بسبب العلاقات مع جداول المشتريات والمبيعات ومرتجعات المشتريات ومرتجعات المبيعات

CREATE TABLE TblJournalEntry  -- جدول ارقام قيود اليومية
(
JournalEntryNo int primary key identity(1,1) ,--------رقم قيد اليومية//   رقم القيد المحاسبي الرئيسي في سجل اليومية
EntryDateTime datetime default getdate() ,------------ قيد التاريخ والوقت تم التعديل بتاريخ 2021/9/24
AccountingEntrytStatement varchar(300)----------------------- بيان القيد المحاسبي
)
GO
--insert into TblJournalEntry values ('2001/1/1 9:20 PM','مبيعات');  

--GO


----*  247  *----------( اجراء مخزن لانشاء قيد محاسبي رئيسي )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc psJournalEntry  -- جدول ارقام قيود اليومية
@EntryDateTime datetime ,------------ قيد التاريخ والوقت تم التعديل بتاريخ 2021/9/24
@AccountingEntrytStatement varchar(300) , ----------------------- بيان القيد المحاسبي
@JournalEntryNo int out --------رقم قيد اليومية//   رقم القيد المحاسبي الرئيسي في سجل اليومية
as
begin
insert into TblJournalEntry values (@EntryDateTime,@AccountingEntrytStatement); 
set @JournalEntryNo =  SCOPE_IDENTITY();
return @JournalEntryNo
end

GO

--select TblSubJournalEntry.SubJornalEntryNo,TblAccounts.AccountNameAR,TblAccounts.AccountNameEN,TblSubJournalEntry.DebitValue,TblSubJournalEntry.CreditValue from TblSubJournalEntry inner join TblAccounts on TblAccounts.AccountNo = TblSubJournalEntry.AccountNo


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

---->>>>>>>>>>>>>> تسجيل قيود محاسبية جديدة
--insert into TblJournalEntry (AccountingEntrytStatement) values ('استثمار مبدئي')-- 1    
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (1,120101001,0,25000 , 'من حساب الراجحي')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (1,120101002,0,25000 , 'من حساب الاهلي')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (1,31,50000,0 , 'الى حساب راس المال')


---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values (' شراء 10 كراسي')-- 2
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (2,110105001,0,1000 , 'من حساب اثاث الفرع الرئيسي')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (2,120101001,500,0 , ' الى حساب الراجحي')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (2,120101002,500,0 , ' الى حساب حساب الاهلي')

---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values ('استثمار اضافي')-- 3
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (3,120101001,0,5000 , ' من حساب الراجحي  ')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (3,120101002,0,13000 , ' من حساب الاهلي  ')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (3,31,18000,0 , 'الى حساب راس مال')



---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values ('بيع اثاث')-- 4
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (4,120101001,0,300 , 'من حساب الراجحي ')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (4,110105001,300,0 , 'الى حساب اثاث الفرع الرئيسي')

---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values ('شراء 10 كتب')-- 5
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (5,120301,0,2000 , 'من حساب المخزون')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (5,120101002,2000,0 , ' الى حساب  الاهلي')


---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values ('اثبات مسحوبات')-- 6
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (6,31101,0,200 , '  من حساب مسحوبات احمد')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (6,120101002,200,0 , ' الى حساب  الاهلي')


---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values ('اثبات مصروفات')-- 7
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (7,430201001,0,2000 , '  من حساب راتب خالد')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (7,430201002,0,1500 , '  من حساب راتب ايهم')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (7,430301001,0,1500 , '  من حساب ايجار العمارة رقم 1')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (7,120101002,5000,0 , 'الى حساب الاهلي')


---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values ('مشتريات على الحساب')-- 8
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (8,120301,0,3500 , 'من حساب المخزون')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (8,220101001,3500,0 , 'الى حساب الدائنين علي محمد')

---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values ('استخراج قرض من البنك الراجحي')-- 9
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (9,120102003,0,6000 , '  من حساب صندوق النقدية رقم 505 ')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (9,210101001,6000,0 , 'الى ح/ قرض / بنك الراجحي')


---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values ('بيع سلع لمستفيد على الحساب')-- 10
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (10,120401002,0,6000 , '  من حساب /مدين/ علي صالح')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (10,1203,6000,0 , 'الى حساب المخزون')

---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values ('قام احمد بسحب 500 ريال')-- 11
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (11,31101,0,6000 , '  من حساب مسحوبات احمد')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (11,120101002,6000,0 , 'الى حساب الاهلي')

---->>>>>>>>>>>>>>
--insert into TblJournalEntry (AccountingEntrytStatement) values ('مبيعات')-- 12
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (11,120101002,0,15000 , '  من الاهلي')
--insert into TblSubJournalEntry (JournalEntryNo,AccountNo,CreditValue,DebitValue,AccountingEntrytStatement) values (11,5101,15000,0 , 'الى حساب الاهلي')


--GO

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

-- ( ربط حقل رقم العميل بالحقل المقابل في جدول العملاء  )
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
TotalBill decimal(8,2) -- اجمالي الفاتورة
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

create proc SpSalesBill 
@RegistrationDateAndTime datetime , -- تاريخ ووقت التسجيل
@SalesCartNo int , -- رقم سلة المبيعات
@JournalEntryNo int , -- رقم قيد اليومية
@ShiftNumber int , -- رقم الوردية
@TotalBill decimal(8,2), -- اجمالي الفاتورة
@SalesInvoiceNumber int OUT -- رقم فاتورة البيع
as
begin
  insert into TblSalesBill (RegistrationDateAndTime , SalesCartNo , JournalEntryNo , ShiftNumber , TotalBill ) values ( @RegistrationDateAndTime , @SalesCartNo , @JournalEntryNo , @ShiftNumber , @TotalBill ) ;
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
ShiftNumber int, -- رقم الوردية
OnDelivery decimal(8,2)  -- المبلغ المطلوب عند التسليم
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
@ShiftNumber int , -- رقم الوردية
@OnDelivery decimal(8,2) -- المبلغ المطلوب عند التسليم
as
begin
insert into TblReceiptVouchers ( RegistrationDateAndTime , SalesInvoiceNumber , ClientsNo , cash , Bank , BankCheck , DeferredPayment , JournalEntryNo , ShiftNumber , OnDelivery ) values ( @RegistrationDateAndTime , @SalesInvoiceNumber , @ClientsNo , @cash , @Bank , @BankCheck , @DeferredPayment , @JournalEntryNo , @ShiftNumber , @OnDelivery)
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


----*  301  *----------( عرض  شجرة الحسابات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

-- Statement of financial position = SOFP 
create view SOFPAccountsView 
as 
SELECT LEVE004.* , iif(F.AccountNo is null,LEVE004.E1,F.AccountNo) as F1 , iif(F.AccountNameEN is null,LEVE004.E2,F.AccountNameEN) as F2 , iif(F.AccountNameAR is null,LEVE004.E3,F.AccountNameAR) as F3 , iif(F.AccountInformations is null,LEVE004.E4,F.AccountInformations) as F4 , iif(F.TopAccountNo is null,LEVE004.E5,F.TopAccountNo) as F5     
FROM (
SELECT LEVE003.* , iif(E.AccountNo is null,LEVE003.D1,E.AccountNo) as E1 , iif(E.AccountNameEN is null,LEVE003.D2,E.AccountNameEN) as E2 , iif(E.AccountNameAR is null,LEVE003.D3,E.AccountNameAR) as E3 , iif(E.AccountInformations is null,LEVE003.D4,E.AccountInformations) as E4 , iif(E.TopAccountNo is null,LEVE003.D5,E.TopAccountNo) as E5 
FROM (
SELECT LEVE002.*,iif(D.AccountNo is null,LEVE002.C1,D.AccountNo) as D1 , iif(D.AccountNameEN is null,LEVE002.C2,D.AccountNameEN) as D2 , iif(D.AccountNameAR is null,LEVE002.C3,D.AccountNameAR) as D3 , iif(D.AccountInformations is null,LEVE002.C4,D.AccountInformations) as D4 , iif(D.TopAccountNo is null,LEVE002.C5,D.TopAccountNo) as D5     
 FROM (
select * from ( select A.AccountNo as A1 , A.AccountNameEN as A2 , A.AccountNameAR as A3 , A.AccountInformations as A4 , A.TopAccountNo as A5   ,   
B.AccountNo as B1 , B.AccountNameEN as B2 , B.AccountNameAR as B3 , B.AccountInformations as B4 , B.TopAccountNo as B5   , 
iif(C.AccountNo is null,  B.AccountNo ,C.AccountNo) as C1 , iif(C.AccountNameEN is null,B.AccountNameEN,C.AccountNameEN) as C2 , iif(C.AccountNameAR is null,B.AccountNameAR,C.AccountNameAR) as C3 , iif(C.AccountInformations is null,B.AccountInformations,C.AccountInformations) as C4 , iif(C.TopAccountNo is null,B.TopAccountNo,C.TopAccountNo) as C5   

from TblAccounts A
left outer join TblAccounts B  on A.AccountNo = B.TopAccountNo
left outer join TblAccounts C on B.AccountNo =  C.TopAccountNo
) AS level001 
where a1 in (1,2,3,4,5,6)
)AS LEVE002
left outer join TblAccounts D on LEVE002.C1 =  D.TopAccountNo
)AS LEVE003
left outer join TblAccounts E on LEVE003.D1 =  E.TopAccountNo
) AS LEVE004
left outer join TblAccounts F on LEVE004.E1 =  F.TopAccountNo

GO


----*  302  *----------( انشاء استعلام يمثل سجل اليومية )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create view jornalShow
as 
select TblJournalEntry.JournalEntryNo  ,  TblJournalEntry.EntryDateTime  ,  TblJournalEntry.AccountingEntrytStatement as AccountingEntrytStatementMain ,
TblSubJournalEntry.SubJornalEntryNo  ,  TblSubJournalEntry.AccountNo  ,
TblAccounts.AccountNameAR  , TblSubJournalEntry.CreditValue  ,  TblSubJournalEntry.DebitValue , TblSubJournalEntry.AccountingEntrytStatement as AccountingEntrytStatementSub

from TblJournalEntry 
inner join TblSubJournalEntry on TblJournalEntry.JournalEntryNo = TblSubJournalEntry.JournalEntryNo
inner join TblAccounts on  TblAccounts.AccountNo = TblSubJournalEntry.AccountNo ;

GO


----*  304 - 305 - 306 - 307 - 308 - 309  *----------( استعلامات ميزان المراجعة بالمستويات للعمليات وليس للعرض  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

-- ميزان المراجعة المستوى الاول
create view TrialBalance_1 
as
select a1,a2,a3,a4,a5,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit  
from
(
select a1,a2,a3,a4,a5,sum(CreditValue) as credit,sum(DebitValue) as Debit  
from  SOFPAccountsView
inner join jornalShow  on jornalShow.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5
)as level001

GO

-- ميزان المراجعة المستوى الثاني
create view TrialBalance_2 
as
select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit 
from
(select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,sum(CreditValue) as credit,sum(DebitValue) as Debit  
from  SOFPAccountsView
inner join jornalShow  on jornalShow.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5,b1,b2,b3,b4,b5)as level001

GO

-- ميزان المراجعة المستوى الثالث
create view TrialBalance_3 
as
 select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit 
 from
 (select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,sum(CreditValue) as credit,sum(DebitValue) as Debit 
from  SOFPAccountsView
inner join jornalShow  on jornalShow.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5) as level001

GO

-- ميزان المراجعة المستوى الرابع
create view TrialBalance_4 
as
select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit 
from
(select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,sum(CreditValue) as credit,sum(DebitValue) as Debit 
from  SOFPAccountsView
inner join jornalShow  on jornalShow.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5) as level001

GO

-- ميزان المراجعة المستوى الخامس
create view TrialBalance_5 
as
select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit 
from
(select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5,sum(CreditValue) as credit,sum(DebitValue) as Debit 
from  SOFPAccountsView
inner join jornalShow  on jornalShow.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5) as level001

GO

-- ميزان المراجعة المستوى السادس
create view TrialBalance_6 
as
select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5,f1,f2,f3,f4,f5 ,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as Debit 
from
(select a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5,f1,f2,f3,f4,f5,sum(CreditValue) as credit,sum(DebitValue) as Debit 
from  SOFPAccountsView
inner join jornalShow  on jornalShow.AccountNo in (SOFPAccountsView.a1,SOFPAccountsView.b1,SOFPAccountsView.c1,SOFPAccountsView.d1,SOFPAccountsView.e1,SOFPAccountsView.f1)
GROUP BY a1,a2,a3,a4,a5,b1,b2,b3,b4,b5,c1,c2,c3,c4,c5,d1,d2,d3,d4,d5,e1,e2,e3,e4,e5,f1,f2,f3,f4,f5 ) as level001
where credit <> Debit
GO

--delete from TblSubJournalEntry
--delete from TblJournalEntry

------*  310  *----------( انشاء استعلام لعرض ميزان المراجعة  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create view TrialBalanceView
as 
select TrialBalance_6.a1  ,TrialBalance_6.a2  ,TrialBalance_6.a3  ,  TrialBalance_6.b1  ,  TrialBalance_6.c1  ,  TrialBalance_6.d1  ,  TrialBalance_6.e1  ,  TrialBalance_6.f1  ,  TrialBalance_6.f2  ,  TrialBalance_6.f3  ,  TrialBalance_6.credit  ,  TrialBalance_6.Debit from TrialBalance_6
union 
select 7 as a1  ,  'total' as a2  ,  'المجموع' as a3  ,  0 as b1,  0 as c1,  0 as d1  ,  0 as e1  ,  0 as f1  ,  'total' as f2  ,  'المجموع' as f3  , sum(TrialBalance_6.credit)  as credit,  sum(TrialBalance_6.Debit) as Debit from TrialBalance_6 ;
GO


----*  312  *----------( انشاء استعلام قائمة الدخل  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create view IncomeList
as
select  TrialBalance_6.a1  ,TrialBalance_6.a2  ,TrialBalance_6.a3  ,  TrialBalance_6.b1  ,  TrialBalance_6.c1  ,  TrialBalance_6.d1  ,  TrialBalance_6.e1  ,  TrialBalance_6.f1  ,  TrialBalance_6.f2  ,  TrialBalance_6.f3   ,  TrialBalance_6.credit  ,  TrialBalance_6.Debit  from TrialBalance_6 where TrialBalance_6.a1 in (select TblStandardAccounts.AccountNo from TblStandardAccounts where TblStandardAccounts.StandardAccountNo in (4,5))
union
select 7 as a1  ,'net profit or loss' as a2  ,'صافي الربح او الخسارة' as a3  ,  0 as b1  ,  0 as c1  ,  0 as d1  ,  0 as e1  ,  0 as f1  ,  'net profit or loss' as f2  ,  'صافي الربح او الخسارة' as f3 ,iif(credit-Debit>=0,credit-Debit,0) as credit,iif(Debit-credit>=0,Debit-credit,0) as debit
from
(select  7 as a1  ,'sum of each side' as a2  ,'مجموع كل جانب' as a3  ,  0 as b1  ,  0 as c1  ,  0 as d1  ,  0 as e1  ,  0 as f1  ,  'total' as f2  ,  'المجموع' as f3  ,sum(TrialBalance_6.credit) as credit,sum(TrialBalance_6.Debit) as debit from TrialBalance_6 where TrialBalance_6.a1 in (4,5) )as xx
GO

----*  313  *----------( انشاء استعلام لعرض قائمة التغيرات في حقوق الملكية  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create view OwnersEquityList as 
--1
select 1 as orderby, a1,b1 ,c1,d1,e1,f1,f2,f3, sum(credit)as credit ,sum(debit) as debit from TrialBalance_6 where TrialBalance_6.a1 in (select TblStandardAccounts.AccountNo from TblStandardAccounts where TblStandardAccounts.StandardAccountNo in (3))  group by a1,b1 ,c1,d1,e1,f1,f2,f3 
--2
union all
--3
select 2 as orderby,0 as a1,0 as b1 ,0 as c1,0 as d1,0 as e1,0 as f1,'مجموع كل جانب' as f2,'مجموع كل جانب' as f3, sum(credit2)as credit ,sum(debit2) as debit from 
(
select  a1,b1 ,c1,d1,e1,f1,f2,f3, sum(credit)as credit2 ,sum(debit) as debit2 from TrialBalance_6 where TrialBalance_6.a1 in (select TblStandardAccounts.AccountNo from TblStandardAccounts where TblStandardAccounts.StandardAccountNo in (3))  group by a1,b1 ,c1,d1,e1,f1,f2,f3 
) as level2001 
--4
union all
--5
select 3 as orderby,0 as a1,0 as b1 ,0 as c1,0 as d1,0 as e1,0 as f1,'ترصيد' as f2,'ترصيد' as f3, iif( sum(credit)-sum(debit) >=0 ,sum(credit)-sum(debit),0)as credit ,iif( sum(debit)-sum(credit) >=0 ,sum(debit)-sum(credit),0) as debit
from (
select 2 as orderby,0 as a1,0 as b1 ,0 as c1,0 as d1,0 as e1,0 as f1,'مجموع كل جانب' as f2,'مجموع كل جانب' as f3, sum(credit2)as credit ,sum(debit2) as debit from 
(
select  a1,b1 ,c1,d1,e1,f1,f2,f3, sum(credit)as credit2 ,sum(debit) as debit2 from TrialBalance_6 where TrialBalance_6.a1 in (select TblStandardAccounts.AccountNo from TblStandardAccounts where TblStandardAccounts.StandardAccountNo in (3))  group by a1,b1 ,c1,d1,e1,f1,f2,f3 
) as level2001 
) as level2002
--6
union all
--7
select 4 as orderby,0 as a1,b1 ,c1,d1,e1,f1,'الأرباح والخسائر' as f2,'الأرباح والخسائر' as f3, credit , debit from IncomeList WHERE a1 =7
--8
union all
--9
select 5 as orderby, a1 , b1 , c1,  d1, e1, f1,'رأس مال آخر المدة' as f2,'رأس مال آخر المدة' as f3, sum(credit)as credit ,sum(debit) as debit
from (
select 3 as orderby,0 as a1,0 as b1 ,0 as c1,0 as d1,0 as e1,0 as f1,'ترصيد' as f2,'ترصيد' as f3, iif( sum(credit)-sum(debit) >=0 ,sum(credit)-sum(debit),0)as credit ,iif( sum(debit)-sum(credit) >=0 ,sum(debit)-sum(credit),0) as debit
from (
select 2 as orderby,0 as a1,0 as b1 ,0 as c1,0 as d1,0 as e1,0 as f1,'مجموع كل جانب' as f2,'مجموع كل جانب' as f3, sum(credit2)as credit ,sum(debit2) as debit from 
(
select  a1,b1 ,c1,d1,e1,f1,f2,f3, sum(credit)as credit2 ,sum(debit) as debit2 from TrialBalance_6 where TrialBalance_6.a1 in (select TblStandardAccounts.AccountNo from TblStandardAccounts where TblStandardAccounts.StandardAccountNo in (3))  group by a1,b1 ,c1,d1,e1,f1,f2,f3 
) as level2001 
) as level2002
union all
select 4 as orderby,0 as a1,b1 ,c1,d1,e1,f1,'الأرباح والخسائر' as f2,'الأرباح والخسائر' as f3, credit , debit from IncomeList WHERE a1 =7
) as level2003 group by a1 , b1 , c1,  d1, e1, f1




GO

----*  314  *----------( انشاء استعلام لعرض قائمة المركز المالي )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create view  StatementOfFinancialPosition
as
select 4 as orderby,a1,b1,c1,d1,e1,f1,f2,f3,credit,debit from TrialBalance_6 where TrialBalance_6.a1 in (select TblStandardAccounts.AccountNo from TblStandardAccounts where TblStandardAccounts.StandardAccountNo in (1,2))
union 
select  orderby,0 as a1,0 as b1,0 as c1,0 as d1,0 as e1,0 as f1,f2,f3,credit ,debit  from OwnersEquityList where orderby = 5
union
select  6 as orderby,0 as a1,0 as b1,0 as c1,0 as d1,0 as e1,0 as f1,'الرصيد' as f2,'الرصيد' as f3, sum(credit) as credit,sum(Debit)as Debit from
(
 select 0 as orderby,a1,b1,c1,d1,e1,f1,f2,f3,credit,debit from TrialBalance_6 where TrialBalance_6.a1 in (select TblStandardAccounts.AccountNo from TblStandardAccounts where TblStandardAccounts.StandardAccountNo in (1,2))
 union 
 select  orderby,a1,b1,c1,d1,e1,f1,f2,f3,credit ,debit  from OwnersEquityList where orderby = 5
)as level004 ;

GO
select f1,f2,f3,credit,debit from StatementOfFinancialPosition 
--select * from TrialBalance_6 -- ميزان المراجعة المستوى السادس
--select * from jornalShow -- سجل اليومية

--select * from TblShifts


----select TblOperationUnits.AccountNo from TblShifts
----inner join TblOperationUnits on TblOperationUnits.OperationUnitNumber = TblShifts.OperationUnitNumber
----where ShiftNumber = 32

----GO
----select * from TblOperationUnits
------ حذف الورديات وجميع المبيعات والقيود
--delete from TblReceiptVouchers
--delete from TblSalesBill
--delete from TblSalesCartDetails
--delete from TblSaleCarts
--delete from TblSubJournalEntry
--delete from TblJournalEntry
--delete from TblShifts
----   delete from TblOperationUnits -- حذف وحدة العمليات

----select * from TblShifts inner join TblOperationUnits on TblShifts.OperationUnitNumber = TblOperationUnits.OperationUnitNumber

--select * from TblOperationUnits
--select * from TblOperationUnits where DeviceNumber = 'BFEBFBFF000A0655'
--select * from OperationUnitNumber where OperationUnitNumber = 11 and ShiftStatus  in (1,2) 

--select * from TblShifts 
--select * from TblClients 

--inner join TblUsersAccounts on TblShifts.UserAccountNo = TblUsersAccounts.UserAccountNo 
--inner join TblEmployees on TblEmployees.EmployeeNo = TblUsersAccounts.EmployeeNo
--where TblShifts.ShiftStatus = 2

--select * from TblStandardAccounts


--select * from TblShifts inner join TblOperationUnits on TblShifts.OperationUnitNumber = TblOperationUnits.OperationUnitNumber
--select * from TblOperationUnits  where DeviceNumber = '' 

--select * from TblShifts inner join TblOperationUnits on TblShifts.OperationUnitNumber = TblOperationUnits.OperationUnitNumber


 ----*  315  *----------( استعلام دفتر الاستاذ )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

declare @AccountNo int , @AccountNameEN VARCHAR(100)  , @AccountNameAR VARCHAR(100)
set @AccountNo = 120101002
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

