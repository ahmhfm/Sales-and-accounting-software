using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


enum ActionType { add, edit }
enum TextBoxType { String, Int, Decimal }

/// <summary>
/// 03  >>  Elemnts Tools
/// </summary>
class ElementsTools
{
    // القائمة المنسدلة
    /// <summary>
    /// 03001  >> ComboBox
    /// </summary>
    public class ComboBox_
    {
        // القائمة المنسدلة متعددة الاعمدة
        /// <summary>
        /// 03001001  >>  ComboBox multi columns 
        /// </summary>
        public class ComboBoxMultiColumns
        {
            
            // دالة تعيد مصفوفة تستخدم للقوائم المنسدلة متعددة القوائم
            /// <summary>
            /// 03001001001  >>  return data used for fill combobox multi columns 
            /// </summary>
             /// <param name="DT">Required : data source  / DataTable Variable</param>
            /// <param name="replace_Char1">Required : Alternate character for spaces / char Variable</param>
            /// <param name="replace_Char2">Required : Alternate character for spaces /char Variable</param>
            /// <param name="replace_CharOther">Required : Alternate character for spaces /char Variable</param>
            /// <param name="col1_charCount">Required : The number of characters in the column /float Variable</param>
            /// <param name="col2_charCount">Required : The number of characters in the column /float Variable</param>
            /// <param name="colOther_charCount">Required : The number of characters in the column /float Variable</param>
            /// <returns> Return string Array</returns>
            public static string[] returnArrayForMultiColumnsComboBox( DataTable @DT, char @replace_Char1, char @replace_Char2, char @replace_CharOther, float @col1_charCount, float @col2_charCount, float @colOther_charCount)
            {

                try
                {
                    DataTable dt = @DT;

                    int colCount = dt.Columns.Count; // عددالاعمدة
                    int rowCount = dt.Rows.Count;
                    int rowCou = 0;  // ترتيبالصف

                    char ww1 = @replace_Char1;
                    char ww2 = @replace_Char2;
                    char ww3 = @replace_CharOther;

                    float col1charCount = @col1_charCount;
                    float col2charCount = @col2_charCount;
                    float col3charCount = @colOther_charCount;

                    string[] returnValue = new string[rowCount];

                    foreach (DataRow drow in dt.Rows)
                    {

                        string itemString = "";
                        rowCou++;
                        int colCou = 0; // ترتيبالعمود


                        foreach (object o in drow.ItemArray)
                        {
                            colCou++;
                            string word = o.ToString();


                            if (colCou == 1)
                            {
                                float x = (word.Length - col1charCount);
                                if (x > 0)
                                {
                                    float yyy = (x);
                                    double yy = Math.Round(word.Length - yyy);
                                    int y = (int)yy;
                                    y = Math.Abs(y);
                                    string wordx = word;
                                    if (wordx.Length > yyy)
                                        word = wordx.Substring(0, y);
                                    itemString += word + " | ";
                                }
                                else if (x < 0)
                                {
                                    x = x * -1;
                                    float yy = (x);
                                    int y = (int)yy;
                                    word = new string(ww1, y) + word;
                                    itemString += word + " | ";
                                }
                            }




                            else if (colCou == 2)
                            {
                                float x = (word.Length - col2charCount);
                                if (x > 0)
                                {
                                    float yyy = (x);
                                    double yy = Math.Round(word.Length - yyy);
                                    int y = (int)yy;
                                    y = Math.Abs(y);
                                    string wordx = word;
                                    if (wordx.Length > yyy)
                                        word = wordx.Substring(0, y);
                                    itemString += word;
                                    if (colCount > colCou)
                                    {
                                        itemString += " | ";
                                    }

                                }
                                else if (x < 0)
                                {
                                    x = x * -1;
                                    float yy = (x);
                                    int y = (int)yy;
                                    word = word + new string(ww2, y);
                                    itemString += word;
                                    if (colCount > colCou)
                                    {
                                        itemString += " | ";
                                    }
                                }
                            }

                            else
                            {
                                float x = (word.Length - col3charCount);
                                if (x > 0)
                                {
                                    float yyy = (x);
                                    double yy = Math.Round(word.Length - yyy);
                                    int y = (int)yy;
                                    y = Math.Abs(y);
                                    string wordx = word;
                                    if (wordx.Length > yyy)
                                        word = wordx.Substring(0, y);
                                    itemString += word;
                                    if (colCount > colCou)
                                    {
                                        itemString += " | ";
                                    }
                                }
                                else if (x < 0)
                                {
                                    x = x * -1;
                                    float yy = (x);
                                    int y = (int)yy;
                                    word = word + new string(ww3, y);
                                    itemString += word;
                                    if (colCount > colCou)
                                    {
                                        itemString += " | ";
                                    }
                                }
                            }


                        }
                        returnValue[rowCou - 1] = itemString;
                    }

                    return returnValue;
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >> ComboBox_  >>  ComboBoxMultiColumns  >>  returnArrayForMultiColumnsComboBox", DateTime.Now, ex.Message, ex.Message);

                    return null;
                }

                /*
                private void button1_Click(object sender, EventArgs e)
                {
                    string result = "";
                    string result2 = "";
                    DataTable dt = DataTools_02.Databases_02002.Sqlite_02002002.ReadTableSqlite_02002002002.ReadTabeAndRetarnAllColumns_02002002002002("tbl1", ConnectionsTools_05.SQLiteConnection01, ref result);
                    if (result == "success")
                    {
                        string[] items = ElemntsTools_03.ComboBox_03001.ComboBoxMultiColumns_03001001.returnArrayForMultiColumnsComboBox_03001001001(dt, '0', ' ', ' ', 8, 8, 8, ref result2);
                        if (result2 == "success") { comboBox1.Items.AddRange(items); } else { MessageBox.Show(result2); }
                    }
                    else { MessageBox.Show(result2); }
                }
                */
            }


