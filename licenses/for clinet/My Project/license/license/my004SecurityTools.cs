using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;  //     يجب عمل ريفرنس لهذه المكتبة
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;

class my004SecurityTools
{

    // توليد رقم خاص بالجهاز
    public class specialDevices_04001
    {
        // دالة تقوم بتوليد رقم مميز للجهاز بناء على السيريال نمبر للمعالج وللهارديسك
        /// <summary>
        /// A function that generates a unique device number based on the serial number of the processor and the hard disk
        /// </summary>
        /// <param name="drive"> Requirement : Name Of Hard Disk / string Variable </param>
        /// <returns> Return : Device Number / string Variable </returns>
        public static string getUniqueID_04001001(out string ReturnMesseage ,string drive)
        {
            string volumeSerialResult = "";
            string getCPUIDResult = "";
            try
            {
                string volumeSerial = getVolumeSerial_04001002(out volumeSerialResult , drive);
                string cpuID = getCPUID_04001003(out getCPUIDResult );
                string x1 = cpuID.Substring(3, 5);
                string x2 = volumeSerial.Substring(2, 4);
                string x3 = cpuID.Substring(5, 2);
                string x4 = volumeSerial.Substring(4, 2);
                string x5 = cpuID.Substring(8, 3);
                string no = x1 + x2 + x3 + x4 + x5;
                ReturnMesseage = "success";
                return no;
            }
            catch (Exception ex)
            {
                ReturnMesseage = " volumeSerialResult(volumeSerialResult) \n getCPUIDResult(getCPUIDResult) \n  '04001002' >> " + ex.Message ;
                return "" ;
            }
        }


