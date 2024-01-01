using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mesrakh; // لكي تظهر العناصر الموجودة في المشروع


// متغيرات تستخدم على مستوى البرنامج
/// <summary>
/// 08  >> general variables 
/// </summary>
public static class GeneralVariables
{
    public static string programName = "mesrakh";  //08001 // اسم البرنامج



    public static string DisplayMode = "Blue";  // 08004 // تحديد نمط العرض
    public static string cultureCode = "AR"; //08005 //  تحديد لغة العرض

    public static string[] LocaleInstances; // 08006  //  مصفوفة بأسماء جميع السيرفرات المحلية
    public static bool weHaveOpenConnection = true;// 08007 // حالة الاتصال 

    public static frmsplash _frmSplash00; // 08008 // 
    public static frmMain01 _frmMain01; // 08009  // 
    public static frmConnectionSettings02 _frmConnectionSettings; // 08010 // 
    public static frmLogin03 _frmLogin03; // 08011 // 
    public static frmAccountManagement _frmAccountManagement04; // 08012 // 
    public static frmMessageBox _frmMessageBox; // 08013 // الرسائل
    public static string MessageBoxResult = ""; // 08014 // نتيجة اختيار المستخدم من صندوق الرسائل
    public static bool frmMessageIsOpen = false; // 08015  // صندوق الرسائل مفتوح او لا

    public static frmNotifications _frmNotifications; // 08016 // نموذج الاشعارات

    public static frmAccount05 _frmAccount05; // 08017 // نموذج حسابات المستخدمين
    //public static DataTable AccountsInformation; // 08018// معلومات الحساب

    public static frmMainMenu06 _frmMainMenu06 ; // 08019 // نموذج القوائم الرئيسية

    public static frmPermissionsGroup07 _frmPermissionsGroup07 ; // 08020 // نموذج مجموعات الصلاحيات
    public static DataTable PermissionsGroup07; // 08021 // مجموعات الصلاحيات
    //public static DataTable Permissions ; // 08022 //  تم ايقافها ولكن تم الاحتفاظ بها للتأكد من عدم وجود مشاكل  ????????????????????????????????????????????????????????   الصلاحيات

    public static DataTable ActiveAccount; // 08023 //  الحساب النشط  // frmLogin03  line no : 196  مكان الاستخدام // permissions AccountHavePermission مكان الاستخدام // 

    public static frmManufacturers08 _frmManufacturers08;  // 08024 // نموذج الشركات الصانعة
    //public static DataTable ManufacturersTable; // 08018// جدول الشركات الصانعة


    public static frmProductsAndServices09 _frmProductsAndServices09;  // 08025 // نموذج السلع والخدمات

    public static frmCategories10 _frmCategories10;  // 08026 // نموذج التصنيفات

    public static frmAccounts11 _frmAccounts11;  // 08027 // نموذج الحسابات المحاسبية

    public static frmMeasureUnit12 _frmMeasureUnit12;  // 08028 // نموذج وحدات القياس

    public static frmEncapsulationUnits13 _frmEncapsulationUnits13;  // 08029 // نموذج وحدات التغليف

    public static frmproductAndServicesDetails14 frmproductAndServicesDetails14;  // 08030 // نموذج تفاصيل السلع والخدمات  

    public static frmEnterprise15 _frmEnterprise15;  // 08031 // نموذج المنشآت  

}
