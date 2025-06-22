using EpamFinalTask.Business.PageObjects;
using EpamFinalTask.Core;
using EpamFinalTask.Core.Constants;
using EpamFinalTask.Core.Wrapper;
using FluentAssertions;

namespace EpamFinalTask.Tests;

public class LoginTests : IDisposable
{
    private readonly BrowserDriverWrapper _wrapper;
    private bool _disposed = false;

    public LoginTests()
    {
        var browserType = (BrowserType)Enum.Parse(typeof(BrowserType), Configuration.GetBrowserType());

        _wrapper = new BrowserDriverWrapper(browserType);
        _wrapper.StartBrowser();
        _wrapper.NavigateTo(Configuration.GetAppUrl());
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _wrapper?.Quit();
        }

        _disposed = true;
    }

    [Fact]
    public void AttemptToLoginWithoutCredentials()
    {
        var page = new LoginPage(_wrapper);
        page.EnterUsername("something");
        page.EnterPassword("something");
        page.ClearUsername();
        page.ClearPassword();
        page.ClickLoginButton();
        page.ErrorMessage().Should().Be(ErrorMessageConstants.UsernameIsRequired);
    }

    [Fact]
    public void AttemptToLoginWithoutPassword()
    {
        var page = new LoginPage(_wrapper);
        page.EnterUsername("something");
        page.EnterPassword("something");
        page.ClearPassword();
        page.ClickLoginButton();
        page.ErrorMessage().Should().Be(ErrorMessageConstants.PasswordIsRequired);
    }

    [Theory]
    [InlineData("wrong_user", "wrong_password")]
    [InlineData("standard_user", "wrong_password")]
    [InlineData("wrong_user", "secret_sauce")]
    public void AttemptToLoginWithWrongCredentials(string login, string password)
    {
        var page = new LoginPage(_wrapper);
        page.Login(login, password);
        page.ErrorMessage().Should().Be(ErrorMessageConstants.UsernameAndPasswordNotMatch);
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce")]
    [InlineData("problem_user", "secret_sauce")]
    [InlineData("performance_glitch_user", "secret_sauce")]
    [InlineData("error_user", "secret_sauce")]
    [InlineData("visual_user", "secret_sauce")]
    public void SuccessfullyLoginAndCheck(string login, string password)
    {
        var page = new LoginPage(_wrapper);
        page.Login(login, password).GetAppTitle().Should().Be(Configuration.GetAppTitle());
    }

    [Fact]
    public void AttemptToLoginWithLockedOutUserCredentials()
    {
        var page = new LoginPage(_wrapper);
        page.Login("locked_out_user", "secret_sauce");
        page.ErrorMessage().Should().Be(ErrorMessageConstants.UserLockedOut);
    }
}