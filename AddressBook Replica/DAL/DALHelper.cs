namespace MultiAddressBook.DAL
{
    public class DALHelper
    {
        public static string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("Default");
    }
}
