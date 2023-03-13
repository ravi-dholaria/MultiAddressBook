using MultiAddressBook.Areas.LOC_Country.Models;
using MultiAddressBook.BAL;
using MultiAddressBook.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MultiAddressBook.Areas.LOC_Country.Controllers
{
    [CheckAccess]
    [Area("LOC_Country")]
    [Route("LOC_Country/[controller]/[action]")]
    public class LOC_CountryController : Controller
    {
        #region PRIVATE_VAR

        private IConfiguration Configuration;
        public LOC_DAL dal = new LOC_DAL();
        #endregion

        #region CONSTRUCTOR

        public LOC_CountryController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region SELECT_ALL

        public IActionResult Index()
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            return View("LOC_CountryList", dal.LOC_Country_SelectAll(userID));
        }

        #endregion

        #region DELETE_BY_PK

        public IActionResult Delete(int CountryID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            if (dal.LOC_Country_Delete(CountryID, userID))
            {
                TempData["LOC_Country_Delete_Msg"] = "Country Deleted Successfully.";
            }
            else
            {
                TempData["LOC_Country_Delete_Msg"] = "Error in Country Deletion.";
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region ADD

        public IActionResult Add(int? CountryID)
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            ViewBag.UserID = userID;

            if (CountryID != null)
            {
                string connectionString = this.Configuration.GetConnectionString("Default");

                return View("LOC_CountryAddEdit", dal.LOC_Country_SelectByPK((int)CountryID, userID));
            }
            return View("LOC_CountryAddEdit");
        }

        #endregion

        #region SAVE

        public IActionResult Save(LOC_CountryModel countryModel)
        {

            string connectionString = this.Configuration.GetConnectionString("Default");

            if (countryModel.CountryID == null)
            {
                if (dal.LOC_Country_Insert(countryModel))
                {
                    TempData["LOC_Country_Insert_Msg"] = "Country Inserted Successfully.";
                }
                else
                {
                    TempData["LOC_Country_Insert_Msg"] = "Error in Country Insertion.";
                }
            }
            else
            {
                if (dal.LOC_Country_Update(countryModel))
                {
                    TempData["LOC_Country_Update_Msg"] = "Country Updated Successfully.";
                }
                else
                {
                    TempData["LOC_Country_Update_Msg"] = "Error in Country Updation.";
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

            LOC_Country_SearchModel country_SearchModel = new LOC_Country_SearchModel();

            country_SearchModel.CountryName = HttpContext.Request.Form["CountryName"].ToString();
            country_SearchModel.CountryCode = HttpContext.Request.Form["CountryCode"].ToString();

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            ViewBag.CountryName = country_SearchModel.CountryName;
            ViewBag.CountryCode = country_SearchModel.CountryCode;

            return View("LOC_CountryList", dal.LOC_Country_Search(country_SearchModel, userID));
        }

        #endregion

    }
}
