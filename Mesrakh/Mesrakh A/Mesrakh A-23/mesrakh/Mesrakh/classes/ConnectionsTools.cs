using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;    // يجب اضافة مكتبة التحكم في ملف الكونفق // right click >> add >> Reference  >> configuration >> ok
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;   // يجب اضافة مكتبة قاعدة البيانات  // Tools >> NuGet Packege Maneger >> Package Manager Console >> install-package system.data.sqlite
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 05 >> create and open connections
/// </summary>
public static class ConnectionsTools
{

    public static bool weHaveOpenConnection = true;
    // الاتصالات
    public static SqlConnection _Conlicenses = null;         // قاعدة بيانات الترخيص الموجودة على الانترنت
    public static SqlConnection _ConMesrakh = null;          // قاعدة بيانات برنامج المبيعات البعيدة
    public static SQLiteConnection _ConMesrakhSpare = null;  // قاعدة بيانات برنامج المبيعات المحلية  

    /// <summary>
    /// 05001 >> open license Sql Server Connection 
    /// </summary>
    public static SqlConnection Conlicenses()
    {
        // sql server فتح اتصال بقاعدة بيانات 
        try
        {

            if (_Conlicenses is null)
            {
                List<string> ConnectionStringsFile = DataTools.FoldersAndFiles.ReadTextFileWitheLinesIndex(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ConnectionStrings.txt");
                string subLine;

                if(!(ConnectionStringsFile is null))
                {
                    foreach (string line in ConnectionStringsFile)

                    {
                        subLine = SecurityTools.incryption.Decrypt(line);

                        if (subLine.Trim() != "")
                        {
                            string[] sub2Line = subLine.Split('&');
                            if (sub2Line[0] == "Conlicenses")
                            {
                                _Conlicenses = new SqlConnection(sub2Line[1]);
                                break;
                            }

                        }
                    }

                }

            }

            if(!(_Conlicenses is null))
            {
                if (_Conlicenses.State == ConnectionState.Closed) { _Conlicenses.Open(); };
                ConnectionsTools.weHaveOpenConnection = true;
                return _Conlicenses;
            }
            else
            {
                (GeneralVariables._frmSplash00).Invoke((MethodInvoker)delegate
                {
                    GeneralVariables._frmSplash00.Visible = false;
                });

                // اذا لم يتوفر اتصال سيتم فتح نافذة اعداد الاتصال
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("توجد مشكلة في الإتصال"), Cultures.ReturnTranslation("هل لديك إتصال بشبكة الإنترنت"), MessageBoxStatus.YesAndNo);
                if (GeneralVariables.MessageBoxResult == "Yes")
                {
                    GeneralVariables._frmConnectionSettings = new Mesrakh.frmConnectionSettings02();
                    GeneralVariables._frmConnectionSettings.FormBorderStyle = FormBorderStyle.FixedDialog;
                    GeneralVariables._frmConnectionSettings.StartPosition =FormStartPosition.CenterScreen;
                    GeneralVariables._frmConnectionSettings.ShowDialog();
                    Application.Exit();
                }
                else
                {
                    ConnectionsTools.weHaveOpenConnection = false;
                };

                (GeneralVariables._frmSplash00).Invoke((MethodInvoker)delegate
                {
                    GeneralVariables._frmSplash00.Visible = true;
                });

                return null;
            }

        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("ConnectionsTools  >> Conlicenses  ", DateTime.Now, "مشكلة في اتصال التحقق من الترخيص ", ex.Message); 
            ConnectionsTools.weHaveOpenConnection = false;
            return null;
        }

    }


