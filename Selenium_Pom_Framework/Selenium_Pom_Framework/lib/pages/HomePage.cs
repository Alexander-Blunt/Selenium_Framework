using OpenQA.Selenium;

namespace SL_Pom_Framework_Test.lib.pages;

public class HomePage
{
    private readonly IWebDriver _driver;
    
    public HomePage(IWebDriver seleniumDriver)
    {
        _driver = seleniumDriver;
    }

    public void VisitHomePage()
    {
        _driver.Navigate().GoToUrl(AppConfigReader.HomePageUrl);
    }

    public void EnterUserName(string userName)
    {
        var usernameElement = _driver.FindElement(By.Id("user-name"));
        usernameElement.SendKeys(userName);
    }

    public void EnterPassword(string password)
    {
        var passwordElement = _driver.FindElement(By.Id("password"));
        passwordElement.SendKeys(password);
    }

    public void ClickLoginButton()
    {
        _driver.FindElement(By.Id("login-button")).Click();
    }

    public string GetErrorMessage()
    {
        return _driver.FindElement(By.CssSelector("h3[data-test='error']")).Text;
    }
}
