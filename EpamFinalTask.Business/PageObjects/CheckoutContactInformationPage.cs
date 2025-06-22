using EpamFinalTask.Core.Wrapper;
using log4net;
using OpenQA.Selenium;

namespace EpamFinalTask.Business.PageObjects;

public class CheckoutContactInformationPage : BasePage
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(CheckoutContactInformationPage));
    
    public CheckoutContactInformationPage(BrowserDriverWrapper driver) : base(driver)
    {
    }
    
    private readonly By _firstNameInputLocator = By.CssSelector("#first-name");
    private readonly By _lastNameInputLocator = By.CssSelector("#last-name");
    private readonly By _postalCodeInputLocator = By.CssSelector("#postal-code");
    private readonly By _continueButtonLocator = By.CssSelector("#continue");

    public CheckoutConfirmInformationPage FillOutInformationAndSubmit(string firstName, string lastName, string postalCode)
    {
        _logger.Info("Entering first name.");
        _driver.EnterText(_firstNameInputLocator, firstName);

        _logger.Info("Entering last name.");
        _driver.EnterText(_lastNameInputLocator, lastName);

        _logger.Info("Entering postal code.");
        _driver.EnterText(_postalCodeInputLocator, postalCode);

        _logger.Info("Clicking the Continue button.");
        _driver.Click(_continueButtonLocator);

        _logger.Info("Navigating to CheckoutConfirmInformationPage.");
        return new CheckoutConfirmInformationPage(_driver);
    }
}