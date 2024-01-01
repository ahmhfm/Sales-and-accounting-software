// المتطلبات
// يجب عمل ريفرنس لهذه المكتبة  // Tools >> References  >>  System.Management
// يجب عمل ريفرنس لهذه المكتبة  // Tools >> References  >>  System.Configuration
// اضافة مكتبة التطبيق // projectName.Properties;  // 

//اضافة هذه المتغيرات في الخصائص 
// UniqID  string   = Non
// EndDateOfLicense  string  = 2000/1/1
// programName  string  = Non

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;  //     يجب عمل ريفرنس لهذه المكتبة  // Tools >> References  >>  System.Management
using System.Configuration; //  يجب عمل ريفرنس لهذه المكتبة  // Tools >> References  >>  System.Configuration
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using Mesrakh.Properties;  // اسم التطبيق

/// <summary>
/// 04  >>  security tools
/// </summary>
class SecurityTools
{
    // توليد رقم خاص بالجهاز
    /// <summary>
    /// 04001  >>  special Devices
    /// </summary>
    public class specialDevices
    {
        // دالة تقوم بتوليد رقم مميز للجهاز بناء على السيريال نمبر للمعالج وللهارديسك
        /// <summary>
        /// 04001001  >>  A function that generates a unique device number based on the serial number of the processor and the hard disk
        /// </summary>
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="drive"> Requirement : Name Of Hard Disk / string Variable </param>
        /// <returns> Return : Device Number / string Variable </returns>
        public static string getUniqueID(string drive)
        {
            try
            {
                string volumeSerial = getVolumeSerial( drive);
                string cpuID = getCPUID( );
                string x1 = cpuID.Substring(3, 5);
                string x2 = volumeSerial.Substring(2, 4);
                string x3 = cpuID.Substring(5, 2);
                string x4 = volumeSerial.Substring(4, 2);
                string x5 = cpuID.Substring(8, 3);
                string no = x1 + x2 + x3 + x4 + x5;

                return no;
            }
            catch (Exception ex)
            {

                GeneralAction.AddNewNotification("SecurityTools >> getUniqueID ", DateTime.Now, ex.Message, ex.Message);
                return "";
            }
        }


        // دالة لاحضار رقم السيريال الخاص بالهارديسك
        /// <summary>
        ///  04001002  >>  extract the hard disk number
        /// </summary>
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="drive">Requirement : Name Of Hard Disk / string Variable</param>
        /// <returns> Return : Hard Disk Number / string Variable </returns>
        public static string getVolumeSerial( string drive)
        {
            try
            {
                if (drive == string.Empty)
                {
                    foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                    {
                        if (compDrive.IsReady)
                        {
                            drive = compDrive.RootDirectory.ToString();
                            break;
                        }
                    }
                }

                if (drive.EndsWith(":\\"))
                {
                    drive = drive.Substring(0, drive.Length - 2);
                }

                ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
                disk.Get();

                string volumeSerial = disk["VolumeSerialNumber"].ToString();
                disk.Dispose();

                return volumeSerial;
            }
            catch (Exception ex)
            {

                GeneralAction.AddNewNotification("SecurityTools >> getVolumeSerial ", DateTime.Now, ex.Message, ex.Message);
                return "";
            }
        }


        // دالة لاحضار رقم السيريال الخاص بالمعالج
        /// <summary>
        /// 04001003  >>  extract the CPU Number
        /// </summary>
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <returns>Return : CPU Number / string Variable</returns>
        public static string getCPUID()
        {

            try
            {
                string cpuInfo = "";
                ManagementClass managClass = new ManagementClass("win32_processor");
                ManagementObjectCollection managCollec = managClass.GetInstances();

                foreach (ManagementObject managObj in managCollec)
                {
                    if (cpuInfo == "")
                    {
                        cpuInfo = managObj.Properties["processorID"].Value.ToString();
                        break;
                    }
                }

                return cpuInfo;
            }
            catch (Exception ex)
            {

                GeneralAction.AddNewNotification("SecurityTools >> getCPUID ", DateTime.Now, ex.Message, ex.Message);
                return "";
            }
        }

    }



    // التشفير
    /// <summary>
    /// 04002  >> incryption
    /// </summary>
    public class incryption
    {

