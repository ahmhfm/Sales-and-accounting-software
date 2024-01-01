using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// قائمة اسماء العناصر
enum myElementType { Form, Panel, Label, TextBox, Button, ComboBox, DataGridView, ListBox, CheckBox, DateTimePicker, RadioButton, PictureBox ,TreeView , TabControl , GroupBox   }

// قائمة اسماء خصائص الالوان للعناصر
enum ColorPropertyName { BackColor_1, BackColor_2, BackColor_3, BackColor_4, BackColor_5, BackColor_6, ForeColor_1, ForeColor_2, ForeColor_3, ForeColor_4, ForeColor_5, ForeColor_6, BorderColor_1, BorderColor_2, BorderColor_3, BorderColor_4, SelectionBackColor_1, SelectionBackColor_2, SelectionBackColor_3, SelectionBackColor_4, SelectionForeColor_1, SelectionForeColor_2, SelectionForeColor_3, SelectionForeColor_4, GridColor_1, GridColor_2, GridColor_3, GridColor_4 };

// 
class DisplayMode
{
    private static DataTable tblColors;  // جدول الالوان
    private static DataTable tblFontAndLocation;    //  جدول الخط
    public static string CurrentForm; // يستخدم عند تغيير خصائص الخط للصفحة  // كل صفحة لها انديكس خاص يحدد الخط الخاص بها

