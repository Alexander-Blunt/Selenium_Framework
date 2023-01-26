using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SL_Pom_Framework_Test.lib.pages;

public class HomePage
{
    private readonly IWebDriver _seleniumDriver;
    
    public HomePage(IWebDriver seleniumDriver)
    {
        _seleniumDriver = seleniumDriver;
    }

    public void VisitHomePage()
    {
        _seleniumDriver.Navigate().GoToUrl(AppConfigReader.HomePageUrl);
    }

    public void EnterUserName(string userName)
    {
        var usernameElement = _seleniumDriver.FindElement(By.Id("user-name"));
        usernameElement.SendKeys(userName);
    }

    public void EnterPassword(string password)
    {
        var passwordElement = _seleniumDriver.FindElement(By.Id("password"));
        passwordElement.SendKeys(password);
    }

    public void ClickLoginButton()
    {
        _seleniumDriver.FindElement(By.Id("login-button")).Click();
    }
}
