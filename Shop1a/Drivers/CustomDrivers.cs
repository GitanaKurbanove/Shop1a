using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;


namespace Shop1a.Drivers
{
    public static class CustomDrivers
    {
        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browser.Chrome);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            return GetDriver(Browser.FireFox);
        }

        public static IWebDriver GetChromeWithOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("incognito");

            return new ChromeDriver(options);
        }

        private static IWebDriver GetDriver(Browser browserName)
        {
            IWebDriver webDriver = null;
            switch (browserName)
            {
                case Browser.FireFox:
                    webDriver = new FirefoxDriver();
                    break;
                case Browser.Chrome:
                    webDriver = GetChromeWithOptions();
                    break;
            }
            
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            return webDriver;
        }
    }
}
