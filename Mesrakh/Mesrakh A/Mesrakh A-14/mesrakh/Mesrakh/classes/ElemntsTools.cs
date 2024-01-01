using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 03  >>  Elemnts Tools
/// </summary>
class ElemntsTools
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
            /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
            /// <param name="DT">Required : data source  / DataTable Variable</param>
            /// <param name="replace_Char1">Required : Alternate character for spaces / char Variable</param>
            /// <param name="replace_Char2">Required : Alternate character for spaces /char Variable</param>
            /// <param name="replace_CharOther">Required : Alternate character for spaces /char Variable</param>
            /// <param name="col1_charCount">Required : The number of characters in the column /float Variable</param>
            /// <param name="col2_charCount">Required : The number of characters in the column /float Variable</param>
            /// <param name="colOther_charCount">Required : The number of characters in the column /float Variable</param>
            /// <returns> Return string Array</returns>
            public static string[] returnArrayForMultiColumnsComboBox(ref string[] Result, DataTable @DT, char @replace_Char1, char @replace_Char2, char @replace_CharOther, float @col1_charCount, float @col2_charCount, float @colOther_charCount)
            {
                Result = new string[2];
                Result[0] = "03001001001";
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
                    Result[1] = "success";
                    return returnValue;
                }
                catch (Exception ex)
                {
                    Result[1] = ex.Message;
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
            /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
            /// <param name="SearchString">Required : search string /string Variable</param>
            /// <param name="cmbobox">Required : the ComboBox We need search insid him /ComboBox Variable</param>
            /// <returns>number of index by int variable</returns>
            public static int SearchReturnItemIndexFromComboBoxMultiColumns(ref string[] Result, string SearchString, ComboBox cmbobox)
            {
                Result = new string[2];
                Result[0] = "03001001002";
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
                    Result[1] = "success";
                    return indexxxx; // اعادة رقم الانديكس
                }
                catch (Exception ex)
                {
                    Result[1] = ex.Message;
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
            /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
            /// <param name="datagridview">Required : the DataGridView /DataGridView Variable</param>
            /// <param name="combobox">Required : the ComboBox /ComboBox Variable</param>
            /// <param name="Index_ForColumnInDataGridViewRowIsHaveValue">Required : index of cell have the value in DataGridView  /int Variable</param>
            /// <returns>return index row in DataGridView / int Variable</returns>
            public static int ConnectBetweenComboBoxAndDataGridView(ref string[] Result, DataGridView datagridview, ComboBox combobox, int Index_ForColumnInDataGridViewRowIsHaveValue)
            {
                Result = new string[2];
                Result[0] = "03001001003";

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
                    Result[1] = "success";
                    return indexxxx;
                }
                catch (Exception ex)
                {
                    Result[1] = ex.Message;
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
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="combobox">Required : the ComboBox we need find the value inside it / ComboBox Variable</param>
        /// <param name="itemValue">Required : item search value / string Variable</param>
        /// <returns>return index of item by Int Variable</returns>
        public static int indexOfItemByValue(ref string[] Result, ComboBox combobox, string itemValue)
        {
            Result = new string[2];
            Result[0] = "03001002";
            try
            {
                //int s = combobox.items.FindStringExact(itemValue);  // هذه افضل في جلب الانديكس
                int s = combobox.Items.IndexOf(itemValue);
                Result[1] = "success";
                return s;
            }
            catch (Exception ex)
            {
                Result[1] = "'03001002' >> " + ex.Message;
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
        public static void ClearComboBox(ref string[] Result, ComboBox combobox)
        {
            Result = new string[2];
            Result[0] = "03001003";
            try
            {
                combobox.DataSource = null;
                combobox.Items.Clear();
                combobox.Text = "";
                Result[1] = "success";
            }
            catch (Exception ex)
            {
                Result[1] = ex.Message;
            }

            /*
            private void button3_Click(object sender, EventArgs e)
            {
                string result = ElemntsTools_03.ComboBox_03001.ClearComboBox_03001003(comboBox1);
                if (result != "success") MessageBox.Show(result);
            }
            */
        }


        public static void CustumProperties(ComboBox ComboBox)
        {
            ComboBox.BackColor = DisplayMode.ReturnColor(ElementType.ComboBox, ColorPropertyName.BackColor_1);
            ComboBox.ForeColor = DisplayMode.ReturnColor(ElementType.ComboBox, ColorPropertyName.ForeColor_1);
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
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="Datagridview">Required : the DataGridView we need Cheange Format / DataGridView Variable</param>
        /// <param name="NewFormat">Required : New Format String / string Variable</param>
        /// <param name="ColumnNo">Required : Column index number we need cheange format / int Variable</param>
        public static void CheangeDataAndTimeFormat( DataGridView Datagridview, string NewFormat, int ColumnNo)
        {

            try
            {
                Datagridview.Columns[ColumnNo].DefaultCellStyle.Format = NewFormat;

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("ElemntsTools  >> DataGridView_  >>  CheangeDataAndTimeFormat", DateTime.Now, "خطأ عند تغيير فورمات الوقت التاريخ بجدول عرض البيانات", ex.Message);
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



        public static void CustumProperties(DataGridView dgv)
        {
            int size = 30;  // ارتفاع الصفوف

            // ستايل جدول البيانات
            dgv.BorderStyle = BorderStyle.None;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;

            dgv.BackgroundColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.BackColor_1); // لون الخلفية


            if (dgv.Rows.Count > 0)
            {

                // خلفية الخلايا
                for (int RowNo = 0; RowNo < dgv.Rows.Count; RowNo++)
                {

                    if (RowNo % 2 == 0)
                    {

                        dgv.Rows[RowNo].DefaultCellStyle.BackColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.BackColor_3);
                        dgv.Rows[RowNo].DefaultCellStyle.ForeColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.ForeColor_1);
                        dgv.Rows[RowNo].DefaultCellStyle.SelectionBackColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.SelectionBackColor_1);
                        dgv.Rows[RowNo].DefaultCellStyle.SelectionForeColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.SelectionForeColor_1);
                    }
                    else
                    {

                        dgv.Rows[RowNo].DefaultCellStyle.BackColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.BackColor_5);
                        dgv.Rows[RowNo].DefaultCellStyle.ForeColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.ForeColor_5);
                        dgv.Rows[RowNo].DefaultCellStyle.SelectionBackColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.SelectionBackColor_2);
                        dgv.Rows[RowNo].DefaultCellStyle.SelectionForeColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.SelectionForeColor_2);
                    }

                }

                // الغاء وظيفة ترتيب الصفوف لكي لا يخرب التنسيق
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }



                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;// نمط التحديد

                dgv.GridColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.GridColor_1);  // لون حدود الخلايا


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

            dgv.ColumnHeadersDefaultCellStyle.BackColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.BackColor_2); // لون خلفية صف عناوين الاعمدة
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.ForeColor_1); // لون الخط على صف عناوين الاعمدة
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.SelectionBackColor_3);  // لون خلفية صف عناوين الاعمدة عند التحديد
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = DisplayMode.ReturnColor(ElementType.DataGridView, ColorPropertyName.SelectionForeColor_3);  // لون خط صف عناوين الاعمدة عند  التحديد

            dgv.RowHeadersVisible = false; // اظهار واخفاء عمود عناوين الصفوف

            dgv.ClearSelection(); // الغاء التحديد

            
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
        public void FindItemIndexNumberThenDelete(ref string[] Result, ListView listview, string SearchString)
        {
            Result = new string[2];
            Result[0] = "03003001";
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
                Result[1] = "success";
            }
            catch (Exception ex)
            {
                Result[1] = ex.Message;
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
        public static ErrorProvider ShowErrors(ref string[] Result, ErrorProvider errorprovider, Control control, string errormessage)
        {
            Result = new string[2];
            Result[0] = "03004001";

            try
            {
                errorprovider.SetError(control, errormessage);
                Result[1] = "success";
                return errorprovider;
            }
            catch (Exception ex)
            {
                Result[1] = ex.Message;
                return null;
            }

            /*
            ErrorProvider ep = new ErrorProvider();
            private void button1_Click(object sender, EventArgs e)
            {
            ep.Clear();
            if (textBox1.Text == "")
            {
            MyGeneralTools01.Eroors0103.ShowErrors(ep,textBox1, "ahmed1");
            }
            }
            */
        }

    }


    public class panel
    {
        // تغيير لون اطار الحاوية
        public void panelBorderColor()
        {
            //panel1.Paint += delegate (object sender, PaintEventArgs e) { ControlPaint.DrawBorder(e.Graphics, (sender as Panel).ClientRectangle, DisplayMode.ReturnColor(7), ButtonBorderStyle.Solid); }; // تغيير لون الاطار الخارجي
        }
    }




    public class button
    {
        public static void CustumProperties(Button theButton , int ThemeNo = 1)
        {
            theButton.FlatStyle = FlatStyle.Flat;
            theButton.FlatAppearance.BorderSize = 0;
            theButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            theButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            theButton.FlatAppearance.BorderColor = theButton.Parent.BackColor;

            Color MainColor = Color.Yellow;
            Color MoveColor;
            Color DownColor;

            if (ThemeNo == 1)
            {
                MainColor = DisplayMode.ReturnColor(ElementType.Button, ColorPropertyName.ForeColor_1);
                theButton.ForeColor = MainColor;
            }
            else if (ThemeNo == 2)
            {
                MainColor = DisplayMode.ReturnColor(ElementType.Button, ColorPropertyName.ForeColor_2);
                theButton.ForeColor = MainColor;
            }
            else if (ThemeNo == 3)
            {

                MainColor = DisplayMode.ReturnColor(ElementType.Button, ColorPropertyName.ForeColor_3);
                theButton.ForeColor = MainColor;
            }
            else if (ThemeNo == 4)
            {
                MainColor = DisplayMode.ReturnColor(ElementType.Button, ColorPropertyName.ForeColor_4);
                theButton.ForeColor = MainColor;
            }

            MoveColor = DisplayMode.ReturnColor(ElementType.Button, ColorPropertyName.ForeColor_5);

            DownColor = DisplayMode.ReturnColor(ElementType.Button, ColorPropertyName.ForeColor_6);

            theButton.MouseMove += delegate
            {
                if (theButton.Enabled)
                {
                    theButton.ForeColor = MoveColor;
                }
            };

            theButton.MouseDown += delegate
            {
                if (theButton.Enabled)
                {
                    theButton.ForeColor = DownColor;
                }
            };

            theButton.MouseUp += delegate
            {
                if (theButton.Enabled)
                {
                    theButton.ForeColor = MoveColor;
                }
            };

            theButton.MouseLeave += delegate
            {
                if (theButton.Enabled)
                {
                    theButton.ForeColor = MainColor;
                }
            };

            theButton.EnabledChanged += delegate
            {
                CustumProperties(theButton, ThemeNo);
            };


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
        public static void CustumProperties(ListBox listbox)
        {
            listbox.ForeColor = DisplayMode.ReturnColor(ElementType.ListBox, ColorPropertyName.ForeColor_1);
            listbox.BackColor = DisplayMode.ReturnColor(ElementType.ListBox, ColorPropertyName.BackColor_1);
            listbox.BorderStyle = BorderStyle.None;
            listbox.SelectionMode = SelectionMode.One;

        }
    }

    public class TextBox_
    {
         
        public static void CustumProperties(TextBox textbox,string cultureInfo="")
        {

            textbox.BorderStyle = BorderStyle.None;
            if (textbox.Enabled)
            {
                textbox.ForeColor = DisplayMode.ReturnColor(ElementType.TextBox, ColorPropertyName.ForeColor_1);
                textbox.BackColor = DisplayMode.ReturnColor(ElementType.TextBox, ColorPropertyName.BackColor_1);
                textbox.Enter += delegate { textbox.BackColor = Color.Yellow; };
                textbox.Leave += delegate { textbox.BackColor = DisplayMode.ReturnColor(ElementType.TextBox, ColorPropertyName.BackColor_1); };
            }
            else
            {
                textbox.ForeColor = DisplayMode.ReturnColor(ElementType.TextBox, ColorPropertyName.ForeColor_2);
                textbox.BackColor = DisplayMode.ReturnColor(ElementType.TextBox, ColorPropertyName.BackColor_2);
            }

            textbox.EnabledChanged += delegate
            {
                CustumProperties(textbox);
            };

            textbox.Enter += delegate
            {
                if (cultureInfo == "")
                {
                    //string culture = 
                    Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo(GeneralVariables.cultureCode == "AR" ? "ar-sa" : "en-us"));
                }
                else
                {
                    Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo(cultureInfo));
                }
            };
        }
    }

    public class Lable_
    {
        public static void CustumProperties(Label lbl)
        {
            lbl.ForeColor = DisplayMode.ReturnColor(ElementType.Label, ColorPropertyName.ForeColor_1);

            lbl.BackColor = DisplayMode.ReturnColor(ElementType.Label, ColorPropertyName.BackColor_1);

            lbl.TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}



