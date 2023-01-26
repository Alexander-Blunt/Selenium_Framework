using OpenQA.Selenium;

namespace SL_Pom_Framework_Test.lib.pages;

public class InventoryPage
{
    private readonly IWebDriver _driver;
    public IWebElement SelectedItem;

    public InventoryPage(IWebDriver seleniumDriver)
    {
        _driver = seleniumDriver;
    }

    public void VisitInventoryPage()
    {
        _driver.Navigate().GoToUrl(AppConfigReader.InventoryPageUrl);
    }

    public void SelectFirstInventoryItem()
    {
        SelectedItem = _driver.FindElement(By.ClassName("inventory_item"));
    }
}
