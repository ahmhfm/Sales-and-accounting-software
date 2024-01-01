using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesrakh
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            DisplayMode.fillTblColors(); // تعبئة جدول الالوان
            DisplayMode.fillTblFontAndLocation(); // تعبئة جدول الخطوط
            Cultures.fillTranslationTable(); // تعبئة جدول اللغات

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //GeneralVariables._frmSplash00 = new frmsplash();
            //Application.Run(GeneralVariables._frmSplash00);

            GeneralVariables._frmMain01 = new frmMain01();
            Application.Run(GeneralVariables._frmMain01);
        }
    }
}
