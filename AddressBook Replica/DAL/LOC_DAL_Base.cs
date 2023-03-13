using MultiAddressBook.Areas.CON_Contact.Models;
using MultiAddressBook.Areas.CON_ContactCategory.Models;
using MultiAddressBook.Areas.LOC_City.Models;
using MultiAddressBook.Areas.LOC_Country.Models;
using MultiAddressBook.Areas.LOC_State.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace MultiAddressBook.DAL
{
    public class LOC_DAL_Base : DALHelper
    {

        #region Country

        #region Select_All

        public DataTable LOC_Country_SelectAll(int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_Country_SelectAll]");

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                using (IDataReader dr = database.ExecuteReader(command))
                {
                    dt.Load(dr);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region SELECT_BY_PK

        public LOC_CountryModel LOC_Country_SelectByPK(int CountryID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_Country_SelectByPK]");

                database.AddInParameter(command, "@CountryID", DbType.Int32, CountryID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();
                LOC_CountryModel countryModel = new LOC_CountryModel();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            countryModel.CountryName = Convert.ToString(row["CountryName"]);
                            countryModel.CountryCode = Convert.ToString(row["CountryCode"]);
                        }
                    }
                }

                return countryModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region INSERT

        public bool LOC_Country_Insert(LOC_CountryModel countryModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_Country_Insert]");

                database.AddInParameter(command, "@CountryName", DbType.String, countryModel.CountryName);
                database.AddInParameter(command, "@CountryCode", DbType.String, countryModel.CountryCode);
                database.AddInParameter(command, "@CreationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, countryModel.UserID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region DELETE

        public bool LOC_Country_Delete(int CountryID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_Country_DeleteByPK]");

                database.AddInParameter(command, "@CountryID", DbType.Int32, CountryID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region UPDATE

        public bool LOC_Country_Update(LOC_CountryModel countryModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_Country_UpdateByPK]");

                database.AddInParameter(command, "@CountryID", DbType.Int32, countryModel.CountryID);
                database.AddInParameter(command, "@CountryName", DbType.String, countryModel.CountryName);
                database.AddInParameter(command, "@CountryCode", DbType.String, countryModel.CountryCode);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, countryModel.UserID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region SEARCH

        public DataTable LOC_Country_Search(LOC_Country_SearchModel country_SearchModel, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_Country_SelectPage]");

                database.AddInParameter(command, "@CountryName", DbType.String, country_SearchModel.CountryName);
                database.AddInParameter(command, "@CountryCode", DbType.String, country_SearchModel.CountryCode);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #endregion

        #region STATE

        #region SELECT_ALL

        public DataTable LOC_State_SelectAll(int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_State_SelectAll]");

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();
                using (IDataReader dr = database.ExecuteReader(command))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region SELECT_BY_PK

        public LOC_StateModel LOC_State_SelectByPk(int StateID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_State_SelectByPK]");

                database.AddInParameter(command, "@StateID", DbType.Int32, StateID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();
                LOC_StateModel stateModel = new LOC_StateModel();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            stateModel.CountryID = Convert.ToInt32(dr["CountryID"]);
                            stateModel.StateName = Convert.ToString(dr["StateName"]);
                        }
                    }
                }
                return stateModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region DELETE

        public bool LOC_State_Delete(int StateID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_State_DeleteByPK]");

                database.AddInParameter(command, "@StateID", DbType.Int32, StateID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region INSERT

        public bool LOC_State_Insert(LOC_StateModel stateModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_State_Insert]");

                database.AddInParameter(command, "@StateName", DbType.String, stateModel.StateName);
                database.AddInParameter(command, "@CountryID", DbType.Int32, stateModel.CountryID);
                database.AddInParameter(command, "@CreationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, stateModel.UserID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region UPDATE

        public bool LOC_State_Update(LOC_StateModel stateModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_State_UpdateByPK]");

                database.AddInParameter(command, "@StateID", DbType.Int32, stateModel.StateID);
                database.AddInParameter(command, "@StateName", DbType.String, stateModel.StateName);
                database.AddInParameter(command, "@CountryID", DbType.String, stateModel.CountryID);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, stateModel.UserID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region SEARCH

        public DataTable LOC_State_Search(LOC_State_SearchModel state_SearchModel, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_State_SelectPage]");

                database.AddInParameter(command, "@CountryName", DbType.String, state_SearchModel.CountryName);
                database.AddInParameter(command, "@StateName", DbType.String, state_SearchModel.StateName);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #endregion

        #region CITY

        #region SELECT_ALL

        public DataTable LOC_City_SelectAll(int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_City_SelectAll]");

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();
                using (IDataReader dr = database.ExecuteReader(command))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region SELECT_BY_PK

        public LOC_CityModel LOC_City_SelectByPk(int CityID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_City_SelectByPK]");

                database.AddInParameter(command, "@CityID", DbType.Int32, CityID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();
                LOC_CityModel cityModel = new LOC_CityModel();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            cityModel.CountryID = Convert.ToInt32(dr["CountryID"]);
                            cityModel.StateID = Convert.ToInt32(dr["StateID"]);
                            cityModel.CityName = Convert.ToString(dr["CityName"]);
                        }
                    }
                }
                return cityModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region DELETE

        public bool LOC_City_Delete(int CityID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_City_DeleteByPK]");

                database.AddInParameter(command, "@CityID", DbType.Int32, CityID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region INSERT

        public bool LOC_City_Insert(LOC_CityModel CityModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_City_Insert]");

                database.AddInParameter(command, "@CityName", DbType.String, CityModel.CityName);
                database.AddInParameter(command, "@CountryID", DbType.Int32, CityModel.CountryID);
                database.AddInParameter(command, "@StateID", DbType.Int32, CityModel.StateID);
                database.AddInParameter(command, "@CreationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, CityModel.UserID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region UPDATE

        public bool LOC_City_Update(LOC_CityModel CityModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_City_UpdateByPK]");

                database.AddInParameter(command, "@CityID", DbType.Int32, CityModel.CityID);
                database.AddInParameter(command, "@CityName", DbType.String, CityModel.CityName);
                database.AddInParameter(command, "@CountryID", DbType.String, CityModel.CountryID);
                database.AddInParameter(command, "@StateID", DbType.Int32, CityModel.StateID);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, CityModel.UserID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region SEARCH

        public DataTable LOC_City_Search(LOC_City_SearchModel city_SearchModel, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_LOC_City_SelectPage]");

                database.AddInParameter(command, "@CountryName", DbType.String, city_SearchModel.CountryName);
                database.AddInParameter(command, "@StateName", DbType.String, city_SearchModel.StateName);
                database.AddInParameter(command, "@CityName", DbType.String, city_SearchModel.CityName);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #endregion
        
    }
}