using SauceDemo.BLL.PageObjects;
using SauceDemo.WebDriver;
using SauceDemo.WebDriver.WebdriverWrapper;

namespace SauceDemo.Testing;

public class Tests
{
    public WebdriverWrapper Browser { get; private set; }

    [SetUp]
    public void Setup()
    {
        var browserType = (BrowserType)Enum.Parse(typeof(BrowserType), Configuration.BrowserType);
        Browser = new WebdriverWrapper(browserType);
        Browser.StartBrowser();
        Browser.NavigateTo(Configuration.SiteUrl);
    }

    [Test]
    public void UC1_Test()
    {
        var loginPage = new LoginPage(Browser);
        
        loginPage.Login("any", "any");
        
        Assert.IsTrue(loginPage.IsErrorVisible());
    }
}