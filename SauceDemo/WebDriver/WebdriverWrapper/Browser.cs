using Serilog;
using OpenQA.Selenium;

namespace SauceDemo.WebDriver.WebdriverWrapper;

public partial class WebdriverWrapper
{
    private readonly TimeSpan _timeout;

    private readonly IWebDriver _driver;

    private const int WaitTimeInSeconds = 20;

    public WebdriverWrapper(BrowserType browserType)
    {
        Log.Logger = new LoggerConfiguration()
            .CreateLogger();
        
        Log.Information("Initializing WebDriver for: {BrowserType}", browserType);
        _driver = DriverFactory.CreateWebDriver(browserType);
        _timeout = TimeSpan.FromSeconds(WaitTimeInSeconds);
    }

    public void StartBrowser(int implicitWaitTime = 10)
    {
        Log.Information("Starting browser. Maximizing window and setting ImplicitWait: {Wait}s", implicitWaitTime);
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitTime);
    }

    public void Close()
    {
        Log.Warning("Closing browser session and disposing resources.");
        _driver.Quit();
        _driver.Dispose();
    }

    public void NavigateTo(string url)
    {
        Log.Information("Navigating to URL: {Url}", url);
        _driver.Navigate().GoToUrl(url);
    }
}