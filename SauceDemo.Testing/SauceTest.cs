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
        var mainPage =loginPage.Login("standard_user", "secret_sauce");
        
        Assert.Multiple(() =>
        {
            Assert.IsTrue(mainPage.IsBurgerVisible(), "Бургер-меню не відображається");
            Assert.IsTrue(mainPage.IsLabelVisible(), "Логотип 'Swag Labs' не відображається");
            Assert.IsTrue(mainPage.IsCartIconVisible(), "Іконка кошика не відображається");
            Assert.IsTrue(mainPage.IsSortDropdownVisible(), "Фільтр сортування не відображається");
            Assert.IsTrue(mainPage.IsInventoryListVisible(), "Список товарів не відображається");
        });
    }
}