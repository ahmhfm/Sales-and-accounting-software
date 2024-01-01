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
            //"البحث عن"
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
            tblTranslation.Rows.Add(new string[] { "294", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "295", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "296", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "297", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "298", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "299", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "300", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "301", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "302", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "303", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "304", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "305", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "306", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "307", "", "", "" });
            tblTranslation.Rows.Add(new string[] { "308", "", "", "" });
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




