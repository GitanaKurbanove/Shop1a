using NUnit.Framework;
using OpenQA.Selenium;


namespace Shop1a.Pages
{
    public class Shop1aShoppingCartPage : PageBase
    {
        private static IWebElement _cartPageTitle => Driver.FindElement(By.ClassName("cart__page-title"));

        public Shop1aShoppingCartPage(IWebDriver webdriver) : base(webdriver) { }


        public Shop1aShoppingCartPage CheckIfWeAreOnShoppingCartPage(string expectedTitle)
        {
            Assert.True(_cartPageTitle.Text.Contains(expectedTitle), $"Message [{_cartPageTitle.Text}] doesn't contain text: [{expectedTitle}]");
            return this;
        }

    }
}