            // بحث في القائمة المنسدلة المتعددة القوائم يعيد رقم الانديكس
            /// <summary>
            /// 03001001002  >>  search in multi columns combobox then return index number ...
            /// </summary>
             /// <param name="SearchString">Required : search string /string Variable</param>
            /// <param name="cmbobox">Required : the ComboBox We need search insid him /ComboBox Variable</param>
            /// <returns>number of index by int variable</returns>
            public static int SearchReturnItemIndexFromComboBoxMultiColumns(  string SearchString, ComboBox cmbobox)
            {

                try
                {
                    string[] items = new string[cmbobox.Items.Count];
                    for (int i = 0; i < cmbobox.Items.Count; i++)
                    {
                        items[i] = cmbobox.Items[i].ToString();
                    }


                    int indexx = -1;
                    int indexxxx = 0;
                    string y1 = "";
                    string o1 = "";
                    string o = SearchString;
                    foreach (string item in items)
                    {
                        indexx += 1;
                        string[] x10 = item.Split('|');
                        foreach (string x11 in x10)
                        {

                            if (x11 != " " || x11 != "  " || x11 != "   " || x11 != "    ")
                            {
                                char[] xx = x11.ToCharArray();
                                string yy = "";
                                int ww = 0;
                                int ww1 = 0;
                                foreach (char x in xx)
                                {
                                    ww += 1;
                                    if (x != '0')
                                    {

                                        foreach (char x1 in xx)
                                        {
                                            ww1 += 1;
                                            if (ww1 >= ww && x1 != ' ')
                                            {
                                                yy += x1;
                                            }

                                        }
                                        break;
                                    }

                                }

                                if (yy == o)
                                {
                                    o1 = o;
                                    y1 = yy;
                                    indexxxx = indexx;
                                    break;
                                }

                            }


                        }

                        if (y1 == o1 && y1 != "")
                        {
                            break;
                        }
                        if (indexx == items.Length - 1)
                        {
                            indexxxx = -1;
                        }

                    }

                    cmbobox.SelectedIndex = indexxxx; // تحديد العنصر في القائمة

                    return indexxxx; // اعادة رقم الانديكس
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >> ComboBox_  >>  ComboBoxMultiColumns  >>  SearchReturnItemIndexFromComboBoxMultiColumns", DateTime.Now, ex.Message, ex.Message);

                    return -100;
                }

                /*
                private void button2_Click(object sender, EventArgs e)
                {
                    string result = "";
                    int x = ElemntsTools_03.ComboBox_03001.ComboBoxMultiColumns_03001001.SearchReturnItemIndexFromComboBoxMultiColumns_03001001002("ali", comboBox1, ref result);
                    if (result != "success") { MessageBox.Show(result); }
                }
                */
            }

            // دالة تقوم بتحديد العنصر في القائمة المنسدلة بناء على العنصر الذي تم تحديده في الداتا قريد فيو
            /// <summary>
            /// 03001001003  >>  select item in ComboBox by Selected Row In DataGridView
            /// </summary>
            /// <param name="datagridview">Required : the DataGridView /DataGridView Variable</param>
            /// <param name="combobox">Required : the ComboBox /ComboBox Variable</param>
            /// <param name="Index_ForColumnInDataGridViewRowIsHaveValue">Required : index of cell have the value in DataGridView  /int Variable</param>
            /// <returns>return index row in DataGridView / int Variable</returns>
            public static int ConnectBetweenComboBoxAndDataGridView( DataGridView datagridview, ComboBox combobox, int Index_ForColumnInDataGridViewRowIsHaveValue)
            {


                try
                {
                    DataGridViewRow DgvR = datagridview.CurrentRow;

                    //if (DgvR is null)
                    //{ result = "row null"; return 0; }


                    string[] items = new string[combobox.Items.Count];
                    for (int i = 0; i < combobox.Items.Count; i++)
                    {
                        items[i] = combobox.Items[i].ToString();
                    }


                    int indexx = -1;
                    int indexxxx = 0;
                    string y1 = "";
                    string o1 = "";
                    string o = DgvR.Cells[Index_ForColumnInDataGridViewRowIsHaveValue].Value.ToString();
                    foreach (string item in items)
                    {
                        indexx += 1;
                        string[] x10 = item.Split('|');
                        foreach (string x11 in x10)
                        {

                            if (x11 != " " || x11 != "  " || x11 != "   " || x11 != "    ")
                            {
                                char[] xx = x11.ToCharArray();
                                string yy = "";
                                int ww = 0;
                                int ww1 = 0;
                                foreach (char x in xx)
                                {
                                    ww += 1;
                                    if (x != '0')
                                    {

                                        foreach (char x1 in xx)
                                        {
                                            ww1 += 1;
                                            if (ww1 >= ww && x1 != ' ')
                                            {
                                                yy += x1;
                                            }

                                        }
                                        break;
                                    }

                                }

                                if (yy == o)
                                {
                                    o1 = o;
                                    y1 = yy;
                                    indexxxx = indexx;
                                    break;
                                }

                            }


                        }

                        if (y1 == o1 && y1 != "")
                        {
                            break;
                        }
                        if (indexx == items.Length - 1)
                        {
                            indexxxx = -1;
                        }

                    }
                    combobox.SelectedIndex = indexxxx;

                    return indexxxx;
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >> ComboBox_  >>  ComboBoxMultiColumns  >>  ConnectBetweenComboBoxAndDataGridView", DateTime.Now, ex.Message, ex.Message);

                    return -100;
                }

                /*
                private void dataGridView1_SelectionChanged(object sender, EventArgs e)
                {
                    string result = "";
                    int ind = ElemntsTools_03.ComboBox_03001.ComboBoxMultiColumns_03001001.ConnectBetweenComboBoxAndDataGridView_03001001003(dataGridView1, comboBox1, 0, ref result);
                    if (result != "success") MessageBox.Show(result);
                }
                */
            }

        }


