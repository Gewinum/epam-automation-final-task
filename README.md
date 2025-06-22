# Read before you scroll
So basically this can successfully run on edge and firefox. Chrome also works, choose any you're comfortable with.

Tests work both on Linux and Windows, test on anything you want

On linux its just after some investigation I found out that snap firefox isnt suitable

And about modifying browser or app url, please see Core/appsettings.json. As browser you can put either Edge, Firefox or Chrome. Don't forget about advice up there

Also don't look at any pageobjects except loginpage and mainpage because all others i have accidentally overdone, like i didn't need them

Also while touching or doing something with these tests it is advised to be careful. I'm using Meziantou.Xunit.ParallelTestFramework to speed up tests but it can cause issues with isolation if isolation issues are not mitigated

# Task description
Launch URL: https://www.saucedemo.com/

**UC-1** Test Login form with empty credentials:
Type any credentials into "Username" and "Password" fields
Clear the inputs
Hit the "Login" button.
Check the error messages: "Username is required"

**UC-2** Test Login form with credentials by passing Username:
Type any credentials in username.
Enter password.
Clear the "Password" input.
Hit the "Login" button.
Check the error messages: "Password is required"

**UC-3** Test Login form with credentials by passing Username & Password:
Type credentials in username which are under Accepted username sections.

Enter password as secret sauce.

Click on Login and validate the title "Swag Labs" in the dashboard.

Provide parallel execution, add logging for tests and use Data Provider to parametrize tests. Make sure that all tasks are supported by these 3 conditions: UC-1; UC-2; UC-3.

Please, add task description as README.md into your solution!

**To perform the task use the various of additional options:**

Test Automation tool: Selenium WebDriver;

Browsers: 1) Edge; 2) Firefox;

Locators: CSS;

Test Runner: xUnit;

[Optional] Patterns: 1) Abstract Factory; 2) Adapter; 3) Bridge

[Optional] Test automation approach: BDD;

Assertions: FluentAssertions;

[Optional] Loggers: Log4Net.