namespace MultiAddressBook.Areas.LOC_State.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }

        public string StateName { get; set; }

        public int CountryID { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
        public int? UserID { get; set; }
    }
    public class LOC_State_DropDownModel
    {
        public int StateID { get; set; }

        public string StateName { get; set; }
    }

    public class LOC_State_SearchModel
    {
        public string? CountryName { get; set; }

        public string? StateName { get; set; }
    }
}
