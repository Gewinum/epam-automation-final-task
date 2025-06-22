using EpamFinalTask.Core.Factory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace EpamFinalTask.Core.Wrapper;

public class BrowserDriverWrapper
{
    private readonly TimeSpan _timeout;

    private readonly IWebDriver _driver;

    private const int WaitTimeInSeconds = 10;

    public BrowserDriverWrapper(BrowserType browserType)
    {
        _driver = BrowserFactory.CreateWebDriver(browserType);
        _timeout = TimeSpan.FromSeconds(WaitTimeInSeconds);
    }

    public void StartBrowser(int implicitWaitTime = 10)
    {
        _driver.Manage().Window.Maximize();
    }

    public void Quit()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    public void NavigateTo(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public void NavigateBack()
    {
        _driver.Navigate().Back();
    }

    public void NavigateForward()
    {
        _driver.Navigate().Forward();
    }

    public void WindowMaximize()
    {
        _driver.Manage().Window.Maximize();
    }

    public string GetTitle()
    {
        return _driver.Title;
    }

    public string GetUrl()
    {
        return _driver.Url;
    }

    public void Click(By by)
    {
        var element = _driver.FindElement(by);
        var clickAndSendKeysActions = new Actions(_driver);
        clickAndSendKeysActions
            .Click(element)
            .Pause(TimeSpan.FromSeconds(0.1))
            .Perform();
    }

    public void EnterText(By by, string text)
    {
        var element = WaitForElementToBePresent(by);
        element!.Clear();
        element.SendKeys(text);
    }

    public void ClearText(By by)
    {
        var element = WaitForElementToBePresent(by);
        new Actions(_driver)
            .Click(element!)
            .Pause(TimeSpan.FromSeconds(0.1))
            .KeyDown(OperatingSystem.IsMacOS() ? Keys.Command : Keys.Control)
            .SendKeys("a")
            .KeyUp(OperatingSystem.IsMacOS() ? Keys.Command : Keys.Control)
            .Pause(TimeSpan.FromSeconds(0.1))
            .SendKeys(Keys.Backspace)
            .Perform();
    }

    public IReadOnlyCollection<IWebElement> FindElements(By by, bool wait = true)
    {
        if (wait)
        {
            WaitForElementToBePresent(by);
        }

        return _driver.FindElements(by);
    }

    public IWebElement FindElement(By by)
    {
        var elementPresent = WaitForElementToBePresent(by);
        return elementPresent!;
    }

    public IWebElement? WaitForElementToBePresent(By by)
    {
        return WaitForElementWithCondition(drv =>
        {
            var element = drv.FindElement(by);
            return element.Displayed ? element : null;
        });
    }

    public IWebElement? WaitForElementWithCondition(Func<IWebDriver, IWebElement?> condition)
    {
        var wait = new WebDriverWait(_driver, _timeout);
        return wait.Until(condition);
    }
}