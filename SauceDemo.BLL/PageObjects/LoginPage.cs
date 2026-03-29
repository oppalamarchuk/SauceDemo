using OpenQA.Selenium;
using SauceDemo.WebDriver.WebdriverWrapper;

namespace SauceDemo.BLL.PageObjects;

public class LoginPage(WebdriverWrapper driver)
{
    private readonly By userNameLocator = By.CssSelector("[data-test='username']");
    private readonly By passwordLocator = By.CssSelector("[data-test='password']");
    private readonly By LoginButtonLocator = By.CssSelector("[data-test='login-button']");
    private readonly By ErrorMessageLocator = By.CssSelector("[data-test='error']");

    
    public MainPage Login(string login, string password)
    {
        EnterLoginPassword(login, password);
        ClickLoginButton();
        
        return new MainPage(driver);
    }

    public void EnterLoginPassword(string login, string password)
    {
        driver.EnterText(userNameLocator, login);
        driver.EnterText(passwordLocator, password);
    }

    public void ClearPasswordField()
    {
        driver.ClearField(passwordLocator);
    }

    public void ClickLoginButton()
    {
        driver.Click(LoginButtonLocator);
    }

    public string GetErrorMessage()
    {
        return driver.FindElement(ErrorMessageLocator).Text;
    }
}