        // دالة تشفير النصوص الخاصة بي
        /// <summary>
        /// 04002001  >>  Text encryption
        /// </summary>
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="string_to_encrypt"> Requirement : the string we need to Encrypt / string Variable </param>
        /// <returns>return the string after encryption</returns>
        public static string Encrypt(string string_to_encrypt)
        {

            try
            {
                string rr = "";
                char[] charactersArray = string_to_encrypt.ToCharArray();
                int numberOFcharacters = charactersArray.Length;
                int[] nn = new int[numberOFcharacters];
                for (int x = 0; x <= numberOFcharacters - 1; x++)
                {
                    nn[x] = (char.ConvertToUtf32(charactersArray[x].ToString(), 0)) + x ;
                }

                for (int x = 0; x <= numberOFcharacters - 1; x++)
                {
                    rr += Convert.ToChar(nn[x]);
                }

                return rr;

            }
            catch (Exception ex)
            {

                GeneralAction.AddNewNotification("SecurityTools >> Encrypt ", DateTime.Now, ex.Message, ex.Message);
                return "";
            }
        }


        // فك نص تم تشفريه بالدالة الخاصة بي
        /// <summary>
        /// 04002002  >>  text Decrypt
        /// </summary>
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="string_to_decrypt"> Requirement : the string we need to Decrypt / string Variable </param>
        /// <returns>return the string after Decryption</returns>
        public static string Decrypt( string string_to_decrypt)
        {

            try
            {
                string rr1 = "";
                if (!(string_to_decrypt is null))
                {
                    char[] charactersArray = string_to_decrypt.ToCharArray();
                    int numberOFcharacters = charactersArray.Length;
                    int[] nn = new int[numberOFcharacters];
                    for (int x = 0; x <= numberOFcharacters - 1; x++)
                    {
                        nn[x] = (char.ConvertToUtf32(charactersArray[x].ToString(), 0)) - x;

                    }

                    for (int x = 0; x <= numberOFcharacters - 1; x++)
                    {
                        rr1 += Convert.ToChar(nn[x]);
                    }
                }

                return rr1;
            }
            catch (Exception ex)
            {

                GeneralAction.AddNewNotification("SecurityTools >> Decrypt ", DateTime.Now, ex.Message, ex.Message);
                return "";
            }

        }


        // دالة تشفير قوية جدا ولا يمكن فك النص الذي يتم تشفيره بها
        /// <summary>
        /// 04002003  >>  Strong encryption function by UTF8 can't decipher the ciphertext 
        /// </summary>
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="Pass_word">Requirement : the string we need to Encrypt / string Variable</param>
        /// <returns> return the string after encryption </returns>
        public static string EncryptUTF8(  string Pass_word)
        {

            try
            {
                SHA512Managed SHA512 = new SHA512Managed();
                byte[] Hash = System.Text.Encoding.UTF8.GetBytes(Pass_word);
                Hash = SHA512.ComputeHash(Hash);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in Hash)
                {
                    sb.Append(b.ToString("x2").ToLower());
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {

                GeneralAction.AddNewNotification("SecurityTools >> EncryptUTF8 ", DateTime.Now, ex.Message, ex.Message);
                return "";
            }
        }
    }

    /*
     *      com2.Parameters.AddWithValue("@device_DeviceNo001002", _device_DeviceNo001002);
            com2.Parameters.AddWithValue("@device_HardiceNo001003", _device_HardiceNo001003);
            com2.Parameters.AddWithValue("@device_ProcessorNo001004", _device_ProcessorNo001004);

            SqlCommand com3 = new SqlCommand(@"insert inot tbl_licenses003 (licens_programName003002,licens_DateOfLicenseRequest003003) values (@licens_programName003002,@licens_DateOfLicenseRequest003003)", con);
            com3.Parameters.AddWithValue("@licens_programName003002", _programName);
     */

    /// <summary>
    /// 04003  >>  License Check
    /// </summary>
    public class LicenseCheck
    {

