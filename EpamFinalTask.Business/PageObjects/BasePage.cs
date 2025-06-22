using EpamFinalTask.Core.Wrapper;

namespace EpamFinalTask.Business.PageObjects;

public abstract class BasePage
{
    protected BrowserDriverWrapper _driver;

    protected BasePage(BrowserDriverWrapper driver)
    {
        _driver = driver;
    }
}