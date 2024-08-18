using FramworkTask1.AbstractEntities;
using Microsoft.Extensions.Configuration;
using FramworkTask1.Util;
using FramworkTask1.Entities;
using FramworkTask1.POM.SwagLabsLoginPage;

namespace FramworkTask1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class UC_1 : BaseTest
    {
        [Test]
        public void Check_LoginErrorMassage_WithoutCredentials()
        {
            //Arrange
            UserEntity? user;
            string expectedErrorMassage;

            //Act
            _config = new ConfigurationBuilder()
            .SetBasePath(StringUtils.testsPath)
            .AddJsonFile("UC_1.json")
            .Build();

            user = _config.GetSection("TestData").Get<UserEntity>();
            expectedErrorMassage = "Epic sadface: Username is required";

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