
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

public static class WebDriverFactory
{
    public static IWebDriver CreateDriver(string browser)
    {
        return browser.ToLower() switch
        {
            "firefox" => new FirefoxDriver(),
            _ => new ChromeDriver()
        };
    }
}
