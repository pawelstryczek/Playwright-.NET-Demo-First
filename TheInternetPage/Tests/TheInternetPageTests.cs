using NUnit.Framework;
using TheInternetPage.PageObject;

namespace TheInternetPage.Tests;

[Parallelizable(ParallelScope.All)]
[TestFixture()]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class TheInternetPageTests : TestBase
{
    [Test]
    public void CheckmarkTest()
    {
        var checkboxesPage = TheInternet
            .Open()
            .ClickCheckboxes()
            .SelectCheckboxOne()
            .UnSelectCheckboxTwo();
        
        Assert.That(checkboxesPage.IsCheckBoxOneSelected(), Is.True);
        Assert.That(checkboxesPage.IsCheckBoxTwoSelected(), Is.False);
    }

    [Test]
    public void LoginTest()
    {
        var SecureAreaPage = TheInternet
            .Open()
            .ClickFormAuthentication()
            .EnterUsername("tomsmith")
            .EnterPassword("SuperSecretPassword!")
            .ClickLogin();

        StringAssert.Contains("You logged into a secure area!", SecureAreaPage.GetLoginStatus());
    }
}