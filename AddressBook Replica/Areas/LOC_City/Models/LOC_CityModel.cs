namespace MultiAddressBook.Areas.LOC_City.Models
{
    public class LOC_CityModel
    {
        public int? CityID { get; set; }

        public string CityName { get; set; }

        public int CountryID { get; set; }

        public int StateID { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public int? UserID { get; set; }
    }

    public class LOC_City_DropDownModel
    {
        public int CityID { get; set; }

        public string CityName { get; set; }
    }

    public class LOC_City_SearchModel
    {
        public string? CountryName { get; set; }

        public string? StateName { get; set; }

        public string? CityName { get; set; }
    }
}
