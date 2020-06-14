using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Shop1a.Pages
{
    public class Shop1aUserSignInPage : PageBase
    {
        private IWebElement _userEmail => Driver.FindElement(By.Id("user_email"));
        private IWebElement _userPassword => Driver.FindElement(By.Id("user_password"));
        private IWebElement _signInButton => Driver.FindElement(By.CssSelector(".users-session-form__submit"));
        private static IWebElement _signInMessage => Driver.FindElement(By.Id("/users/sign_in"));

        public Shop1aUserSignInPage(IWebDriver webdriver) : base(webdriver) { }

        public Shop1aUserSignInPage CheckIfWeAreOnSignInPage(string expectedMessage)
        {
            Assert.True(_signInMessage.Text.Contains(expectedMessage), $"Message [{_signInMessage.Text}] doesn't contain text: [{expectedMessage}]");
            return this;
        }

        public Shop1aMainPage PerformSignIn(string userEmail, string password)
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.Id("user_email")));
            _userEmail.Clear();
            _userEmail.SendKeys(userEmail);
            _userPassword.Clear();
            _userPassword.SendKeys(password);

            _signInButton.Click();

            return new Shop1aMainPage(Driver);
        }

    }
}
