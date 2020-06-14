using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace Shop1a.Pages
{
    public class PageBase
    {
        protected static IWebDriver Driver;

        public PageBase(IWebDriver webdriver)
        {
            Driver = webdriver;
        }
        public void CloseBrowser()
        {
            Driver.Quit();
        }
        public WebDriverWait GetWait()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            return wait;
        }

    }
}
