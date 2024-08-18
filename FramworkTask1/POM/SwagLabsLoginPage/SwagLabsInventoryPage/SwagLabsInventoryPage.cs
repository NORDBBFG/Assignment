using FramworkTask1.AbstractEntities;
using OpenQA.Selenium;

namespace FramworkTask1.POM.SwagLabsLoginPage.SwagLabsInventoryPage
{
    internal class SwagLabsInventoryPage : AbstractPage
    {
        public SwagLabsInventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement DivSwagLogo => driver.FindElement(By.XPath("//div[@class='app_logo']"));
    }
}
