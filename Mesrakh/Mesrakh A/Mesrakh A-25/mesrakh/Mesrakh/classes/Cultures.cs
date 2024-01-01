using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// الحضارات والترجمة
/// <summary>
///  06  >>  Translation
/// </summary>
public class Cultures
{

    private static DataTable tblTranslation;  // لكي لا يزيد الحمل على الذاكرة

    // جدول ترجمة المفردات
    /// <summary>
    ///  06001  >> fill  translation table by Vocabulary
    /// </summary>
    /// <returns>Return Vocabulary translation table / DataTable Variable</returns>
    public static void fillTranslationTable()
    {
        if (tblTranslation is null)
        {

            tblTranslation = new DataTable("tblVocabulary");
            tblTranslation.Columns.Add("rowIndex", typeof(string));
            tblTranslation.Columns.Add("AR", typeof(string));
            tblTranslation.Columns.Add("EN", typeof(string));
            tblTranslation.Columns.Add("UR", typeof(string));

            tblTranslation.Rows.Add(new string[] { "0", "إسم المستخدم", "User Name", "" });
            tblTranslation.Rows.Add(new string[] { "1", "كلمة المرور", "Password", "" });
            tblTranslation.Rows.Add(new string[] { "2", "رجاء قم بتسجيل إسم المستخدم", "Please Enter your UserName", "" });
            tblTranslation.Rows.Add(new string[] { "3", "رجاء قم بتسجيل كلمة المرور", "Please Enter your Password", "" });
            tblTranslation.Rows.Add(new string[] { "4", "لا يوجد سيرفر محلي", "There is no local server", "" });
            tblTranslation.Rows.Add(new string[] { "5", "إسم قاعدة البيانات", "Database Name", "" });
            tblTranslation.Rows.Add(new string[] { "6", "نوع قاعدة البيانات", "Database Type", "" });
            tblTranslation.Rows.Add(new string[] { "7", "موقع السيرفر", "Server Location", "" });
            tblTranslation.Rows.Add(new string[] { "8", "إسم السيرفر المحلي", "local server name", "" });
            tblTranslation.Rows.Add(new string[] { "9", "نوع المصادقة", "Authentication type", "" });
            tblTranslation.Rows.Add(new string[] { "10", "رقم الآي بي", "IP No", "" });
            tblTranslation.Rows.Add(new string[] { "11", "نص الإتصال", "Connection String", "" });
            tblTranslation.Rows.Add(new string[] { "12", "فشل الإتصال", "Connection failed", "" });
            tblTranslation.Rows.Add(new string[] { "13", "نجاح الإتصال هل تريد الحفظ", "Connection success Do you want to save", "" });
            tblTranslation.Rows.Add(new string[] { "14", "تم الحفظ بنجاح", "Saved successfully", "" });
            tblTranslation.Rows.Add(new string[] { "15", "نعم", "Yes", "" });
            tblTranslation.Rows.Add(new string[] { "16", "لا", "No", "" });
            tblTranslation.Rows.Add(new string[] { "17", "موافق", "Ok", "" });
            tblTranslation.Rows.Add(new string[] { "18", "هل لديك إتصال بشبكة الإنترنت", "Do you have internet connection", "" });
            tblTranslation.Rows.Add(new string[] { "19", "تحقق من وجود إتصال بالإنترنت ووجود رخصة سارية المفعول", "Check that you have an internet connection and a valid license", "" });
            tblTranslation.Rows.Add(new string[] { "20", "تنبيه", "Warning !!!", "" });
            tblTranslation.Rows.Add(new string[] { "21", "توجد مشكلة في الإتصال", "There is a connection problem", "" });
            tblTranslation.Rows.Add(new string[] { "22", "هل لديك إتصال بشبكة الإنترنت", "Do you have internet connection", "" });
            tblTranslation.Rows.Add(new string[] { "23", "رجاء تأكد من صحة إعدادات الإتصال", "Please make sure that the connection settings are correct", "" });
            tblTranslation.Rows.Add(new string[] { "24", "الموقع", "Location", "" });
            tblTranslation.Rows.Add(new string[] { "25", "التاريخ والوقت", "Date Time", "" });
            tblTranslation.Rows.Add(new string[] { "26", "الرسالة", "Message", "" });
            tblTranslation.Rows.Add(new string[] { "27", "الإشعارات", "Notifications", "" });
            tblTranslation.Rows.Add(new string[] { "28", "تأكد من صحة إسم المستخدم وكلمة المرور", "Ensure that the username and password are correct", "" });
            tblTranslation.Rows.Add(new string[] { "29", "توجد مشكلة في الاتصال", "There is a connection problem", "" });
            tblTranslation.Rows.Add(new string[] { "30", "حسابات المستخدمين", "Users Accounts", "" });
            tblTranslation.Rows.Add(new string[] { "31", "رقم المستخدم", "Account No", "" });
            tblTranslation.Rows.Add(new string[] { "32", "رقم الموظف", "Employee No", "" });
            tblTranslation.Rows.Add(new string[] { "33", "رقم الحساب", "Account Number", "" });
            tblTranslation.Rows.Add(new string[] { "34", "إسم الموظف", "Employee Name", "" });
            tblTranslation.Rows.Add(new string[] { "35", "إدارة المخزون", "Inventory Management", "" });
            tblTranslation.Rows.Add(new string[] { "36", "المبيعات والمشتريات", "Sales And Purchases", "" });
            tblTranslation.Rows.Add(new string[] { "37", "المحاسبة", "Accounting", "" });
            tblTranslation.Rows.Add(new string[] { "38", "النظام", "System", "" });
            tblTranslation.Rows.Add(new string[] { "39", "حسابات المستخدمين", "users accounts", "" });
            tblTranslation.Rows.Add(new string[] { "40", "مجموعات الصلاحيات", "Permissions Groups", "" });
            tblTranslation.Rows.Add(new string[] { "41", "الالوان", "Colors", "" });
            tblTranslation.Rows.Add(new string[] { "42", "النظام", "System", "" });
            tblTranslation.Rows.Add(new string[] { "43", "هل الحساب نشط", "Active", "" });
            tblTranslation.Rows.Add(new string[] { "44", "مجموعات الصلاحيات", "Permission Groups", "" });
            tblTranslation.Rows.Add(new string[] { "45", "رقم المجموعة", "Group No", "" });
            tblTranslation.Rows.Add(new string[] { "46", "إسم المجموعة عربي", "Group AR Name", "" });
            tblTranslation.Rows.Add(new string[] { "47", "إسم المجموعة إنجليزي", "Group EN Name", "" });
            tblTranslation.Rows.Add(new string[] { "48", "جديد", "New", "" });
            tblTranslation.Rows.Add(new string[] { "49", "حفظ", "Save", "" });
            tblTranslation.Rows.Add(new string[] { "50", "عرض", "Show", "" });
            tblTranslation.Rows.Add(new string[] { "51", "إضافة", "Add", "" });
            tblTranslation.Rows.Add(new string[] { "52", "تعديل", "Edit", "" });
            tblTranslation.Rows.Add(new string[] { "53", "حذف", "Delete", "" });
            tblTranslation.Rows.Add(new string[] { "54", "تعديل الصلاحيات", "Edit Permissions", "" });
            tblTranslation.Rows.Add(new string[] { "55", "حفظ الصلاحيات", "Save Permissions", "" });
            tblTranslation.Rows.Add(new string[] { "56", "الشركات الصانعة", "Manufacturers", "" });
            tblTranslation.Rows.Add(new string[] { "57", "رقم الشركة الصانعة", "Manufacturer No", "" });
            tblTranslation.Rows.Add(new string[] { "58", "اسم الشركة عربي", "Arabic Company Name", "" });
            tblTranslation.Rows.Add(new string[] { "59", "اسم الشركة انجليزي", "English Company Name", "" });
            tblTranslation.Rows.Add(new string[] { "60", "توجد منتجات مرتبطة بهذه الشركة", "There Are Products Associated With This Company", "" });
            tblTranslation.Rows.Add(new string[] { "61", "الحساب غير نشط", "The Account Is Not Active", "" });
            tblTranslation.Rows.Add(new string[] { "62", "غير نشط", "Not Active", "" });
            tblTranslation.Rows.Add(new string[] { "63", "وسائل التواصل", "Ways To Communicate", "" });
            tblTranslation.Rows.Add(new string[] { "64", "طريقة الإتصال", "Contact method", "" });
            tblTranslation.Rows.Add(new string[] { "75", "الرقم", "Number", "" });
            tblTranslation.Rows.Add(new string[] { "66", "تفاصيل أخرى", "Other Details", "" });
            tblTranslation.Rows.Add(new string[] { "67", "البحث عن", "Searching For", "" });
            tblTranslation.Rows.Add(new string[] { "68", "بحث", "Search", "" });
            tblTranslation.Rows.Add(new string[] { "69", "تفاصيل أخرى", "other details", "" });
            tblTranslation.Rows.Add(new string[] { "70", "رجاء قم بتحديد الشركةالتي تريد إضافة طريقة إتصال جديدة إليها", "Please select the company you want to add a new contact method to", "" });
            tblTranslation.Rows.Add(new string[] { "71", "رجاء قم بتحديد نوع طريقة الإتصال", "Please select the type of communication method", "" });
            tblTranslation.Rows.Add(new string[] { "72", "رجاء قم بتسجيل رقم طريقة الإتصال الجديدة", "Please register the number of the new contact method", "" });
            tblTranslation.Rows.Add(new string[] { "73", "مشكلة في الإتصال بقاعدة البيانات الرئيسية", "Problem connecting to the main database", "" });
            tblTranslation.Rows.Add(new string[] { "75", "رجاء قم بكتابة إسم المستخدم", "Please enter your username", "" });
            tblTranslation.Rows.Add(new string[] { "76", "رجاء قم بكتابة كلمة المرور", "Please type the password", "" });
            tblTranslation.Rows.Add(new string[] { "77", "رجاء قم بإختيار موظف", "Please select an employee", "" });
            tblTranslation.Rows.Add(new string[] { "78", "رجاء قم بإختيار مجموعة الصلاحيات", "Please select a set of permissions", "" });
            tblTranslation.Rows.Add(new string[] { "79", "يوجد مستخدم بنفس الإسم", "There is a user with the same name", "" });//
            tblTranslation.Rows.Add(new string[] { "80", "هذا الموظف لديه حساب سابق", "This employee has a previous account", "" });
            tblTranslation.Rows.Add(new string[] { "81", "رجاء قم بتسمية المجموعة باللغة العربية", "Please name the group in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "82", "رجاء قم بتسمية المجموعة باللغة الإنجليزية", "Please name the group in English", "" });
            tblTranslation.Rows.Add(new string[] { "83", "رجاء قم بتسجيل إسم الشركة عربي", "Please register the company name in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "84", "رجاء قم بتسجيل إسم الشركة إنجليزي", "Please register the company name in English", "" });
            tblTranslation.Rows.Add(new string[] { "85", "توجد شركة بنفس إسم الشركة العربي", "There is a company with the same name as the Arabic company", "" });
            tblTranslation.Rows.Add(new string[] { "86", "توجد شركة بنفس إسم الشركة الإنجليزي", "There is a company with the same name as the English company", "" });
            tblTranslation.Rows.Add(new string[] { "87", "توجد وسيلة إتصال لها نفس الرقم", "There is a contact with the same number", "" });
            tblTranslation.Rows.Add(new string[] { "88", "إلغاء", "cancel", "" });
            tblTranslation.Rows.Add(new string[] { "89", "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator", "" });
            tblTranslation.Rows.Add(new string[] { "90", "المنتجات", "Products", "" });
            tblTranslation.Rows.Add(new string[] { "91", "رقم المنتج", "Product number" , "" });
            tblTranslation.Rows.Add(new string[] { "92", "إسم المنتج عربي", "Product name Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "93", "الموديل", "Model", "" });
            tblTranslation.Rows.Add(new string[] { "94", "وصف المنتج عربي", "Product Description Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "95", "وصف المنتج إنجليزي", "Product Description English", "" });
            tblTranslation.Rows.Add(new string[] { "96", "الفئات السعرية", "Price Categories", "" });
            tblTranslation.Rows.Add(new string[] { "97", "نسبة ربح من سعر التكلفة", "Cost profit ratio", "" });
            tblTranslation.Rows.Add(new string[] { "98", "رجاء قم بتسجيل إسم المنتج عربي", "Please register the name of the product in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "99", "رجاء قم بتسجيل إسم المنتج إنجليزي", "Please register the name of the product in English", "" });
            tblTranslation.Rows.Add(new string[] { "100", "رجاء قم بتسجيل موديل المنتج", "Please register the product model", "" });
            tblTranslation.Rows.Add(new string[] { "101", "رجاء قم بوصف المنتج عربي", "Please describe the product in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "102", "رجاء قم بوصف المنتج إنجليزي", "Please describe the product in English", "" });
            tblTranslation.Rows.Add(new string[] { "103", "رجاء قم بتحديد الشركة الصانعة", "Please select the manufacturer", "" });
            tblTranslation.Rows.Add(new string[] { "104", "رجاء قم بتحديد أسلوب إحتساب السعر", "Please select a method of calculating the price", "" });
            tblTranslation.Rows.Add(new string[] { "105", "يوجد منتج بنفس إسم المنتج العربي", "There is a product with the same name as the Arabic product", "" });
            tblTranslation.Rows.Add(new string[] { "106", "يوجد منتج بنفس إسم المنتج الإنجليزي", "There is a product with the same name as the English product", "" });
            tblTranslation.Rows.Add(new string[] { "107", "رقم المنتج", "Product number", "" });
            tblTranslation.Rows.Add(new string[] { "108", "إسم المنتج عربي", "Product name Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "109", "إسم المنتج إنجليزي", "English product name", "" });
            tblTranslation.Rows.Add(new string[] { "110", "إسم الشركة الصانعة", "Manufacturer's name", "" });
            tblTranslation.Rows.Add(new string[] { "111", "الموديل", "Model", "" });
            tblTranslation.Rows.Add(new string[] { "112", "وصف المنتج عربي", "Product Description Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "113", "وصف المنتج إنجليزي", "Product Description English", "" });
            tblTranslation.Rows.Add(new string[] { "114", "إسم الشركة الصانعة عربي", "The name of the manufacturer is in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "115", "إسم الشركة الصانعة إنجليزي", "English name of the manufacturer", "" });
            tblTranslation.Rows.Add(new string[] { "116", "الشركة الصانعة", "Manufacturing company", "" });
            tblTranslation.Rows.Add(new string[] { "117", "أسلوب إحتساب السعر", "price calculation method", "" });
            tblTranslation.Rows.Add(new string[] { "119", "توجد سجلات مرتبطة في جدول طرق الإتصال", "There are related records in the contact methods table", "" });
            tblTranslation.Rows.Add(new string[] { "120", "توجد سجلات مرتبطة في جدول الشركات الصانعة", "There are related records in the manufacturers table", "" });
            tblTranslation.Rows.Add(new string[] { "121", "توجد سجلات مرتبطة في جدول المنتجات", "There are related records in the Products table", "" });
            tblTranslation.Rows.Add(new string[] { "122", "توجد سجلات مرتبطة في جدول تصنيف المنتجات", "There are related records in the product classification table", "" });
            tblTranslation.Rows.Add(new string[] { "123", "توجد سجلات مرتبطة في جدول المنتج والتصنيف", "There are related records in the product and classification table", "" });
            tblTranslation.Rows.Add(new string[] { "124", "توجد سجلات مرتبطة في جدول وحدات القياس", "There are related records in the Units of Measure table", "" });
            tblTranslation.Rows.Add(new string[] { "125", "توجد سجلات مرتبطة في جدول وحدات القياس والتغليف", "There are related records in the Units of Measure and Packaging table", "" });
            tblTranslation.Rows.Add(new string[] { "126", "توجد سجلات مرتبطة في جدول الباركود", "There are related records in the barcode table", "" });
            tblTranslation.Rows.Add(new string[] { "127", "توجد سجلات مرتبطة في جدول عرض الوحدات المجانية", "There are related records in the free units display table", "" });
            tblTranslation.Rows.Add(new string[] { "128", "توجد سجلات مرتبطة في جدول الفئات السعرية", "There are related records in the price categories table", "" });
            tblTranslation.Rows.Add(new string[] { "129", "توجد سجلات مرتبطة في جدول التشغيلات", "There are related records in the run table", "" });
            tblTranslation.Rows.Add(new string[] { "130", "توجد سجلات مرتبطة في جدول الدول", "There are related records in the countries table", "" });
            tblTranslation.Rows.Add(new string[] { "131", "توجد سجلات مرتبطة في جدول المناطق والولايات", "There are related records in the Regions and States table", "" });
            tblTranslation.Rows.Add(new string[] { "132", "توجد سجلات مرتبطة في جدول المحافظات والمدن", "There are related records in the governorates and cities table", "" });
            tblTranslation.Rows.Add(new string[] { "133", "توجد سجلات مرتبطة في جدول العناوين", "There are related records in the address table", "" });
            tblTranslation.Rows.Add(new string[] { "134", "توجد سجلات مرتبطة في جدول فروع المنشآت", "There are related records in the establishments branch table", "" });
            tblTranslation.Rows.Add(new string[] { "135", "توجد سجلات مرتبطة في جدول الأرفف", "There are related records in the rack table", "" });
            tblTranslation.Rows.Add(new string[] { "136", "توجد سجلات مرتبطة في جدول الأرفف والمنتجات", "There are related records in the Shelves and Products table", "" });
            tblTranslation.Rows.Add(new string[] { "137", "توجد سجلات مرتبطة في جدول الوكلاء التجاريين", "There are related records in the Trade Agents table", "" });
            tblTranslation.Rows.Add(new string[] { "138", "توجد سجلات مرتبطة في جدول الشركات الصانعة و الوكلاء التجاريين", "There are related records in the table of manufacturers and commercial agents", "" });
            tblTranslation.Rows.Add(new string[] { "139", "توجد سجلات مرتبطة في جدول عناوين الوكلاء التجاريين", "There are related records in the address table of commercial agents", "" });
            tblTranslation.Rows.Add(new string[] { "140", "توجد سجلات مرتبطة في جدول العملاء", "There are related records in the Customers table", "" });
            tblTranslation.Rows.Add(new string[] { "141", "توجد سجلات مرتبطة في جدول عناوين العملاء", "There are related records in the customer address table", "" });
            tblTranslation.Rows.Add(new string[] { "142", "توجد سجلات في جدول الموظفين", "There are records in the employee table", "" });
            tblTranslation.Rows.Add(new string[] { "143", "توجد سجلات في جدول الموظف والهوية", "There are records in the employee and identity table", "" });
            tblTranslation.Rows.Add(new string[] { "144", "توجد سجلات في جدول عناوين الموظفين", "There are records in the employee address table", "" });
            tblTranslation.Rows.Add(new string[] { "145", "توجد سجلات في جدول عناوين الموظفين و الفروع", "There are records in the table of addresses of employees and branches", "" });
            tblTranslation.Rows.Add(new string[] { "146", "توجد سجلات في جدول الصلاحيات", "There are records in the permissions table", "" });
            tblTranslation.Rows.Add(new string[] { "147", "توجد سجلات في جدول حسابات المستخدمين", "There are records in the user accounts table", "" });
            tblTranslation.Rows.Add(new string[] { "148", "توجد سجلات في جدول وحدات العمليات", "There are records in the Operations Units table", "" });
            tblTranslation.Rows.Add(new string[] { "149", "توجد سجلات في جدول الحسابات", "There are records in the chart of accounts", "" });
            tblTranslation.Rows.Add(new string[] { "150", "توجد سجلات مرتبطة في جدول القيود المحاسبية الفرعية", "There are related records in the sub-accounting entries table", "" });
            tblTranslation.Rows.Add(new string[] { "151", "توجد سجلات مرتبطة في جدول العمليات", "There are related records in the operations table", "" });
            tblTranslation.Rows.Add(new string[] { "152", "توجد سجلات مرتبطة في جدول الفواتير", "There are related records in the billing table", "" });
            tblTranslation.Rows.Add(new string[] { "153", "توجد سجلات مرتبطة في جدول تفاصيل الفواتير", "There are related records in the billing details table", "" });
            tblTranslation.Rows.Add(new string[] { "154", "توجد سجلات مرتبطة في جدول عمليات الجرد", "There are related records in the counts table", "" });
            tblTranslation.Rows.Add(new string[] { "155", "توجد سجلات مرتبطة في جدول تفاصيل عمليات الجرد", "There are related records in the Inventories details table", "" });
            tblTranslation.Rows.Add(new string[] { "156", "توجد سجلات مرتبطة في جدول عمليات الإهلاك", "There are related records in the depreciation operations table", "" });
            tblTranslation.Rows.Add(new string[] { "157", "توجد سجلات مرتبطة في جدول تفاصيل عمليات الاهلاك", "There are related records in the Depreciation operations details table", "" });
            tblTranslation.Rows.Add(new string[] { "158", "توجد سجلات مرتبطة في جدول نقل الارصدة", "There are related records in the balance transfer table", "" });
            tblTranslation.Rows.Add(new string[] { "159", "توجد سجلات مرتبطة في جدول تفاصيل نقل الأرصدة", "", "" });
            tblTranslation.Rows.Add(new string[] { "160", "توجد سجلات مرتبطة في جدول المخزون", "There are related records in the inventory table", "" });
            tblTranslation.Rows.Add(new string[] { "161", "التصنيفات", "Categories", "" });
            tblTranslation.Rows.Add(new string[] { "162", "رقم الصنف", "Category No", "" });
            tblTranslation.Rows.Add(new string[] { "163", "إسم الصنف عربي", "Arabic Category Name", "" });
            tblTranslation.Rows.Add(new string[] { "164", "إسم الصنف إنجليزي", "English Category Name", "" });
            tblTranslation.Rows.Add(new string[] { "165", "وصف الصنف", "Category Description", "" });
            tblTranslation.Rows.Add(new string[] { "166", "الصنف الأعلى", "Top Category", "" });
            tblTranslation.Rows.Add(new string[] { "167", "رجاء قم بتسجيل إسم الصنف عربي", "Please enter the name of the Category in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "168", "رجاء قم بتسجيل إسم الصنف إنجليزي", "Please enter the name of the Category in English", "" });
            tblTranslation.Rows.Add(new string[] { "169", "يوجد تصنيف بنفس إسم الصنف العربي", "There is a category with the same name as the Arabic Category", "" });
            tblTranslation.Rows.Add(new string[] { "170", "يوجد تصنيف بنفس إسم الصنف الإنجليزي", "There is a category with the same name as the English Category", "" });
            tblTranslation.Rows.Add(new string[] { "171", "مشكلة غير محددة", "Unspecified problem", "" });
            tblTranslation.Rows.Add(new string[] { "172", "البحث", "Search", "" });
            tblTranslation.Rows.Add(new string[] { "173", "التصنيف", "Category", "" });
            tblTranslation.Rows.Add(new string[] { "174", "الباركود", "Barcode", "" });
            tblTranslation.Rows.Add(new string[] { "175", "رقم التصنيف", "Category Number", "" });
            tblTranslation.Rows.Add(new string[] { "176", "رجاء قم بتحديد العنصر الذي تريد حذفه من خلال العرض الشجري", "Please select the item you want to delete by tree view", "" });
            tblTranslation.Rows.Add(new string[] { "177", "الحسابات", "The Accounts", "" });
            tblTranslation.Rows.Add(new string[] { "178", "رقم الحساب", "Account Number", "" });
            tblTranslation.Rows.Add(new string[] { "179", "إسم الحساب إنجليزي", "English Account Name", "" });
            tblTranslation.Rows.Add(new string[] { "180", "إسم الحساب عربي", "Arabic Account Name", "" });
            tblTranslation.Rows.Add(new string[] { "181", "وصف الحساب", "Account Description", "" });
            tblTranslation.Rows.Add(new string[] { "182", "الحساب الأعلى", "Top Account", "" });
            tblTranslation.Rows.Add(new string[] { "183", "العميل", "Client", "" });
            tblTranslation.Rows.Add(new string[] { "184", "رجاء قم بتسجيل إسم الحساب إنجليزي", "Please register the account name in English", "" });
            tblTranslation.Rows.Add(new string[] { "185", "رجاء قم بتسجيل إسم الحساب عربي", "Please register the account name in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "186", "يوجد حساب بنفس إسم الحساب العربي", "There is an account with the same name as the Arabic account", "" });
            tblTranslation.Rows.Add(new string[] { "187", "يوجد حساب بنفس إسم الحساب الانجليزي", "There is an account with the same account name in English", "" });
            tblTranslation.Rows.Add(new string[] { "188", "رجاء قم بتسجيل رقم الحساب", "Please enter the account number", "" });
            tblTranslation.Rows.Add(new string[] { "189", "يوجد حساب بنفس رقم الحساب", "There is an account with the same account number", "" });
            tblTranslation.Rows.Add(new string[] { "190", "وحدات القياس", "Measurement units", "" });
            tblTranslation.Rows.Add(new string[] { "191", "رقم وحدة القياس", "measruing unit number", "" });
            tblTranslation.Rows.Add(new string[] { "192", "إسم الوحدة عربي", "Arabic unit name", "" });
            tblTranslation.Rows.Add(new string[] { "193", "إسم الوحدةانجليزي", "English unit name", "" });
            tblTranslation.Rows.Add(new string[] { "194", "رمز الوحدة عربي", "unit symbol arabic", "" });
            tblTranslation.Rows.Add(new string[] { "195", "رمز الوحدة إنجليزي", "unit symbol english", "" });
            tblTranslation.Rows.Add(new string[] { "196", "الوحدة الأعلى", "top unit", "" });
            tblTranslation.Rows.Add(new string[] { "197", "قيمة التحويل", "Transfer value", "" });
            tblTranslation.Rows.Add(new string[] { "198", "رجاء قم بتسجيل إسم الوحدة عربي", "Please register the unit name in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "199", "رجاء قم بتسجيل إسم الوحدة إنجليزي", "Please register the unit name in English", "" });
            tblTranslation.Rows.Add(new string[] { "200", "رجاء قم بتسجيل رمز الوحدة عربي", "Please register the unit code Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "201", "رجاء قم بتسجيل رمز الوحدة إنجليزي", "Please register the unit code English", "" });
            tblTranslation.Rows.Add(new string[] { "202", "توجد وحدة بنفس إسم الوحدة العربي", "There is a unit with the same name as the Arabic unit", "" });
            tblTranslation.Rows.Add(new string[] { "203", "توجد وحدة بنفس إسم الوحدة الإنجليزي", "There is a unit with the same English name as the unit", "" });
            tblTranslation.Rows.Add(new string[] { "204", "يوجد رمز وحدة بنفس رمز الوحدة العربي", "There is a unit symbol with the same Arabic unit symbol", "" });
            tblTranslation.Rows.Add(new string[] { "205", "يوجد رمز وحدة بنفس رمز الوحدة الإنجليزي", "There is a unit symbol with the same English unit symbol", "" });
            tblTranslation.Rows.Add(new string[] { "206", "لقد إرتكبت خطأ منطقي حيث يوجد عناصر كلاً منهما يتبع الاّخر", "You made a logical error where there are two elements that follow each other", "" });
            tblTranslation.Rows.Add(new string[] { "207", "رجاء قم بتحديد أحد العناصر", "Please select an item", "" });
            tblTranslation.Rows.Add(new string[] { "208", "فشل التنفيذ", "Execution failed", "" });
            tblTranslation.Rows.Add(new string[] { "209", "إنتر للإضافة و + للتعديل و - للحذف", "Enter for Add + for Update - for Delete", "" });
            tblTranslation.Rows.Add(new string[] { "210", "توجد مشكلة", "there is a problem", "" });
            tblTranslation.Rows.Add(new string[] { "211", "عملية الحذف لم تتم", "The deletion process was not completed", "" });
            tblTranslation.Rows.Add(new string[] { "212", "رجاء قم بتحديد السجل الذي تريد حذفه", "Please select the record you want to delete", "" });
            tblTranslation.Rows.Add(new string[] { "213", "إسم الموظف", "Employee Name", "" });
            tblTranslation.Rows.Add(new string[] { "214", "رجاء قم بالمحاولة من جديد", "Please try again", "" });
            tblTranslation.Rows.Add(new string[] { "215", "الباراميترات", "parameters", "" });
            tblTranslation.Rows.Add(new string[] { "216", "رسالة", "Message", "" });
            tblTranslation.Rows.Add(new string[] { "217", "رسالة آلية", "Automatic Message", "" });
            tblTranslation.Rows.Add(new string[] { "218", "النص البرمجي", "script", "" });
            tblTranslation.Rows.Add(new string[] { "219", "وحدات التغليف", "Packaging units", "" });
            tblTranslation.Rows.Add(new string[] { "220", "رقم وحدة التغليف", "Packaging Unit No.", "" });
            tblTranslation.Rows.Add(new string[] { "221", "اسم الوحدة عربي", "Arabic Unit Name", "" });
            tblTranslation.Rows.Add(new string[] { "222", "اسم الوحدة انجليزي", "English Unit Name", "" });
            tblTranslation.Rows.Add(new string[] { "223", "رمز الوحدة عربي", "Arabic Unit Code", "" });
            tblTranslation.Rows.Add(new string[] { "224", "رمز الوحدة انجليزي", "English Unit Code", "" });
            tblTranslation.Rows.Add(new string[] { "225", "رجاء قم بتسجيل إسم وحدة التغليف عربي", "Please register the name of the packaging unit in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "226", "رجاء قم بتسجيل إسم وحدة التغليف إنجليزي", "Please enter the name of the packaging unit in English", "" });
            tblTranslation.Rows.Add(new string[] { "227", "توجد وحدة بنفس إسم الوحدة العربي", "There is a unit with the same name as the Arabic unit", "" });
            tblTranslation.Rows.Add(new string[] { "228", "توجد وحدة بنفس إسم الوحدة الإنجليزي", "There is a unit with the same English name as the unit", "" });
            tblTranslation.Rows.Add(new string[] { "229", "رجاء قم بتسجيل رمز وحدة التغليف عربي", "Please register the packaging unit code Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "230", "رجاء قم بتسجيل رمز وحدة التغليف إنجليزي", "Please register the packing unit code English", "" });
            tblTranslation.Rows.Add(new string[] { "231", "توجد وحدة بنفس رمز الوحدة العربي", "There is a unit with the same Arabic unity symbol.", "" });
            tblTranslation.Rows.Add(new string[] { "232", "توجد وحدة بنفس رمز الوحدة الانجليزي", "There is a unit with the same English unit symbol", "" });
            tblTranslation.Rows.Add(new string[] { "233", "وحدات القياس والتغليف", "Units of measurement and packaging", "" });
            tblTranslation.Rows.Add(new string[] { "234", "رقم الوحدة", "unit number", "" });
            tblTranslation.Rows.Add(new string[] { "235", "وحدة التغليف", "packing unit", "" });
            tblTranslation.Rows.Add(new string[] { "236", "المنتج", "the product", "" });
            tblTranslation.Rows.Add(new string[] { "237", "قيمة وحدةالقياس", "unit of measure value", "" });
            tblTranslation.Rows.Add(new string[] { "238", "وحدة القياس", "measruing unit", "" });
            tblTranslation.Rows.Add(new string[] { "239", "قيمة وحدة القياس والتغليف", "measure and packaging value", "" });
            tblTranslation.Rows.Add(new string[] { "240", "وحدة القياس والتغليف", "unit of measure and packing", "" });
            tblTranslation.Rows.Add(new string[] { "241", "رجاء قم بتحديد السجل الذي تريد حذفه", "Please select the record you want to delete", "" });
            tblTranslation.Rows.Add(new string[] { "242", "رجاء قم بإختيار وحدة التغليف", "Please select a packing unit", "" });
            tblTranslation.Rows.Add(new string[] { "243", "رجاء قم بإختيار المنتج", "Please select the product", "" });
            tblTranslation.Rows.Add(new string[] { "244", "رجاء قم بتسجيل قيمة وحدة القياس أو قيمة وحدة القياس والتغليف", "Please record the UoM value or the UoM value and packaging", "" });
            tblTranslation.Rows.Add(new string[] { "245", "رجاء قم بإختيار وحدة قياس أو وحدة قياس وتغليف", "Please choose a unit of measure or unit of measure and packing", "" });
            tblTranslation.Rows.Add(new string[] { "246", "توجد وحدة بنفس الإسم العربي", "There is a unit with the same Arabic name", "" });
            tblTranslation.Rows.Add(new string[] { "247", "توجد وحدة بنفس الإسم الإنجليزي", "There is a unit with the same English name", "" });
            tblTranslation.Rows.Add(new string[] { "248", "عروض الوحدات المجانية", "Free Unit Offers", "" });
            tblTranslation.Rows.Add(new string[] { "249", "الفئات السعرية", "Price Categories", "" });
            tblTranslation.Rows.Add(new string[] { "250", "رقم الباركود", "Barcode Number", "" });
            tblTranslation.Rows.Add(new string[] { "251", "الرقم المتسلسل للباركود", "Barcode Serial Number", "" });
            tblTranslation.Rows.Add(new string[] { "252", "رجاء قم بإختيار وحدة القياس والتغليف", "Please select a unit of measurement and packaging", "" });
            tblTranslation.Rows.Add(new string[] { "253", "رجاء قم بكتابة رقم الباركود", "Please enter the barcode number", "" });
            tblTranslation.Rows.Add(new string[] { "254", "يوجد باركود بنفس الرقم", "There is a barcode with the same number", "" });
            tblTranslation.Rows.Add(new string[] { "255", "رجاء قم بتحديد السجل الذي ترغب في تحديث بياناته", "Please select the record you wish to update", "" });
            tblTranslation.Rows.Add(new string[] { "256", "رجاء قم بتحديد السجل الذي تريد حذفه", "Please select the record you want to delete", "" });
            tblTranslation.Rows.Add(new string[] { "257", "إنتر للتعديل و + للإضافة و - للحذف", "Enter for edit , + for add , - for delete", "" });
            tblTranslation.Rows.Add(new string[] { "258", "رقم الفئة السعرية", "Price category number", "" });
            tblTranslation.Rows.Add(new string[] { "259", "أقل كيمة", "Minimum quantity", "" });
            tblTranslation.Rows.Add(new string[] { "260", "أعلى كيمة", "Maximum quantity", "" });
            tblTranslation.Rows.Add(new string[] { "261", "رجاء قم بكتابة أقل كمية", "Please write the Minimum quantity", "" });
            tblTranslation.Rows.Add(new string[] { "262", "رجاء قم بكتابة أكبر كمية", "Please write the Maximum quantity", "" });
            tblTranslation.Rows.Add(new string[] { "263", "رجاء قم بكتابة السعر", "Please write the price", "" });
            tblTranslation.Rows.Add(new string[] { "264", "خطأ منطقي أقل كمية تقع ضمن حدود تصنيف كمي آخر", "Logical error The Minimum quantity in falls within the limits of another quantitative classification", "" });
            tblTranslation.Rows.Add(new string[] { "265", "خطأ منطقي أعلى كمية تقع ضمن حدود تصنيف كمي آخر", "Logical error The Maximum quantity in falls within the limits of another quantitative classification", "" });
            tblTranslation.Rows.Add(new string[] { "266", "رقم الفئة السعرية", "Price category number", "" });
            tblTranslation.Rows.Add(new string[] { "267", "السعر", "Price", "" });
            tblTranslation.Rows.Add(new string[] { "268", "رقم العرض", "Promo Number", "" });
            tblTranslation.Rows.Add(new string[] { "269", "عدد الوحدات المجانية", "Number Of Free Units", "" });
            tblTranslation.Rows.Add(new string[] { "270", "تاريخ بداية العرض", "Promo Start Date", "" });
            tblTranslation.Rows.Add(new string[] { "271", "تاريخ نهاية العرض", "Promo End Date", "" });
            tblTranslation.Rows.Add(new string[] { "272", "رجاء قم بكتابة عدد الوحدات المجانية", "Please write the number of free units", "" });
            tblTranslation.Rows.Add(new string[] { "273", "خطأ منطقي في ترتيب التواريخ", "Logical error in the order of dates", "" });
            tblTranslation.Rows.Add(new string[] { "274", "خطأ منطقي في تحديد الكميات", "Logical error in determining quantities", "" });
            tblTranslation.Rows.Add(new string[] { "275", "تفاصيل السلع والخدمات", "Products and Services Details", "" });
            tblTranslation.Rows.Add(new string[] { "276", "السلع والخدمات", "Products and services", "" });
            tblTranslation.Rows.Add(new string[] { "277", "إسم السلعة او الخدمة عربي", "Product Or service Arabic Name", "" });
            tblTranslation.Rows.Add(new string[] { "278", "إسم السلعة او الخدمة إنجليزي", "Product Or service Einglish Name", "" });
            tblTranslation.Rows.Add(new string[] { "279", "وصف السلعة او الخدمة عربي", "product or service Arabic Description", "" });
            tblTranslation.Rows.Add(new string[] { "280", "وصف السلعة او الخدمة إنجليزي", "product or service English Description", "" });
            tblTranslation.Rows.Add(new string[] { "281", "قيمة الوحدة المتبوعة", "followed  unit value", "" });
            tblTranslation.Rows.Add(new string[] { "282", "رقم السلعة او الخدمة", "product or service Number", "" });
            tblTranslation.Rows.Add(new string[] { "283", "السلعة او الخدمة", "product or service", "" });
            tblTranslation.Rows.Add(new string[] { "284", "السلع والخدمات", "Products And Services", "" });
            tblTranslation.Rows.Add(new string[] { "285", "الاسم المفصل للمنتج اوالخدمة عربي", "Detailed name of the product or service in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "286", "الاسم المفصل للمنتج اوالخدمة انجليزي", "Detailed name of the product or service in English", "" });
            tblTranslation.Rows.Add(new string[] { "287", "سلعة", "product", "" });
            tblTranslation.Rows.Add(new string[] { "288", "خدمة", "service", "" });
            tblTranslation.Rows.Add(new string[] { "289", "رجاء قم بتسجيل قيمة وحدة القياس أو قيمة الوحدة المتبوعة", "Please record the unit of measure value or the unit value followed", "" });
            tblTranslation.Rows.Add(new string[] { "290", "رجاء قم بإختيار وحدة قياس أو الوحدة المتبوعة", "Please choose a unit of measure or the unit followed", "" });
            tblTranslation.Rows.Add(new string[] { "291", "رجاء قم بإختيار الخدمة او السلعة", "Please select a service or product", "" });
            tblTranslation.Rows.Add(new string[] { "292", "الموديل او وصف السلعة إنجليزي", "Model or Product description in English", "" });
            tblTranslation.Rows.Add(new string[] { "293", "الموديل أو وصف السلعة عربي", "Model or Product description is Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "294", "المنشآت", "facilities", "" });
            tblTranslation.Rows.Add(new string[] { "295", "إختيار صورة", "Choose a picture", "" });
            tblTranslation.Rows.Add(new string[] { "296", "حذف الصورة", "delete picture", "" });
            tblTranslation.Rows.Add(new string[] { "297", "رقم المنشأة", "No. facility", "" });
            tblTranslation.Rows.Add(new string[] { "298", "إسم المنشأة عربي", "facility Arabic Name", "" });
            tblTranslation.Rows.Add(new string[] { "299", "إسم المنشأة إنجليزي", "facility English Name", "" });
            tblTranslation.Rows.Add(new string[] { "300", "تفاصيل", "details", "" });
            tblTranslation.Rows.Add(new string[] { "301", "رجاء قم بتسجيل إسم المنشأة عربي", "Please register the name of the facility in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "302", "رجاء قم بتسجيل إسم المنشأة إنجليزي", "Please register the name of the facility in English", "" });
            tblTranslation.Rows.Add(new string[] { "303", "توجد منشأة بنفس الإسم العربي", "There is a facility with the same Arabic name", "" });
            tblTranslation.Rows.Add(new string[] { "304", "توجد منشأة بنفس الإسم الإنجليزي", "There is a facility with the same English name", "" });
            tblTranslation.Rows.Add(new string[] { "305", "رقم الفرع", "Branch No.", "" });
            tblTranslation.Rows.Add(new string[] { "306", "المنشأة", "facility", "" });
            tblTranslation.Rows.Add(new string[] { "307", "نوع الفرع", "Branch type", "" });
            tblTranslation.Rows.Add(new string[] { "308", "إسم الفرع عربي", "Branch Name Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "309", "إسم الفرع إنجليزي", "Branch Name English", "" });
            tblTranslation.Rows.Add(new string[] { "310", "فروع المنشأة", "Establishment branches", "" });
            tblTranslation.Rows.Add(new string[] { "311", "بيانات الفرع", "Branch data", "" });
            tblTranslation.Rows.Add(new string[] { "312", "تفاصيل", "Details", "" });
            tblTranslation.Rows.Add(new string[] { "313", "رجاء قم بإختيار منشأة", "Please select a facility", "" });
            tblTranslation.Rows.Add(new string[] { "314", "رجاء قم بتحديد نوع الفرع", "Please select a branch type", "" });
            tblTranslation.Rows.Add(new string[] { "315", "رجاء قم بتسجيل إسم الفرع عربي", "Please register the name of the branch in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "316", "رجاء قم بتسجيل إسم الفرع إنجليزي", "Please register the name of the branch in English", "" });
            tblTranslation.Rows.Add(new string[] { "317", "رجاء قم بتسجيل عنوان الفرع", "Please register the branch address", "" });
            tblTranslation.Rows.Add(new string[] { "318", "يوجد فرع بنفس الإسم العربي", "There is a branch with the same Arabic name", "" });
            tblTranslation.Rows.Add(new string[] { "319", "يوجد فرع بنفس الإسم الإنجليزي", "There is a branch with the same English name", "" });
            tblTranslation.Rows.Add(new string[] { "320", "العنوان", "Address", "" });
            tblTranslation.Rows.Add(new string[] { "321", "وحدات العمليات", "Operation units", "" });
            tblTranslation.Rows.Add(new string[] { "322", "رمز الوحدة", "unit symbol", "" });
            tblTranslation.Rows.Add(new string[] { "323", "رجاء قم بتحديد الفرع الذي تريد إضافة طريقة إتصال جديدة إليه", "Please select the branch you want to add a new contact method to", "" });
            tblTranslation.Rows.Add(new string[] { "324", "رجاء قم بتسجيل وحدة العمليات الجديدة", "Please register the new unit of operations", "" });
            tblTranslation.Rows.Add(new string[] { "325", "توجد وحدة عمليات لها نفس الرمز", "There is a unit of operations with the same symbol", "" });
            tblTranslation.Rows.Add(new string[] { "326", "رمز وحدة العمليات", "Operations unit symbol", "" });
            tblTranslation.Rows.Add(new string[] { "327", "رجاء قم بالضغط على وحدة العمليات التي ترغب في حذفها", "Please click on the unit of operations you wish to delete", "" });
            tblTranslation.Rows.Add(new string[] { "328", "رجاء قم بالضغط على طريقة الإتصال التي تريد حذفها", "Please click on the contact method you want to delete", "" });
            tblTranslation.Rows.Add(new string[] { "329", "الأرفف", "Shelves", "" });
            tblTranslation.Rows.Add(new string[] { "330", "الرقم المتسلسل للرف", "shelf serial number", "" });
            tblTranslation.Rows.Add(new string[] { "331", "رجاء قم بتحديد الفرع الذي تريد إضافة وحدة عمليات جديدة إليه", "Please select the branch you want to add a new operations unit to", "" });
            tblTranslation.Rows.Add(new string[] { "332", "رجاء قم بتحديد الفرع الذي تريد إضافة أرفف جديدة إليه", "Please select the branch you want to add new shelves to", "" });
            tblTranslation.Rows.Add(new string[] { "333", "رجاء قم بتسجيل رمز الرف الجديد", "Please register a new shelf code", "" });
            tblTranslation.Rows.Add(new string[] { "334", "يوجد رف يحمل نفس الرمز", "There is a shelf with the same Code", "" });
            tblTranslation.Rows.Add(new string[] { "335", "رجاء قم بالضغط على الرف الذي ترغب في حذفه", "Please click on the shelf you wish to delete", "" });
            tblTranslation.Rows.Add(new string[] { "336", "رمز الرف", "shelf icon", "" });
            tblTranslation.Rows.Add(new string[] { "337", "الدول", "Countries", "" });
            tblTranslation.Rows.Add(new string[] { "338", "رقم الدولة", "Country number", "" });
            tblTranslation.Rows.Add(new string[] { "339", "إسم الدولة عربي", "Arabic Nountry Name", "" });
            tblTranslation.Rows.Add(new string[] { "340", "إسم الدولة إنجليزي", "English Nountry Name", "" });
            tblTranslation.Rows.Add(new string[] { "341", "الجنسية للذكور عربي", "Nationality for male Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "342", "الجنسية للذكور إنجليزي", "Nationality for male English", "" });
            tblTranslation.Rows.Add(new string[] { "343", "الجنسية للاناث عربي", "Arabic Nationality for female", "" });
            tblTranslation.Rows.Add(new string[] { "344", "الجنسية للاناث إنجليزي", "English Nationality for female ", "" });
            tblTranslation.Rows.Add(new string[] { "345", "إسم العملة عربي", "Arabic currency name", "" });
            tblTranslation.Rows.Add(new string[] { "346", "إسم العملة إنجليزي", "English currency name", "" });
            tblTranslation.Rows.Add(new string[] { "347", "القيمة مقابل الدولار", "Dollar value", "" });
            tblTranslation.Rows.Add(new string[] { "348", "رجاء قم بتحديد نوع الفرع", "Please select a branch type", "" });
            tblTranslation.Rows.Add(new string[] { "349", "رجاء قم بتسجيل إسم الدولة عربي", "Please register the name of the country in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "350", "رجاء قم بتسجيل إسم الدولة إنجليزي", "Please enter the name of the country in English", "" });
            tblTranslation.Rows.Add(new string[] { "351", "رجاء قم بتسجيل الجنسية للذكور عربي", "Please register the nationality for male Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "352", "رجاء قم بتسجيل الجنسية للذكور إنجليزي", "Please register the nationality for males English", "" });
            tblTranslation.Rows.Add(new string[] { "353", "رجاء قم بتسجيل الجنسية للاناث عربي", "Please register the nationality for female Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "354", "رجاء قم بتسجيل الجنسية للاناث إنجليزي", "Please register the nationality for female English", "" });
            tblTranslation.Rows.Add(new string[] { "355", "رجاء قم بتسجيل إسم العملة عربي", "Please register the name of the currency in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "356", "رجاء قم بتسجيل إسم العملة إنجليزي", "Please enter the name of the currency in English", "" });
            tblTranslation.Rows.Add(new string[] { "357", "رجاء قم بتسجيل قيمة العملة مقابل الدولار الأمريكي", "Please record the value of the currency against the US dollar", "" });
            tblTranslation.Rows.Add(new string[] { "358", "توجد دولة بنفس الإسم العربي", "There is a country with the same Arabic name", "" });
            tblTranslation.Rows.Add(new string[] { "359", "توجد دولة بنفس الإسم الإنجليزي", "There is a country with the same English name", "" });
            tblTranslation.Rows.Add(new string[] { "360", "الموظفين", "Employees", "" }); 
            tblTranslation.Rows.Add(new string[] { "360", "إسم الموظف عربي", "Arabic Employee Name", "" });
            tblTranslation.Rows.Add(new string[] { "360", "إسم الموظف إنجليزي", "English Employee Name", "" });
            tblTranslation.Rows.Add(new string[] { "360", "الجنس", "Gender", "" });
            tblTranslation.Rows.Add(new string[] { "360", "الجنسية", "Nationality", "" });
            tblTranslation.Rows.Add(new string[] { "360", "رجاء قم بتسجيل إسم الموظف عربي", "Please enter the employee's name in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "360", "رجاء قم بتسجيل إسم الموظف إنجليزي", "Please enter the employee's name in English", "" });
            tblTranslation.Rows.Add(new string[] { "360", "رجاء قم بإختيار الجنس", "Please select a gender", "" });
            tblTranslation.Rows.Add(new string[] { "360", "رجاء قم بإختيار الجنسية", "Please select a nationality", "" });
            tblTranslation.Rows.Add(new string[] { "360", "يوجد موظف بنفس الإسم العربي", "There is an employee with the same Arabic name", "" });
            tblTranslation.Rows.Add(new string[] { "360", "يوجد موظف بنفس الإسم الإنجليزي", "There is an employee with the same English name", "" });
            tblTranslation.Rows.Add(new string[] { "360", "رجاء قم بتحديد الموظف تريد إضافة طريقة إتصال جديدة إليه", "Please select the employee you want to add a new contact method to", "" });
            tblTranslation.Rows.Add(new string[] { "360", "العملاء", "Clients", "" });
            tblTranslation.Rows.Add(new string[] { "360", "نوع العميل", "customer type", "" });
            tblTranslation.Rows.Add(new string[] { "360", "زبون", "Customer", "" });
            tblTranslation.Rows.Add(new string[] { "360", "مورد", "Supplier", "" });
            tblTranslation.Rows.Add(new string[] { "360", "رقم العميل", "Customer Number", "" });
            tblTranslation.Rows.Add(new string[] { "360", "إسم العميل عربي", "Arabic customer name", "" });
            tblTranslation.Rows.Add(new string[] { "360", "إسم العميل إنجليزي", "English customer nam", "" });
            tblTranslation.Rows.Add(new string[] { "360", "الرقم الضريبي", "Tax Number", "" });
            tblTranslation.Rows.Add(new string[] { "360", "تفاصيل أخرى", "other details", "" });
            tblTranslation.Rows.Add(new string[] { "360", "الفائدة على رأس المال", "Interest On Capital", "" });
            tblTranslation.Rows.Add(new string[] { "360", "نسبة الشريك من الأرباح", "Partners Share Of Profits", "" });
            tblTranslation.Rows.Add(new string[] { "361", "رجاء قم بتسجيل إسم العميل عربي", "Please register the customer's name in Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "362", "رجاء قم بتسجيل إسم العميل إنجليزي", "Please register the customer's name in English", "" });
            tblTranslation.Rows.Add(new string[] { "363", "رجاء قم بتحديد نوع العميل", "Please select the type of customer", "" });
            tblTranslation.Rows.Add(new string[] { "364", "يوجد عميل بنفس الإسم العربي", "There is a customer with the same Arabic name", "" });
            tblTranslation.Rows.Add(new string[] { "365", "يوجد عميل بنفس الإسم الإنجليزي", "There is a customer with the same English name", "" });
            tblTranslation.Rows.Add(new string[] { "366", "قيود اليومية", "Journal Entry", "" });
            tblTranslation.Rows.Add(new string[] { "367", "رقم قيد اليومية", "Journal Entry No.", "" });
            tblTranslation.Rows.Add(new string[] { "368", "التاريخ والوقت", "Date And Time", "" });
            tblTranslation.Rows.Add(new string[] { "369", "بيان القيد المحاسبي", "Accounting Entryt Statement", "" });
            tblTranslation.Rows.Add(new string[] { "370", "رجاء قم بتسجيل التاريخ", "Please record the date", "" });
            tblTranslation.Rows.Add(new string[] { "371", "رجاء قم بتسجيل البيان", "Please sign the statement", "" });
            tblTranslation.Rows.Add(new string[] { "372", "صيغة الوقت والتاريخ غير صحيحة لذلك سيتم عرض التاريخ والوقت الحالي بالصيغة الصحيحة ويمكنك التعديل عليه", "The date and time format is incorrect, so the current date and time will be displayed in the correct format and you can modify it", "" });
            tblTranslation.Rows.Add(new string[] { "373", "الحساب", "Account", "" });
            tblTranslation.Rows.Add(new string[] { "374", "مدين", "Debtor", "" });
            tblTranslation.Rows.Add(new string[] { "375", "دائن", "Creditor", "" });
            tblTranslation.Rows.Add(new string[] { "376", "التفاصيل", "Details", "" });
            tblTranslation.Rows.Add(new string[] { "377", "رجاء قم بتحديد الحساب من القائمة", "Please select the account from the list", "" });
            tblTranslation.Rows.Add(new string[] { "378", "رجاء قم بتسجيل قيمة أحد الجنبين", "Please record the value of one of the sides", "" });
            tblTranslation.Rows.Add(new string[] { "379", "رجاء قم بتسجيل بيانات القيد", "Please register your registration information", "" });
            tblTranslation.Rows.Add(new string[] { "380", "رجاء قم بالضغط على القيد الفرعي الذي ترغب في حذفه", "Please click on the sub-entry that you wish to delete", "" });
            tblTranslation.Rows.Add(new string[] { "381", "رجاء قم بتحديد القيد الرئيسي", "Please select the main constraint", "" });
            tblTranslation.Rows.Add(new string[] { "382", "رجاء قم بتسجيل قيمة أكبر من صفر في أحد الجانبين", "Please record a value greater than zero on one side", "" });
            tblTranslation.Rows.Add(new string[] { "383", "العنوان الوطني", "National address", "" });
            tblTranslation.Rows.Add(new string[] { "384", "رمز الرف", "shelf coding", "" });
            tblTranslation.Rows.Add(new string[] { "385", "رقم التفصيل", "Detail No.", "" });
            tblTranslation.Rows.Add(new string[] { "386", "الإسم المفصل للسلعة أو الخدمة", "Detailed name of the good or service", "" });
            tblTranslation.Rows.Add(new string[] { "387", "الإسم المختصر عربي", "Arabic abbreviation", "" });
            tblTranslation.Rows.Add(new string[] { "388", "الإسم المختصر إنجليزي", "Arabic abbreviation", "" });
            tblTranslation.Rows.Add(new string[] { "389", "كمية المخزون", "Stock Quantity", "" });
            tblTranslation.Rows.Add(new string[] { "390", "تكلفة المخزون", "Stock Cost", "" });
            tblTranslation.Rows.Add(new string[] { "391", "أسلوب إحتساب تكلفة الوحدة", "Cost Calculation Method Of Unit", "" });
            tblTranslation.Rows.Add(new string[] { "392", "تكلفة الوحدة", "Unit Cost", "" });
            tblTranslation.Rows.Add(new string[] { "393", "أسلوب إحتساب سعر البيع", "Price Calculation Method", "" });
            tblTranslation.Rows.Add(new string[] { "394", "توجد سلعة أو خدمة بنفس الإسم العربي المفصل", "There is a good or service with the same detailed Arabic name", "" });
            tblTranslation.Rows.Add(new string[] { "395", "توجد سلعة أو خدمة بنفس الإسم الإنجليزي المفصل", "There is a good or service with the same detailed English name", "" });
            tblTranslation.Rows.Add(new string[] { "396", "توجد سلعة أو خدمة بنفس الإسم العربي المختصر", "There is a good or service with the same Arabic abbreviated name", "" });
            tblTranslation.Rows.Add(new string[] { "397", "توجد سلعة أو خدمة بنفس الإسم الإنجليزي المختصر", "There is a good or service with the same English abbreviated name", "" });
            tblTranslation.Rows.Add(new string[] { "398", "رجاء قم بتحديد طريقة التسعير", "Please select a pricing method", "" });
            tblTranslation.Rows.Add(new string[] { "399", "أرقام الأرفف", "shelves numbers", "" });
            tblTranslation.Rows.Add(new string[] { "400", "رقم الرف", "shelf number", "" });
            tblTranslation.Rows.Add(new string[] { "401", "رجاء قم بإختيار أحد الأرفف", "Please choose one of the shelves", "" });
            tblTranslation.Rows.Add(new string[] { "402", "تمت إضافة هذه الرف مسبقاً", "This shelf has already been added", "" });
            tblTranslation.Rows.Add(new string[] { "403", "رجاء قم بتحديد الرف الذي تريد حذفه", "Please select the shelf you want to delete", "" });
            tblTranslation.Rows.Add(new string[] { "404", "كود الرف", "shelf code", "" });
            tblTranslation.Rows.Add(new string[] { "405", "تجاوزت أكبر رقم وهو 999999.99", "Exceeded the largest number of 999999.99", "" });
            tblTranslation.Rows.Add(new string[] { "406", "الورديات", "Shifts", "" });
            tblTranslation.Rows.Add(new string[] { "407", "رقم الوردية", "shift number", "" });
            tblTranslation.Rows.Add(new string[] { "408", "تاريخ ووقت فتح الوردية", "opening shift Date time ", "" });
            tblTranslation.Rows.Add(new string[] { "409", "رقم الوردية المستلمة", "shift number received", "" });
            tblTranslation.Rows.Add(new string[] { "410", "الرصيد المستلم من الوردية السابقة", "Balance received from previous shift", "" });
            tblTranslation.Rows.Add(new string[] { "411", "رقم المستخدم", "user number", "" });
            tblTranslation.Rows.Add(new string[] { "412", "رقم وحدة العمليات", "Operation unit number", "" });
            tblTranslation.Rows.Add(new string[] { "413", "حالة الوردية", "Shift Status", "" });
            tblTranslation.Rows.Add(new string[] { "414", "تاريخ ووقت إقفال الوردية", "Date And Time Of Shift Closing", "" });
            tblTranslation.Rows.Add(new string[] { "415", "نوع الإقفال", "Closing Type", "" });
            tblTranslation.Rows.Add(new string[] { "416", "رقم الحساب الذي قام بالاقفال", "Closing User Account No", "" });
            tblTranslation.Rows.Add(new string[] { "417", "الرصيد القيدي", "BalanceIn Records", "" });
            tblTranslation.Rows.Add(new string[] { "418", "الرصيد الفعلي", "Actual Balance", "" });
            tblTranslation.Rows.Add(new string[] { "419", "الفرق بين الرصيدين", "Difference Between Two Balances", "" });
            tblTranslation.Rows.Add(new string[] { "420", "الفروع", "Branches", "" });
            tblTranslation.Rows.Add(new string[] { "421", "تسجيل رقم وحدة العمليات", "Operation unit number registration", "" });
            tblTranslation.Rows.Add(new string[] { "422", "رقم وحدة العمليات", "Operation unit number", "" });
            tblTranslation.Rows.Add(new string[] { "423", "رجاء قم بتحديد رقم وحدة العمليات", "Please specify the operation unit number", "" });
            tblTranslation.Rows.Add(new string[] { "424", "رجاء قم بحذف رقم وحدة العمليات السابق قبل الإضافة", "Please delete the previous unit number before adding", "" });
            tblTranslation.Rows.Add(new string[] { "425", "يسمح للحسابات المحلية فقط بفتح وردية جديدة", "Only local accounts are allowed to open a new shift", "" });
            tblTranslation.Rows.Add(new string[] { "426", "لديك وردية نشطة يجب اغلاقها قبل فتح وردية جديدة", "You have an active shift that must be closed before a new shift can be opened", "" });
            tblTranslation.Rows.Add(new string[] { "427", "إستلام وردية الموظف", "Receipt of the employee's shift", "" });
            tblTranslation.Rows.Add(new string[] { "428", "الموظف الذي قام بإقفال الوردية", "The employee who closed the shift", "" }); 
            tblTranslation.Rows.Add(new string[] { "429", "تعديل الحالة", "Edit Status", "" });
            tblTranslation.Rows.Add(new string[] { "430", "يوجد حساب آخر لديه وردية مفتوحة على هذا الجهاز", "Another account has an open shift on this device", "" });
            tblTranslation.Rows.Add(new string[] { "431", "رجاء قم بإغلاق الوردية المفتوحة على وحدة العمليات رقم" , "Please close the open shift on Operations Unit No.", "" });
            tblTranslation.Rows.Add(new string[] { "432", "نسخ", "Copied", "" });
            tblTranslation.Rows.Add(new string[] { "433", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "434", "الرمز البريدي", "Postal code", "" });
            tblTranslation.Rows.Add(new string[] { "435", "إسم المدينة", "City", "" });
            tblTranslation.Rows.Add(new string[] { "436", "إسم الحي", "Neighborhood", "" });
            tblTranslation.Rows.Add(new string[] { "437", "إسم الشارع", "Street Name", "" });
            tblTranslation.Rows.Add(new string[] { "438", "رقم المبنى", "building number", "" });
            tblTranslation.Rows.Add(new string[] { "439", "الرقم الفرعي", "Sub number", "" });
            tblTranslation.Rows.Add(new string[] { "440", "رقم الوحدة", "unit number", "" });
            tblTranslation.Rows.Add(new string[] { "441", "العنوان المختصر", "Short title", "" });
            tblTranslation.Rows.Add(new string[] { "442", "رقم الحساب", "account number", "" });
            tblTranslation.Rows.Add(new string[] { "443", "الدولة", "Country", "" });
            tblTranslation.Rows.Add(new string[] { "444", "رجاء قم بإضافة أسماء بعض الدول", "Please add the names of some countries", "" });
            tblTranslation.Rows.Add(new string[] { "445", "خطأ منطقي النسبة أكبر من مائة", "Logical error The percentage is greater than one hundred", "" });
            tblTranslation.Rows.Add(new string[] { "446", "رقم الحساب غير صحيح", "The account number is incorrect", "" });
            tblTranslation.Rows.Add(new string[] { "447", "الحسابات البنكية", "Bank Accounts", "" });
            tblTranslation.Rows.Add(new string[] { "448", "إسم مالك الحساب", "Account owner name", "" });
            tblTranslation.Rows.Add(new string[] { "449", "إسم البنك", "Bank Name", "" });
            tblTranslation.Rows.Add(new string[] { "450", "رقم الحساب", "Account Number", "" });
            tblTranslation.Rows.Add(new string[] { "451", "رقم الآيبان", "IBAN number", "" });
            tblTranslation.Rows.Add(new string[] { "452", "رجاء قم بتحديد الفرع الذي تريد إضافة حساب بنكي جديد إليه", "Please select the branch you want to add a new bank account to", "" });
            tblTranslation.Rows.Add(new string[] { "453", "رجاء قم بتسجيل إسم مالك الحساب", "Please register the name of the account owner", "" });
            tblTranslation.Rows.Add(new string[] { "454", "رجاء قم بتسجيل إسم البنك", "Please register the name of the bank", "" });
            tblTranslation.Rows.Add(new string[] { "455", "رجاء قم بتسجيل رقم الحساب البنكي", "Please enter the bank account number", "" });
            tblTranslation.Rows.Add(new string[] { "456", "رجاء قم بتسجيل رقم الآيبان", "Please register your IBAN number", "" });
            tblTranslation.Rows.Add(new string[] { "457", "رجاء قم بتسجيل رقم الحساب المحاسبي", "Please enter the account number", "" });
            tblTranslation.Rows.Add(new string[] { "458", "يوجد حساب بنكي يحمل نفس الرقم", "There is a bank account with the same number", "" });
            tblTranslation.Rows.Add(new string[] { "459", "يوجد رقم آيبان يحمل نفس الرقم", "There is an IBAN with the same number", "" });
            tblTranslation.Rows.Add(new string[] { "460", "يوجد حساب محاسبي يحمل نفس الرقم", "There is an account with the same number", "" });
            tblTranslation.Rows.Add(new string[] { "461", "رقم الحساب المحاسبي", "Accounting account number", "" });
            tblTranslation.Rows.Add(new string[] { "462", "البنك", "Bank", "" });
            tblTranslation.Rows.Add(new string[] { "463", "رقم الحساب البنكي", "Bank account number", "" });
            tblTranslation.Rows.Add(new string[] { "464", "صناديق النقدية", "Cash Boxes", "" });
            tblTranslation.Rows.Add(new string[] { "465", "رمز الصندوق", "Box Code", "" });
            tblTranslation.Rows.Add(new string[] { "466", "رجاء قم بتسجيل رمز الصندوق", "Please register the box code", "" });
            tblTranslation.Rows.Add(new string[] { "467", "يوجد صندوق نقدية يحمل نفس الرمز", "There is a cash box with the same symbol", "" });
            tblTranslation.Rows.Add(new string[] { "468", "رجاء قم بالضغط على صندوق النقدية الذي ترغب في حذفه", "Please click on the cash box you wish to delete", "" });
            tblTranslation.Rows.Add(new string[] { "469", "رجاء قم بالضغط على الحساب البنكي الذي ترغب في حذفه", "Please click on the bank account you wish to delete", "" });
            tblTranslation.Rows.Add(new string[] { "470", "المبيعات", "Sales", "" });
            tblTranslation.Rows.Add(new string[] { "471", "سعر البيع", "selling price", "" });
            tblTranslation.Rows.Add(new string[] { "472", "الخصم", "Discount", "" });
            tblTranslation.Rows.Add(new string[] { "473", "سعر البيع بعد الخصم", "Sale price after discount", "" });
            tblTranslation.Rows.Add(new string[] { "474", "الضريبة", "Tax", "" });
            tblTranslation.Rows.Add(new string[] { "475", "سعر البيع شاملا الضريبة", "Selling price including tax", "" });
            tblTranslation.Rows.Add(new string[] { "476", "رقم الباركود", "Barcode Number", "" });
            tblTranslation.Rows.Add(new string[] { "477", "إسم الصنف", "Product Name", "" });
            tblTranslation.Rows.Add(new string[] { "478", "السعر", "price", "" });
            tblTranslation.Rows.Add(new string[] { "479", "الكمية", "Quantity", "" });
            tblTranslation.Rows.Add(new string[] { "480", "نسبة التخفيظ", "Reduction Ratio", "" });
            tblTranslation.Rows.Add(new string[] { "481", "مبلغ التخفيظ", "Discount Amount", "" });
            tblTranslation.Rows.Add(new string[] { "482", "الإجمالي الفرعي", "Subtotal", "" });
            tblTranslation.Rows.Add(new string[] { "483", "نسبة الضريبة", "Tax percentage", "" });
            tblTranslation.Rows.Add(new string[] { "484", "مبلغ الضريبة", "tax amount", "" });
            tblTranslation.Rows.Add(new string[] { "485", "الكمية المجانية", "Free Quantity", "" });
            tblTranslation.Rows.Add(new string[] { "486", "إضافة عميل", "add customer", "" });
            tblTranslation.Rows.Add(new string[] { "487", "رجاء قم بتسجيل رقم العميل", "Please enter the customer number", "" });
            tblTranslation.Rows.Add(new string[] { "488", "الرقم", "Number", "" });
            tblTranslation.Rows.Add(new string[] { "489", "رقم الصنف", "Item No", "" });
            tblTranslation.Rows.Add(new string[] { "490", "الإسم العربي", "Arabic name", "" });
            tblTranslation.Rows.Add(new string[] { "491", "الإسم الإنجليزي", "English name", "" });
            tblTranslation.Rows.Add(new string[] { "492", "السعر", "Price", "" });
            tblTranslation.Rows.Add(new string[] { "493", "الكمية", "Quantity", "" });
            tblTranslation.Rows.Add(new string[] { "494", "مجموع سعر البيع", "Total Sale Price", "" });
            tblTranslation.Rows.Add(new string[] { "495", "الخصم التجاري", "Discount", "" });
            tblTranslation.Rows.Add(new string[] { "496", "سعر البيع بعد الخصم", "Sale Price After Discount", "" });
            tblTranslation.Rows.Add(new string[] { "497", "نسبة ضريبة", "VATrate", "" });
            tblTranslation.Rows.Add(new string[] { "498", "ضريبة المخرجات", "OutputTax", "" });
            tblTranslation.Rows.Add(new string[] { "499", "المجموع الفرعي", "Sub Total", "" });
            tblTranslation.Rows.Add(new string[] { "500", "لم تقم بتحديد الصنف", "You did not specify the category", "" });
            tblTranslation.Rows.Add(new string[] { "501", "تعديل الكمية", "Edit Quantity", "" });
            tblTranslation.Rows.Add(new string[] { "502", "رجاء قم بتسجيل الكمية", "Please record the quantity", "" });
            tblTranslation.Rows.Add(new string[] { "503", "تعديل مبلغ الخصم", "Adjust the discount amount", "" });
            tblTranslation.Rows.Add(new string[] { "504", "رجاء قم بتسجيل مبلغ الخصم", "Please enter the discount amount", "" });
            tblTranslation.Rows.Add(new string[] { "505", "تعديل نسبة الضريبة", "Tax rate adjustment", "" });
            tblTranslation.Rows.Add(new string[] { "506", "رجاء قم بتسجيل نسبة الضريبة", "Please enter the tax rate", "" });
            tblTranslation.Rows.Add(new string[] { "507", "فتح السلة", "open basket", "" });
            tblTranslation.Rows.Add(new string[] { "508", "رجاء قم بتسجيل رقم السلة", "Please enter the basket number", "" });
            tblTranslation.Rows.Add(new string[] { "509", "إجمالي الفاتورة", "Total Bill", "" });
            tblTranslation.Rows.Add(new string[] { "510", "المبلغ المستحق", "Deserved Amount", "" });
            tblTranslation.Rows.Add(new string[] { "511", "المبلغ المتبقي", "Remaining Amount", "" });
            tblTranslation.Rows.Add(new string[] { "512", "إصدار سند قبض", "Issuance Of Receipt Voucher", "" });
            tblTranslation.Rows.Add(new string[] { "513", "لا توجد وردية مفتوحة لهذا الحساب على هذا الجهاز", "There is no open shift for this account on this device", "" });
            tblTranslation.Rows.Add(new string[] { "514", "لا يمكن إصدار أكثر من فاتورة لعربة تسوق واحدة", "No more than one invoice can be issued for one shopping cart", "" });
            tblTranslation.Rows.Add(new string[] { "515", "لا يمكن إصدار فاتورة لعربة تسوق فارغة", "An empty shopping cart cannot be invoiced", "" });
            tblTranslation.Rows.Add(new string[] { "516", "توجد مشكلة لم تسمح بإضافة فاتورة جديدة", "There is a problem that did not allow to add a new invoice", "" });
            tblTranslation.Rows.Add(new string[] { "517", "لا توجد عربة مبيعات بهذا الرقم", "There is no sales cart with this number", "" });
            tblTranslation.Rows.Add(new string[] { "518", "إضافة عميل", "add customer", "" });
            tblTranslation.Rows.Add(new string[] { "519", "حفظ سند قبض", "Keeping a receipt", "" });
            tblTranslation.Rows.Add(new string[] { "520", "آجل", "Postpaid", "" });
            tblTranslation.Rows.Add(new string[] { "521", "شيك بنك", "Bank check", "" });
            tblTranslation.Rows.Add(new string[] { "522", "بنك", "Bank", "" });
            tblTranslation.Rows.Add(new string[] { "523", "كاش", "cash", "" });
            tblTranslation.Rows.Add(new string[] { "524", "إسم العميل", "customer name", "" });
            tblTranslation.Rows.Add(new string[] { "525", "رقم العميل", "customer number", "" });
            tblTranslation.Rows.Add(new string[] { "526", "سند قبض", "Catch Receipt", "" });
            tblTranslation.Rows.Add(new string[] { "527", "لم تقم بتسجيل رقم السلة", "You have not registered the basket number", "" });
            tblTranslation.Rows.Add(new string[] { "528", "لا يوجد عميل بهذه البيانات", "There is no customer with this data", "" });
            tblTranslation.Rows.Add(new string[] { "529", "توجد مشكلة لم تسمح بإضافة سند القبض", "There is a problem that did not allow adding the receipt of arrest", "" });
            tblTranslation.Rows.Add(new string[] { "530", "الفاتورة المرتبطة", "Associated Invoice", "" });
            tblTranslation.Rows.Add(new string[] { "531", "إضافة فاتورة مرتبطة", "Add a linked invoice", "" });
            tblTranslation.Rows.Add(new string[] { "532", "رجاء قم بتسجيل رقم الفاتورة", "Please enter the invoice number", "" });
            tblTranslation.Rows.Add(new string[] { "533", "لا يوجد فاتورة بهذه البيانات", "There is no invoice with this data", "" });
            tblTranslation.Rows.Add(new string[] { "534", "المجموع", "Total", "" });
            tblTranslation.Rows.Add(new string[] { "535", "رقم الحساب اكبر من الرقم 2,147,483,646", "The account number is greater than the number 2,147,483,646", "" });
            tblTranslation.Rows.Add(new string[] { "536", "خطأ", "Error", "" });
            tblTranslation.Rows.Add(new string[] { "537", "رقم الحساب ليس رقم", "Account number is not a number", "" });
            tblTranslation.Rows.Add(new string[] { "538", "طرفي المعادلة غير متساوية", "Both sides of the equation are not equal", "" });
            tblTranslation.Rows.Add(new string[] { "539", "إغلاق", "Close", "" });
            tblTranslation.Rows.Add(new string[] { "540", "عند التسليم", "on delivery", "" });
            tblTranslation.Rows.Add(new string[] { "541", "الحساب البنكي", "Bank account", "" });
            tblTranslation.Rows.Add(new string[] { "542", "الحسابات المعيارية", "Standard Accounts", "" });
            tblTranslation.Rows.Add(new string[] { "543", "الحساب المحاسبي المرتبط", "Linked Accounting Account", "" });
            tblTranslation.Rows.Add(new string[] { "544", "ربط الحسابات المعيارية بالحسابات المحاسبية الموازية", "Linking standard accounts to parallel accounts", "" });
            tblTranslation.Rows.Add(new string[] { "545", "رقم الحساب المعياري", "Standard account number", "" });
            tblTranslation.Rows.Add(new string[] { "546", "إسم الحساب عربي", "Arabic account name", "" });
            tblTranslation.Rows.Add(new string[] { "547", "إسم الحساب إنجليزي", "English account name", "" });
            tblTranslation.Rows.Add(new string[] { "548", "معلومات الحساب", "Account Information", "" });
            tblTranslation.Rows.Add(new string[] { "549", "رجاء قم بتحديد الحساب المحاسبي المرتبط", "Please select the linked account", "" });
            tblTranslation.Rows.Add(new string[] { "550", "يوجد حساب معياري مرتبط بنفس الحساب المحاسبي", "There is a standard account linked to the same accounting account", "" });
            tblTranslation.Rows.Add(new string[] { "551", "إسم الحساب المعياري إنجليزي", "English Standard Account Name", "" });
            tblTranslation.Rows.Add(new string[] { "552", "إسم الحساب المعياري عربي", "Standard account name is Arabic", "" });
            tblTranslation.Rows.Add(new string[] { "553", "لا يمكن التعديل على فاتورة تم حفظها سابقاً", "It is not possible to modify a previously saved invoice", "" });
            tblTranslation.Rows.Add(new string[] { "554", "هل تريد إستلام الوردية الموجودة على هذا الجهاز", "Do you want to receive the pink on this device", "" });
            tblTranslation.Rows.Add(new string[] { "555", "وحدة العمليات الحالية غير مهيئة", "The current operations module is not configured", "" });
            tblTranslation.Rows.Add(new string[] { "556", "لديك وردية مفتوحة على وحدة عمليات أخرى", "You have an open shift on another operations unit", "" });
            tblTranslation.Rows.Add(new string[] { "557", "توجد وردية نشطة على وحدة العمليات الحالية", "There is an active shift on the current process module", "" });
            tblTranslation.Rows.Add(new string[] { "558", "إستلام وردية سابقة", "Previous shift received", "" });
            tblTranslation.Rows.Add(new string[] { "559", "كم المبلغ المستلم", "How much is received?", "" });
            tblTranslation.Rows.Add(new string[] { "560", "هل تريد إستلام وردية أخرى ؟", "Do you want to receive another shift?", "" });
            tblTranslation.Rows.Add(new string[] { "561", "رقم الحساب المحاسبي", "Accounting account number", "" });
            tblTranslation.Rows.Add(new string[] { "562", "لا توجد وردية مفتوحة على هذا الجهاز", "There is no open shift on this device", "" });
            tblTranslation.Rows.Add(new string[] { "563", "لم تقم بتسجيل رقم العميل", "You have not registered the customer number", "" });
            tblTranslation.Rows.Add(new string[] { "564", "هذا الجهاز غير مسجل كوحدة عمليات", "This device is not registered as a unit of operation", "" });
            tblTranslation.Rows.Add(new string[] { "565", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "566", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "567", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "568", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "569", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "570", "", "", "" });

        }
    }

    // اعادة الترجمة حسب اللغة المستخدمة
    public static string ReturnTranslation(string text)
    {
        try
        {
            if (!(text is null))
            {
                DataRow[] dr = tblTranslation.Select("AR = '" + text + "' ");
                if (dr.Length > 0)
                {
                    return dr[0][GeneralVariables.cultureCode].ToString();
                }
                else
                {
                    return text;
                }

            }
            else
            {
                return "";
            }
        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("Cultures  >>  ReturnTranslation", DateTime.Now, ex.Message, ex.Message);
            return "";
        }


    }




    // يقوم بعكس العناصر من اليسار الى اليمين والعكس 
    /// <summary>
    /// 06002  >>  It reverses the elements from left to right and vice versa
    /// </summary>
    /// <param name="form">Required : the form we need reverses its elements / Form Variable </param>
    /// <param name="languageCode">Required : cultures code (ar-SA or en-US or ur-PK) / string Variable </param>
    public static void cheangeCultuer(Control control, string languageCode)
    {
        try
        {
            if (control is Form)
            {


                if (languageCode == "AR")
                {

                    ((Form)control).RightToLeft = RightToLeft.Yes;
                    ((Form)control).RightToLeftLayout = true;

                    foreach (Control cnt1 in control.Controls)
                    {
                        if (cnt1 is Panel || cnt1 is TableLayoutPanel || cnt1 is Form) { cheangeCultuer(cnt1, languageCode); }
                    }
                }
                else if (languageCode != "AR")
                {
                    ((Form)control).RightToLeft = RightToLeft.No;
                    ((Form)control).RightToLeftLayout = false;

                    foreach (Control cnt1 in control.Controls)
                    {
                        if (cnt1 is Panel || cnt1 is TableLayoutPanel || cnt1 is Form) { cheangeCultuer(cnt1, languageCode); }
                    }
                }
            }
            else if (control is Panel || control is TableLayoutPanel)
            {

                foreach (Control cnt2 in control.Controls)
                {

                    if (cnt2 is TextBox)
                    {
                        if (GeneralVariables.cultureCode == "AR")
                        {
                            cnt2.RightToLeft = RightToLeft.Yes;
                        }
                        else
                        {
                            cnt2.RightToLeft = RightToLeft.No;
                        }
                    }

                    //if (cnt2 is Label)
                    //{
                    //    if ((cnt2 as Label).TextAlign == ContentAlignment.MiddleLeft)
                    //    {
                    //        (cnt2 as Label).TextAlign = ContentAlignment.MiddleRight;
                    //    }
                    //    else if ((cnt2 as Label).TextAlign == ContentAlignment.MiddleRight)
                    //    {
                    //        (cnt2 as Label).TextAlign = ContentAlignment.MiddleLeft;
                    //    }

                    //    if (cnt2.RightToLeft == RightToLeft.Yes) { cnt2.RightToLeft = RightToLeft.No; } else { cnt2.RightToLeft = RightToLeft.Yes; };
                    //}
                    //string ss = cnt2.Name;

                    cnt2.Left = cnt2.Parent.Width - cnt2.Width - cnt2.Left;

                    if (cnt2 is Panel || cnt2 is TableLayoutPanel || cnt2 is Form)
                    {
                        if (cnt2.Dock == DockStyle.Left) { cnt2.Dock = DockStyle.Right; } else if (cnt2.Dock == DockStyle.Right) { cnt2.Dock = DockStyle.Left; }
                        cheangeCultuer(cnt2, languageCode);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("Cultures  >>  cheangeCultuer", DateTime.Now, ex.Message, ex.Message);
        }

    }

}

/*
        if (GeneralVariables.arabic)
        {
            lbl01002001001.Text = Cultures.TranslationTable().Rows[0]["en-US"].ToString();
            lbl01002001003.Text = Cultures.TranslationTable().Rows[1]["en-US"].ToString();

            Cultures.cheangeCultuer(this, "en-US");
            GeneralVariables.arabic = false;

        }
        else
        {

            lbl01002001001.Text = Cultures.TranslationTable().Rows[0]["AR"].ToString();
            lbl01002001003.Text = Cultures.TranslationTable().Rows[1]["AR"].ToString();

            Cultures.cheangeCultuer(this, "AR");
            GeneralVariables.arabic = true;

        }
 */




