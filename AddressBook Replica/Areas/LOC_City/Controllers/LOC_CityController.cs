using MultiAddressBook.Areas.LOC_City.Models;
using MultiAddressBook.Areas.LOC_State.Models;
using MultiAddressBook.BAL;
using MultiAddressBook.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MultiAddressBook.Areas.LOC_City.Controllers
{
    [CheckAccess]
    [Area("LOC_City")]
    [Route("LOC_City/[controller]/[action]")]
    public class LOC_CityController : Controller
    {

        #region PRIVATE_VAR

        private IConfiguration configuration;

        #endregion

        #region CONSTRUCTOR

        public LOC_CityController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        #endregion

        #region DAL Object

        private LOC_DAL dal = new LOC_DAL();

        #endregion

        #region SELECT_ALL

        public IActionResult Index()
        {
            string connectionString = this.configuration.GetConnectionString("Default");
            //LOC_DAL dal = new LOC_DAL();

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            
            return View("LOC_CityList", dal.LOC_City_SelectAll(userID));
        }

        #endregion

        #region DELETE

        public IActionResult Delete(int CityID)
        {
            string connectionString = this.configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            if (dal.LOC_City_Delete(CityID, userID))
            {
                TempData["LOC_City_Delete_Msg"] = "City Deleted Successfully.";
            }
            else
            {
                TempData["LOC_City_Delete_Msg"] = "Error in City Deletion.";
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region ADD

        public IActionResult Add(int? CityID)
        {
            string connectionString = this.configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            ViewBag.UserID = userID;

            ViewBag.CountryList = dal.LOC_Country_DropDown(userID);

            ViewBag.StateList = new List<LOC_State_DropDownModel>();

            
            // Fetch Tuple

            if (CityID != null)
            {
                LOC_CityModel cityModel = dal.LOC_City_SelectByPk((int)CityID, userID);

                LOC_State_DropDownByCountry(cityModel.CountryID);

                return View("LOC_CityAddEdit", cityModel);
            }
            return View("LOC_CityAddEdit");
        }

        #endregion

        #region SAVE

        public IActionResult Save(LOC_CityModel CityModel)
        {
            string connectionString = this.configuration.GetConnectionString("Default");

            if (CityModel.CityID == null)
            {
                if (dal.LOC_City_Insert(CityModel))
                {
                    TempData["LOC_City_Insert_Msg"] = "City Inserted Successfully.";
                }
                else
                {
                    TempData["LOC_City_Insert_Msg"] = "Error in City Insertion.";
                }
            }
            else
            {
                if (dal.LOC_City_Update(CityModel))
                {
                    TempData["LOC_City_Update_Msg"] = "City Updated Successfully.";
                }
                else
                {
                    TempData["LOC_City_Update_Msg"] = "Error in City Updation.";
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }

        #endregion

        #region STATE_DROPDOWN

        public IActionResult LOC_State_DropDownByCountry(int CountryID)
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            ViewBag.StateList = dal.LOC_State_DropDown(CountryID, userID);

            var state_model = ViewBag.StateList;
            return Json(state_model);
        }

        #endregion

        #region SEARCH_BOX

        public IActionResult Search()
        {
            string connectionString = this.configuration.GetConnectionString("Default");

            LOC_City_SearchModel city_SearchModel = new LOC_City_SearchModel();

            city_SearchModel.CountryName = HttpContext.Request.Form["CountryName"].ToString();
            city_SearchModel.StateName = HttpContext.Request.Form["StateName"].ToString();
            city_SearchModel.CityName = HttpContext.Request.Form["CityName"].ToString();

            ViewBag.CountryName = city_SearchModel.CountryName;
            ViewBag.StateName = city_SearchModel.StateName;
            ViewBag.CityName = city_SearchModel.CityName;

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            return View("LOC_CityList", dal.LOC_City_Search(city_SearchModel, userID));
        }

        #endregion

    }
}
