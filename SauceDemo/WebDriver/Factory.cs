using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SauceDemo.WebDriver;

public class DriverFactory
{
    public static IWebDriver CreateWebDriver(BrowserType browserType)
    {
        switch (browserType)
        {
            case BrowserType.Chrome:
                return new ChromeDriver();
            case BrowserType.Firefox:
                return new FirefoxDriver();
            default:
                throw new ArgumentOutOfRangeException(
                    nameof(browserType),
                    browserType,
                    "No such browser type supported");
        }
    }
}