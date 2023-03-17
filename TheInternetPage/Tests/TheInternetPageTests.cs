using NUnit.Framework;
using static NUnit.Framework.TestContext;
using TheInternetPage.PageObject;
using FluentAssertions;

namespace TheInternetPage.Tests;

[Parallelizable(ParallelScope.All)]
[TestFixture()]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class TheInternetPageTests : TestBase
{
    [Test]
    public void CheckmarkTest()
	{
        //Act
        var checkboxesPage = TheInternet
            .Open()
            .ClickCheckboxes()
            .SelectCheckboxOne()
            .UnSelectCheckboxTwo();

        //Assertions
        checkboxesPage.IsCheckBoxOneSelected().Should().BeTrue();
        checkboxesPage.IsCheckBoxTwoSelected().Should().BeFalse();
    }

	[Test]
    public void LoginTest()
    {
        //Act
        var SecureAreaPage = TheInternet
            .Open()
            .ClickFormAuthentication()
            .EnterUsername(username: Parameters.Get("username"))
            .EnterPassword(password: Parameters.Get("password"))
            .ClickLogin();

        //Assertions
        SecureAreaPage.GetLoginStatus().Should().Contain("You logged into a secure area!");
    }
}