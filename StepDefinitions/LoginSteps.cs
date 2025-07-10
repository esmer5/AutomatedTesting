
using TechTalk.SpecFlow;
using FluentAssertions;
using Serilog;
using SauceDemo.Tests.Drivers;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps()
        {
            _loginPage = new LoginPage(WebDriverSingleton.Driver);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();
        }

        [Given("the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            _loginPage.Navigate();
        }

        [When("the user clicks the login button")]
        public void WhenTheUserClicksLogin()
        {
            _loginPage.ClickLogin();
        }

        [When("the user enters '(.*)' as username and clears password")]
        public void WhenTheUserEntersUsernameAndClearsPassword(string username)
        {
            _loginPage.ClearFields();
            _loginPage.EnterUsername(username);
        }

        [When("the user enters '(.*)' as username and '(.*)' as password")]
        public void WhenTheUserEntersCredentials(string username, string password)
        {
            _loginPage.ClearFields();
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
        }

        [Then("an error message '(.*)' should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string expected)
        {
            var actual = _loginPage.GetErrorMessage();
            actual.Should().Be(expected);
            Log.Information("Validated error message: {Message}", actual);
        }

        [Then("the user should see the title '(.*)'")]
        public void ThenUserShouldSeeTitle(string expected)
        {
            var actual = _loginPage.GetTitle();
            actual.Should().Be(expected);
            Log.Information("Validated page title: {Title}", actual);
            WebDriverSingleton.Quit();
        }
    }
}
