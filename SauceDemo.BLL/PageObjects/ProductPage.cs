using OpenQA.Selenium;
using SauceDemo.WebDriver.WebdriverWrapper;

namespace SauceDemo.BLL.PageObjects;

public class ProductPage(WebdriverWrapper driver)
{
    private readonly By AddToCartLocator = By.CssSelector("[data-test='add-to-cart']");
    private readonly By CartBadgeLocator = By.CssSelector("[data-test='shopping-cart-badge']");


    public void AddToCart()
    {
        driver.Click(AddToCartLocator);
    }

    public bool IsCartBadgeDisplayed() => driver.FindElement(CartBadgeLocator).Displayed;
}