        // ايجاد رقم الانديكس الخاص بأحد العناصر الموجودة في القائمة المنسدلة
        /// <summary>
        /// 03001002  >>  find index by item in combobox by item value
        /// </summary>
        /// <param name="combobox">Required : the ComboBox we need find the value inside it / ComboBox Variable</param>
        /// <param name="itemValue">Required : item search value / string Variable</param>
        /// <returns>return index of item by Int Variable</returns>
        public static int indexOfItemByValue( ComboBox combobox, string itemValue)
        {

            try
            {
                //int s = combobox.items.FindStringExact(itemValue);  // هذه افضل في جلب الانديكس
                int s = combobox.Items.IndexOf(itemValue);

                return s;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  ComboBox_  >>   indexOfItemByValue", DateTime.Now, ex.Message, ex.Message);
                return -100;
            }

            /*
            private void button3_Click(object sender, EventArgs e)
            {
                string result;
                int ind = ElemntsTools_03.ComboBox_03001.indexOfItemByValue_03001002(comboBox1, textBox1.Text, ref result);
                if (result == "success") { if (ind < 0) { MessageBox.Show("not found"); } else { MessageBox.Show(ind.ToString()); } } else { MessageBox.Show(result); }
            }
            */
        }


        //تفريغ القائمة المنسدلة من العناصر
        /// <summary>
        /// 03001003  >>  clear the ComboBox From Items
        /// </summary>
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="combobox">Required : the ComboBox we need Clear / ComboBox Variable</param>
        public static void ClearComboBox( ComboBox combobox)
        {

            try
            {
                combobox.DataSource = null;
                combobox.Items.Clear();
                combobox.Text = "";

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  ComboBox_  >>   ClearComboBox", DateTime.Now, ex.Message, ex.Message);
            }

            /*
            private void button3_Click(object sender, EventArgs e)
            {
                string result = ElemntsTools_03.ComboBox_03001.ClearComboBox_03001003(comboBox1);
                if (result != "success") MessageBox.Show(result);
            }
            */
        }