        // دالة لاحضار رقم السيريال الخاص بالهارديسك
        /// <summary>
        ///  extract the hard disk number
        /// </summary>
        /// <param name="drive">Requirement : Name Of Hard Disk / string Variable</param>
        /// <returns> Return : Hard Disk Number / string Variable </returns>
        public static string getVolumeSerial_04001002(out string ReturnMesseage , string drive)
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
                ReturnMesseage = "success";
                return volumeSerial;
            }
            catch (Exception ex)
            {
                ReturnMesseage = " '04001002' >> " + ex.Message ;
                return "" ;
            }
        }


        // دالة لاحضار رقم السيريال الخاص بالمعالج
        /// <summary>
        /// extract the CPU Number
        /// </summary>
        /// <returns>Return : CPU Number / string Variable</returns>
        public static string getCPUID_04001003(out string ReturnMesseage)
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
                ReturnMesseage = "success";
                return cpuInfo;
            }
            catch (Exception ex)
            {
                ReturnMesseage = " '04001003' >> " + ex.Message ;
                return "" ;
            }
        }

    }



    // التشفير
    public class incryption_04002
    {

        // دالة تشفير النصوص الخاصة بي
        /// <summary>
        /// Text encryption
        /// </summary>
        /// <param name="string_to_encrypt"> Requirement : the string we need to Encrypt / string Variable </param>
        /// <returns>return the string after encryption</returns>
        public static string Encrypt_04002001(out string ReturnMesseage , string string_to_encrypt)
        {
            try
            {
                string rr = "";
                char[] charactersArray = string_to_encrypt.ToCharArray();
                int numberOFcharacters = charactersArray.Length;
                int[] nn = new int[numberOFcharacters];
                for (int x = 0; x <= numberOFcharacters - 1; x++)
                {
                    nn[x] = (char.ConvertToUtf32(charactersArray[x].ToString(), 0)) + (x * 3) + 7;
                }

                for (int x = 0; x <= numberOFcharacters - 1; x++)
                {
                    rr += Convert.ToChar(nn[x]);
                }
                ReturnMesseage = "success";
                return rr;
            }
            catch (Exception ex)
            {
                ReturnMesseage = " '04002001' >> " + ex.Message ;
                return "" ;
            }
        }


        // فك نص تم تشفريه بالدالة الخاصة بي
        /// <summary>
        /// text Decrypt
        /// </summary>
        /// <param name="string_to_decrypt"> Requirement : the string we need to Decrypt / string Variable </param>
        /// <returns>return the string after Decryption</returns>
        public static string Decrypt_04002002(out string ReturnMesseage,  string string_to_decrypt)
        {
            try
            {
                string rr1 = "";
                char[] charactersArray = string_to_decrypt.ToCharArray();
                int numberOFcharacters = charactersArray.Length;
                int[] nn = new int[numberOFcharacters];
                for (int x = 0; x <= numberOFcharacters - 1; x++)
                {
                    nn[x] = (char.ConvertToUtf32(charactersArray[x].ToString(), 0)) - (x * 3) - 7;

                }

                for (int x = 0; x <= numberOFcharacters - 1; x++)
                {
                    rr1 += Convert.ToChar(nn[x]);
                }
                ReturnMesseage = "success";
                return rr1;
            }
            catch (Exception ex)
            {
                ReturnMesseage = " '04002002' >> " + ex.Message ;
                return "";
            }

        }


        // دالة تشفير قوية جدا ولا يمكن فك النص الذي يتم تشفيره بها
        /// <summary>
        /// Strong encryption function by UTF8 can't decipher the ciphertext 
        /// </summary>
        /// <param name="Pass_word">Requirement : the string we need to Encrypt / string Variable</param>
        /// <returns> return the string after encryption </returns>
        public string EncryptUTF8_04002003(out string ReturnMesseage,  string Pass_word)
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
                ReturnMesseage = "success";
                return sb.ToString();
            }
            catch (Exception ex)
            {
                ReturnMesseage = " '04002003' >> " + ex.Message ;
                return "" ;
            }
        }


    }

    /*
     *            com2.Parameters.AddWithValue("@device_DeviceNo001002", _device_DeviceNo001002);
            com2.Parameters.AddWithValue("@device_HardiceNo001003", _device_HardiceNo001003);
            com2.Parameters.AddWithValue("@device_ProcessorNo001004", _device_ProcessorNo001004);


            SqlCommand com3 = new SqlCommand(@"insert inot tbl_licenses003 (licens_programName003002,licens_DateOfLicenseRequest003003) values (@licens_programName003002,@licens_DateOfLicenseRequest003003)", con);
            com3.Parameters.AddWithValue("@licens_programName003002", _programName);
     */



    //public class LicensingManagement_04003
    //{
    //    // ادارة الترخيص
    //    public static void LicenseCheck_04003001(out string[] licenseResult , string CurrentUniqueID, string SavedUniqueID, string ApplicationStatus, DateTime SavedLicenseEndDate, DateTime CurrntDateTime , string device_HardiceNo001003, string device_ProcessorNo001004 , string programName)
    //    {
    //    point0001:
    //        SecurityForms_04004 sf = new SecurityForms_04004(CurrentUniqueID, device_HardiceNo001003, device_ProcessorNo001004, programName);  // استدعاء نموذج طلب ترخيص
    //        sf.licenseRecuest_04004001();

    //        licenseResult = null;

    //        if (ApplicationStatus == "New") // اول مرة
    //        {
  

    //            //frm_002_license frm = new frm_002_license();
    //            //frm.Show();
    //            //this.Close();
    //        }
    //        else if (ApplicationStatus == "RequestLicense") // تم طلب ترخيص
    //        {
    //            if (CurrentUniqueID == SavedUniqueID)
    //            {
    //                MessageBox.Show("RequestLicense");
    //                // تحقق من قاعدة البيانات وفي حال كان هناك ترخيص يتم التحديث
    //                //تتم اعادة الخطوات من النقطة point001
    //                //goto point0001;
    //            }
    //            else
    //            {
    //                //frm_002_license frm = new frm_002_license();
    //                //frm.Show();
    //                //this.Close();
    //            }

    //        }
    //        else if (ApplicationStatus == "RenewLicense") // تم طلب تجديد للترخيص
    //        {
    //            if (CurrentUniqueID == SavedUniqueID)
    //            {

    //            }
    //            else { }
    //        }
    //        else if (ApplicationStatus == "TransferFromOther") // طلب نقل ترخيص من جهاز الى اخر
    //        {
    //            if (CurrentUniqueID == SavedUniqueID)
    //            {

    //            }
    //            else { }
    //        }
    //        else if (ApplicationStatus == "TransferToOther") // طلب نقل هذاالترخيص الى جهاز اخر
    //        {
    //            if (CurrentUniqueID == SavedUniqueID)
    //            {

    //            }
    //            else { }
    //        }
    //        else if (ApplicationStatus == "Normal") // التطبيق يعمل بشكل طبيعي
    //        {
    //            if (CurrentUniqueID == SavedUniqueID)
    //            {


    //                if (CurrntDateTime < SavedLicenseEndDate.AddDays(-30))
    //                {
    //                    // فتح نموذج الدخول
    //                }
    //                else if (CurrntDateTime <= SavedLicenseEndDate)
    //                {
    //                    // عرض رسالة تحذر بقرب انتهاء الرخصة
    //                    // فتح نموذج الدخول
    //                }
    //            }
    //            else
    //            {
    //                // افتح نموذج طلب ترخيص
    //                // ارسال تحذير لي ببيانات محاولة الاختراق
    //                // تسجيل خروج

    //            }
    //        }
    //        else { }
    //    }

    //    /*
    //     // هذه الميثود تعمل بعد اكتمال نموذج السبلاش وتوضع في نفس الكلاس ومن ثم تستدعى في التايمر  
    //    public static void LicensingManagement()
    //    {
    //        // License Verification التحقق من الرخصة  02  
    //        string resultCurrentUniqueID = "";
    //        string CurrentUniqueID = SecurityTools_04.specialDevices_04001.getUniqueID_04001001(out resultCurrentUniqueID, "c");
    //        string resultgetCPUID = "";
    //        string CurrentCPUID = SecurityTools_04.specialDevices_04001.getCPUID_04001003(out resultgetCPUID);
    //        string resultVolumeSerial = "";
    //        string CurrentVolumeSerial = SecurityTools_04.specialDevices_04001.getVolumeSerial_04001002(out resultVolumeSerial, "c");

    //        string SavedUniqueID = Mesrakh.Properties.Settings.Default.UniqueID;
    //        string ApplicationStatus = Properties.Settings.Default.ApplicationStatus;
    //        DateTime SavedLicenseEndDate = Properties.Settings.Default.LicenseEndDate;
    //        DateTime CurrntDateTime = DateTime.Now;

    //        string[] licenseResult;
    //        SecurityTools_04.LicensingManagement_04003.LicenseCheck_04003001(out licenseResult, CurrentUniqueID, SavedUniqueID, ApplicationStatus, SavedLicenseEndDate, CurrntDateTime, CurrentVolumeSerial, CurrentCPUID, "Mesrakh");
    //    }
    //    */

    //    /*
    //    private void timer1_Tick(object sender, EventArgs e)
    //    {
    //        progressBar1.Value += 1;
    //        if (progressBar1.Value == 12) connection();
    //        if (progressBar1.Value == 100) { timer1.Enabled = false; LicensingManagement(); }
    //    }
    //    */
    //}


  
}

