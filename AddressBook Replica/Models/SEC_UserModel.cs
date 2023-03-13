using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MultiAddressBook.Models
{
    public class SEC_UserModel
    {
        public int UserID { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhotoPath { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
