using EpamFinalTask.Core.Wrapper;
using log4net;
using OpenQA.Selenium;

namespace EpamFinalTask.Business.PageObjects;

public class LoginPage : BasePage
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(LoginPage));

    public LoginPage(BrowserDriverWrapper driver) : base(driver)
    {
    }
    
    private readonly By _userNameLocator = By.CssSelector("#user-name");
    private readonly By _passwordLocator = By.CssSelector("#password");
    private readonly By _loginButtonLocator = By.CssSelector("#login-button");
    private readonly By _errorMessageLocator = By.CssSelector("h3[data-test=\"error\"]");

    public MainPage Login(string login, string password)
    {
        _logger.Info("Entering username.");
        EnterUsername(login);

        _logger.Info("Entering password.");
        EnterPassword(password);

        _logger.Info("Clicking the Login button.");
        ClickLoginButton();

        _logger.Info("Navigating to MainPage.");
        return new MainPage(_driver);
    }
    
    public void EnterUsername(string username) => _driver.EnterText(_userNameLocator, username);
    
    public void EnterPassword(string password) => _driver.EnterText(_passwordLocator, password);
    
    public void ClearUsername() => _driver.ClearText(_userNameLocator);
    
    public void ClearPassword() => _driver.ClearText(_passwordLocator);
    
    public void ClickLoginButton() => _driver.Click(_loginButtonLocator);

    public string ErrorMessage()
    {
        _logger.Info("Retrieving error message.");
        return _driver.FindElement(_errorMessageLocator).Text;
    }
}