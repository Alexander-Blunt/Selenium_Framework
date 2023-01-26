using System.Configuration;

namespace SL_Pom_Framework_Test;

public static class AppConfigReader
{
    public static readonly string HomePageUrl = ConfigurationManager.AppSettings["HomePageUrl"];
    public static readonly string InventoryPageUrl = ConfigurationManager.AppSettings["InventoryPageUrl"];
    public static readonly string UserName = ConfigurationManager.AppSettings["UserName"];
    public static readonly string Password = ConfigurationManager.AppSettings["Password"];
}
