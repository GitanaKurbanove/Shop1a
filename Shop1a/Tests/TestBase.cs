using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Shop1a.Drivers;
using Shop1a.Pages;



namespace Shop1a.Tests
{
    public class TestBase
    {
        public static IWebDriver driver;
        public static Shop1aMainPage _shop1AMainPage;
        public static Shop1aNewUserSignUpPage _shop1ANewUserSignUpPage;
        public static Shop1aUserSignInPage _shop1AUserSignInPage;
        public static Shop1aComputerEquipmentPage _shop1AComputerEquipmentPage;
        public static Shop1aShoppingCartPage _shop1aShoppingCartPage;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            driver = CustomDrivers.GetChromeWithOptions();
           
            _shop1AMainPage = new Shop1aMainPage(driver);
            _shop1ANewUserSignUpPage = new Shop1aNewUserSignUpPage(driver);
            _shop1AUserSignInPage = new Shop1aUserSignInPage(driver);
            _shop1AComputerEquipmentPage = new Shop1aComputerEquipmentPage(driver);
            _shop1aShoppingCartPage = new Shop1aShoppingCartPage(driver);
        }

       
        [TearDown]

        public static void SingleTestTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Tools.MyScreenshot.MakePhoto(driver);
            }
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            driver.Quit();
        }



    }
}
