namespace MultiAddressBook.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {
        public int? CountryID { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public int? UserID { get; set;}
    }
    public class LOC_Country_DropDownModel
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }
    }

    public class LOC_Country_SearchModel
    {
        public string? CountryName { get; set; }

        public string? CountryCode { get; set; }
    }
}
