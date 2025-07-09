
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using Serilog;

[Binding]
public class LoginSteps : IDisposable
{
    private IWebDriver _driver;
    private string _url = "https://www.saucedemo.com";

    private IWebElement Username => _driver.FindElement(By.CssSelector("input[data-test='username']"));
    private IWebElement Password => _driver.FindElement(By.CssSelector("input[data-test='password']"));
    private IWebElement LoginButton => _driver.FindElement(By.CssSelector("input[data-test='login-button']"));
    private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("h3[data-test='error']"));

    public LoginSteps()
    {
        _driver = new ChromeDriver();

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }

    [Given("the user navigates to the SauceDemo login page")]
    public void GivenTheUserNavigatesToSauceDemo()
    {
        _driver.Navigate().GoToUrl(_url);
    }

    [When(@"the user enters '(.*)' as username and clears password")]
    public void WhenUserEntersUsernameAndClearsPassword(string username)
    {
        Username.Clear();
        Password.Clear();

        Username.SendKeys(username);
        Password.Clear(); // por si hay algo residual
    }

    [When("the user enters '(.*)' as username and '(.*)' as password")]
    public void WhenUserEntersCredentials(string username, string password)
    {
        Username.SendKeys(username);
        Password.SendKeys(password);
    }

    [When("the user clears the username and password fields")]
    public void WhenUserClearsCredentials()
    {
        Username.Clear();
        Password.Clear();

        Username.GetAttribute("value").Should().Be("");
        Password.GetAttribute("value").Should().Be("");
    }

    [When("clicks the login button")]
    public void WhenUserClicksLogin()
    {
        LoginButton.Click();
    }

    [Then("an error message '(.*)' should be displayed")]
    public void ThenErrorMessageShouldBeDisplayed(string expectedMessage)
    {
        ErrorMessage.Text.Should().Be(expectedMessage);
        Log.Information("Error message validated: {Message}", expectedMessage);
    }

    [Then("the user should see the title '(.*)'")]
    public void ThenUserShouldSeeTitle(string expectedTitle)
    {
        _driver.Title.Should().Be(expectedTitle);
        Log.Information("Page title validated: {Title}", expectedTitle);
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}
