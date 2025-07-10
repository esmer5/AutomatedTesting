
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SauceDemo.Tests.Drivers
{
    public static class WebDriverSingleton
    {
        private static IWebDriver? _driver;
        private static string _browser = "chrome";

        public static IWebDriver Driver => _driver ??= CreateDriver();

        private static IWebDriver CreateDriver()
        {
            IWebDriver driver = _browser.ToLower() switch
            {
                "firefox" => new FirefoxDriver(),
                _ => new ChromeDriver()
            };
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }

        public static void Quit()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
