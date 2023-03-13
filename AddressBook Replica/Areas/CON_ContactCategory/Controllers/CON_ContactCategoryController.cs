using MultiAddressBook.Areas.CON_ContactCategory.Models;
using MultiAddressBook.BAL;
using MultiAddressBook.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MultiAddressBook.Areas.CON_ContactCategory.Controllers
{
    [CheckAccess]
    [Area("CON_ContactCategory")]
    [Route("CON_ContactCategory/[controller]/[action]")]
    public class CON_ContactCategoryController : Controller
    {
        #region PRIVATE_VAR

        private IConfiguration Configuration;
        private CON_DAL dal = new CON_DAL();

        #endregion

        #region CONSTRUCTOR

        public CON_ContactCategoryController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region SELECT_ALL

        public IActionResult Index()
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            return View("CON_ContactCategoryList", dal.CON_ContactCategory_SelectAll(userID));
        }

        #endregion

        #region DELETE_BY_PK

        public IActionResult Delete(int ContactCategoryID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");
            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            if (dal.CON_ContactCategory_Delete(ContactCategoryID, userID))
            {
                TempData["CON_ContactCategory_Delete_Msg"] = "Contact Category Deleted Successfully.";
            }
            else
            {
                TempData["CON_ContactCategory_Delete_Msg"] = "Error in Contact Category Deletion.";
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region ADD

        public IActionResult Add(int? contactCategoryID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");
            
            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            ViewBag.UserID = userID;

            if (contactCategoryID != null)
            {
                return View("CON_ContactCategoryAddEdit", dal.CON_ContactCategory_SelectByPK((int)contactCategoryID, userID));
            }
            return View("CON_ContactCategoryAddEdit");
        }

        #endregion

        #region SAVE

        public IActionResult Save(CON_ContactCategoryModel contactCategoryModel)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            if (contactCategoryModel.ContactCategoryID == null)
            {
                if (dal.CON_ContactCategory_Insert(contactCategoryModel))
                {
                    TempData["CON_ContactCategory_Insert_Msg"] = "Contact Category Inserted Successfully.";
                }
                else
                {
                    TempData["CON_ContactCategory_Insert_Msg"] = "Error in Contact Category Insertion.";
                }
            }
            else
            {
                if (dal.CON_ContactCategory_Update(contactCategoryModel))
                {
                    TempData["CON_ContactCategory_Update_Msg"] = "Contact Category Updated Successfully.";
                }
                else
                {
                    TempData["CON_ContactCategory_Update_Msg"] = "Error in Contact Category Updation.";
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }

        #endregion

        #region SEARCH_BOX

        public IActionResult Search()
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            CON_ContactCategory_SearchModel contactCategory_SearchModel = new CON_ContactCategory_SearchModel();
            contactCategory_SearchModel.ContactCategory = HttpContext.Request.Form["ContactCategory"].ToString();
            ViewBag.ContactCategory = contactCategory_SearchModel.ContactCategory;

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            return View("CON_ContactCategoryList", dal.CON_ContactCategory_Search(contactCategory_SearchModel, userID));
        }

        #endregion
    }
}

