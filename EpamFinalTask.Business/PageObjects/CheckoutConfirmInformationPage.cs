using EpamFinalTask.Core.Wrapper;
using log4net;
using OpenQA.Selenium;

namespace EpamFinalTask.Business.PageObjects;

public class CheckoutConfirmInformationPage : BasePage
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(CheckoutConfirmInformationPage));
    
    public CheckoutConfirmInformationPage(BrowserDriverWrapper driver) : base(driver)
    {
    }
    
    private readonly By _finishButtonLocator = By.CssSelector("#finish");
    private readonly By _checkoutCompleteContainerLocator = By.CssSelector("#checkout_complete_container");

    public void Finish()
    {
        _driver.Click(_finishButtonLocator);
        _logger.Info("Waiting for checkout complete container.");
        _driver.FindElement(_checkoutCompleteContainerLocator);
        _logger.Info("Checkout process finished.");
    }
}