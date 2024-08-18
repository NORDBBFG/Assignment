using FramworkTask1.AbstractEntities;
using FramworkTask1.Entities;
using FramworkTask1.POM.SwagLabsLoginPage;
using FramworkTask1.POM.SwagLabsLoginPage.SwagLabsInventoryPage;

namespace FramworkTask1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    internal class UC_3 : BaseTest
    {
        [Test]
        public void Check_LoginSuccessfully_WithValidCredentials()
        {
            //Arrange
            UserEntity? user;
            string expectedLogo;

            //Act
            user = new UserEntity();
            expectedLogo = "Swag Labs";

            //Assert
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var swagLabsLoginPageContext = new SwagLabsLoginPageContext(driver);
            swagLabsLoginPageContext.selectRandomValidUserName(user)
                .selectRandomValidPassword(user)
                .setUsername(user.Username)
                .setPassword(user.Password)
                .clickButtonLogin<SwagLabsInventoryPageContext>()
                .verifySwagLogo(expectedLogo);

        }
    }
}
