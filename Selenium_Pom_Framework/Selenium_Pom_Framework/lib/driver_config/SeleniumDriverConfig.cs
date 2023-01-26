using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SL_Pom_Framework_Test.lib.driver_config;

public class SeleniumDriverConfig<T> where T : IWebDriver, new()
{
    public IWebDriver Driver { get; internal set; }
    public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSecs, bool headless)
    {
        //check driver is of valid type
        CheckDriverType();

        if (headless) SetHeadless();
        else Driver = new T();

        Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);

        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);
    }

    private void CheckDriverType()
    {
        if (!(typeof(T) == typeof(ChromeDriver)) && !(typeof(T) == typeof(FirefoxDriver)))
        {
            throw new ArgumentException("IWebDriver must be of type ChromeDriver or FirefoxDriver");
        }
    }

    private void SetHeadless()
    {
        if (typeof(T) == typeof(ChromeDriver))
        {
            ChromeOptions options = new();
            options.AddArgument("headless");
            Driver = new ChromeDriver(options);
        }
        else if (typeof(T) == typeof(FirefoxDriver))
        {
            FirefoxOptions options = new();
            options.AddArgument("-headless");
            Driver = new FirefoxDriver(options);
        }
    }
}
