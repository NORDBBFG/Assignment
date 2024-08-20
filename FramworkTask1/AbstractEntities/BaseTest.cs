using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using Serilog;
using FramworkTask1.Util;

namespace FramworkTask1.AbstractEntities
{
    public abstract class BaseTest
    {
        protected IWebDriver? driver;
        private IConfiguration _browserConfig;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("test-log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Information("Logger were created");
        }

        [SetUp]
        public void Setup()
        {
            var configPath = Path.Combine(StringUtils.driverConfigPath, "driverConfig.json");
            _browserConfig = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .Build();

            string browser = _browserConfig["Browser"];

            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    driver = new EdgeDriver(edgeOptions);
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }
            Log.Information($"Driver: {driver} where used.");

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
            Log.Information("Test case where ended");
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            Log.Information("Logger were flushed");
            Log.CloseAndFlush();
        }
    }
}