    /// <summary>
    /// 05002 >> open salse Sql Server Connection
    /// </summary>
    public static SqlConnection ConMesrakhMainDB()
    {

        // sql server فتح اتصال بقاعدة بيانات 
        try
        {

            if (_ConMesrakh is null)
            {
                List<string> ConnectionStringsFile = DataTools.FoldersAndFiles.ReadTextFileWitheLinesIndex(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ConnectionStrings.txt");
                string subLine;

                if (!(ConnectionStringsFile is null))
                {
                    foreach (string line in ConnectionStringsFile)
                    {
                        subLine = SecurityTools.incryption.Decrypt(line);
                        if (subLine.Trim() != "")
                        {
                            string[] sub2Line = subLine.Split('&');
                            if (sub2Line[0] == "ConMesrakh")
                            {
                                _ConMesrakh = new SqlConnection(sub2Line[1]);
                                break;
                            }

                        }
                    }

                }

            }

            if (!(_ConMesrakh is null))
            {
                if (_ConMesrakh.State == ConnectionState.Closed) { _ConMesrakh.Open(); };
                ConnectionsTools.weHaveOpenConnection = true;
                return _ConMesrakh;
            }
            else
            {

                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء تأكد من صحة إعدادات الإتصال"), MessageBoxStatus.Ok);
                ConnectionsTools.weHaveOpenConnection = false;
                return null;
            }

        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("ConnectionsTools  >> ConMesrakhMainDB  ", DateTime.Now, ex.Message, ex.Message); 
            ConnectionsTools.weHaveOpenConnection = false;
            return null;
        }
    }



    // SQLite فتح اتصال بقاعدة بيانات 
    /// <summary>
    /// 05003 >> open salse Sqlite Connection
    /// </summary>
    /// <param name="result"> Return Connection Result / string[2] Variable </param>
    public static SQLiteConnection ConMesrakhSpareDB()
    {

        try
        {

            if (_ConMesrakhSpare is null)
            {
                List<string> ConnectionStringsFile = DataTools.FoldersAndFiles.ReadTextFileWitheLinesIndex(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ConnectionStrings.txt");
                string subLine;

                if (!(ConnectionStringsFile is null))
                {
                    foreach (string line in ConnectionStringsFile)
                    {
                        subLine = SecurityTools.incryption.Decrypt(line);
                        if (subLine.Trim() != "")
                        {
                            string[] sub2Line = subLine.Split('&');
                            if (sub2Line[0] == "ConMesrakhSpare")
                            {
                                _ConMesrakhSpare = new SQLiteConnection(sub2Line[1]);
                                break;
                            }

                        }
                    }

                }

            }

            if (!(_ConMesrakhSpare is null))
            {
                if (_ConMesrakhSpare.State == ConnectionState.Closed) { _ConMesrakhSpare.Open(); };
                ConnectionsTools.weHaveOpenConnection = true;
                return _ConMesrakhSpare;
            }
            else
            {
                frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), Cultures.ReturnTranslation("رجاء تأكد من صحة إعدادات الإتصال"), MessageBoxStatus.Ok);
                ConnectionsTools.weHaveOpenConnection = false;
                return null;
            }

        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("ConnectionsTools  >> ConMesrakhSpareDB  ", DateTime.Now, ex.Message, ex.Message); 
            ConnectionsTools.weHaveOpenConnection = false;
            return null;
        }
    }


    // تحميل جميع السيرفرات المحلية
    public static string[] ReadAllInstancesOnLocalMachine()
    {
        try
        {
            string[] instanceNames = null;
            string serverName = Environment.MachineName;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey registy = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instansKey = registy.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft sql Server\Instance Names\SQL", false);
                if (instansKey != null)
                {
                    instanceNames = new string[instansKey.GetValueNames().Length];
                    int x = 0;
                    foreach (var instanceName in instansKey.GetValueNames())
                    {
                        instanceNames[x] = serverName + "\\" + instanceName;
                        x++;
                    }
                }
                else
                {
                    instanceNames = new string[1];
                    instanceNames[0] = "لا يوجد لديك سيرفر محلي";
                }
            }
            return instanceNames;
        }
        catch (Exception ex)
        {
            GeneralAction.AddNewNotification("ConnectionsTools  >> ReadAllInstancesOnLocalMachine  ", DateTime.Now, ex.Message, ex.Message);
            return null;
        }

    }

}

