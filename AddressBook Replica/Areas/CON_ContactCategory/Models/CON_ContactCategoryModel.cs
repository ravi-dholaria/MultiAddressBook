namespace MultiAddressBook.Areas.CON_ContactCategory.Models
{
    public class CON_ContactCategoryModel
    {
        public int? ContactCategoryID { get; set; }

        public string ContactCategory { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
        public int? UserID { get; set; }
    }

    public class CON_ContactCategory_DropDownModel
    {
        public int ContactCategoryID { get; set; }

        public string ContactCategory { get; set; }
    }

    public class CON_ContactCategory_SearchModel
    {
        public string? ContactCategory { get; set; }
    }
}