        /// <summary>
        /// 04003001  >> Use license check
        /// </summary>
        /// <param name="Result">Return : Result Of Operation /string[2] Variable</param>
        /// <param name="sqlconnection">Requirement : Open SqlConnection  / SqlConnection Variable</param>
        /// <param name="frmMain">Requirement : main form  / Form Variable</param>
        /// <param name="frmLicense">Requirement : license form  / Form Variable</param>
        /// <param name="frmSeplahs">Requirement : seplash form  / Form Variable</param>
        public static void AreWeHaveActiveLicense(ref string[] Result)
        {
            Result = new string[3];
            Result[0] = "04003001";

            try
            {
                if (ConnectionsTools._Conlicenses is null)
                {
                    ConnectionsTools.Conlicenses();
                }
                //else
                //{
                //    // ?????????? اذا كان يوجد اتصال ويعمل بشكل جيد لماذا نحول القيمة الى لا
                //    ConnectionsTools.weHaveOpenConnection = false;
                //}
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("SecurityTools >> AreWeHaveActiveLicense ", DateTime.Now, ex.Message, ex.Message);

                ConnectionsTools.weHaveOpenConnection = false;
            }

            string currentUniqueID = specialDevices.getUniqueID("c");
            DataTable dt = new DataTable();

            if (ConnectionsTools.weHaveOpenConnection)
            {
                //--( 4 )
                try
                {
                    string commandString = @"select * from tbl008Packages 
                                        inner join tbl003_licenses on tbl003_licenses.c002_PackageName = tbl008Packages.c001_package 
                                        inner join tbl004_licenseAndDevices on tbl004_licenseAndDevices.c003_licensNo =tbl003_licenses.c001_licenseNo 
                                        inner join tbl001_devices on tbl001_devices.c001_deviceAuotoNo = tbl004_licenseAndDevices.c002_deviceAuotoNo 
                                        where c002_DeviceNo = @c002_DeviceNo";
                    SqlCommand com = new SqlCommand(commandString, ConnectionsTools.Conlicenses());
                    com.Parameters.AddWithValue("@c002_DeviceNo", currentUniqueID);
                    dt.Load(com.ExecuteReader());
                    //--( 5 )
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        if (Convert.ToDateTime(row[12].ToString()) >= DateTime.Now && row[2].ToString() == GeneralVariables.programName)
                        {
                            Result[1] = "success";
                            Result[2] = Convert.ToDateTime(row[12].ToString()).ToString("yyyy/MM/dd");
                            return;
                        }
                    }

                    Result[1] = "not success";
                }
                catch (Exception ex)
                {
                    GeneralAction.AddNewNotification("SecurityTools >> AreWeHaveActiveLicense ", DateTime.Now, ex.Message, ex.Message);

                    Result[1] = ex.Message;
                }
                finally
                {
                    
                    if (Result[1] == "success")
                    {
                        //--( 6 )

                        Settings.Default["UniqID"] = SecurityTools.incryption.Encrypt( currentUniqueID);         // using WindowsFormsApp1.Properties;
                        Settings.Default["EndDateOfLicense"] = SecurityTools.incryption.Encrypt( Result[2]);     // using WindowsFormsApp1.Properties;
                        Settings.Default["programName"] = SecurityTools.incryption.Encrypt(GeneralVariables.programName);        // using WindowsFormsApp1.Properties;
                        Settings.Default.Save();
                        //--( 7 )

                        DataTools.myRegistry s = new DataTools.myRegistry(Microsoft.Win32.Registry.CurrentUser, "license", "UniqID");
                        s.Registry_write(SecurityTools.incryption.Encrypt( currentUniqueID));

                        DataTools.myRegistry s1 = new DataTools.myRegistry(Microsoft.Win32.Registry.CurrentUser, "license", "EndDateOfLicense");
                        s1.Registry_write(SecurityTools.incryption.Encrypt( Result[2]));

                        DataTools.myRegistry s2 = new DataTools.myRegistry(Microsoft.Win32.Registry.CurrentUser, "license", "programName");
                        s2.Registry_write(SecurityTools.incryption.Encrypt(GeneralVariables.programName));

                        //--(14)
                        Result[1] = "success";

                    }
                    else
                    {

                        //--( 16 )

                        Settings.Default["UniqID"] = SecurityTools.incryption.Encrypt( "Non");
                        Settings.Default["EndDateOfLicense"] = SecurityTools.incryption.Encrypt( "2000/1/1");
                        Settings.Default["programName"] = SecurityTools.incryption.Encrypt( "Non");
                        Settings.Default.Save();

                        //--( 17 )

                        DataTools.myRegistry s = new DataTools.myRegistry(Microsoft.Win32.Registry.CurrentUser, "license", "UniqID");
                        s.Registry_write(SecurityTools.incryption.Encrypt( "Non"));

                        DataTools.myRegistry s1 = new DataTools.myRegistry(Microsoft.Win32.Registry.CurrentUser, "license", "EndDateOfLicense");
                        s1.Registry_write(SecurityTools.incryption.Encrypt( "2000/1/1"));

                        DataTools.myRegistry s2 = new DataTools.myRegistry(Microsoft.Win32.Registry.CurrentUser, "license", "programName");
                        s2.Registry_write(SecurityTools.incryption.Encrypt( "Non"));

                        //--( 15 )

                        Result[1] = "not success";

                    }
                }
            }
            else
            {

                //--(8)

                string UniqIDSettings = SecurityTools.incryption.Decrypt( Settings.Default["UniqID"].ToString() );  // using WindowsFormsApp1.Properties;
                string EndDateOfLicenseSettings = SecurityTools.incryption.Decrypt( Settings.Default["EndDateOfLicense"].ToString());  // using WindowsFormsApp1.Properties;
                string programNameSettings = SecurityTools.incryption.Decrypt( Settings.Default["programName"].ToString());  // using WindowsFormsApp1.Properties;

                //--(9)

                DataTools.myRegistry s = new DataTools.myRegistry(Microsoft.Win32.Registry.CurrentUser, "license", "UniqID");
                string UniqIDRegistry  = SecurityTools.incryption.Decrypt( s.Registry_read());

                DataTools.myRegistry s1 = new DataTools.myRegistry(Microsoft.Win32.Registry.CurrentUser, "license", "EndDateOfLicense");
                string EndDateOfLicenseRegistry = SecurityTools.incryption.Decrypt( s1.Registry_read());

                DataTools.myRegistry s2 = new DataTools.myRegistry(Microsoft.Win32.Registry.CurrentUser, "license", "programName");
                string programNameRegistry = SecurityTools.incryption.Decrypt( s2.Registry_read());

                //--(10) 
                if(UniqIDRegistry==UniqIDSettings && UniqIDSettings==currentUniqueID)
                {
                    //--(11)
                    if(EndDateOfLicenseRegistry==EndDateOfLicenseSettings)
                    {
                        //--(12)
                        if(Convert.ToDateTime(EndDateOfLicenseSettings) >= DateTime.Now)
                        {
                            //--(13)
                            if(programNameRegistry==programNameSettings && programNameSettings == GeneralVariables.programName)
                            {
                                Result[1] = "success";
                            }
                            else
                            {
                                //--(15)
                                Result[1] = "not success";
                            }
                        }
                        else
                        {
                            //--(15)
                            Result[1] = "not success";
                        }
                    }
                    else
                    {
                        //--(15)
                        Result[1] = "not success";
                    }
                }
                else
                {
                    //--(15)
                    Result[1] = "not success";
                }
            }


