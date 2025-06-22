using Microsoft.Extensions.Configuration;

namespace EpamFinalTask.Core;

public static class Configuration
{
    static Configuration() => Init();

    public static void Init()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();
        
        _browserType = configuration["BrowserType"] ?? "Chrome";
        _appUrl = configuration["ApplicationUrl"] ?? string.Empty;
        _appTitle = configuration["AppTitle"] ?? string.Empty;
    }

    private static string? _browserType;

    private static string? _appUrl;

    private static string? _appTitle;

    public static string GetBrowserType()
    {
        return _browserType!;
    }

    public static string GetAppUrl()
    {
        return _appUrl!;
    }

    public static string GetAppTitle()
    {
        return _appTitle!;
    }
}