        // الخصائص والاحداث المخصصة
        /// <summary>
        /// ElemntsTools >> ComboBox_ >> CustumProperties // ComboBox Properties and Events... 
        /// </summary>
        /// <param name="theButton">Required : The ComboBox / ComboBox Variable<</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(ComboBox ComboBox,string cultureInfo = "" , bool Properties = true, bool Events = false)//*************************************************************************
        {

            if (Properties)
            {
                try
                {
                    // الاكمال التلقائي
                    ComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    ComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

                    if (ComboBox.Enabled)
                    {
                        ComboBox.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                        ComboBox.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);
                    }
                    else
                    {
                        ComboBox.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_2);
                        ComboBox.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_2);
                    }
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  ComboBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                }
            }

            if(Events)
            {
                ComboBox.EnabledChanged += delegate
                {
                    try
                    {
                        CustumProperties(ComboBox);

                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  ComboBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);
                    }
                };

                ComboBox.Enter += delegate
                {
                    try
                    {
                        ComboBox.BackColor = Color.Yellow;
                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  ComboBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);
                    }
                };

                ComboBox.Leave += delegate
                {
                    try
                    {
                        if (ComboBox.Enabled)
                        {
                            ComboBox.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_1);
                            ComboBox.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_1);
                        }
                        else
                        {
                            ComboBox.BackColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.BackColor_2);
                            ComboBox.ForeColor = DisplayMode.ReturnColor(myElementType.ComboBox, ColorPropertyName.ForeColor_2);
                        }
                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  ComboBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);
                    }

                };


                // اللغة عند الدخول للعنصر
                ComboBox.Enter += delegate
                {
                    try
                    {
                        ComboBox.BackColor = Color.Yellow;
                        if (cultureInfo == "")
                        {
                            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo(GeneralVariables.cultureCode == "AR" ? "ar-sa" : "en-us"));
                        }
                        else
                        {

                            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo(cultureInfo));
                        }
                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  TextBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                    }

                };

            }


        }

    }

    
    //اداة عرض بيانات الجداول 
    /// <summary>
    /// 03002  >>  DataGridView
    /// </summary>
    public class DataGridView_
    {
        // تغيير فورمات الوقت والتاريخ لاحد الاعمدة
        /// <summary>
        /// 03002001  >>  Cheange Data And Time Format
        /// </summary>
         /// <param name="Datagridview">Required : the DataGridView we need Cheange Format / DataGridView Variable</param>
        /// <param name="NewFormat">Required : New Format String / string Variable</param>
        /// <param name="ColumnNo">Required : Column index number we need cheange format / int Variable</param>
        public static void CheangeDateAndTimeFormat( DataGridView Datagridview, string NewFormat, int ColumnNo)
        {

            try
            {
                Datagridview.Columns[ColumnNo].DefaultCellStyle.Format = NewFormat;

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  DataGridView_  >>   CheangeDateAndTimeFormat", DateTime.Now, ex.Message, ex.Message);
            }

            /*
            private void button3_Click(object sender, EventArgs e)
            {
                string result = ElemntsTools_03.DataGridView_03002.CheangeDataAndTimeFormat_03002001(dataGridView1, "yyyy/MM/dd", 0);
                if (result != "success") MessageBox.Show(result);
            }
            */
        }
        
        /* اهم الاحداث
         CellBeginEdit  اخذ قيمة الحقل قبل التعديل   
         CellEndEdit    قيمة الحقل بعد التعديل
         SelectionChanged   عند تحديد سطر معين سواء بالفارة او بأزرار التنقل
         */


        /// <summary>
        /// ElemntsTools >> DataGridView_ >> CustumProperties // DataGridView Properties and Events... 
        /// </summary>
        /// <param name="theButton">Required : The DataGridView / DataGridView Variable<</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(DataGridView dgv, bool Properties = true, bool Events = false)
        {
            if(Properties)
            {
                try
                {
                    int size = 30;  // ارتفاع الصفوف

                    // ستايل جدول البيانات
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.AllowUserToAddRows = false;
                    dgv.ReadOnly = true;

                    dgv.BackgroundColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.BackColor_1); // لون الخلفية


                    if (dgv.Rows.Count > 0)
                    {

                        // خلفية الخلايا
                        for (int RowNo = 0; RowNo < dgv.Rows.Count; RowNo++)
                        {

                            if (RowNo % 2 == 0)
                            {

                                dgv.Rows[RowNo].DefaultCellStyle.BackColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.BackColor_3);
                                dgv.Rows[RowNo].DefaultCellStyle.ForeColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.ForeColor_1);
                                dgv.Rows[RowNo].DefaultCellStyle.SelectionBackColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.SelectionBackColor_1);
                                dgv.Rows[RowNo].DefaultCellStyle.SelectionForeColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.SelectionForeColor_1);
                            }
                            else
                            {

                                dgv.Rows[RowNo].DefaultCellStyle.BackColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.BackColor_5);
                                dgv.Rows[RowNo].DefaultCellStyle.ForeColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.ForeColor_5);
                                dgv.Rows[RowNo].DefaultCellStyle.SelectionBackColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.SelectionBackColor_2);
                                dgv.Rows[RowNo].DefaultCellStyle.SelectionForeColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.SelectionForeColor_2);
                            }

                        }

                        // الغاء وظيفة ترتيب الصفوف لكي لا يخرب التنسيق
                        foreach (DataGridViewColumn column in dgv.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }



                        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;// نمط التحديد

                        dgv.GridColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.GridColor_1);  // لون حدود الخلايا


                        // ارتفاع الصفوف
                        Font f = DisplayMode.ReturnFont(DisplayMode.CurrentForm);
                        size = int.Parse(f.Size.ToString());
                        foreach (DataGridViewRow item in dgv.Rows)
                        {
                            item.Height = size + 20;
                        }

                    }

                    dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // محاذات النص في الخلايا

                    dgv.ColumnHeadersHeight = size + 30; // عرض صف عناوين الاعمدة

                    dgv.EnableHeadersVisualStyles = true; // السماح بتصميم صف عناوين الاعمدة
                    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // محاذات الكلامات في صف عناوين الاعمدة
                    dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // التحكم في ارتفاع صف عناوين الاعمدة
                    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single; // نمط اطار صف عناوين الاعمدة
                    dgv.EnableHeadersVisualStyles = false; // السماح بتصميم صف عناوين الاعمدة

                    dgv.ColumnHeadersDefaultCellStyle.BackColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.BackColor_2); // لون خلفية صف عناوين الاعمدة
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.ForeColor_1); // لون الخط على صف عناوين الاعمدة
                    dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.SelectionBackColor_3);  // لون خلفية صف عناوين الاعمدة عند التحديد
                    dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.SelectionForeColor_3);  // لون خط صف عناوين الاعمدة عند  التحديد

                    dgv.RowHeadersVisible = false; // اظهار واخفاء عمود عناوين الصفوف

                    dgv.ClearSelection(); // الغاء التحديد

                    //////dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  DataGridView_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);
                }
                
            }

            if(Events)
            {
                // تنسيق جدول عرض البيانات عند اضافة صف جديد
                dgv.RowsAdded += delegate
                {
                    try
                    {
                        // ارتفاع الصفوف
                        Font f = dgv.Font;
                        int size = int.Parse(f.Size.ToString());
                        dgv.Rows[dgv.Rows.Count - 1].Height = size + 20; ;

                        // اللون
                        if ((dgv.Rows.Count - 1) % 2 == 0)
                        {

                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.BackColor_3);
                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.ForeColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.ForeColor_1);
                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.SelectionBackColor_1);
                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.SelectionForeColor_1);
                        }
                        else
                        {

                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.BackColor_5);
                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.ForeColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.ForeColor_5);
                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.SelectionBackColor_2);
                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = DisplayMode.ReturnColor(myElementType.DataGridView, ColorPropertyName.SelectionForeColor_2);
                        }


                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  DataGridView_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);
                    }
                  
                    
                };
            }
        }

        
        public static bool? findValueThenSelected(DataGridView dgv , ActionType actionType, string TextValue , int columnIndex)
        {
            try
            {
                if (ActionType.add == actionType)
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells[columnIndex].Value.ToString().Trim().Equals(TextValue.Trim()))
                        {
                            dgv.ClearSelection();
                            row.Selected = true;
                            return true;

                        }
                    }
                    return false;
                }
                else
                {
                    int index = 0;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (dgv.SelectedRows != null)
                        {
                            if (dgv.SelectedRows.Count > 0)
                            {

                                if (dgv.SelectedRows[0].Index != index)
                                {
                                    if (row.Cells[columnIndex].Value.ToString().Trim() == TextValue.Trim())
                                    {
                                        dgv.ClearSelection();
                                        row.Selected = true;
                                        return true;
                                    }
                                }

                            }

                        }
                        index++;
                    }
                    index = 0;
                    return false;
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  DataGridView_  >>   findValueThenSelected", DateTime.Now, ex.Message, ex.Message);
                return null;
            }
   

          /*
            
           bool FindUserName = ElementsTools.DataGridView_.findValueThenSelected(dgv05003, txt05002004.Text, 1);
           if (FindUserName) 
           { 
                Errors = Cultures.ReturnTranslation("يوجد مستخدم بنفس الإسم");
           }
           else
           {
                 bool FindEmployee = ElementsTools.DataGridView_.findValueThenSelected(dgv05003, cmb05002008.SelectedValue.ToString() , 4);
                 if (FindEmployee)
                 {
                      Errors = Cultures.ReturnTranslation("هذا الموظف لديه حساب سابق");
                 }
           }

          */
        }
    }


    public class Form_
    {
        /// <summary>
        /// ElemntsTools >> Form_ >> CustumProperties // Form Properties and Events ... 
        /// </summary>
        /// <param name="lbl">Required : The Form / Form Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(Form frm, ColorPropertyName BackColor = ColorPropertyName.BackColor_3,  bool Properties = true, bool Events = false)
        {
            if (Properties)
            {
                try
                {
                    frm.BackColor = DisplayMode.ReturnColor(myElementType.Form, BackColor);

                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  Form_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                }
            }

            if (Events)
            {

            }
        }
    }


    public class panel_
    {
        /// <summary>
        /// ElemntsTools >> Panel >> CustumProperties // Panel Properties and Events ... 
        /// </summary>
        /// <param name="pnl">Required : The Panel / Panel Variable</param>
        /// <param name="BackColor">Required : ColorPropertyName.BackColor_3 OR ColorPropertyName.BackColor_2 ... / ColorPropertyName Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(Panel pnl, ColorPropertyName BackColor = ColorPropertyName.BackColor_3 , bool Properties = true, bool Events = false)
        {
            if (Properties)
            {
                try
                {
                    pnl.BackColor = DisplayMode.ReturnColor(myElementType.Panel, BackColor);
                    //panel1.Paint += delegate (object sender, PaintEventArgs e) { ControlPaint.DrawBorder(e.Graphics, (sender as Panel).ClientRectangle, DisplayMode.ReturnColor(7), ButtonBorderStyle.Solid); }; // تغيير لون الاطار الخارجي
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  panel_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                }

            }

            if (Events)
            {

            }
        }
    }

    public class GroupBox_
    {
        /// <summary>
        /// ElemntsTools >> GroupBox >> CustumProperties // GroupBox Properties and Events ... 
        /// </summary>
        /// <param name="groupBox">Required : The GroupBox / GroupBox Variable</param>
        /// <param name="text">Required : The text / String Variable</param>
        /// <param name="BackColor">Required : ColorPropertyName.BackColor_3 OR ColorPropertyName.BackColor_2 ... / ColorPropertyName Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(GroupBox groupBox,string text, ColorPropertyName BackColor = ColorPropertyName.BackColor_3, ColorPropertyName ForColor = ColorPropertyName.ForeColor_1, bool Properties = true, bool Events = false)
        {
            if (Properties)
            {
                try
                {
                    groupBox.BackColor = DisplayMode.ReturnColor(myElementType.GroupBox, BackColor);
                    groupBox.ForeColor = DisplayMode.ReturnColor(myElementType.GroupBox, ForColor);
                    groupBox.Text = text;
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  GroupBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                }

            }

            if (Events)
            {
                
            }
        }
    }

    public class Button_
    {

        /// <summary>
        /// ElemntsTools >> Button_ >> CustumProperties // Button Properties and Events... 
        /// </summary>
        /// <param name="theButton">Required : The Button / Button Variable<</param>
        /// /// <param name="theButton">Required : text / String Variable<</param>
        /// <param name="ForColor">Optional : ColorPropertyName.ForeColor_1 OR ColorPropertyName.ForeColor_2 ... / String Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(Button theButton ,string Translation, ColorPropertyName ForColor = ColorPropertyName.ForeColor_1 , bool Properties = true, bool Events = false)
        {

            if(Properties)
            {
                try
                {
                    theButton.Text = Cultures.ReturnTranslation(Translation);

                    theButton.FlatStyle = FlatStyle.Flat;
                    theButton.FlatAppearance.BorderSize = 0;
                    theButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    theButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    theButton.FlatAppearance.BorderColor = theButton.Parent.BackColor;

                    theButton.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ForColor);
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  Button_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                }


            }



            if (Events)
            {

                theButton.MouseMove += delegate
                {
                    try
                    {
                        if (theButton.Enabled)
                        {
                            theButton.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_5);
                        }
                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  Button_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                    }

                };

                theButton.MouseDown += delegate
                {
                    try
                    {
                        if (theButton.Enabled)
                        {
                            theButton.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_6);
                        }
                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  Button_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                    }

                };

                theButton.MouseUp += delegate
                {
                    try
                    {
                        if (theButton.Enabled)
                        {
                            theButton.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ColorPropertyName.ForeColor_5);
                        }
                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  Button_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                    }

                };

                theButton.MouseLeave += delegate
                {
                    try
                    {
                        if (theButton.Enabled)
                        {
                            theButton.ForeColor = DisplayMode.ReturnColor(myElementType.Button, ForColor);
                        }
                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  Button_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                    }

                };

                theButton.EnabledChanged += delegate
                {
                    try
                    {
                        CustumProperties(theButton, Translation, ForColor);

                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  Button_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                    }
                };
            }




            //// الرسم على الزر في حال كانت الحالة داكن وكان الزر غير نشط
            //if (GeneralVariables.DisplayMode != "Blue")
            //{
            //    if (theButton.Enabled == false)
            //    {
            //        theButton.Paint += delegate (object sender, System.Windows.Forms.PaintEventArgs e)
            //        {
            //            Button btn = (Button)sender;
            //            Brush drawBrush = new SolidBrush(Color.FromArgb(100, 100, 100));
            //            StringFormat sf = new StringFormat
            //            {
            //                Alignment = StringAlignment.Center,
            //                LineAlignment = StringAlignment.Center
            //            };

            //            ((Button)sender).Text = string.Empty;
            //            e.Graphics.DrawString(theButton.Text, btn.Font, drawBrush, e.ClipRectangle, sf);
            //            drawBrush.Dispose();
            //            sf.Dispose();
            //        };
            //    }
            //}
        }

    }


    public class ListBox_
    {
        /// <summary>
        /// ElemntsTools >> ListBox_ >> CustumProperties // ListBox Properties and Events... 
        /// </summary>
        /// <param name="lbl">Required : The ListBox / ListBox Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(ListBox listbox , bool Properties = true, bool Events = false)
        {
            if(Properties)
            {
                try
                {
                    listbox.ForeColor = DisplayMode.ReturnColor(myElementType.ListBox, ColorPropertyName.ForeColor_1);
                    listbox.BackColor = DisplayMode.ReturnColor(myElementType.ListBox, ColorPropertyName.BackColor_1);
                    listbox.BorderStyle = BorderStyle.None;
                    listbox.SelectionMode = SelectionMode.One;
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  ListBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                }

            }

            if(Events)
            {

            }
        }

        //ايجاد قيمة ثم التحديد
        public static bool? findValueThenSelected(ListBox listBox, ActionType actionType, string TextValue, int ColumnIndex)
        {
            try
            {

                if (ActionType.add == actionType)
                {

                    int xx = 0;
                    foreach (DataRowView item in listBox.Items)
                    {

                        if (item[ColumnIndex].ToString() == TextValue)
                        {
                            listBox.ClearSelected();
                            listBox.SelectedIndex = xx;
                            return true;
                        }
                        xx++;
                    }
                    return false;
                }
                else
                {

                    int xx = 0;
                    foreach (DataRowView item in listBox.Items)
                    {

                        if (listBox.SelectedIndex != xx)
                        {
                            if (item[ColumnIndex].ToString().Equals(TextValue))
                            {
                                listBox.ClearSelected();
                                listBox.SelectedIndex = xx;
                                return true;
                            }
                        }
                        xx++;
                    }
                    return false;

                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  ListBox_  >>   findValueThenSelected", DateTime.Now, ex.Message, ex.Message);
                return null;
            }


        }
    }

    public class TextBox_
    {

        /// <summary>
        /// ElemntsTools >> TextBox_ >> CustumProperties // TextBox Properties and Events... 
        /// </summary>
        /// <param name="textbox">Required : The TextBox / TextBox Variable</param>
        /// <param name="cultureInfo">Optional : "ar-sa" or "en-us" / String Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(TextBox textbox , string cultureInfo = "" ,int Length = 198 , ColorPropertyName BackColor = ColorPropertyName.BackColor_1, ColorPropertyName ForColor = ColorPropertyName.ForeColor_1, bool Properties = true , bool Events = false , TextBoxType textBoxType = TextBoxType.String)
        {

            if(Properties)
            {
                try
                {
                    textbox.BorderStyle = BorderStyle.FixedSingle;
                    
                    if (Length != 198)
                    {
                        textbox.MaxLength = Length;
                    }

                    // ألوان العنصر حسب حالته نشط او لا
                    if (textbox.Enabled)
                    {
                        textbox.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ForColor);
                        textbox.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, BackColor);
                    }
                    else
                    {
                        textbox.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.ForeColor_2);
                        textbox.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.BackColor_2);
                    }
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  TextBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                }
            }

            if(Events)
            {
                // عند تغيير حالة العنصر ليتم تغيير ألوانه
                textbox.EnabledChanged += delegate
                {
                    try
                    {
                        ElementsTools.TextBox_.CustumProperties(textbox, cultureInfo);
                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  TextBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                    }

                };

                // الألوان عند المغادرة
                textbox.Leave += delegate
                {
                    try
                    {
                        if (textbox.Enabled)
                        {
                            textbox.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ForColor);
                            textbox.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, BackColor);
                        }
                        else
                        {
                            textbox.ForeColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.ForeColor_2);
                            textbox.BackColor = DisplayMode.ReturnColor(myElementType.TextBox, ColorPropertyName.BackColor_2);
                        }
                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  TextBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                    }

                };


                // الالوان واللغة عند الدخول للعنصر
                textbox.Enter += delegate
                {
                    try
                    {
                        textbox.BackColor = Color.Yellow;
                        if (cultureInfo == "")
                        {
                            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo(GeneralVariables.cultureCode == "AR" ? "ar-sa" : "en-us"));
                        }
                        else
                        {

                            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo(cultureInfo));
                        }
                    }
                    catch (Exception ex)
                    {
                        GeneralAction.AddNewNotification("ElementsTools  >>  TextBox_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                    }

                };

                textbox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                {
                    if(textBoxType == TextBoxType.Int)
                    {
                        if( !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) )
                        {
                            e.Handled = true;
                        }
                    }

                    if (textBoxType == TextBoxType.Decimal)
                    {
                        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == '.'))
                        {
                            e.Handled = true;
                        }

                        if(e.KeyChar == '.'  && textbox.Text.Contains('.')) // منع تكرار الفاصلة
                        {
                            e.Handled = true;
                        }
                    }
                };
            }




        }
    }


    public class Lable_
    {
        /// <summary>
        /// ElemntsTools >> Lable_ >> CustumProperties // Lable Properties and Events ... 
        /// </summary>
        /// <param name="lbl">Required : The Lable / Lable Variable</param>
        /// <param name="Translation">Required : Text / String Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(Label lbl,string Translation, ColorPropertyName BackColor = ColorPropertyName.BackColor_1 , ColorPropertyName ForeColor = ColorPropertyName.ForeColor_1 , bool Properties = true, bool Events = false)
        {
            if(Properties)
            {
                try
                {
                    lbl.Text = Cultures.ReturnTranslation(Translation);

                    lbl.ForeColor = DisplayMode.ReturnColor(myElementType.Label, ForeColor);

                    lbl.BackColor = DisplayMode.ReturnColor(myElementType.Label, BackColor);

                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  Lable_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);
                }

            }

            if(Events)
            {

            }
        }
    }


    // قائمة العناصر
    /// <summary>
    /// 03003  >>  ListView
    /// </summary>
    public class ListView_
    {

        // ايجاد عنصر في قائمة العناصر ومن ثم حذفه
        /// <summary>
        /// 03003001  >>  Find Item Index Number Then Delete
        /// </summary>
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="listview">Required : ListView we need delete item from them / ListView Variable</param>
        /// <param name="SearchString">Required : shearch string / string Variable</param>
        public void FindItemIndexNumberThenDelete( ListView listview, string SearchString)
        {

            try
            {
                int itemIndex = 0;
                foreach (ListViewItem i in listview.Items)
                {
                    if (i.Text.Contains(SearchString))
                    {
                        itemIndex = i.Index;
                    }
                }
                listview.Items.Remove(listview.Items[itemIndex]);

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  ListView_  >>   FindItemIndexNumberThenDelete", DateTime.Now, ex.Message, ex.Message);
            }

        }

    }


    // علامات التنبيه بوجود خطأ
    /// <summary>
    /// 03004  >>  Eroors Provider
    /// </summary>
    public class Eroors
    {

        // عرض اشارة التنبيه بوجود خطأ على النموذج
        /// <summary>
        /// 03004001  >>  Show Errors 
        /// </summary>
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="errorprovider">Required ErrorProvider Variable</param>
        /// <param name="control">Required Control Variable</param>
        /// <param name="errormessage">Required Error message  String Variable</param>
        /// <returns>ErrorProvider Variable</returns>
        public static ErrorProvider ShowErrors( ErrorProvider errorprovider, Control control, string errormessage)
        {
            try
            {
                errorprovider.SetError(control, errormessage);

                return errorprovider;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  Eroors  >>   ShowErrors", DateTime.Now, ex.Message, ex.Message);
                return null;
            }

            /*
            ErrorProvider ep = new ErrorProvider();
            private void button1_Click(object sender, EventArgs e)
            {
            ep.Clear();
            if (textBox1.Text.Trim() == "")
            {
            MyGeneralTools01.Eroors0103.ShowErrors(ep,textBox1, "ahmed1");
            }
            }
            */
        }

    }


    public class TreeView_
    {
        // البحث عن نود
          //  TreeNode[] nodes = trvMenu.Nodes.Find("TestNode", true);
        //    trvMenu.Nodes.Remove(nodes[0]);


        public static void CustumProperties(TreeView treeVew, ColorPropertyName BackColor = ColorPropertyName.BackColor_1, ColorPropertyName ForColor = ColorPropertyName.ForeColor_1, bool Properties = true,bool Events = false)
        {
            if (Properties)
            {
                try
                {
                    treeVew.BorderStyle = BorderStyle.None;
                    treeVew.BackColor = DisplayMode.ReturnColor(myElementType.TreeView, BackColor);
                    treeVew.ForeColor = DisplayMode.ReturnColor(myElementType.TreeView, ForColor);
                    ElementsTools.TreeView_.changeColors(treeVew, DisplayMode.ReturnColor(myElementType.TreeView, BackColor), DisplayMode.ReturnColor(myElementType.TreeView, ForColor));
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  TreeView_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                }


            }

            if (Events)
            {

            }
        }

        public static void fillTreeView(TreeView treeview, DataTable dt, string PerintColumnName, int PerintColumnIndex, int PerintColumnValue, int TextArabicColumnIndex, int TextEnglishColumnIndex, int ValueColumnIndex, TreeNode treenode = null)
        {
            try
            {
                if (PerintColumnValue == -1)
                {
                    DataRow[] drws = dt.Select(PerintColumnName + "  Is Null");
                    if (drws.Length > 0)
                    {
                        DataTable dtMain = drws.CopyToDataTable();

                        if (dtMain != null)
                        {
                            foreach (DataRow row in dtMain.Rows)
                            {
                                TreeNode tn = new TreeNode(row[GeneralVariables.cultureCode == "AR" ? TextArabicColumnIndex : TextEnglishColumnIndex].ToString());
                                tn.Tag = row[ValueColumnIndex];
                                treeview.Nodes.Add(tn);
                                fillTreeView(treeview, dt, PerintColumnName, PerintColumnIndex, (int)row[ValueColumnIndex], TextArabicColumnIndex, TextEnglishColumnIndex, ValueColumnIndex, tn);
                            }
                        }
                    }
                }
                else
                {
                    DataRow[] drws = dt.Select(PerintColumnName + "  = " + PerintColumnValue);
                    if (drws.Length > 0)
                    {
                        DataTable dtsub = drws.CopyToDataTable();
                        if (dtsub != null)
                        {
                            foreach (DataRow row in dtsub.Rows)
                            {
                                TreeNode tn = new TreeNode(row[GeneralVariables.cultureCode == "AR" ? TextArabicColumnIndex : TextEnglishColumnIndex].ToString());
                                tn.Tag = row[ValueColumnIndex];
                                treenode.Nodes.Add(tn);
                                fillTreeView(treeview, dt, PerintColumnName, PerintColumnIndex, (int)row[ValueColumnIndex], TextArabicColumnIndex, TextEnglishColumnIndex, ValueColumnIndex, tn);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  TreeView_  >>   fillTreeView", DateTime.Now, ex.Message, ex.Message);

            }
            
        }


        // البحث داخل العرض الشجري
        public static TreeNode Search(TreeView TreeView, object NodeTag)
        {
            try
            {
                if(NodeTag != null)
                {
                    foreach (TreeNode node in TreeView.Nodes)
                    {

                        if ((int)node.Tag == (int)NodeTag)
                        {
                            return node;
                        }
                        if (node.Nodes.Count > 0)
                        {
                            TreeNode tn = Search2(node.Nodes, NodeTag);
                            if (tn != null)
                            {
                                return tn;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  TreeView_  >>   Search", DateTime.Now, ex.Message, ex.Message);
                return null;
            }

        }

        private static TreeNode Search2(TreeNodeCollection TreeNodes, object NodeTag)
        {
            try
            {
                foreach (TreeNode node in TreeNodes)
                {
                    if ((int)node.Tag == (int)NodeTag)
                    {
                        return node;
                    }
                    if (node.Nodes.Count > 0)
                    {
                        TreeNode tn = Search2(node.Nodes, NodeTag);
                        if (tn != null)
                        {
                            return tn;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  TreeView_  >>   Search2", DateTime.Now, ex.Message, ex.Message);
                return null;
            }

        }


        // تغيير الالوان
        public static void changeColors(TreeView TreeView, Color BackColor, Color ForColor)
        {
            try
            {
                foreach (TreeNode node in TreeView.Nodes)
                {
                    node.BackColor = BackColor;
                    node.ForeColor = ForColor;

                    if (node.Nodes.Count > 0)
                    {
                        changeColors2(node, BackColor, ForColor);
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  TreeView_  >>   changeColors", DateTime.Now, ex.Message, ex.Message);

            }

        }

        private static void changeColors2(TreeNode TreeNode, Color BackColor, Color ForColor)
        {
            try
            {
                foreach (TreeNode node in TreeNode.Nodes)
                {
                    node.BackColor = BackColor;
                    node.ForeColor = ForColor;

                    if (node.Nodes.Count > 0)
                    {
                        changeColors2(node, BackColor, ForColor);
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  TreeView_  >>   changeColors2", DateTime.Now, ex.Message, ex.Message);

            }

        }


        // فحص العرض الشجري للأكد من عدم وقوعنا في دائرة من العناصر كل منها يتبع الاخر
        public static bool? CircleOfElementsResut = null;
        public static void CircleOfElements(TreeView treeview , TreeNode treeNodeMove, TreeNode treeNodeMoveTo)
        {
            try
            {
                if(treeNodeMove != null)
                {
                    if (treeNodeMove.Tag == treeNodeMoveTo.Tag)
                    {
                        CircleOfElementsResut = true;
                        return;
                    }
                    else
                    {
                        if (treeNodeMoveTo.Parent != null)
                        {
                            CircleOfElements(treeview ,treeNodeMove, treeNodeMoveTo.Parent);
                        }
                        else
                        {
                            CircleOfElementsResut = false;
                            return;
                        }
                    }
                }
                else
                {
                    if (treeview.Nodes.Count > 0)
                    {
                        treeview.SelectedNode = treeview.Nodes[0];
                    }

                    CircleOfElementsResut = null ;
                    return;
                }
                        
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  TreeView_  >>   CircleOfElements", DateTime.Now, ex.Message, ex.Message);

            }

        }


        // الذاب الى النود المنطقي بعد عملية الحذف
        public static TreeNode NextTreeNode = null;
        public static void StarchNextNode(TreeView treeview, TreeNode treeNode) // الذي عليه الدور
        {
            try
            {
                if (treeNode.Parent != null)
                {
                    if (treeNode.Parent.Nodes.Count > 1)
                    {
                        if (treeNode.Parent.Nodes[treeNode.Parent.Nodes.Count - 2].IsSelected)
                        {

                            if (treeNode.Parent.Nodes.Count >= 2)
                            {
                                StarchNextNode2(treeNode.Parent.Nodes[treeNode.Parent.Nodes.Count - 1]);
                            }
                        }
                        else
                        {
                            StarchNextNode2(treeNode.Parent.Nodes[treeNode.Parent.Nodes.Count - 2]);

                        }
                    }
                    else
                    {
                        NextTreeNode = treeNode;
                    }
                }
                else
                {
                    if (treeview.Nodes.Count > 1)
                    {
                        if(treeview.Nodes[treeview.Nodes.Count - 2].IsSelected)
                        {
                            StarchNextNode2(treeview.Nodes[treeview.Nodes.Count - 1]);
                        }
                        else
                        {
                            StarchNextNode2(treeview.Nodes[treeview.Nodes.Count - 2]);
                        }
                        
                    }
                    else
                    {
                        NextTreeNode = treeNode;
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  TreeView_  >>   StarchNextNode", DateTime.Now, ex.Message, ex.Message);

            }
            
        }
        private static void StarchNextNode2(TreeNode treeNode)// هل له فروع
        {
            try
            {
                if (treeNode.Nodes.Count > 0)
                {
                    StarchNextNode2(treeNode.Nodes[treeNode.Nodes.Count - 1]);
                }
                else
                {
                    NextTreeNode = treeNode;
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElementsTools  >>  TreeView_  >>   StarchNextNode2", DateTime.Now, ex.Message, ex.Message);

            }

        }

    }


    public class TabControl_
    {
        /// <summary>
        /// ElemntsTools >> Lable_ >> CustumProperties // Lable Properties and Events ... 
        /// </summary>
        /// <param name="lbl">Required : The Lable / Lable Variable</param>
        /// <param name="Translation">Required : Text / String Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(TabControl tabControl, List<string> PagesNames, ColorPropertyName BackColor = ColorPropertyName.BackColor_1, ColorPropertyName ForeColor = ColorPropertyName.ForeColor_1, bool Properties = true, bool Events = false)
        {
            if (Properties)
            {
                try
                {

                    for (int i = 0; i < tabControl.TabPages.Count; i++)
                    {
                        tabControl.TabPages[i].BackColor = DisplayMode.ReturnColor(myElementType.TabControl, BackColor);
                        tabControl.TabPages[i].ForeColor = DisplayMode.ReturnColor(myElementType.TabControl, ForeColor);
                        tabControl.TabPages[i].BorderStyle = BorderStyle.None;
                        tabControl.TabPages[i].Text = PagesNames[i];
                    }
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  TabControl_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);

                }

            }

            if (Events)
            {

            }
        }
    }


    public class DateTimePicker_
    {
        /// <summary>
        /// ElemntsTools >> DateTimePicker_ >> CustumProperties // Lable Properties and Events ... 
        /// </summary>
        /// <param name="lbl">Required : The Lable / Lable Variable</param>
        /// <param name="Translation">Required : Text / String Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(DateTimePicker DateTimePicker,bool Properties = true, bool Events = false)
        {
            if (Properties)
            {
                try
                {
                    DateTimePicker.Format = DateTimePickerFormat.Custom;
                    DateTimePicker.CustomFormat = "yyyy/MM/dd : dddd";
                    
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("ElementsTools  >>  DateTimePicker_  >>   CustumProperties", DateTime.Now, ex.Message, ex.Message);
                }

            }

            if (Events)
            {

            }
        }
    }


    public class PictureBox_
    {
        /// <summary>
        /// ElemntsTools >> PictureBox_ >> CustumProperties // PictureBox Properties and Events ... 
        /// </summary>
        /// <param name="PictureBox">Required : The PictureBox / PictureBox Variable</param>
        /// <param name="BackColor">Required : Back Color / ColorPropertyName Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(PictureBox PictureBox,  ColorPropertyName backColor = ColorPropertyName.BackColor_1, bool Properties = true, bool Events = false)
        {
            if (Properties)
            {

                PictureBox.BackColor = DisplayMode.ReturnColor(myElementType.PictureBox, backColor );

            }

            if (Events)
            {
                PictureBox.BackColor = DisplayMode.ReturnColor(myElementType.PictureBox, backColor);

            }
        }
    }


    public class CheckBox_
    {
        /// <summary>
        /// ElemntsTools >> CheckBox_ >> CustumProperties  
        /// </summary>
        /// <param name="CheckBox">Required : The CheckBox / CheckBox Variable</param>
        /// <param name="text">Required : The text / string Variable</param>
        /// <param name="forcolor">Required : forcolor Color / ColorPropertyName Variable</param>
        /// <param name="Properties">Optional : Update The properties / bool Variable</param>
        /// <param name="Events">Optional : Update The Events / bool Variable</param>
        public static void CustumProperties(CheckBox CheckBox,string text , ColorPropertyName forcolor = ColorPropertyName.ForeColor_1, bool Properties = true, bool Events = false)
        {
            if (Properties)
            {
                CheckBox.ForeColor = DisplayMode.ReturnColor(myElementType.CheckBox, forcolor);
                CheckBox.Text = text;
            }

            if (Events)
            {
                CheckBox.ForeColor = DisplayMode.ReturnColor(myElementType.CheckBox, forcolor);
                CheckBox.Text = text;

            }
        }
    }
}




