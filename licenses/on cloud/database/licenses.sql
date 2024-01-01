
----*  0  *----------( انشاء قاعدة البيانات)---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create database licenses;                                          --  انشاء قاعدة بيانات المبيعات 

GO

ALTER DATABASE licenses COLLATE Arabic_CI_AS;                      --  تغيير الترميز او الكوليجن لتتعرف قاعدة البيانات على اللغة العربية  

GO

--use master
--go
--alter database licenses set single_user with rollback immediate
--drop database licenses
--GO

use licenses ;

GO

----*  1  *----------( الاجهزة)---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table tbl001_devices
(
 c001_deviceAuotoNo int identity primary key , -- الرقم المتسلسل للجهاز
 c002_DeviceNo varchar(50),                    -- رقم الجهاز
 c003_HardiceNo varchar(50),                   -- رقم الهارديسك
 c004_ProcessorNo varchar(50)                 -- رقم المعالج

);
GO
----*  2  *----------( الحسابات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table tbl002_Accounts  
(
 c001_AccountNo int identity primary key,  -- رقم الحساب
 c002_userName varchar(20) unique ,        -- اسم المستخدم
 c003_password varchar(20) ,               -- كلمة المرور
 c004_ClientName varchar(100),             -- اسمل العميل
 c005_ClientPhone varchar(20),             -- رقم جوال العميل
 c006_ClientEmail varchar(50),             -- ايميل العميل
 c007_ShortAddress varchar(20),            -- العنوان المختصر 
 c008_BuildingNo varchar(20),              -- رقم المبنى
 c009_Street varchar(20),                  -- الشارع
 c010_SecondaryNo  varchar(20),            -- الرقم الفرعي
 c011_District  varchar(20),               -- الحي
 c012_PostalCode varchar(20),              -- الرمز البريدي
 c013_City varchar(50),                    -- المدينة
 c014_country  varchar(50),                -- الدولة
);
GO

----*  3  *----------( البرامج واسعارها )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table tbl008Packages
(
c001_package varchar(100) primary key ,
c002_price decimal(7,2) default 0 , 
c003_programName varchar(50) ,         --  اسم البرنامج
c004_PackageDuration INT  ,          -- مدة الرخصة
c005_packageDevicesCount int ,       -- عدد الاجهزة
c006_information varchar(200)       -- معلومات الرخصة
);
GO
insert into tbl008Packages values ('Mesrakh-365day-1device',1500,'mesrakh',365,1,'برنامج المبيعات مصراخ لمدة سنة وعدد واحد جهاز');
insert into tbl008Packages values ('Mesrakh-365day-5devices',3500,'mesrakh',365,5,'برنامج المبيعات مصراخ لمدة سنة وعدد خمسة اجهزة');
insert into tbl008Packages values ('Mesrakh-730day-1devices',2300,'mesrakh',730,1,'برنامج المبيعات مصراخ لمدة سنتين وعدد واحد جهاز');
GO
--select * from tbl008Packages
----*  4  *----------( الرخص)---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table tbl003_licenses 
(
 c001_licenseNo int identity primary key,         -- رقم الرخصة
 c002_PackageName varchar(100),                    -- اسم الباقة
 c003_DateOfLicenseRequest datetime,              -- تاريخ طلب الترخيص
 c004_DateOfLicenseStart datetime default '2000-1-1' ,                -- تاريخ بداية الترخيص
 c005_DevicesCount int default 1,                          -- عدد الاجهزة
 c006_termOfThelicenseByDays int default 0 ,      -- مدة الترخيص بالايام
 c007_LicenseEndDate datetime default '2000-1-1' ,                    --  تاريخ نهاية الترخيص
 c008_AccountNo int                               -- رقم العميل
 );

alter table tbl003_licenses
add constraint PK003008T002001 foreign key (c008_AccountNo) references  tbl002_Accounts(c001_AccountNo) ;


alter table tbl003_licenses
add constraint PK003002T008001 foreign key (c002_PackageName) references  tbl008Packages(c001_package) ;
GO

 ----*  5  *----------(  ربط الاجهزة بالرخص  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table tbl004_licenseAndDevices
(
c001_linkNo int identity primary key ,  -- رقم الربط
c002_deviceAuotoNo int,                 -- الرقم الخاص للجهاز
c003_licensNo int ,                       -- رقم الرخصة
 c005_location varchar(100),                   -- موقع الجهاز
 c006_deviceUses varchar(100)                  -- استخدامات الجهاز
)

alter table tbl004_licenseAndDevices
add constraint PK004002TO001001 foreign key (c002_deviceAuotoNo) references tbl001_devices(c001_deviceAuotoNo)  ;

alter table tbl004_licenseAndDevices
add constraint PK004003TO003001 foreign key (c003_licensNo) references tbl003_licenses(c001_licenseNo)  ;
GO

--select * from tbl008Packages 
--inner join tbl003_licenses on tbl003_licenses.c002_PackageName = tbl008Packages.c001_package 
--inner join tbl004_licenseAndDevices on tbl004_licenseAndDevices.c003_licensNo =tbl003_licenses.c001_licenseNo 
--inner join tbl001_devices on tbl001_devices.c001_deviceAuotoNo = tbl004_licenseAndDevices.c002_deviceAuotoNo

----*  6  *----------( الفواتير )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create table tbl007_invoices
(
 c001_invoiceNumber int identity(1,1) primary key ,                         -- رقم الفاتورة
 c002_data datetime default getdate(),                             -- تاريخ الصدور 
 c003_LicenseCost decimal(7,2),                   -- تكلفة 
 c004_TaxPercentage decimal(2,2) ,                -- نسبة الضريبة
 c005_TaxCost decimal(7,2),                       -- تكلفة الضريبة
 c006_AllCost decimal(7,2)                      -- مجموع التكلفة  السعر + الضريبة 
)



----*  7  *----------( ربط الفواتير بالرخص )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table linkInvoiceWithLicense
(
c001_linkNo int identity primary key,
c002_invoiceNo int ,
c003_licenseNo int 
)

alter table linkInvoiceWithLicense
add constraint pk010002TO007001 foreign key (c002_invoiceNo) references tbl007_invoices(c001_invoiceNumber)

alter table linkInvoiceWithLicense
add constraint pk010003TO003001 foreign key (c003_licenseNo) references tbl003_licenses(c001_licenseNo)


 ----*  8  *----------(طلبات اعتماد الحوالات  )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
 -- تدخل من قبل العميل
create table tbl006_LicenseActivationRequests
(
 c001_tbl006TransferAoutoNo int identity primary key,      -- رقم طلب اعتماد الحوالة 
 c002_TransferBanckNumber   varchar(100) ,           -- رقم الحوالة الخاص بالبنك                
 c003_TransferBank varchar(50) ,                     -- البنك
 c004_TransferDate datetime,                         -- تاريخ الحوالة 
 c005_TransferTime datetime,                         -- وقت الحوالة
 c006_TransferAmount decimal(7,2),                   -- مبلغ الحوالة
 c007_invoiceNumber int ,                                  -- رقم الفاتورة
 c008_licenseNo int ,                                  -- رقم الرخصة (تستخدم لتجديد الرخصة)س
 c009_PackageDuration int                              -- مدة الرخصة (تستخدم لتجديد الرخصة)س
 );


alter table tbl006_LicenseActivationRequests
add constraint PK006007TO007001 foreign key (c007_invoiceNumber) references tbl007_invoices(c001_invoiceNumber)  ;
GO


----*  9  *----------( الحوالات المالية)---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
-- تدخل من قبل الشركة
create table tbl005_MoneyTransfers
(
 c001_tbl005TransferAoutoNo int identity primary key,      -- الرقم المتسلسل للحوالات 
 c002_TransferBanckNumber   varchar(100) ,           -- رقم الحوالة الخاص بالبنك                
 c003_TransferBank varchar(50) ,                     -- البنك
 c004_TransferDate datetime,                   -- تاريخ الحوالة 
 c005_TransferTime datetime,                   -- وقت الحوالة
 c006_TransferAmount decimal(7,2)              -- مبلغ الحوالة
);

--insert into tbl005_MoneyTransfers values ('111111','مصرف الراجحي','2022-02-02','2000-01-01 09:00',15000);


----*  10  *----------( ربط الحوالات المالية بطلبات اعتماد الحوالات )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
-- تدخل من قبل الشركة
create table tbl011_linkActivationRequestsAndMonyTransfers
(
 C001_number int identity(1,1) primary key,
 c002_tbl006TransferAoutoNo int,
 c003_tbl005TransferAoutoNo int
)
GO

alter table tbl011_linkActivationRequestsAndMonyTransfers
add constraint pk011002TO006001 foreign key (c002_tbl006TransferAoutoNo) references tbl006_LicenseActivationRequests(c001_tbl006TransferAoutoNo)

alter table tbl011_linkActivationRequestsAndMonyTransfers
add constraint pk011003TO005001 foreign key (c003_tbl005TransferAoutoNo) references tbl005_MoneyTransfers(c001_tbl005TransferAoutoNo)

--insert into tbl011_linkActivationRequestsAndMonyTransfers values (1,1);


----*  11  *----------( اعادات عامة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
create table tbl009GeneralSettings
(
c001_TaxPercentage decimal(2,2)
)
go

insert into tbl009GeneralSettings values (0.15)
go






---*  101  *----------( تسجيل بيانات جهاز جديد وربطه بالرخصة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc AddDeviceAndConnctWithLicense
 @c002_DeviceNo varchar(50),                    -- رقم الجهاز
 @c003_HardiceNo varchar(50),                   -- رقم الهارديسك
 @c004_ProcessorNo varchar(50),                 -- رقم المعالج
 @c005_location varchar(100),                   -- موقع الجهاز
 @c006_deviceUses varchar(100),                  -- استخدامات الجهاز
 @c003_licensNo int,                -- رقم الرخصة
 @c001_deviceAuotoNoOUT int out                 -- الرقم المتسلسل للجهاز
 as
 begin
 insert into tbl001_devices (c002_DeviceNo,c003_HardiceNo,c004_ProcessorNo) values (@c002_DeviceNo,@c003_HardiceNo,@c004_ProcessorNo) 
 set @c001_deviceAuotoNoOUT = SCOPE_IDENTITY();
 insert into tbl004_licenseAndDevices (c002_deviceAuotoNo,c003_licensNo ,c005_location ,c006_deviceUses) values (SCOPE_IDENTITY(),@c003_licensNo, @c005_location, @c006_deviceUses )
 return @c001_deviceAuotoNoOUT
 end
 GO

 ----*  102  *----------( ربط جهاز برخصة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc ConnctDeviceAndLicense
 @c002_DeviceNo varchar(50),                    -- رقم الجهاز
 @c003_licensNo int ,               -- رقم الرخصة
  @c005_location varchar(100),                   -- موقع الجهاز
 @c006_deviceUses varchar(100)                  -- استخدامات الجهاز
  as
 begin
 declare @c001_deviceAuotoNo int
 select @c001_deviceAuotoNo = c001_deviceAuotoNo from tbl001_devices where c002_DeviceNo = @c002_DeviceNo
 insert into tbl004_licenseAndDevices (c002_deviceAuotoNo,c003_licensNo  ,c005_location ,c006_deviceUses) values ( @c001_deviceAuotoNo , @c003_licensNo , @c005_location, @c006_deviceUses)
  end
  GO
  
 ----*  103  *----------( الغاء ربط جهاز برخصة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

 create proc DesConnctDeviceAndLicense
 @c002_DeviceNo varchar(50),                    -- رقم الجهاز
 @c003_licensNo int                -- رقم الرخصة
  as
 begin
 declare @c001_deviceAuotoNo int
 select @c001_deviceAuotoNo = c001_deviceAuotoNo from tbl001_devices where c002_DeviceNo = @c002_DeviceNo
 delete from tbl004_licenseAndDevices  where c002_deviceAuotoNo = @c001_deviceAuotoNo and c003_licensNo = @c003_licensNo
  end
GO

 ----*  104  *----------( حذف رخصة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

--delete from tbl003_licenses where c001_licenseNo = @c001_licenseNo

create proc licenseDelete
@c001_licenseNo int
as
begin
delete from tbl004_licenseAndDevices where c003_licensNo = @c001_licenseNo ;
delete from linkInvoiceWithLicense where c003_licenseNo = @c001_licenseNo ;
delete from tbl003_licenses where c001_licenseNo = @c001_licenseNo ;
end
GO
--exec licenseDelete 1
 ----*  105  *----------( انشاء فاتورة جديدة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

create proc createNewInvoice
@c003_LicenseCost decimal(7,2),
@c007_licenseNo int 
as
begin
declare @c004_TaxPercentage decimal(2,2)
declare @c005_TaxCost decimal(7,2)
declare @c006_AllCost decimal(7,2)
select  @c004_TaxPercentage = c001_TaxPercentage from tbl009GeneralSettings
set @c005_TaxCost = @c003_LicenseCost*@c004_TaxPercentage
set @c006_AllCost = @c005_TaxCost + @c003_LicenseCost
insert into tbl007_invoices (c003_LicenseCost,c004_TaxPercentage,c005_TaxCost,c006_AllCost) values (@c003_LicenseCost,@c004_TaxPercentage,@c005_TaxCost,@c006_AllCost)
declare @c001_invoiceNumber int
set @c001_invoiceNumber  = SCOPE_IDENTITY();
insert into linkInvoiceWithLicense ( c002_invoiceNo  , c003_licenseNo ) values ( @c001_invoiceNumber  , @c007_licenseNo )
end
GO
 ----*  106  *----------( طلب اعتماد حوالة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
 
 create proc addLicenseActivationRequests
 @c002_TransferBanckNumber varchar(100) ,           -- رقم الحوالة الخاص بالبنك                
 @c003_TransferBank varchar(50) ,                     -- البنك
 @c004_TransferDate datetime,                         -- تاريخ الحوالة 
 @c005_TransferTime datetime,                         -- وقت الحوالة
 @c006_TransferAmount decimal(7,2),                   -- مبلغ الحوالة
 @c007_invoiceNumber int  ,                                 -- رقم الفاتورة
 @c008_licenseNo int ,                                  -- رقم الرخصة (تستخدم لتجديد الرخصة)س
 @c009_PackageDuration int                              -- مدة الرخصة (تستخدم لتجديد الرخصة)س
 as
begin
insert into tbl006_LicenseActivationRequests (c002_TransferBanckNumber,c003_TransferBank,c004_TransferDate,c005_TransferTime ,c006_TransferAmount,c007_invoiceNumber ,c008_licenseNo,c009_PackageDuration) values ( @c002_TransferBanckNumber,@c003_TransferBank,@c004_TransferDate,@c005_TransferTime ,@c006_TransferAmount,@c007_invoiceNumber ,@c008_licenseNo,@c009_PackageDuration)
end
GO


 ----*  107  *----------( تحديث طلب اعتماد حوالة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
 
 create proc updateLicenseActivationRequests
 @c001_tbl006TransferAoutoNo int ,                  -- رقم طلب اعتماد الحوالة
 @c002_TransferBanckNumber varchar(100) ,           -- رقم الحوالة الخاص بالبنك                
 @c003_TransferBank varchar(50) ,                     -- البنك
 @c004_TransferDate datetime,                         -- تاريخ الحوالة 
 @c005_TransferTime datetime,                         -- وقت الحوالة
 @c006_TransferAmount decimal(7,2),                   -- مبلغ الحوالة
 @c007_invoiceNumber int  ,                                 -- رقم الفاتورة
 @c008_licenseNo int ,                                  -- رقم الرخصة (تستخدم لتجديد الرخصة)س
 @c009_PackageDuration int                              -- مدة الرخصة (تستخدم لتجديد الرخصة)س
 as
begin
update tbl006_LicenseActivationRequests set c002_TransferBanckNumber = @c002_TransferBanckNumber, c003_TransferBank =@c003_TransferBank ,c004_TransferDate=@c004_TransferDate,c005_TransferTime=@c005_TransferTime ,c006_TransferAmount=@c006_TransferAmount,c007_invoiceNumber=@c007_invoiceNumber ,c008_licenseNo=@c008_licenseNo,c009_PackageDuration=@c009_PackageDuration where c001_tbl006TransferAoutoNo = @c001_tbl006TransferAoutoNo
end
GO



 ----*  108  *----------( تسجيل الحوالات الواردة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
 
create proc AddMoneyTransfers
 @c002_TransferBanckNumber   varchar(100) ,           -- رقم الحوالة الخاص بالبنك                
 @c003_TransferBank varchar(50) ,                     -- البنك
 @c004_TransferDate datetime,                   -- تاريخ الحوالة 
 @c005_TransferTime datetime,                   -- وقت الحوالة
 @c006_TransferAmount decimal(7,2)              -- مبلغ الحوالة
 as
begin
insert into tbl005_MoneyTransfers ( c002_TransferBanckNumber , c003_TransferBank , c004_TransferDate , c005_TransferTime , c006_TransferAmount ) values ( @c002_TransferBanckNumber , @c003_TransferBank , @c004_TransferDate , @c005_TransferTime , @c006_TransferAmount )
end
GO

--execute AddMoneyTransfers '222222','مصرف الراجحي','2022-03-03','2000-01-01 03:33',13000

 ----*  109  *----------( تجديد الرخصة )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
 create proc ReNewLicenses
 @c001_tbl006TransferAoutoNo int , -- رقم طلب اعتماد الحوالة
 @c001_tbl005TransferAoutoNo int ,  -- رقم الحوالة
 @c001_licenseNo int ,      -- رقم الرخصة
 @c004_PackageDuration int  -- مدة الرخصة
 as
 begin
 insert into tbl011_linkActivationRequestsAndMonyTransfers values (@c001_tbl006TransferAoutoNo,@c001_tbl005TransferAoutoNo)
 update tbl003_licenses set tbl003_licenses.c004_DateOfLicenseStart = getdate() , tbl003_licenses.c007_LicenseEndDate = dateadd(day,@c004_PackageDuration,getdate()) where tbl003_licenses.c001_licenseNo = @c001_licenseNo
 end
 GO


  ----*  110  *----------( نقل جهاز الى رخصة اخرى )---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

  create proc [dbo].[TransfareDeviceToOtherLicense]
  @c003_licensNo int,
  @c001_linkNo int
  as 
  begin
  update tbl004_licenseAndDevices set c003_licensNo = @c003_licensNo where c001_linkNo =  @c001_linkNo 
  end
GO























--select * from tbl007_invoices 
--    left join linkInvoiceWithLicense on linkInvoiceWithLicense.c002_invoiceNo = tbl007_invoices.c001_invoiceNumber 
--    left join tbl006_LicenseActivationRequests on tbl006_LicenseActivationRequests.c007_invoiceNumber = tbl007_invoices.c001_invoiceNumber 
--    left join tbl011_linkActivationRequestsAndMonyTransfers on tbl011_linkActivationRequestsAndMonyTransfers.c002_tbl006TransferAoutoNo = tbl006_LicenseActivationRequests.c001_tbl006TransferAoutoNo 
--	left join tbl005_MoneyTransfers on tbl005_MoneyTransfers.c001_tbl005TransferAoutoNo = tbl011_linkActivationRequestsAndMonyTransfers.c003_tbl005TransferAoutoNo


 --   select * from tbl006_LicenseActivationRequests  
 --   left join tbl011_linkActivationRequestsAndMonyTransfers on tbl011_linkActivationRequestsAndMonyTransfers.c002_tbl006TransferAoutoNo = tbl006_LicenseActivationRequests.c001_tbl006TransferAoutoNo 
	--where C001_number is null


	--select * from tbl005_MoneyTransfers 
	--left join tbl011_linkActivationRequestsAndMonyTransfers on tbl005_MoneyTransfers.c001_tbl005TransferAoutoNo = tbl011_linkActivationRequestsAndMonyTransfers.c003_tbl005TransferAoutoNo
	--where C001_number is null

