using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using TheInternetPage.PageObject;

namespace TheInternetPage.Tests
{
    public class TestBase : ContextTest
    {
        public IPage Page { get; private set; } = null!;

        internal TheInternet? TheInternet;

        [SetUp]
        public void PageSetup()
        {
            Page = Context.NewPageAsync().Result;
            Page.Context.ConfigureAwait(false);
            TheInternet = TheInternet.Initialize(Page);
        }    
    }
}
