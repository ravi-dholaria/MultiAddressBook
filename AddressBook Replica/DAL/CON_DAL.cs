using MultiAddressBook.Areas.CON_ContactCategory.Models;
using MultiAddressBook.Areas.LOC_City.Models;
using MultiAddressBook.Areas.LOC_Country.Models;
using MultiAddressBook.Areas.LOC_State.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace MultiAddressBook.DAL
{
    public class CON_DAL : CON_DAL_Base
    {
        #region CONTACTCATEGORY_DROPDOWN

        public List<CON_ContactCategory_DropDownModel> CON_ContactCategory_DropDown(int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_ContactCategory_SelectComboBox]");

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();
                List<CON_ContactCategory_DropDownModel> contactCategory_list = new List<CON_ContactCategory_DropDownModel>();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            CON_ContactCategory_DropDownModel tuple = new CON_ContactCategory_DropDownModel();
                            tuple.ContactCategoryID = Convert.ToInt32(dr["ContactCategoryID"]);
                            tuple.ContactCategory = Convert.ToString(dr["ContactCategory"]);
                            contactCategory_list.Add(tuple);
                        }
                    }
                }
                return contactCategory_list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

    }
}
