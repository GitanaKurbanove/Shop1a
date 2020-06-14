using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;


namespace Shop1a.Pages
{
    public class Shop1aComputerEquipmentPage : PageBase
    {
        private static IWebElement _laptopsAndAccessoriesButton => Driver.FindElement(By.LinkText("Nešiojami kompiuteriai ir priedai"));
        private static IWebElement _laptopsButton => Driver.FindElement(By.LinkText("Nešiojami kompiuteriai"));
        private static IWebElement _laptopsForBusiness => Driver.FindElement(By.LinkText("Verslui"));
        private static IWebElement _priceFrom => Driver.FindElement(By.Id("attr-from-price"));
        private static IWebElement _priceTo => Driver.FindElement(By.Id("attr-to-price"));
        private static IWebElement _dellLaptopsCheckBox => Driver.FindElement(By.XPath("//div[3]/label/a"));
        private static IWebElement _sortingDropdown => Driver.FindElement(By.ClassName("sort-select-wrap"));
        private static IWebElement _priceAscDropdown
        {
            get
            {
                var list = Driver.FindElements(By.ClassName("select2-results__option"));
                foreach (var item in list)
                {
                    if (item.Text == "Kaina nuo žemiausios")
                        return item;
                }

                return null;
            }
        }
        private static IWebElement _firstProductItemFromList
        {
            get
            {
                var list = Driver.FindElements(By.ClassName("new-product-item"));
                foreach (var item in list)
                {
                    if (list.IndexOf(item) == 0)
                        return item;
                }

                return null;
            }
        }
        private static IWebElement _addToCartButton => Driver.FindElement(By.ClassName("add-to-cart-catalog-btn"));
        private static IWebElement _lookToCartButton => Driver.FindElement(By.LinkText("Peržiūrėti pirkinių krepšelį"));
        private static IWebElement _priceOfTheItem  => Driver.FindElement(By.ClassName("item-price"));

        public Shop1aComputerEquipmentPage(IWebDriver webdriver) : base(webdriver) { }

        public Shop1aComputerEquipmentPage SelectLaptopsAndAccesoriesCategory()
        {
            var laptopsAndAccessoriesButton = _laptopsAndAccessoriesButton;

            if (laptopsAndAccessoriesButton.Selected != true)
                laptopsAndAccessoriesButton.Click();

            GetWait().Until(ExpectedConditions.StalenessOf(laptopsAndAccessoriesButton));

            return this;
        }

        public Shop1aComputerEquipmentPage SelectLaptopsCategory()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Nešiojami kompiuteriai")));

            var laptopsButton = _laptopsButton;

            if (laptopsButton.Selected != true)
                laptopsButton.Click();

            GetWait().Until(ExpectedConditions.StalenessOf(laptopsButton));

            return this;
        }

        public Shop1aComputerEquipmentPage SelectLaptopsForBusinessCategory()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Verslui")));

            var laptopsForBusiness = _laptopsForBusiness;

            if (laptopsForBusiness.Selected != true)
                laptopsForBusiness.Click();

            GetWait().Until(ExpectedConditions.StalenessOf(laptopsForBusiness));

            return this;
        }

        public Shop1aComputerEquipmentPage EnterPriceLimits(int priceFromValue, int priceToValue)
        {
            new Actions(Driver).SendKeys(Keys.PageDown).Build().Perform();

            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("attr-from-price")));
            var priceFrom = _priceFrom;
            priceFrom.Click();

            new Actions(Driver)
                .KeyDown(Keys.LeftControl)
                .SendKeys("a")
                .KeyUp(Keys.LeftControl)
                .SendKeys(priceFromValue + Keys.Enter)
                .Build()
                .Perform();
            GetWait().Until(ExpectedConditions.StalenessOf(priceFrom));

            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("attr-to-price")));

            var priceTo = _priceTo;
            priceTo.Click();

            new Actions(Driver)
                .KeyDown(Keys.LeftControl)
                .SendKeys("a")
                .KeyUp(Keys.LeftControl)
                .SendKeys(priceToValue + Keys.Enter)
                .Build()
                .Perform();
            
            GetWait().Until(ExpectedConditions.StalenessOf(priceTo));

            return this;
        }

        public Shop1aComputerEquipmentPage ChooseComputerBrand()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[3]/label/a")));
            
            var dellLaptopsCheckBox = _dellLaptopsCheckBox;

            if (dellLaptopsCheckBox.Selected != true) 
                dellLaptopsCheckBox.Click();

            GetWait().Until(ExpectedConditions.StalenessOf(dellLaptopsCheckBox));
              
            new Actions(Driver).SendKeys(Keys.Home).Build().Perform();
            return this;
        }

        public Shop1aComputerEquipmentPage SortResultsByPriceAscending()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.ClassName("sort-select-wrap")));
            var sortingDropdown = _sortingDropdown;
            sortingDropdown.Click();
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.ClassName("select2-results__option")));
            _priceAscDropdown.Click();
            GetWait().Until(ExpectedConditions.StalenessOf(sortingDropdown));

            return this;
        }

        public Shop1aComputerEquipmentPage AddToChartFirstProductItem()
        {
            new Actions(Driver).SendKeys(Keys.PageDown).Build().Perform();
            GetWait().Until(ExpectedConditions.ElementToBeClickable(_firstProductItemFromList));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(_firstProductItemFromList).Perform();
            var addToCartButton = _addToCartButton;
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.ClassName("add-to-cart-catalog-btn")));
            addToCartButton.Click();
           
            return this;
        }

        public Shop1aComputerEquipmentPage ComparePrices(int expectedResuls)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(_firstProductItemFromList).Perform();
            string originalText = _priceOfTheItem.Text;
            string itemsPriceWithoutComma = _priceOfTheItem.Text.Replace(",", "").Replace("00", "").Replace("€", "").Replace("/", "").Replace("v", "").Replace("n", "").Replace("t", "").Replace(".", "");
            int itemsPrice = Convert.ToInt32(itemsPriceWithoutComma);

            Assert.GreaterOrEqual(itemsPrice, expectedResuls);
            return this;
        }

        public Shop1aShoppingCartPage GoToShoppingCartPage()
        {
            GetWait().Until(ExpectedConditions.ElementExists(By.LinkText("Peržiūrėti pirkinių krepšelį")));
            var lookToCartButton = _lookToCartButton;
            lookToCartButton.Click();

            return new Shop1aShoppingCartPage (Driver);
        }

    }
}
