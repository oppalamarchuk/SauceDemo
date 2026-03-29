using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.WebDriver.WebdriverWrapper;

public partial class WebdriverWrapper
{
    public void Click(By by)
    {
        WaitForElementToBePresent(_driver, by, _timeout)?.Click();
    }

    public void EnterText(By by, string text)
    {
        var element = WaitForElementToBePresent(_driver, by, _timeout);
        element.Clear();
        element.SendKeys(text);
    }
    
    public IWebElement FindElement(By by)
    {
        return WaitForElementToBePresent(_driver, by, _timeout);
    }
    
    public IWebElement WaitForElementToBePresent(IWebDriver driver, By by, TimeSpan timeout)
    {
        var wait = new WebDriverWait(driver, timeout);
        wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        return wait.Until(ExpectedConditions.ElementIsVisible(by));
    }
    
    public void ClearField(By by) 
    {
        var element = WaitForElementToBePresent(_driver, by, _timeout);
        element.Click(); 
        element.SendKeys(Keys.Control + "a");
        element.SendKeys(Keys.Backspace);
    }
}
