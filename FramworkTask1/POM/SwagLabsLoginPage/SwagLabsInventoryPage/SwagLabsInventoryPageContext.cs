using FramworkTask1.AbstractEntities;
using OpenQA.Selenium;

namespace FramworkTask1.POM.SwagLabsLoginPage.SwagLabsInventoryPage
{
    internal class SwagLabsInventoryPageContext : AbstractPageContext
    {
        private readonly SwagLabsInventoryPage swagLabsInventoryPage;
        public SwagLabsInventoryPageContext(IWebDriver driver)
        {
            this.driver = driver;
            swagLabsInventoryPage = new SwagLabsInventoryPage(driver);
        }

        public SwagLabsInventoryPageContext verifySwagLogo(string expectedLogo)
        {
            string actualLogo = swagLabsInventoryPage.DivSwagLogo.Text;
            Assert.That(actualLogo, Is.EqualTo(expectedLogo));
            return this;
        }
    }
}
