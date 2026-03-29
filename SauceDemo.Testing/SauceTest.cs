using FluentAssertions;
using SauceDemo.BLL.PageObjects;
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
        
        loginPage.EnterLoginPassword("standard_user", "a");
        loginPage.ClearPasswordField();
        loginPage.ClickLoginButton();
        
        var errorMessage = loginPage.GetErrorMessage();
        errorMessage.Should().Contain("Password is required");
    }

    [Test]
    public void UC2_Test()
    {
        var loginPage = new LoginPage(Browser);
        
        var mainPage = loginPage.Login("standard_user", "secret_sauce");
        
        mainPage.IsBurgerVisible().Should().BeTrue();
        mainPage.IsSwagLabelVisible().Should().BeTrue();
        mainPage.IsCartIconVisible().Should().BeTrue();
        mainPage.IsSortDropdownVisible().Should().BeTrue();
        mainPage.IsInventoryListVisible().Should().BeTrue();
    }
    
    
    [Test]
    public void UC3_Test()
    {
        var loginPage = new LoginPage(Browser);
        
        var mainPage = loginPage.Login("standard_user", "secret_sauce");
        var productPage = mainPage.OpenProductDetails();
        productPage.AddToCart();
        
       productPage.IsCartBadgeDisplayed().Should().BeTrue();
    }
}