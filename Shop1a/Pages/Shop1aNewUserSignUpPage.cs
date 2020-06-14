using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Shop1a.Pages
{
    public class Shop1aNewUserSignUpPage : PageBase
    {
        private IWebElement _userEmail => Driver.FindElement(By.Id("user_email"));
        private IWebElement _userPassword => Driver.FindElement(By.Id("user_password"));
        private IWebElement _userPasswordConfirmation => Driver.FindElement(By.Id("user_password_confirmation"));
        private IWebElement _userRegistrationConsentCheckBox => Driver.FindElement(By.Id("user_registration_consent"));
        private IWebElement _userMarketingConsentCheckBox => Driver.FindElement(By.Id("user_marketing_consent"));
        private IWebElement _newUserSignUpButton => Driver.FindElement(By.XPath("//*[@id='new_user']/div[6]/input"));
        private static IWebElement _registrationMessage => Driver.FindElement(By.CssSelector(".users-session__header--emphasized"));
        
        public Shop1aNewUserSignUpPage(IWebDriver webdriver) : base(webdriver) { }

        
        public Shop1aNewUserSignUpPage CheckIfWeAreOnRegistrationPage(string expectedResult)
        {
            Assert.True(_registrationMessage.Text.Contains(expectedResult), $"Message [{_registrationMessage.Text}] doesn't contain text: [{expectedResult}]");
            return this;
        }

        public Shop1aMainPage PerformSignUp(string userEmail, string password, string samePassword)
        {
            _userEmail.Clear();
            _userEmail.SendKeys(userEmail);
            _userPassword.Clear();
            _userPassword.SendKeys(password);
            _userPasswordConfirmation.Clear();
            _userPasswordConfirmation.SendKeys(samePassword);

            Actions actions = new Actions(Driver);
            actions.SendKeys(Keys.PageDown).Build().Perform();

            var userRegistrationConsentCheckBox = _userRegistrationConsentCheckBox;
            var userMarketingConsentCheckBox = _userMarketingConsentCheckBox;

            GetWait().Until(ExpectedConditions.ElementToBeClickable(userRegistrationConsentCheckBox));
            GetWait().Until(ExpectedConditions.ElementToBeClickable(userMarketingConsentCheckBox));

            if (!userRegistrationConsentCheckBox.Selected && !userMarketingConsentCheckBox.Selected)
            {
                userRegistrationConsentCheckBox.Click();
                userMarketingConsentCheckBox.Click();
            }

           _newUserSignUpButton.Click();

            return new Shop1aMainPage(Driver);
        }

    }
}
