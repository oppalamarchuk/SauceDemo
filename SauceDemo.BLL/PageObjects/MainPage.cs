using OpenQA.Selenium;
using SauceDemo.WebDriver.WebdriverWrapper;

namespace SauceDemo.BLL.PageObjects;

public class MainPage(WebdriverWrapper driver)
{
    private readonly By BurgerButtonLocator = By.CssSelector("#react-burger-menu-btn");
    private readonly By SwagLabelLocator = By.CssSelector(".app_logo");
    private readonly By CartIconLocator = By.CssSelector("[data-test='shopping-cart-link']");
    private readonly By DropdownLocator = By.CssSelector("[data-test='product-sort-container']");
    private readonly By ItemsListLocator = By.CssSelector("[data-test='inventory-list']");
    
    public bool IsBurgerVisible() => driver.FindElement(BurgerButtonLocator).Displayed;
    
    public bool IsLabelVisible() => driver.FindElement(SwagLabelLocator).Displayed;

    public bool IsCartIconVisible() => driver.FindElement(CartIconLocator).Displayed;

    public bool IsSortDropdownVisible() => driver.FindElement(DropdownLocator).Displayed;

    public bool IsInventoryListVisible() => driver.FindElement(ItemsListLocator).Displayed;
}
