using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace Shop1a.Pages
{
    public class Shop1aMainPage : PageBase

    {
        private static IWebElement _messageInput => Driver.FindElement(By.Id("q"));
        private static IWebElement _mainSearchButton => Driver.FindElement(By.XPath("//*[@id='top-search-form']/div/div[2]/button/i"));
        private static IWebElement _hairDryerCheckBox => Driver.FindElement(By.PartialLinkText("Plaukų džiovintuvai"));
        private static IWebElement _searchResultHeading => Driver.FindElement(By.ClassName("active-filter"));
        private static IWebElement _userProfileDropDown => Driver.FindElement(By.CssSelector(".user-block__icon"));
        private static IWebElement _signUpButton => Driver.FindElement(By.XPath("//a[contains(text(),'Registruotis')]"));
        private static IWebElement _signInButton => Driver.FindElement(By.XPath("//strong[contains(.,'Prisijungti')]"));
        private static IWebElement _buttonToMyProfile => Driver.FindElement(By.LinkText("Mano profilis"));
        private static IWebElement _errorMessageAfterSignUp => Driver.FindElement(By.ClassName("users-session-form__error-message"));
        private static IWebElement _mainMenuIcon => Driver.FindElement(By.CssSelector(".main-menu__handle"));
        private static IWebElement _computerEquipmentOfficeSuppliesButton => Driver.FindElement(By.LinkText("Kompiuterinė technika, biuro prekės"));

        public Shop1aMainPage(IWebDriver webdriver) : base(webdriver) { }

        public Shop1aMainPage OpenShop1aPage()
        {
            Driver.Url = "https://www.1a.lt/";
            return this;
        }

        public Shop1aMainPage AddCookieConcent()
        {
            OpenQA.Selenium.Cookie myCookie = new OpenQA.Selenium.Cookie(
                "CookieConsent",
                "{stamp:'pwwMnFtzGMTJjtJkJQDnZmVtpQAY8sTIn6EVlKCTOo1tXcZ44nRR5w=='%2Cnecessary:true%2Cpreferences:true%2Cstatistics:true%2Cmarketing:true%2Cver:1%2Cutc:1591722604907%2Cregion:'lt'}",
                "/",
                DateTime.Now.AddYears(1));

            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();

            return this;
        }

        public Shop1aMainPage EnterKeywordToSearchBox(string myKeyword)
        {
            _messageInput.Clear();
            _messageInput.SendKeys(myKeyword);
            return this;
        }

        public Shop1aMainPage ClickMainSeachButton()
        {
            var mainSearchButton = _mainSearchButton;
            mainSearchButton.Click();

            return this;
        }

        public Shop1aMainPage ClickHairDryerCheckBox()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Plaukų džiovintuvai")));

            Actions actions = new Actions(Driver);
            actions.SendKeys(Keys.PageDown).Build().Perform();

            var hairDryerCheckBox = _hairDryerCheckBox;
            if (hairDryerCheckBox.Selected != true)
                hairDryerCheckBox.Click();

            GetWait().Until(ExpectedConditions.StalenessOf(hairDryerCheckBox));

            return this;
        }

        public Shop1aMainPage CheckResultHeading(string expectedResult)
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.ClassName("active-filter")));
            Assert.True(_searchResultHeading.Text.Contains(expectedResult), $"Heading [{_searchResultHeading.Text}] doesn't contain [{expectedResult}]");
            return this;
        }

        public Shop1aNewUserSignUpPage GoToSignUpPage(string text)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(_userProfileDropDown).Perform();
            
            _signUpButton.Click();

            return new Shop1aNewUserSignUpPage(Driver);
        }

        public Shop1aMainPage CheckErrorMessageAfterReregistration(string expectedText)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(_userProfileDropDown).Perform();

            Assert.AreEqual(expectedText, _errorMessageAfterSignUp.Text, $"Heading [{_errorMessageAfterSignUp.Text}] is not equal [{expectedText}]");

            return this;
        }

        public Shop1aUserSignInPage GoToSignInPage(string text)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(_userProfileDropDown).Perform();

            _signInButton.Click();

            return new Shop1aUserSignInPage(Driver);
        }

        public Shop1aMainPage CheckAfterSignIn(string expectedText)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(_userProfileDropDown).Perform();

            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Mano profilis")));
            
            Assert.AreEqual(expectedText, _buttonToMyProfile.Text, $"Heading [{_buttonToMyProfile.Text}] is not equal [{expectedText}]");

            return this;
        }

        public Shop1aComputerEquipmentPage GoToComputerEquipmentPage()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(_mainMenuIcon).Perform();
            _computerEquipmentOfficeSuppliesButton.Click();

            return new Shop1aComputerEquipmentPage(Driver);
        }


    }
}
