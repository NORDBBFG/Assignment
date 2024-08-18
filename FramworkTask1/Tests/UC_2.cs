using FramworkTask1.AbstractEntities;
using FramworkTask1.Entities;
using FramworkTask1.POM.SwagLabsLoginPage;
using FramworkTask1.Util;
using Microsoft.Extensions.Configuration;

namespace FramworkTask1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    internal class UC_2 : BaseTest
    {
        [Test]
        public void Check_LoginErrorMassage_WithoutPassword()
        {
            //Arrange
            UserEntity? user;
            string expectedErrorMassage;

            //Act
            _config = new ConfigurationBuilder()
            .SetBasePath(StringUtils.testsPath)
            .AddJsonFile("UC_2.json")
            .Build();

            user = _config.GetSection("TestData").Get<UserEntity>();
            expectedErrorMassage = "Epic sadface: Password is required";

            //Assert
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var swagLabsLoginPageContext = new SwagLabsLoginPageContext(driver);
            swagLabsLoginPageContext.setUsername(user.Username)
                .setPassword(user.Password)
                .clearPassword()
                .clickButtonLogin<SwagLabsLoginPageContext>()
                .verifyErrorMessageAppears(expectedErrorMassage);
        }
    }
}
