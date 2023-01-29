using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using TheInternetPage.PageObject;

namespace TheInternetPage.Tests;

[Parallelizable(ParallelScope.All)]
[TestFixture()]
public class TheInternetPageTests : PageTest
{
    [Test]
    public void CheckmarkTest()
    {
        var checkboxesPage = TheInternet
            .Initialize(Page)
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
            .Initialize(Page)
            .Open()
            .ClickFormAuthentication()
            .EnterUsername("tomsmith")
            .EnterPassword("SuperSecretPassword!")
            .ClickLogin();

        StringAssert.Contains("You logged into a secure area!", SecureAreaPage.GetLoginStatus());
    }
}