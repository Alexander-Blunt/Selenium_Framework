using OpenQA.Selenium;
using SL_Pom_Framework_Test.lib.driver_config;

namespace SL_Pom_Framework_Test.lib.pages;

public class SL_Website<T> where T : IWebDriver, new()
{
    public IWebDriver SeleniumDriver { get; internal set; }
    public HomePage SL_HomePage { get; internal set; }
    public InventoryPage SL_InventoryPage { get; internal set; }

    public SL_Website(int pageLoadInSecs = 3, int implicitWaitInSecs = 3, bool headless = true)
    {
        SeleniumDriverConfig<T> seleniumDriverConfig = new(pageLoadInSecs, implicitWaitInSecs, headless);

        SeleniumDriver = seleniumDriverConfig.Driver;
        SL_HomePage = new HomePage(SeleniumDriver);
        SL_InventoryPage = new InventoryPage(SeleniumDriver);
    }


    public void LogOn()
    {
        SeleniumDriver.Navigate().GoToUrl(AppConfigReader.HomePageUrl);
        SeleniumDriver.Manage().Cookies.AddCookie(new Cookie("session-username", AppConfigReader.UserName));
        SeleniumDriver.Navigate().Back();
    }

    public void RemoveCookies()
    {
        SeleniumDriver.Manage().Cookies.DeleteAllCookies();
    }


    public void CleanUp()
    {
        // Quit the driver, closing associated window
        SeleniumDriver.Quit();
        // Releases unmanaged resources
        SeleniumDriver.Dispose();
    }

    public string GetUrl()
    {
        return SeleniumDriver.Url;
    }
}
