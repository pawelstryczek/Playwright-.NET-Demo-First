using Microsoft.Playwright;
using System.Runtime.CompilerServices;

namespace TheInternetPage.PageObject
{
    internal class TheInternet
    {
        private readonly IPage _page;
        private readonly ILocator _checkboxLink;
        private readonly ILocator _formAuthentication;

        public static TheInternet Initialize(IPage page)
        {
            return new TheInternet(page);
        }
        public TheInternet(IPage page)
        {
            _page = page;
            _checkboxLink = page.Locator("a[href='/checkboxes']");
            _formAuthentication = page.Locator("a[href='/login']");
        }

        public TheInternet Open()
        {
            _page.GotoAsync("http://localhost:7080/").Wait();
            _checkboxLink.WaitForAsync(new() { State = WaitForSelectorState.Visible }).Wait();
            return this;
        }

        public CheckboxesPage ClickCheckboxes()
        {
            _checkboxLink.ClickAsync().Wait();
            return new(_page);
        }

        public LoginPage ClickFormAuthentication()
        {
            _formAuthentication.ClickAsync().Wait();
            return new(_page);
        }
    }
}
