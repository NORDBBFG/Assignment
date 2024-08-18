using FramworkTask1.AbstractEntities;
using FramworkTask1.Entities;
using FramworkTask1.POM.SwagLabsLoginPage;

namespace FramworkTask1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class UC_1 : BaseTest
    {
        [TestCase("SomeUser", "88005553535", "Epic sadface: Username is required")]
        [TestCase("88005553535", "SomeUser", "Epic sadface: Username is required")]
        public void Check_LoginErrorMassage_WithoutCredentials(string userName, string password, string expectedErrorMassage)
        {
            Serilog.Log.Information($"Test case {TestContext.CurrentContext.Test.MethodName} was started with params:" +
                $"\n userName: {userName}\n password: {password}\n expectedErrorMassage: {expectedErrorMassage}");
            //Arrange
            UserEntity? user;

            //Act
            user = new UserEntity();
            user.Username = userName;
            user.Password = password;

            //Assert
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var swagLabsLoginPageContext = new SwagLabsLoginPageContext(driver);
            swagLabsLoginPageContext.setUsername(user.Username)
                .setPassword(user.Password)
                .clearUserCredentials()
                .clickButtonLogin<SwagLabsLoginPageContext>()
                .verifyErrorMessageAppears(expectedErrorMassage);
        }
    }
}