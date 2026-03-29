using OpenQA.Selenium;
using SauceDemo.WebDriver.WebdriverWrapper;

namespace SauceDemo.BLL.PageObjects;

public class LoginPage(WebdriverWrapper driver)
{
    private readonly By userNameLocator = By.CssSelector("[data-test='username']");
    private readonly By passwordLocator = By.CssSelector("[data-test='password']");
    private readonly By LoginButtonLocator = By.CssSelector("[data-test='login-button']");
    private readonly By ErrorMessageLocator = By.CssSelector("[data-test='error']");

    public bool IsErrorVisible() => driver.FindElement(ErrorMessageLocator).Displayed;
    
    public MainPage Login(string login, string password)
    {
        driver.EnterText(userNameLocator, login);
        driver.EnterText(passwordLocator, password);
        driver.Click(LoginButtonLocator);

        return new MainPage(driver);
    }
}