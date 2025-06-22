using EpamFinalTask.Core.Wrapper;
using log4net;
using OpenQA.Selenium;

namespace EpamFinalTask.Business.PageObjects;

public class MainPage : BasePage
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(MainPage));

    public MainPage(BrowserDriverWrapper driver) : base(driver)
    {
    }
    
    private readonly By _appLogoLocator = By.CssSelector(".app_logo");
    private readonly By _bikeLightProductTitleLocator = By.CssSelector("#item_0_title_link");
    private readonly By _addShirtToCartLocator = By.CssSelector("#add-to-cart-sauce-labs-bolt-t-shirt");
    private readonly By _removeShirtFromCartLocator = By.CssSelector("#remove-sauce-labs-bolt-t-shirt");
    private readonly By _shoppingCartLinkLocator = By.CssSelector(".shopping_cart_link");

    public string GetAppTitle()
    {
        _logger.Info("Retrieving application title.");
        return _driver.FindElement(_appLogoLocator).Text;
    }
    
    public ProductItemPage NavigateToProduct()
    {
        _logger.Info("Navigating to product item page.");
        _driver.Click(_bikeLightProductTitleLocator);
        return new ProductItemPage(_driver);
    }

    public void AddShirtToCart()
    {
        _logger.Info("Adding shirt to cart.");
        _driver.FindElement(_addShirtToCartLocator).Click();
        _driver.WaitForElementToBePresent(_removeShirtFromCartLocator);
        _logger.Info("Shirt added to cart.");
    }

    public void RemoveShirtFromCart()
    {
        _logger.Info("Removing shirt from cart.");
        _driver.Click(_removeShirtFromCartLocator);
        _driver.WaitForElementToBePresent(_shoppingCartLinkLocator);
        _logger.Info("Shirt removed from cart.");
    }

    public ShoppingCartPage NavigateToShoppingCart()
    {
        _logger.Info("Navigating to shopping cart page.");
        _driver.Click(_shoppingCartLinkLocator);
        return new ShoppingCartPage(_driver);
    }
}