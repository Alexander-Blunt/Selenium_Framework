using OpenQA.Selenium.Chrome;
using SL_Pom_Framework_Test.lib.pages;

namespace SL_Pom_Framework_Test.Tests.ChromeTests;

public class HomePageTests
{
    private SL_Website<ChromeDriver> SL_Website = new();

    [Test]
    [Category("Happy")]
    public void GivenIamOntheHomepage_WhenIEnterAValidUsernameAndValidPassword_ThenIShouldLandOnTheInventoryPage()
    {
        // Navigate to home page
        SL_Website.SL_HomePage.VisitHomePage();
        // Enter valid username
        SL_Website.SL_HomePage.EnterUserName(AppConfigReader.UserName);
        // Enter valid password
        SL_Website.SL_HomePage.EnterPassword(AppConfigReader.Password);
        // Click login button
        SL_Website.SL_HomePage.ClickLoginButton();
        // Check landing page is correct
        Assert.That(SL_Website.GetUrl(), Is.EqualTo(AppConfigReader.InventoryPageUrl));
    }

    [Test]
    [Category("Sad")]
    public void GivenIamOntheHomepage_WhenIEnterAValidUsernameAndInvalidPassword_ThenIShouldStayOnTheHomepage()
    {
        // Navigate to home page
        SL_Website.SL_HomePage.VisitHomePage();
        // Enter valid username
        SL_Website.SL_HomePage.EnterUserName(AppConfigReader.UserName);
        // Enter invalid password
        SL_Website.SL_HomePage.EnterPassword("passwort");
        // Click login button
        SL_Website.SL_HomePage.ClickLoginButton();
        // Check landing page is correct
        Assert.That(SL_Website.GetUrl(), Is.EqualTo(AppConfigReader.HomePageUrl));
    }

    [Test]
    [Category("Sad")]
    public void GivenIamOntheHomepage_WhenIEnterAValidUsernameAndInvalidPassword_ThenIShouldSeeCorrectErrorMessage()
    {
        // Navigate to home page
        SL_Website.SL_HomePage.VisitHomePage();
        // Enter valid username
        SL_Website.SL_HomePage.EnterUserName(AppConfigReader.UserName);
        // Enter invalid password
        SL_Website.SL_HomePage.EnterPassword("passwort");
        // Click login button
        SL_Website.SL_HomePage.ClickLoginButton();
        // Check error message is "Epic sadface: Username and password do not match any user in this service"
        Assert.That(SL_Website.SL_HomePage.GetErrorMessage(), Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
    }

    [Test]
    [Category("Sad")]
    public void GivenIamOntheHomepage_WhenIDoNotEnterAUsername_ThenIShouldSeeCorrectErrorMessage()
    {
        // Navigate to home page
        SL_Website.SL_HomePage.VisitHomePage();
        // Enter valid password
        SL_Website.SL_HomePage.EnterPassword(AppConfigReader.Password);
        // Click login button
        SL_Website.SL_HomePage.ClickLoginButton();
        // Check error message is "Epic sadface: Username is required"
        Assert.That(SL_Website.SL_HomePage.GetErrorMessage(), Is.EqualTo("Epic sadface: Username is required"));
    }

    [Test]
    [Category("Sad")]
    public void GivenIamOntheHomepage_WhenIDoNotEnterAPassword_ThenIShouldSeeCorrectErrorMessage()
    {
        // Navigate to home page
        SL_Website.SL_HomePage.VisitHomePage();
        // Enter valid username
        SL_Website.SL_HomePage.EnterUserName(AppConfigReader.UserName);
        // Click login button
        SL_Website.SL_HomePage.ClickLoginButton();
        // Check error message is "Epic sadface: Username is required"
        Assert.That(SL_Website.SL_HomePage.GetErrorMessage(), Is.EqualTo("Epic sadface: Password is required"));
    }

    // Will run once after all tests have finished
    [OneTimeTearDown]
    public void CleanUp()
    {
        SL_Website.CleanUp();
    }
}
