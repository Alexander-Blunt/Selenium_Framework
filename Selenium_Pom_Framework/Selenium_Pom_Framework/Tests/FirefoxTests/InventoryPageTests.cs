using OpenQA.Selenium.Firefox;
using SL_Pom_Framework_Test.lib.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL_Pom_Framework_Test.Tests.FirefoxTests
{
    public class InventoryPageTests
    {
        private SL_Website<FirefoxDriver> SL_Website = new();

        [Test]
        [Category("Sad")]
        public void GivenIAmNotLoggedOn_WhenINavigateToTheInventoryPage_ILandOnTheHomePage()
        {
            //ensure logged off
            SL_Website.RemoveCookies();

            //navigate to inventory page
            SL_Website.SL_InventoryPage.VisitInventoryPage();

            Assert.That(SL_Website.GetUrl(), Is.EqualTo(AppConfigReader.HomePageUrl));
        }

        [Test]
        [Category("Happy")]
        public void GivenIAmLoggedOn_WhenINavigateToTheInventoryPage_ILandOnTheInventoryPage()
        {
            SL_Website.LogOn();

            //navigate to inventory page
            SL_Website.SL_InventoryPage.VisitInventoryPage();

            Assert.That(SL_Website.GetUrl(), Is.EqualTo(AppConfigReader.InventoryPageUrl));
        }

        [Test]
        [Category("Happy")]
        public void GivenIAmOnTheInventoryPage_WhenIClickAddToCartOnAnItem_TheAddToCartButtonChangesToRemove()
        {
            SL_Website.LogOn();

            //navigate to inventory page
            SL_Website.SL_InventoryPage.VisitInventoryPage();

            //click on the add to cart button
            SL_Website.SL_InventoryPage.InventoryItems[0].ClickButton();

            Assert.That(SL_Website.SL_InventoryPage.InventoryItems[0].GetButtonText(), Is.EqualTo("REMOVE"));
        }

        // Will run once after all tests have finished
        [OneTimeTearDown]
        public void CleanUp()
        {
            SL_Website.CleanUp();
        }
    }
}
