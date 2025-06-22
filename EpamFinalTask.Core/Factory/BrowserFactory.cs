using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace EpamFinalTask.Core.Factory;

public static class BrowserFactory
{
    public static IWebDriver CreateWebDriver(BrowserType browserType)
    {
        switch (browserType)
        {
            case BrowserType.Edge:
                var edgeOptions = new EdgeOptions();
                edgeOptions.AddArgument("inprivate");
                edgeOptions.AddArgument("disable-infobars");
                return new EdgeDriver(edgeOptions);
            case BrowserType.Firefox:
                var firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArgument("-private");
                firefoxOptions.Profile = new FirefoxProfile();
                return new FirefoxDriver(firefoxOptions);
            case BrowserType.Chrome:
                var service = ChromeDriverService.CreateDefaultService();
                ChromeOptions options = new();
                options.AddArgument("disable-infobars");
                options.AddArgument("--incognito");
                return new ChromeDriver(service, options);
            default:
                throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
        }
    }
}