            /*
            private void frmsplash_Load(object sender, EventArgs e)
            {
                checkLicenseInSeplash();
            }

            SqlConnection con = new SqlConnection("Data Source = 52.147.200.137; Initial Catalog = licenses; User ID = sa; Password = Aah51771#");
            string programName = "mesrakh";
            Form frmlicens = new Form();
            Form frmmain = new Form();

            private void checkLicenseInSeplash()
            {
                Timer t = new Timer();  // وضع في الاعلى لانه يستخدم في عدة سطور
                t.Interval = 100;

                try
                {
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                }
                catch (Exception) { }

                // التحقق من صلاحية الرخصة  ----------------------------------------------------
                string[] ResultLicense = null;
                Task.Run(() =>
                {
                    SecurityTools.LicenseCheck.AreWeHaveActiveLicense(ref ResultLicense, con, programName);
                }).ContinueWith((d) =>
                {
                    this.Invoke((MethodInvoker)delegate { t.Interval = 20; });    // تسريع البروقريس بار لأن النتيجة وصلت
                });

                // البروقرس بار والتايمر  -----------------------------------------------------
                t.Tick += delegate
                {
                    if (progressBar1.Value < 100)
                    {
                        progressBar1.Value += 1;
                        if (progressBar1.Value == 70 && ResultLicense == null) { t.Interval = 200; };   // إبطاء البروقريس بار في حال تجاوز 70 في المئة وعدم وصول نتيجة التحقق من الترخيص
                    }
                    else
                    {
                        t.Stop();
                        if (ResultLicense[1] == "success")
                        {
                            this.Hide();
                            frmmain.Text = "main";
                            frmmain.Show();
                        }
                        else if (ResultLicense[1] == "not success")
                        {
                            frmlicens.Show();
                            frmlicens.Text = "license";
                            this.Hide();
                        }
                        else if (ResultLicense[1] != null)
                        {
                            MessageBox.Show(ResultLicense[0] + "  >>  " + ResultLicense[1]);
                            this.Close();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                };
                t.Start();

                */

        }

 
    }



}

