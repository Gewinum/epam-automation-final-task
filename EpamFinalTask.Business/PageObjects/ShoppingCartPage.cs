using EpamFinalTask.Core.Wrapper;
using log4net;
using OpenQA.Selenium;

namespace EpamFinalTask.Business.PageObjects;

public class ShoppingCartPage : BasePage
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(ShoppingCartPage));

    public ShoppingCartPage(BrowserDriverWrapper driver) : base(driver)
    {
    }

    public class ShoppingCartItem
    {
        public ShoppingCartItem(IWebElement rootElement)
        {
            _rootElement = rootElement;
        }

        private readonly IWebElement _rootElement;
        
        private readonly By _itemQuantityLocator = By.CssSelector(".cart_quantity");
        private readonly By _itemNameLocator = By.CssSelector(".inventory_item_name");
        private readonly By _itemDescriptionLocator = By.CssSelector(".inventory_item_desc");
        private readonly By _itemPriceLocator = By.CssSelector(".inventory_item_price");
        private readonly By _itemRemoveFromCartLocator = By.CssSelector("button");

        public int GetQuantity()
        {
            // Logging inside nested class is optional, but can be added if needed
            return int.Parse(_rootElement.FindElement(_itemQuantityLocator).Text);
        }

        public string GetName()
        {
            return _rootElement.FindElement(_itemNameLocator).Text;
        }

        public string GetDescription()
        {
            return _rootElement.FindElement(_itemDescriptionLocator).Text;
        }

        public decimal GetPrice()
        {
            return decimal.Parse(_rootElement.FindElement(_itemPriceLocator).Text);
        }

        public void RemoveFromCart()
        {
            _rootElement.FindElement(_itemRemoveFromCartLocator).Click();
        }
    }
    
    private readonly By _checkOutButtonLocator = By.CssSelector("#checkout"); 
    private readonly By _cartItemLocator = By.CssSelector(".cart_item");

    public ShoppingCartItem[] GetShoppingCartItems()
    {
        _logger.Info("Retrieving shopping cart items.");
        var elements = _driver.FindElements(_cartItemLocator, false).ToArray();
        
        var items = new ShoppingCartItem[elements.Length];

        for (int i = 0; i < elements.Length; i++)
        {
            items[i] = new ShoppingCartItem(elements[i]);
        }
        
        _logger.Info("Found " + items.Length + " item(s) in the shopping cart.");
        return items;
    }

    public CheckoutContactInformationPage Checkout()
    {
        _logger.Info("Clicking the checkout button.");
        _driver.Click(_checkOutButtonLocator);
        _logger.Info("Navigating to CheckoutContactInformationPage.");
        return new CheckoutContactInformationPage(_driver);
    }
}