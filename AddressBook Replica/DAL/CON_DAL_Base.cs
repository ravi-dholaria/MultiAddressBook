using MultiAddressBook.Areas.CON_ContactCategory.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using MultiAddressBook.Areas.CON_Contact.Models;

namespace MultiAddressBook.DAL
{
    public class CON_DAL_Base : DALHelper
    {
        #region ContactCategory

        #region Select_All

        public DataTable? CON_ContactCategory_SelectAll(int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_ContactCategory_SelectAll]");

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

        public CON_ContactCategoryModel CON_ContactCategory_SelectByPK(int ContactCategoryID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_ContactCategory_SelectByPK]");

                database.AddInParameter(command, "@ContactCategoryID", DbType.Int32, ContactCategoryID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();
                CON_ContactCategoryModel contactCategoryModel = new CON_ContactCategoryModel();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            contactCategoryModel.ContactCategory = Convert.ToString(row["ContactCategory"]);
                        }
                    }
                }
                return contactCategoryModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region INSERT

        public bool CON_ContactCategory_Insert(CON_ContactCategoryModel contactCategoryModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_ContactCategory_Insert]");

                database.AddInParameter(command, "@ContactCategory", DbType.String, contactCategoryModel.ContactCategory);
                database.AddInParameter(command, "@CreationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, contactCategoryModel.UserID);

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

        public bool CON_ContactCategory_Delete(int ContactCategoryID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_ContactCategory_DeleteByPK]");

                database.AddInParameter(command, "@ContactCategoryID", DbType.Int32, ContactCategoryID);
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

        public bool CON_ContactCategory_Update(CON_ContactCategoryModel contactCategoryModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_ContactCategory_UpdateByPK]");

                database.AddInParameter(command, "@ContactCategoryID", DbType.Int32, contactCategoryModel.ContactCategoryID);
                database.AddInParameter(command, "@ContactCategory", DbType.String, contactCategoryModel.ContactCategory);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, contactCategoryModel.UserID);

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

        public DataTable? CON_ContactCategory_Search(CON_ContactCategory_SearchModel contactCategory_SearchModel, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_ContactCategory_SelectPage]");

                database.AddInParameter(command, "@ContactCategory", DbType.String, contactCategory_SearchModel.ContactCategory);
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

        #region CONTACT

        #region SELECT_ALL

        public DataTable? CON_Contact_SelectAll(int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_Contact_SelectAll]");

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

        public CON_ContactModel CON_Contact_SelectByPk(int ContactID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_Contact_SelectByPK]");

                database.AddInParameter(command, "@ContactID", DbType.Int32, ContactID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();
                CON_ContactModel contactModel = new CON_ContactModel();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            contactModel.ContactID = Convert.ToInt32(dr["ContactID"]);
                            contactModel.Name = Convert.ToString(dr["Name"]);
                            contactModel.Mobile = Convert.ToString(dr["Mobile"]);
                            contactModel.Email = Convert.ToString(dr["Email"]);
                            contactModel.Address = Convert.ToString(dr["Address"]);
                            contactModel.CountryID = Convert.ToInt32(dr["CountryID"]);
                            contactModel.StateID = Convert.ToInt32(dr["StateID"]);
                            contactModel.CityID = Convert.ToInt32(dr["CityID"]);
                            contactModel.ContactCategoryID = Convert.ToInt32(dr["ContactCategoryID"]);
                            contactModel.PhotoPath = Convert.ToString(dr["PhotoPath"]);
                        }
                    }
                }
                return contactModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region DELETE

        public bool CON_Contact_Delete(int ContactID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_Contact_DeleteByPK]");

                database.AddInParameter(command, "@ContactID", DbType.Int32, ContactID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                #region DELETE_FILE_IN_DATABASE

                DbCommand command2 = database.GetStoredProcCommand("[dbo].[PR_CON_Contact_SelectPhotoPathByPK]");

                database.AddInParameter(command2, "@ContactID", DbType.Int32, ContactID);
                database.AddInParameter(command2, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                string file_name, file_name_with_path;
                string full_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\upload");

                using (IDataReader reader = database.ExecuteReader(command2))
                {
                    dt.Load(reader);
                    file_name = Convert.ToString(dt.Rows[0][1]);
                    file_name_with_path = Path.Combine(full_path, file_name);
                }

                //Delete File
                if (File.Exists(file_name_with_path))
                {
                    File.Delete(file_name_with_path);
                }

                #endregion

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

        public bool CON_Contact_Insert(CON_ContactModel contactModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_Contact_Insert]");

                database.AddInParameter(command, "@Name", DbType.String, contactModel.Name);
                database.AddInParameter(command, "@Mobile", DbType.String, contactModel.Mobile);
                database.AddInParameter(command, "@Email", DbType.String, contactModel.Email);
                database.AddInParameter(command, "@Address", DbType.String, contactModel.Address);
                database.AddInParameter(command, "@CountryID", DbType.Int32, contactModel.CountryID);
                database.AddInParameter(command, "@StateID", DbType.Int32, contactModel.StateID);
                database.AddInParameter(command, "@CityID", DbType.Int32, contactModel.CityID);
                database.AddInParameter(command, "@ContactCategoryID", DbType.Int32, contactModel.ContactCategoryID);
                database.AddInParameter(command, "@CreationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, contactModel.UserID);

                #region FILE_UPLOAD

                if (contactModel.File != null)
                {
                    string file_loc = "wwwroot\\upload";
                    string full_path = Path.Combine(Directory.GetCurrentDirectory(), file_loc);

                    if (!Directory.Exists(full_path))
                    {
                        Directory.CreateDirectory(full_path);
                    }

                    string file_name_with_path = Path.Combine(full_path, contactModel.File.FileName);
                    //contactModel.PhotoPath = "~" + file_loc.Replace("wwwroot\\", "//") + contactModel.File.FileName;
                    contactModel.PhotoPath = contactModel.File.FileName;

                    database.AddInParameter(command, "@PhotoPath", DbType.String, contactModel.PhotoPath);

                    using (var stream = new FileStream(file_name_with_path, FileMode.Create))
                    {
                        contactModel.File.CopyTo(stream);
                    }
                }

                #endregion

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

        public bool CON_Contact_Update(CON_ContactModel contactModel, string delete_file_name)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_Contact_UpdateByPK]");

                database.AddInParameter(command, "@ContactID", DbType.Int32, contactModel.ContactID);
                database.AddInParameter(command, "@Name", DbType.String, contactModel.Name);
                database.AddInParameter(command, "@Mobile", DbType.String, contactModel.Mobile);
                database.AddInParameter(command, "@Email", DbType.String, contactModel.Email);
                database.AddInParameter(command, "@Address", DbType.String, contactModel.Address);
                database.AddInParameter(command, "@CountryID", DbType.Int32, contactModel.CountryID);
                database.AddInParameter(command, "@StateID", DbType.Int32, contactModel.StateID);
                database.AddInParameter(command, "@CityID", DbType.Int32, contactModel.CityID);
                database.AddInParameter(command, "@ContactCategoryID", DbType.Int32, contactModel.ContactCategoryID);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, contactModel.UserID);

                #region FILE_UPLOAD

                if (contactModel.File != null)
                {
                    string file_loc = "wwwroot\\upload";
                    string full_path = Path.Combine(Directory.GetCurrentDirectory(), file_loc);

                    if (!Directory.Exists(full_path))
                    {
                        Directory.CreateDirectory(full_path);
                    }

                    string file_name_with_path = Path.Combine(full_path, contactModel.File.FileName);

                    string delete_old_file = Path.Combine(full_path, delete_file_name);
                    if (File.Exists(delete_old_file))
                    {
                        File.Delete(delete_old_file);
                    }

                    //contactModel.PhotoPath = "~" + file_loc.Replace("wwwroot\\", "//") + contactModel.File.FileName;
                    contactModel.PhotoPath = contactModel.File.FileName;
                    database.AddInParameter(command, "@PhotoPath", DbType.String, contactModel.PhotoPath);

                    using (var stream = new FileStream(file_name_with_path, FileMode.Create))
                    {
                        contactModel.File.CopyTo(stream);
                    }
                }

                #endregion

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        #endregion

        #region SEARCH

        public DataTable? CON_Contact_Search(CON_Contact_SearchModel contact_SearchModel, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_CON_Contact_SelectPage]");

                database.AddInParameter(command, "@CountryName", DbType.String, contact_SearchModel.CountryName);
                database.AddInParameter(command, "@StateName", DbType.String, contact_SearchModel.StateName);
                database.AddInParameter(command, "@CityName", DbType.String, contact_SearchModel.CityName);
                database.AddInParameter(command, "@ContactCategory", DbType.String, contact_SearchModel.Category);
                database.AddInParameter(command, "@Name", DbType.String, contact_SearchModel.Name);
                database.AddInParameter(command, "@Email", DbType.String, contact_SearchModel.Email);
                database.AddInParameter(command, "@Mobile", DbType.String, contact_SearchModel.Mobile);
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
