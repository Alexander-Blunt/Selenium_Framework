using OpenQA.Selenium;

namespace SL_Pom_Framework_Test.lib.pages;

public class InventoryPage
{
    private readonly IWebDriver _driver;
    public InventoryItem[]? InventoryItems { get; internal set; }

    public InventoryPage(IWebDriver seleniumDriver)
    {
        _driver = seleniumDriver;
    }

    public void VisitInventoryPage()
    {
        _driver.Navigate().GoToUrl(AppConfigReader.InventoryPageUrl);
        List<InventoryItem> inventoryList = new();
        foreach (IWebElement element in _driver.FindElements(By.ClassName("inventory_item")))
        {
            inventoryList.Add(new InventoryItem(element));
        }
        InventoryItems = inventoryList.ToArray();
    }
}

public class InventoryItem
{
    public IWebElement WebElement { get; init; }
    
    public InventoryItem(IWebElement webElement)
    {
        WebElement = webElement;
    }

    public string GetName()
    {
        return WebElement.FindElement(By.CssSelector("div[class='inventory_item_name]")).Text;
    }

    public string GetDesc()
    {
        return WebElement.FindElement(By.CssSelector("div[class='inventory_item_desc]")).Text;
    }

    public string GetPrice()
    {
        return WebElement.FindElement(By.CssSelector("div[class='inventory_item_price]")).Text;
    }
    public string GetButtonText()
    {
        return WebElement.FindElement(By.TagName("button")).Text;
    }

    public void ClickButton()
    {
        WebElement.FindElement(By.TagName("button")).Click();
    }
}
