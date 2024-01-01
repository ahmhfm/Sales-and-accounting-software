using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;  // install-package system.data.sqlite
using System.Configuration;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Threading;


class DataTools
{
    public class DataBases
    {

        // تنفيذ امر عادي وامر يعدي رقم 
        // https://www.yrefube.com/watch?v=iKYXix3Q1k0&list=PLHIfW1KZRIflAus00vgdVEzLUBCx8ooH_&index=159
        /// <summary>
        /// DataTools >> DataBases >> Run // Run sql command or sql stored procedure
        /// </summary>
        /// <param name="CommandString">Required : CommandString /string Variable</param>
        /// <param name="commandtype">Required : Command String Or Stored Procedure /CommandType Variable</param>
        /// <param name="ParameterAndValue">Required : if you have parameters /object[][] Variable</param>
        /// <returns>Return int</returns>
        public static object Run(ref string[] result ,string CommandString, CommandType commandtype, params object[][] ParameterAndValue)
        {
            //0 >> ExecuteNonQuery result
            //1 >> succeeded   or  ConMesrakhMainDB Not Open  or  Exception Message
            //2 >> CommandString
            //3 >> commandtype
            //4 >> ParameterAndValue
            result = new string[5];

            result[2] = CommandString;
            result[3] = commandtype.ToString();
            try
            {
                if (ConnectionsTools.ConMesrakhMainDB().State == ConnectionState.Open)
                {

                    SqlCommand com = new SqlCommand(CommandString, ConnectionsTools.ConMesrakhMainDB());
                    com.CommandType = commandtype;
                    string outParameterName = "";
                    for (int i = 0; i < ParameterAndValue.Length; i++)
                    {
                        if(ParameterAndValue[i][1] != null)
                        {
                            if(ParameterAndValue[i][1].ToString().Trim() != "")
                            {
                                if (ParameterAndValue[i][1].ToString().Trim() != "")
                                {
                                    if (ParameterAndValue[i][1].ToString().ToUpper() == "OUT")
                                    {
                                        outParameterName = (string)ParameterAndValue[i][0];
                                        com.Parameters.Add((string)ParameterAndValue[i][0], SqlDbType.Int).Direction = ParameterDirection.Output;
                                    }
                                    else
                                    {
                                        com.Parameters.AddWithValue((string)ParameterAndValue[i][0], ParameterAndValue[i][1]);
                                    }
                                }
                                else
                                {
                                    com.Parameters.AddWithValue((string)ParameterAndValue[i][0], DBNull.Value);

                                }

                            }
                            else
                            {
                                com.Parameters.AddWithValue((string)ParameterAndValue[i][0], DBNull.Value);
                            }
                        }
                        else
                        {
                            com.Parameters.AddWithValue((string)ParameterAndValue[i][0], DBNull.Value);
                        }

                        if (i == 0)
                        {
                            result[4] = " ( " + (string)ParameterAndValue[i][0] + "  =  " + ParameterAndValue[i][1] + " )";
                        }
                        else
                        {
                            result[4] += "         ( " + (string)ParameterAndValue[i][0] + "  =  " + ParameterAndValue[i][1]+" )";
                        }
                        //MessageBox.Show(" ( " + (string)ParameterAndValue[i][0] + "  =  " + ParameterAndValue[i][1] + " )");
                    }


                    int x = com.ExecuteNonQuery();

                    result[0] = x.ToString();
                    result[1] = "succeeded";




                    if (outParameterName != "")
                    {
                        return com.Parameters[outParameterName].Value;
                    }
                    else
                    {
                        return null ;
                    }
                }
                else
                {
                    result[1] = "ConMesrakhMainDB Not Open";
                    // قاعدة البيانات الاحتياطية التي تستخدم عندما يتوقف الاتصال بقاعدة البيانات الرئيسية ------------   ???????????????????????????????????????????????????????????????????????????????????????????????????? 
                    return null;
                }
            }
            catch (Exception ex)
            {
                result[1] = ex.Message;

                //  01 
                if (ex.Message.Contains("PK_TblMethodsOfCommunication_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO"))
                {
                    
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول طرق الإتصال";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"),ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4] );

                }
                //  02
                else if (ex.Message.Contains("PK_TblMethodsOfCommunication_TblContactMethodsTypes_ContactMethodsTypeNo"))
                {
                   
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول طرق الإتصال";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  03
                else if (ex.Message.Contains("PK_TblManufacturers_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الشركات الصانعة";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  04
                else if (ex.Message.Contains("PK_TblProducts_TblManufacturers_ManufacturerNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول المنتجات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  05
                else if (ex.Message.Contains("PK_TblCategories_TblCategories_CateGOryNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تصنيف المنتجات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  06
                else if (ex.Message.Contains("PK_TblProductsAndCategory_TblCategories_CateGOryNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول المنتج والتصنيف";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  07
                else if (ex.Message.Contains("PK_TblProductsAndCategory_TblProducts_ProductNumber"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول المنتج والتصنيف";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  08
                else if (ex.Message.Contains("PK_TblMeasureUnit_TopMeasureUnit_self"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول وحدات القياس";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  09
                else if (ex.Message.Contains("PK_TblMeasureAndEncapsulationUnits_TblMeasureUnit_MeasureUnitNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول وحدات القياس والتغليف";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  10
                else if (ex.Message.Contains("PK_TblMeasureAndEncapsulationUnits_MeasureAndEncapsulationUnitNoSelfJoin_self"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول وحدات القياس والتغليف";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  11
                else if (ex.Message.Contains("PK_TblMeasureAndEncapsulationUnits_TblEncapsulationUnits_EncapsulationUnitsNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول وحدات القياس والتغليف";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  12
                else if (ex.Message.Contains("PK_TblMeasureAndEncapsulationUnits_TblProducts_ProductNumber"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول وحدات القياس والتغليف";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  13
                else if (ex.Message.Contains("PK_TblBarcode_TblMeasureAndEncapsulationUnits_MeasureAndEncapsulationUnitNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الباركود";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  14
                else if (ex.Message.Contains("PK2_TblFreeUnitsOffers_TblMeasureAndEncapsulationUnits_MeasureAndEncapsulationUnitNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول عرض الوحدات المجانية";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  15
                else if (ex.Message.Contains("PK_TblPriceCategories_TblMeasureAndEncapsulationUnits_MeasureAndEncapsulationUnitNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الفئات السعرية";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  16
                else if (ex.Message.Contains("PK_TblBatch_TblProducts_ProductNumber"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول التشغيلات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  17
                else if (ex.Message.Contains("PK_TblCountries_TblCoins_CurrencyNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الدول";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  18
                else if (ex.Message.Contains("PK_TblRegionOrStateNo_TblCountries_CountryNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول المناطق والولايات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  19
                else if (ex.Message.Contains("PK_TblCityOrProvince_TblRegionOrStateNo_RegionOrStateNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول المحافظات والمدن";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  20
                else if (ex.Message.Contains("PK_TblAddresses_TblCountries_CountryNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول العناوين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  21
                else if (ex.Message.Contains("PK_TblAddresses_TblRegionOrStateNo_RegionOrStateNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول العناوين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  22
                else if (ex.Message.Contains("PK_TblAddresses_TblCityOrProvince_CityOrProvinceNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول العناوين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  23
                else if (ex.Message.Contains("PK_TblEnterpriseBranches_TblEnterprise_EnterpriseNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول فروع المنشآت";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  24
                else if (ex.Message.Contains("PK_TblEnterpriseBranches_TblBranchesTypes_BranchTypeNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول فروع المنشآت";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  25
                else if (ex.Message.Contains("PK_TblEnterpriseBranches_TblAddresses_AddressNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول فروع المنشآت";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  26
                else if (ex.Message.Contains("PK_TblEnterpriseBranches_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول فروع المنشآت";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  27
                else if (ex.Message.Contains("PK_TblShelves_TblEnterpriseBranches_BranchNumber"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الأرفف";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  28
                else if (ex.Message.Contains("PK_TblshevesAndProducts_TblProducts_ProductNumber"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الأرفف والمنتجات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  29
                else if (ex.Message.Contains("PK_TblshevesAndProducts_TblShelves_ShelfGeneralNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الأرفف والمنتجات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  30
                else if (ex.Message.Contains("PK2_TblAgents_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الوكلاء التجاريين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  31
                else if (ex.Message.Contains("pk_TblCompaniesAgents_TblManufacturers_ManufacturerNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الشركات الصانعة و الوكلاء التجاريين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  32
                else if (ex.Message.Contains("pk_TblCompaniesAgents_TblAgents_AgencyNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الشركات الصانعة و الوكلاء التجاريين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  33
                else if (ex.Message.Contains("pk_TblAgentsAddresses_TblAgents_AgencyNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول عناوين الوكلاء التجاريين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  34
                else if (ex.Message.Contains("pk_TblAgentsAddresses_TblAddresses_AddressNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول عناوين الوكلاء التجاريين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  35
                else if (ex.Message.Contains("pk_TblClients_TblClientstypes_ClientsTypesNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول العملاء";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  36
                else if (ex.Message.Contains("PK_TblClients_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول العملاء";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  37
                else if (ex.Message.Contains("pk_TblClientAddresses_TblClients_ClientsNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول عناوين العملاء";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  38
                else if (ex.Message.Contains("pk_TblClientAddresses_TblAddresses_AddressNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول عناوين العملاء";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  39
                else if (ex.Message.Contains("pk_TblEmployees_TblCountries_CountryNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول الموظفين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  40
                else if (ex.Message.Contains("PK_TblEmployees_TblConnectingMethodsOfCommunication_ConnectingMethodsOfCommunicationNO"))
                {
                    string ArabicMessage = "توجد سجلات في جدول الموظفين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  41
                else if (ex.Message.Contains("pk_TblEmployeeAndIdentity_TblIdentitiesTypes_IdentitiesTypeNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول الموظف والهوية";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  42
                else if (ex.Message.Contains("pk_TblEmployeeAndIdentity_TblEmployees_EmployeeNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول الموظف والهوية";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  43
                else if (ex.Message.Contains("pk_TblEmployeeAddresses_TblEmployees_EmployeeNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول عناوين الموظفين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  44
                else if (ex.Message.Contains("pk2_TblEmployeeAddresses_TblAddresses_AddressNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول عناوين الموظفين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  45
                else if (ex.Message.Contains("pk_TblBranchesAndEmployees_TblEmployees_EmployeeNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول عناوين الموظفين و الفروع";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  46
                else if (ex.Message.Contains("pk_TblBranchesAndEmployees_TblEnterpriseBranches_BranchNumber"))
                {
                    string ArabicMessage = "توجد سجلات في جدول عناوين الموظفين و الفروع";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  47
                else if (ex.Message.Contains("pk_TblBranchesAndEmployees_TblJobTitles_JobNameNumber"))
                {
                    string ArabicMessage = "توجد سجلات في جدول عناوين الموظفين و الفروع";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  48
                else if (ex.Message.Contains("pk_TblPermissions_TblObjects_ObjectNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول الصلاحيات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  49
                else if (ex.Message.Contains("pk_TblPermissions_TblUsersPermissionsGroup_PermissionGroupNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول الصلاحيات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  50
                else if (ex.Message.Contains("pk_TblUsersAccounts_TblUsersPermissionsGroup_PermissionGroupNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول حسابات المستخدمين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  51
                else if (ex.Message.Contains("pk_TblUsersAccounts_TblEmployees_EmployeeNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول حسابات المستخدمين";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  52
                else if (ex.Message.Contains("pk_TblOperationUnits_TblEnterpriseBranches_BranchNumber"))
                {
                    string ArabicMessage = "توجد سجلات في جدول وحدات العمليات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  53
                else if (ex.Message.Contains("PK_TblAccounts_TopAccountNo_self"))
                {
                    string ArabicMessage = "توجد سجلات في جدول الحسابات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  54
                else if (ex.Message.Contains("PK_TblAccounts_TblClients_ClientsNo"))
                {
                    string ArabicMessage = "توجد سجلات في جدول الحسابات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  55
                else if (ex.Message.Contains("PK_TblSubJournalEntry_TblJournalEntry_JournalEntryNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول القيود المحاسبية الفرعية";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  56
                else if (ex.Message.Contains("PK_TblSubJournalEntry_TblAccounts_AccountNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول القيود المحاسبية الفرعية";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  57
                else if (ex.Message.Contains("pk_TblOperations_TblOperationsTypes_OperationTypeNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول العمليات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  58
                else if (ex.Message.Contains("pk_TblOperations_TblOperationUnits_OperationUnitNumber"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول العمليات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  59
                else if (ex.Message.Contains("pk_TblOperations_UserAccountNoWhoRegistered_TblUsersAccounts_UserAccountNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول العمليات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  60
                else if (ex.Message.Contains("pk_TblOperations_UserAccountNoWhoHxecuted_TblUsersAccounts_UserAccountNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول العمليات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  61
                else if (ex.Message.Contains("pk_TblOperations_TblJournalEntry_JournalEntryNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول العمليات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  62
                else if (ex.Message.Contains("pk_TblInvoice_MainInvoiceNoSelf_TblInvoice_MainInvoiceNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الفواتير";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  63
                else if (ex.Message.Contains("pk_TblInvoice_TblOperations_OperationNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الفواتير";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  64
                else if (ex.Message.Contains("pk_TblInvoice_TblClients_ClientsNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول الفواتير";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  65
                else if (ex.Message.Contains("pk_TblInvoicesDetails_TblInvoice_MainInvoiceNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل الفواتير";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  66
                else if (ex.Message.Contains("pk_TblInvoicesDetails_TblProducts_ProductNumber"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل الفواتير";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  67
                else if (ex.Message.Contains("pk_TblInvoicesDetails_TblBatch_BatchNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل الفواتير";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  68
                else if (ex.Message.Contains("pk_TblInvoicesDetails_TblMeasureAndEncapsulationUnits_MeasureAndEncapsulationUnitNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل الفواتير";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  69
                else if (ex.Message.Contains("pk_TblInventoryOperations_TblOperations_OperationNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول عمليات الجرد";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  70
                else if (ex.Message.Contains("pk_TblInventoryOperations_TblInventoryType_TypeNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول عمليات الجرد";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  71
                else if (ex.Message.Contains("pk_TblInventoryOperationDetails_TblInventoryOperations_InventoryOperationNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل عمليات الجرد";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  72
                else if (ex.Message.Contains("pk_TblInventoryOperationDetails_TblProducts_ProductNumber"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل عمليات الجرد";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  73
                else if (ex.Message.Contains("pk_TblInventoryOperationDetails_TblBatch_BatchNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل عمليات الجرد";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  74
                else if (ex.Message.Contains("pk_TblInventoryOperationDetails_TblShelves_ShelfGeneralNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل عمليات الجرد";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  75
                else if (ex.Message.Contains("pk_TblInventoryOperationDetails_TblMeasureAndEncapsulationUnits_MeasureAndEncapsulationUnitNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل عمليات الجرد";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  76
                else if (ex.Message.Contains("pk_TblDepreciationOperations_TblOperations_OperationNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول عمليات الإهلاك";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  77
                else if (ex.Message.Contains("pk_TblDepreciationOperationDetails_TblDepreciationOperations_DepreciationOperationsNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل عمليات الاهلاك";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  78
                else if (ex.Message.Contains("pk_TblDepreciationOperationDetails_TblProducts_ProductNumber"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل عمليات الاهلاك";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  79
                else if (ex.Message.Contains("pk_TblDepreciationOperationDetails_TblBatch_BatchNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل عمليات الاهلاك";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  80
                else if (ex.Message.Contains("pk_TblDepreciationOperationDetails_TblShelves_ShelfGeneralNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل عمليات الاهلاك";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  81
                else if (ex.Message.Contains("pk_TblDepreciationOperationDetails_TblMeasureAndEncapsulationUnits_MeasureAndEncapsulationUnitNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل عمليات الاهلاك";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  82
                else if (ex.Message.Contains("pk_TblInventoryTransfer_TblOperations_OperationNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول نقل الارصدة";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  83
                else if (ex.Message.Contains("pk_TblTransferTransferDetails_TblInventoryTransfer_InventoryInventoryTransferNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل نقل الأرصدة";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  84
                else if (ex.Message.Contains("pk_TblTransferTransferDetails_TblProducts_ProductNumber"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل نقل الأرصدة";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  85
                else if (ex.Message.Contains("pk_TblTransferTransferDetails_TblBatch_BatchNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل نقل الأرصدة";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  86
                else if (ex.Message.Contains("pk_TblTransferTransferDetails_TblMeasureAndEncapsulationUnits_MeasureAndEncapsulationUnitNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل نقل الأرصدة";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  87
                else if (ex.Message.Contains("pk_TblTransferTransferDetails_ShelfGeneralNoFrom_TblShelves_ShelfGeneralNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل نقل الأرصدة";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  88
                else if (ex.Message.Contains("pk_TblTransferTransferDetails_ShelfGeneralNoTo_TblShelves_ShelfGeneralNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول تفاصيل نقل الأرصدة";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  89
                else if (ex.Message.Contains("pk_TblStock_TblMeasureAndEncapsulationUnits_MeasureAndEncapsulationUnitNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول المخزون";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  90
                else if (ex.Message.Contains("pk_TblStock_TblShelves_ShelfGeneralNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول المخزون";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  91
                else if (ex.Message.Contains("pk_TblStock_TblBatch_BatchNo"))
                {
                    string ArabicMessage = "توجد سجلات مرتبطة في جدول المخزون";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage)  , ex.Message  , result[2] , result[4]);
                }
                //  92   
                else if (ex.Message.Contains("pk_TblEmployees_TblAccounts_AccountNo"))
                {
                    string ArabicMessage = "عدم توافق مع سجلات جدول الحسابات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage), ex.Message, result[2], result[4]);
                }
                //  93   
                else if (ex.Message.Contains("pk_TblCashBoxes_TblAccounts_AccountNo"))
                {
                    string ArabicMessage = "عدم توافق مع سجلات جدول الحسابات";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage), ex.Message, result[2], result[4]);
                }
                //  94
                else 
                {
                    string ArabicMessage = "مشكلة غير محددة";
                    frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ArabicMessage, MessageBoxStatus.Ok);
                    GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, Cultures.ReturnTranslation(ArabicMessage), ex.Message, result[2], result[4]);

                }
                return -100 ;
            }

        }



        // قراءة جدول في قاعدة البيانات واعادة جميع العمدة منه
        /// <summary>
        /// DataTools >> DataBases >> ReadTabel  //  Read a table in the database
        /// </summary>
        /// <param name="CommandString">Required : sql command string /string Variable</param>
        /// <returns> return datatable </returns>
        public static DataTable ReadTabel(string CommandString)
        {
            //GeneralAction.AddNewNotification("DataTools >> DataBases >> Run ", DateTime.Now, CommandString, CommandString, CommandString, CommandString);
            //0543202334
            try
            {
                if (ConnectionsTools.ConMesrakhMainDB().State == ConnectionState.Open)
                {

                    SqlCommand com = new SqlCommand(CommandString, ConnectionsTools.ConMesrakhMainDB());

                    SqlDataReader dr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> DataBases >> ReadTabel", DateTime.Now, ex.Message, ex.Message);
                return null;
            }

        }




    }


    // التعامل مع ملفات اكسيل
    /// <summary>
    /// 02003 >>  work with Excel file
    /// </summary>
    public class Excel
    {

        //using System.Data.OleDb;
        // قراءة البيانات من ملف اكسيل
        //https://www.yrefube.com/watch?v=m7uS13eu_V4
        // https://www.yrefube.com/watch?v=Wm6E60K8lpI&list=PLHIfW1KZRIflAus00vgdVEzLUBCx8ooH_&index=183

        /// <summary>
        /// 02003001  >>  Read data from excel file
        /// </summary>
        /// <param name="FilePath">Required : file path / string variable</param>
        /// <param name="SheetName">Required : name of the sheet in Excil File / string Variable</param>
        /// <returns>return Data in DataTable Variable</returns>
        public static DataTable readDataFromExcilFile( string FilePath, string SheetName)
        {

            try
            {
                if (File.Exists(FilePath))
                {
                    DataTable dt = new DataTable();
                    string CommandString = string.Format("select * from [{0}$]", SheetName);

                    string dubelCod = ((char)34).ToString();
                    string con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= {0} ;Extended Properties={1}Excel 12.0 Xml; HDR = YES{2};", FilePath, dubelCod, dubelCod);

                    OleDbConnection conn = new OleDbConnection(con);
                    OleDbCommand comm = new OleDbCommand(CommandString, conn);
                    conn.Open();

                    dt.Load(comm.ExecuteReader());
                    conn.Close();
                    return dt;
                }
                else
                {
                    throw new Exception("the file not exists");
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> Excel >> readDataFromExcilFile", DateTime.Now, ex.Message, ex.Message);
                return null;
            }

            /*
            // تشغيل مهام بتسلسل معين مع تشغيل عناصر في الخلفية
            private void button1_Click(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                string path = @"C:\Users\user\Desktop\excel01.xlsx"; // home pc
                                                                     //string path = @"C:\Users\admin\Desktop\excel01.xlsx"; // stor pc
                string sheet = @"sheet1";
                string result = "";   // نتيجة عملية التحميل هل نجح او لا
                Task.Run(() => { return DataTools_02.Excel_02003.readDataFromExcilFile_02003001(path, sheet, ref result); }).ContinueWith((d) => { dataGridView1.Invoke((MethodInvoker)delegate () { if (result == "success") { dataGridView1.DataSource = d.Result; } else { MessageBox.Show(result); } }); });
            }
            */
        }



        // تحويل البيانات من جدول بيانات الى ملف اكسيل
        //https://www.yrefube.com/watch?v=_EPTJwTuYdw&list=PLHIfW1KZRIflAus00vgdVEzLUBCx8ooH_&index=184
        /// <summary>
        /// 02003002  >>  Save the DataTable in Excil File
        /// </summary>
        /// <param name="FilePath">Required : sile path / string Variable</param>
        /// <param name="SheetName">Required : name of the sheet in Excil File / string Variable </param>
        /// <param name="datatable">Required : The DataTable Have the Data / DataTable Variable</param>
        public static void SaveDatatabeInExcilFile( string FilePath, string SheetName, DataTable datatable)
        {

            try
            {
                string dubelCod = ((char)34).ToString();
                string con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= {0} ;Extended Properties={1}Excel 12.0 Xml; HDR = YES{2};", FilePath, dubelCod, dubelCod);  // نص اتصال بالاكسيل
                OleDbConnection conn = new OleDbConnection(con);

                string CommandString = "";
                int ColumnsCount = datatable.Columns.Count;
                string columnsNames = "";
                for (int columnIndex = 0; columnIndex < ColumnsCount; columnIndex++) // قراءة اسماء الاعمدة
                {
                    if (ColumnsCount > 0)
                    {
                        if (!(columnIndex == 0 || columnIndex == ColumnsCount - 1))
                        {
                            columnsNames += " [" + datatable.Columns[columnIndex].ColumnName + "] , ";
                        }
                        else if (columnIndex == 0)
                        {
                            columnsNames += " ( [" + datatable.Columns[columnIndex].ColumnName + "] , ";
                        }
                        else
                        {
                            columnsNames += "[" + datatable.Columns[columnIndex].ColumnName + "] ) ";
                        }
                    }
                }

                OleDbCommand comm = new OleDbCommand(CommandString, conn);

                afterDelete:
                if (!File.Exists(FilePath)) // انشاء ملف اكيسيل وانشاء الشيت والاعمدة
                {

                    conn.Open();
                    string commandString02 = "create table sheet1 ";
                    for (int columnIndex = 0; columnIndex < ColumnsCount; columnIndex++)
                    {
                        if (ColumnsCount > 0)
                        {
                            if (!(columnIndex == 0 || columnIndex == ColumnsCount - 1))
                            {
                                commandString02 += " [" + datatable.Columns[columnIndex].ColumnName + "] text ,  ";
                            }
                            else if (columnIndex == 0)
                            {
                                commandString02 += " ( [" + datatable.Columns[columnIndex].ColumnName + "] text, ";
                            }
                            else
                            {
                                commandString02 += "[" + datatable.Columns[columnIndex].ColumnName + "] text ) ";
                            }
                        }
                    }

                    comm.CommandText = commandString02;
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                else  // اذا كان الملف موجود
                {
                    File.Delete(FilePath);
                    goto afterDelete;
                }

                conn.Open();

                int RowsCount = datatable.Rows.Count;
                for (int RowIndex = 0; RowIndex < RowsCount; RowIndex++)  // تسجيل البيانات في الملف
                {
                    CommandString = string.Format(@"insert into [{0}$] {1} values ", SheetName, columnsNames);

                    for (int columnIndex = 0; columnIndex < ColumnsCount; columnIndex++)
                    {
                        if (ColumnsCount > 0)
                        {
                            if (!(columnIndex == 0 || columnIndex == ColumnsCount - 1))
                            {
                                CommandString += "'" + datatable.Rows[RowIndex][columnIndex] + "',";
                            }
                            else if (columnIndex == 0)
                            {
                                CommandString += " ( '" + datatable.Rows[RowIndex][columnIndex] + "' ,";
                            }
                            else
                            {
                                CommandString += "'" + datatable.Rows[RowIndex][columnIndex] + "' ) ";
                            }
                        }
                    }
                    comm.CommandText = CommandString;

                    comm.ExecuteNonQuery();

                }

                conn.Close();

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> Excel >> SaveDatatabeInExcilFile", DateTime.Now, ex.Message, ex.Message);

            }

            /*
            // تشغيل مهام بتسلسل معين مع تشغيل عناصر من الخلفية 
            private void button2_Click(object sender, EventArgs e)
            {
                string path = @"C:\Users\user\Desktop\excel01.xlsx"; // home pc
                //string path = @"C:\Users\admin\Desktop\excel01.xlsx"; // stor pc
                string sheet = @"sheet1";
                DataTable dt = new DataTable();
                dt.Columns.Add("number", typeof(int));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("salary", typeof(int));
                dt.Columns.Add("address", typeof(string));
                dt.Rows.Add(new object[] { 1, "ahmed", 11000, "najran" });
                dt.Rows.Add(new object[] { 2, "salem", 12000, "jeddah" });
                dt.Rows.Add(new object[] { 2, "mahdi", 13000, "reiad" });

                Task.Run(() => { return DataTools_02.Excel_02003.SaveDatatabeInExcilFile_02003002(path, sheet, dt); }).ContinueWith((d) => { dataGridView1.Invoke((MethodInvoker)delegate () { if (d.Result == "success") { } else { MessageBox.Show(d.Result); } }); });  // تنفيذ المهمة في تاسك مستقل لكي لا يعلق البرنامج
            }
            */
        }

    }


    // xml عمليات ملفات
    /// <summary>
    /// 02004  >>  work with xml files
    /// </summary>
    public class xml
    {
        //  xml حفظ الديتا تيبل في ملف
        //https://www.yrefube.com/watch?v=mZTb_dtEzJo
        /// <summary>
        /// 02004001  >>  Save DataTabe In Xml File 
        /// </summary>
        /// <param name="XmlFileName">Required : File Name /string Variable</param>
        /// <param name="datatable">Required : the datatable /DataTable Variable</param>
        public static void SaveDataTabeInXmlFile( string XmlFileName, DataTable datatable)
        {

            try
            {
                DataSet ds = new DataSet();
                ds.DataSetName = "datasetName001";
                ds.Tables.Add(datatable);
                ds.WriteXml(XmlFileName);
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> xml >> SaveDataTabeInXmlFile", DateTime.Now, ex.Message, ex.Message);

            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("number", typeof(int));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("salary", typeof(int));

                dt.Rows.Add(new object[] { 11, "ali", 1200 });
                dt.Rows.Add(new object[] { 12, "ali salme", 1300 });
                dt.Rows.Add(new object[] { 13, "ahmed ali", 1450 });
                dt.Rows.Add(new object[] { 14, "ali ali ali", 1750 });

                string result = DataTools_02.xml_02004.SaveDataTabeInXmlFile_02004001(@"C:\Users\user\Desktop\xmlt.xml", dt);
                if (result != "success") MessageBox.Show(result);
            }
            */
        }

        //  الى جدول بيانات  XML  تحميل البيانات الموجودة في ملف
        //https://www.yrefube.com/watch?v=ArNDHoWJsCE
        /// <summary>
        /// 02004002  >>  Read DataTabe In Xml File Then upload to datatable 
        /// </summary>
         /// <param name="FileName">Required : File Name /string Variable</param>
        public static DataTable ReadDataInXmlFileUploadToDatatable(  string FileName)
        {
 
            try
            {
                DataTable dt;
                DataSet ds = new DataSet();
                ds.ReadXml(FileName);
                dt = ds.Tables[0];
 
                return dt;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> xml >> ReadDataInXmlFileUploadToDatatable", DateTime.Now, ex.Message, ex.Message);

                return null;
            }

            /*
            private void button2_Click(object sender, EventArgs e)
            {
                string result = "";
                dataGridView1.DataSource = DataTools_02.xml_02004.ReadDataInXmlFileUploadToDatatable_02004002(@"C:\Users\user\Desktop\xmlt.xml", ref result);
                if (result != "success") MessageBox.Show(result);
            }
            */
        }
    }


    // config ملف الاعدادات
    /// <summary>
    /// 02005  >> confige file 
    /// </summary>
    public class ConfigFile
    {
        static Configuration config;
        //// تغيير نص الاتصال في ملف الكنفنق
        /// <summary>
        /// 02005001  >>  cheange connection string in config file
        /// </summary>
         /// <param name="ConnectionName">Required : Connection name in config file / string Variable</param>
        /// <param name="connectionString">Required : New Connection String in config file / string Variable</param>
        public static void ChangeConnctionString(  string ConnectionName, string connectionString)
        {
 
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (ConfigurationManager.ConnectionStrings[ConnectionName] != null)
                {
                    config.ConnectionStrings.ConnectionStrings[ConnectionName].ConnectionString = connectionString;
                    config.Save(ConfigurationSaveMode.Modified);
 
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> ConfigFile >> ChangeConnctionString", DateTime.Now, ex.Message, ex.Message);
            }

            /*
            private void button2_Click(object sender, EventArgs e)
            {
                string result = "";
                result = DataTools_02.ConfigFile_02005.ChangeConnctionString_02005001("SqliteConn", @"Data Source = sqlite\database2");
                if (result != "success") MessageBox.Show(result);
            }
            */
        }


        // قراءة نص الاتصال من ملف الكونفق
        /// <summary>
        ///  02005002  >>  read connection string from cofig file
        /// </summary>
        /// <param name="ConnectionName">Required : connection string name / string Variable</param>
        /// <returns>return : connection string / string Variable </returns>
        public static string ReadConnictionString(string ConnectionName)
        {

            try
            {
                if (ConfigurationManager.ConnectionStrings[ConnectionName] != null)
                {
                    string s = ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
                    return s;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> ConfigFile >> ReadConnictionString", DateTime.Now, ex.Message, ex.Message);
                return "";
            }

            /*
            private void button3_Click(object sender, EventArgs e)
            {
                string result = "";
                string connctionstring = DataTools_02.ConfigFile_02005.ReadConnictionString_02005002("SqlServerConn", ref result);
                if (result != "success") { MessageBox.Show(result); } else { MessageBox.Show(connctionstring); }
            }
            */
        }

        // انشاء نص اتصال بقواعد بيانات  
        //https://www.yrefube.com/watch?v=JVW4sxbBdXE&list=PLHIfW1KZRIflAus00vgdVEzLUBCx8ooH_&index=157
    }


    // عمليات الملفات المحفوظة في الرسورس
    //https://www.yrefube.com/watch?v=QZtW9S-WvPA
    /// <summary>
    /// 02006  >>  Resources
    /// </summary>
    public class Resources
    {
        // نسخ ملف موجود في الموارد على الكمبيوتر
        /// <summary>
        /// 02005001 >> Copy File from Resources to the coumbuter
        /// </summary>
        /// <param name="path">Required : the path with the name of file / string Variable</param>
        /// <param name="file">Required : file as byte[] by (Properties.Resources.) / byte[] Variable</param>
        public static void CopyFileFormResourcesToPc(  string path, byte[] file)
        {

            try
            {
                if (file != null)
                {
                    File.WriteAllBytes(path, file);
                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> ConfigFile >> CopyFileFormResourcesToPc", DateTime.Now, ex.Message, ex.Message);
            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
                string result = DataTools_02.Resources_02006.CopyFileFormResourcesToPc_02005001(@"C:\Users\user\Desktop\excel01.xlsx", Properties.Resources.excel01);
                if (result != "success") MessageBox.Show(result);
            }
            */

        }

    }



    // الملفات والمجلدات
    /// <summary>
    /// 02007  >>  folders and files 
    /// </summary>
    public class FoldersAndFiles
    {

        //انشاء مجلد جديد اذا لم يكن موجود في الاساس واعادة نتيجة العملية 
        //https://www.yrefube.com/watch?v=QIOLq7OZYis&list=PLHIfW1KZRIfl6UP-PlUli03pokSc4af2S&index=16
        /// <summary>
        /// 02007001  >>  Create A New Folder If It Dose Not Exist
        /// </summary>
        /// <param name="PathAndFolderName">Required : The path to create the folder with its name / String Variable</param>
        public static void CreateFolder(string PathAndFolderName)
        {

            try
            {
                if (!Directory.Exists(PathAndFolderName))
                {
                    Directory.CreateDirectory(PathAndFolderName);

                }

            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> FoldersAndFiles >> CreateFolder", DateTime.Now, ex.Message, ex.Message);
            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
            string path = @"C:\Users\user\Desktop\folder01";
            string message = MyGeneralTools01.FoldersAndFiles_01009.CreateFolder_01009001(path);
            MessageBox.Show(message);
            }
            */
        }

        // انشاء ملف نصي والكتابة عليه او الكتابة على ملف موجود
        //https://yrefu.be/oUpTDShvRoU?list=PLHIfW1KZRIfl6UP-PlUli03pokSc4af2S&t=110
        /// <summary>
        /// 02007002  >>  Create A New File If It Dose Not Exist
        /// </summary>
        /// <param name="Result">Return : Operation Result / string[3] Variable</param>
        /// <param name="PathAndFileName">Required : The path with file name / String Variable</param>
        /// <param name="StringLines">Required : The string we need write on the file / String Variable</param>
        public static void CreateOrOpenTextFileAndWriteLinse(string PathAndFileName, string[] StringLines = null)
        {

            try
            {
                if (!File.Exists(PathAndFileName))
                {
                    StreamWriter sr = new StreamWriter(PathAndFileName, true);
                    if (!(StringLines is null))
                    {
                        if (StringLines.Length > 0)
                        {
                            foreach (string s in StringLines)
                            {
                                sr.WriteLine(s);
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                    sr.Close();

                }
                else
                {
                    StreamWriter sr = new StreamWriter(PathAndFileName, true);
                    if (!(StringLines is null))
                    {
                        if (StringLines.Length > 0)
                        {
                            foreach (string s in StringLines)
                            {
                                sr.WriteLine(s);
                            }
                        }
                        else
                        {

                        }

                    }
                    else
                    {

                    }
                    sr.Close();

                }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> FoldersAndFiles >> CreateOrOpenTextFileAndWriteLinse", DateTime.Now, ex.Message, ex.Message);
            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
                string path = @"C:\Users\user\Desktop\folder01/mytext.txt";
                string[] sr = { "ahmed", "salem" };
                //string message = MyGeneralTools01.FoldersAndFiles_01009.CreateTextFileAndWriteLinse(path);
                string message = MyGeneralTools01.FoldersAndFiles_01009.CreateTextFileAndWriteLinse_01009002(path, sr);
                MessageBox.Show(message);
            }
            */
        }


        // قراءة النص واعادة قائمة بالسطور كل سطر لوحده 
        /// <summary>
        /// 02007003  >>  Read the  text file then  return list have a lines each line by index
        /// </summary>
        /// <param name="Result">Return : Operation Result / string[2] Variable</param>
        /// <param name="PathAndFileName">Required : The path with file name / String Variable</param>
        /// <returns> List string Variable</returns>
        public static List<string> ReadTextFileWitheLinesIndex(string PathAndFileName)
        {

            try
            {
                List<string> LinesLest = new List<string>();
                StreamReader sr = new StreamReader(PathAndFileName);
                string lineString;
                do
                {
                    lineString = sr.ReadLine();
                    if (!(lineString is null))
                    {
                        LinesLest.Add(lineString);
                    }

                }
                while (!(lineString is null));
                sr.Close();
                return LinesLest;
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> FoldersAndFiles  >> ReadTextFileWitheLinesIndex  ", DateTime.Now, ex.Message, ex.Message);
                return null;
            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
                List<string> lest = MyGeneralTools01.FoldersAndFiles_01009.ReadTextFileWiteLinesIndex_01009003(@"C:\Users\user\Desktop\folder01\1.txt");
                for (int index = 0; index < lest.Count; index++)
                {
                    MessageBox.Show(lest[index] + "  " + index);
                }
            }
            */
        }


        // فحص الملف للتأكد بأنه مفتوح
        /// <summary>
        /// 02007004  >>  Check the file to make sure it is open
        /// </summary>
        /// <param name="path">Required : the path / string Variable</param>
        /// <returns>return bool Variable</returns>
        public static bool FileInUse(  string path)
        {

            try
            {
                if (File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("the file not Exists ");
                }

            }
            catch (IOException ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> FoldersAndFiles  >> FileInUse  ", DateTime.Now, ex.Message, ex.Message);

                return true;
            }

            /*
            if (MyDatabaseTools_02.Files_02007.FileInUse(path))
            {
                MessageBox.Show("the file is open");
            }
            */
        }


    }


    // الريجيستري
    /// <summary>
    /// 02008  ..  regestry 
    /// </summary>
    public class myRegistry
    {

        private Microsoft.Win32.RegistryKey _BaseFolderPath;
        public Microsoft.Win32.RegistryKey BaseFolderPath
        {
            get { return _BaseFolderPath; }
            set { _BaseFolderPath = value; }
        }

        private string _subFolderPath;
        public string subFolderPath
        {
            get { return _subFolderPath; }
            set { _subFolderPath = value; }
        }

        private string _KeyName;
        public string KeyName
        {
            get { return _KeyName; }
            set { _KeyName = value; }
        }


        /// <summary>
        /// 02008  >>  constracter 
        /// </summary>
        /// <param name="BaseFolder">Requirement : Microsoft.Win32.Registry.CurrentUser / Microsoft.Win32.Registry.CurrentUser Variable</param>
        /// <param name="subFolderPath">Requirement :sub Folder Path / string Variable</param>
        /// <param name="KeyName">Requirement : Key Name / string Variable</param>
        public myRegistry(Microsoft.Win32.RegistryKey BaseFolder, string subFolderPath, string KeyName)
        {
            this.BaseFolderPath = BaseFolder;
            this.subFolderPath = subFolderPath;
            this.KeyName = KeyName;
        }

        // الكتابة على الريجيستري
        /// <summary>
        /// 02008001  >>  write on registry 
        /// </summary>
        /// <param name="text">Requirement: text we need write on regestry / string Variable </param>
        public void Registry_write(string text)
        {
            try
            {
                Microsoft.Win32.RegistryKey RegKey = _BaseFolderPath;
                Microsoft.Win32.RegistryKey subKey = RegKey.CreateSubKey(_subFolderPath);
                subKey.SetValue(_KeyName, text);
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> myRegistry  >> Registry_write  ", DateTime.Now, ex.Message, ex.Message);

            }

        }

        // القراءة من الريجيستري
        /// <summary>
        /// 02008002  >>  read from registry
        /// </summary>
        /// <returns>Retrun : string</returns>
        public string Registry_read()
        {
            try
            {
                Microsoft.Win32.RegistryKey RegKey = _BaseFolderPath;
                Microsoft.Win32.RegistryKey subKey = RegKey.OpenSubKey(_subFolderPath, true);
                if(subKey != null)
                {
                    if (subKey.GetValueNames() != null)
                    {
                        if (subKey.GetValueNames().Contains(_KeyName) != null)
                        {

                            if (subKey.GetValueNames().Contains(_KeyName))
                            {
                                return subKey.GetValue(_KeyName).ToString();
                            }
                            else
                            {
                                return null;
                            }

                        }
                        else
                        { return null; }
                    }
                    else
                    { return null; }
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                GeneralAction.AddNewNotification("DataTools  >> myRegistry  >> Registry_read  ", DateTime.Now, ex.Message, ex.Message);

                return null;
            }
        }
    }

}




