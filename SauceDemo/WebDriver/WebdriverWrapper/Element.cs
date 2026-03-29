using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var elementPresent = WaitForElementToBePresent(_driver, by, _timeout);
            return elementPresent.FindElements(by);
        }

        public IWebElement FindElement(By by)
        {
            return WaitForElementToBePresent(_driver, by, _timeout);
        }

        public IWebElement FindChildByName(By byParent, string childName)
        {
            var elementParent = WaitForElementToBePresent(_driver, byParent, _timeout);
            return elementParent.FindElement(By.Name(childName));
        }

        public void ClickAndSendAction(IWebElement element, string textToSend)
        {
            var clickAndSendKeysActions = new Actions(_driver);
            clickAndSendKeysActions.Click(element)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(textToSend)
                .Perform();
        }

        public IWebElement WaitForElementToBePresent(IWebDriver driver, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
    
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }    
    }
