using FramworkTask1.AbstractEntities;
using OpenQA.Selenium;

namespace FramworkTask1.POM.SwagLabsLoginPage
{
    internal class SwagLabsLoginPage : AbstractPage
    {
        public SwagLabsLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement InputUserName => driver.FindElement(By.Id("user-name"));
        public IWebElement InputPassword => driver.FindElement(By.Id("password"));
        public IWebElement ButtonLogin => driver.FindElement(By.Id("login-button"));
        public IWebElement ErrorMasage => driver.FindElement(By.XPath("//div[@class = 'error-message-container error']"));
        public IWebElement DivloginUserName => driver.FindElement(By.Id("login_credentials"));
        public IWebElement DivloginPassword => driver.FindElement(By.XPath("//div[@class='login_password']"));
    }
}
