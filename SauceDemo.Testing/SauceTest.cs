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

    [TearDown]
    public void TearDown()
    {
        Browser.Close();
    }
    [Test]
    public void UC1_Test()
    {
        var loginPage = new LoginPage(Browser);
        
        loginPage.Login("any", "any");
        
        Assert.IsTrue(loginPage.IsErrorVisible());
    }

    [Test]
    public void UC2_Test()
    {
        var loginPage = new LoginPage(Browser);
        
        var mainPage = loginPage.Login("standard_user", "secret_sauce");
        
        Assert.Multiple(() =>
        {
            Assert.IsTrue(mainPage.IsBurgerVisible());
            Assert.IsTrue(mainPage.IsLabelVisible());
            Assert.IsTrue(mainPage.IsCartIconVisible());
            Assert.IsTrue(mainPage.IsSortDropdownVisible());
            Assert.IsTrue(mainPage.IsInventoryListVisible());
        });
    }
    
    
    [Test]
    public void UC3_Test()
    {
        var loginPage = new LoginPage(Browser);
        
        var mainPage = loginPage.Login("standard_user", "secret_sauce");
        var productPage = mainPage.OpenProductDetails();
        productPage.AddToCart();
        
        Assert.IsTrue(productPage.IsCartBadgeDisplayed());
    }
}