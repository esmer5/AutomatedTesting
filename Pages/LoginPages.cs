
using OpenQA.Selenium;

namespace SauceDemo.Tests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Username => _driver.FindElement(By.CssSelector("input[data-test='username']"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("input[data-test='password']"));
        private IWebElement LoginButton => _driver.FindElement(By.CssSelector("input[data-test='login-button']"));
        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("h3[data-test='error']"));

        public void Navigate() => _driver.Navigate().GoToUrl("https://www.saucedemo.com");

        public void EnterUsername(string username)
        {
            Username.Clear();
            Username.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Password.Clear();
            Password.SendKeys(password);
        }

        public void ClearFields()
        {
            Username.SendKeys(Keys.Control + "a" + Keys.Delete);
            Password.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        public void ClickLogin() => LoginButton.Click();

        public string GetErrorMessage() => ErrorMessage.Text;

        public string GetTitle() => _driver.Title;
    }
}
