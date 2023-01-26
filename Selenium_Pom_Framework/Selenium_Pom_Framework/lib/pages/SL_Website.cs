using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SL_Pom_Framework_Test.lib.driver_config;

namespace SL_Pom_Framework_Test.lib.pages;

public class SL_Website<T> where T : IWebDriver, new()
{
    public IWebDriver SeleniumDriver { get; internal set; }
    public HomePage SL_HomePage { get; internal set; }

    public SL_Website(int pageLoadInSecs = 3, int implicitWaitInSecs = 3, bool headless = true)
    {
        SeleniumDriverConfig<T> seleniumDriverConfig = new(pageLoadInSecs, implicitWaitInSecs, headless);

        SeleniumDriver = seleniumDriverConfig.Driver;
        SL_HomePage = new HomePage(SeleniumDriver);
    }

}
