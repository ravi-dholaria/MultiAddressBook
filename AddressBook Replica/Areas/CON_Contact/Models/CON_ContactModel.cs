namespace MultiAddressBook.Areas.CON_Contact.Models
{
    public class CON_ContactModel
    {
        public int? ContactID { get; set; }

        public string Name { get; set; }

        public int CountryID { get; set; }

        public int StateID { get; set; }

        public int CityID { get; set; }

        public int ContactCategoryID { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public IFormFile File { get; set; }

        public string PhotoPath { get; set; }

        public int? UserID { get; set; }
    }

    public class CON_Contact_SearchModel
    {
        public string? CountryName { get; set; }

        public string? StateName { get; set; }

        public string? CityName { get; set; }

        public string? Category { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }
    }
}
