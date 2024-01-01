using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


enum PermissionType { Show, Add, Edit, Delete }
enum PermissionObjectes { DataBases_Connections, Manufacturers, Users_Accounts, Manage_User_Group_Permissions , Products_And_Services, product_And_Services_Details, Barcode, Price_Categories, Free_Unit_Offers , Categories , Accounting_Accounts , Measurement_units , Encapsulation_Units , Enterprises , Enterprise_Branches , Unit_Branch , Shelves , Countries , Employees  , Clients , Journal_Entry }
class Permissions
{
    
    public static bool AccountHavePermission(PermissionObjectes PermissionObjectes, PermissionType permission)
    {
        try
        {
            string ObjectNameEN = PermissionObjectes.ToString().Replace("_", " ");

            if(GeneralVariables.ActiveAccount != null)
            {
                if (GeneralVariables.ActiveAccount.Columns[0].ColumnName == "UserAccountNo")
                {

                    string commandString = "";
                    if (permission == PermissionType.Show)
                    {
                        commandString = "ObjectNameEN = '" + ObjectNameEN + "' and ShowData = 1 ";
                    }
                    else if (permission == PermissionType.Add)
                    {
                        commandString = "ObjectNameEN = '" + ObjectNameEN + "' and AddData = 1 ";
                    }
                    else if (permission == PermissionType.Edit)
                    {
                        commandString = "ObjectNameEN = '" + ObjectNameEN + "' and EditData = 1";
                    }
                    else if (permission == PermissionType.Delete)
                    {
                        commandString = "ObjectNameEN = '" + ObjectNameEN + "' and DeleteData = 1 ";
                    }

                    DataRow[] rows = GeneralVariables.ActiveAccount.Select(commandString);

                    if (rows.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            frmMessageBox.ShowMessageBox(Cultures.ReturnTranslation("تنبيه"), ex.Message, MessageBoxStatus.Ok);
            GeneralAction.AddNewNotification("Permissions >> AccountHavePermission ", DateTime.Now, ex.Message, ex.Message);
            return false;
        }


        /* 
                    if (Permissions.AccountHavePermission("manufacturers", PermissionType.Show))
                    {

                    }
                    else
                    {
                        frmMessageBox.ShowMessageBox("تنبيه", "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", MessageBoxStatus.Ok);
                        GeneralAction.AddNewNotification("frmMainMenu06 >> btn06002001EventsAndProperties", DateTime.Now, "لا توجد لديك صلاحية للوصول رجاء تواصل مع مدير النظام", "You do not have access, please contact the system administrator");
                    }
        */
    }
}

