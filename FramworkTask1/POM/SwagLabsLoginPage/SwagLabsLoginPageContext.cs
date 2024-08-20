using FramworkTask1.AbstractEntities;
using OpenQA.Selenium;
using FramworkTask1.Entities;

namespace FramworkTask1.POM.SwagLabsLoginPage
{
    internal class SwagLabsLoginPageContext : AbstractPageContext
    {
        private readonly SwagLabsLoginPage swagLabsLoginPage;

        public SwagLabsLoginPageContext(IWebDriver driver)
        {
            this.driver = driver;
            swagLabsLoginPage = new SwagLabsLoginPage(driver);
        }

        public SwagLabsLoginPageContext setUsername(string username)
        {
            swagLabsLoginPage.InputUserName.SendKeys(username);
            return this;
        }

        public SwagLabsLoginPageContext setPassword(string password)
        {
            swagLabsLoginPage.InputPassword.SendKeys(password);
            return this;
        }

        public SwagLabsLoginPageContext clearUserCredentials()
        {
            swagLabsLoginPage.InputUserName.SendKeys(Keys.Control + "a");
            swagLabsLoginPage.InputUserName.SendKeys(Keys.Delete);
            swagLabsLoginPage.InputPassword.SendKeys(Keys.Control + "a");
            swagLabsLoginPage.InputPassword.SendKeys(Keys.Delete);

            return this;
        }

        public SwagLabsLoginPageContext clearPassword()
        {
            swagLabsLoginPage.InputPassword.SendKeys(Keys.Control + "a");
            swagLabsLoginPage.InputPassword.SendKeys(Keys.Delete);

            return this;
        }

        public SwagLabsLoginPageContext clearUserName()
        {
            swagLabsLoginPage.InputUserName.SendKeys(Keys.Control + "a");
            swagLabsLoginPage.InputUserName.SendKeys(Keys.Delete);

            return this;
        }

        public SwagLabsLoginPageContext selectRandomValidUserName(UserEntity user)
        {
            Random random = new Random();
            string fullText = swagLabsLoginPage.DivloginUserName.GetAttribute("innerHTML");
            string withoutHeader = fullText.Split(new string[] { "</h4>" }, StringSplitOptions.None)[1].Trim();
            string[] usernames = withoutHeader.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
            int randomIndex = random.Next(usernames.Length);
            string validUserName = usernames[randomIndex];
            user.Username = validUserName;
            return this;
        }

        public SwagLabsLoginPageContext selectRandomValidPassword(UserEntity user)
        {
            Random random = new Random();
            string fullText = swagLabsLoginPage.DivloginPassword.GetAttribute("innerHTML");
            string withoutHeader = fullText.Split(new string[] { "</h4>" }, StringSplitOptions.None)[1].Trim();
            string[] passwords = withoutHeader.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
            int randomIndex = random.Next(passwords.Length);
            string validPasswords = passwords[randomIndex];
            user.Password = validPasswords;
            return this;
        }

        public T clickButtonLogin<T>() where T : class
        {
            swagLabsLoginPage.ButtonLogin.Click();
            try
            {
                return Activator.CreateInstance(typeof(T), driver) as T;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something hepend with returning type! \n Exeption: {ex}");
            }
        }

        public SwagLabsLoginPageContext verifyErrorMessageAppears(string expectedErrorMessage)
        {
            string actualErrorMassage;
            bool isDispayed = swagLabsLoginPage.ErrorMasage.Displayed;
            Assert.IsTrue(isDispayed, "Error message is not displayed");
            actualErrorMassage = swagLabsLoginPage.ErrorMasage.Text;
            Assert.That(expectedErrorMessage, Is.EqualTo(actualErrorMassage),
                $"Error messages are not equals, expected was: [{expectedErrorMessage}], but actual: [{actualErrorMassage}]");
            return this;
        }
    }
}