    /// <summary>
    ///  06001  >> fill  color table by colors
    /// </summary>
    public static void fillTblColors()
    {
        if (tblColors is null)
        {

           


            tblColors = new DataTable("TblColors");
            tblColors.Columns.Add("Dark", typeof(string));
            tblColors.Columns.Add("Blue", typeof(string));
            tblColors.Columns.Add("ElementType", typeof(string));
            tblColors.Columns.Add("ColorPropertyName", typeof(string));



            //// النماذج 
            tblColors.Rows.Add(new string[] { "20,20,20", "13, 86, 159", myElementType.Form.ToString(), ColorPropertyName.BackColor_1.ToString() });     // مطابق للحاوية العلوية
            tblColors.Rows.Add(new string[] { "60,60,60", "5, 69, 193", myElementType.Form.ToString(), ColorPropertyName.BackColor_2.ToString() });  // مطابق للحاوية الجانبية
            tblColors.Rows.Add(new string[] { "40,40,40", "93, 152, 233", myElementType.Form.ToString(), ColorPropertyName.BackColor_3.ToString() });    //  مطابق للحاوية الرئيسية
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.Form.ToString(), ColorPropertyName.BackColor_4.ToString() });  // 

            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Form.ToString(), ColorPropertyName.ForeColor_1.ToString() });          // 
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.Form.ToString(), ColorPropertyName.ForeColor_2.ToString() });   // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Form.ToString(), ColorPropertyName.ForeColor_3.ToString() });       //
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.Form.ToString(), ColorPropertyName.ForeColor_4.ToString() }); // 



            // الحاويات
            tblColors.Rows.Add(new string[] { "20,20,20", "13, 86, 159", myElementType.Panel.ToString(), ColorPropertyName.BackColor_1.ToString() }); //  لون الحاوية العلوية في النموذج الرئيسي
            tblColors.Rows.Add(new string[] { "60,60,60", "5, 69, 193", myElementType.Panel.ToString(), ColorPropertyName.BackColor_2.ToString() }); // لون الحاويات الجانبية
            tblColors.Rows.Add(new string[] { "40,40,40", "93, 152, 233", myElementType.Panel.ToString(), ColorPropertyName.BackColor_3.ToString() });   // لون الحاوية الرئيسية في النموذج الرئيسي
            tblColors.Rows.Add(new string[] { "0,0,0", "115,187,236", myElementType.Panel.ToString(), ColorPropertyName.BackColor_4.ToString() }); // لون الفواصل بين الحاويات الجانبية
            tblColors.Rows.Add(new string[] { "20,20,20", "53, 119, 196", myElementType.Panel.ToString(), ColorPropertyName.BackColor_5.ToString() });
            tblColors.Rows.Add(new string[] { "72, 72, 72", "73, 182, 241" , myElementType.Panel.ToString(), ColorPropertyName.BackColor_6.ToString() });

            tblColors.Rows.Add(new string[] { "00,00,00", "00, 00, 00", myElementType.Panel.ToString(), ColorPropertyName.ForeColor_1.ToString() });  //  
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Panel.ToString(), ColorPropertyName.ForeColor_2.ToString() });   // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Panel.ToString(), ColorPropertyName.ForeColor_3.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Panel.ToString(), ColorPropertyName.ForeColor_4.ToString() });   // 


            // GroupBox
            tblColors.Rows.Add(new string[] { "40,40,40", "93, 152, 233", myElementType.GroupBox.ToString(), ColorPropertyName.BackColor_1.ToString() }); //  لون الحاوية العلوية في النموذج الرئيسي
            tblColors.Rows.Add(new string[] { "60,60,60", "5, 69, 193", myElementType.GroupBox.ToString(), ColorPropertyName.BackColor_2.ToString() }); // لون الحاويات الجانبية
            tblColors.Rows.Add(new string[] { "40,40,40", "93, 152, 233", myElementType.GroupBox.ToString(), ColorPropertyName.BackColor_3.ToString() });   // لون الحاوية الرئيسية في النموذج الرئيسي
            tblColors.Rows.Add(new string[] { "0,0,0", "115,187,236", myElementType.GroupBox.ToString(), ColorPropertyName.BackColor_4.ToString() }); // 
            tblColors.Rows.Add(new string[] { "255,255,255", "255,255,255", myElementType.GroupBox.ToString(), ColorPropertyName.BackColor_5.ToString() }); // 

            tblColors.Rows.Add(new string[] { "60, 60, 60", "227, 241, 251", myElementType.GroupBox.ToString(), ColorPropertyName.ForeColor_1.ToString() });  //  
            tblColors.Rows.Add(new string[] { "40,40,40", "93, 152, 233", myElementType.GroupBox.ToString(), ColorPropertyName.ForeColor_2.ToString() });   // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.GroupBox.ToString(), ColorPropertyName.ForeColor_3.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.GroupBox.ToString(), ColorPropertyName.ForeColor_4.ToString() });   // 


            // الملصقات
            tblColors.Rows.Add(new string[] { "20,20,20", "53, 119, 196", myElementType.Label.ToString(), ColorPropertyName.BackColor_1.ToString() }); //  
            tblColors.Rows.Add(new string[] { "230, 230, 230 ", "230, 230, 230  ", myElementType.Label.ToString(), ColorPropertyName.BackColor_2.ToString() });  // 
            tblColors.Rows.Add(new string[] { "190, 190, 190", "227, 241, 251", myElementType.Label.ToString(), ColorPropertyName.BackColor_3.ToString() });    // 
            tblColors.Rows.Add(new string[] { "60, 60, 60", "193, 224, 248", myElementType.Label.ToString(), ColorPropertyName.BackColor_4.ToString() });  // 
            tblColors.Rows.Add(new string[] { "0,0,0", "115,187,236", myElementType.Label.ToString(), ColorPropertyName.BackColor_5.ToString() });  // 
            tblColors.Rows.Add(new string[] { "255, 112, 105", "255, 112, 105", myElementType.Label.ToString(), ColorPropertyName.BackColor_6.ToString() });  // 

            tblColors.Rows.Add(new string[] { "175,175,175", "193,224,248 ", myElementType.Label.ToString(), ColorPropertyName.ForeColor_1.ToString() });   //  1 لون خط الملصقات
            tblColors.Rows.Add(new string[] { "60,60,60", "193,224,248 ", myElementType.Label.ToString(), ColorPropertyName.ForeColor_2.ToString() });     // 2 لون خط الملصقات
            tblColors.Rows.Add(new string[] { "190, 190, 190", "227, 241, 251", myElementType.Label.ToString(), ColorPropertyName.ForeColor_3.ToString() });   // لون خط الملصقات بالقائمة الرئيسية
            tblColors.Rows.Add(new string[] { "175,175,175", "93, 152, 233", myElementType.Label.ToString(), ColorPropertyName.ForeColor_4.ToString() });        // 
            tblColors.Rows.Add(new string[] { "229, 62, 49", "229, 62, 49", myElementType.Label.ToString(), ColorPropertyName.ForeColor_5.ToString() });        // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Label.ToString(), ColorPropertyName.ForeColor_6.ToString() });        // 



            // صناديق النصوص
            tblColors.Rows.Add(new string[] { "255, 255, 255 ", "255, 255, 255", myElementType.TextBox.ToString(), ColorPropertyName.BackColor_1.ToString() }); //   لون خلفيات صناديق النص
            tblColors.Rows.Add(new string[] { "230, 230, 230 ", "230, 230, 230  ", myElementType.TextBox.ToString(), ColorPropertyName.BackColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "240, 240, 240 ", "255, 255, 255", myElementType.TextBox.ToString(), ColorPropertyName.BackColor_3.ToString() });      // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.TextBox.ToString(), ColorPropertyName.BackColor_4.ToString() });       // 

            tblColors.Rows.Add(new string[] { "00, 00, 00", "22, 144, 222", myElementType.TextBox.ToString(), ColorPropertyName.ForeColor_1.ToString() });   //   لون خط صناديق النص
            tblColors.Rows.Add(new string[] { "255,255,255", "255,255,255", myElementType.TextBox.ToString(), ColorPropertyName.ForeColor_2.ToString() });  // 
            tblColors.Rows.Add(new string[] { "240, 240, 240 ", "227, 241, 251", myElementType.TextBox.ToString(), ColorPropertyName.ForeColor_3.ToString() });    // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.TextBox.ToString(), ColorPropertyName.ForeColor_4.ToString() });  // 


            // القوائم المنسدلة
            tblColors.Rows.Add(new string[] { "240, 240, 240 ", "227, 241, 251", myElementType.ComboBox.ToString(), ColorPropertyName.BackColor_1.ToString() }); //   ألوان خلفية القوائم المنسدلة
            tblColors.Rows.Add(new string[] { "230, 230, 230 ", "230, 230, 230 ", myElementType.ComboBox.ToString(), ColorPropertyName.BackColor_2.ToString() });   // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.ComboBox.ToString(), ColorPropertyName.BackColor_3.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.ComboBox.ToString(), ColorPropertyName.BackColor_4.ToString() });      // 

            tblColors.Rows.Add(new string[] { "00, 00, 00", "22, 144, 222", myElementType.ComboBox.ToString(), ColorPropertyName.ForeColor_1.ToString() });   //   ألوان خط القوائم المنسدلة
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.ComboBox.ToString(), ColorPropertyName.ForeColor_2.ToString() });  // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.ComboBox.ToString(), ColorPropertyName.ForeColor_3.ToString() });    // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.ComboBox.ToString(), ColorPropertyName.ForeColor_4.ToString() });  // 





            // الازرار
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Button.ToString(), ColorPropertyName.BackColor_1.ToString() }); //   
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Button.ToString(), ColorPropertyName.BackColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Button.ToString(), ColorPropertyName.BackColor_3.ToString() });    // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Button.ToString(), ColorPropertyName.BackColor_4.ToString() });  // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Button.ToString(), ColorPropertyName.BackColor_5.ToString() });    // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Button.ToString(), ColorPropertyName.BackColor_6.ToString() });  // 


            tblColors.Rows.Add(new string[] { "120, 120, 120", "227, 241, 251", myElementType.Button.ToString(), ColorPropertyName.ForeColor_1.ToString() });   //  اللون الاساسي 1
            tblColors.Rows.Add(new string[] { "200,200,200", "115, 187, 236", myElementType.Button.ToString(), ColorPropertyName.ForeColor_2.ToString() });             //  اللون الاساسي 2 
            tblColors.Rows.Add(new string[] { "200,200,200", "238,232,170", myElementType.Button.ToString(), ColorPropertyName.ForeColor_3.ToString() });         //  اللون الاساسي 3 
            tblColors.Rows.Add(new string[] { "23, 160, 93", "93, 221, 88", myElementType.Button.ToString(), ColorPropertyName.ForeColor_4.ToString() });    // اللون الاساسي 4 // اخضر و بب
            tblColors.Rows.Add(new string[] { "255, 168, 6", "255, 168, 6", myElementType.Button.ToString(), ColorPropertyName.ForeColor_5.ToString() });    //  لون الحركة فوق الزر
            tblColors.Rows.Add(new string[] { "23, 160, 93", "8, 57, 106", myElementType.Button.ToString(), ColorPropertyName.ForeColor_6.ToString() });     //  لون الضغطة

            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Button.ToString(), ColorPropertyName.BorderColor_1.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Button.ToString(), ColorPropertyName.BorderColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Button.ToString(), ColorPropertyName.BorderColor_3.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.Button.ToString(), ColorPropertyName.BorderColor_4.ToString() });     //



            // صندوق القوائم
            tblColors.Rows.Add(new string[] { "60, 60, 60", "193, 224, 248", myElementType.ListBox.ToString(), ColorPropertyName.BackColor_1.ToString() }); //   
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.ListBox.ToString(), ColorPropertyName.BackColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.ListBox.ToString(), ColorPropertyName.BackColor_3.ToString() });    // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.ListBox.ToString(), ColorPropertyName.BackColor_4.ToString() });  // 

            tblColors.Rows.Add(new string[] { "190, 190, 190", "22, 144, 222", myElementType.ListBox.ToString(), ColorPropertyName.ForeColor_1.ToString() });   //  الوان خط الزر 
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.ListBox.ToString(), ColorPropertyName.ForeColor_2.ToString() });    //   لون التحرك فوق الزر
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.ListBox.ToString(), ColorPropertyName.ForeColor_3.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.ListBox.ToString(), ColorPropertyName.ForeColor_4.ToString() });    // 


            //  العرض الشجري
            tblColors.Rows.Add(new string[] { "60, 60, 60", "227, 241, 251", myElementType.TreeView.ToString(), ColorPropertyName.BackColor_1.ToString() }); //   
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.TreeView.ToString(), ColorPropertyName.BackColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "255,255,255", "255,255,255", myElementType.TreeView.ToString(), ColorPropertyName.BackColor_3.ToString() });    // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.TreeView.ToString(), ColorPropertyName.BackColor_4.ToString() });  // 

            tblColors.Rows.Add(new string[] { "190, 190, 190", "22, 144, 222", myElementType.TreeView.ToString(), ColorPropertyName.ForeColor_1.ToString() });   //   
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.TreeView.ToString(), ColorPropertyName.ForeColor_2.ToString() });    //   
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.TreeView.ToString(), ColorPropertyName.ForeColor_3.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.TreeView.ToString(), ColorPropertyName.ForeColor_4.ToString() });    // 

            //  TabControl 
            tblColors.Rows.Add(new string[] { "255,255,255", "255,255,255", myElementType.TabControl.ToString(), ColorPropertyName.BackColor_1.ToString() }); //   
            tblColors.Rows.Add(new string[] { " 40,40,40"," 93, 152, 233", myElementType.TabControl.ToString(), ColorPropertyName.BackColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "255,255,255", "255,255,255", myElementType.TabControl.ToString(), ColorPropertyName.BackColor_3.ToString() });    // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.TabControl.ToString(), ColorPropertyName.BackColor_4.ToString() });  // 

            tblColors.Rows.Add(new string[] { "190, 190, 190", "22, 144, 222", myElementType.TabControl.ToString(), ColorPropertyName.ForeColor_1.ToString() });   //   
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.TabControl.ToString(), ColorPropertyName.ForeColor_2.ToString() });    //   
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.TabControl.ToString(), ColorPropertyName.ForeColor_3.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.TabControl.ToString(), ColorPropertyName.ForeColor_4.ToString() });    // 

            //  CheckBox 
            tblColors.Rows.Add(new string[] { "60, 60, 60", "227, 241, 251", myElementType.CheckBox.ToString(), ColorPropertyName.BackColor_1.ToString() }); //   *
            tblColors.Rows.Add(new string[] { " 40,40,40", " 93, 152, 233", myElementType.CheckBox.ToString(), ColorPropertyName.BackColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "255,255,255", "255,255,255", myElementType.CheckBox.ToString(), ColorPropertyName.BackColor_3.ToString() });    // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.CheckBox.ToString(), ColorPropertyName.BackColor_4.ToString() });  // 

            tblColors.Rows.Add(new string[] { "20,20,20", "13, 86, 159", myElementType.CheckBox.ToString(), ColorPropertyName.ForeColor_1.ToString() });   //   
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.CheckBox.ToString(), ColorPropertyName.ForeColor_2.ToString() });    //   
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.CheckBox.ToString(), ColorPropertyName.ForeColor_3.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.CheckBox.ToString(), ColorPropertyName.ForeColor_4.ToString() });    // 


            // DataGridView ألوان جداول عرض البيانات 
            tblColors.Rows.Add(new string[] { "0,0,0", "227, 241, 251", myElementType.DataGridView.ToString(), ColorPropertyName.BackColor_1.ToString() });     //   
            tblColors.Rows.Add(new string[] { "60, 60, 60", "193, 224, 248", myElementType.DataGridView.ToString(), ColorPropertyName.BackColor_2.ToString() });    // 
            tblColors.Rows.Add(new string[] { "16, 16, 16", "227, 241, 251", myElementType.DataGridView.ToString(), ColorPropertyName.BackColor_3.ToString() });    // 
            tblColors.Rows.Add(new string[] { "72, 72, 72", "73, 182, 241", myElementType.DataGridView.ToString(), ColorPropertyName.BackColor_4.ToString() });     // 
            tblColors.Rows.Add(new string[] { "32, 32, 32", "213, 234, 250", myElementType.DataGridView.ToString(), ColorPropertyName.BackColor_5.ToString() });    // 
            tblColors.Rows.Add(new string[] { "72, 72, 72", "73, 182, 241", myElementType.DataGridView.ToString(), ColorPropertyName.BackColor_6.ToString() });     // 

            tblColors.Rows.Add(new string[] { "148, 148, 148", "22,144,222", myElementType.DataGridView.ToString(), ColorPropertyName.ForeColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "190, 190, 190", "22, 144, 222", myElementType.DataGridView.ToString(), ColorPropertyName.ForeColor_1.ToString() });    //   
            tblColors.Rows.Add(new string[] { "72, 72, 72", "73, 182, 241", myElementType.DataGridView.ToString(), ColorPropertyName.ForeColor_3.ToString() });       // 
            tblColors.Rows.Add(new string[] { "190, 190, 190", "255, 255, 255", myElementType.DataGridView.ToString(), ColorPropertyName.ForeColor_4.ToString() });   // 
            tblColors.Rows.Add(new string[] { "190, 190, 190", "22, 144, 222", myElementType.DataGridView.ToString(), ColorPropertyName.ForeColor_5.ToString() });    // 
            tblColors.Rows.Add(new string[] { "190, 190, 190", "255, 255, 255", myElementType.DataGridView.ToString(), ColorPropertyName.ForeColor_6.ToString() });   // 

            tblColors.Rows.Add(new string[] { "0,0,0", "22,144,222", myElementType.DataGridView.ToString(), ColorPropertyName.BorderColor_1.ToString() });     // 
            tblColors.Rows.Add(new string[] { "0,0,0", "115,187,236", myElementType.DataGridView.ToString(), ColorPropertyName.BorderColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.DataGridView.ToString(), ColorPropertyName.BorderColor_3.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.DataGridView.ToString(), ColorPropertyName.BorderColor_4.ToString() });     // 

            tblColors.Rows.Add(new string[] { "72, 72, 72", "73, 182, 241", myElementType.DataGridView.ToString(), ColorPropertyName.SelectionBackColor_1.ToString() });     // 
            tblColors.Rows.Add(new string[] { "72, 72, 72", "73, 182, 241", myElementType.DataGridView.ToString(), ColorPropertyName.SelectionBackColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "60, 60, 60", "193, 224, 248", myElementType.DataGridView.ToString(), ColorPropertyName.SelectionBackColor_3.ToString() });     // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.DataGridView.ToString(), ColorPropertyName.SelectionBackColor_4.ToString() });     // 

            tblColors.Rows.Add(new string[] { "190, 190, 190", "255, 255, 255", myElementType.DataGridView.ToString(), ColorPropertyName.SelectionForeColor_1.ToString() });     // 
            tblColors.Rows.Add(new string[] { "190, 190, 190", "255, 255, 255", myElementType.DataGridView.ToString(), ColorPropertyName.SelectionForeColor_2.ToString() });     // 
            tblColors.Rows.Add(new string[] { "148, 148, 148", "22,144,222", myElementType.DataGridView.ToString(), ColorPropertyName.SelectionForeColor_3.ToString() });       // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.DataGridView.ToString(), ColorPropertyName.SelectionForeColor_4.ToString() });              // 

            tblColors.Rows.Add(new string[] { "0,0,0", "227, 241, 251", myElementType.DataGridView.ToString(), ColorPropertyName.GridColor_1.ToString() });  // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.DataGridView.ToString(), ColorPropertyName.GridColor_2.ToString() });  // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.DataGridView.ToString(), ColorPropertyName.GridColor_3.ToString() });  // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.DataGridView.ToString(), ColorPropertyName.GridColor_4.ToString() });  // 

            //// صندوق الصور 
            tblColors.Rows.Add(new string[] { "20,20,20", "13, 86, 159", myElementType.PictureBox.ToString(), ColorPropertyName.BackColor_1.ToString() });     // 
            tblColors.Rows.Add(new string[] { "60,60,60", "5, 69, 193", myElementType.PictureBox.ToString(), ColorPropertyName.BackColor_2.ToString() });  // 
            tblColors.Rows.Add(new string[] { "40,40,40", "93, 152, 233", myElementType.PictureBox.ToString(), ColorPropertyName.BackColor_3.ToString() });    //  
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.PictureBox.ToString(), ColorPropertyName.BackColor_4.ToString() });  // 

            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.PictureBox.ToString(), ColorPropertyName.ForeColor_1.ToString() });          // 
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.PictureBox.ToString(), ColorPropertyName.ForeColor_2.ToString() });   // 
            tblColors.Rows.Add(new string[] { "00,00,00", "00,00,00", myElementType.PictureBox.ToString(), ColorPropertyName.ForeColor_3.ToString() });       //
            tblColors.Rows.Add(new string[] { "00, 00, 00", "00, 00, 00", myElementType.PictureBox.ToString(), ColorPropertyName.ForeColor_4.ToString() }); // 
        }
    }

    // اعادة اللون حسب نمط العرض المستخدم
    public static Color ReturnColor(myElementType _ElementType, ColorPropertyName _ColorPropertyName)
    {
        try
        {
            if (!(tblColors is null))
            {
                DataRow[] dr = tblColors.Select("ElementType = '" + _ElementType + "' and ColorPropertyName = '" + _ColorPropertyName + "'");
                if (dr.Length > 0)
                {
                    string[] RGB = dr[0][GeneralVariables.DisplayMode].ToString().Split(',');
                    return Color.FromArgb(Convert.ToInt32(RGB[0]), Convert.ToInt32(RGB[1]), Convert.ToInt32(RGB[2]));
                }
                return Color.Red;
            }
            else
            {
                return Color.Red;
            }
        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("DisplayMode  >> ReturnColor", DateTime.Now, ex.Message, ex.Message);
            return Color.Red;  
        }


    }


    //*********************************************

    // تعبئة جدول الخطوط ومواقع النماذج
    public static void fillTblFontAndLocation()
    {
        try
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\" + "FontAndLocation.xml"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\" + "FontAndLocation.xml");
                tblFontAndLocation = ds.Tables[0];
            }


            if (tblFontAndLocation is null)
            {

                tblFontAndLocation = new DataTable("tblFont");
                tblFontAndLocation.Columns.Add("RowIndex", typeof(string));
                tblFontAndLocation.Columns.Add("formName", typeof(string));
                tblFontAndLocation.Columns.Add("fontName", typeof(string));
                tblFontAndLocation.Columns.Add("fontSize", typeof(float));
                tblFontAndLocation.Columns.Add("Left", typeof(string));
                tblFontAndLocation.Columns.Add("Top", typeof(string));

                tblFontAndLocation.Rows.Add(new string[] { "0", "frmSplash00", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "1", "frmMain01", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "2", "frmConnectionSettings02", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "3", "frmLogin03", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "4", "", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "5", "frmAccount05", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "6", "frmMainMenu06", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "7", "frmPermissionsGroup07", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "8", "frmManufacturers08", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "9", "frmProductsAndServices09", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "10", "frmCategories10", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "11", "frmAccounts11", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "12", "frmMeasureUnit12", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "13", "frmEncapsulationUnits13", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "14", "frmproductAndServicesDetails14", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "15", "frmEnterprise15", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "16", "frmEnterpriseBranches16", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "17", "frmCountries17", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "18", "frmEmployees18", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "19", "frmClients19", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "20", "frmJournalEntry20", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "20", "frmShifts21", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "21", "frmOperationUnits22", "Microsoft Sans Serif", "5", "1000", "1000" });  // نموذج وحدات العمليات
                tblFontAndLocation.Rows.Add(new string[] { "22", "frmSales23", "Microsoft Sans Serif", "5", "1000", "1000" });  // نموذج المبيعات
                tblFontAndLocation.Rows.Add(new string[] { "23", "frmStandardAccounts24", "Microsoft Sans Serif", "5", "1000", "1000" });  // نموذج الحسابت المعيارية
                tblFontAndLocation.Rows.Add(new string[] { "24", "", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "25", "", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "26", "", "Microsoft Sans Serif", "5", "1000", "1000" });  // 
                tblFontAndLocation.Rows.Add(new string[] { "27", "", "Microsoft Sans Serif", "5", "1000", "1000" });  // 

                tblFontAndLocation.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "\\" + "FontAndLocation.xml");
            }
        }
        catch (Exception ex)
        {

            GeneralAction.AddNewNotification("DisplayMode  >> fillTblFontAndLocation", DateTime.Now, ex.Message, ex.Message);

        }
        
    }



    // اعادة خط النموذج
    public static Font ReturnFont(string formName)
    {
        try
        {
            CurrentForm = formName;
            if (!(tblFontAndLocation is null))
            {
                DataRow[] row = tblFontAndLocation.Select("formName = '" + formName + "'");
                if (row != null)
                {

                    if (row.Length > 0)
                    {

                        return new Font(row[0][2].ToString(), float.Parse(row[0][3].ToString()));
                    }
                }
                return new Font("Microsoft Sans Serif", 12);
            }
            else
            {
                return new Font("Microsoft Sans Serif", 12);
            }
        }
        catch (Exception ex) 
        {

            GeneralAction.AddNewNotification("DisplayMode  >> ReturnFont", DateTime.Now, ex.Message, ex.Message);
            return new Font("Microsoft Sans Serif", 12);

        }


    }


    // اعادة موقع النموذج
    public static Point ReturnLocation(string formName)
    {
        try
        {
            CurrentForm = formName;
            if (!(tblFontAndLocation is null))
            {
                DataRow[] row = tblFontAndLocation.Select("formName = '" + formName + "'");

                if (row != null)
                {
                    if (row.Length > 0)
                    {
                        return new Point(int.Parse(row[0][4].ToString()), int.Parse(row[0][5].ToString()));
                    }
                }
                return new Point(10, 10);
            }
            else
            {
                return new Point(10, 10);
            }
        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("DisplayMode  >> ReturnLocation", DateTime.Now, ex.Message, ex.Message);
            return new Point(10, 10);

        }

    }


    // تغيير خط و موقع النموذج
    public static void ChangeFontAndLocation(string NewFontName, float NewFontSize, int NewLeft, int Newtop)
    {
        try
        {
            DataRow[] row = tblFontAndLocation.Select("formName = '" + CurrentForm + "'");

            if (row != null)
            {
                if (row.Length > 0)
                {
                    row[0][2] = NewFontName;
                    row[0][3] = NewFontSize;
                    row[0][4] = NewLeft.ToString();
                    row[0][5] = Newtop.ToString();

                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\" + "fontAndLocation.xml"))
                    {
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\" + "fontAndLocation.xml");
                    }

                    tblFontAndLocation.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "\\" + "fontAndLocation.xml");

                    GeneralAction.RefreshAllElementsProperties();// تحديث خصائص العناصر
                }
            }
        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("DisplayMode  >> ChangeFontAndLocation", DateTime.Now, ex.Message, ex.Message);

        }


    }

}


