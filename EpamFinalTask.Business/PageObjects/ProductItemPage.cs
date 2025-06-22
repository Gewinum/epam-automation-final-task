using EpamFinalTask.Core.Wrapper;
using log4net;
using OpenQA.Selenium;

namespace EpamFinalTask.Business.PageObjects;

public class ProductItemPage : BasePage
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(ProductItemPage));

    public ProductItemPage(BrowserDriverWrapper driver) : base(driver)
    {
    }
    
    private readonly By _productNameLocator = By.CssSelector(".inventory_details_name");
    private readonly By _productPriceLocator = By.CssSelector(".inventory_details_price");
    private readonly By _productAddToCartButtonLocator = By.CssSelector("#add-to-cart");
    private readonly By _productRemoveFromCartButtonLocator = By.CssSelector("#remove");
    
    public string GetName()
    {
        _logger.Info("Retrieving product name.");
        return _driver.FindElement(_productNameLocator).Text;
    }

    public string GetPrice()
    {
        _logger.Info("Retrieving product price.");
        return _driver.FindElement(_productPriceLocator).Text;
    }

    public ProductItemPage AddToCart()
    {
        _logger.Info("Adding product to cart.");
        _driver.Click(_productAddToCartButtonLocator);
        _driver.WaitForElementToBePresent(_productRemoveFromCartButtonLocator);
        _logger.Info("Product added to cart.");
        return this;
    }

    public ProductItemPage RemoveFromCart()
    {
        _logger.Info("Removing product from cart.");
        _driver.Click(_productRemoveFromCartButtonLocator);
        _driver.WaitForElementToBePresent(_productAddToCartButtonLocator);
        _logger.Info("Product removed from cart.");
        return this;
    }

    public MainPage NavigateBack()
    {
        _logger.Info("Navigating back to MainPage.");
        _driver.NavigateBack();
        return new MainPage(_driver);
    }
}